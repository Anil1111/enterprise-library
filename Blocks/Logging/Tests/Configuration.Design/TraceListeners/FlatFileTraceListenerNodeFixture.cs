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

using System;
using Microsoft.Practices.EnterpriseLibrary.Configuration.Design.TestSupport;
using Microsoft.Practices.EnterpriseLibrary.Logging.Configuration.Design.TraceListeners;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.Practices.EnterpriseLibrary.Logging.Configuration.Design.Tests
{
    [TestClass]
    public class FlatFileTraceListenerNodeFixture : ConfigurationDesignHost
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PassingNullDataInFlatFileTraceListenerNodeThrows()
        {
            new FlatFileTraceListenerNode(null);
        }

        [TestMethod]
        public void FlatFileTraceListenerNodeTest()
        {
            string name = "some name";
            string fileName = "some filename";
            string header = "some header";
            string footer = "some footer";

            FlatFileTraceListenerNode flatFileTraceListenerNode = new FlatFileTraceListenerNode();
            flatFileTraceListenerNode.Name = name;
            flatFileTraceListenerNode.Footer = footer;
            flatFileTraceListenerNode.Header = header;
            flatFileTraceListenerNode.Filename = fileName;

            ApplicationNode.AddNode(flatFileTraceListenerNode);

            FlatFileTraceListenerData nodeData = (FlatFileTraceListenerData)flatFileTraceListenerNode.TraceListenerData;

            Assert.AreEqual(name, nodeData.Name);
            Assert.AreEqual(header, nodeData.Header);
            Assert.AreEqual(footer, nodeData.Footer);
            Assert.AreEqual(fileName, nodeData.FileName);
        }

        [TestMethod]
        public void FlatFileTraceListenerNodeDataTest()
        {
            string name = "some name";
            string fileName = "some filename";
            string header = "some header";
            string footer = "some footer";

            FlatFileTraceListenerData flatFileTraceListenerData = new FlatFileTraceListenerData();
            flatFileTraceListenerData.Name = name;
            flatFileTraceListenerData.FileName = fileName;
            flatFileTraceListenerData.Header = header;
            flatFileTraceListenerData.Footer = footer;

            FlatFileTraceListenerNode flatFileTraceListenerNode = new FlatFileTraceListenerNode(flatFileTraceListenerData);
            ApplicationNode.AddNode(flatFileTraceListenerNode);

            Assert.AreEqual(name, flatFileTraceListenerNode.Name);
            Assert.AreEqual(fileName, flatFileTraceListenerNode.Filename);
            Assert.AreEqual(header, flatFileTraceListenerNode.Header);
            Assert.AreEqual(footer, flatFileTraceListenerNode.Footer);
        }
    }
}
