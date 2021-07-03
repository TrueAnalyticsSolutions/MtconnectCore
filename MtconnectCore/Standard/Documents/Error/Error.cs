using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums.Error;
using MtconnectCore.Standard.Contracts.Enums.Error.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace MtconnectCore.Standard.Documents.Error
{
    /// <summary>
    /// Represents the Error element of the MTConnect Standard. See Part 1, Section 9.1.2 of the MTConnect Standard
    /// </summary>
    public class Error : MtconnectNode
    {
        [MtconnectNodeAttribute(ErrorAttributes.ERROR_CODE)]
        public ErrorCodes ErrorCode { get; set; }

        public string Value { get; set; }

        public Error() : base() { }
        public Error(XmlNode xNode, XmlNamespaceManager nsmgr) : base(xNode, nsmgr, Constants.DEFAULT_XML_NAMESPACE)
        {
            Value = xNode.InnerText;
        }
    }
}
