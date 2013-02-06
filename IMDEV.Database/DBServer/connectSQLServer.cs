﻿using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Data.SqlClient;
using IMDEV.Database.Common;

namespace IMDEV.Database.DBServer
{
    class connectSQLServer : baseDB
    {
        private SqlConnection _conn;
        private SqlCommand _proc;

        public override bool connect(string connectionString)
        {
            try
            {
                _lastServeur = connectionString;
                _conn = new SqlConnection(connectionString);
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
            return connexion(parameters.server, parameters.databaseName, parameters.userName, parameters.password);
        }

        public bool connexion(string serveur, string nomBase, string login, string motDePasse)
        {
            string chaineConnexion = "Persist Security Info=False;Integrated Security=False;workstation id=PA:" + System.Environment.MachineName + ";packet size=4096;initial catalog=" + nomBase + ";data source='" + serveur + "';user id=" + login + ";password='" + motDePasse + "'";
            return connect(chaineConnexion);
        }

        private unRetourRequete copieDonnees(ref SqlDataReader source)
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
            SqlCommand sa = new SqlCommand();
            SqlDataReader src = null;

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
                catch {}
                src = null;
            }
            return null;
        }

        override public bool executeRequete(string requete)
        {
            SqlCommand sa = new SqlCommand();

            verifConnexion();
            try
            {
                sa.Connection = _conn;
                sa.CommandText = requete;
                sa.CommandType = CommandType.Text;
                _lastNbAffected = sa.ExecuteNonQuery();
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
                _proc = new SqlCommand();
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
            SqlDataReader reader = null;
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

        public override object executeScalaire(string requete)
        {
            SqlCommand sa = new SqlCommand();

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
        private void verifConnexion()
        {
            if ((_conn == null) || (_conn.State != ConnectionState.Open))
                if (!string.IsNullOrEmpty(_lastServeur))
                    try
                    {
                        _conn = new SqlConnection(_lastServeur);
                        _conn.Open();
                    }
                    catch {}
        }

        public override ConnectionState state()
        {
            return _conn.State;
        }
    }
}