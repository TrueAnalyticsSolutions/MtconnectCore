using System;

namespace MtconnectCore.Standard.Contracts.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
    public class ObservationalValueAttribute : Attribute
    {
        public Type ValueEnum { get; set; }

        public ObservationalValueAttribute(Type valueEnum)
        {
            ValueEnum = valueEnum;
        }
    }
}
