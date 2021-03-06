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
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using System.Xml;
using System.Xml.XPath;
using System.Threading;
using System.Windows.Threading;
using UPNPLib;

namespace Sonority.UPnP
{
    public sealed class ZonePlayer : DispatcherObject, IComparable<ZonePlayer>, IComparable, INotifyPropertyChanged, IDisposable
    {
        public ZonePlayer(string uniqueDeviceName)
        {
            _udn = uniqueDeviceName;
            _device = FindByUDN(uniqueDeviceName);
            Initialize();
        }

        public ZonePlayer(UPnPDevice device)
        {
            // hack/fix to prevent DisconnectedContext MDA due to the upnp callback threads
            // calling CoUninit and nuking this STA on return. create a new instance instead
            if (Thread.CurrentThread.GetApartmentState() == ApartmentState.STA)
            {
                _device = FindByUDN(device.UniqueDeviceName);
            }
            else
            {
                _device = device;
            }
            _udn = _device.UniqueDeviceName;
            Initialize();
        }

        private static UPnPDeviceFinder _finder = new UPnPDeviceFinderClass();

        private static UPnPDevice FindByUDN(string uniqueDeviceName)
        {
            for (int i = 0; i < 3; ++i)
            {
                UPnPDevice device = _finder.FindByUDN(uniqueDeviceName);
                if (device != null)
                {
                    return device;
                }
            }

            return null;
        }

        private void Initialize()
        {
            if (_device == null)
            {
                throw new ArgumentNullException();
            }

            ContentDirectory.PropertyChanged += new PropertyChangedEventHandler(ContainerUpdateIDs_PropertyChanged);
            Dispatcher.BeginInvoke(DispatcherPriority.Background, new ThreadStart(GetDocumentUrl));
            BeginUpdateQueue();

#if DEBUG
            // this is helpful just for loading in otherwise unused interfaces and being able to poke
            // at them in a debugger...
            if (System.Diagnostics.Debugger.IsAttached)
            {
                Dispatcher.BeginInvoke(DispatcherPriority.ContextIdle, (ThreadStart)delegate
                {
                    foreach (PropertyInfo pi in this.GetType().GetProperties(BindingFlags.Instance))
                    {
                        pi.GetGetMethod().Invoke(this, null);
                    }
                });
            }
#endif
        }

        void GetDocumentUrl()
        {
            IUPnPDeviceDocumentAccess blah = _device as IUPnPDeviceDocumentAccess;
            if (blah != null)
            {
                _documentUrl = new Uri(blah.GetDocumentURL(), UriKind.Absolute);
                PropertyChanged(this, new PropertyChangedEventArgs("DocumentUrl"));
            }
        }

        public UPnPDevice MediaServer
        {
            get
            {
                if (_mediaServer == null)
                {
                    _mediaServer = _device.Children[String.Format(CultureInfo.InvariantCulture, "{0}_MS", _device.UniqueDeviceName)];
                }
                return _mediaServer;
            }
        }

        public UPnPDevice MediaRenderer
        {
            get
            {
                if (_mediaRenderer == null)
                {
                    _mediaRenderer = _device.Children[String.Format(CultureInfo.InvariantCulture, "{0}_MR", _device.UniqueDeviceName)];
                }
                return _mediaRenderer;
            }
        }

        public AudioIn AudioIn
        {
            get
            {
                if (_audioIn == null)
                {
                    _audioIn = new AudioIn(_device.Services["urn:upnp-org:serviceId:AudioIn"]);
                }
                return _audioIn;
            }
        }

        public SystemProperties SystemProperties
        {
            get
            {
                if (_systemProperties == null)
                {
                    _systemProperties = new SystemProperties(_device.Services["urn:upnp-org:serviceId:SystemProperties"]);
                }
                return _systemProperties;
            }
        }
        public DeviceProperties DeviceProperties
        {
            get
            {
                if (_deviceProperties == null)
                {
                    _deviceProperties = new DeviceProperties(_device.Services["urn:upnp-org:serviceId:DeviceProperties"]);
                }
                return _deviceProperties;
            }
        }
        public AVTransport AVTransport
        {
            get
            {
                if (_avTransport == null)
                {
                    _avTransport = new AVTransport(MediaRenderer.Services["urn:upnp-org:serviceId:AVTransport"]);
                }
                return _avTransport;
            }
        }
        public RenderingControl RenderingControl
        {
            get
            {
                if (_renderingControl == null)
                {
                    _renderingControl = new RenderingControl(MediaRenderer.Services["urn:upnp-org:serviceId:RenderingControl"]);
                }
                return _renderingControl;
            }
        }
        public ContentDirectory ContentDirectory
        {
            get
            {
                if (_contentDirectory == null)
                {
                    _contentDirectory = new ContentDirectory(MediaServer.Services["urn:upnp-org:serviceId:ContentDirectory"]);
                }
                return _contentDirectory;
            }
        }

        public UPnPService AlarmClock
        {
            get
            {
                if (_alarmClock == null)
                {
                    _alarmClock = _device.Services["urn:upnp-org:serviceId:AlarmClock"];
                }
                return _alarmClock;
            }
        }

        public ZoneGroupTopology ZoneGroupTopology
        {
            get
            {
                if (_zoneGroupTopology == null)
                {
                    _zoneGroupTopology = new ZoneGroupTopology(_device.Services["urn:upnp-org:serviceId:ZoneGroupTopology"]);
                }
                return _zoneGroupTopology;
            }
        }

        public GroupManagement GroupManagement
        {
            get
            {
                if (_groupManagment == null)
                {
                    _groupManagment = new GroupManagement(_device.Services["urn:upnp-org:serviceId:GroupManagement"]);
                }
                return _groupManagment;
            }
        }

        public ConnectionManager ConnectionManager
        {
            get
            {
                if (_connectionManager == null)
                {
                    _connectionManager = new ConnectionManager(MediaRenderer.Services["urn:upnp-org:serviceId:ConnectionManager"]);
                }
                return _connectionManager;
            }
        }

        public Uri QueueUri
        {
            get
            {
                if (_queueUri == null)
                {
                    _queueUri = new Uri(String.Format(CultureInfo.InvariantCulture, "x-rincon-queue{0}#0", UniqueDeviceName.Substring(UniqueDeviceName.IndexOf(':'))));
                }

                return _queueUri;
            }
        }

        public string UniqueDeviceName { get { return _device.UniqueDeviceName; } }
        public Uri DocumentUrl { get { return _documentUrl; } }

        private void BeginUpdateQueue()
        {
            ThreadPool.QueueUserWorkItem(delegate { UpdateQueue(); });
        }

        // maybe there is some way to detect items moving within the queue otherwise need to implement
        // longest common subsequence or do a O(n*n) search
        private void UpdateQueue()
        {
            int index = 0;
            foreach (XPathNavigator node in ContentDirectory.Browse("Q:0", BrowseFlags.BrowseDirectChildren, "*", ""))
            {
                QueueItem qi = new QueueItem(node);

                Dispatcher.Invoke(DispatcherPriority.Background, (ThreadStart)delegate
                {
                    if (index < _queue.Count)
                    {
                        if (_queue[index].NumericId == qi.NumericId && _queue[index].Res == qi.Res)
                        {
                            _queue.RemoveAt(index);
                            _queue.Insert(index, qi);
                        }
                    }
                    else
                    {
                        _queue.Insert(index, qi);
                    }
                });

                index++;
            }

            Dispatcher.BeginInvoke(DispatcherPriority.Background, (ThreadStart)delegate
            {
                while (index < _queue.Count)
                {
                    _queue.RemoveAt(index);
                }
            });
        }

        private void ContainerUpdateIDs_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName != "ContainerUpdateIDs")
            {
                return;
            }

            if (ContentDirectory.ContainerUpdateIDs.Contains("Q:0,") == false)
            {
                return;
            }

            BeginUpdateQueue();
        }

        public ObservableCollection<QueueItem> Queue
        {
            get
            {
                return _queue;
            }
        }

        private ObservableCollection<QueueItem> _queue = new ObservableCollection<QueueItem>();

        int IComparable.CompareTo(object obj)
        {
            IComparable<ZonePlayer> that = this;
            return that.CompareTo((ZonePlayer)obj);
        }

        int IComparable<ZonePlayer>.CompareTo(ZonePlayer other)
        {
            return String.Compare(UniqueDeviceName, other.UniqueDeviceName);
        }

        public override bool Equals(object obj)
        {
            IComparable that = this;
            return that.CompareTo(obj) == 0;
        }

        public override int GetHashCode()
        {
            return UniqueDeviceName.GetHashCode();
        }

        public static bool operator ==(ZonePlayer lhs, ZonePlayer rhs)
        {
            IComparable<ZonePlayer> ic = lhs;
            return ic.CompareTo(rhs) == 0;
        }

        public static bool operator !=(ZonePlayer lhs, ZonePlayer rhs)
        {
            IComparable<ZonePlayer> ic = lhs;
            return ic.CompareTo(rhs) != 0;
        }

        public static bool operator <(ZonePlayer lhs, ZonePlayer rhs)
        {
            IComparable<ZonePlayer> ic = lhs;
            return ic.CompareTo(rhs) < 0;
        }
        
        public static bool operator >(ZonePlayer lhs, ZonePlayer rhs)
        {
            IComparable<ZonePlayer> ic = lhs;
            return ic.CompareTo(rhs) > 0;
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        private UPnPDevice _device;
        private UPnPDevice _mediaServer;
        private UPnPDevice _mediaRenderer;
        private AudioIn _audioIn;
        private UPnPService _alarmClock;
        private SystemProperties _systemProperties;
        private ZoneGroupTopology _zoneGroupTopology;
        private GroupManagement _groupManagment;
        private DeviceProperties _deviceProperties;
        private AVTransport _avTransport;
        private RenderingControl _renderingControl;
        private ContentDirectory _contentDirectory;
        private ConnectionManager _connectionManager;
        private Uri _documentUrl;
        private Uri _queueUri;
        private string _udn;

        public void Dispose()
        {
            if (_avTransport != null)
            {
                _avTransport.Dispose();
            }
        }
    }
}
