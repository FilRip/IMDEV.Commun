using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IMDEV.OpenERP.models.query
{
    public class baseQuery
    {
        protected List<object> _listeParametre = new List<Object>();

        /// <summary>
        /// Ajoute un paramètre/une valeur unique à la requête
        /// </summary>
        /// <param name="valeur">Valeur/paramètre à rajouter</param>
        /// <remarks></remarks>
        public void addParameter(object valeur)
        {
            initListe();
            _listeParametre.Add(valeur);
        }

        /// <summary>
        /// Supprime un paramètre unique ajouté précédemment
        /// </summary>
        /// <param name="valeur">La valeur/paramètre unique à supprimer</param>
        /// <remarks></remarks>
        public void deleteParameter(string valeur)
        {
            if (_listeParametre != null)
                foreach (string p in _listeParametre)
                    if ((p == valeur))
                    {
                        _listeParametre.Remove(p);
                        break;
                    }
        }

        /// <summary>
        /// Retourne la requête dans le format objet requis par le service xmlrpc de OpenERP pour la fonction 'read' (lire)
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        public Array toXmlRpc
        {
            get { return _listeParametre.ToArray(); }
        }

        public void deleteAll()
        {
            initListe();
            _listeParametre.Clear();
        }

        public List<object> listParameters()
        {
            return _listeParametre;
        }


        protected void initListe()
        {
            if ((_listeParametre == null))
                _listeParametre = new List<Object>();
        }
    }
}
