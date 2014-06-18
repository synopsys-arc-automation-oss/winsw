﻿using System;
using System.Collections.Generic;
using System.Text;
using winsw;
using NUnit.Framework;
using winsw.extensions;

namespace winswTests.extensions
{
    [TestFixture]
    class WinSWExtensionManagerTest
    {
        ServiceDescriptor testServiceDescriptor;

        [SetUp]
        public void SetUp()
        {
            const string SeedXml = "<?xml version=\"1.0\" encoding=\"utf-8\" ?>"
                + "<service>                                                                                                        "
                + "  <id>SERVICE_NAME</id>                                                                                          "
                + "  <name>Jenkins Slave</name>                                                                                     "
                + "  <description>This service runs a slave for Jenkins continuous integration system.</description>                "
                + "  <executable>C:\\Program Files\\Java\\jre7\\bin\\java.exe</executable>                                               "
                + "  <arguments>-Xrs  -jar \\\"%BASE%\\slave.jar\\\" -jnlpUrl ...</arguments>                                              "
                + "  <logmode>rotate</logmode>                                                                                      "
                + "  <extensions>                                                                                                   "
                + "    <extension enabled=\"true\" className=\"winsw.extensions.shared_dirs.SharedDirectoryMapper\" id=\"mapNetworDirs\"> "
                + "      <mapping>                                                                                                  "
                + "        <map enabled=\"false\" label=\"N:\" uncpath=\"\\\\UNC\"/>                                                        "
                + "        <map enabled=\"false\" label=\"M:\" uncpath=\"\\\\UNC2\"/>                                                       "
                + "      </mapping>                                                                                                 "
                + "    </extension>                                                                                                 "
                + "  </extensions>                                                                                                  "
                + "</service>";
            testServiceDescriptor = ServiceDescriptor.FromXML(SeedXml);
        }

        [Test]
        public void LoadExtensions()
        {
            WinSWExtensionManager manager = new WinSWExtensionManager(testServiceDescriptor);
            manager.LoadExtensions();
        }
    }
}
