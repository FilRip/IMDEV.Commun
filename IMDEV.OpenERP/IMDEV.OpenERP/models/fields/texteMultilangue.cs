using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace IMDEV.OpenERP.models.fields
{
    public class texteMultilangue
    {
        public enum COMMON_LANGUAGE
        {
            en_US,
            fr_FR,
            es_ES,
            de_DE,
        }

        private models.@base.anOpenERPObject _classeParente;
        private string _nomChamps = "";
        private Hashtable _listeChaines = new Hashtable();
        private Hashtable _changed = new Hashtable();
        private string _default = "";
        private bool _alreadyLoaded;

        /// <summary>
        /// Les langues ont elles été chargées
        /// </summary>
        public bool alreadyLoaded
        {
            get { return _alreadyLoaded; }
        }

        /// <summary>
        /// La langue demandée est-elle chargée
        /// </summary>
        /// <param name="codeLangue">Code de la langue</param>
        /// <returns></returns>
        public bool languageLoaded(string codeLangue)
        {
            return (_listeChaines[codeLangue] != null);
        }

        public string defaut
        {
            get { return _default; }
            set { _default = value; }
        }

        public texteMultilangue(IMDEV.OpenERP.models.@base.anOpenERPObject classeParente, string nomChamps)
        {
            _classeParente = classeParente;
            _nomChamps = nomChamps;
        }

        /// <summary>
        /// Retourne le texte d'une langue
        /// </summary>
        /// <param name="langue">code langue</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public string retourneChaine(string langue)
        {
            return (string)_listeChaines[langue];
        }

        /// <summary>
        /// Défini le texte d'une langue
        /// </summary>
        /// <param name="langue">Code langue</param>
        /// <param name="valeur">Nouveau texte pour cette langue</param>
        /// <remarks></remarks>
        public void setChaine(string langue, string valeur)
        {
            if ((string)_listeChaines[langue] != valeur)
            {
                _listeChaines[langue] = valeur;
                _changed[langue] = true;
            }
        }

        /// <summary>
        /// Charges tous les textes pour toute une liste de langue
        /// </summary>
        /// <param name="proprieteConnexionOpenERP">Propriété de connexion au serveur OpenERP</param>
        /// <param name="listeLangue">Liste des langues à chargés</param>
        /// <remarks></remarks>
        public bool chargeLangues(IMDEV.OpenERP.models.@base.connectionProperties proprieteConnexionOpenERP, List<models.common.res_lang> listeLangue)
        {
            IMDEV.OpenERP.Clients.clientOpenERP clientOpenERP = new IMDEV.OpenERP.Clients.clientOpenERP(proprieteConnexionOpenERP);
            return chargeLangues(clientOpenERP, listeLangue);
        }

        /// <summary>
        /// Charges tous les textes pour toute une liste de langue
        /// </summary>
        /// <param name="clientOpenERP">Client de connexion au serveur OpenERP</param>
        /// <param name="listeLangue">Liste des langues à chargés</param>
        /// <remarks></remarks>
        public bool chargeLangues(IMDEV.OpenERP.Clients.clientOpenERP clientOpenERP, List<models.common.res_lang> listeLangue)
        {
            if (clientOpenERP.checkIfBusy())
                return false;

            return chargeLanguesData(clientOpenERP, listeLangue);
        }

        private void chargeLanguesAsyncCall(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Clients.clientOpenERP cli;
            cli = (Clients.clientOpenERP)((Hashtable)(e.Argument))["clientOpenERP"];
            e.Result = chargeLanguesData(cli, (List<models.common.res_lang>)((Hashtable)(e.Argument))["listeLangue"]);
        }

        private void chargeLanguesAsyncCallC(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            IMDEV.OpenERP.Clients.clientOpenERP clientOpenERP = new IMDEV.OpenERP.Clients.clientOpenERP(((IMDEV.OpenERP.models.@base.connectionProperties)(((Hashtable)(e.Argument))["proprieteOpenERP"])));
            e.Result = chargeLanguesData(clientOpenERP, (List<models.common.res_lang>)((Hashtable)(e.Argument))["listeLangue"]);
        }

        /// <summary>
        /// Charge tous les texte pour toute une liste de langue, en asynchrone
        /// </summary>
        /// <param name="proprieteOpenERP">Propriété de connexion au serveur OpenERP</param>
        /// <param name="listeLangue">Liste des code langues a chargés</param>
        /// <param name="callBack"></param>
        public void chargeLanguesAsync(IMDEV.OpenERP.models.@base.connectionProperties proprieteOpenERP, List<models.common.res_lang> listeLangue, System.ComponentModel.RunWorkerCompletedEventHandler callBack)
        {
            try
            {
                Hashtable param = new Hashtable();
                System.ComponentModel.BackgroundWorker bg = new System.ComponentModel.BackgroundWorker();
                bg.RunWorkerCompleted += callBack;
                bg.DoWork += new System.ComponentModel.DoWorkEventHandler(this.chargeLanguesAsyncCallC);
                param.Add("proprieteOpenERP", proprieteOpenERP);
                param.Add("listeLangue", listeLangue);
                bg.RunWorkerAsync(param);
            }
            catch { }
        }

        /// <summary>
        /// Charge tous les texte pour toute une liste de langue, en asynchrone
        /// </summary>
        /// <param name="clientOpenERP">Client OpenERP déjà connecté</param>
        /// <param name="listeLangue">Liste des code langue a charger</param>
        /// <param name="callBack"></param>
        public void chargeLanguesAsync(IMDEV.OpenERP.Clients.clientOpenERP clientOpenERP, List<models.common.res_lang> listeLangue, System.ComponentModel.RunWorkerCompletedEventHandler callBack)
        {
            chargeLanguesAsync(clientOpenERP, listeLangue, callBack, false);
        }
        public void chargeLanguesAsync(IMDEV.OpenERP.Clients.clientOpenERP clientOpenERP, List<models.common.res_lang> listeLangue, System.ComponentModel.RunWorkerCompletedEventHandler callBack, bool prioritaire)
        {
            Hashtable param = new Hashtable();
            param.Add("clientOpenERP", clientOpenERP);
            param.Add("listeLangue", listeLangue);
            clientOpenERP.worker.addTask(new System.ComponentModel.DoWorkEventHandler(this.chargeLanguesAsyncCall), callBack, param, prioritaire);
        }

        /// <summary>
        /// Charges tous les textes pour toute une liste de langue
        /// </summary>
        /// <param name="proprieteConnexionOpenERP">Propriété de connexion au serveur OpenERP</param>
        /// <param name="listeLangue">Liste des langues à charger</param>
        /// <remarks></remarks>
        public bool chargeLangues(IMDEV.OpenERP.models.@base.connectionProperties proprieteConnexionOpenERP, List<string> listeLangue)
        {
            IMDEV.OpenERP.Clients.clientOpenERP clientOpenERP = new IMDEV.OpenERP.Clients.clientOpenERP(proprieteConnexionOpenERP);
            return chargeLangues(clientOpenERP, listeLangue);
        }

        /// <summary>
        /// Charges tous les textes pour toute une liste de langue
        /// </summary>
        /// <param name="clientOpenERP">Client de connexion au serveur OpenERP</param>
        /// <param name="listeLangue">Liste des langues à charger</param>
        /// <remarks></remarks>
        public bool chargeLangues(IMDEV.OpenERP.Clients.clientOpenERP clientOpenERP, List<string> listeLangue)
        {
            List<models.common.res_lang> listLang = new List<models.common.res_lang>();
            models.common.res_lang l;
            foreach (string lang in listeLangue)
            {
                l = new models.common.res_lang();
                l.code = lang;
                listLang.Add(l);
            }
            return chargeLangues(clientOpenERP, listLang);
        }

        /// <summary>
        /// Charge le texte pour une langue
        /// </summary>
        /// <param name="proprieteConnexion">Propriété de connexion au serveur OpenERP</param>
        /// <param name="codeLangue">Code de la langue du texte à charger</param>
        /// <remarks></remarks>
        public bool chargeLangue(IMDEV.OpenERP.models.@base.connectionProperties proprieteConnexion, string codeLangue)
        {
            models.common.res_lang l = new models.common.res_lang();
            List<models.common.res_lang> listeLangue = new List<models.common.res_lang>();
            l.code = codeLangue;
            listeLangue.Add(l);
            return chargeLangues(proprieteConnexion, listeLangue);
        }

        /// <summary>
        /// Charge le texte pour une langue
        /// </summary>
        /// <param name="clientOpenERP">Client de connexion au serveur OpenERP</param>
        /// <param name="codeLangue">Code de la langue du texte à charger</param>
        /// <remarks></remarks>
        public bool chargeLangue(IMDEV.OpenERP.Clients.clientOpenERP clientOpenERP, string codeLangue)
        {
            models.common.res_lang l = new models.common.res_lang();
            List<models.common.res_lang> listeLangue = new List<models.common.res_lang>();
            l.code = codeLangue;
            listeLangue.Add(l);
            return chargeLangues(clientOpenERP, listeLangue);
        }

        private bool chargeLanguesData(IMDEV.OpenERP.Clients.clientOpenERP clientOpenERP, List<models.common.res_lang> listeLangue)
        {
            List<object> retour;
            List<string> listeChamps = new List<string>();
            models.@base.listProperties context;
            listeChamps.Add(_nomChamps);
            _listeChaines.Clear();
            _listeChaines = new Hashtable();
            _changed.Clear();
            _changed = new Hashtable();
            try
            {
                if (listeLangue == null)
                {
                    listeLangue = clientOpenERP.translatableLang();
                    if (listeLangue == null)
                        throw new Systeme.exceptionOpenERP(IMDEV.OpenERP.Systeme.exceptionOpenERP.ERRORS.NO_LANGUAGE);
                }
                foreach (models.common.res_lang lang in listeLangue)
                {
                    context = new models.@base.listProperties();
                    context.add("lang", lang.code);
                    retour = clientOpenERP.read(new IMDEV.OpenERP.models.query.aQuery((int)_classeParente.listProperties.value("id", IMDEV.OpenERP.models.@base.aField.FIELD_TYPE.INTEGER)), _classeParente.resource_name(), listeChamps, context);
                    _listeChaines.Add(lang.code, ((models.@base.aGenericObject)(retour[0])).listProperties.value(_nomChamps, IMDEV.OpenERP.models.@base.aField.FIELD_TYPE.TEXT));
                    _changed.Add(lang.code, false);
                }
                _alreadyLoaded = true;
                return true;
            }
            catch (Exception e)
            {
                throw new Systeme.exceptionOpenERP(Systeme.exceptionOpenERP.ERRORS.ERR_LOAD_TRANSLATE, e.Message);
            }
        }

        /// <summary>
        /// Enregistre sur le serveur toutes les langues chargées
        /// </summary>
        /// <param name="proprieteConnexion">Propriété de connexion au serveur OpenERP</param>
        /// <returns></returns>
        public bool sauveLangues(IMDEV.OpenERP.models.@base.connectionProperties proprieteConnexion)
        {
            return sauveLanguesData(proprieteConnexion);
        }

        /// <summary>
        /// Enregistre sur le serveur toutes les langues chargées
        /// </summary>
        /// <param name="clientOpenERP">Client OpenERP déjà ouvert</param>
        /// <returns></returns>
        public bool sauveLangues(IMDEV.OpenERP.Clients.clientOpenERP clientOpenERP)
        {
            return sauveLanguesData(clientOpenERP);
        }

        private void sauveLanguesAsyncCall(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Clients.clientOpenERP clientOpenERP = new IMDEV.OpenERP.Clients.clientOpenERP(((IMDEV.OpenERP.models.@base.connectionProperties)((Hashtable)(e.Argument))["proprieteOpenERP"]));
            e.Result = sauveLanguesData(clientOpenERP);
        }

        private void sauveLanguesAsyncCallC(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            e.Result = sauveLanguesData((Clients.clientOpenERP)((Hashtable)(e.Argument))["clientOpenERP"]);
        }

        /// <summary>
        /// Enregistre sur le serveur toutes les langues chargées en asynchrone
        /// </summary>
        /// <param name="proprieteConnexion">Propriété de connexion au serveur OpenERP</param>
        /// <param name="callBack">Méthode à appeler quand le travail est terminé</param>
        /// <param name="prioritaire">Passe cette requête en priorité ?</param>
        public void sauveLanguesAsync(IMDEV.OpenERP.models.@base.connectionProperties proprieteConnexion, System.ComponentModel.RunWorkerCompletedEventHandler callBack)
        {
            sauveLanguesAsync(proprieteConnexion, callBack, false);
        }
        public void sauveLanguesAsync(IMDEV.OpenERP.models.@base.connectionProperties proprieteConnexion, System.ComponentModel.RunWorkerCompletedEventHandler callBack, bool prioritaire)
        {
            try
            {
                Hashtable param = new Hashtable();
                System.ComponentModel.BackgroundWorker bg = new System.ComponentModel.BackgroundWorker();
                bg.DoWork += new System.ComponentModel.DoWorkEventHandler(this.sauveLanguesAsyncCallC);
                bg.RunWorkerCompleted += callBack;
                param.Add("proprieteOpenERP", proprieteConnexion);
                bg.RunWorkerAsync(param);
            }
            catch 
            {
            }
        }

        /// <summary>
        /// Enregistre sur le serveur toutes les langues chargées en asynchrone
        /// </summary>
        /// <param name="clientOpenERP">Client OpenERP déjà connecté</param>
        /// <param name="callBack">Méthode à appeler quand le travail est terminé</param>
        /// <param name="prioritaire">Passe cette requête en priorité ?</param>
        public void sauveLanguesAsync(Clients.clientOpenERP clientOpenERP, System.ComponentModel.RunWorkerCompletedEventHandler callBack)
        {
            sauveLanguesAsync(clientOpenERP, callBack, false);
        }
        public void sauveLanguesAsync(Clients.clientOpenERP clientOpenERP, System.ComponentModel.RunWorkerCompletedEventHandler callBack, bool prioritaire)
        {
            Hashtable param = new Hashtable();
            try
            {
                param.Add("clientOpenERP", clientOpenERP);
                clientOpenERP.worker.addTask(new System.ComponentModel.DoWorkEventHandler(this.sauveLanguesAsyncCallC), callBack, param, prioritaire);
            }
            catch { }
        }

        private bool sauveLanguesData(IMDEV.OpenERP.models.@base.connectionProperties proprieteConnexion)
        {
            try
            {
                foreach (string codeLangue in _listeChaines.Keys)
                    if (!sauveLangue(proprieteConnexion, codeLangue))
                        throw new Exception("sauveLangue return False");

                return true;
            }
            catch (Exception ex)
            {
                throw new Systeme.exceptionOpenERP(Systeme.exceptionOpenERP.ERRORS.ERR_SAVE_TRANSLATE, ex.Message);
            }
        }

        private bool sauveLanguesData(Clients.clientOpenERP clientOpenERP)
        {
            try
            {
                foreach (string codeLangue in _listeChaines.Keys)
                    if (!sauveLangue(clientOpenERP, codeLangue))
                        throw new Exception("sauveLangue return False");

                return true;
            }
            catch (Exception ex)
            {
                throw new Systeme.exceptionOpenERP(Systeme.exceptionOpenERP.ERRORS.ERR_SAVE_TRANSLATE, ex.Message);
            }
        }

        /// <summary>
        /// Enregistre le texte d'une langue, sur le serveur OpenERP
        /// </summary>
        /// <param name="proprieteConnexion">Propriété de connexion au serveur OpenERP</param>
        /// <param name="codeLangue">Code de la langue à enregistrer</param>
        /// <returns></returns>
        public bool sauveLangue(IMDEV.OpenERP.models.@base.connectionProperties proprieteConnexion, string codeLangue)
        {
            if (!_changed.ContainsKey(codeLangue))
                return false;

            string libelle;
            IMDEV.OpenERP.Clients.clientOpenERP conn;
            bool retour;
            IMDEV.OpenERP.models.@base.listProperties context;
            IMDEV.OpenERP.models.@base.listProperties fields;
            if ((bool)_changed[codeLangue])
            {
                conn = new IMDEV.OpenERP.Clients.clientOpenERP(proprieteConnexion);
                libelle = (string)_listeChaines[codeLangue];
                fields = new IMDEV.OpenERP.models.@base.listProperties();
                fields.add(_nomChamps, libelle);
                context = new IMDEV.OpenERP.models.@base.listProperties();
                context.add("lang", codeLangue);
                retour = conn.update(fields, _classeParente.GetType(), (int)_classeParente.listProperties.value("id", IMDEV.OpenERP.models.@base.aField.FIELD_TYPE.INTEGER), context);
                if (!retour)
                    throw new Exception("Update return False");

                _changed[codeLangue] = false;
            }
            return true;
        }

        /// <summary>
        /// Enregistre le texte d'une langue, sur le serveur OpenERP
        /// </summary>
        /// <param name="clientOpenERP">Client OpenERP déjà connecté</param>
        /// <param name="codeLangue">Code de la langue à enregistrer</param>
        /// <returns></returns>
        public bool sauveLangue(Clients.clientOpenERP clientOpenERP, string codeLangue)
        {
            if (!_changed.ContainsKey(codeLangue))
                return false;

            string libelle;
            bool retour;
            IMDEV.OpenERP.models.@base.listProperties context;
            IMDEV.OpenERP.models.@base.listProperties fields;
            if ((bool)_changed[codeLangue])
            {
                libelle = (string)_listeChaines[codeLangue];
                fields = new IMDEV.OpenERP.models.@base.listProperties();
                fields.add(_nomChamps, libelle);
                context = new IMDEV.OpenERP.models.@base.listProperties();
                context.add("lang", codeLangue);
                retour = clientOpenERP.update(fields, _classeParente.GetType(), (int)(_classeParente.listProperties.value("id", IMDEV.OpenERP.models.@base.aField.FIELD_TYPE.INTEGER)), context);
                if (!retour)
                    throw new Exception("Update return False");

                _changed[codeLangue] = false;
            }
            return true;
        }
    }
}
