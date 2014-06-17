using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CookComputing.XmlRpc;
using System.Collections;

namespace IMDEV.OpenERP.Clients
{
    public class clientObjects : clientCommon
    {

        /// <summary>
        /// Lire un ou plusieurs objets de la base
        /// </summary>
        /// <param name="query">un objet requete contenant la liste des identifiants des objets à retourner/charger</param>
        /// <param name="objectType">Type d'objet à rechercher (partenaire, produit, ...). Facultatif sauf si nomObjet est absent.Si absent, un objet generic contenant tous les champs est retourné.</param>
        /// <param name="objectName">Type d'objet à rechercher en toute lettres comme le donne OpenERP (res.partner, product.product, ...). Facultatif sauf si typeObjet est absent.</param>
        /// <returns>Liste d'objets demandé en 'requete'. Un retourne un seul objet si un seul identifiant était réclamé en 'requete'</returns>
        /// <remarks></remarks>
        public List<object> read(models.query.aQuery query, System.Type objectType)
        {
            return read(query, objectType, "", null, null);
        }
        public List<object> read(models.query.aQuery query, System.Type objectType, List<string> listeChamps)
        {
            return read(query, objectType, "", listeChamps, null);
        }
        public List<object> read(models.query.aQuery query, System.Type objectType, List<string> listeChamps, models.@base.listProperties context)
        {
            return read(query, objectType, "", listeChamps, context);
        }
        public List<object> read(models.query.aQuery query, string objectName)
        {
            return read(query, null, objectName, null, null);
        }
        public List<object> read(models.query.aQuery query, string objectName, List<string> listeChamps)
        {
            return read(query, null, objectName, listeChamps, null);
        }
        public List<object> read(models.query.aQuery query, string objectName, List<string> listeChamps, models.@base.listProperties context)
        {
            return read(query, null, objectName, listeChamps, context);
        }
        private List<object> read(models.query.aQuery query, System.Type objectType, string objectName, List<string> listeChamps, models.@base.listProperties context)
        {
            if (checkIfBusy())
                return null;

            return readData(query, objectType, objectName, listeChamps, context);
        }

        private List<object> readData(models.query.aQuery query, System.Type objectType, string objectName, List<string> listeChamps, models.@base.listProperties context)
        {
            Interfaces.IObject conn;
            object retour;
            List<object> listeRetour = null;
            string nomRessource = "";
            models.@base.anOpenERPObject classeInstanciee = null;
            models.@base.anOpenERPObject obj;

            if (!isConnected)
            {
                throw new Systeme.exceptionOpenERP(Systeme.exceptionOpenERP.ERRORS.NOT_CONNECTED);
            }
            if ((objectType == null)
                        && (objectName == ""))
                throw new Systeme.exceptionOpenERP(Systeme.exceptionOpenERP.ERRORS.ERR_NOMTYPE_OBJET_OPENERP);

            try
            {
                if (objectType != null)
                {
                    classeInstanciee = ((models.@base.anOpenERPObject)(Activator.CreateInstance(objectType)));
                    nomRessource = classeInstanciee.resource_name();
                }
                else
                    nomRessource = objectName;

                conn = XmlRpcProxyGen.Create<Interfaces.IObject>();
                conn.Url = url(SERVICE_XMLRPC.@object);
                if (listeChamps == null)
                    listeChamps = new List<String>();
                if (context == null)
                    retour = conn.executeTwoParam(_config.database, _config.userId, _config.password, nomRessource, "read", query.toXmlRpc, listeChamps.ToArray());
                else
                    retour = conn.executeThreeParam(_config.database, _config.userId, _config.password, nomRessource, "read", query.toXmlRpc, listeChamps.ToArray(), context.toArray());
                if (retour != null)
                {
                    listeRetour = new List<Object>();
                    for (int i = 0; (i
                                <= (((System.Array)(retour)).GetLength(0) - 1)); i++)
                    {
                        if (objectType != null)
                            obj = ((models.@base.anOpenERPObject)(Activator.CreateInstance(objectType)));
                        else
                            obj = new models.@base.aGenericObject(nomRessource);
                        obj.copyData((XmlRpcStruct)(((object[])(retour))[i]));
                        listeRetour.Add(obj);
                    }
                }
            }
            catch (Exception ex)
            {
                if ((_config.reportXmlRpcError)
                            && (ex.GetType() == typeof(XmlRpcFaultException)))
                {
                    throw new Systeme.exceptionOpenERP(Systeme.exceptionOpenERP.ERRORS.LIB_XMLRPC, ex.Message);
                }
            }
            finally
            {
                conn = null;
            }
            return listeRetour;
        }

        /// <summary>
        /// Lire un ou plusieurs objets de la base en asynchrone
        /// </summary>
        /// <param name="query">un objet requete contenant la liste des identifiants des objets à retourner/charger</param>
        /// <param name="callBack">Fonction appelée quand c'est terminé</param>
        /// <param name="objectType">Type d'objet à rechercher (partenaire, produit, ...). Facultatif sauf si nomObjet est absent.Si absent, un objet generic contenant tous les champs est retourné.</param>
        /// <param name="objectName">Type d'objet à rechercher en toute lettres comme le donne OpenERP (res.partner, product.product, ...). Facultatif sauf si typeObjet est absent.</param>
        /// <param name="prioritaire">Passe cette requete en priorité par rapport aux autres en attentes</param>
        /// <remarks></remarks>
        public void readAsync(models.query.aQuery query, System.ComponentModel.RunWorkerCompletedEventHandler callBack, System.Type objectType, string objectName, List<string> listeChamps, models.@base.listProperties context, bool prioritaire)
        {
            Hashtable param = new Hashtable();
            param.Add("query", query);
            param.Add("objectType", objectType);
            param.Add("objectName", objectName);
            param.Add("listeChamps", listeChamps);
            param.Add("context", context);
            _work.addTask(new System.ComponentModel.DoWorkEventHandler(this.readAsyncCall), callBack, param, prioritaire);
        }

        private void readAsyncCall(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            e.Result = readData((models.query.aQuery)((Hashtable)(e.Argument))["query"], (System.Type)((Hashtable)(e.Argument))["objectType"], (string)((Hashtable)(e.Argument))["objectName"], (List<string>)((Hashtable)(e.Argument))["listeChamps"], (models.@base.listProperties)((Hashtable)(e.Argument))["context"]);
        }

        /// <summary>
        /// Recherche des objets dans la base OpenERP répondant à des critères spécifiés dans l'objet 'requete'
        /// </summary>
        /// <param name="query">Objet uneRequete contenant les conditions à remplir pour la recherche</param>
        /// <param name="objectType">Type d'objet à rechercher (partenaire, produit, ...). Facultatif sauf si nomObjet est absent.Si absent, un objet generic contenant tous les champs est retourné.</param>
        /// <param name="objectName">Type d'objet à rechercher en toute lettres comme le donne OpenERP (res.partner, product.product, ...). Facultatif sauf si typeObjet est absent</param>
        /// <param name="loadObject">Indique qu'il faut charger les résultats trouvé ou non. Si non = seul les identifiants sont retournés. Si oui = tout l'objet spécifié trouvé est retourner</param>
        /// <param name="offset">A partir de combien commencons nous a renvoyer le résultat (les précédents seront exclu, ex : 10 : on commence par le 10ieme trouvé, les 9 premiers ne sont pas dans le résultat)</param>
        /// <param name="limit">Combien de résultat maximum renvoyons nous. Ex 10 : on ne retourne que 10 résultats, même si il y en a plus</param>
        /// <returns>Liste d'objet répondant aux conditions de la requete spécifiée en paramètre de cette fonction</returns>
        /// <remarks></remarks>
        public List<Object> search(models.query.aQuery query, System.Type objectType)
        {
            return searchData(query, objectType, "", false, null, 0, 0, null);
        }
        public List<Object> search(models.query.aQuery query, System.Type objectType, bool loadObject)
        {
            return searchData(query, objectType, "", loadObject, null, 0, 0, null);
        }
        public List<Object> search(models.query.aQuery query, System.Type objectType, bool loadObject, List<string> listeChamps)
        {
            return searchData(query, objectType, "", loadObject, listeChamps, 0, 0, null);
        }
        public List<Object> search(models.query.aQuery query, System.Type objectType, int offset, int limit)
        {
            return searchData(query, objectType, "", false, null, offset, limit, null);
        }
        public List<Object> search(models.query.aQuery query, System.Type objectType, bool loadObject, int offset, int limit)
        {
            return searchData(query, objectType, "", loadObject, null, offset, limit, null);
        }
        public List<Object> search(models.query.aQuery query, System.Type objectType, bool loadObject, models.@base.listProperties context)
        {
            return searchData(query, objectType, "", loadObject, null, 0, 0, context);
        }
        public List<Object> search(models.query.aQuery query, System.Type objectType, bool loadObject, List<string> listeChamps, models.@base.listProperties context)
        {
            return searchData(query, objectType, "", loadObject, listeChamps, 0, 0, context);
        }
        public List<Object> search(models.query.aQuery query, System.Type objectType, bool loadObject, List<string> listeChamps, int offset, int limit, models.@base.listProperties context)
        {
            return searchData(query, objectType, "", loadObject, listeChamps, offset, limit, context);
        }
        public List<Object> search(models.query.aQuery query, string objectName)
        {
            return searchData(query, null, objectName, false, null, 0, 0, null);
        }

        public List<Object> search(models.query.aQuery query, string objectName, bool loadObject)
        {
            return searchData(query, null, objectName, loadObject, null, 0, 0, null);
        }
        public List<Object> search(models.query.aQuery query, string objectName, bool loadObject, List<string> listeChamps)
        {
            return searchData(query, null, objectName, loadObject, listeChamps, 0, 0, null);
        }
        public List<Object> search(models.query.aQuery query, string objectName, int offset, int limit)
        {
            return searchData(query, null, objectName, false, null, offset, limit, null);
        }
        public List<Object> search(models.query.aQuery query, string objectName, bool loadObject, int offset, int limit)
        {
            return searchData(query, null, objectName, loadObject, null, offset, limit, null);
        }
        public List<Object> search(models.query.aQuery query, string objectName, bool loadObject, models.@base.listProperties context)
        {
            return searchData(query, null, objectName, loadObject, null, 0, 0, context);
        }
        public List<Object> search(models.query.aQuery query, string objectName, bool loadObject, List<string> listeChamps, models.@base.listProperties context)
        {
            return searchData(query, null, objectName, loadObject, listeChamps, 0, 0, context);
        }
        public List<Object> search(models.query.aQuery query, string objectName, bool loadObject, List<string> listeChamps, int offset, int limit, models.@base.listProperties context)
        {
            return searchData(query, null, objectName, loadObject, listeChamps, offset, limit, context);
        }
        /*public List<Object> search(models.query.aQuery query, System.Type objectType, string objectName, bool loadObject, List<string> listeChamps, int offset, int limit, models.@base.listProperties context)
        {
           if (checkIfBusy()) {
                return null;
            }
            return searchData(query, objectType, objectName, loadObject, listeChamps, offset, limit, context);
        }*/

        private List<object> searchData(models.query.aQuery query, System.Type objectType, string objectName, bool loadObject, List<string> listeChamps)
        {
            return searchData(query, objectType, objectName, loadObject, listeChamps, 0, 0, null);
        }
        private List<object> searchData(models.query.aQuery query, System.Type objectType, string objectName, bool loadObject, List<string> listeChamps, int offset, int limit, models.@base.listProperties context)
        {
            Interfaces.IObject conn;
            object retour;
            List<object> listeRetour = null;
            Array rT;
            models.@base.anOpenERPObject classeInstanciee = null;
            string nomRessource = "";
            models.query.aQuery req = null;
            if (!isConnected)
                throw new Systeme.exceptionOpenERP(Systeme.exceptionOpenERP.ERRORS.NOT_CONNECTED);

            if ((objectType == null)
                        && (objectName == ""))
                throw new Systeme.exceptionOpenERP(Systeme.exceptionOpenERP.ERRORS.ERR_NOMTYPE_OBJET_OPENERP);
            
            if (!loadObject && listeChamps != null)
                throw new Systeme.exceptionOpenERP(Systeme.exceptionOpenERP.ERRORS.MANQUE_PARAM);

            try
            {
                if (objectType != null)
                {
                    classeInstanciee = ((models.@base.anOpenERPObject)(Activator.CreateInstance(objectType)));
                    nomRessource = classeInstanciee.resource_name();
                }
                else
                    nomRessource = objectName;

                conn = XmlRpcProxyGen.Create<Interfaces.IObject>();
                conn.Url = url(SERVICE_XMLRPC.@object);
                if (query == null)
                {
                    List<int> dummyReq = new List<int>();
                    retour = conn.recherche(_config.database, _config.userId, _config.password, nomRessource, "search", dummyReq.ToArray(), offset, limit);
                }
                else
                    retour = conn.recherche(_config.database, _config.userId, _config.password, nomRessource, "search", query.toSearchXmlRpc(), offset, limit);

                if (retour != null)
                {
                    rT = ((System.Array)(retour));
                    listeRetour = new List<Object>();
                    for (int i = 0; (i
                                <= (rT.GetLength(0) - 1)); i++)
                    {
                        if (loadObject)
                        {
                            if (req == null)
                                req = new models.query.aQuery();
                            req.addParameter(rT.GetValue(i));
                        }
                        else
                            listeRetour.Add(rT.GetValue(i));
                    }
                    if (loadObject && req != null)
                        return readData(req, objectType, objectName, listeChamps, context);
                }
            }
            catch (Exception ex)
            {
                if ((_config.reportXmlRpcError)
                            && (ex.GetType() == typeof(XmlRpcFaultException)))
                    throw new Systeme.exceptionOpenERP(Systeme.exceptionOpenERP.ERRORS.LIB_XMLRPC, ex.Message);
            }
            finally
            {
                classeInstanciee = null;
                conn = null;
            }
            return listeRetour;
        }
        /// <summary>
        /// Recherche des objets dans la base OpenERP répondant à des critères spécifiés dans l'objet 'requete' en asynchrone
        /// </summary>
        /// <param name="query">Objet uneRequete contenant les conditions à remplir pour la recherche</param>
        /// <param name="callBack">Fontion appelée quand c'est terminé</param>
        /// <param name="objectType">Type d'objet à rechercher (partenaire, produit, ...). Facultatif sauf si nomObjet est absent.Si absent, un objet generic contenant tous les champs est retourné.</param>
        /// <param name="objectName">Type d'objet à rechercher en toute lettres comme le donne OpenERP (res.partner, product.product, ...). Facultatif sauf si typeObjet est absent</param>
        /// <param name="loadObject">Indique qu'il faut charger les résultats trouvé ou non. Si non = seul les identifiants sont retournés. Si oui = tout l'objet spécifié trouvé est retourner</param>
        /// <param name="offset">A partir de combien commencons nous a renvoyer le résultat (les précédents seront exclu, ex : 10 : on commence par le 10ieme trouvé, les 9 premiers ne sont pas dans le résultat)</param>
        /// <param name="limit">Combien de résultat maximum renvoyons nous. Ex 10 : on ne retourne que 10 résultats, même si il y en a plus</param>
        /// <param name="prioritaire">Passe cette requete en priorité par rapport aux autres en attentes</param>
        /// <remarks></remarks>

        public void searchAsync(models.query.aQuery query, System.ComponentModel.RunWorkerCompletedEventHandler callBack, System.Type objectType, string objectName, bool loadObject, List<string> listeChamps, int offset, int limit, models.@base.listProperties context, bool prioritaire)
        {
            Hashtable param = new Hashtable();
            param.Add("query", query);
            param.Add("objectType", objectType);
            param.Add("objectName", objectName);
            param.Add("loadObject", loadObject);
            param.Add("offset", offset);
            param.Add("limit", limit);
            param.Add("listeChamps", listeChamps);
            param.Add("context", context);
            _work.addTask(new System.ComponentModel.DoWorkEventHandler(this.searchAsyncCall), callBack, param, prioritaire);
        }

        private void searchAsyncCall(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            e.Result = searchData((models.query.aQuery)((Hashtable)(e.Argument))["query"], (System.Type)((Hashtable)(e.Argument))["objectType"], (string)((Hashtable)(e.Argument))["objectName"], (bool)((Hashtable)(e.Argument))["loadObject"], (List<string>)((Hashtable)(e.Argument))["listeChamps"], (int)((Hashtable)(e.Argument))["offset"], (int)((Hashtable)(e.Argument))["limit"], (models.@base.listProperties)((Hashtable)(e.Argument))["context"]);
        }

        /// <summary>
        /// Retourne le nb d'enregistrement trouvé correspondant aux critères de recherche demandé
        /// </summary>
        /// <param name="query">Critères de recherche</param>
        /// <param name="objectName">Type d'objet (nom OpenERP)</param>
        /// <returns>Un entier</returns>
        /// <remarks></remarks>
        public int searchCount(models.query.aQuery query, string objectName)
        {
            if (checkIfBusy())
                return 0;

            return searchCountData(query, objectName);
        }

        private int searchCountData(models.query.aQuery query, string objectName)
        {
            Interfaces.IObject conn;
            object retour;
            int nbTrouve;
            if (!isConnected)
                throw new Systeme.exceptionOpenERP(Systeme.exceptionOpenERP.ERRORS.NOT_CONNECTED);
            try
            {
                conn = XmlRpcProxyGen.Create<Interfaces.IObject>();
                conn.Url = url(SERVICE_XMLRPC.@object);
                retour = conn.execute(_config.database, _config.userId, _config.password, objectName, "search_count", query.toSearchCountXmlRpc());
                if (retour != null)
                {
                    int.TryParse((string)retour, out nbTrouve);
                    return nbTrouve;
                }
            }
            catch (Exception ex)
            {
                if ((_config.reportXmlRpcError)
                            && (ex.GetType() == typeof(XmlRpcFaultException)))
                    throw new Systeme.exceptionOpenERP(Systeme.exceptionOpenERP.ERRORS.LIB_XMLRPC, ex.Message);
                conn = null;
            }
            return 0;
        }

        /// <summary>
        /// Retourne le nb d'enregistrement trouvé correspondant aux critères de recherche demandé
        /// </summary>
        /// <param name="query">Critères de recherche</param>
        /// <param name="objectName">Type d'objet (nom OpenERP)</param>
        /// <param name="callBack">Fonction appelée quand c'est terminé</param>
        /// <param name="prioritaire">Passe cette requete en priorité par rapport aux autres en attentes</param>
        /// <remarks></remarks>
        public void searchCountAsync(models.query.aQuery query, string objectName, System.ComponentModel.RunWorkerCompletedEventHandler callBack)
        {
            searchCountAsync(query, objectName, callBack, false);
        }
        public void searchCountAsync(models.query.aQuery query, string objectName, System.ComponentModel.RunWorkerCompletedEventHandler callBack, bool prioritaire)
        {
            Hashtable param = new Hashtable();
            param.Add("query", query);
            param.Add("objectName", objectName);
            _work.addTask(new System.ComponentModel.DoWorkEventHandler(this.searchCountAsyncCall), callBack, param, prioritaire);
        }

        private void searchCountAsyncCall(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            e.Result = searchCountData((models.query.aQuery)((Hashtable)(e.Argument))["query"], (string)((Hashtable)(e.Argument))["objectName"]);
        }

        /// <summary>
        /// Créer/ajoute un objet dans la base OpenERP.
        /// </summary>
        /// <param name="objectToInsert">Objet/contenu à créer</param>
        /// <returns>l'identifiant unique de l'objet dans la base OpenERP si réussi, sinon retourne -1</returns>
        /// <remarks></remarks>
        public int insert(models.@base.anOpenERPObject objectToInsert)
        {
            return insert(objectToInsert, null);
        }
        public int insert(models.@base.anOpenERPObject objectToInsert, models.@base.listProperties complementInfo)
        {
            if (checkIfBusy())
                return 0;

            return insertData(objectToInsert, complementInfo);
        }

        private int insertData(models.@base.anOpenERPObject objectToInsert)
        {
            return insertData(objectToInsert, null);
        }
        private int insertData(models.@base.anOpenERPObject objectToInsert, models.@base.listProperties complementInfo)
        {
            Interfaces.IObject conn;
            object retour;
            string nomRessource = objectToInsert.resource_name();
            CookComputing.XmlRpc.XmlRpcStruct valeurs;
            if (!isConnected)
                throw new Systeme.exceptionOpenERP(Systeme.exceptionOpenERP.ERRORS.NOT_CONNECTED);
            if (objectToInsert == null)
                throw new Systeme.exceptionOpenERP(Systeme.exceptionOpenERP.ERRORS.MANQUE_PARAM);

            try
            {
                conn = XmlRpcProxyGen.Create<Interfaces.IObject>();
                conn.Url = url(SERVICE_XMLRPC.@object);
                valeurs = objectToInsert.toXmlRpc(false);
                if (valeurs.Contains("id"))
                    valeurs.Remove("id");
                if (complementInfo == null)
                    retour = conn.execute(_config.database, _config.userId, _config.password, nomRessource, "create", valeurs);
                else
                    retour = conn.executeTwoParam(_config.database, _config.userId, _config.password, nomRessource, "create", valeurs, complementInfo.toArray());
                return (int)retour;
            }
            catch (Exception ex)
            {
                if ((_config.reportXmlRpcError)
                            && (ex.GetType() == typeof(XmlRpcFaultException)))
                    throw new Systeme.exceptionOpenERP(Systeme.exceptionOpenERP.ERRORS.LIB_XMLRPC, ex.Message);
            }
            finally
            {
                conn = null;
            }
            return -1;
        }

        /// <summary>
        /// Créer/ajoute un objet dans la base OpenERP en asynchrone
        /// </summary>
        /// <param name="objectToInsert">Objet/contenu à créer</param>
        /// <param name="callBack">Fonction appelée quand c'est terminé</param>
        /// <param name="prioritaire">Passe cette requete en priorité par rapport aux autres en attentes</param>
        /// <remarks></remarks>
        public void insertAsync(models.@base.anOpenERPObject objectToInsert, System.ComponentModel.RunWorkerCompletedEventHandler callBack)
        {
            insertAsync(objectToInsert, callBack, null, false);
        }
        public void insertAsync(models.@base.anOpenERPObject objectToInsert, System.ComponentModel.RunWorkerCompletedEventHandler callBack, models.@base.listProperties complementInfo)
        {
            insertAsync(objectToInsert, callBack, complementInfo, false);
        }
        public void insertAsync(models.@base.anOpenERPObject objectToInsert, System.ComponentModel.RunWorkerCompletedEventHandler callBack, bool prioritaire)
        {
            insertAsync(objectToInsert, callBack, null, prioritaire);
        }
        public void insertAsync(models.@base.anOpenERPObject objectToInsert, System.ComponentModel.RunWorkerCompletedEventHandler callBack, models.@base.listProperties complementInfo, bool prioritaire)
        {
            Hashtable param = new Hashtable();
            param.Add("objectToInsert", objectToInsert);
            param.Add("complementInfo", complementInfo);
            _work.addTask(new System.ComponentModel.DoWorkEventHandler(this.insertAsyncCall), callBack, param, prioritaire);
        }

        private void insertAsyncCall(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            e.Result = insertData((models.@base.anOpenERPObject)((Hashtable)(e.Argument))["objectToInsert"], (models.@base.listProperties)((Hashtable)(e.Argument))["complementInfo"]);
        }

        /// <summary>
        /// Creer/ajoute plusieurs nouveaux objets dans la base OpenERP
        /// </summary>
        /// <param name="objectsToInsert">Liste des objets à inserer/creer</param>
        /// <returns>Liste des numéro unique des objets, dans le même ordre que la liste des objets envoyés en paramètres</returns>
        /// <remarks></remarks>
        public List<int> insert(List<models.@base.aGenericObject> objectsToInsert)
        {
            if (checkIfBusy())
                return null;

            return insertData(objectsToInsert);
        }

        private List<int> insertData(List<models.@base.aGenericObject> objectsToInsert)
        {
            List<int> retour = new List<int>();
            foreach (models.@base.aGenericObject obj in objectsToInsert)
                retour.Add(insert(obj));

            return retour;
        }

        /// <summary>
        /// Creer/ajoute plusieurs nouveaux objets dans la base OpenERP en asynchrone
        /// </summary>
        /// <param name="objectsToInsert">Liste des objets à inserer/creer</param>
        /// <param name="callBack">Fonction appelée quand c'est terminé</param>
        /// <param name="prioritaire">Passe cette requete en priorité par rapport aux autres en attentes</param>
        /// <remarks></remarks>
        public void insertAsync(List<models.@base.aGenericObject> objectsToInsert, System.ComponentModel.RunWorkerCompletedEventHandler callBack)
        {
            insertAsync(objectsToInsert, callBack, false);
        }
        public void insertAsync(List<models.@base.aGenericObject> objectsToInsert, System.ComponentModel.RunWorkerCompletedEventHandler callBack, bool prioritaire)
        {
            Hashtable param = new Hashtable();
            param.Add("objectsToInsert", objectsToInsert);
            _work.addTask(new System.ComponentModel.DoWorkEventHandler(this.multipleInsertAsyncCall), callBack, param, prioritaire);
        }

        private void multipleInsertAsyncCall(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            e.Result = insertData((List<models.@base.aGenericObject>)((Hashtable)(e.Argument))["objectsToInsert"]);
        }

        /// <summary>
        /// Efface un/des objets de la base OpenERP. Soit par l'objet, soit par numéro envoyé en chaine.
        /// </summary>
        /// <param name="objectToDelete">Facultatif : Objet/contenu à effacer</param>
        /// <param name="objectName">Facultatif : nom, OpenERP, de la ressource (ex : res.partner)</param>
        /// <param name="objectType">Facultatif : nom de la classe dotNET de la ressource</param>
        /// <param name="query">Facultatif sauf si objet est absent : liste, séparée par des virgules, des numéro unique à supprimer</param>
        /// <returns>True si réussi (ou rien à faire car numéro unique inexistant), sinon False</returns>
        /// <remarks>Parmis les paramètres : objet, nomObjet, typeObjet. Il en faut un et uniquement un seul de ces 3 la.</remarks>
        public bool delete(System.Type objectType, ArrayList query)
        {
            return delete(null, "", objectType, query);
        }
        public bool delete(string objectName, ArrayList query)
        {
            return delete(null, objectName, null, query);
        }
        public bool delete(models.@base.anOpenERPObject objectToDelete)
        {
            return delete(objectToDelete, "", null, null);
        }
        public bool delete(models.@base.anOpenERPObject objectToDelete, string objectName, System.Type objectType, ArrayList query)
        {
            if (checkIfBusy())
                return false;

            return deleteData(objectToDelete, objectName, objectType, query);
        }

        private bool deleteData(models.@base.anOpenERPObject objectToDelete, string objectName, System.Type objectType, ArrayList query)
        {
            Interfaces.IObject conn;
            object retour;
            string nomRessource = "";
            models.@base.anOpenERPObject classeInstanciee;
            if (!isConnected)
                throw new Systeme.exceptionOpenERP(Systeme.exceptionOpenERP.ERRORS.NOT_CONNECTED);
            if ((objectType == null)
                        && (objectName == "")
                        && (objectToDelete == null))
                throw new Systeme.exceptionOpenERP(Systeme.exceptionOpenERP.ERRORS.ERR_NOMTYPE_OBJET_OPENERP);

            if ((query == null)
                        && (objectToDelete == null))
                throw new Systeme.exceptionOpenERP(Systeme.exceptionOpenERP.ERRORS.MANQUE_PARAM, @"query ne peut pas être vide si l'objet' est vide également");

            try
            {
                conn = XmlRpcProxyGen.Create<Interfaces.IObject>();
                conn.Url = url(SERVICE_XMLRPC.@object);
                if (objectToDelete != null)
                {
                    nomRessource = objectToDelete.resource_name();
                    query = new ArrayList();
                    query.Add((objectToDelete.listProperties.value("id")).ToString());
                }
                else if (objectType != null)
                {
                    classeInstanciee = ((models.@base.anOpenERPObject)(Activator.CreateInstance(objectType)));
                    nomRessource = classeInstanciee.resource_name();
                }
                else
                    nomRessource = objectName;

                retour = conn.execute(_config.database, _config.userId, _config.password, nomRessource, "unlink", query.ToArray());
                return true;
            }
            catch (Exception ex)
            {
                if ((_config.reportXmlRpcError)
                            && (ex.GetType() == typeof(XmlRpcFaultException)))
                    throw new Systeme.exceptionOpenERP(Systeme.exceptionOpenERP.ERRORS.LIB_XMLRPC, ex.Message);
            }
            finally
            {
                conn = null;
                classeInstanciee = null;
            }
            return false;
        }

        /// <summary>
        /// Efface un/des objets de la base OpenERP. Soit par l'objet, soit par numéro envoyé en chaine en asynchrone
        /// </summary>
        /// <param name="callBack">Fonction appelée quand c'est terminé</param>
        /// <param name="objectToDelete">Facultatif : Objet/contenu à effacer</param>
        /// <param name="objectName">Facultatif : nom, OpenERP, de la ressource (ex : res.partner)</param>
        /// <param name="objectType">Facultatif : nom de la classe dotNET de la ressource</param>
        /// <param name="query">Facultatif sauf si objet est absent : liste, séparée par des virgules, des numéro unique à supprimer</param>
        /// <param name="prioritaire">Passe cette requete en priorité par rapport aux autres en attentes</param>
        /// <remarks>Parmis les paramêtres : objet, nomObjet, typeObjet. Il en faut un et uniquement un seul de ces 3 la.</remarks>
        public void deleteAsync(System.ComponentModel.RunWorkerCompletedEventHandler callBack, models.@base.anOpenERPObject objectToDelete, bool prioritaire)
        {
            deleteAsync(callBack, objectToDelete, "", null, null, prioritaire);
        }
        public void deleteAsync(System.ComponentModel.RunWorkerCompletedEventHandler callBack, models.@base.anOpenERPObject objectToDelete)
        {
            deleteAsync(callBack, objectToDelete, "", null, null);
        }
        public void deleteAsync(System.ComponentModel.RunWorkerCompletedEventHandler callBack, string objectName, ArrayList query, bool prioritaire)
        {
            deleteAsync(callBack, null, objectName, null, query, prioritaire);
        }
        public void deleteAsync(System.ComponentModel.RunWorkerCompletedEventHandler callBack, string objectName, ArrayList query)
        {
            deleteAsync(callBack, null, objectName, null, query);
        }
        public void deleteAsync(System.ComponentModel.RunWorkerCompletedEventHandler callBack, System.Type objectType, ArrayList query)
        {
            deleteAsync(callBack, null, "", objectType, query);
        }
        public void deleteAsync(System.ComponentModel.RunWorkerCompletedEventHandler callBack, System.Type objectType, ArrayList query, bool prioritaire)
        {
            deleteAsync(callBack, null, "", objectType, query, prioritaire);
        }
        public void deleteAsync(System.ComponentModel.RunWorkerCompletedEventHandler callBack, models.@base.anOpenERPObject objectToDelete, string objectName, System.Type objectType, ArrayList query)
        {
            deleteAsync(callBack, objectToDelete, objectName, objectType, query);
        }
        public void deleteAsync(System.ComponentModel.RunWorkerCompletedEventHandler callBack, models.@base.anOpenERPObject objectToDelete, string objectName, System.Type objectType, ArrayList query, bool prioritaire)
        {
            Hashtable param = new Hashtable();
            param.Add("objectToDelete", objectToDelete);
            param.Add("objectName", objectName);
            param.Add("objectType", objectType);
            param.Add("query", query);
            _work.addTask(new System.ComponentModel.DoWorkEventHandler(this.deleteAsyncCall), callBack, param, prioritaire);
        }

        private void deleteAsyncCall(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            e.Result = deleteData((models.@base.anOpenERPObject)((Hashtable)(e.Argument))["objectToDelete"], (string)((Hashtable)(e.Argument))["objectName"], (System.Type)((Hashtable)(e.Argument))["objectType"], (ArrayList)((Hashtable)(e.Argument))["query"]);
        }

        /// <summary>
        /// Ecrire/met à jour un enregistrement (un objet) déjà existant dans la base OpenERP
        /// </summary>
        /// <param name="objectToUpdate">l'objet à mettre à jour (contenant les propriétés à modifier uniquement)</param>
        /// <returns>True si réussi, sinon False</returns>
        /// <remarks></remarks>
        public bool update(models.@base.anOpenERPObject objectToUpdate)
        {
            return update(objectToUpdate, null);
        }
        public bool update(models.@base.anOpenERPObject objectToUpdate, models.@base.listProperties complement)
        {
            if (checkIfBusy())
                return false;

            return updateData(objectToUpdate, complement);
        }

        /// <summary>
        /// Mettre à jour certains champs d'un objet OpenERP existant
        /// </summary>
        /// <param name="listeChamps">Liste des champs (et leurs nouvelles valeurs) à modifier</param>
        /// <param name="objectType">Nom/Type d'objet OpenERP</param>
        /// <param name="id">Id de l'objet à mettre à jour</param>
        /// <returns>True si réussi, sinon False</returns>
        /// <remarks></remarks>
        public bool update(models.@base.listProperties listeChamps, System.Type objectType, models.@base.listProperties context)
        {
            return update(listeChamps, objectType, 0, context);
        }
        public bool update(models.@base.listProperties listeChamps, System.Type objectType, int id)
        {
            return update(listeChamps, objectType, id, null);
        }
        public bool update(models.@base.listProperties listeChamps, System.Type objectType)
        {
            return update(listeChamps, objectType, 0, null);
        }
        public bool update(models.@base.listProperties listeChamps, System.Type objectType, int id, models.@base.listProperties context)
        {
            if (checkIfBusy())
                return false;

            models.@base.anOpenERPObject classeInstanciee = null;
            classeInstanciee = ((models.@base.anOpenERPObject)(Activator.CreateInstance(objectType)));
            classeInstanciee.listProperties = listeChamps;
            if ((id > 0) && !classeInstanciee.listProperties.Contains("id"))
                classeInstanciee.listProperties.add("id", id);

            return updateData(classeInstanciee, context);
        }

        private bool updateData(models.@base.anOpenERPObject objectToUpdate)
        {
            return updateData(objectToUpdate, null);
        }
        private bool updateData(models.@base.anOpenERPObject objectToUpdate, models.@base.listProperties complement)
        {
            object retour;
            Interfaces.IObject conn;
            List<int> listeId = new List<int>();
            CookComputing.XmlRpc.XmlRpcStruct valeurs;
            if (objectToUpdate == null)
                throw new Systeme.exceptionOpenERP(Systeme.exceptionOpenERP.ERRORS.MANQUE_PARAM, "classe est vide, op�ration impossible.");

            if (!isConnected)
                throw new Systeme.exceptionOpenERP(Systeme.exceptionOpenERP.ERRORS.NOT_CONNECTED);

            try
            {
                conn = XmlRpcProxyGen.Create<Interfaces.IObject>();
                conn.Url = url(SERVICE_XMLRPC.@object);
                valeurs = objectToUpdate.toXmlRpc(false);
                listeId.Add((int)objectToUpdate.listProperties.value("id"));
                if (complement == null)
                    retour = conn.executeTwoParam(_config.database, _config.userId, _config.password, objectToUpdate.resource_name(), "write", listeId.ToArray(), valeurs);
                else
                    retour = conn.executeThreeParam(_config.database, _config.userId, _config.password, objectToUpdate.resource_name(), "write", listeId.ToArray(), valeurs, complement.toArray());
                return true;
            }
            catch (Exception ex)
            {
                if ((_config.reportXmlRpcError) && (ex.GetType() == typeof(XmlRpcFaultException)))
                    throw new Systeme.exceptionOpenERP(Systeme.exceptionOpenERP.ERRORS.LIB_XMLRPC, ex.Message);
            }
            finally
            {
                conn = null;
            }
            return false;
        }

        /// <summary>
        /// Ecrire/met à jour un enregistrement (un objet) déjà existant dans la base OpenERP en asynchrone
        /// </summary>
        /// <param name="objectToUpdate">l'objet à mettre à jour (contenant les propriétés à modifier uniquement)</param>
        /// <param name="callBack">Fonction appelée quand c'est terminé</param>
        /// <param name="prioritaire">Passe cette requête en priorité par rapport aux autres en attentes</param>
        /// <remarks></remarks>
        public void updateAsync(models.@base.anOpenERPObject objectToUpdate, System.ComponentModel.RunWorkerCompletedEventHandler callBack)
        {
            updateAsync(objectToUpdate, callBack, null, false);
        }
        public void updateAsync(models.@base.anOpenERPObject objectToUpdate, System.ComponentModel.RunWorkerCompletedEventHandler callBack, models.@base.listProperties complement)
        {
            updateAsync(objectToUpdate, callBack, complement, false);
        }
        public void updateAsync(models.@base.anOpenERPObject objectToUpdate, System.ComponentModel.RunWorkerCompletedEventHandler callBack, bool prioritaire)
        {
            updateAsync(objectToUpdate, callBack, null, prioritaire);
        }
        public void updateAsync(models.@base.anOpenERPObject objectToUpdate, System.ComponentModel.RunWorkerCompletedEventHandler callBack, models.@base.listProperties complement, bool prioritaire)
        {
            Hashtable param = new Hashtable();
            param.Add("objectToUpdate", objectToUpdate);
            param.Add("complement", complement);
            _work.addTask(new System.ComponentModel.DoWorkEventHandler(this.updateAsyncCall), callBack, param, prioritaire);
        }

        /// <summary>
        /// Mettre à jour seulement certains champs d'un objet OpenERP
        /// </summary>
        /// <param name="listeChamps">Liste des champs (et leurs valeurs) à modifier</param>
        /// <param name="objectName">Type/Nom d'objet OpenERP</param>
        /// <param name="callBack">Fonction appelée quand c'est terminé</param>
        /// <param name="id">Id de l'objet à mettre à jour</param>
        /// <param name="prioritaire">Passe cette requête en priorité par rapport aux autres en attentes</param>
        /// <remarks></remarks>
        public void updateAsync(models.@base.listProperties listeChamps, string objectName, System.ComponentModel.RunWorkerCompletedEventHandler callBack, int id, models.@base.listProperties complement, bool prioritaire)
        {
            models.@base.aGenericObject objectToUpdate = new models.@base.aGenericObject(objectName);
            objectToUpdate.listProperties = listeChamps;
            if (id > 0)
                objectToUpdate.listProperties.add("id", id);
            updateAsync(objectToUpdate, callBack, complement, prioritaire);
        }

        /// <summary>
        /// Ecrire/update plusieurs objets à la fois en asynchronee
        /// </summary>
        /// <param name="objectsToUpdate">Liste d'objet, generic ou non, à écrire</param>
        /// <param name="callBack">Fonction appelée quand c'est terminé</param>
        /// <param name="prioritaire">Passe cette requete en priorité par rapport aux autres en attentes</param>
        /// <remarks></remarks>
        public void updateAsync(List<models.@base.anOpenERPObject> objectsToUpdate, System.ComponentModel.RunWorkerCompletedEventHandler callBack, models.@base.listProperties complement, bool prioritaire)
        {
            Hashtable param = new Hashtable();
            param.Add("objectsToUpdate", objectsToUpdate);
            param.Add("complement", complement);
            _work.addTask(new System.ComponentModel.DoWorkEventHandler(this.multipleUpdateAsyncCall), callBack, param, prioritaire);
        }

        private void updateAsyncCall(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            e.Result = updateData((models.@base.anOpenERPObject)((Hashtable)(e.Argument))["objectToUpdate"], (models.@base.listProperties)((Hashtable)(e.Argument))["complement"]);
        }

        /// <summary>
        /// Ecrire/update plusieurs objets à la fois
        /// </summary>
        /// <param name="objectsToUpdate">Liste d'objet, generic ou non, à écrire</param>
        /// <returns>True si réussi, sinon False</returns>
        /// <remarks></remarks>
        public bool update(List<models.@base.anOpenERPObject> objectsToUpdate, models.@base.listProperties complement)
        {
            if (checkIfBusy())
                return false;

            return updateMultipleData(objectsToUpdate, complement);
        }

        private bool updateMultipleData(List<models.@base.anOpenERPObject> objectsToUpdate, models.@base.listProperties complement)
        {
            if (objectsToUpdate == null)
                throw new Systeme.exceptionOpenERP(Systeme.exceptionOpenERP.ERRORS.MANQUE_PARAM, "Ne peut être vide");
            foreach (models.@base.anOpenERPObject objet in objectsToUpdate)
                if (!update(objet, complement))
                    return false;
            return true;
        }

        private void multipleUpdateAsyncCall(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            e.Result = updateMultipleData((List<models.@base.anOpenERPObject>)((Hashtable)(e.Argument))["objectsToUpdate"], (models.@base.listProperties)((Hashtable)(e.Argument))["complement"]);
        }

        /// <summary>
        /// Retourne la(les?) companie(s) de cet utilisateur
        /// </summary>
        /// <returns>Liste d'objet uneCle contenant juste un numéro identifiant numérique et un libellé</returns>
        /// <remarks></remarks>
        public List<models.@base.aKey> getCurrentCompany()
        {
            if (checkIfBusy())
                return null;

            return getCurrentCompanyData();
        }

        /// <summary>
        /// Retourne la(les?) companie(s) de cet utilisateur en asynchrone
        /// </summary>
        /// <param name="callBack">Fonction appelée quand c'est terminé</param>
        /// <param name="prioritaire">Passe cette requete en priorité par rapport aux autres en attentes</param>
        /// <remarks></remarks>
        public void getCurrentCompanyAsync(System.ComponentModel.RunWorkerCompletedEventHandler callBack)
        {
            getCurrentCompanyAsync(callBack, false);
        }
        public void getCurrentCompanyAsync(System.ComponentModel.RunWorkerCompletedEventHandler callBack, bool prioritaire)
        {
            _work.addTask(new System.ComponentModel.DoWorkEventHandler(this.getCurrentCompanyAsyncCall), callBack, null, prioritaire);
        }

        private void getCurrentCompanyAsyncCall(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            e.Result = getCurrentCompanyData();
        }

        private List<models.@base.aKey> getCurrentCompanyData()
        {
            Interfaces.IObject conn;
            Array retour;
            List<models.@base.aKey> ret = null;
            models.@base.aKey cle;
            if (!isConnected)
                throw new Systeme.exceptionOpenERP(Systeme.exceptionOpenERP.ERRORS.NOT_CONNECTED);

            try
            {
                conn = XmlRpcProxyGen.Create<Interfaces.IObject>();
                conn.Url = url(SERVICE_XMLRPC.@object);
                retour = (System.Array)conn.executeWithoutParam(_config.database, _config.userId, _config.password, "res.users", "get_current_company");
                if (retour != null)
                {
                    ret = new List<models.@base.aKey>();
                    for (int i = 0; (i <= (retour.GetLength(0) - 1)); i++)
                    {
                        cle = new models.@base.aKey();
                        cle.id = (int)((System.Array)(retour.GetValue(i))).GetValue(0);
                        cle.name = (string)((System.Array)(retour.GetValue(i))).GetValue(1);
                        ret.Add(cle);
                    }
                }
            }
            catch (Exception ex)
            {
                if ((_config.reportXmlRpcError) && (ex.GetType() == typeof(XmlRpcFaultException)))
                    throw new Systeme.exceptionOpenERP(Systeme.exceptionOpenERP.ERRORS.LIB_XMLRPC, ex.Message);
            }
            finally
            {
                conn = null;
            }
            return ret;
        }

        /// <summary>
        /// Retourne la liste des champs d'une ressource (d'un objet OpenERP)
        /// </summary>
        /// <param name="resourceName">Nom de la ressource, de l'objet</param>
        /// <param name="department_id">NON DOCUMENTE</param>
        /// <param name="lang">Langue utilisée pour les libellés des champs</param>
        /// <param name="project_id">NON DOCUMENTE</param>
        /// <param name="section_id">NON DOCUMENTE</param>
        /// <param name="tz">NON DOCUMENTE</param>
        /// <returns>Une liste d'objet aField contenant toutes les infos de chaque champs</returns>
        /// <remarks></remarks>
        public List<models.@base.aField> getFieldsList(string resourceName)
        {
            return getFieldsList(resourceName, "", false, false, false, false);
        }
        public List<models.@base.aField> getFieldsList(string resourceName, string lang, object department_id, object project_id, object section_id, object tz)
        {
            if (checkIfBusy())
                return null;

            return getFieldsListData(resourceName, lang, department_id, project_id, section_id, tz);
        }

        /// <summary>
        /// Retourne la liste des champs d'une ressource (d'un objet OpenERP) en asynchrone
        /// </summary>
        /// <param name="resourceName">Nom de la ressource, de l'objet</param>
        /// <param name="callBack">Fonction appelée quand c'est terminé</param>
        /// <param name="department_id">NON DOCUMENTE</param>
        /// <param name="lang">Langue utilisée pour les libellés des champs</param>
        /// <param name="project_id">NON DOCUMENTE</param>
        /// <param name="section_id">NON DOCUMENTE</param>
        /// <param name="tz">NON DOCUMENTE</param>
        /// <param name="prioritaire">Passe cette requete en priorité par rapport aux autres en attentes</param>
        /// <remarks></remarks>
        public void getFieldsListAsync(System.ComponentModel.RunWorkerCompletedEventHandler callBack, string resourceName, bool prioritaire)
        {
            getFieldsListAsync(callBack, resourceName, "", false, false, false, false, prioritaire);
        }
        public void getFieldsListAsync(System.ComponentModel.RunWorkerCompletedEventHandler callBack, string resourceName)
        {
            getFieldsListAsync(callBack, resourceName, "", false, false, false, false, false);
        }
        public void getFieldsListAsync(System.ComponentModel.RunWorkerCompletedEventHandler callBack, string resourceName, string lang, object department_id, object project_id, object section_id, object tz, bool prioritaire)
        {
            Hashtable param = new Hashtable();
            param.Add("resourceName", resourceName);
            param.Add("lang", lang);
            param.Add("department_id", department_id);
            param.Add("project_id", project_id);
            param.Add("section_id", section_id);
            param.Add("tz", tz);
            _work.addTask(new System.ComponentModel.DoWorkEventHandler(this.getFieldsListAsyncCall), callBack, param, prioritaire);
        }

        private void getFieldsListAsyncCall(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            e.Result = getFieldsListData((string)((Hashtable)(e.Argument))["resourceName"], (string)((Hashtable)(e.Argument))["lang"], ((Hashtable)(e.Argument))["department_id"], ((Hashtable)(e.Argument))["project_id"], ((Hashtable)(e.Argument))["section_id"], ((Hashtable)(e.Argument))["tz"]);
        }

        private List<models.@base.aField> getFieldsListData(string resourceName, string lang, object department_id, object project_id, object section_id, object tz)
        {
            Interfaces.IObject conn;
            XmlRpcStruct retour;
            List<models.@base.aField> ret = new List<models.@base.aField>();
            IEnumerator boucle;
            models.@base.aField f;
            XmlRpcStruct param = new XmlRpcStruct();
            if (!isConnected)
                throw new Systeme.exceptionOpenERP(Systeme.exceptionOpenERP.ERRORS.NOT_CONNECTED);

            try
            {
                conn = XmlRpcProxyGen.Create<Interfaces.IObject>();
                conn.Url = url(SERVICE_XMLRPC.@object);
                if ((lang == "") && (_config.defaultLanguage == ""))
                    retour = (XmlRpcStruct)conn.executeWithoutParam(_config.database, _config.userId, _config.password, resourceName, "fields_get");
                else
                {
                    if (lang == "")
                        lang = _config.defaultLanguage;
                    param.Add("department_id", department_id);
                    param.Add("lang", lang);
                    param.Add("project_id", project_id);
                    param.Add("section_id", section_id);
                    param.Add("tz", tz);
                    retour = (XmlRpcStruct)conn.executeTwoParam(_config.database, _config.userId, _config.password, resourceName, "fields_get", false, param);
                }
                boucle = retour.GetEnumerator();
                while (boucle.MoveNext())
                {
                    f = new models.@base.aField();
                    f.treatment((string)((DictionaryEntry)(boucle.Current)).Key, (XmlRpcStruct)((DictionaryEntry)(boucle.Current)).Value);
                    ret.Add(f);
                }
            }
            catch (Exception ex)
            {
                if (_config.reportXmlRpcError)
                    throw new Systeme.exceptionOpenERP(Systeme.exceptionOpenERP.ERRORS.LIB_XMLRPC, ex.Message);
            }
            finally
            {
                conn = null;
            }
            return ret;
        }

        /// <summary>
        /// Retourne le libellé d'une ressource, dans la langue voulu.
        /// </summary>
        /// <param name="resourceName">Nom de la ressource</param>
        /// <param name="id">Identifiant de l'enregistrement</param>
        /// <param name="lang">Code langue du libellé</param>
        /// <param name="section_id">NON DOCUMENTE</param>
        /// <param name="tz">NON DOCUMENTE</param>
        /// <returns>Une chaine, texte, contenant le libellé de cet enregistrement de cette ressource, dans la langue demandée</returns>
        /// <remarks></remarks>
        public string getName(string resourceName, int id, string lang)
        {
            return getName(resourceName, id, lang, false, false);
        }
        public string getName(string resourceName, int id, string lang, object section_id, object tz)
        {
            if (checkIfBusy())
                return null;

            return getNameData(resourceName, id, lang, section_id, tz);
        }

        /// <summary>
        /// Retourne le libellé d'une ressource, dans la langue voulu en asynchrone
        /// </summary>
        /// <param name="resourceName">Nom de la ressource</param>
        /// <param name="id">Identifiant de l'enregistrement</param>
        /// <param name="lang">Code langue du libellé</param>
        /// <param name="section_id">NON DOCUMENTE</param>
        /// <param name="tz">NON DOCUMENTE</param>
        /// <param name="callBack">Fonction appelée quand c'est terminé</param>
        /// <param name="prioritaire">Passe cette requete en priorité par rapport aux autres en attentes</param>
        /// <remarks></remarks>
        public void getNameAsync(System.ComponentModel.RunWorkerCompletedEventHandler callBack, string resourceName, int id, string lang)
        {
            getNameAsync(callBack, resourceName, id, "", false, false, false);
        }
        public void getNameAsync(System.ComponentModel.RunWorkerCompletedEventHandler callBack, string resourceName, int id, string lang, bool prioritaire)
        {
            getNameAsync(callBack, resourceName, id, "", false, false, prioritaire);
        }
        public void getNameAsync(System.ComponentModel.RunWorkerCompletedEventHandler callBack, string resourceName, int id, string lang, object section_id, object tz, bool prioritaire)
        {
            Hashtable param = new Hashtable();
            param.Add("resourceName", resourceName);
            param.Add("id", id);
            param.Add("lang", lang);
            param.Add("section_id", section_id);
            param.Add("tz", tz);
            _work.addTask(new System.ComponentModel.DoWorkEventHandler(this.getNameAsyncCall), callBack, param, prioritaire);
        }

        private void getNameAsyncCall(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            e.Result = getNameData((string)((Hashtable)(e.Argument))["resourceName"], (int)((Hashtable)(e.Argument))["id"], (string)((Hashtable)(e.Argument))["lang"], ((Hashtable)(e.Argument))["section_id"], ((Hashtable)(e.Argument))["tz"]);
        }

        private string getNameData(string resourceName, int id, string lang, object section_id, object tz)
        {
            Interfaces.IObject conn;
            Array retour;
            XmlRpcStruct secondParam = new XmlRpcStruct();
            if ((lang == "") && (_config.defaultLanguage == ""))
                throw new Systeme.exceptionOpenERP(Systeme.exceptionOpenERP.ERRORS.MANQUE_PARAM, "default language not set");
            if (!isConnected)
                throw new Systeme.exceptionOpenERP(Systeme.exceptionOpenERP.ERRORS.NOT_CONNECTED);
            try
            {
                conn = XmlRpcProxyGen.Create<Interfaces.IObject>();
                conn.Url = url(SERVICE_XMLRPC.@object);
                if (lang == "")
                    lang = _config.defaultLanguage;
                secondParam.Add("lang", lang);
                secondParam.Add("section_id", section_id);
                secondParam.Add("tz", tz);
                retour = (Array)conn.executeTwoParam(_config.database, _config.userId, _config.password, resourceName, "name_get", id, secondParam);
                return (string)((System.Array)(retour.GetValue(0))).GetValue(1);
            }
            catch (Exception ex)
            {
                if ((_config.reportXmlRpcError) && (ex.GetType() == typeof(XmlRpcFaultException)))
                    throw new Systeme.exceptionOpenERP(Systeme.exceptionOpenERP.ERRORS.LIB_XMLRPC, ex.Message);
            }
            finally
            {
                conn = null;
            }
            return "";
        }

        /// <summary>
        /// Recherche des ensembles d'un objet OpenERP. Exemple : liste tous les pays (libellé et code) pour affichage en liste déroulante
        /// </summary>
        /// <param name="resourceName">Nom de l'objet OpenERP</param>
        /// <param name="query">Conditions de filtres. NON DOCUMENTES. RECHERCHE EN COURS. Optional pour l'instant</param>
        /// <returns>Une liste d'objet aKey contenant le code et le libellé de chaque objet trouvé</returns>
        /// <remarks></remarks>
        public List<models.@base.aKey> searchName(string resourceName)
        {
            return searchName(resourceName, null);
        }
        public List<models.@base.aKey> searchName(string resourceName, models.query.aQuery query)
        {
            if (checkIfBusy())
                return null;

            return searchNameData(resourceName, query);
        }

        /// <summary>
        /// Recherche des ensembles d'un objet OpenERP. Exemple : liste tous les pays (libellé et code) pour affichage en liste déroulante
        /// </summary>
        /// <param name="resourceName">Nom de l'objet OpenERP</param>
        /// <param name="query">Conditions de filtres. NON DOCUMENTES. RECHERCHE EN COURS</param>
        /// <param name="callBack">Fonction appelée quand c'est terminé</param>
        /// <param name="prioritaire">Passe cette requete en priorité par rapport aux autres en attentes</param>
        /// <remarks></remarks>
        public void searchNameAsync(string resourceName, System.ComponentModel.RunWorkerCompletedEventHandler callBack)
        {
            searchNameAsync(resourceName, callBack, null, false);
        }
        public void searchNameAsync(string resourceName, System.ComponentModel.RunWorkerCompletedEventHandler callBack, bool prioritaire)
        {
            searchNameAsync(resourceName, callBack, null, prioritaire);
        }
        public void searchNameAsync(string resourceName, System.ComponentModel.RunWorkerCompletedEventHandler callBack, models.query.aQuery query, bool prioritaire)
        {
            Hashtable param = new Hashtable();
            param.Add("resourceName", resourceName);
            param.Add("query", query);
            _work.addTask(new System.ComponentModel.DoWorkEventHandler(this.searchNameAsyncCall), callBack, param, prioritaire);
        }

        private void searchNameAsyncCall(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            e.Result = searchNameData((string)((Hashtable)(e.Argument))["resourceName"], (models.query.aQuery)((Hashtable)(e.Argument))["query"]);
        }

        private List<models.@base.aKey> searchNameData(string resourceName, models.query.aQuery query)
        {
            Interfaces.IObject conn;
            List<models.@base.aKey> retour = null;
            Array ret;
            models.@base.aKey k;
            if (!isConnected)
                throw new Systeme.exceptionOpenERP(Systeme.exceptionOpenERP.ERRORS.NOT_CONNECTED);

            try
            {
                conn = XmlRpcProxyGen.Create<Interfaces.IObject>();
                conn.Url = url(SERVICE_XMLRPC.@object);
                //  TODO : Gestion de la requete envoyée en param de cette fonction
                ret = (Array)conn.executeFourParam(_config.database, _config.userId, _config.password, resourceName, "name_search", "", "", "ilike", query);
                if (ret != null)
                {
                    retour = new List<models.@base.aKey>();
                    for (int i = 0; (i <= (ret.GetLength(0) - 1)); i++)
                    {
                        k = new models.@base.aKey();
                        k.id = (int)((System.Array)(ret.GetValue(i))).GetValue(0);
                        k.name = (string)((System.Array)(ret.GetValue(i))).GetValue(1);
                        retour.Add(k);
                    }
                }
            }
            catch (Exception ex)
            {
                if ((_config.reportXmlRpcError) && (ex.GetType() == typeof(XmlRpcFaultException)))
                    throw new Systeme.exceptionOpenERP(Systeme.exceptionOpenERP.ERRORS.LIB_XMLRPC, ex.Message);
            }
            finally
            {
                conn = null;
            }
            return retour;
        }

        public List<models.common.res_lang> translatableLang()
        {
            return translatableLang(null);
        }
        public List<models.common.res_lang> translatableLang(List<string> listeChamps)
        {
            if (checkIfBusy())
                return null;

            return translatableLangData(listeChamps);
        }

        private List<models.common.res_lang> translatableLangData(List<string> listeChamps)
        {
            object retour;
            if (!isConnected)
                throw new Systeme.exceptionOpenERP(Systeme.exceptionOpenERP.ERRORS.NOT_CONNECTED);

            if (listeChamps == null)
            {
                listeChamps = new List<String>();
                listeChamps.Add("code");
                listeChamps.Add("name");
            }
            retour = searchData(new models.query.aQuery("translatable", "1"), typeof(models.common.res_lang), "", true, listeChamps);
            return (List<models.common.res_lang>)retour;
        }

        public void translatableLangASync(System.ComponentModel.RunWorkerCompletedEventHandler callBack, bool prioritaire)
        {
            translatableLangASync(callBack, null, prioritaire);
        }
        public void translatableLangASync(System.ComponentModel.RunWorkerCompletedEventHandler callBack, List<string> listeChamps)
        {
            translatableLangASync(callBack, listeChamps, false);
        }
        public void translatableLangASync(System.ComponentModel.RunWorkerCompletedEventHandler callBack)
        {
            translatableLangASync(callBack, null, false);
        }
        public void translatableLangASync(System.ComponentModel.RunWorkerCompletedEventHandler callBack, List<string> listeChamps, bool prioritaire)
        {
            Hashtable param = new Hashtable();
            param.Add("listeChamps", listeChamps);
            _work.addTask(new System.ComponentModel.DoWorkEventHandler(this.translatableLangASyncCall), callBack, param, prioritaire);
        }

        private void translatableLangASyncCall(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            e.Result = translatableLangData((List<string>)((Hashtable)(e.Argument))["listeChamps"]);
        }
    }
}
