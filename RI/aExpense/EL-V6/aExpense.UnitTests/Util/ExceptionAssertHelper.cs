﻿// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AExpense.UnitTests.Util
{
    public static class ExceptionAssertHelper
    {
        public static T Throws<T>(Action action) where T : Exception
        {
            try
            {
                action();
            }
            catch (T ex)
            {
                return ex;
            }

            Assert.Fail("Exception of type {0} should be thrown.", typeof(T));

            return null;
        }
    }
}
