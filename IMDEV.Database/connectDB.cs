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

        public unRetourRequete retourneDonnees(string requete)
        {
            if (checkCurrentServerType()) return null;
            return _myConnection.retourneDonnees(requete);
        }

        public bool executeRequete(string requete)
        {
            if (checkCurrentServerType()) return false;
            return _myConnection.executeRequete(requete);
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
            return _myConnection.executeProcedureStockee();
        }

        public unRetourRequete retourneDonnees()
        {
            if (checkCurrentServerType()) return null;
            return _myConnection.retourneDonnees();
        }

        public System.Data.ConnectionState state()
        {
            if (checkCurrentServerType()) return System.Data.ConnectionState.Closed;
            return _myConnection.state();
        }

        public object executeScalaire(string requete)
        {
            if (checkCurrentServerType()) return null;
            return _myConnection.executeScalaire(requete);
        }

        public void fermer()
        {
            _myConnection.fermer();
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
