﻿using ConsoulLibrary;
using ConsoulLibrary.Views;
using MtconnectCore;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Documents.Error;
using MtconnectCore.Standard.Documents.Streams;
using MtconnectCoreExample.ViewModels;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MtconnectCoreExample.Views
{
    public class CurrentIntervalRequestView : RequestViewBase {
        private int Interval = 2000;

        public CurrentIntervalRequestView()
        {
            Title = (new BannerEntry("MTConnect Current Interval Example")).Message;
            Source = new RequestBase()
            {
                Directory = RequestTypes.CURRENT.ToString().ToLower()
            };
        }

        internal string _setIntervalMessage() => $"Interval: {Interval}";
        internal ConsoleColor _setIntervalColor() => Interval <= 0 ? ConsoleColor.Red : ConsoleColor.Green;
        [DynamicViewOption(nameof(_setIntervalMessage), nameof(_setIntervalColor))]
        public void SetInterval()
        {
            int interval;
            string strInterval;
            do
            {
                strInterval = Consoul.Input("Enter the interval that the MTConnect Agent should update the document:");
            } while (!int.TryParse(strInterval, out interval));
            Interval = interval;
        }

        public override void Send()
        {
            Uri uri = Source.ToUri();
            bool canLoop = true;
            MtconnectIntervalStreamCallback callback = async (document) => {
                Console.Clear();
                Consoul.Write($"Press any key to stop...", ConsoleColor.DarkGray);
                if (document is ErrorDocument)
                {
                    ErrorDocument errorDoc = document as ErrorDocument;
                    foreach (var item in errorDoc.Items)
                    {
                        Consoul.Write($"[{item.ErrorCode}] {item.Value}", ConsoleColor.Red);
                    }
                }
                else if (document is StreamsDocument)
                {
                    StreamsDocument streamDoc = document as StreamsDocument;
                    Consoul.Write($"{streamDoc.Header.CreationTime}\t- NextSequence={streamDoc.Header.NextSequence} from {uri}", ConsoleColor.White);
                } else {
                    Consoul.Write($"Unhandled document type: {document.Type}");
                }
            };
            using (CancellationTokenSource token = new CancellationTokenSource())
            {
                Task waitForKeyTask = Task.Run(() => {
                    Console.Clear();
                    Consoul.Write($"Press any key to stop...", ConsoleColor.DarkGray);
                    while (canLoop && !token.IsCancellationRequested)
                    {
                        if (Console.KeyAvailable)
                        {
                            canLoop = false;
                        }
                        System.Threading.Thread.Sleep(Interval);
                    }
                    token.Cancel();
                });
                AgentConnector.QueryStreamAsync(uri, Interval, callback, token.Token)
                .ContinueWith((task) =>
                {
                    Consoul.Write($"An error occurred while requesting interval document.");
                    token.Cancel();
                }, TaskContinuationOptions.OnlyOnFaulted);
                waitForKeyTask.Wait();
            }

            Consoul.Write("Done!", ConsoleColor.Green);
            Consoul.Wait();
        }
    }
}
