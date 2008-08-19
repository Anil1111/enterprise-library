//===============================================================================
// Microsoft patterns & practices Enterprise Library
// Policy Injection Application Block
//===============================================================================
// Copyright � Microsoft Corporation.  All rights reserved.
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE.
//===============================================================================

using System;
using Microsoft.Practices.EnterpriseLibrary.PolicyInjection.MatchingRules;
using Microsoft.Practices.EnterpriseLibrary.PolicyInjection.RemotingInterception;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.Practices.EnterpriseLibrary.PolicyInjection.Tests
{
    /// <summary>
    /// Tests for various kinds of things handlers can do.
    /// </summary>
    [TestClass]
    public class HandlerInvocationFixture
    {
        [TestMethod]
        public void HandlersCanChangeInputsBeforeTargetIsCalled()
        {
            RemotingPolicyInjector factory = new RemotingPolicyInjector();
            AddInputChangePolicy(factory);

            CanChangeParametersTarget target = factory.Create<CanChangeParametersTarget>();

            Assert.AreEqual(0, target.MostRecentInput);
            target.DoSomething(2);
            Assert.AreEqual(4, target.MostRecentInput);
        }

        [TestMethod]
        public void HandlersCanChangeOutputsAfterTargetReturns()
        {
            RemotingPolicyInjector factory = new RemotingPolicyInjector();
            AddInputChangePolicy(factory);

            CanChangeParametersTarget target = factory.Create<CanChangeParametersTarget>();

            int output;

            target.DoSomethingElse(2, out output);

            Assert.AreEqual((2 + 5) * 3, output);
        }

        void AddInputChangePolicy(PolicyInjector factory)
        {
            RuleDrivenPolicy doubleInputPolicy = new RuleDrivenPolicy("Double your inputs");
            doubleInputPolicy.RuleSet.Add(new MemberNameMatchingRule("DoSomething"));
            doubleInputPolicy.Handlers.Add(new DoubleInputHandler());

            RuleDrivenPolicy tripleOutputPolicy = new RuleDrivenPolicy("Triple an output parameter");
            tripleOutputPolicy.RuleSet.Add(new MemberNameMatchingRule("DoSomethingElse"));
            tripleOutputPolicy.Handlers.Add(new TripleOutputHandler());

            factory.Policies.AddRange(new RuleDrivenPolicy[] { doubleInputPolicy, tripleOutputPolicy });
        }
    }

    class DoubleInputHandler : ICallHandler
    {
        int order = 0;

        /// <summary>
        /// Gets or sets the order in which the handler will be executed
        /// </summary>
        public int Order
        {
            get { return order; }
            set { order = value; }
        }

        public IMethodReturn Invoke(IMethodInvocation input,
                                    GetNextHandlerDelegate getNext)
        {
            int i = (int)(input.Inputs[0]) * 2;
            input.Inputs[0] = i;
            return getNext()(input, getNext);
        }
    }

    class TripleOutputHandler : ICallHandler
    {
        int order = 0;

        /// <summary>
        /// Gets or sets the order in which the handler will be executed
        /// </summary>
        public int Order
        {
            get { return order; }
            set { order = value; }
        }

        public IMethodReturn Invoke(IMethodInvocation input,
                                    GetNextHandlerDelegate getNext)
        {
            IMethodReturn result = getNext()(input, getNext);
            if (result.Exception == null)
            {
                int output = (int)result.Outputs[0] * 3;
                result.Outputs[0] = output;
            }
            return result;
        }
    }

    class CanChangeParametersTarget : MarshalByRefObject
    {
        int mostRecentInput = 0;

        public int MostRecentInput
        {
            get { return mostRecentInput; }
        }

        public void DoSomething(int i)
        {
            mostRecentInput = i;
        }

        public void DoSomethingElse(int i,
                                    out int j)
        {
            j = i + 5;
        }
    }
}