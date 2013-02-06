using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Data.Odbc;
using IMDEV.Database.Common;

namespace IMDEV.Database.DBServer
{
    class connectODBC : baseDB
    {
        private OdbcConnection _conn;
        private OdbcCommand _proc;

        public override bool connect(string connectionString)
        {
            try
            {
                _lastServeur = connectionString;
                _conn = new OdbcConnection(connectionString);
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
            return connexion(parameters.fileName, parameters.databaseName, parameters.userName, parameters.password, parameters.odbcType);
        }

        public bool connexion(string nomLien)
        {
            return connexion(nomLien,"","","",connectionProperties.TYPE_ODBC.SYSTEME);
        }
        public bool connexion(string nomLien, connectionProperties.TYPE_ODBC type)
        {
            return connexion(nomLien, "", "", "", type);
        }

        public bool connexion(string nomLien, string nomBase, string login, string motDePasse, connectionProperties.TYPE_ODBC type)
        {
            string chaineConnexion = (type == connectionProperties.TYPE_ODBC.FICHIER ? "filedsn" : "dsn=") + nomLien;
            if (!string.IsNullOrEmpty(nomBase))
                chaineConnexion += ";database=" + nomBase;
            if (!string.IsNullOrEmpty(login))
                chaineConnexion += ";uid=" + login;
            if (!string.IsNullOrEmpty(motDePasse))
                chaineConnexion += ";pwd='" + motDePasse + "'";
            return connect(chaineConnexion);
        }

        private unRetourRequete copieDonnees(ref OdbcDataReader source)
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
            OdbcCommand sa = new OdbcCommand();
            OdbcDataReader src = null;

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
            OdbcCommand sa = new OdbcCommand();

            verifConnexion();
            try
            {
                sa.Connection = _conn;
                sa.CommandText = requete;
                sa.CommandType = CommandType.Text;
                sa.ExecuteNonQuery();
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
                _proc = new OdbcCommand();
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
                _proc.ExecuteNonQuery();
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
            OdbcDataReader reader = null;
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
                        _conn = new OdbcConnection(_lastServeur);
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
