using ConsoulLibrary;
using Microsoft.Extensions.Logging;
using MtconnectTranspiler;
using MtconnectTranspiler.Sinks.CSharp;
using MtconnectTranspiler.Sinks.MtconnectCore;
using System.Threading.Tasks;

internal class Program
{
    private static void Main(string[] args)
    {
        if (args.Length == 0) throw new ArgumentNullException(nameof(args), "Missing projectPath argument");

        string projectPath = args[0];
        if (!Directory.Exists(projectPath))
        {
            Consoul.Write("Creating project path: " + projectPath);
            Directory.CreateDirectory(projectPath);
        }

        var logger = LoggerFactory.Create((o) => o.AddConsoulLogger())
            .CreateLogger<TranspilerDispatcher>();

        // NOTE: The GitHubRelease can be a reference to a specific tag referring to the version in which to download.
        var dispatchOptions = new FromGitHubOptions() { GitHubRelease = "latest" };

        using (var tokenSource = new CancellationTokenSource())
        using (var dispatcher = new TranspilerDispatcher(dispatchOptions, logger))
        {
            dispatcher.AddSink(new Transpiler(projectPath));

            var task = Task.Run(() => dispatcher.TranspileAsync(tokenSource.Token)).ContinueWith((t) => tokenSource.Cancel());

            Consoul.Wait(cancellationToken: tokenSource.Token);

            if (task.IsCompletedSuccessfully)
            {
                Consoul.Write("Done!", ConsoleColor.Green);

                Environment.Exit(0);
            } else
            {
                Consoul.Write("Cancelled", ConsoleColor.Red);
                Environment.Exit(1);
            }

        }
    }
}