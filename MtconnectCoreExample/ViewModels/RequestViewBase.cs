using ConsoulLibrary;
using ConsoulLibrary.Views;
using MtconnectCore;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Documents;
using MtconnectCore.Standard.Documents.Streams;
using MtconnectCoreExample.ViewModels;
using System;

namespace MtconnectCoreExample.Views
{
    public abstract class RequestViewBase : DynamicView<RequestBase>
    {
        public RequestViewBase()
        {
            Title = (new BannerEntry("MTConnect Example")).Message;
            Source = new RequestBase();
        }

        internal string _setProtocolMessage() => "Protocol: " + (string.IsNullOrEmpty(Source.Protocol) ? "NA" : Source.Protocol);
        internal ConsoleColor _setProtocolColor() => string.IsNullOrEmpty(Source.Protocol) ? ConsoleColor.Yellow : ConsoleColor.Green;
        [DynamicViewOption(nameof(_setProtocolMessage), nameof(_setProtocolColor))]
        public void SetProtocol() {
            Source.Protocol = Consoul.Input("Enter the protocol or scheme of the request (ie. http or https):", ConsoleColor.Yellow);
        }

        internal string _setHostMessage() => "Host: " + (string.IsNullOrEmpty(Source.Host) ? "NA" : Source.Host);
        internal ConsoleColor _setHostColor() => string.IsNullOrEmpty(Source.Host) ? ConsoleColor.Yellow : ConsoleColor.Green;
        [DynamicViewOption(nameof(_setHostMessage), nameof(_setHostColor))]
        public void SetHost()
        {
            Source.Host = Consoul.Input("Enter the host of the request (ie. 123.45.678.9:80 or somenamedserver:80):", ConsoleColor.Yellow);
        }

        internal string _setQueryMessage() => "Query: " + (string.IsNullOrEmpty(Source.Query) ? "NA" : Source.Query);
        internal ConsoleColor _setQueryColor() => string.IsNullOrEmpty(Source.Query) ? ConsoleColor.Yellow : ConsoleColor.Green;
        [DynamicViewOption(nameof(_setQueryMessage), nameof(_setQueryColor))]
        public void SetQuery()
        {
            Source.Query = Consoul.Input("Enter additional query parameter(s) and delimit using ampersand (&) (ie. some=parameter&another=parameter):", ConsoleColor.Yellow);
        }

        internal string _sendMessage() => "Send (" + (Source.IsValid() ? "Ready" : "Not Ready") + ")";
        internal ConsoleColor _sendColor() => Source.IsValid() ? ConsoleColor.Green : ConsoleColor.Red;
        [DynamicViewOption(nameof(_sendMessage), nameof(_sendColor))]
        public abstract void Send();
    }
}
