using System;
using System.Collections.Generic;
using System.Text;
using IMDEV.Database.Common;
using IMDEV.Database.DBServer;

namespace IMDEV.Database
{
    public class connectDB
    {
        private baseDB _myConnection;
        public enum TYPE_SERVEUR
        {
            MYSQL=1,
            SQLSERVER=2,
            ODBC=3,
            OLEDB=4,
            ORACLE=5,
            POSTGRESQL=6,
            SQLITE=7
        }

        public connectDB(TYPE_SERVEUR typeServeur)
        {
            selectServerType(typeServeur);
        }

        public void selectServerType(TYPE_SERVEUR typeServeur)
        {
            switch (typeServeur)
            {
                case TYPE_SERVEUR.MYSQL:
                    _myConnection=new connectMySQL();
                    break;
                case TYPE_SERVEUR.SQLSERVER:
                    _myConnection=new connectSQLServer();
                    break;
                case TYPE_SERVEUR.ODBC:
                    _myConnection = new connectODBC();
                    break;
                case TYPE_SERVEUR.OLEDB:
                    _myConnection = new connectOleDb();
                    break;
                case TYPE_SERVEUR.ORACLE:
                    _myConnection = new connectOracle();
                    break;
                case TYPE_SERVEUR.POSTGRESQL:
                    _myConnection = new connectPostgreSQL();
                    break;
                case TYPE_SERVEUR.SQLITE:
                    _myConnection = new connectSQLite();
                    break;
                default:
                    throw new Exception("Unknown database server type");
            }
        }

        private bool checkCurrentServerType()
        {
            return (_myConnection==null);
        }

        public delegate void delegateRetourDonnees(string sql, object result);
        public event delegateRetourDonnees callBackRetourneDonnees;
        
        public bool connect(string connectionString)
        {
            if (checkCurrentServerType()) return false;
            return _myConnection.connect(connectionString);
        }

        public bool connect(IMDEV.Database.Common.connectionProperties connectionProperties)
        {
            if (checkCurrentServerType()) return false;
            return _myConnection.connect(connectionProperties);
        }

        public void connectAsync(Common.connectionProperties connectionProperties, System.ComponentModel.RunWorkerCompletedEventHandler callBack)
        {
            if (checkCurrentServerType()) return;
            _myConnection.connectAsync(connectionProperties, callBack);
        }

        public unRetourRequete retourneDonnees(string requete)
        {
            if (checkCurrentServerType()) return null;
            IMDEV.Database.Common.unRetourRequete result;
            result=_myConnection.retourneDonnees(requete);
            callBackRetourneDonnees(requete, result);
            return result;
        }
        public void retourneDonneesAsync(string requete, System.ComponentModel.RunWorkerCompletedEventHandler callBack)
        {
            if (checkCurrentServerType()) return;
            _myConnection.retourneDonneesAsync(requete, callBack);
            callBackRetourneDonnees(requete, null);
        }

        public bool executeRequete(string requete)
        {
            if (checkCurrentServerType()) return false;
            callBackRetourneDonnees(requete, null);
            return _myConnection.executeRequete(requete);
        }
        public void executeRequeteAsync(string requete, System.ComponentModel.RunWorkerCompletedEventHandler callBack)
        {
            if (checkCurrentServerType()) return;
            _myConnection.executeRequeteAsync(requete, callBack);
            callBackRetourneDonnees(requete, null);
        }

        public bool prepareProcedureStockee(string nom)
        {
            if (checkCurrentServerType()) return false;
            return _myConnection.prepareProcedureStockee(nom);
        }

        public bool ajouteParametrePS(string nom, object valeur)
        {
            if (checkCurrentServerType()) return false;
            return _myConnection.ajouteParametrePS(nom, valeur);
        }

        public bool executeProcedureStockee()
        {
            if (checkCurrentServerType()) return false;
            callBackRetourneDonnees("PS", _myConnection.returnCurrentPS());
            return _myConnection.executeProcedureStockee();
        }
        public void executeProcedureStockeeAsync(System.ComponentModel.RunWorkerCompletedEventHandler callBack)
        {
            if (checkCurrentServerType()) return;
            _myConnection.executeProcedureStockeeAsync(callBack);
            callBackRetourneDonnees("PS", _myConnection.returnCurrentPS());
        }

        public unRetourRequete retourneDonnees()
        {
            if (checkCurrentServerType()) return null;
            callBackRetourneDonnees("PS", _myConnection.returnCurrentPS());
            return _myConnection.retourneDonnees();
        }
        public void retourneDonneesAsync(System.ComponentModel.RunWorkerCompletedEventHandler callBack)
        {
            if (checkCurrentServerType()) return;
            _myConnection.retourneDonneesAsync(callBack);
            callBackRetourneDonnees("PS", _myConnection.returnCurrentPS());
        }

        public System.Data.ConnectionState state()
        {
            if (checkCurrentServerType()) return System.Data.ConnectionState.Closed;
            return _myConnection.state();
        }

        public object executeScalaire(string requete)
        {
            if (checkCurrentServerType()) return null;
            callBackRetourneDonnees(requete, null);
            return _myConnection.executeScalaire(requete);
        }
        public void executeScalaireAsync(string requete, System.ComponentModel.RunWorkerCompletedEventHandler callBack)
        {
            if (checkCurrentServerType()) return;
            _myConnection.executeScalaireAsync(requete, callBack);
            callBackRetourneDonnees(requete, null);
        }

        public object executeScalaire()
        {
            if (checkCurrentServerType()) return null;
            callBackRetourneDonnees("PS", _myConnection.returnCurrentPS());
            return _myConnection.executeScalaire();
        }
        public void executeScalaireAsync(System.ComponentModel.RunWorkerCompletedEventHandler callBack)
        {
            if (checkCurrentServerType()) return;
            _myConnection.executeScalaireAsync(callBack);
            callBackRetourneDonnees("PS", _myConnection.returnCurrentPS());
        }

        public List<string> listTables()
        {
            if (checkCurrentServerType()) return null;
            return _myConnection.listTables();
        }

        public models.aTable returnTable(string tableName)
        {
            if (checkCurrentServerType()) return null;
            return _myConnection.returnTable(tableName);
        }

        public List<string> returnShemas()
        {
            if (checkCurrentServerType()) return null;
            return _myConnection.listSchemas();
        }
        public void fermer()
        {
            _myConnection.fermer();
        }

        public string currentConnectionString()
        {
            return _myConnection.lastConnectionString();
        }

        public int nbAffectee
        {
            get { return _myConnection.lastNbAffected; }
        }
        /// <summary>
        /// Lire le message d'erreur de la dernière erreur qui a pu se produire
        /// </summary>
        /// <returns>Le message d'erreur</returns>
        /// <remarks></remarks>
        public string derniereErreur
        {
            get { return _myConnection.lastError; }
        }
    }
}
