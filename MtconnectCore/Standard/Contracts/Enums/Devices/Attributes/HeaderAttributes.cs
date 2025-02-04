using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Devices.Attributes
{
    [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, Constants.ModelBrowserLinks.DeviceModel.HEADER)]
    public enum HeaderAttributes
    {
        /// <summary>
        /// maximum number of Asset types that can be stored in the agent that published the response document. Note: The implementer is responsible for allocating the appropriate amount of storage capacity required to accommodate the  Header::assetBufferSize.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, Constants.ModelBrowserLinks.DeviceModel.HEADER)]
        ASSET_BUFFER_SIZE,
        /// <summary>
        /// current number of Asset that are currently stored in the agent as of the  Header::creationTime that the agent published the response document. Header::assetCount MUST NOT be larger than the value reported for  Header::assetBufferSize.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, Constants.ModelBrowserLinks.DeviceModel.HEADER)]
        ASSET_COUNT,
        /// <summary>
        /// maximum number of DataItems that MAY be retained in the agent that published the response document at any point in time. Note 1 to entry:  Header::bufferSize represents the maximum number of sequence numbers that MAY be stored in the agent. Note 2 to entry: The implementer is responsible for allocating the appropriate amount of storage capacity required to accommodate the  Header::bufferSize.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, Constants.ModelBrowserLinks.DeviceModel.HEADER)]
        BUFFER_SIZE,
        /// <summary>
        /// timestamp that an agent published the response document.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, Constants.ModelBrowserLinks.DeviceModel.HEADER)]
        CREATION_TIME,
        /// <summary>
        /// identifier for a specific instantiation of the buffer associated with the agent that published the response document. Header::instanceId MUST be changed to a different unique number each time the buffer is cleared and a new set of data begins to be collected.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, Constants.ModelBrowserLinks.DeviceModel.HEADER)]
        INSTANCE_ID,
        /// <summary>
        /// identification defining where the agent that published the response document is installed or hosted. Header::sender MUST be either an IP Address or Hostname describing where the agent is installed or the URL of the agent; e.g., http://&lt;address>[:port]/. Note: The port number need not be specified if it is the default HTTP port 80.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, Constants.ModelBrowserLinks.DeviceModel.HEADER)]
        SENDER,
        /// <summary>
        /// indicates whether the agent that published the response document is operating in a test mode. If  Header::testIndicator is not specified, the value for  Header::testIndicator MUST be interpreted to be false.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, Constants.ModelBrowserLinks.DeviceModel.HEADER)]
        TEST_INDICATOR,
        /// <summary>
        /// major, minor, and revision number of the MTConnect Standard that defines the semantic data model that represents the content of the response document. It also includes the revision number of the schema associated with that specific semantic data model. As an example, the value reported for  Header::version for a response document that was structured based on schema revision 10 associated with Version 1.4.0 of the MTConnect Standard would be: 1.4.0.10
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, Constants.ModelBrowserLinks.DeviceModel.HEADER)]
        VERSION,
        /// <summary>
        /// sequence number assigned to the oldest piece of streaming data stored in the buffer of the agent immediately prior to the time that the agent published the response document.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, Constants.ModelBrowserLinks.DeviceModel.HEADER, MtconnectVersions.V_1_2_0)]
        FIRST_SEQUENCE,
        /// <summary>
        /// sequence number assigned to the last piece of streaming data that was added to the buffer of the agent immediately prior to the time that the agent published the response document.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, Constants.ModelBrowserLinks.DeviceModel.HEADER, MtconnectVersions.V_1_2_0)]
        LAST_SEQUENCE,
        /// <summary>
        /// sequence number of the piece of streaming data that is the next piece of data to be retrieved from the buffer of the agent that was not included in the response document published by the agent. If the streaming data included in the response document includes the last piece of data stored in the buffer of the agent at the time that the document was published, then the value reported for  Header::nextSequence MUST be equal to  Header::lastSequence + 1.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, Constants.ModelBrowserLinks.DeviceModel.HEADER, MtconnectVersions.V_1_2_0)]
        NEXT_SEQUENCE,
        /// <summary>
        /// timestamp of the last update of the  Device information for any device.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, Constants.ModelBrowserLinks.DeviceModel.HEADER)]
        DEVICE_MODEL_CHANGE_TIME
    }
}
