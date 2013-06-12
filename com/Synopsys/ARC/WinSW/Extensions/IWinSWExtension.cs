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
using Synopsys.ARC.WinSW.Utils;
using System.Xml;

namespace Synopsys.ARC.WinSW.Extensions
{
    /// <summary>
    /// Interface for Win Service Wrapper Extension
    /// </summary>
    public interface IWinSWExtension
    {
        /// <summary>
        /// Extension name
        /// </summary>
        String Name { get; }
        /// <summary>
        /// Extension ArtifactId
        /// </summary>
        String ArtifactId { get; }
        /// <summary>
        /// Extension GroupId
        /// </summary>
        String GroupId { get; }
        /// <summary>
        /// Version of the extension
        /// </summary>
        Version Version { get; }

        /// <summary>
        /// Initial setup of the extension
        /// </summary>
        /// <param name="name">Name of the extension</param>
        /// <param name="config"></param>
        /// <exception cref="ExtensionException">Any error during execution</exception>
        void Configure(String name, XmlNode config);

        /// <summary>
        /// Start handler. Called during start of the service
        /// </summary>
        /// <param name="eventWriter">Logger</param>
        /// <exception cref="ExtensionException">Any error during execution</exception>
        void OnStart(IEventWriter eventWriter);

        /// <summary>
        /// Stop handler. Called during stop of the service
        /// </summary>
        /// <param name="eventWriter">Logger</param>
        /// <exception cref="ExtensionException">Any error during execution</exception>
        void OnStop(IEventWriter eventWriter);
    }
}
