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
using System.Xml;
using System.Xml.XPath;

namespace Sonority.XPath
{
    internal static class Globals
    {
        static Globals()
        {
            Manager = new XmlNamespaceManager(Table);
            Manager.AddNamespace("didl",    "urn:schemas-upnp-org:metadata-1-0/DIDL-Lite/");
            Manager.AddNamespace("upnp",    "urn:schemas-upnp-org:metadata-1-0/upnp/");
            Manager.AddNamespace("r",       "urn:schemas-rinconnetworks-com:metadata-1-0/");
            Manager.AddNamespace("avt",     "urn:schemas-upnp-org:metadata-1-0/AVT/");
            Manager.AddNamespace("dc",      "http://purl.org/dc/elements/1.1/");
        }

        public static readonly XmlNameTable Table = new NameTable();
        public static readonly XmlNamespaceManager Manager;
    }

    internal static class Expressions
    {
        public static readonly XPathExpression EventElements = XPathExpression.Compile("/avt:Event/avt:InstanceID[@val='0']/*", XPath.Globals.Manager);
        public static readonly XPathExpression ValueAttributes = XPathExpression.Compile("@val", XPath.Globals.Manager);

        public static readonly XPathExpression ItemsElements = XPathExpression.Compile("/didl:DIDL-Lite/didl:item", XPath.Globals.Manager);
        public static readonly XPathExpression ContainerElements = XPathExpression.Compile("/didl:DIDL-Lite/didl:container", XPath.Globals.Manager);
    }
}