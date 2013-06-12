/*
 * The MIT License
 *
 * Copyright (c) 2013, Oleg Nenashev <nenashev@synopsys.com>, Synopsys Inc
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
using System.Text;

namespace Synopsys.ARC.WinSW.Extensions
{
    /**
     * Extension attribute, which describes extension for the PluginManager
     */
    [AttributeUsage(System.AttributeTargets.Class)]
    public class WinSWExtensionAttribute : System.Attribute
    {
        public string GroupId { get; private set; }
        public string ArtifactId { get; private set; }
        public Version Version { get; private set; }


        public WinSWExtensionAttribute(String groupId, String artifactId, Version version)
        {
            GroupId = groupId;
            ArtifactId = artifactId;
            Version = version;
        }

        public override string ToString()
        {
            return GroupId+":"+ArtifactId+"["+Version+"]";
        }
    }
}
