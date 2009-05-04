﻿//===============================================================================
// Microsoft patterns & practices Enterprise Library
// Logging Application Block
//===============================================================================
// Copyright © Microsoft Corporation.  All rights reserved.
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE.
//===============================================================================

using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration.ContainerModel;
using Microsoft.Practices.EnterpriseLibrary.Logging.Filters;

namespace Microsoft.Practices.EnterpriseLibrary.Logging.Configuration
{
    /// <summary>
    /// Configuration settings for client-side logging applications.
    /// </summary>
    public class LoggingSettings : SerializableConfigurationSection, ITypeRegistrationsProvider
    {
        private const string ErrorsTraceSourceKey = "___ERRORS";
        private const string AllTraceSourceKey = "___ALL";
        private const string NoMatchesTraceSourceKey = "___NO_MATCHES";

        private const string tracingEnabledProperty = "tracingEnabled";
        private const string nameProperty = "name";
        private const string traceListenerDataCollectionProperty = "listeners";
        private const string formatterDataCollectionProperty = "formatters";
        private const string logFiltersProperty = "logFilters";
        private const string traceSourcesProrperty = "categorySources";
        private const string defaultCategoryProperty = "defaultCategory";
        private const string logWarningsWhenNoCategoriesMatchProperty = "logWarningsWhenNoCategoriesMatch";
        private const string specialTraceSourcesProperty = "specialSources";
        private const string revertImpersonationProperty = "revertImpersonation";

        /// <summary>
        /// Configuration section name for logging client settings.
        /// </summary>
        public const string SectionName = "loggingConfiguration";

        /// <summary>
        /// Initialize a new instance of the <see cref="LoggingSettings"/> with default values.
        /// </summary>
        public LoggingSettings()
            : this(string.Empty)
        {
        }

        /// <summary>
        /// Initialize a new instance of the <see cref="LoggingSettings"/> using the given name.
        /// </summary>
        /// <param name="name">The name to use for this instance</param>
        public LoggingSettings(string name)
            : this(name, false, string.Empty)
        {
        }

        /// <summary>
        /// Initialize a new instance of the <see cref="LoggingSettings"/> using the given values.
        /// </summary>
        /// <param name="name">The name to use for this instance</param>
        /// <param name="tracingEnabled">Should tracing be enabled?</param>
        /// <param name="defaultCategory">The default category to use.</param>
        public LoggingSettings(string name, bool tracingEnabled, string defaultCategory)
        {
            this.Name = name;
            this.TracingEnabled = tracingEnabled;
            this.DefaultCategory = defaultCategory;
        }

        /// <summary>
        /// Retrieves the <see cref="LoggingSettings"/> section from the configuration source.
        /// </summary>
        /// <param name="configurationSource">The <see cref="IConfigurationSource"/> to get the section from.</param>
        /// <returns>The logging section.</returns>
        public static LoggingSettings GetLoggingSettings(IConfigurationSource configurationSource)
        {
            return (LoggingSettings)configurationSource.GetSection(LoggingSettings.SectionName);
        }

        /// <summary>
        /// Enable or disable trace logging.
        /// </summary>
        [ConfigurationProperty(tracingEnabledProperty)]
        public bool TracingEnabled
        {
            get
            {
                return (bool)this[tracingEnabledProperty];
            }
            set
            {
                this[tracingEnabledProperty] = value;
            }
        }

        /// <summary>
        /// Gets or sets the name of the configuration node.
        /// </summary>
        [ConfigurationProperty(nameProperty)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public string Name
        {
            get
            {
                return (string)this[nameProperty];
            }
            set
            {
                this[nameProperty] = value;
            }
        }

        /// <summary>
        /// Gets or sets the default logging category.
        /// </summary>
        [ConfigurationProperty(defaultCategoryProperty, IsRequired = true)]
        public string DefaultCategory
        {
            get
            {
                return (string)this[defaultCategoryProperty];
            }
            set
            {
                this[defaultCategoryProperty] = value;
            }
        }

        /// <summary>
        /// Gets the collection of <see cref="TraceListenerData"/> configuration elements that define 
        /// the available <see cref="System.Diagnostics.TraceListener"/>s.
        /// </summary>
        [ConfigurationProperty(traceListenerDataCollectionProperty)]
        public TraceListenerDataCollection TraceListeners
        {
            get
            {
                return (TraceListenerDataCollection)base[traceListenerDataCollectionProperty];
            }
        }

        /// <summary>
        /// Gets the collection of <see cref="FormatterData"/> configuration elements that define 
        /// the available <see cref="Microsoft.Practices.EnterpriseLibrary.Logging.Formatters.ILogFormatter"/>s.
        /// </summary>
        [ConfigurationProperty(formatterDataCollectionProperty)]
        public NameTypeConfigurationElementCollection<FormatterData, CustomFormatterData> Formatters
        {
            get
            {
                return (NameTypeConfigurationElementCollection<FormatterData, CustomFormatterData>)base[formatterDataCollectionProperty];
            }
        }

        /// <summary>
        /// Gets the collection of <see cref="LogFilterData"/> configuration elements that define 
        /// the available <see cref="Microsoft.Practices.EnterpriseLibrary.Logging.Filters.ILogFilter"/>s.
        /// </summary>
        [ConfigurationProperty(logFiltersProperty)]
        public NameTypeConfigurationElementCollection<LogFilterData, CustomLogFilterData> LogFilters
        {
            get
            {
                return (NameTypeConfigurationElementCollection<LogFilterData, CustomLogFilterData>)base[logFiltersProperty];
            }
        }

        /// <summary>
        /// Gets the collection of <see cref="TraceSourceData"/> configuration elements that define 
        /// the available <see cref="LogSource"/>s.
        /// </summary>
        [ConfigurationProperty(traceSourcesProrperty)]
        public NamedElementCollection<TraceSourceData> TraceSources
        {
            get
            {
                return (NamedElementCollection<TraceSourceData>)base[traceSourcesProrperty];
            }
        }

        /// <summary>
        /// Gets or sets the configuration elements that define the distinguished <see cref="LogSource"/>s: 
        /// for all events. for missing categories, and for errors and warnings.
        /// </summary>
        [ConfigurationProperty(specialTraceSourcesProperty, IsRequired = true)]
        public SpecialTraceSourcesData SpecialTraceSources
        {
            get
            {
                return (SpecialTraceSourcesData)base[specialTraceSourcesProperty];
            }
            set
            {
                base[specialTraceSourcesProperty] = value;
            }
        }

        /// <summary>
        /// Gets or sets the indication that a warning should be logged when a category is not found while 
        /// dispatching a log entry.
        /// </summary>
        [ConfigurationProperty(logWarningsWhenNoCategoriesMatchProperty)]
        public bool LogWarningWhenNoCategoriesMatch
        {
            get
            {
                return (bool)this[logWarningsWhenNoCategoriesMatchProperty];
            }
            set
            {
                this[logWarningsWhenNoCategoriesMatchProperty] = value;
            }
        }

        /// <summary>
        /// Gets or sets the indication that impersonation should be reverted temporarily while logging, if enabled.
        /// </summary>
        [ConfigurationProperty(revertImpersonationProperty, DefaultValue = true, IsRequired = false)]
        public bool RevertImpersonation
        {
            get
            {
                return (bool)this[revertImpersonationProperty];
            }
            set
            {
                this[revertImpersonationProperty] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TypeRegistration> CreateRegistrations()
        {
            var registrations = new List<TypeRegistration>();

            registrations.AddRange(this.TraceListeners.SelectMany(tld => tld.GetContainerConfigurationModel()));
            registrations.AddRange(this.LogFilters.Select(lfd => lfd.GetContainerConfigurationModel()));
            registrations.AddRange(this.Formatters.Select(fd => fd.GetContainerConfigurationModel()));
            registrations.AddRange(this.TraceSources.Select(tsd => tsd.GetContainerConfigurationModel()));
            registrations.Add(
                CreateLogSourceRegistration(this.SpecialTraceSources.AllEventsTraceSource, AllTraceSourceKey));
            registrations.Add(
                CreateLogSourceRegistration(this.SpecialTraceSources.NotProcessedTraceSource, NoMatchesTraceSourceKey));
            registrations.Add(
                CreateLogSourceRegistration(this.SpecialTraceSources.ErrorsTraceSource, ErrorsTraceSourceKey));
            registrations.Add(CreateLogWriterRegistration());
            
            // todo: Add back in when resolving Instrumentation for this block
            //registrations.Add(CreateTraceManagerRegistration());

            return registrations;
        }

        private TypeRegistration CreateLogSourceRegistration(TraceSourceData traceSourceData, string name)
        {
            var registration = traceSourceData.GetContainerConfigurationModel();
            registration.Name = name;
            return registration;
        }

        private TypeRegistration CreateLogWriterRegistration()
        {
            return new TypeRegistration<LogWriter>(() =>
                new LogWriter(
                    Container.ResolvedEnumerable<ILogFilter>(this.LogFilters.Select(lfd => lfd.Name)),
                    Container.ResolvedEnumerable<LogSource>(this.TraceSources.Select(tsd => tsd.Name)),
                    Container.Resolved<LogSource>(AllTraceSourceKey),
                    Container.Resolved<LogSource>(NoMatchesTraceSourceKey),
                    Container.Resolved<LogSource>(ErrorsTraceSourceKey),
                    this.DefaultCategory,
                    this.TracingEnabled,
                    this.LogWarningWhenNoCategoriesMatch));
        }

        private TypeRegistration CreateTraceManagerRegistration()
        {
            // TODO deal with instrumentation
            return new TypeRegistration<TraceManager>(() =>
                new TraceManager(Container.Resolved<LogWriter>()));
        }
    }
}