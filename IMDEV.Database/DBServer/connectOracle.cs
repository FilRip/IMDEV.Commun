﻿using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Data.OracleClient;
using IMDEV.Database.Common;

namespace IMDEV.Database.DBServer
{
    class connectOracle : baseDB
    {
        private OracleConnection _conn;
        private OracleCommand _proc;

        public override bool connect(string connectionString)
        {
            try
            {
                _lastServeur = connectionString;
                _conn = new OracleConnection(connectionString);
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

        /// <summary>
        /// Permet de se connecter à un serveur, toutes les futurs commandes seront disponible et s'exécuteront sur ce serveur
        /// </summary>
        /// <param name="serveur">Nom/Adresse du serveur</param>
        /// <param name="nomBase">Nom de la base (TNS)</param>
        /// <param name="login">Nom de compte</param>
        /// <param name="motDePasse">Mot de passe du compte</param>
        /// <param name="port">Port TCP à utilisé, si différent du port par défaut de Oracle</param>
        /// <returns>True si la connexion a pu s'effectuer, sinon False</returns>
        /// <remarks></remarks>
        public bool connexion(string serveur, string nomBase, string login, string motDePasse)
        {
            return connexion(serveur,nomBase,login,motDePasse,1521);
        }
        public bool connexion(string serveur, string nomBase, string login, string motDePasse, int port)
        {
            string chaineConnexion = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=EUROPROD)(PORT=" + port.ToString() + ")))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=" + nomBase + ")));User Id=" + login + ";Password=" + motDePasse + ";";
            return connect(chaineConnexion);
        }

        /// <summary>
        /// Converti les données d'un OracleReader à un unRetourRequete
        /// </summary>
        /// <param name="source">Un OracleReader</param>
        /// <returns>un unRetourRequete si tout s'est bien passé, sinon Nothing</returns>
        /// <remarks></remarks>
        private unRetourRequete copieDonnees(ref OracleDataReader source)
        {
            unRetourRequete retour = new unRetourRequete();

            try
            {
                // On ajoute une liste, une table qui contiendra le résultat
                retour.Tables.Add("Resultat1");
                // On ajoute les champs, un par un, avec leur type d'origine
                for (int i = 0; i <= source.FieldCount - 1; i++)
                    retour.Tables[0].Columns.Add(source.GetName(i), source.GetFieldType(i));
                // Maintenant, on rempli avec les données sortie
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

        /// <summary>
        /// Exécute une requête et retourne le résultat (select)
        /// </summary>
        /// <param name="requete">Instructions SQL</param>
        /// <returns>un objet unRetourRequete (dataset) contenant toutes les données si tout s'est bien passé, sinon False</returns>
        /// <remarks></remarks>
        override public unRetourRequete retourneDonnees(string requete)
        {
            OracleCommand oc = new OracleCommand(requete);
            OracleDataReader reader = null;

            verifConnexion();
            try
            {
                oc.Connection = _conn;
                reader = oc.ExecuteReader();
                if ((reader != null) && (reader.HasRows))
                    return copieDonnees(ref reader);
            }
            catch (Exception ex)
            {
                _lastError = ex.Message;
            }
            finally
            {
                oc = null;
                try
                {
                    reader.Close();
                }
                catch {}
                reader = null;
            }
            return null;
        }

        /// <summary>
        /// Exécute une requête sur le serveur oracle actuellement connecté
        /// </summary>
        /// <param name="requete">Instructions SQL à exécuter</param>
        /// <returns>True si tout s'est bien passé, sinon False</returns>
        /// <remarks></remarks>
        override public bool executeRequete(string requete)
        {
            OracleCommand oc = new OracleCommand();

            verifConnexion();
            try
            {
                oc.Connection = _conn;
                oc.CommandText = requete;
                oc.CommandType = CommandType.Text;
                oc.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                _lastError = ex.Message;
            }
            finally
            {
                oc = null;
            }
            return false;
        }

        /// <summary>
        /// Prepare/Initialise une procédure stockée pour être exécuter plus tard après avoir entré les paramètres si necessaire
        /// </summary>
        /// <param name="nom">Nom de la procédure stockée</param>
        /// <returns>True si tout s'est bien passé, sinon False</returns>
        /// <remarks></remarks>
        override public bool prepareProcedureStockee(string nom)
        {
            try
            {
                _proc = new OracleCommand();
                _proc.CommandText = nom;
                _proc.CommandType = CommandType.StoredProcedure;
                return true;
            }
            catch (Exception ex)
            {
                _lastError = ex.Message;
            }
            return false;
        }

        /// <summary>
        /// Entre un parametre pour la procedure stockée en cours
        /// </summary>
        /// <param name="nom">Nom du paramètre à entrer</param>
        /// <param name="valeur">Valeur du paramètre à entrer dans son type d'origine</param>
        /// <returns>True si tout s'est bien passé, sinon False</returns>
        /// <remarks></remarks>
        override public bool ajouteParametrePS(string nom, object valeur)
        {
            try
            {
                OracleParameter param = new OracleParameter(nom, valeur);
                _proc.Parameters.Add(param);
                return true;
            }
            catch (Exception ex)
            {
                _lastError = ex.Message;
            }
            return false;
        }

        /// <summary>
        /// Execute une procedure stockée ne retournant pas de résultat
        /// </summary>
        /// <returns>True si tout s'est bien passé, sinon False</returns>
        /// <remarks></remarks>
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

        /// <summary>
        /// Execute une procedure stockée retournant des données
        /// </summary>
        /// <returns>un objet unRetourRequete (dataset), sinon Nothing</returns>
        /// <remarks></remarks>
        override public unRetourRequete retourneDonnees()
        {
            OracleDataReader reader = null;

            verifConnexion();
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
            {
                try
                {
                    _conn = new OracleConnection(_lastServeur);
                    _conn.Open();
                }
                catch {}
            }
        }

        public override ConnectionState state()
        {
            return _conn.State;
        }
    }
}
