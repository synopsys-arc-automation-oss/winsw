/*
 * The MIT License
 *
 * Copyright (c) 2013, Oleg Nenashev <nenashev@synopsys.com>, Synopsys Inc.
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using winsw;

namespace Synopsys.ARC.WinSW.Extensions.Test.util
{
    class TestHelper
    {
        public static ServiceDescriptor LoadServiceDescriptor<TExceptionType>(string sourceFile, bool expectException = false) where TExceptionType : Exception
        {
            try
            {
                ServiceDescriptor descr = new ServiceDescriptor(sourceFile);

                // Check correctness of ExtensionManagerConfig property
                var res = descr.ExtensionManagerConfig;
                return descr;
            }
            catch (TExceptionType ex)
            {
                TestWrapper.Log("Caught exception: " + ex);
                if (expectException)
                {
                    return null;
                }
                else throw;
            }
            catch (Exception ex)
            {
                Assert.Fail("Received unexpected exception. " + ex);
            }

            return null;
        }

        public static ExtensionsManager InitManager(string filePath)
        {
            var descr = LoadServiceDescriptor<Exception>(filePath);
            Assert.IsNotNull(descr);

            // Run configuration loader
            var mgr = new ExtensionsManager(TestWrapper.Logger);
            mgr.Enable(descr.ExtensionManagerConfig);
            Assert.IsTrue(mgr.Enabled, "Extensions manager should be enabled");
            return mgr;
        }
    }
}
