using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace IMDEV.OpenERP.models.@base {
    
    public class listProperties : Hashtable {
        
        /// <summary>
        /// Retourne ou d�fini le contenu d'une propri�t�
        /// </summary>
        /// <param name="champs">Nom de la propri�t�</param>
        /// <value>Nouvelle valeur pour cette propri�t�</value>
        /// <returns>La valeur de la propri�t�</returns>
        /// <remarks></remarks>
        public object value(string champs)
        {
            return value(champs, aField.FIELD_TYPE.NC);
        }
        public object value(string champs, aField.FIELD_TYPE typeChamps)
        {
            if (this[champs] == null)
            {
                switch (typeChamps)
                {
                    case aField.FIELD_TYPE.BOOLEAN:
                        return false;
                    case aField.FIELD_TYPE.CHAR:
                    case aField.FIELD_TYPE.SELECTION:
                    case aField.FIELD_TYPE.TEXT:
                        return "";
                    case aField.FIELD_TYPE.FLOAT:
                        return (double)0.0;
                    case aField.FIELD_TYPE.INTEGER:
                        return 0;
                    case aField.FIELD_TYPE.MANY2MANY:
                    case aField.FIELD_TYPE.MANY2ONE:
                    case aField.FIELD_TYPE.ONE2MANY:
                    case aField.FIELD_TYPE.ONE2ONE:
                        this[champs] = new ArrayList();
                        break;
                    case aField.FIELD_TYPE.DATE:
                    case aField.FIELD_TYPE.DATETIME:
                        return null;
                }
            }

            if (this[champs].GetType() == typeof(bool))
            {
                if ((typeChamps == aField.FIELD_TYPE.TEXT)
                            || (typeChamps == aField.FIELD_TYPE.CHAR))
                    return "";
                else if (typeChamps == aField.FIELD_TYPE.FLOAT)
                    return (double)0.0;
                else if (typeChamps == aField.FIELD_TYPE.INTEGER)
                    return 0;
                else if ((typeChamps == aField.FIELD_TYPE.DATE)
                            || (typeChamps == aField.FIELD_TYPE.DATETIME))
                    return null;
            }
            else if (((typeChamps == aField.FIELD_TYPE.DATE)
                    || (typeChamps == aField.FIELD_TYPE.DATETIME))
                    && (this[champs].GetType() == typeof(string)))
            {
                try
                {
                    DateTime val;
                    if ((((string)(this[champs])).IndexOf(" ") >= 0))
                    {
                        //  avec heure
                        string[] d = this[champs].ToString().Split(' ')[0].Split('-');
                        string[] h = this[champs].ToString().Split(' ')[1].Split(':');
                        val = new DateTime(int.Parse(d[0]), int.Parse(d[1]), int.Parse(d[2]), int.Parse(h[0]), int.Parse(h[1]), int.Parse(h[2]));
                    }
                    else
                    {
                        //  sans heure
                        string[] split = this[champs].ToString().Split('-');
                        val = new DateTime(int.Parse(split[0]), int.Parse(split[1]), int.Parse(split[2]));
                    }
                    return val;
                }
                catch
                {
                    throw new Systeme.exceptionOpenERP(IMDEV.OpenERP.Systeme.exceptionOpenERP.ERRORS.ERR_READING_OBJECT);
                }
            }
            return this[champs];
        }

        public void setValue(string champs, object valeur)
        {
            if ((valeur != null) && (valeur.GetType() == typeof(DateTime)))
            {
                this[champs] = ((DateTime)(valeur)).Year.ToString() + "-"
                            + ((DateTime)(valeur)).Month.ToString() + "-" + ((DateTime)(valeur)).Day.ToString()
                     + " "
                                + ((DateTime)(valeur)).Hour.ToString() + ":"
                                + ((DateTime)(valeur)).Minute.ToString() + ":" + ((DateTime)(valeur)).Second.ToString();
            }
            else
            {
                this[champs] = valeur;
            }
        }
        
        public void add(string champs, object valeur) {
            if (isKeyExist(champs)) {
                throw new Exception(("Key " 
                                + (champs + " in listproperties already exist")));
            }
            base.Add(champs, valeur);
        }
        
        /// <summary>
        /// Retourne oui ou non si une propri�t� existe dans cette liste
        /// </summary>
        /// <param name="keyName">Nom de la propri�t�</param>
        /// <returns>Vrai ou Faux</returns>
        /// <remarks></remarks>
        public bool isKeyExist(string keyName) {
            foreach (string key in Keys) {
                if ((key == keyName)) {
                    return true;
                }
            }
            return false;
        }
        
        /// <summary>
        /// Retourne la liste des propri�t�s en flux xmlrpc
        /// </summary>
        /// <param name="withId">Avec ou sans le champs "id" ?</param>
        /// <returns>Un objet XmlRpcStruct � int�grer dans une requ�te xmlrpc</returns>
        /// <remarks></remarks>
        public CookComputing.XmlRpc.XmlRpcStruct toArray()
        {
            return toArray(false);
        }
        public CookComputing.XmlRpc.XmlRpcStruct toArray(bool withId) {
            CookComputing.XmlRpc.XmlRpcStruct temp = new CookComputing.XmlRpc.XmlRpcStruct();
            // Warning!!! Optional parameters not supported
            foreach (string key in Keys) {
                if (((key != "id") 
                            || withId)) {
                    if ((this[key] == null)) {
                        temp.Add(key, false);
                    }
                    else {
                        temp.Add(key, this[key]);
                    }
                }
            }
            return temp;
        }
        
        /// <summary>
        /// Retourne la valeur d'une propriété sous forme de liste
        /// </summary>
        /// <param name="champs">Nom de la propriété</param>
        /// <returns>Liste des valeurs de la propriété</returns>
        /// <remarks></remarks>
        public ArrayList getList(string champs)
        {
            if (((this[champs] == null)
                        || (this[champs].GetType() == typeof(bool))))
            {
                this[champs] = new ArrayList();
            }
            else if ((this[champs].GetType() != typeof(System.Array)) && this[champs].GetType() != typeof(ArrayList))
            {

                object obj;
                obj = this[champs];
                this[champs] = new ArrayList();
                ((ArrayList)(this[champs])).Add(obj);
            }
            return (ArrayList)this[champs];
        }
        
        /// <summary>
        /// Retourne si "oui" ou "non" cette propri�t� est une liste
        /// </summary>
        /// <param name="champs">Nom de la propri�t�</param>
        /// <returns>Vrai ou Faux</returns>
        /// <remarks></remarks>
        public bool isList(string champs)
        {
            //  TODO : A court terme, normalement, il n'y a plus de list dans les listProperties, �tant donn� que maintenant les champs relationnels sont g�r� autrement
            //  donc ces tests doivent etre supprim�s...
            return ((this[champs].GetType() == typeof(ArrayList))
                        || (this[champs].GetType() == typeof(Int32[])));
        }
        
        /// <summary>
        /// Copie les donn�es � partir d'un flux xmlrpc
        /// </summary>
        /// <param name="source">Objet XmlRpcStruct source (provenant d'un flux xmlrpc)</param>
        /// <remarks></remarks>
        public void copyData(CookComputing.XmlRpc.XmlRpcStruct source)
        {
            IEnumerator boucle;
            boucle = source.GetEnumerator();
            while (boucle.MoveNext())
            {
                add((string)((DictionaryEntry)(boucle.Current)).Key, ((DictionaryEntry)(boucle.Current)).Value/*traitementListe(((DictionaryEntry)(boucle.Current)).Value)*/);
            }
        }
        
        /*private object traitementListe(object valeur) {
            ArrayList liste = new ArrayList();
            IEnumerator boucle;
            if (((valeur.GetType() == typeof(System.Array)) 
                        || ((valeur.GetType() == typeof(object[])) 
                        || (valeur.GetType() == typeof(int[]))))) {
                boucle = ((ArrayList)valeur).GetEnumerator();
                while (boucle.MoveNext()) {
                    liste.Add(boucle.Current);
                }
                return liste;
            }
            else {
                return valeur;
            }
        }*/
    }
}
