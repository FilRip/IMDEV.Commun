using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using Npgsql;
using IMDEV.Database.Common;

namespace IMDEV.Database.DBServer
{
    class connectPostgreSQL : baseDB
    {
        private NpgsqlConnection _conn;
        private NpgsqlCommand _proc;

        public override bool connect(string connectionString)
        {
            try
            {
                _lastServeur = connectionString;
                _conn = new NpgsqlConnection(connectionString);
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
            return connexion(parameters.server, parameters.databaseName, parameters.userName, parameters.password, parameters.portTCP);
        }

        public bool connexion(string serveur, string baseDeDonnees, string login, string motDePasse)
        {
            return connexion(serveur, baseDeDonnees, login, motDePasse, 5432);
        }
        public bool connexion(string serveur, string baseDeDonnees, string login, string motDePasse, int port)
        {
            string chaine = "Server=" + serveur + ";Database=" + baseDeDonnees + ";User id=" + login + ";Password=" + motDePasse + ";Port=" + port.ToString();
            return connect(chaine);
        }

        public override void connectAsync(connectionProperties parameters, System.ComponentModel.RunWorkerCompletedEventHandler callBack)
        {
            System.ComponentModel.BackgroundWorker bg = new System.ComponentModel.BackgroundWorker();
            System.Collections.Hashtable param = new Hashtable();

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

        private unRetourRequete copieDonnees(ref NpgsqlDataReader source)
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
                catch {}
            }
            return null;
        }

        override public unRetourRequete retourneDonnees(string requete)
        {
            NpgsqlCommand sa = new NpgsqlCommand();
            NpgsqlDataReader src = null;

            verifConnexion();
            try
            {
                sa.Connection = _conn;
                sa.CommandType = CommandType.Text;
                sa.CommandText = requete;
                src = sa.ExecuteReader();
                if (((src != null) && (src.HasRows)))
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
                catch {}
                src = null;
            }
            return null;
        }

        override public bool executeRequete(string requete)
        {
            NpgsqlCommand sa = new NpgsqlCommand();

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
                _proc = new NpgsqlCommand();
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
            NpgsqlDataReader reader = null;
            try
            {
                _proc.Connection = _conn;
                reader = _proc.ExecuteReader();
                if ((reader != null) && (reader.HasRows))
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
                catch {}
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
            catch {}
            finally
            {
                _conn = null;
            }
        }

        private void verifConnexion()
        {
            if ((_conn == null) || (_conn.State != ConnectionState.Open))
                if (!string.IsNullOrEmpty(_lastServeur))
                    try
                    {
                        _conn = new NpgsqlConnection(_lastServeur);
                        _conn.Open();
                    }
                    catch {}
        }

        public override object executeScalaire(string requete)
        {
            NpgsqlCommand sa = new NpgsqlCommand();

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

        public override ConnectionState state()
        {
            return _conn.State;
        }
    }
}
