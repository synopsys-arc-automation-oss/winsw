﻿/*
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
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using winsw;
using Synopsys.ARC.WinSW.Extensions.Test.resources;
using Synopsys.ARC.WinSW.Extensions.Test.util;

namespace Synopsys.ARC.WinSW.Extensions.Test
{
    [TestClass]
    public class ConfigLoaderTest
    {
        [TestMethod]
        public void Sanity_LoadOriginalFile()
        {
            ServiceDescriptor descr = TestHelper.LoadServiceDescriptor<Exception>(TestSources.ORIGINAL_FILE, false);
            Assert.IsNull(descr.ExtensionManagerConfig);
        }


        [TestMethod]
        public void Sanity_LoadDirectoryMapper()
        {
            var extManager = TestHelper.InitManager(TestSources.DIRECTORY_MAPPER);
        }

        [TestMethod]
        public void Sanity_LoadInvalidConfig()
        {
            var extManager = TestHelper.InitManager(TestSources.ERR_WRONG_EXTENSION);
        }
    }
}
