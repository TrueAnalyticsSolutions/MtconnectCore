using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums.Devices;
using MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes;
using System;
using System.Linq;
using System.Reflection;

namespace MtconnectCore.Standard.Contracts
{
    /// <summary>
    /// A reference to an observational type and sub-type.
    /// </summary>
    public class Observation
    {
        /// <summary>
        /// Category for the observation reference (ie. SAMPLE, EVENT, or CONDITION)
        /// </summary>
        public virtual CategoryTypes Category { get; }

        /// <summary>
        /// Raw observational type
        /// </summary>
        public string Type { get; }
        /// <summary>
        /// Reference, if any, to the explicit type defined in the standard.
        /// </summary>
        public Enum ExplicitType { get; }

        /// <summary>
        /// Raw observational sub-type
        /// </summary>
        public string SubType { get; }
        /// <summary>
        /// Reference, if any, to the explicit sub-type defined in the standard for the provided <see cref="Type"/>.
        /// </summary>
        public Enum ExplicitSubType { get; }

        /// <summary>
        /// Constructs a new observation as a reference.
        /// </summary>
        /// <param name="category"><inheritdoc cref="Category" path="/summary" /></param>
        /// <param name="type"><inheritdoc cref="Type" path="/summary" /></param>
        /// <param name="subType"><inheritdoc cref="SubType" path="/summary" /></param>
        /// <exception cref="ArgumentException"></exception>
        public Observation(CategoryTypes category, string type, string subType = null)
        {
            Category = category;
            Type = type;
            SubType = subType;

            try
            {
                switch (Category)
                {
                    case CategoryTypes.SAMPLE:
                        var sampleType = Enum.Parse(typeof(SampleTypes), Type, true);
                        if (sampleType != null)
                        {
                            ExplicitType = (SampleTypes)sampleType;
                        }
                        break;
                    case CategoryTypes.EVENT:
                        var eventType = Enum.Parse(typeof(EventTypes), Type, true);
                        if (eventType != null)
                        {
                            ExplicitType = (EventTypes)eventType;
                        }
                        break;
                    case CategoryTypes.CONDITION:
                        var conditionType = Enum.Parse(typeof(ConditionTypes), Type, true);
                        // TODO: Evaluate SAMPLE and EVENT types as well
                        if (conditionType != null)
                        {
                            ExplicitType = (ConditionTypes)conditionType;
                        }
                        break;
                    default:
                        throw new ArgumentException();
                }

                if (ExplicitType != null)
                {
                    Type typeEnum = ExplicitType.GetType();
                    MemberInfo enumMember = typeEnum.GetMember(ExplicitType.ToString()).FirstOrDefault();

                    var subTypeAttr = enumMember?.GetCustomAttribute<ObservationalSubTypeAttribute>();
                    if (subTypeAttr != null)
                    {
                        var subTypeResult = Enum.Parse(subTypeAttr.SubTypeEnum, SubType, true);
                        if (subTypeResult != null)
                        {
                            ExplicitSubType = subTypeResult as Enum;
                        }
                    }
                }
            }
            catch (Exception ex) { }
        }

        /// <summary>
        /// <inheritdoc cref="Observation(CategoryTypes, string, string)" />
        /// </summary>
        /// <param name="category"><inheritdoc cref="Category" path="/summary" /></param>
        /// <param name="type"><inheritdoc cref="Type" path="/summary" /></param>
        /// <param name="subType"><inheritdoc cref="SubType" path="/summary" /></param>
        public Observation(CategoryTypes category, Enum type, string subType = null) : this(category, type.ToString(), subType) { }
        /// <summary>
        /// <inheritdoc cref="Observation(CategoryTypes, string, string)" />
        /// </summary>
        /// <param name="category"><inheritdoc cref="Category" path="/summary" /></param>
        /// <param name="type"><inheritdoc cref="Type" path="/summary" /></param>
        /// <param name="subType"><inheritdoc cref="SubType" path="/summary" /></param>
        public Observation(CategoryTypes category, Enum type, Enum subType = null) : this(category, type, subType?.ToString()) { }
    }
    /// <summary>
    /// A reference to an observational EVENT type and sub-type.
    /// </summary>
    public class EventObservation : Observation
    {
        /// <summary>
        /// EVENT Category for the observation reference.
        /// </summary>
        public override CategoryTypes Category => CategoryTypes.EVENT;

        /// <summary>
        /// Reference, if any, to the explicit EVENT type defined in the standard.
        /// </summary>
        new public EventTypes ExplicitType { get; }

        /// <inheritdoc cref="Observation(CategoryTypes, string, string)"/>
        public EventObservation(string type, string subType = null) : base(CategoryTypes.EVENT, type, subType) { }
        /// <inheritdoc cref="Observation(CategoryTypes, Enum, string)"/>
        public EventObservation(EventTypes type, string subType = null) : base(CategoryTypes.EVENT, type, subType) { }
        /// <inheritdoc cref="Observation(CategoryTypes, Enum, Enum)"/>
        public EventObservation(EventTypes type, Enum subType = null) : base(CategoryTypes.EVENT, type, subType) { }
    }
    /// <summary>
    /// A reference to an observational SAMPLE type and sub-type.
    /// </summary>
    public class SampleObservation : Observation
    {
        /// <summary>
        /// SAMPLE Category for the observation reference.
        /// </summary>
        public override CategoryTypes Category => CategoryTypes.SAMPLE;

        /// <summary>
        /// Reference, if any, to the explicit SAMPLE type defined in the standard.
        /// </summary>
        new public SampleTypes ExplicitType { get; }

        /// <inheritdoc cref="Observation(CategoryTypes, string, string)"/>
        public SampleObservation(string type, string subType = null) : base(CategoryTypes.SAMPLE, type, subType) { }
        /// <inheritdoc cref="Observation(CategoryTypes, Enum, string)"/>
        public SampleObservation(SampleTypes type, string subType = null) : base(CategoryTypes.SAMPLE, type, subType) { }
        /// <inheritdoc cref="Observation(CategoryTypes, Enum, Enum)"/>
        public SampleObservation(SampleTypes type, Enum subType = null) : base(CategoryTypes.SAMPLE, type, subType) { }
    }
}
