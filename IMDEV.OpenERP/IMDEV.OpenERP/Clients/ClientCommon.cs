using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CookComputing.XmlRpc;
using System.Collections;

namespace IMDEV.OpenERP.Clients
{
    public class clientCommon : clientDB
    {
        public clientCommon()
        {
        }

        public clientCommon(string serverAddress)
        {
            construct(serverAddress, 8069, "", "", "");
        }
        public clientCommon(string serverAddress, int portTCP)
        {
            construct(serverAddress, portTCP, "", "", "");
        }
        public clientCommon(string serverAddress, int portTCP, string db, string login, string pass)
        {
            construct(serverAddress, portTCP, db, login, pass);
        }

        private void construct(string serverAddress, int portTCP, string db, string login, string pass)
        {
            _config.host = serverAddress;
            _config.port = portTCP;
            if ((login != ""))
            {
                connectionData(db, login, pass);
            }
        }

        /// <summary>
        /// Indique si oui ou non la connexion/l'authentification a été faite sur le serveur OpenERP
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public bool isConnected
        {
            get
            {
                return (_config.userId >= 0);
            }
        }

        /// <summary>
        /// Se connecter au serveur, sur une base et avec un utilisateur en particulier
        /// </summary>
        /// <param name="db">Nom de la base de donnée</param>
        /// <param name="user">Nom de l'utilisateur</param>
        /// <param name="pass">Mot de passe de l'utilisateur</param>
        /// <returns>True si il a pu se connecter, sinon False</returns>
        /// <remarks>getUserId(), après une réussite de connexion, donnera le numéro identifiant de l'utilisateur. Requis pour les futurs requêtes envoyées</remarks>
        public bool connection(string host, int port, string db, string user, string pass)
        {
            if (checkIfBusy())
                return false;
            _config.host = host;
            _config.port = port;
            return connectionData(db, user, pass);
        }
        public bool connection(string db, string user, string pass)
        {
            if (checkIfBusy())
                return false;

            return connectionData(db, user, pass);
        }

        protected bool connectionData(string db, string user, string pass)
        {
            Interfaces.Icommon conn;
            object retour;
            int i = -1;
            try
            {
                conn = XmlRpcProxyGen.Create<Interfaces.Icommon>();
                conn.Url = url(SERVICE_XMLRPC.common);
                retour = conn.login(db, user, pass);
                if (retour.GetType() == typeof(int))
                {
                    _config.username = user;
                    _config.password = pass;
                    _config.database = db;
                    _config.setUserId((int)retour);
                }
            }
            catch
            {
                _config.setUserId(i);
                _config.username = "";
                _config.password = "";
                _config.database = "";
            }
            finally
            {
                conn = null;
            }
            return ((_config.userId < 0) ? false : true);
        }

        /// <summary>
        /// Se connecter au serveur, sur une base et avec un utilisateur en particulier
        /// </summary>
        /// <param name="db">Nom de la base de donnée</param>
        /// <param name="user">Nom de l'utilisateur</param>
        /// <param name="pass">Mot de passe de l'utilisateur</param>
        /// <param name="callBack">Fonction appelée quand c'est terminé</param>
        /// <param name="prioritaire">Passe cette requete en priorité par rapport aux autres en attentes</param>
        /// <remarks>getUserId(), après une réussite de connexion, donnera le numéro identifiant de l'utilisateur. Requis pour les futurs requêtes envoyées</remarks>
        public void connectionAsync(string db, string user, string pass, System.ComponentModel.RunWorkerCompletedEventHandler callBack)
        {
            connectionAsync(db, user, pass, callBack, false);
        }
        public void connectionAsync(string db, string user, string pass, System.ComponentModel.RunWorkerCompletedEventHandler callBack, bool prioritaire)
        {
            Hashtable param = new Hashtable();
            param.Add("db", db);
            param.Add("user", user);
            param.Add("pass", pass);
            _work.addTask(new System.ComponentModel.DoWorkEventHandler(this.connectionAsyncCall), callBack, param, prioritaire);
        }

        private void connectionAsyncCall(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            e.Result = connectionData((string)((Hashtable)(e.Argument))["db"], (string)((Hashtable)(e.Argument))["user"], (string)((Hashtable)(e.Argument))["pass"]);
        }

        /// <summary>
        /// Retourne le message d'accueil
        /// </summary>
        /// <returns>Une chaine</returns>
        /// <remarks></remarks>
        public string loginMessage()
        {
            if (checkIfBusy())
                return null;

            return loginMessageData();
        }

        private string loginMessageData()
        {
            Interfaces.Icommon conn;
            try
            {
                conn = XmlRpcProxyGen.Create<Interfaces.Icommon>();
                conn.Url = url(SERVICE_XMLRPC.common);
                return conn.loginMessage();
            }
            catch (Exception ex)
            {
                if ((_config.reportXmlRpcError
                            && (ex.GetType() == typeof(XmlRpcFaultException))))
                {
                    throw new Systeme.exceptionOpenERP(Systeme.exceptionOpenERP.ERRORS.LIB_XMLRPC, ex.Message);
                }
            }
            finally
            {
                conn = null;
            }
            return "";
        }

        /// <summary>
        /// Retourne le message d'accueil en asynchrone
        /// </summary>
        /// <param name="callback">Fonction appelée quand c'est terminé</param>
        /// <param name="prioritaire">Passe cette requete en priorité par rapport aux autres en attentes</param>
        /// <remarks></remarks>
        public void loginMessageAsync(System.ComponentModel.RunWorkerCompletedEventHandler callback)
        {
            loginMessageAsync(callback, false);
        }
        public void loginMessageAsync(System.ComponentModel.RunWorkerCompletedEventHandler callback, bool prioritaire)
        {
            _work.addTask(new System.ComponentModel.DoWorkEventHandler(this.loginMessageAsyncCall), callback, null, prioritaire);
        }

        private void loginMessageAsyncCall(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            e.Result = loginMessageData();
        }

        /// <summary>
        /// Retourne le message "A propos de..." du serveur (essentiellement licence du produit)
        /// </summary>
        /// <returns>Une chaine</returns>
        /// <remarks></remarks>
        public string getAbout()
        {
            if (checkIfBusy())
                return null;

            return getAboutData();
        }

        private string getAboutData()
        {
            Interfaces.Icommon conn;
            try
            {
                conn = XmlRpcProxyGen.Create<Interfaces.Icommon>();
                conn.Url = url(SERVICE_XMLRPC.common);
                return conn.getAbout();
            }
            catch (Exception ex)
            {
                if ((_config.reportXmlRpcError
                            && (ex.GetType() == typeof(XmlRpcFaultException))))
                {
                    throw new Systeme.exceptionOpenERP(Systeme.exceptionOpenERP.ERRORS.LIB_XMLRPC, ex.Message);
                }
            }
            return "";
        }

        /// <summary>
        /// Retourne le message "A propos de..." du serveur (essentiellement licence du produit)
        /// </summary>
        /// <param name="callBack">Fonction appelée quand c'est terminé</param>
        /// <param name="prioritaire">Passe cette requete en priorité par rapport aux autres en attentes</param>
        /// <remarks></remarks>
        public void getAboutAsync(System.ComponentModel.RunWorkerCompletedEventHandler callBack)
        {
            getAboutAsync(callBack, false);
        }
        public void getAboutAsync(System.ComponentModel.RunWorkerCompletedEventHandler callBack, bool prioritaire)
        {
            _work.addTask(new System.ComponentModel.DoWorkEventHandler(this.getAboutAsyncCall), callBack, null, prioritaire);
        }

        private void getAboutAsyncCall(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            e.Result = getAboutData();
        }

        /// <summary>
        /// Retourne le timezone, en texte, de la base de données en cours
        /// </summary>
        /// <returns>Une chaine, exemple : "UTC"</returns>
        /// <remarks></remarks>
        public string getTimeZone()
        {
            if (checkIfBusy())
                return null;

            return getTimeZoneData();
        }

        private string getTimeZoneData()
        {
            Interfaces.Icommon conn;
            try
            {
                conn = XmlRpcProxyGen.Create<Interfaces.Icommon>();
                conn.Url = url(SERVICE_XMLRPC.common);
                return conn.getTimeZone(_config.database, _config.userId, _config.password);
            }
            catch (Exception ex)
            {
                if ((_config.reportXmlRpcError
                            && (ex.GetType() == typeof(XmlRpcFaultException))))
                {
                    throw new Systeme.exceptionOpenERP(Systeme.exceptionOpenERP.ERRORS.LIB_XMLRPC, ex.Message);
                }
            }
            finally
            {
                conn = null;
            }
            return "";
        }

        /// <summary>
        /// Retourne le timezone, en texte, de la base de données en cours en asynchrone
        /// </summary>
        /// <param name="callBack">Fonction appelée quand c'est terminé</param>
        /// <param name="prioritaire">Passe cette requete en priorité par rapport aux autres en attentes</param>
        /// <remarks></remarks>
        public void getTimeZoneAsync(System.ComponentModel.RunWorkerCompletedEventHandler callBack)
        {
            getTimeZoneAsync(callBack, false);
        }
        public void getTimeZoneAsync(System.ComponentModel.RunWorkerCompletedEventHandler callBack, bool prioritaire)
        {
            _work.addTask(new System.ComponentModel.DoWorkEventHandler(this.getTimeZoneAsyncCall), callBack, null, prioritaire);
        }

        private void getTimeZoneAsyncCall(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            e.Result = getTimeZoneData();
        }

        public models.@base.connectionProperties retourneProprieteConnexion()
        {
            return _config;
        }

        public bool chargeProprieteConnexion(models.@base.connectionProperties prop)
        {
            if (checkIfBusy())
                return false;

            return chargeProprieteConnexionData(prop);
        }

        private bool chargeProprieteConnexionData(models.@base.connectionProperties prop)
        {
            _config = prop;
            return connection(_config.database, _config.username, _config.password);
        }

        private void chargeProprieteConnexionAsyncCall(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            e.Result = chargeProprieteConnexionData((models.@base.connectionProperties)((Hashtable)(e.Argument))["prop"]);
        }

        public void chargeProprieteConnexionAsync(models.@base.connectionProperties prop, System.ComponentModel.RunWorkerCompletedEventHandler callBack)
        {
            chargeProprieteConnexionAsync(prop, callBack, false);
        }
        public void chargeProprieteConnexionAsync(models.@base.connectionProperties prop, System.ComponentModel.RunWorkerCompletedEventHandler callBack, bool prioritaire)
        {
            Hashtable param = new Hashtable();
            param.Add("prop", prop);
            _work.addTask(new System.ComponentModel.DoWorkEventHandler(this.chargeProprieteConnexionAsyncCall), callBack, param, prioritaire);
        }

        public void chargeProprieteConnexionAsync(string fichierXml, System.ComponentModel.RunWorkerCompletedEventHandler callBack)
        {
            chargeProprieteConnexionAsync(fichierXml, callBack, false);
        }
        public void chargeProprieteConnexionAsync(string fichierXml, System.ComponentModel.RunWorkerCompletedEventHandler callBack, bool prioritaire)
        {
            Hashtable param = new Hashtable();
            param.Add("fichierXml", fichierXml);
            _work.addTask(new System.ComponentModel.DoWorkEventHandler(this.chargeProprieteConnexionFichierAsyncCall), callBack, param, prioritaire);
        }

        private void chargeProprieteConnexionFichierAsyncCall(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            e.Result = chargeProprieteConnexionFichierData((string)((Hashtable)(e.Argument))["fichierXml"]);
        }

        private bool chargeProprieteConnexionFichierData(string fichierXml)
        {
            System.IO.StreamReader fich;
            models.@base.connectionProperties config;
            fich = new System.IO.StreamReader(fichierXml);
            config = new models.@base.connectionProperties();
            System.Xml.Serialization.XmlSerializer deserialisation = new System.Xml.Serialization.XmlSerializer(config.GetType());
            config = (IMDEV.OpenERP.models.@base.connectionProperties)deserialisation.Deserialize(fich);
            fich.Close();
            return chargeProprieteConnexion(config);
        }

        public bool chargeProprieteConnexion(string fichierXml)
        {
            return chargeProprieteConnexionFichierData(fichierXml);
        }

        public void sauveProprieteConnexion(string fichierDestination)
        {
            System.IO.StreamWriter fich;
            System.Xml.Serialization.XmlSerializer serialisation;
            serialisation = new System.Xml.Serialization.XmlSerializer(_config.GetType());
            fich = new System.IO.StreamWriter(fichierDestination);
            serialisation.Serialize(fich, _config);
            fich.Close();
        }
    }
}
