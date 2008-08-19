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

using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration.Unity;
using Microsoft.Practices.EnterpriseLibrary.Logging.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Logging.Configuration.Unity;
using Microsoft.Practices.EnterpriseLibrary.Logging.Formatters;
using Microsoft.Practices.EnterpriseLibrary.Logging.Formatters.Tests;
using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.Practices.EnterpriseLibrary.Logging.Tests.Configuration.Unity
{
	[TestClass]
	public class FormattersPolicyCreationFixture
	{
		private IUnityContainer container;
		private LoggingSettings loggingSettings;
		private DictionaryConfigurationSource configurationSource;

		[TestInitialize]
		public void SetUp()
		{
			loggingSettings = new LoggingSettings();
			configurationSource = new DictionaryConfigurationSource();
			configurationSource.Add(LoggingSettings.SectionName, loggingSettings);

			container = new UnityContainer();

			container.AddExtension(new EnterpriseLibraryCoreExtension(configurationSource));
		}

		[TestCleanup]
		public void TearDown()
		{
			container.Dispose();
		}

		[TestMethod]
		public void CanCreatePoliciesForTextFormatter()
		{
			FormatterData data = new TextFormatterData("name", "template");
			loggingSettings.Formatters.Add(data);

			container.AddExtension(new LoggingBlockExtension());

			TextFormatter createdObject = (TextFormatter)container.Resolve<ILogFormatter>("name");

			Assert.IsNotNull(createdObject);
			Assert.AreEqual("template", createdObject.Template);
		}

		[TestMethod]
		public void CanCreatePoliciesForBinaryLogFormatter()
		{
			FormatterData data = new BinaryLogFormatterData("name");
			loggingSettings.Formatters.Add(data);

			container.AddExtension(new LoggingBlockExtension());

			BinaryLogFormatter createdObject = (BinaryLogFormatter)container.Resolve<ILogFormatter>("name");

			Assert.IsNotNull(createdObject);
		}

		[TestMethod]
		public void CanCreatePoliciesForCustomLogFormatter()
		{
			CustomFormatterData data = new CustomFormatterData("name", typeof(MockCustomLogFormatter).AssemblyQualifiedName);
			data.Attributes.Add(MockCustomLogFormatter.AttributeKey, "attribute value");
			loggingSettings.Formatters.Add(data);

			container.AddExtension(new LoggingBlockExtension());

			MockCustomLogFormatter createdObject = (MockCustomLogFormatter)container.Resolve<ILogFormatter>("name");

			Assert.IsNotNull(createdObject);
			Assert.AreEqual("attribute value", createdObject.customValue);
		}
	}
}
