using System;
using System.Collections.Generic;
using System.Text;

namespace MtconnectCoreExample.ViewModels
{
    public class RequestBase
    {
        public string Protocol { get; set; } = "http";

        public string Host { get; set; }

        public string Directory { get; set; }

        public RequestBase() { }

        public override string ToString() => $"{Protocol}://{Host}/";

        public Uri ToUri() => new Uri(ToString());

        public bool IsValid() => !string.IsNullOrEmpty(Protocol)
            && !string.IsNullOrEmpty(Host)
            && !string.IsNullOrEmpty(Directory);
    }
}
