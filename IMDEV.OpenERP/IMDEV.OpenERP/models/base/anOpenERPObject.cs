using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace IMDEV.OpenERP.models.@base
{

    public abstract class anOpenERPObject
    {

        private listProperties _listePropriete = new listProperties();

        /// <summary>
        /// Retourne la liste des propri�t�s de cet objet
        /// </summary>
        /// <value></value>
        /// <returns>liste de propri�t�s, contenant chacun un nom de champ et sa valeur</returns>
        /// <remarks></remarks>
        public listProperties listProperties
        {
            get
            {
                return _listePropriete;
            }
            set
            {
                _listePropriete = value;
            }
        }

        public void copyData(CookComputing.XmlRpc.XmlRpcStruct source)
        {
            bool change = true;
            List<System.Reflection.PropertyInfo> listePropriete;
            List<System.Reflection.PropertyInfo> listeProprietesEnum;

            listePropriete = listeProprieteRelationnelles();
            //  On copie d'abord les valeurs des champs relationnelles (m2o, o2m, m2m)
            while (change)
            {
                change = false;
                foreach (string key in source.Keys)
                {
                    foreach (System.Reflection.PropertyInfo prop in listePropriete)
                    {
                        if (prop.Name.Trim().ToLower() == key.Trim().ToLower())
                        {
                            if (source[key].GetType() != typeof(bool))
                            {
                                if (prop.GetValue(this, null).GetType() == typeof(models.fields.relations.manyToOne))
                                {
                                    if (source[key].GetType() == typeof(int))
                                        ((models.fields.relations.manyToOne)(prop.GetValue(this, null))).copyData((int)source[key]);
                                    else
                                        ((models.fields.relations.manyToOne)(prop.GetValue(this, null))).copyData((Array)source[key]);
                                }
                                else if (prop.GetValue(this, null).GetType() == typeof(models.fields.relations.oneToMany))
                                    ((models.fields.relations.oneToMany)(prop.GetValue(this, null))).copyData((Array)source[key]);
                                else if (prop.GetValue(this, null).GetType() == typeof(models.fields.relations.manyToMany))
                                    ((models.fields.relations.manyToMany)(prop.GetValue(this, null))).copyData((Array)source[key]);
                            }
                            change = true;
                            source.Remove(key);
                            break;
                        }
                    }
                    if (change)
                    {
                        break;
                    }
                }
            }
            listeProprietesEnum = listeProprieteEnum();
            change = true;
            while (change)
            {
                change = false;
                foreach (string key in source.Keys)
                {
                    if (source[key].GetType() != typeof(bool))
                    {
                        foreach (System.Reflection.PropertyInfo prop in listeProprietesEnum)
                        {
                            if (prop.Name.Trim().ToLower() == key.Trim().ToLower())
                            {
                                setEnum(prop, source[key].ToString());
                                change = true;
                                source.Remove(key);
                                break;
                            }
                        }
                        if (change)
                        {
                            break;
                        }
                    }
                }
            }
            //  On copie ensuite le reste (int, string, etc...)
            _listePropriete.copyData(source);
        }

        private int getNumEnum(System.Reflection.FieldInfo f, string val)
        {
            Array listeValeurs;
            int i = 0;
            listeValeurs = (Array)f.GetValue(this);
            foreach (string valeur in listeValeurs)
            {
                if (valeur == val)
                {
                    return i;
                }
                i++;
            }
            return 0;
        }

        private void setEnum(System.Reflection.PropertyInfo prop, string val)
        {
            System.Reflection.FieldInfo listeEnum;
            int i;
            listeEnum = this.GetType().GetField(("_frv_" + prop.Name), (System.Reflection.BindingFlags.NonPublic
                            | (System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Static)));
            i = getNumEnum(listeEnum, val);
            prop.SetValue(this, i, null);
        }

        private List<System.Reflection.PropertyInfo> listeProprieteEnum()
        {
            List<System.Reflection.PropertyInfo> retour = new List<System.Reflection.PropertyInfo>();
            try
            {
                System.Reflection.PropertyInfo[] listProprietes;
                listProprietes = this.GetType().GetProperties();
                foreach (System.Reflection.PropertyInfo prop in listProprietes)
                {
                    if (prop.PropertyType.BaseType == typeof(System.Enum))
                    {
                        retour.Add(prop);
                    }
                }
            }
            catch
            {
                throw new Systeme.exceptionOpenERP(IMDEV.OpenERP.Systeme.exceptionOpenERP.ERRORS.ERR_READING_OBJECT);
            }
            return retour;
        }

        private List<System.Reflection.PropertyInfo> listeProprieteRelationnelles()
        {
            List<System.Reflection.PropertyInfo> retour = new List<System.Reflection.PropertyInfo>();
            try
            {
                System.Reflection.PropertyInfo[] listProprietes;
                listProprietes = this.GetType().GetProperties();
                foreach (System.Reflection.PropertyInfo prop in listProprietes)
                {
                    if ((prop.PropertyType == typeof(fields.relations.manyToMany))
                                || (prop.PropertyType == typeof(fields.relations.manyToOne))
                                || (prop.PropertyType == typeof(fields.relations.oneToMany)))
                    {
                        retour.Add(prop);
                    }
                }
            }
            catch
            {
                throw new Systeme.exceptionOpenERP(IMDEV.OpenERP.Systeme.exceptionOpenERP.ERRORS.ERR_READING_OBJECT);
            }
            return retour;
        }

        public CookComputing.XmlRpc.XmlRpcStruct toXmlRpc()
        {
            return toXmlRpc(true);
        }

        public CookComputing.XmlRpc.XmlRpcStruct toXmlRpc(bool avecLectureSeule)
        {
            object val;
            object dummyObj;
            CookComputing.XmlRpc.XmlRpcStruct retour;
            retour = new CookComputing.XmlRpc.XmlRpcStruct();
            List<System.Reflection.PropertyInfo> listProprietesRel;
            List<System.Reflection.PropertyInfo> listProprietesEnum;
            listProprietesRel = listeProprieteRelationnelles();
            listProprietesEnum = listeProprieteEnum();
            System.Reflection.FieldInfo libEnum;
            try
            {
                foreach (System.Reflection.PropertyInfo prop in listProprietesRel)
                {
                    val = prop.GetValue(this, null);
                    if (val != null)
                    {
                        dummyObj = null;
                        if (val.GetType() == typeof(models.fields.relations.manyToMany))
                            dummyObj = ((models.fields.relations.manyToMany)(val)).toXmlRpc();
                        if (val.GetType() == typeof(models.fields.relations.oneToMany))
                            dummyObj = ((models.fields.relations.oneToMany)(val)).toXmlRpc();
                        if (val.GetType() == typeof(models.fields.relations.manyToOne))
                            dummyObj = ((models.fields.relations.manyToOne)(val)).toXmlRpc();
                        if (dummyObj != null)
                            retour.Add(prop.Name, dummyObj);
                    }
                }
                foreach (System.Reflection.PropertyInfo prop in listProprietesEnum)
                {
                    val = prop.GetValue(this, null);
                    if ((val != null) && (val.ToString() != ""))
                        if ((val.ToString() != "NULL"))
                            if ((val.ToString() == "_EMPTY_"))
                                retour.Add(prop.Name, 0);
                            else
                            {
                                libEnum = this.GetType().GetField(("_frv_" + prop.Name), (System.Reflection.BindingFlags.NonPublic
                                                | (System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Static)));
                                retour.Add(prop.Name, ((System.Array)(libEnum.GetValue(this))).GetValue((int)prop.GetValue(this, null)));
                            }
                }

                CookComputing.XmlRpc.XmlRpcStruct varStd;
                varStd = _listePropriete.toArray();
                foreach (string key in varStd.Keys)
                {
                    System.Reflection.PropertyInfo prop = this.GetType().GetProperty(key);
                    if (prop != null)
                    {
                        if (avecLectureSeule || prop.CanWrite)
                        {
                            retour.Add(key, varStd[key]);
                        }
                    }
                }
            }
            catch
            {
                throw new Systeme.exceptionOpenERP(IMDEV.OpenERP.Systeme.exceptionOpenERP.ERRORS.ERROR_READING_VALUES);
            }
            return retour;
        }

        public override string ToString()
        {
            return (string)listProperties.value("name", aField.FIELD_TYPE.CHAR);
        }

        public abstract string resource_name();

#region "Save"

        public bool save(connectionProperties connexionOpenERP)
        {
            return save(connexionOpenERP, null);
        }
        public bool save(connectionProperties connexionOpenERP, models.@base.listProperties context)
        {
            Clients.clientOpenERP cli = new IMDEV.OpenERP.Clients.clientOpenERP(connexionOpenERP);
            return sauveData(cli,context);
        }

        public bool save(Clients.clientOpenERP clientOpenERP)
        {
            return save(clientOpenERP, null);
        }
        public bool save(Clients.clientOpenERP clientOpenERP, models.@base.listProperties context)
        {
            return sauveData(clientOpenERP, context);
        }

        public void sauveAsyncCallC(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            e.Result = sauveData((Clients.clientOpenERP)((Hashtable)(e.Argument))["clientOpenERP"], (models.@base.listProperties)((Hashtable)(e.Argument))["context"]);
        }

        public void saveAsync(connectionProperties connexionOpenERP, System.ComponentModel.RunWorkerCompletedEventHandler callBack, models.@base.listProperties context)
        {
            saveAsync(connexionOpenERP, callBack, false, context);
        }
        public void saveAsync(connectionProperties connexionOpenERP, System.ComponentModel.RunWorkerCompletedEventHandler callBack, bool prioritaire)
        {
            saveAsync(connexionOpenERP, callBack, prioritaire, null);
        }
        public void saveAsync(connectionProperties connexionOpenERP, System.ComponentModel.RunWorkerCompletedEventHandler callBack)
        {
            saveAsync(connexionOpenERP, callBack, false,null);
        }
        public void saveAsync(connectionProperties connexionOpenERP, System.ComponentModel.RunWorkerCompletedEventHandler callBack, bool prioritaire, models.@base.listProperties context)
        {
            Clients.clientOpenERP cli = new IMDEV.OpenERP.Clients.clientOpenERP(connexionOpenERP);
            saveAsync(cli, callBack, prioritaire, context);
        }

        public void saveAsync(Clients.clientOpenERP clientOpenERP, System.ComponentModel.RunWorkerCompletedEventHandler callBack, models.@base.listProperties context)
        {
            saveAsync(clientOpenERP, callBack, false, context);
        }
        public void saveAsync(Clients.clientOpenERP clientOpenERP, System.ComponentModel.RunWorkerCompletedEventHandler callBack, bool prioritaire)
        {
            saveAsync(clientOpenERP, callBack, prioritaire, null);
        }
        public void saveAsync(Clients.clientOpenERP clientOpenERP, System.ComponentModel.RunWorkerCompletedEventHandler callBack)
        {
            saveAsync(clientOpenERP, callBack, false,null);
        }
        public void saveAsync(Clients.clientOpenERP clientOpenERP, System.ComponentModel.RunWorkerCompletedEventHandler callBack, bool prioritaire, models.@base.listProperties context)
        {
            Hashtable param = new Hashtable();
            param.Add("clientOpenERP", clientOpenERP);
            param.Add("context", context);
            clientOpenERP.worker.addTask(new System.ComponentModel.DoWorkEventHandler(this.sauveAsyncCallC), callBack, param, prioritaire);
        }

        public bool sauveData(Clients.clientOpenERP clientOpenERP, models.@base.listProperties context)
        {
            bool result;
            try
            {
                if ((!listProperties.ContainsKey("id"))
                            || ((int)listProperties.value("id", aField.FIELD_TYPE.INTEGER) == 0))
                {
                    listProperties.setValue("id", clientOpenERP.insert(this,context));
                    result = ((int)listProperties.value("id") > 0);
                }
                else
                {
                    result = clientOpenERP.update(this, context);
                }
                if (result)
                {
                    foreach (System.Reflection.PropertyInfo prop in listeProprieteMultilangue())
                    {
                        ((IMDEV.OpenERP.models.fields.texteMultilangue)(prop.GetValue(this, null))).sauveLangues(clientOpenERP);
                    }
                    return true;
                }
            }
            catch
            {
                throw new Systeme.exceptionOpenERP(IMDEV.OpenERP.Systeme.exceptionOpenERP.ERRORS.ERR_SAVE_OBJECT);
            }
            finally
            {
                clientOpenERP = null;
            }
            return false;
        }

#endregion

#region "Delete"

        public bool delete(connectionProperties connexionOpenERP)
        {
            return effaceData(connexionOpenERP);
        }

        public bool delete(Clients.clientOpenERP clientOpenERP)
        {
            return effaceData(clientOpenERP);
        }

        public bool effaceData(connectionProperties connexionOpenERP)
        {
            Clients.clientOpenERP clientOpenERP = new Clients.clientOpenERP(connexionOpenERP);
            return effaceData(clientOpenERP);
        }

        public bool effaceData(Clients.clientOpenERP clientOpenERP)
        {
            bool retour = false;
            try
            {
                if ((int)listProperties.value("id", aField.FIELD_TYPE.INTEGER) == 0)
                {
                    throw new Exception("Cet objet n\'existe pas encore sur le serveur OpenERP");
                }
                retour = clientOpenERP.delete(this);
                if (retour)
                {
                    listProperties.setValue("id", 0);
                }
            }
            catch 
            {
                throw new Systeme.exceptionOpenERP(IMDEV.OpenERP.Systeme.exceptionOpenERP.ERRORS.ERR_DEL_OBJECT);
            }
            finally
            {
                clientOpenERP = null;
            }
            return retour;
        }

        public void deleteAsync(connectionProperties connexionOpenERP, System.ComponentModel.RunWorkerCompletedEventHandler callBack)
        {
            Hashtable param = new Hashtable();
            System.ComponentModel.BackgroundWorker bg = new System.ComponentModel.BackgroundWorker();
            bg.DoWork += new System.ComponentModel.DoWorkEventHandler(this.effaceAsyncCall);
            bg.RunWorkerCompleted += callBack;
            param.Add("connexionOpenERP", connexionOpenERP);
            bg.RunWorkerAsync(param);
        }

        public void deleteAsync(Clients.clientOpenERP clientOpenERP, System.ComponentModel.RunWorkerCompletedEventHandler callBack)
        {
            deleteAsync(clientOpenERP, callBack, false);
        }
        public void deleteAsync(Clients.clientOpenERP clientOpenERP, System.ComponentModel.RunWorkerCompletedEventHandler callBack, bool prioritaire)
        {
            Hashtable param = new Hashtable();
            param.Add("clientOpenERP", clientOpenERP);
            clientOpenERP.worker.addTask(new System.ComponentModel.DoWorkEventHandler(this.effaceAsyncCallC), callBack, param, prioritaire);
        }

        private void effaceAsyncCall(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            e.Result = effaceData((models.@base.connectionProperties)((Hashtable)(e.Argument))["connexionOpenERP"]);
        }
        private void effaceAsyncCallC(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            e.Result = effaceData((Clients.clientOpenERP)((Hashtable)(e.Argument))["clientOpenERP"]);
        }

#endregion

        public List<System.Reflection.PropertyInfo> listeProprieteMultilangue()
        {
            List<System.Reflection.PropertyInfo> retour = new List<System.Reflection.PropertyInfo>();
            try
            {
                System.Reflection.PropertyInfo[] listProprietes;
                listProprietes = this.GetType().GetProperties();
                foreach (System.Reflection.PropertyInfo prop in listProprietes)
                {
                    if (prop.PropertyType == typeof(fields.texteMultilangue))
                    {
                        retour.Add(prop);
                    }
                }
            }
            catch 
            {
                throw new Systeme.exceptionOpenERP(IMDEV.OpenERP.Systeme.exceptionOpenERP.ERRORS.ERR_READING_OBJECT);
            }
            return retour;
        }
    }
}
