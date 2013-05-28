using System;
using System.Collections.Generic;
using System.Text;

namespace IMDEV.Database.Common
{
    abstract class baseDB
    {
        protected string _lastError;
        protected string _lastServeur = "";
        protected int _lastNbAffected;

        abstract public bool connect(connectionProperties parameters);
        abstract public bool connect(string connectionString);
        abstract public unRetourRequete retourneDonnees(string requete);
        abstract public bool executeRequete(string requete);
        abstract public object executeScalaire(string requete);
        abstract public object executeScalaire();
        abstract public bool prepareProcedureStockee(string nom);
        abstract public bool ajouteParametrePS(string nom, object valeur);
        abstract public bool executeProcedureStockee();
        abstract public unRetourRequete retourneDonnees();
        abstract public void fermer();
        abstract public System.Data.ConnectionState state();
        abstract public List<string> listTables();
        abstract public models.aTable returnTable(string name);
        abstract public List<models.aFieldType> listFieldType();
        abstract public List<string> listSchemas();

        // Asynchrone
        abstract public void connectAsync(connectionProperties parameters, System.ComponentModel.RunWorkerCompletedEventHandler callBack);
        abstract public void connectAsync(string connectionString, System.ComponentModel.RunWorkerCompletedEventHandler callBack);
        abstract public void retourneDonneesAsync(string requete, System.ComponentModel.RunWorkerCompletedEventHandler callBack);
        abstract public void executeRequeteAsync(string requete, System.ComponentModel.RunWorkerCompletedEventHandler callBack);
        abstract public void executeScalaireAsync(string requete, System.ComponentModel.RunWorkerCompletedEventHandler callBack);
        abstract public void executeScalaireAsync(System.ComponentModel.RunWorkerCompletedEventHandler callBack);
        abstract public void executeProcedureStockeeAsync(System.ComponentModel.RunWorkerCompletedEventHandler callBack);
        abstract public void retourneDonneesAsync(System.ComponentModel.RunWorkerCompletedEventHandler callBack);

        // TODO : generateConnectionString
        //abstract public string generateConnectionString(params string[] values);

        public string currentDatabase
        {
            get
            {
                foreach (string partie in _lastServeur.Split(';'))
                {
                    if (partie.ToLower().Trim().StartsWith("database="))
                        return partie.Split('=')[1].Trim().ToString();
                }
                return "";
            }
        }

        public string lastError
        {
            get { return _lastError; }
        }

        public int lastNbAffected
        {
            get { return _lastNbAffected; }
        }
    }
}
