using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

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
        abstract public void listTablesAsync(System.ComponentModel.RunWorkerCompletedEventHandler callBack);
        abstract public models.aTable returnTable(string name);
        abstract public void returnTableAsync(string name, System.ComponentModel.RunWorkerCompletedEventHandler callBack);

        abstract public List<models.aFieldType> listFieldType();
        abstract public List<string> listSchemas();
        abstract public List<string> returnCurrentPS();

        public string lastConnectionString()
        {
            return _lastServeur;
        }

        // Asynchrone
        abstract public void connectAsync(connectionProperties parameters, System.ComponentModel.RunWorkerCompletedEventHandler callBack);
        abstract public void connectAsync(string connectionString, System.ComponentModel.RunWorkerCompletedEventHandler callBack);
        abstract public void retourneDonneesAsync(string requete, System.ComponentModel.RunWorkerCompletedEventHandler callBack);
        abstract public void executeRequeteAsync(string requete, System.ComponentModel.RunWorkerCompletedEventHandler callBack);
        abstract public void executeScalaireAsync(string requete, System.ComponentModel.RunWorkerCompletedEventHandler callBack);
        abstract public void executeScalaireAsync(System.ComponentModel.RunWorkerCompletedEventHandler callBack);
        abstract public void executeProcedureStockeeAsync(System.ComponentModel.RunWorkerCompletedEventHandler callBack);
        abstract public void retourneDonneesAsync(System.ComponentModel.RunWorkerCompletedEventHandler callBack);

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

        public IMDEV.Database.models.aTable returnTable(string name, string db, string schema)
        {
            return returnTableData(name, db, schema);
        }
        public void returnTableAsync(string name, string db, string schema, System.ComponentModel.RunWorkerCompletedEventHandler callBack)
        {
            System.ComponentModel.BackgroundWorker bg = new System.ComponentModel.BackgroundWorker();
            System.Collections.Hashtable param = new System.Collections.Hashtable();

            param.Add("name", name);
            param.Add("db", db);
            param.Add("schema", schema);

            bg.DoWork += new System.ComponentModel.DoWorkEventHandler(bgReturnTable_DoWork);
            bg.RunWorkerCompleted += callBack;

            bg.RunWorkerAsync(param);
        }

        private void bgReturnTable_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            string name, db, schema;

            name = ((System.Collections.Hashtable)(e.Argument))["name"].ToString();
            db = ((System.Collections.Hashtable)(e.Argument))["db"].ToString();
            schema = ((System.Collections.Hashtable)(e.Argument))["schema"].ToString();

            e.Result = returnTableData(name, db, schema);
        }

        protected IMDEV.Database.models.aTable returnTableData(string name, string db, string schema)
        {
            models.aTable retour = null;
            Common.unRetourRequete result;
            models.aField f;
            models.aFieldType ft;

            result = retourneDonnees("select * from information_schema.columns where table_name='" + name.Trim() + "' and table_catalog='" + db + "' and table_schema='" + schema + "'");
            if (result != null)
            {
                retour = new IMDEV.Database.models.aTable();
                retour.tableName = name.Trim();
                foreach (DataRow ligne in result.Tables[0].Rows)
                {
                    f = new IMDEV.Database.models.aField();
                    ft = new IMDEV.Database.models.aFieldType();
                    ft.name = ligne["data_type"].ToString();
                    f.fieldType = ft;
                    f.name = ligne["column_name"].ToString();
                    retour.listOfFields.Add(f);
                }
            }
            return retour;
        }

        public void listTablesAsync(string db, System.ComponentModel.RunWorkerCompletedEventHandler callBack)
        {
            throw new Exception("You must specify the schema");
        }
        public void listTablesAsync(string db, string schema, System.ComponentModel.RunWorkerCompletedEventHandler callBack)
        {
            System.ComponentModel.BackgroundWorker bg = new System.ComponentModel.BackgroundWorker();
            System.Collections.Hashtable param = new System.Collections.Hashtable();

            param.Add("db", db);
            param.Add("schema", schema);

            bg.DoWork += new System.ComponentModel.DoWorkEventHandler(bg_DoWork);
            bg.RunWorkerCompleted += callBack;

            bg.RunWorkerAsync(param);
        }

        private void bg_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            string db, schema;

            db = ((System.Collections.Hashtable)(e.Argument))["db"].ToString();
            schema = ((System.Collections.Hashtable)(e.Argument))["schema"].ToString();

            e.Result = listTablesData(db, schema);
        }
        public List<string> listTables(string db)
        {
            throw new Exception("You must specify the schema");
        }
        public List<string> listTables(string db, string schema)
        {
            return listTablesData(db, schema);
        }

        protected List<string> listTablesData(string db, string schema)
        {
            Common.unRetourRequete result;
            List<string> retour = null;

            result = retourneDonnees("select table_name from information_schema.tables where table_schema='" + schema + "' and table_catalog='" + db + "' and table_type='BASE TABLE'");
            if (result != null)
            {
                retour = new List<string>();
                foreach (DataRow ligne in result.Tables[0].Rows)
                    retour.Add(ligne[0].ToString());
            }
            return retour;
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
