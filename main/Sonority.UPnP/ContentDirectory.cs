//
// Copyright (c) 2007 Sonority
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to
// deal in the Software without restriction, including without limitation the
// rights to use, copy, modify, merge, publish, distribute, sublicense, and/or
// sell copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
// DEALINGS IN THE SOFTWARE.
//

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.XPath;
using UPNPLib;

namespace Sonority.UPnP
{
    public class ContentDirectory
    {
        static ContentDirectory()
        {
            nameTable = new NameTable();
            namespaceManager = new XmlNamespaceManager(nameTable);
            namespaceManager.AddNamespace("didl", "urn:schemas-upnp-org:metadata-1-0/DIDL-Lite/");
            namespaceManager.AddNamespace("upnp", "urn:schemas-upnp-org:metadata-1-0/upnp/");
            namespaceManager.AddNamespace("r", "urn:schemas-rinconnetworks-com:metadata-1-0/");
            namespaceManager.AddNamespace("dc", "http://purl.org/dc/elements/1.1/");
            didlItemsExpression = XPathExpression.Compile("/didl:DIDL-Lite/didl:item", namespaceManager);
        }

        internal ContentDirectory(UPnPService service)
        {
            directoryService = service;
        }

        public string GetSearchCapabilities()
        {
            return InvokeAction("GetSearchCapabilities");
        }

        public string GetSortCapabilities()
        {
            return InvokeAction("GetSortCapabilities");
        }

        public string GetSystemUpdateID()
        {
            return InvokeAction("GetSystemUpdateID");
        }

        public IEnumerable<XPathNavigator> Browse(string objectID, string browseFlag, string filter, string sortCriteria)
        {
            Array inArgs = new object[] { objectID, browseFlag, filter, 0u, 256u, sortCriteria };
            object[] outArray = { "", 0u, uint.MaxValue, 0u };

            for (uint i = 0; i < (uint)outArray[2]; i += (uint)outArray[1])
            {
                inArgs.SetValue(i, 3); // starting index
                inArgs.SetValue(Math.Min((uint)inArgs.GetValue(4), (uint)outArray[2] - (uint)outArray[1]), 4); // items to retrieve

                object outArgs = null;
                object results = directoryService.InvokeAction("Browse", inArgs, ref outArgs);
                outArray = (object[])outArgs;

            	string resultXml = Convert.ToString(outArray.GetValue(0));
	            uint numberReturned = Convert.ToUInt32(outArray.GetValue(1));
	            uint TotalMatches = Convert.ToUInt32(outArray.GetValue(2));

                XPathDocument doc = new XPathDocument(new StringReader(resultXml));
                XPathNavigator nav = doc.CreateNavigator();

                foreach (XPathNavigator node in nav.Select(didlItemsExpression))
                {
                    yield return node;
                }
            }
        }

        public void Search()
        {
            throw new NotImplementedException();
        }

        private string InvokeAction(string actionName)
        {
            Array inArgs = new object[] { };
            object outArgs = null;
            object results = directoryService.InvokeAction(actionName, inArgs, ref outArgs);
            return Convert.ToString(((object[])outArgs).GetValue(0));
        }

        private static XmlNameTable nameTable;
        private static XmlNamespaceManager namespaceManager;
        private static XPathExpression didlItemsExpression;

        private UPnPService directoryService;
    }
}