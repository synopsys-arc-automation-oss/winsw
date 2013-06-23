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
using System.Text;
using Synopsys.ARC.WinSW.Utils;
using System.Xml;
using System.Diagnostics;

namespace Synopsys.ARC.WinSW.Extensions
{
    public class ExtensionsManager
    {
        private Dictionary<string, IWinSWExtension> extensions = new Dictionary<string, IWinSWExtension>();
        public IEventWriter Logger { get; private set; }
        public bool Enabled { get; private set; }

        public ExtensionsManager(IEventWriter logger)
        {
            Logger = logger;
            Enabled = false;
        }

        public void LoadExtensions()
        {
            if (!Enabled) return;
        }

        public void UnloadExtensions()
        {
            if (!Enabled) return;
        }

        #region Configuration

        public void Enable(XmlNode config)
        {
            ReadConfiguration(config);
            Enabled = true;
        }

        private void ReadConfiguration(XmlNode config)
        {
            //TODO: implement

        }

        #endregion

        public void StartExceptions()
        {
            foreach (var ext in extensions)
            {
                try
                {
                    ext.Value.OnStart(Logger);
                }
                catch (ExtensionException ex)
                {
                    Logger.LogEvent("Failed to start extension  " + ex.ExtensionName + "\n" + ex.Message, EventLogEntryType.Error);
                    //Logger.WriteEvent("Failed to start extension  " + ex.ExtensionName, ex);

                    //TODO: Add error
                }
            }
        }

        public void StopExceptions()
        {
            foreach (var ext in extensions)
            {
                try
                {
                    ext.Value.OnStop(Logger);
                }
                catch (ExtensionException ex)
                {
                    Logger.LogEvent("Failed to stop extension  " + ex.ExtensionName + "\n" + ex.Message, EventLogEntryType.Error);
                    //Logger.WriteEvent("Failed to stop extension  " + ex.ExtensionName, ex);
                }
            }
        }


        #region Extension management
        //TODO: Implement loading of external extensions. Current version supports internal hack


        //FIXME: obsolete stub
        private void LoadExtension<TExtensionType>(TExtensionType extension)
            where TExtensionType : IWinSWExtension
        {
            if (extensions.ContainsKey(extension.Name))
            {
                throw new ExtensionException(extension.Name, "Extension has been already loaded");
            }

            extensions.Add(extension.Name, extension);
            //extension.Init(descriptor);
        }

        #endregion
    }
}
