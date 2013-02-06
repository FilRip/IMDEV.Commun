using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using CookComputing.XmlRpc;

namespace IMDEV.OpenERP.Clients
{
    public class clientReport : clientObjects
    {

        private const int DEFAULT_MAX_TIMEOUT = 10;

        /// <summary>
        /// Prépare/Génère, coté serveur, des rapports. Que l'on peut ensuite récupérer/lire avec la fonction getReport
        /// </summary>
        /// <param name="resourceName">Nom OpenERP de l'objet</param>
        /// <param name="id">Identifiant des objets à utiliser pour la génération du rapport</param>
        /// <param name="model">Contient des informations sur le rapport en lui même</param>
        /// <returns>Liste d'identifiant de rapport (requis pour la fonction getReport)</returns>
        /// <remarks></remarks>
        public int generateReport(string resourceName, ArrayList id, models.query.aQueryReport model)
        {
            if (checkIfBusy())
            {
                return 0;
            }
            return generateReportData(resourceName, id, model);
        }

        private int generateReportData(string resourceName, ArrayList id, models.query.aQueryReport model)
        {
            Interfaces.Ireport conn;
            object retour;
            int numGen;
            if (!isConnected)
            {
                throw new Systeme.exceptionOpenERP(Systeme.exceptionOpenERP.ERRORS.NOT_CONNECTED);
            }
            if (((resourceName == "")
                        || (((id == null)
                        || (id.Count == 0))
                        || (model == null))))
            {
                throw new ArgumentNullException();
            }
            try
            {
                conn = XmlRpcProxyGen.Create<Interfaces.Ireport>();
                conn.Url = url(SERVICE_XMLRPC.report);
                retour = conn.report(_config.database, _config.userId, _config.password, resourceName, id.ToArray(), model.toXmlRpc(true));
                if (int.TryParse((string)retour, out numGen))
                {
                    return numGen;
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
            return 0;
        }

        /// <summary>
        /// Prépare/Génère, coté serveur, des rapports. Que l'on peut ensuite récupérer/lire avec la fonction getReport. De facon asynchrone.
        /// </summary>
        /// <param name="resourceName">Nom OpenERP de l'objet</param>
        /// <param name="id">Identifiant des objets à utiliser pour la génération du rapport</param>
        /// <param name="model">Contient des informations sur le rapport en lui même</param>
        /// <param name="callBack">Fonction appelée quand c'est terminé</param>
        /// <param name="prioritaire">Indique que cette tâche passe en priorité par rapport aux autres en attente si il y en a</param>
        /// <remarks></remarks>
        public void generateReportAsync(string resourceName, ArrayList id, models.query.aQueryReport model, System.ComponentModel.RunWorkerCompletedEventHandler callBack)
        {
            generateReportAsync(resourceName, id, model, callBack, false);
        }
        public void generateReportAsync(string resourceName, ArrayList id, models.query.aQueryReport model, System.ComponentModel.RunWorkerCompletedEventHandler callBack, bool prioritaire)
        {
            Hashtable param = new Hashtable();
            param.Add("resourceName", resourceName);
            param.Add("id", id);
            param.Add("model", model);
            _work.addTask(new System.ComponentModel.DoWorkEventHandler(this.generateReportAsyncCall), callBack, param, prioritaire);
        }

        private void generateReportAsyncCall(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            e.Result = generateReportData((string)((Hashtable)(e.Argument))["resourceName"], (ArrayList)((Hashtable)(e.Argument))["id"], (models.query.aQueryReport)((Hashtable)(e.Argument))["model"]);
        }

        /// <summary>
        /// Récupère un rapport précédement généré par la fonction 'generateReport'
        /// </summary>
        /// <param name="idReport">Identifiant du(des) rapport(s) à récupérer. Ces identifiants sont retournés par la fonction 'generateReport'</param>
        /// <param name="timeOut">Durée maximale d'attente du rapport, en seconde. 10 par défaut (selon exemple sur openerp.com)</param>
        /// <returns>Pour l'instant, un buffer/block mémoire contenant le rapport. Si on sauve ce block dans un fichier, on aura le format demandé (pdf, ou autre)</returns>
        /// <remarks></remarks>
        public models.reports.aReport getReport(int idReport)
        {
            return getReport(idReport, DEFAULT_MAX_TIMEOUT);
        }
        public models.reports.aReport getReport(int idReport, int timeOut)
        {
            if (checkIfBusy())
            {
                return null;
            }
            return getReportData(idReport, timeOut);
        }

        private models.reports.aReport getReportData(int idReport, int timeOut)
        {
            Interfaces.Ireport conn;
            int attempt = 0;
            object retour = null;
            bool boucle = true;
            models.reports.aReport ret = new models.reports.aReport();
            string _lastError = "";
            if (!isConnected)
            {
                throw new Systeme.exceptionOpenERP(Systeme.exceptionOpenERP.ERRORS.NOT_CONNECTED);
            }
            if ((idReport <= 0))
            {
                throw new Systeme.exceptionOpenERP(Systeme.exceptionOpenERP.ERRORS.MANQUE_PARAM, "idReport can\'t be less or equal to zero");
            }
            try
            {
                conn = XmlRpcProxyGen.Create<Interfaces.Ireport>();
                conn.Url = url(SERVICE_XMLRPC.report);
                while (boucle)
                {
                    try
                    {
                        retour = conn.getReport(_config.database, _config.userId, _config.password, idReport);
                        if ((retour != null) && (bool)((XmlRpcStruct)(retour))["state"])
                        {
                            break;
                        }
                    }
                    catch (Exception ex)
                    {
                        _lastError = ex.Message;
                    }
                    System.Threading.Thread.Sleep(1000);
                    attempt++;
                    if ((attempt >= timeOut))
                    {
                        throw new Systeme.exceptionOpenERP(Systeme.exceptionOpenERP.ERRORS.TIMEOUT_REPORT, _lastError);
                    }
                    ret.state = (bool)((XmlRpcStruct)(retour))["state"];
                    ret.contains = (string)((XmlRpcStruct)(retour))["result"];
                    ret.format = (string)((XmlRpcStruct)(retour))["format"];
                    return ret;
                }
            }
            catch (Exception ex)
            {
                if ((ex.GetType() == typeof(Systeme.exceptionOpenERP)))
                {
                    throw ex;
                }
                if ((_config.reportXmlRpcError
                            && (ex.GetType() == typeof(XmlRpcFaultException))))
                {
                    throw new Systeme.exceptionOpenERP(Systeme.exceptionOpenERP.ERRORS.LIB_XMLRPC, (ex.Message + ("\r\n" + ("CptTimeout : " + attempt))));
                }
                conn = null;
            }
            return null;
        }
        /// <summary>
        /// Récupère un rapport précédement généré par la fonction 'generateReport' en asynchrone
        /// </summary>
        /// <param name="idReport">Identifiant du(des) rapport(s) à récupérer. Ces identifiants sont retournés par la fonction 'generateReport'</param>
        /// <param name="timeOut">Durée maximale d'attente du rapport, en seconde. 10 par défaut</param>
        /// <remarks></remarks>
        public void getReportAsync(int idReport, System.ComponentModel.RunWorkerCompletedEventHandler callBack)
        {
            getReportAsync(idReport, callBack, DEFAULT_MAX_TIMEOUT, false);
        }
        public void getReportAsync(int idReport, System.ComponentModel.RunWorkerCompletedEventHandler callBack, int timeOut)
        {
            getReportAsync(idReport, callBack, timeOut, false);
        }
        public void getReportAsync(int idReport, System.ComponentModel.RunWorkerCompletedEventHandler callBack, bool prioritaire)
        {
            getReportAsync(idReport, callBack, DEFAULT_MAX_TIMEOUT, prioritaire);
        }
        public void getReportAsync(int idReport, System.ComponentModel.RunWorkerCompletedEventHandler callBack, int timeOut, bool prioritaire)
        {
            Hashtable param = new Hashtable();
            param.Add("idReport", idReport);
            param.Add("timeOut", timeOut);
            _work.addTask(new System.ComponentModel.DoWorkEventHandler(this.getReportAsyncCall), callBack, param, prioritaire);
        }

        private void getReportAsyncCall(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            e.Result = getReportData((int)((Hashtable)(e.Argument))["idReport"], (int)((Hashtable)(e.Argument))["timeOut"]);
        }
    }
}
