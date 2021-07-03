namespace MtconnectCore.Standard.Contracts.Attributes
{
    public class MtconnectNodeElementsAttribute : MtconnectNodeAttribute
    {
        public string TryAddMethod { get; set; }

        public MtconnectNodeElementsAttribute(object name, string tryAddMethodName) : base(name)
        {
            TryAddMethod = tryAddMethodName;
        }
    }
}
