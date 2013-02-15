using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using CookComputing.XmlRpc;

namespace IMDEV.OpenERP.Clients
{
    public class clientOpenERP : clientReport
    {

        private const string NOM_ATTACHMENT = "ir.attachment";

        public clientOpenERP()
        {
        }

        public clientOpenERP(string serverAddress, int port)
        {
            initConnection(serverAddress, port, "", "", "");
        }
        public clientOpenERP(string serverAddress, string db, string user, string pass)
        {
            initConnection(serverAddress, 8069, db, user, pass);
        }
        public clientOpenERP(string serverAddress, int port, string db, string user, string pass)
        {
            initConnection(serverAddress, port, db, user, pass);
        }

        private void initConnection(string serverAddress, int portTCP, string db, string user, string pass)
        {
            _config.host = serverAddress;
            _config.port = portTCP;
            _config.database = db;
            if ((user != ""))
            {
                connectionData(db, user, pass);
            }
        }

        public clientOpenERP(models.@base.connectionProperties config)
        {
            chargeProprieteConnexion(config);
        }

        /// <summary>
        /// Retourne le nombre de fichier joint à un objet
        /// </summary>
        /// <param name="resourceName">Nom OpenERP de l'objet</param>
        /// <param name="id">Numéro de l'objet</param>
        /// <returns>Un entier</returns>
        /// <remarks></remarks>
        public int nbFileAttachment(string resourceName, int id)
        {
            if (checkIfBusy())
            {
                return 0;
            }
            return searchCount(buildQueryAttachment(resourceName, id), NOM_ATTACHMENT);
        }

        private models.query.aQuery buildQueryAttachment(string resourceName, int id)
        {
            models.query.aQuery req = new models.query.aQuery();
            req.addEqualTo("res_model", resourceName);
            req.addEqualTo("res_id", id);
            return req;
        }

        /// <summary>
        /// Retourne le nombre de fichier joint à un objet en asynchrone
        /// </summary>
        /// <param name="resourceName">Nom OpenERP de l'objet</param>
        /// <param name="id">Numéro de l'objet</param>
        /// <param name="callBack">Fonction appelée quand c'est terminé</param>
        /// <param name="prioritaire">Passe cette requete en priorité par rapport aux autres en attentes</param>
        /// <remarks></remarks>
        public void nbFileAttachmentAsync(string resourceName, int id, System.ComponentModel.RunWorkerCompletedEventHandler callBack)
        {
            nbFileAttachmentAsync(resourceName, id, callBack, false);
        }
        public void nbFileAttachmentAsync(string resourceName, int id, System.ComponentModel.RunWorkerCompletedEventHandler callBack, bool prioritaire)
        {
            searchCountAsync(buildQueryAttachment(resourceName, id), NOM_ATTACHMENT, callBack, prioritaire);
        }

        /// <summary>
        /// Ajoute un fichier lié à un objet OpenERP
        /// Pour le lire, la simple fonction "read" le permet de la même manière que n'importe quel objet OpenERP
        /// </summary>
        /// <param name="resourceName">Nom OpenERP de l'objet (ex:"res.partnet")</param>
        /// <param name="id">Numéro de l'objet</param>
        /// <param name="filename">Emplacement et nom du fichier à lier</param>
        /// <param name="libelle">Nom logique du fichier</param>
        /// <returns>Le numéro de l'objet OpenERP</returns>
        /// <remarks></remarks>
        public int addFileAttachment(string resourceName, int id, string filename)
        {
            return addFileAttachment(resourceName, id, "");
        }
        public int addFileAttachment(string resourceName, int id, string filename, string libelle)
        {
            if (checkIfBusy())
            {
                return 0;
            }
            return addFileAttachmentData(resourceName, id, filename, libelle);
        }

        private int addFileAttachmentData(string resourceName, int id, string filename, string libelle)
        {
            string _contentBase64;
            models.@base.aGenericObject obj = new models.@base.aGenericObject(NOM_ATTACHMENT);
            models.@base.listProperties comp = new models.@base.listProperties();
            byte octet;
            if (((resourceName == "")
                        || ((id <= 0)
                        || (filename == ""))))
            {
                throw new ArgumentNullException();
            }
            if ((libelle == ""))
            {
                libelle = System.IO.Path.GetFileNameWithoutExtension(filename);
            }
            System.IO.FileStream f = new System.IO.FileStream(filename, System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.Read);
            System.IO.MemoryStream donnees = new System.IO.MemoryStream((int)f.Length);
            while ((f.Position < f.Length))
            {
                octet = (byte)f.ReadByte();
                donnees.WriteByte(octet);
            }
            f.Close();
            byte[] dummyArray = donnees.ToArray();
            _contentBase64 = IMDEV.Decrypt.Base64.encodeBase64(ref dummyArray);
            obj.listProperties.add("datas", _contentBase64);
            obj.listProperties.add("datas_fname", System.IO.Path.GetFileName(filename));
            obj.listProperties.add("name", libelle);
            obj.listProperties.add("type", "binary");
            comp.add("default_res_model", resourceName);
            comp.add("default_res_id", id);
            return insert(obj, comp);
        }

        /// <summary>
        /// Ajoute un fichier lié à un objet OpenERP en asynchrone
        /// Pour le lire, la simple fonction "read" le permet de la même manière que n'importe quel objet OpenERP
        /// </summary>
        /// <param name="resourceName">Nom OpenERP de l'objet (ex:"res.partnet")</param>
        /// <param name="id">Numéro de l'objet</param>
        /// <param name="filename">Emplacement et nom du fichier à lier</param>
        /// <param name="libelle">Nom logique du fichier</param>
        /// <param name="callBack">Fonction appelée quand c'est terminé</param>
        /// <param name="prioritaire">Passe cette requete en priorité par rapport aux autres en attentes</param>
        /// <remarks></remarks>
        public void addFileAttachmentAsync(string resourceName, int id, string filename, System.ComponentModel.RunWorkerCompletedEventHandler callBack)
        {
            addFileAttachmentAsync(resourceName, id, filename, callBack, "", false);
        }
        public void addFileAttachmentAsync(string resourceName, int id, string filename, System.ComponentModel.RunWorkerCompletedEventHandler callBack, string libelle)
        {
            addFileAttachmentAsync(resourceName, id, filename, callBack, libelle, false);
        }
        public void addFileAttachmentAsync(string resourceName, int id, string filename, System.ComponentModel.RunWorkerCompletedEventHandler callBack, bool prioritaire)
        {
            addFileAttachmentAsync(resourceName, id, filename, callBack, "", prioritaire);
        }
        public void addFileAttachmentAsync(string resourceName, int id, string filename, System.ComponentModel.RunWorkerCompletedEventHandler callBack, string libelle, bool prioritaire)
        {
            Hashtable param = new Hashtable();
            param.Add("resourceName", resourceName);
            param.Add("id", id);
            param.Add("filename", filename);
            param.Add("libelle", libelle);
            _work.addTask(new System.ComponentModel.DoWorkEventHandler(this.addFileAttachmentAsyncCall), callBack, param, prioritaire);
        }

        private void addFileAttachmentAsyncCall(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            e.Result = addFileAttachmentData((string)((Hashtable)(e.Argument))["resourceName"], (int)((Hashtable)(e.Argument))["id"], (string)((Hashtable)(e.Argument))["filename"], (string)((Hashtable)(e.Argument))["libelle"]);
        }

        /// <summary>
        /// Copie un objet OpenERP pour en créer un nouveau
        /// </summary>
        /// <param name="resourceName">Type d'objet OpenERP</param>
        /// <param name="id">Numéro de l'objet OpenERP à copier</param>
        /// <param name="valeurs">Liste de champs à mettre à jour sur la copie</param>
        /// <returns>Numéro de l'objet nouvellement créer par la copie</returns>
        /// <remarks></remarks>
        public int copy(string resourceName, int id)
        {
            return copy(resourceName, id, null);
        }
        public int copy(string resourceName, int id, models.@base.listProperties valeurs)
        {
            if (checkIfBusy())
            {
                return 0;
            }
            return copyData(resourceName, id, valeurs);
        }

        //  TODO : Pourquoi ne pas envoyer un anOpenERPObject ?
        private int copyData(string resourceName, int id, models.@base.listProperties valeurs)
        {
            Interfaces.IObject conn;
            int retour = 0;
            try
            {
                conn = XmlRpcProxyGen.Create<Interfaces.IObject>();
                conn.Url = url(SERVICE_XMLRPC.@object);
                if ((valeurs == null))
                {
                    retour = (int)conn.execute(_config.database, _config.userId, _config.password, resourceName, "copy", id);
                }
                else
                {
                    retour = (int)conn.executeTwoParam(_config.database, _config.userId, _config.password, resourceName, "copy", id, valeurs.toArray());
                }
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
            return retour;
        }

        /// <summary>
        /// Copie un objet OpenERP pour en créer un nouveau en asynchrone
        /// </summary>
        /// <param name="resourceName">Type d'objet OpenERP</param>
        /// <param name="id">Numéro de l'objet OpenERP à copier</param>
        /// <param name="valeurs">Liste de champs à mettre à jour sur la copie</param>
        /// <param name="callBack">Fonction appelée quand c'est terminé</param>
        /// <param name="prioritaire">Passe cette requete en priorité par rapport aux autres en attentes</param>
        /// <remarks></remarks>
        public void copyAsync(string resourceName, int id, System.ComponentModel.RunWorkerCompletedEventHandler callBack)
        {
            copyAsync(resourceName, id, callBack, null, false);
        }
        public void copyAsync(string resourceName, int id, System.ComponentModel.RunWorkerCompletedEventHandler callBack, models.@base.listProperties valeurs)
        {
            copyAsync(resourceName, id, callBack, valeurs, false);
        }
        public void copyAsync(string resourceName, int id, System.ComponentModel.RunWorkerCompletedEventHandler callBack, bool prioritaire)
        {
            copyAsync(resourceName, id, callBack, null, prioritaire);
        }
        public void copyAsync(string resourceName, int id, System.ComponentModel.RunWorkerCompletedEventHandler callBack, models.@base.listProperties valeurs, bool prioritaire)
        {
            Hashtable param = new Hashtable();
            param.Add("resourceName", resourceName);
            param.Add("id", id);
            param.Add("valeurs", valeurs);
            _work.addTask(new System.ComponentModel.DoWorkEventHandler(this.copyAsyncCall), callBack, param, prioritaire);
        }

        private void copyAsyncCall(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            e.Result = copyData((string)((Hashtable)(e.Argument))["resourceName"], (int)((Hashtable)(e.Argument))["id"], (models.@base.listProperties)((Hashtable)(e.Argument))["valeurs"]);
        }

        /// <summary>
        /// Vérifie les dépendances d'un objet OpenERP (parent et child) pour s'assurer qu'il n'y ai pas de boucle infinie (dépendance sur soit même)
        /// </summary>
        /// <param name="resourceName">Type d'objet OpenERP</param>
        /// <param name="id">Numéro de l'objet à vérifier</param>
        /// <returns>True = tout va bien, False = Erreur quelque part</returns>
        /// <remarks></remarks>
        public bool checkRecursion(string resourceName, int id)
        {
            if (checkIfBusy())
            {
                return false;
            }
            ArrayList listId = new ArrayList();
            listId.Add(id);
            return checkRecursionData(resourceName, listId);
        }

        /// <summary>
        /// Vérifie les dépendances de plusieurs objets OpenERP (parent et child) pour s'assurer qu'il n'y ai pas de boucle infinie (dépendance sur soit même)
        /// </summary>
        /// <param name="resourceName">Type d'objet OpenERP</param>
        /// <param name="listId">Liste des numéros d'objet à vérifier</param>
        /// <returns>True = tout va bien, False = Erreur quelque part</returns>
        /// <remarks></remarks>
        public bool checkRecursion(string resourceName, ArrayList listId)
        {
            if (checkIfBusy())
            {
                return false;
            }
            return checkRecursionData(resourceName, listId);
        }

        private bool checkRecursionData(string resourceName, ArrayList listId)
        {
            Interfaces.IObject conn;
            bool retour;
            try
            {
                conn = XmlRpcProxyGen.Create<Interfaces.IObject>();
                conn.Url = url(SERVICE_XMLRPC.@object);
                retour = (bool)conn.execute(_config.database, _config.userId, _config.password, resourceName, "check_recursion", listId.ToArray());
                return retour;
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
            return true;
        }

        /// <summary>
        /// Vérifie les dépendances de plusieurs objets OpenERP (parent et child) pour s'assurer qu'il n'y ai pas de boucle infinie (dépendance sur soit même) en asynchrone
        /// </summary>
        /// <param name="resourceName">Type d'objet OpenERP</param>
        /// <param name="listId">Liste des numéros d'objet à vérifier</param>
        /// <param name="callBack">Fonction appelée quand c'est terminé</param>
        /// <param name="prioritaire">Passe cette requete en priorité par rapport aux autres en attentes</param>
        /// <remarks></remarks>
        public void checkRecursionAsync(string resourceName, ArrayList listId, System.ComponentModel.RunWorkerCompletedEventHandler callBack)
        {
            checkRecursionAsync(resourceName, listId, callBack, false);
        }
        public void checkRecursionAsync(string resourceName, ArrayList listId, System.ComponentModel.RunWorkerCompletedEventHandler callBack, bool prioritaire)
        {
            Hashtable param = new Hashtable();
            param.Add("resourceName", resourceName);
            param.Add("listId", listId);
            _work.addTask(new System.ComponentModel.DoWorkEventHandler(checkRecursionAsyncCallListId), callBack, param, prioritaire);
        }

        /// <summary>
        /// Vérifie les dépendances de plusieurs objets OpenERP (parent et child) pour s'assurer qu'il n'y ai pas de boucle infinie (dépendance sur soit même) en asynchrone
        /// </summary>
        /// <param name="resourceName">Type d'objet OpenERP</param>
        /// <param name="id">Numéro de l'objet à vérifier</param>
        /// <param name="callBack">Fonction appelée quand c'est terminé</param>
        /// <param name="prioritaire">Passe cette requete en priorité par rapport aux autres en attentes</param>
        /// <remarks></remarks>
        public void checkRecursionAsync(string resourceName, int id, System.ComponentModel.RunWorkerCompletedEventHandler callBack)
        {
            checkRecursionAsync(resourceName, id, callBack, false);
        }
        public void checkRecursionAsync(string resourceName, int id, System.ComponentModel.RunWorkerCompletedEventHandler callBack, bool prioritaire)
        {
            Hashtable param = new Hashtable();
            ArrayList listId = new ArrayList();
            listId.Add(id);
            param.Add("resourceName", resourceName);
            param.Add("id", listId);
            _work.addTask(new System.ComponentModel.DoWorkEventHandler(this.checkRecursionAsyncCallId), callBack, param, prioritaire);
        }

        private void checkRecursionAsyncCallListId(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            e.Result = checkRecursionData((string)((Hashtable)(e.Argument))["resourceName"], (ArrayList)((Hashtable)(e.Argument))["listId"]);
        }
        private void checkRecursionAsyncCallId(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            ArrayList listId = new ArrayList();
            listId.Add((int)((Hashtable)(e.Argument))["id"]);
            e.Result = checkRecursionData((string)((Hashtable)(e.Argument))["resourceName"], listId);
        }

        /// <summary>
        /// Retourne les valeurs par défauts des champs envoyés en paramètre, pour l'objet OpenERP envoyé en paramètre
        /// </summary>
        /// <param name="resourceName">Nom de l'objet OpenERP</param>
        /// <param name="listeChamps">Liste des champs</param>
        /// <returns>Un tableau de valeurs avec clé (listProperties)</returns>
        /// <remarks></remarks>
        public models.@base.listProperties defaultGet(string resourceName, List<string> listeChamps)
        {
            if (checkIfBusy())
            {
                return null;
            }
            return defaultGetData(resourceName, listeChamps);
        }

        private models.@base.listProperties defaultGetData(string resourceName, List<string> listeChamps)
        {
            Interfaces.IObject conn;
            object retour;
            models.@base.listProperties ret = new models.@base.listProperties();
            try
            {
                conn = XmlRpcProxyGen.Create<Interfaces.IObject>();
                conn.Url = url(SERVICE_XMLRPC.@object);
                retour = conn.execute(_config.database, _config.userId, _config.password, resourceName, "default_get", listeChamps.ToArray());
                ret.copyData((XmlRpcStruct)retour);
                return ret;
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
            return null;
        }

        /// <summary>
        /// Retourne les valeurs par défauts des champs envoyés en paramètre, pour l'objet OpenERP envoyé en paramètre en asynchrone
        /// </summary>
        /// <param name="resourceName">Nom de l'objet OpenERP</param>
        /// <param name="listeChamps">Liste des champs</param>
        /// <param name="callBack">Fonction appelée quand c'est terminé</param>
        /// <param name="prioritaire">Passe cette requete en priorité par rapport aux autres en attentes</param>
        /// <remarks></remarks>
        public void defaultGetAsync(string resourceName, List<string> listeChamps, System.ComponentModel.RunWorkerCompletedEventHandler callBack)
        {
            defaultGetAsync(resourceName, listeChamps, callBack, false);
        }
        public void defaultGetAsync(string resourceName, List<string> listeChamps, System.ComponentModel.RunWorkerCompletedEventHandler callBack, bool prioritaire)
        {
            Hashtable param = new Hashtable();
            param.Add("resourceName", resourceName);
            param.Add("listeChamps", listeChamps);
            _work.addTask(new System.ComponentModel.DoWorkEventHandler(this.defaultGetAsyncCall), callBack, param, prioritaire);
        }

        private void defaultGetAsyncCall(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            e.Result = defaultGetData((string)((Hashtable)(e.Argument))["resourceName"], (List<string>)((Hashtable)(e.Argument))["listeChamps"]);
        }

        /// <summary>
        /// Retourne les données des champs envoyés en paramètre pour les numéro d'objet envoyés en paramètre
        /// </summary>
        /// <param name="resourceName">Nom de l'objet OpenERP</param>
        /// <param name="listId">Liste des numéro unique d'objet OpenERP</param>
        /// <param name="listFields">Liste des champs à exporter</param>
        /// <returns>Liste des listes de champs exportés</returns>
        /// <remarks></remarks>
        public List<models.@base.listProperties> exportData(string resourceName, List<int> listId, List<string> listFields)
        {
            if (checkIfBusy())
            {
                return null;
            }
            return exportDataData(resourceName, listId, listFields);
        }

        private List<models.@base.listProperties> exportDataData(string resourceName, List<int> listId, List<string> listeChamps)
        {
            Interfaces.IObject conn;
            object retour;
            List<models.@base.listProperties> ret = new List<models.@base.listProperties>();
            IEnumerator boucle;
            IEnumerator b2;
            models.@base.listProperties list;
            int i;
            try
            {
                conn = XmlRpcProxyGen.Create<Interfaces.IObject>();
                conn.Url = url(SERVICE_XMLRPC.@object);
                retour = conn.executeTwoParam(_config.database, _config.userId, _config.password, resourceName, "export_data", listId.ToArray(), listeChamps.ToArray());
                boucle = ((Array)(((XmlRpcStruct)(retour))["datas"])).GetEnumerator();
                while (boucle.MoveNext())
                {
                    b2 = ((Array)(boucle.Current)).GetEnumerator();
                    list = new models.@base.listProperties();
                    i = 0;
                    while (b2.MoveNext())
                    {
                        list.add(listeChamps[i], b2.Current);
                        i++;
                    }
                    ret.Add(list);
                }
                return ret;
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
            return null;
        }

        /// <summary>
        /// Retourne les données des champs envoyés en paramètre pour les numéro d'objet envoyés en paramètre
        /// </summary>
        /// <param name="resourceName">Nom de l'objet OpenERP</param>
        /// <param name="listId">Liste des numéro unique d'objet OpenERP</param>
        /// <param name="listFields">Liste des champs à exporter</param>
        /// <param name="callBack">Fonction appelée quand c'est terminé</param>
        /// <param name="prioritaire">Passe cette requete en priorité par rapport aux autres en attentes</param>
        /// <remarks></remarks>
        public void exportDataAsync(string resourceName, List<int> listId, List<string> listFields, System.ComponentModel.RunWorkerCompletedEventHandler callBack)
        {
            exportDataAsync(resourceName, listId, listFields, callBack, false);
        }
        public void exportDataAsync(string resourceName, List<int> listId, List<string> listFields, System.ComponentModel.RunWorkerCompletedEventHandler callBack, bool prioritaire)
        {
            Hashtable param = new Hashtable();
            param.Add("resourceName", resourceName);
            param.Add("listId", listId);
            param.Add("listFields", listFields);
            _work.addTask(new System.ComponentModel.DoWorkEventHandler(this.exportDataAsyncCall), callBack, param, prioritaire);
        }

        private void exportDataAsyncCall(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            e.Result = exportDataData((string)((Hashtable)(e.Argument))["resourceName"], (List<int>)((Hashtable)(e.Argument))["listId"], (List<string>)((Hashtable)(e.Argument))["listFields"]);
        }

        public models.@base.listProperties getData(string resourceName, string order, string what, ArrayList comp, models.@base.listProperties context)
        {
            Interfaces.IObject conn;
            object retour;
            List<models.@base.listProperties> ret = new List<models.@base.listProperties>();
            XmlRpcStruct boucle;
            models.@base.listProperties list;
            try
            {
                conn = XmlRpcProxyGen.Create<Interfaces.IObject>();
                conn.Url = url(SERVICE_XMLRPC.@object);
                retour = conn.executeFiveParam(_config.database, _config.userId, _config.password, resourceName, "get", order, what, comp.ToArray(),false, context.toArray());
                boucle = ((XmlRpcStruct)((object[])((((object[])(retour))[0])))[2]);
                list = new IMDEV.OpenERP.models.@base.listProperties();
                list.copyData(boucle);
                return list;
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
            return null;
        }

        /// <summary>
        /// Retourne les détails d'un(des) champ(s) d'un objet OpenERP
        /// </summary>
        /// <param name="resourceName">Nom de l'objet OpenERP</param>
        /// <param name="listFields">Liste des champs pour lequel on veut le détail</param>
        /// <returns>Liste des détails des champs</returns>
        /// <remarks></remarks>
        public List<models.@base.listProperties> fieldsGet(string resourceName, List<string> listFields)
        {
            if (checkIfBusy())
            {
                return null;
            }
            return fieldsGetData(resourceName, listFields);
        }

        private List<models.@base.listProperties> fieldsGetData(string resourceName, List<string> listFields)
        {
            Interfaces.IObject conn;
            object retour;
            List<models.@base.listProperties> ret = new List<models.@base.listProperties>();
            IEnumerator boucle;
            IEnumerator b2;
            models.@base.listProperties list;
            try
            {
                conn = XmlRpcProxyGen.Create<Interfaces.IObject>();
                conn.Url = url(SERVICE_XMLRPC.@object);
                retour = conn.execute(_config.database, _config.userId, _config.password, resourceName, "fields_get", listFields.ToArray());
                boucle = ((Array)(retour)).GetEnumerator();
                while (boucle.MoveNext())
                {
                    b2 = ((Array)(((DictionaryEntry)(boucle.Current)).Value)).GetEnumerator();
                    list = new models.@base.listProperties();
                    while (b2.MoveNext())
                    {
                        list.add((string)((DictionaryEntry)(b2.Current)).Key, ((DictionaryEntry)(b2.Current)).Value);
                    }
                    ret.Add(list);
                }
                return ret;
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
            return null;
        }

        /// <summary>
        /// Retourne les détails d'un(des) champ(s) d'un objet OpenERP en asynchrone
        /// </summary>
        /// <param name="resourceName">Nom de l'objet OpenERP</param>
        /// <param name="listFields">Liste des champs pour lequel on veut le détail</param>
        /// <param name="callBack">Fonction appelée quand c'est terminé</param>
        /// <param name="prioritaire">Passe cette requete en priorité par rapport aux autres en attentes</param>
        /// <remarks></remarks>
        public void fieldsGetAsync(string resourceName, List<string> listFields, System.ComponentModel.RunWorkerCompletedEventHandler callBack)
        {
            fieldsGetAsync(resourceName, listFields, callBack, false);
        }
        public void fieldsGetAsync(string resourceName, List<string> listFields, System.ComponentModel.RunWorkerCompletedEventHandler callBack, bool prioritaire)
        {
            Hashtable param = new Hashtable();
            param.Add("resourceName", resourceName);
            param.Add("listFields", listFields);
            _work.addTask(new System.ComponentModel.DoWorkEventHandler(this.fieldsGetAsyncCall), callBack, param, prioritaire);
        }

        private void fieldsGetAsyncCall(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            e.Result = fieldsGetData((string)((Hashtable)(e.Argument))["resourceName"], (List<string>)((Hashtable)(e.Argument))["listFields"]);
        }

        /// <summary>
        /// Récupère toutes les infos sur une vue
        /// </summary>
        /// <param name="viewId">Numéro de la vue</param>
        /// <param name="viewType">TEST EN COURS sur la véritable signification de ce paramètre optionel</param>
        /// <returns>Une liste des propriétés de la vue</returns>
        /// <remarks></remarks>
        public models.@base.listProperties fieldsViewGet(string resourceName, int viewId, string viewType, IMDEV.OpenERP.models.@base.listProperties context)
        {
            if (checkIfBusy())
            {
                return null;
            }
            return fieldsViewGetData(resourceName, viewId, viewType, context);
        }

        private models.@base.listProperties fieldsViewGetData(string resourceName, int viewId, string viewType, IMDEV.OpenERP.models.@base.listProperties context)
        {
            Interfaces.IObject conn;
            object retour;
            models.@base.listProperties ret = null;
            try
            {
                conn = XmlRpcProxyGen.Create<Interfaces.IObject>();
                conn.Url = url(SERVICE_XMLRPC.@object);
                retour = conn.executeThreeParam(_config.database, _config.userId, _config.password, resourceName, "fields_view_get", viewId, viewType, context.toArray());
                ret = new models.@base.listProperties();
                ret.copyData((XmlRpcStruct)retour);
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
            return ret;
        }

        /// <summary>
        /// Récupère toutes les infos sur une vue en asynchrone
        /// </summary>
        /// <param name="viewId">Numéro de la vue</param>
        /// <param name="viewType">TEST EN COURS sur la véritable signification de ce paramètre optionel</param>
        /// <param name="callBack">Fonction appelée quand c'est terminé</param>
        /// <param name="prioritaire">Passe cette requete en priorité par rapport aux autres en attentes</param>
        /// <remarks></remarks>
        public void fieldsViewGetAsync(string resourceName, int viewId, System.ComponentModel.RunWorkerCompletedEventHandler callBack, string viewType, IMDEV.OpenERP.models.@base.listProperties context)
        {
            fieldsViewGetAsync(resourceName, viewId, callBack, viewType, context, false);
        }
        public void fieldsViewGetAsync(string resourceName, int viewId, System.ComponentModel.RunWorkerCompletedEventHandler callBack, string viewType, IMDEV.OpenERP.models.@base.listProperties context, bool prioritaire)
        {
            Hashtable param = new Hashtable();
            param.Add("resourceName",resourceName);
            param.Add("viewId", viewId);
            param.Add("viewType", viewType);
            param.Add("context", context);
            _work.addTask(new System.ComponentModel.DoWorkEventHandler(this.fieldsViewGetAsyncCall), callBack, param, prioritaire);
        }

        private void fieldsViewGetAsyncCall(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            e.Result = fieldsViewGet((string)((Hashtable)(e.Argument))["resourceName"], (int)((Hashtable)(e.Argument))["viewId"], (string)((Hashtable)(e.Argument))["viewType"], (IMDEV.OpenERP.models.@base.listProperties)((Hashtable)(e.Argument))["context"]);
        }

        /// <summary>
        /// Importe des données dans un objet (une table)
        /// </summary>
        /// <param name="resourceName"></param>
        /// <param name="listFields"></param>
        /// <param name="datas"></param>
        /// <param name="mode"></param>
        /// <returns>Le nombre d'enregistrement ajouté</returns>
        /// <remarks></remarks>
        public int importData(string resourceName, List<string> listFields, models.@base.listProperties datas)
        {
            return importData(resourceName, listFields, datas, "init");
        }
        public int importData(string resourceName, List<string> listFields, models.@base.listProperties datas, string mode)
        {
            if (checkIfBusy())
            {
                return 0;
            }
            return importDataData(resourceName, listFields, datas, mode);
        }

        private int importDataData(string resourceName, List<string> listFields, models.@base.listProperties datas, string mode)
        {
            Interfaces.IObject conn;
            object retour;
            try
            {
                conn = XmlRpcProxyGen.Create<Interfaces.IObject>();
                conn.Url = url(SERVICE_XMLRPC.@object);
                retour = conn.executeThreeParam(_config.database, _config.userId, _config.password, resourceName, "import_data", listFields.ToArray(), datas.toArray(), mode);
                return (int)((XmlRpcStruct)(retour))[0];
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
            return 0;
        }

        /// <summary>
        /// Importe des données dans un objet (une table) en asynchrone
        /// </summary>
        /// <param name="resourceName"></param>
        /// <param name="listFields"></param>
        /// <param name="datas"></param>
        /// <param name="callBack">Fonction appelée quand c'est terminé</param>
        /// <param name="mode"></param>
        /// <param name="prioritaire">Passe cette requete en priorité par rapport aux autres en attentes</param>
        /// <remarks></remarks>
        public void importDataAsync(string resourceName, List<string> listFields, models.@base.listProperties datas, System.ComponentModel.RunWorkerCompletedEventHandler callBack, string mode)
        {
            importDataAsync(resourceName, listFields, datas, callBack, mode, false);
        }
        public void importDataAsync(string resourceName, List<string> listFields, models.@base.listProperties datas, System.ComponentModel.RunWorkerCompletedEventHandler callBack)
        {
            importDataAsync(resourceName, listFields, datas, callBack, "init", false);
        }
        public void importDataAsync(string resourceName, List<string> listFields, models.@base.listProperties datas, System.ComponentModel.RunWorkerCompletedEventHandler callBack, bool prioritaire)
        {
            importDataAsync(resourceName, listFields, datas, callBack, "init", prioritaire);
        }
        public void importDataAsync(string resourceName, List<string> listFields, models.@base.listProperties datas, System.ComponentModel.RunWorkerCompletedEventHandler callBack, string mode, bool prioritaire)
        {
            Hashtable param = new Hashtable();
            param.Add("resourceName", resourceName);
            param.Add("listFields", listFields);
            param.Add("datas", datas);
            param.Add("mode", mode);
            _work.addTask(new System.ComponentModel.DoWorkEventHandler(this.importDataAsyncCall), callBack, param, prioritaire);
        }

        private void importDataAsyncCall(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            e.Result = importDataData((string)((Hashtable)(e.Argument))["resourceName"], (List<string>)((Hashtable)(e.Argument))["listFields"], (models.@base.listProperties)((Hashtable)(e.Argument))["datas"], (string)((Hashtable)(e.Argument))["mode"]);
        }
    }
}
