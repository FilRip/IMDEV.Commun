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

        /// <summary>
        /// Select server type
        /// </summary>
        /// <param name="typeServeur"></param>
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

        /// <summary>
        /// Check if server type has been initiate
        /// </summary>
        /// <returns></returns>
        private bool checkCurrentServerType()
        {
            return (_myConnection==null);
        }

        public delegate void delegateRetourDonnees(string sql, object result);
        /// <summary>
        /// Generate when calling an action in database
        /// </summary>
        public event delegateRetourDonnees callBackRetourneDonnees;

        protected virtual void OnConnectFailed(string sql, object result)
        {
            delegateRetourDonnees tmp = callBackRetourneDonnees;
            if (tmp != null)
                tmp(sql, result);
        }

        /// <summary>
        /// Connect to the server
        /// </summary>
        /// <param name="connectionString">ConnectionString of the server</param>
        /// <returns></returns>
        public bool connect(string connectionString)
        {
            if (checkCurrentServerType()) return false;
            return _myConnection.connect(connectionString);
        }

        /// <summary>
        /// Connect to the server
        /// </summary>
        /// <param name="connectionProperties">Connection properties of the server</param>
        /// <returns></returns>
        public bool connect(IMDEV.Database.Common.connectionProperties connectionProperties)
        {
            if (checkCurrentServerType()) return false;
            return _myConnection.connect(connectionProperties);
        }

        /// <summary>
        /// Connect to the server asynchronously
        /// </summary>
        /// <param name="connectionProperties">Connection properties of the server</param>
        /// <param name="callBack">Method to call when task finished</param>
        public void connectAsync(Common.connectionProperties connectionProperties, System.ComponentModel.RunWorkerCompletedEventHandler callBack)
        {
            if (checkCurrentServerType()) return;
            _myConnection.connectAsync(connectionProperties, callBack);
        }

        /// <summary>
        /// Execute a query and return the result
        /// </summary>
        /// <param name="requete">The query</param>
        /// <returns></returns>
        public unRetourRequete retourneDonnees(string requete)
        {
            if (checkCurrentServerType()) return null;
            IMDEV.Database.Common.unRetourRequete result;
            result=_myConnection.retourneDonnees(requete);
            OnConnectFailed(requete, result);
            return result;
        }
        /// <summary>
        /// Execute a query and return the result asynchronously
        /// </summary>
        /// <param name="requete">The query</param>
        /// <param name="callBack">Method to call when finished</param>
        /// <returns></returns>
        public void retourneDonneesAsync(string requete, System.ComponentModel.RunWorkerCompletedEventHandler callBack)
        {
            if (checkCurrentServerType()) return;
            _myConnection.retourneDonneesAsync(requete, callBack);
            OnConnectFailed(requete, null);
        }

        /// <summary>
        /// Execute a query
        /// </summary>
        /// <param name="requete">Query to execute</param>
        /// <returns>Return if query has been correctly executed or not</returns>
        public bool executeRequete(string requete)
        {
            if (checkCurrentServerType()) return false;
            OnConnectFailed(requete, null);
            return _myConnection.executeRequete(requete);
        }
        /// <summary>
        /// Execute a query asynchronously
        /// </summary>
        /// <param name="requete">Query to execute</param>
        /// <param name="callBack">Method to call when job finished</param>
        /// <returns>Return if query has been correctly executed or not</returns>
        public void executeRequeteAsync(string requete, System.ComponentModel.RunWorkerCompletedEventHandler callBack)
        {
            if (checkCurrentServerType()) return;
            _myConnection.executeRequeteAsync(requete, callBack);
            OnConnectFailed(requete, null);
        }

        /// <summary>
        /// Prepare connection to execute a stored procedure
        /// </summary>
        /// <param name="nom">Name of the stored procedure</param>
        /// <returns></returns>
        public bool prepareProcedureStockee(string nom)
        {
            if (checkCurrentServerType()) return false;
            return _myConnection.prepareProcedureStockee(nom);
        }

        /// <summary>
        /// Add parameters for the current stored procedure
        /// </summary>
        /// <param name="nom">Name of the parameter in stored procedure</param>
        /// <param name="valeur">Value of this parameter</param>
        /// <returns></returns>
        public bool ajouteParametrePS(string nom, object valeur)
        {
            if (checkCurrentServerType()) return false;
            return _myConnection.ajouteParametrePS(nom, valeur);
        }

        /// <summary>
        /// Execute the current stored procedure
        /// </summary>
        /// <returns>True or False if executing without errors</returns>
        public bool executeProcedureStockee()
        {
            if (checkCurrentServerType()) return false;
            OnConnectFailed("PS", _myConnection.returnCurrentPS());
            return _myConnection.executeProcedureStockee();
        }
        /// <summary>
        /// Execute the current stored procedure asynchronously
        /// </summary>
        /// <param name="callBack">Method to call when job finished</param>
        /// <returns></returns>
        public void executeProcedureStockeeAsync(System.ComponentModel.RunWorkerCompletedEventHandler callBack)
        {
            if (checkCurrentServerType()) return;
            _myConnection.executeProcedureStockeeAsync(callBack);
            OnConnectFailed("PS", _myConnection.returnCurrentPS());
        }

        /// <summary>
        /// Execute the current stored procedure and return the result
        /// </summary>
        /// <returns></returns>
        public unRetourRequete retourneDonnees()
        {
            if (checkCurrentServerType()) return null;
            OnConnectFailed("PS", _myConnection.returnCurrentPS());
            return _myConnection.retourneDonnees();
        }
        /// <summary>
        /// Execute the current stored procedure and return the result, asynchronously
        /// </summary>
        /// <param name="callBack">Method to call when job finished</param>
        /// <returns></returns>
        public void retourneDonneesAsync(System.ComponentModel.RunWorkerCompletedEventHandler callBack)
        {
            if (checkCurrentServerType()) return;
            _myConnection.retourneDonneesAsync(callBack);
            OnConnectFailed("PS", _myConnection.returnCurrentPS());
        }

        public System.Data.ConnectionState state()
        {
            if (checkCurrentServerType()) return System.Data.ConnectionState.Closed;
            return _myConnection.state();
        }

        /// <summary>
        /// Execute a query and return the first value returned by the query (first line, first column)
        /// </summary>
        /// <param name="requete">Query to execute</param>
        /// <returns></returns>
        public object executeScalaire(string requete)
        {
            if (checkCurrentServerType()) return null;
            OnConnectFailed(requete, null);
            return _myConnection.executeScalaire(requete);
        }
        /// <summary>
        /// Execute a query and return the first value returned by the query (first line, first column), asynchronously
        /// </summary>
        /// <param name="requete">Query to execute</param>
        /// <param name="callBack">Method to call when job finished</param>
        /// <returns></returns>
        public void executeScalaireAsync(string requete, System.ComponentModel.RunWorkerCompletedEventHandler callBack)
        {
            if (checkCurrentServerType()) return;
            _myConnection.executeScalaireAsync(requete, callBack);
            OnConnectFailed(requete, null);
        }

        /// <summary>
        /// Execute the current stored procedure and return the first value returned by the query (first line, first column)
        /// </summary>
        /// <returns></returns>
        public object executeScalaire()
        {
            if (checkCurrentServerType()) return null;
            OnConnectFailed("PS", _myConnection.returnCurrentPS());
            return _myConnection.executeScalaire();
        }
        /// <summary>
        /// Execute the current stored procedure and return the first value returned by the query (first line, first column), asynchronously
        /// </summary>
        /// <param name="requete">Query to execute</param>
        /// <param name="callBack">Method to call when job finished</param>
        /// <returns></returns>
        public void executeScalaireAsync(System.ComponentModel.RunWorkerCompletedEventHandler callBack)
        {
            if (checkCurrentServerType()) return;
            _myConnection.executeScalaireAsync(callBack);
            OnConnectFailed("PS", _myConnection.returnCurrentPS());
        }

        /// <summary>
        /// List all tables of the current database
        /// </summary>
        /// <returns></returns>
        public List<string> listTables()
        {
            if (checkCurrentServerType()) return null;
            return _myConnection.listTables();
        }

        /// <summary>
        /// Return details of a table of the current database
        /// </summary>
        /// <param name="tableName">Name of the table</param>
        /// <returns></returns>
        public models.aTable returnTable(string tableName)
        {
            if (checkCurrentServerType()) return null;
            return _myConnection.returnTable(tableName);
        }

        /// <summary>
        /// Return all schemas of the current database
        /// </summary>
        /// <returns></returns>
        public List<string> returnShemas()
        {
            if (checkCurrentServerType()) return null;
            return _myConnection.listSchemas();
        }

        /// <summary>
        /// Close/Disconnect from the current database/server
        /// </summary>
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
