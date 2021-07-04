using System;

namespace MtconnectCore.Standard
{
    public abstract class RequestQuery {
        public abstract bool Validate(out Exception exception);
        public abstract string ToString();
    }
}
