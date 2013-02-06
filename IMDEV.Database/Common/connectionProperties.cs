using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace IMDEV.Database.Common
{
    [XmlRoot()]
    public class connectionProperties
    {
        public enum TYPE_ODBC
        {
            SYSTEME,
            FICHIER
        }

        private string _fileName;
        private string _server;
        private string _databaseName;
        private string _userName;
        private string _password;
        private int _portTCP;
        private int _serverType;
        private string _engine;
        private TYPE_ODBC _odbcType;

        [XmlElement()]
        public string fileName
        {
            get { return _fileName; }
            set { _fileName = value; }
        }

        [XmlElement()]
        public string server
        {
            get { return _server; }
            set { _server = value; }
        }

        [XmlElement()]
        public string userName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        [XmlElement()]
        public string password
        {
            get { return _password; }
            set { _password = value; }
        }

        [XmlElement()]
        public int portTCP
        {
            get { return _portTCP; }
            set { _portTCP = value; }
        }

        [XmlElement()]
        public int serverType
        {
            get { return _serverType; }
            set { _serverType = value; }
        }

        [XmlElement()]
        public string databaseName
        {
            get { return _databaseName; }
            set { _databaseName = value; }
        }

        [XmlElement()]
        public string engine
        {
            get { return _engine; }
            set { _engine = value; }
        }

        [XmlElement()]
        public TYPE_ODBC odbcType
        {
            get { return _odbcType; }
            set { _odbcType = value; }
        }

        public bool saveToFile(string fileName)
        {
            if (System.IO.File.Exists(fileName)) return false;
            System.IO.StreamWriter fich=null;
            try
            {
                XmlSerializer serialisation = new XmlSerializer(this.GetType());
                fich = new System.IO.StreamWriter(fileName);
                serialisation.Serialize(fich, this);
                return true;
            }
            catch { }
            finally
            {
                try { fich.Close(); }
                catch { }
            }
            return false;
        }

        public bool loadFromFile(string fileName)
        {
            if (!System.IO.File.Exists(fileName)) return false;
            connectionProperties temp;
            System.IO.StreamReader fich = null; ;
            try
            {
                fich = new System.IO.StreamReader(fileName);
                XmlSerializer deserialisation = new XmlSerializer(this.GetType());
                temp = (connectionProperties)deserialisation.Deserialize(fich);
                _server = temp.server;
                _fileName = temp.fileName;
                _userName = temp.userName;
                _password = temp.password;
                _portTCP = temp.portTCP;
                _databaseName = temp.databaseName;
                _serverType = temp.serverType;
                _engine = temp.engine;
                _odbcType = temp.odbcType;
                return true;
            }
            catch { }
            finally
            {
                temp = null;
                try { fich.Close(); }
                catch { }
            }
            return false;
        }
    }
}
