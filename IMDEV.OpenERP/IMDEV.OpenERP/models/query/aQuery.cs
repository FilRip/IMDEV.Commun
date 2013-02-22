using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace IMDEV.OpenERP.models.query
{
    public class aQuery : baseQuery
    {

        public enum OPERATORS
        {
            AND,
            OR,
            NOT,
        }

        private string OPERATEUR_ET = "&";
        private string OPERATEUR_OU = "|";
        private string OPERATEUR_NON = "!";

        public aQuery()
        {
        }

        public aQuery(int id)
        {
            addParameter(id);
        }

        public aQuery(Int64 id)
        {
            addParameter(id);
        }

        public aQuery(List<int> listId)
        {
            foreach (int i in listId)
                addParameter(i);
        }

        public aQuery(string champs, object egalA)
        {
            addEqualTo(champs, egalA);
        }

        public aQuery(ArrayList listId)
        {
            foreach (int a in listId)
                addParameter(a);
        }

        /// <summary>
        /// Indique le nombre d'opérateur ET/OU contenu dans cette requête
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        public int nbCond()
        {
            int nbCond = 0;
            foreach (object r in _listeParametre)
            {
                if ((r.GetType() == typeof(string)))
                {
                    if ((((string)r == OPERATEUR_ET)
                                || (((string)r == OPERATEUR_OU)
                                || ((string)r == OPERATEUR_NON))))
                        nbCond++;
                }
            }
            return nbCond;
        }

        /// <summary>
        /// Permet quelques vérifications pour savoir si la requête sera acceptée par la fonction 'search' (recherche) du service xmlrpc de OpenERP
        /// </summary>
        /// <returns>True = correcte, sinon False</returns>
        /// <remarks></remarks>
        public bool checkSearchQuery()
        {
            for (int i = 0; (i <= (_listeParametre.Count - 2)); i++)
            {
                if ((_listeParametre[i].GetType() == typeof(string)))
                {
                    if ((((string)_listeParametre[i] == OPERATEUR_ET)
                                || (((string)_listeParametre[i] == OPERATEUR_OU)
                                || ((string)_listeParametre[i] == OPERATEUR_NON)))
                                && (((string)_listeParametre[(i + 1)] == OPERATEUR_ET)
                                || (((string)_listeParametre[(i + 1)] == OPERATEUR_OU)
                                || ((string)_listeParametre[(i + 1)] == OPERATEUR_NON))))
                        return false;
                }
            }
            if (nbCond() > 0)
            {
                if (((_listeParametre.Count - nbCond()) / 3) != (nbCond() + 1))
                    return false;
            }
            else
            {
                if (_listeParametre.Count > 3)
                    return false;
            }
            return true;
        }
        /// <summary>
        /// Retourne la requête sous le format objet requis pour l'envoi en xmlrpc à OpenERP pour la fonction 'search' (recherche)
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        public Array toSearchXmlRpc()
        {
            verifLastItem();
            if (!checkSearchQuery())
                return null;

            ArrayList construct = new ArrayList();
            string lastOperateur = "";
            Array lastConstruct;
            for (int i = 0; (i <= nbCond()); i++)
            {
                lastConstruct = arrayToNextCond(i, ref lastOperateur);
                if ((lastOperateur != "") && (i < nbCond()))
                    construct.Add(lastOperateur);
                construct.Add(lastConstruct);
            }
            return construct.ToArray();
        }


        public bool isSearchCountQuery()
        {
            if (IMDEV.Maths.traitement.multipleDe(_listeParametre.Count, 3))
                return true;
            else
                return false;
        }
        public void verifLastItem()
        {
            bool unChangement = true;
            while ((_listeParametre[(_listeParametre.Count - 1)].GetType() == typeof(string))
                        && (((string)_listeParametre[(_listeParametre.Count - 1)] == OPERATEUR_ET)
                        || (((string)_listeParametre[(_listeParametre.Count - 1)] == OPERATEUR_NON)
                        || ((string)_listeParametre[(_listeParametre.Count - 1)] == OPERATEUR_OU))))
            {
                _listeParametre.RemoveAt((_listeParametre.Count - 1));
            }
            //  on enleve les operateurs qui sont en double (l'un à coté de l'autre)
            while (unChangement)
            {
                unChangement = false;
                for (int i = 0; (i <= (_listeParametre.Count - 2)); i++)
                {
                    if (((_listeParametre[i].GetType() == typeof(string))
                                && (_listeParametre[(i + 1)].GetType() == typeof(string))))
                    {
                        if ((((string)_listeParametre[i] == OPERATEUR_ET)
                                    || (((string)_listeParametre[i] == OPERATEUR_NON)
                                    || ((string)_listeParametre[i] == OPERATEUR_OU)))
                                    && (((string)_listeParametre[(i + 1)] == OPERATEUR_ET)
                                    || (((string)_listeParametre[(i + 1)] == OPERATEUR_NON)
                                    || ((string)_listeParametre[(i + 1)] == OPERATEUR_OU))))
                        {
                            _listeParametre.RemoveAt((i + 1));
                            unChangement = true;
                            break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Retourne la requete sous le format attendu par la méthode xmlrpc searchcount
        /// </summary>
        /// <returns></returns>
        public Array toSearchCountXmlRpc()
        {
            ArrayList construct = new ArrayList();
            ArrayList phrase;
            verifLastItem();
            if (!isSearchCountQuery())
                return null;

            for (int i = 0; (i <= (_listeParametre.Count - 1)); i = (i + 3))
            {
                phrase = new ArrayList();
                phrase.Add(_listeParametre[i]);
                phrase.Add(_listeParametre[(i + 1)]);
                phrase.Add(_listeParametre[(i + 2)]);
                construct.Add(phrase.ToArray());
            }
            return construct.ToArray();
        }

        private Array arrayToNextCond(int numCond, ref string lastOperator)
        {
            int lastIndex = 0;
            List<object> listeCondition = new List<Object>();
            lastOperator = "";
            for (int i = 0; (i <= (_listeParametre.Count - 1)); i++)
            {
                if (((_listeParametre[i].GetType() == typeof(string))
                            && (((string)_listeParametre[i] == OPERATEUR_ET)
                            || (((string)_listeParametre[i] == OPERATEUR_OU)
                            || ((string)_listeParametre[i] == OPERATEUR_NON)))))
                {
                    lastOperator = (string)_listeParametre[i];
                    if ((lastIndex == numCond))
                        break;

                    lastIndex++;
                }
                else if ((lastIndex == numCond))
                    listeCondition.Add(_listeParametre[i]);
            }
            return listeCondition.ToArray();
        }

        /// <summary>
        /// Ajoute la condition 'nomChamp=valeur'
        /// </summary>
        /// <param name="nomChamp">Nom du champ</param>
        /// <param name="valeur">Valeur du champ</param>
        /// <remarks></remarks>
        public void addEqualTo(string nomChamp, object valeur)
        {
            ajouteOperateur(nomChamp, "=", valeur);
        }
        /// <summary>
        /// Ajoute la condition 'nomChamp inférieur à valeur'
        /// </summary>
        /// <param name="nomChamp">Nom du champ</param>
        /// <param name="valeur">Valeur du champ</param>
        /// <remarks></remarks>
        public void addLessThan(string nomChamp, object valeur)
        {
            ajouteOperateur(nomChamp, "<", valeur);
        }
        /// <summary>
        /// Ajoute la condition 'nomChamp supérieur à valeur'
        /// </summary>
        /// <param name="nomChamp">Nom du champ</param>
        /// <param name="valeur">Valeur du champ</param>
        /// <remarks></remarks>
        public void addGreaterThan(string nomChamp, object valeur)
        {
            ajouteOperateur(nomChamp, ">", valeur);
        }
        /// <summary>
        /// Ajoute la condition 'nomChamp inférieur ou égal à valeur'
        /// </summary>
        /// <param name="nomChamp">Nom du champ</param>
        /// <param name="valeur">Valeur du champ</param>
        /// <remarks></remarks>
        public void addLessOrEqualTo(string nomChamp, object valeur)
        {
            ajouteOperateur(nomChamp, "<=", valeur);
        }
        /// <summary>
        /// Ajoute la condition 'nomChamp supérieur ou égal à valeur'
        /// </summary>
        /// <param name="nomChamp">Nom du champ</param>
        /// <param name="valeur">Valeur du champ</param>
        /// <remarks></remarks>
        public void addGreaterOrEqualTo(string nomChamp, object valeur)
        {
            ajouteOperateur(nomChamp, ">=", valeur);
        }
        /// <summary>
        /// Ajoute la condition 'nomChamp différent de valeur'
        /// </summary>
        /// <param name="nomChamp">Nom du champ</param>
        /// <param name="valeur">Valeur du champ</param>
        /// <remarks></remarks>
        public void addDifferentTo(string nomChamp, object valeur)
        {
            ajouteOperateur(nomChamp, "<>", valeur);
        }
        /// <summary>
        /// Ajoute la condition 'nomChamp like valeur'
        /// </summary>
        /// <param name="nomChamp">Nom du champ</param>
        /// <param name="valeur">Valeur du champ</param>
        /// <remarks></remarks>
        public void addLike(string nomChamp, object valeur)
        {
            ajouteOperateur(nomChamp, "like", valeur);
        }
        /// <summary>
        /// Ajoute la condition 'nomChamp not like valeur'
        /// </summary>
        /// <param name="nomChamp">Nom du champ</param>
        /// <param name="valeur">Nom du champ</param>
        /// <remarks></remarks>
        public void addNotLike(string nomChamp, object valeur)
        {
            ajouteOperateur(nomChamp, "not like", valeur);
        }
        /// <summary>
        /// Ajoute la condition 'nomChamp in (valeur)'
        /// </summary>
        /// <param name="nomChamp">Nom du champ</param>
        /// <param name="valeur">Valeur du champ. Peut être plusieurs valeurs séparées par des virgules</param>
        /// <remarks></remarks>
        public void addIn(string nomChamp, object valeur)
        {
            ajouteOperateur(nomChamp, "in", valeur);
        }
        /// <summary>
        /// Ajoute la condition 'nomChamp not in (valeur)'
        /// </summary>
        /// <param name="nomChamp">Nom du champ</param>
        /// <param name="valeur">Valeur du champ. Peut être plusieurs valeurs séparées par des virgules</param>
        /// <remarks></remarks>
        public void addNotIn(string nomChamp, object valeur)
        {
            ajouteOperateur(nomChamp, "not in", valeur);
        }
        /// <summary>
        /// Undocumented yet
        /// </summary>
        /// <param name="nomChamp"></param>
        /// <param name="valeur"></param>
        /// <remarks></remarks>
        public void addChildOf(string nomChamp, object valeur)
        {
            ajouteOperateur(nomChamp, "child_of", valeur);
        }
        /// <summary>
        /// Ajoute l'opérateur ET pour pouvoir ensuite ajouter une autre condition
        /// </summary>
        /// <remarks></remarks>
        public void addAND()
        {
            initListe();
            _listeParametre.Add(OPERATEUR_ET);
        }
        /// <summary>
        /// Ajoute l'opérateur OU pour pouvoir ensuite ajouter une autre condition
        /// </summary>
        /// <remarks></remarks>
        public void addOR()
        {
            initListe();
            _listeParametre.Add(OPERATEUR_OU);
        }
        /// <summary>
        /// Ajoute l'opérateur NOT pour pouvoir ensuite ajouter une autre conditions
        /// </summary>
        /// <remarks></remarks>
        public void addNOT()
        {
            initListe();
            _listeParametre.Add(OPERATEUR_NON);
        }
        /// <summary>
        /// Ajoute la condition 'nomChamp ilike 'valeur'
        /// Comme like mais ne prend pas en compte la casse de la valeur
        /// </summary>
        /// <param name="nomChamp">Nom du champ</param>
        /// <param name="valeur">Valeur du champ</param>
        /// <remarks></remarks>
        public void addIlike(string nomChamp, object valeur)
        {
            ajouteOperateur(nomChamp, "ilike", valeur);
        }
        /// <summary>
        /// Ajoute la condition 'nomChamp not ilike 'valeur'
        /// Comme like mais ne prend pas en compte la casse de la valeur
        /// </summary>
        /// <param name="nomChamp">Nom du champ</param>
        /// <param name="valeur">Valeur du champ</param>
        /// <remarks></remarks>
        public void addNotIlike(string nomChamp, object valeur)
        {
            ajouteOperateur(nomChamp, "not ilike", valeur);
        }

        /// <summary>
        /// Supprime une condition de la requete. Une condition est un ensemble de 3 valeurs : le nom du champ, l'opérateur, la valeur du champ.
        /// Cette fonction ne doit pas être utilisée pour supprimer uniquement une seule valeur. Utilisez supprimeParam pour cela.
        /// </summary>
        /// <param name="name">Nom du champ de la condition à supprimer</param>
        /// <param name="value">Valeur du champ pour identifier la condition à supprimer si toutefois il y a plusieurs conditions portant sur un même champ. Si il y a plusieurs conditions pour ce champ mais qu'aucune valeur n'est renseigné, il ne supprimera que la première qu'il trouve, la premiere ajoutée en premier</param>
        /// <remarks></remarks>
        public void deleteCondition(string name, object value)
        {
            int i;
            bool confirmSuppr = true;
            if (_listeParametre != null)
            {
                i = 0;
                foreach (string p in _listeParametre)
                {
                    if (p == name)
                    {
                        confirmSuppr = true;
                        if (value != null)
                        {
                            if (_listeParametre[(i + 2)] != value)
                                confirmSuppr = false;
                        }
                        if (confirmSuppr)
                        {
                            _listeParametre.RemoveRange(i, 3);
                            break;
                        }
                    }
                    i++;
                }
            }
        }
        //  INFO : operateur "=like" non documenté, et donc absent de cette classe
        public void ajouteOperateur(string nomChamps, string operateur, object valeur)
        {
            initListe();
            _listeParametre.Add(nomChamps);
            _listeParametre.Add(operateur);
            _listeParametre.Add(valeur);
            
        }

        /// <summary>
        /// Ajoute toute une requête à la requête en cours
        /// </summary>
        /// <param name="req"></param>
        /// <param name="operateur"></param>
        public void addQuery(aQuery req, OPERATORS operateur)
        {
            if ((req == null) || (req.listParameters().Count == 0))
                return;

            switch (operateur)
            {
                case OPERATORS.AND:
                    addAND();
                    break;
                case OPERATORS.NOT:
                    addNOT();
                    break;
                case OPERATORS.OR:
                    addOR();
                    break;
            }
            foreach (string val in req.listParameters())
                addParameter(val);
        }
    }
}
