using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Xml.Serialization;

namespace IMDEV.OpenERP.models.@base
{
    [XmlRoot()]
    public class connectionProperties
    {
        private string _password = "";
        private string _username = "";
        private int _userId;
        private string _database = "";
        private string _defaultLanguage = "";
        private string _defaultTimeZone = "";
        private string _host = "";
        private int _port = 8069;
        private bool _reportXmlRpcError;
        private bool _busyThrowError;

        [XmlElement()]
        public string database
        {
            get { return _database; }
            set { _database = value; }
        }

        [XmlElement()]
        public string username
        {
            get { return _username; }
            set { _username = value; }
        }

        public int userId
        {
            get { return _userId; }
        }

        [XmlElement()]
        public bool reportXmlRpcError
        {
            get { return _reportXmlRpcError; }
            set { _reportXmlRpcError = value; }
        }

        [XmlElement()]
        public bool busyThrowAnError
        {
            get { return _busyThrowError; }
            set { _busyThrowError = value; }
        }

        [XmlElement()]
        public string password
        {
            get { return _password; }
            set { _password = value; }
        }

        [XmlElement()]
        public string host
        {
            get { return _host; }
            set { _host = value; }
        }

        [XmlElement()]
        public int port
        {
            get { return _port; }
            set { _port = value; }
        }

        [XmlElement()]
        public string defaultLanguage
        {
            get { return _defaultLanguage; }
            set { _defaultLanguage = value; }
        }

        [XmlElement()]
        public string defaultTimeZone
        {
            get { return _defaultTimeZone; }
            set { _defaultTimeZone = value; }
        }
        
        public void setUserId(int newUserId) {
            _userId = newUserId;
        }
    }
}
