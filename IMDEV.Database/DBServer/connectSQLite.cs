﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using IMDEV.Database.Common;
using System.Data.SQLite;
using System.Data;

namespace IMDEV.Database.DBServer
{
    class connectSQLite : baseDB
    {
        private SQLiteConnection _conn;
        private SQLiteCommand _proc;

        public override bool connect(string connectionString)
        {
            try
            {
                _lastServeur = connectionString;
                _conn = new SQLiteConnection(connectionString);
                _conn.Open();
                return true;
            }
            catch (Exception ex)
            {
                _lastError = ex.Message;
            }
            return false;
        }

        public override bool connect(connectionProperties parameters)
        {
            return connexion(parameters.fileName);
        }

        public new string currentDatabase
        {
            get
            {
                foreach (string partie in _lastServeur.Split(';'))
                {
                    if (partie.ToLower().Trim().StartsWith("data source="))
                        return partie.Split('=')[1].Trim().ToString();
                }
                return "";
            }
        }

        public bool connexion(string nomFichier)
        {
            string chaineConnexion = "Data Source=" + nomFichier + ";Pooling=true;FailIfMissing=false";
            return connect(chaineConnexion);
        }

        public override void connectAsync(connectionProperties parameters, System.ComponentModel.RunWorkerCompletedEventHandler callBack)
        {
            System.ComponentModel.BackgroundWorker bg = new System.ComponentModel.BackgroundWorker();
            System.Collections.Hashtable param = new System.Collections.Hashtable();

            param.Add("connectionProperties", parameters);
            bg.DoWork += new System.ComponentModel.DoWorkEventHandler(bgConnect_DoWork);
            bg.RunWorkerCompleted += callBack;
            bg.RunWorkerAsync(param);
        }

        public override void connectAsync(string connectionString, System.ComponentModel.RunWorkerCompletedEventHandler callBack)
        {
            System.ComponentModel.BackgroundWorker bg = new System.ComponentModel.BackgroundWorker();
            System.Collections.Hashtable param = new Hashtable();

            param.Add("connectionString", connectionString);
            bg.DoWork += new System.ComponentModel.DoWorkEventHandler(bgConnect_DoWork);
            bg.RunWorkerCompleted += callBack;
            bg.RunWorkerAsync(param);
        }

        private void bgConnect_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            IMDEV.Database.Common.connectionProperties cp;
            string connectionString;

            if (((Hashtable)(e.Argument)).ContainsKey("connectionString"))
            {
                connectionString = ((Hashtable)(e.Argument))["connectionString"].ToString();
                if (!connect(connectionString))
                {
                    e.Result = false;
                    return;
                }
            }
            else
            {
                cp = (IMDEV.Database.Common.connectionProperties)((Hashtable)(e.Argument))["connectionProperties"];
                if (!connect(cp))
                {
                    e.Result = false;
                    return;
                }
            }
            while (_conn.State == ConnectionState.Connecting) { }
            if (_conn.State != ConnectionState.Open)
            {
                e.Result = false;
                return;
            }
            e.Result = true;
        }

        public override void retourneDonneesAsync(string requete, System.ComponentModel.RunWorkerCompletedEventHandler callBack)
        {
            System.ComponentModel.BackgroundWorker bg = new System.ComponentModel.BackgroundWorker();
            Hashtable param = new Hashtable();

            param.Add("requete", requete);
            bg.DoWork += new System.ComponentModel.DoWorkEventHandler(bgRetourneDonnees_DoWork);
            bg.RunWorkerCompleted += callBack;
            bg.RunWorkerAsync(param);
        }

        private void bgRetourneDonnees_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            string requete;

            if (((Hashtable)(e.Argument)).ContainsKey("requete"))
            {
                requete = ((Hashtable)(e.Argument))["requete"].ToString();
                e.Result = retourneDonnees(requete);
            }
            else
            {
                e.Result = retourneDonnees();
            }
        }

        public override void executeRequeteAsync(string requete, System.ComponentModel.RunWorkerCompletedEventHandler callBack)
        {
            System.ComponentModel.BackgroundWorker bg = new System.ComponentModel.BackgroundWorker();
            Hashtable param = new Hashtable();

            param.Add("requete", requete);
            bg.DoWork += new System.ComponentModel.DoWorkEventHandler(bgExecuteRequete_DoWork);
            bg.RunWorkerCompleted += callBack;
            bg.RunWorkerAsync(param);
        }
        private void bgExecuteRequete_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            string requete;

            requete = ((Hashtable)(e.Argument))["requete"].ToString();
            e.Result = executeRequete(requete);
        }

        public override void executeScalaireAsync(string requete, System.ComponentModel.RunWorkerCompletedEventHandler callBack)
        {
            System.ComponentModel.BackgroundWorker bg = new System.ComponentModel.BackgroundWorker();
            Hashtable param = new Hashtable();

            param.Add("requete", requete);
            bg.DoWork += new System.ComponentModel.DoWorkEventHandler(bgExecuteScalaire_DoWork);
            bg.RunWorkerCompleted += callBack;
            bg.RunWorkerAsync(param);
        }
        private void bgExecuteScalaire_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            string requete;

            if (((Hashtable)(e.Argument)).ContainsKey("requete"))
            {
                requete = ((Hashtable)(e.Argument))["requete"].ToString();
                e.Result = executeScalaire(requete);
            }
            else
            {
                e.Result = executeScalaire();
            }
        }

        public override void executeScalaireAsync(System.ComponentModel.RunWorkerCompletedEventHandler callBack)
        {
            System.ComponentModel.BackgroundWorker bg = new System.ComponentModel.BackgroundWorker();

            bg.DoWork += new System.ComponentModel.DoWorkEventHandler(bgExecuteScalaire_DoWork);
            bg.RunWorkerCompleted += callBack;
            bg.RunWorkerAsync();
        }

        public override void executeProcedureStockeeAsync(System.ComponentModel.RunWorkerCompletedEventHandler callBack)
        {
            System.ComponentModel.BackgroundWorker bg = new System.ComponentModel.BackgroundWorker();

            bg.DoWork += new System.ComponentModel.DoWorkEventHandler(bgExecuteProcedureStockee_DoWork);
            bg.RunWorkerCompleted += callBack;
            bg.RunWorkerAsync();
        }
        private void bgExecuteProcedureStockee_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            e.Result = executeProcedureStockee();
        }

        public override void retourneDonneesAsync(System.ComponentModel.RunWorkerCompletedEventHandler callBack)
        {
            System.ComponentModel.BackgroundWorker bg = new System.ComponentModel.BackgroundWorker();

            bg.DoWork += new System.ComponentModel.DoWorkEventHandler(bgRetourneDonnees_DoWork);
            bg.RunWorkerCompleted += callBack;
            bg.RunWorkerAsync();
        }

        private unRetourRequete copieDonnees(ref SQLiteDataReader source)
        {
            unRetourRequete retour = new unRetourRequete();

            try
            {
                retour.Tables.Add("Resultat1");
                for (int i = 0; i <= source.FieldCount - 1; i++)
                    retour.Tables[0].Columns.Add(source.GetName(i), source.GetFieldType(i));
                while (source.Read())
                {
                    retour.Tables[0].Rows.Add();
                    for (int numColonne = 0; numColonne <= source.FieldCount - 1; numColonne++)
                        retour.Tables[0].Rows[retour.Tables[0].Rows.Count - 1][numColonne] = source[numColonne];
                }
                return retour;
            }
            catch (Exception ex)
            {
                _lastError = ex.Message;
            }
            finally
            {
                try
                {
                    source.Close();
                }
                catch { }
            }
            return null;
        }

        override public unRetourRequete retourneDonnees(string requete)
        {
            SQLiteCommand sa = new SQLiteCommand();
            SQLiteDataReader src = null;

            verifConnexion();
            try
            {
                sa.Connection = _conn;
                sa.CommandType = CommandType.Text;
                sa.CommandText = requete;
                src = sa.ExecuteReader();
                if ((src != null) && (src.HasRows))
                    return copieDonnees(ref src);
            }
            catch (Exception ex)
            {
                _lastError = ex.Message;
            }
            finally
            {
                sa = null;
                try
                {
                    src.Close();
                }
                catch { }
                src = null;
            }
            return null;
        }

        override public bool executeRequete(string requete)
        {
            SQLiteCommand sa = new SQLiteCommand();
            verifConnexion();
            try
            {
                sa.Connection = _conn;
                sa.CommandText = requete;
                sa.CommandType = CommandType.Text;
                _lastNbAffected=sa.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                _lastError = ex.Message;
            }
            finally
            {
                sa = null;
            }
            return false;
        }

        override public bool prepareProcedureStockee(string nom)
        {
            try
            {
                _proc = new SQLiteCommand();
                _proc.CommandType = CommandType.StoredProcedure;
                _proc.CommandText = nom;
                return true;
            }
            catch (Exception ex)
            {
                _lastError = ex.Message;
            }
            return false;
        }

        override public bool ajouteParametrePS(string nom, object valeur)
        {
            try
            {
                _proc.Parameters.AddWithValue(nom, valeur);
                return true;
            }
            catch (Exception ex)
            {
                _lastError = ex.Message;
            }
            return false;
        }

        override public bool executeProcedureStockee()
        {
            verifConnexion();
            try
            {
                _proc.Connection = _conn;
                _lastNbAffected=_proc.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                _lastError = ex.Message;
            }
            return false;
        }

        override public unRetourRequete retourneDonnees()
        {
            verifConnexion();
            SQLiteDataReader reader = null;
            try
            {
                _proc.Connection = _conn;
                reader = _proc.ExecuteReader();
                if (((reader != null) && (reader.HasRows)))
                    return copieDonnees(ref reader);
            }
            catch (Exception ex)
            {
                _lastError = ex.Message;
            }
            finally
            {
                try
                {
                    reader.Close();
                }
                catch { }
                reader = null;
            }
            return null;
        }

        override public void fermer()
        {
            try
            {
                _proc = null;
                _conn.Close();
            }
            catch { }
            finally
            {
                _conn = null;
            }
        }

        public override ConnectionState state()
        {
            if (_conn != null) return _conn.State; else return ConnectionState.Closed;
        }

        public override object executeScalaire(string requete)
        {
            SQLiteCommand sa = new SQLiteCommand();
            verifConnexion();
            try
            {
                sa.Connection = _conn;
                sa.CommandText = requete;
                sa.CommandType = CommandType.Text;
                return sa.ExecuteScalar();
            }
            catch (Exception ex)
            {
                _lastError = ex.Message;
            }
            finally
            {
                sa = null;
            }
            return null;
        }

        public override object executeScalaire()
        {
            verifConnexion();
            try
            {
                _proc.Connection = _conn;
                return _proc.ExecuteScalar();
            }
            catch (Exception ex)
            {
                _lastError = ex.Message;
            }
            return null;
        }

        public override List<string> listTables()
        {
            throw new NotImplementedException();
        }
        public override IMDEV.Database.models.aTable returnTable(string name)
        {
            throw new NotImplementedException();
        }
        public override List<IMDEV.Database.models.aFieldType> listFieldType()
        {
            throw new NotImplementedException();
        }
        public override List<string> listSchemas()
        {
            throw new NotImplementedException();
        }
        public override void listTablesAsync(System.ComponentModel.RunWorkerCompletedEventHandler callBack)
        {
            throw new NotImplementedException();
        }
        public override void returnTableAsync(string name, System.ComponentModel.RunWorkerCompletedEventHandler callBack)
        {
            throw new NotImplementedException();
        }

        private void verifConnexion()
        {
            if ((_conn == null) || (_conn.State != ConnectionState.Open))
                if (!string.IsNullOrEmpty(_lastServeur))
                    try
                    {
                        _conn = new SQLiteConnection(_lastServeur);
                        _conn.Open();
                    }
                    catch { }
        }
        public override List<string> returnCurrentPS()
        {
            List<string> retour = new List<string>();
            retour.Add(_proc.CommandText);
            foreach (SQLiteParameter val in _proc.Parameters)
                retour.Add(val.ParameterName + " = " + val.Value.ToString());
            return retour;
        }
    }
}
