﻿using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Enums.Streams.Attributes;
using MtconnectCore.Standard.Contracts.Errors;
using MtconnectCore.Validation;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using static MtconnectCore.Logging.MtconnectCoreLogger;

namespace MtconnectCore.Standard.Documents.Streams
{
    public class Component : MtconnectNode
    {
        private const string MODEL_BROWSER_URL = "https://model.mtconnect.org/#Structure__EAID_9057AAF9_4687_42be_BD2B_E2F18DF049DC";

        /// <inheritdoc cref="ComponentAttributes.COMPONENT_ID"/>
        [MtconnectNodeAttribute(ComponentAttributes.COMPONENT_ID)]
        public string ComponentId { get; set; }

        /// <inheritdoc cref="ComponentAttributes.NAME"/>
        [MtconnectNodeAttribute(ComponentAttributes.NAME)]
        public string Name { get; set; }

        /// <inheritdoc cref="ComponentAttributes.NATIVE_NAME"/>
        [MtconnectNodeAttribute(ComponentAttributes.NATIVE_NAME)]
        public string NativeName { get; set; }

        /// <inheritdoc cref="ComponentAttributes.COMPONENT"/>
        [MtconnectNodeAttribute(ComponentAttributes.COMPONENT)]
        public string ComponentReference { get; set; }

        /// <inheritdoc cref="ComponentAttributes.UUID"/>
        [MtconnectNodeAttribute(ComponentAttributes.UUID)]
        public string Uuid { get; set; }

        private List<Sample> _samples = new List<Sample>();
        /// <summary>
        /// Samples groups one or more Sample entities. See Section Sample.
        /// </summary>
        [MtconnectNodeElements("Samples/*", nameof(TryAddSample))]
        public ICollection<Sample> Samples => _samples;

        private List<Event> _events = new List<Event>();
        /// <summary>
        /// Events groups one or more Event entities. See Section Event.
        /// </summary>
        [MtconnectNodeElements("Events/*", nameof(TryAddEvent))]
        public ICollection<Event> Events => _events;

        private List<Condition> _conditions = new List<Condition>();
        /// <summary>
        /// Conditions groups one or more Condition entities. See Section Condition.
        /// Note: In the XML representation, Conditions MUST appear as Condition element in the MTConnectStreams Response Document.
        /// </summary>
        [MtconnectNodeElements("Condition/*", nameof(TryAddCondition))]
        public ICollection<Condition> Conditions => _conditions;

        /// <inheritdoc/>
        public Component() { }

        /// <inheritdoc/>
        public Component(XmlNode xNode, XmlNamespaceManager nsmgr, MtconnectVersions version) : base(xNode, nsmgr, version) { }

        public bool TryAddSample(XmlNode xNode, XmlNamespaceManager nsmgr, out Sample sample)
        {
            if (xNode.Name.EndsWith("DataSet"))
            {
                var dataset = new List<SampleDataSet>();
                var datasetParseResult = base.TryAdd<SampleDataSet>(xNode, nsmgr, ref dataset, out SampleDataSet datasetInstance);
                if (datasetParseResult)
                    _samples.Add(datasetInstance);
                sample = datasetInstance;
                return datasetParseResult;
            }
            else if (xNode.Name.EndsWith("Table"))
            {
                var table = new List<SampleTable>();
                var tableParseResult = base.TryAdd<SampleTable>(xNode, nsmgr, ref table, out SampleTable tableInstance);
                if (tableParseResult)
                    _samples.Add(tableInstance);
                sample = tableInstance;
                return tableParseResult;
            }
            else if (xNode.Name.EndsWith("TimeSeries"))
            {
                var timeseries = new List<SampleTimeSeries>();
                var timeseriesParseResult = base.TryAdd<SampleTimeSeries>(xNode, nsmgr, ref timeseries, out SampleTimeSeries timeseriesInstance);
                if (timeseriesParseResult)
                    _samples.Add(timeseriesInstance);
                sample = timeseriesInstance;
                return timeseriesParseResult;
            }
            else
            {
                return base.TryAdd<Sample>(xNode, nsmgr, ref _samples, out sample);
            }
        }

        public bool TryAddEvent(XmlNode xNode, XmlNamespaceManager nsmgr, out Event @event)
        {
            if (xNode.Name.EndsWith("DataSet"))
            {
                var dataset = new List<EventDataSet>();
                var datasetParseResult = base.TryAdd<EventDataSet>(xNode, nsmgr, ref dataset, out EventDataSet datasetInstance);
                if (datasetParseResult)
                    _events.Add(datasetInstance);
                @event = datasetInstance;
                return datasetParseResult;
            } else if (xNode.Name.EndsWith("Table")){
                var table = new List<EventTable>();
                var tableParseResult = base.TryAdd<EventTable>(xNode, nsmgr, ref table, out EventTable tableInstance);
                if (tableParseResult)
                    _events.Add(tableInstance);
                @event = tableInstance;
                return tableParseResult;
            } else
            {
                return base.TryAdd<Event>(xNode, nsmgr, ref _events, out @event);
            }
        }

        public bool TryAddCondition(XmlNode xNode, XmlNamespaceManager nsmgr, out Condition condition) => base.TryAdd<Condition>(xNode, nsmgr, ref _conditions, out condition);

        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, MODEL_BROWSER_URL)]
        private bool ValidateProperties(out ICollection<MtconnectValidationException> validationErrors)
        {
            return new NodeValidationContext(this)
                // Validate componentId
                .ValidateValueProperty(
                    ComponentAttributes.COMPONENT_ID,
                    (o) =>
                        o.IsImplemented(ComponentId)
                        ?.WhileIntroduced((i) =>
                            i.IsRequired(ComponentId)
                        )
                )
                // Validate ComponentReference
                .ValidateValueProperty<ComponentAttributes>(nameof(ComponentReference), (o) =>
                    o.IsImplemented(ComponentReference)?.IsRequired(ComponentReference)
                )
                // Validate Name (deprecated check)
                .ValidateValueProperty<ComponentAttributes>(nameof(Name), (o) =>
                    o.IsImplemented(Name)
                    ?.If(
                        v => MtconnectVersion.GetValueOrDefault() >= MtconnectVersions.V_1_0_1 && MtconnectVersion.GetValueOrDefault() < MtconnectVersions.V_1_2_0,
                        v => throw new MtconnectValidationException(
                            ValidationSeverity.ERROR,
                            "Component MUST include a 'name' attribute.",
                            SourceNode) {
                            Code = Contracts.Enums.ExceptionsReport.ExceptionCodeEnum.NOT_FOUND,
                            ScopeType = Contracts.Enums.ExceptionsReport.ExceptionContextEnum.VALUE_PROPERTY,
                            Scope = nameof(Name)
                        }
                    )
                )
                // Validate Contents
                //.ValidateValueProperty<ComponentAttributes>(nameof(Samples), (o) =>
                //    o.IsImplemented(Samples)
                //    ?.If(
                //        v => Events.Count <= 0 && Samples.Count <= 0 && Conditions.Count <= 0,
                //        v => throw new MtconnectValidationException(
                //            ValidationSeverity.ERROR,
                //            "ComponentStream MUST have at least one of Event, Sample, or Condition.",
                //            SourceNode)
                //    )
                //)
                .UpdateHelpLinks(MODEL_BROWSER_URL)
                // Return validation errors
                .HasError(out validationErrors);
        }
    }
}
