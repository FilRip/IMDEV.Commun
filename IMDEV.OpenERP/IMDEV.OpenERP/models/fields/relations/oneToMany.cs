using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace IMDEV.OpenERP.models.fields.relations
{
    public class oneToMany : manyToOne
    {
        protected enum ORDERS : int
        {
            CREATE_AND_LINK = 0,
            UPDATE_LINKED = 1,
            DEL_LINK_AND_OBJ = 2,
            REMOVE_LINK = 3,
            ADD_LINK = 4,
            REMOVE_ALL_LINK = 5,
            SET_LINK = 6,
        }
        
        protected ArrayList _listeOrdres = new ArrayList();
        
        /// <summary>
        /// Order 0 of OpenERP. Create the object with specified properties and link it to this object
        /// </summary>
        /// <param name="champs">List of properties to create, linked object</param>
        /// <remarks></remarks>
        public void createAndLink(models.@base.listProperties champs)
        {
            ArrayList ordre;
            ordre = createOrder(ORDERS.CREATE_AND_LINK);
            ordre.Add(0);
            ordre.Add(champs.toArray());
        }
        
        /// <summary>
        /// Order 0 of OpenERP. Create the object and link it to this object
        /// </summary>
        /// <param name="objet">Object to create, linked to this object</param>
        /// <remarks></remarks>
        public void createAndLink(models.@base.anOpenERPObject objet)
        {
            ArrayList ordre;
            ordre = createOrder(ORDERS.CREATE_AND_LINK);
            ordre.Add(0);
            ordre.Add(objet.toXmlRpc());
        }
        
        /// <summary>
        /// Order 1 of OpenERP. Update fields of a linked object
        /// </summary>
        /// <param name="id">Id of the linked object</param>
        /// <param name="champs">New values of fields</param>
        /// <remarks></remarks>
        public void updateLinked(int id, models.@base.listProperties champs)
        {
            ArrayList ordre;
            ordre = createOrder(ORDERS.UPDATE_LINKED);
            ordre.Add(id);
            ordre.Add(champs.toArray());
        }
        
        /// <summary>
        /// Order 1 of OpenERP. Update the linked object
        /// </summary>
        /// <param name="id">Id of the object</param>
        /// <param name="objet">New values of object</param>
        /// <remarks></remarks>
        public void updateLinked(int id, models.@base.anOpenERPObject objet)
        {
            ArrayList ordre;
            ordre = createOrder(ORDERS.UPDATE_LINKED);
            ordre.Add(id);
            ordre.Add(objet.toXmlRpc());
        }
        
        /// <summary>
        /// Order 2. Delete a link to an object, and delete the object too
        /// </summary>
        /// <param name="id">Id of the object</param>
        /// <remarks></remarks>
        public void delLinkAndObj(int id)
        {
            ArrayList ordre;
            if (orderExist(ORDERS.DEL_LINK_AND_OBJ, id))
                return;

            ordre = createOrder(ORDERS.DEL_LINK_AND_OBJ);
            ordre.Add(id);
        }
        
        /// <summary>
        /// Order 2. Delete a list of linked objects, and delete the objects too
        /// </summary>
        /// <param name="listId">List of Id of object to delete</param>
        /// <remarks></remarks>
        public void delLinkAndObj(List<int> listId)
        {
            foreach (int id in listId)
                delLinkAndObj(id);
        }
        
        /// <summary>
        /// Order 2. Delete a list of linked objects, and delete the objects too
        /// </summary>
        /// <param name="listId">List of Id of object to delete</param>
        /// <remarks></remarks>
        public void delLinkAndObj(ArrayList listId)
        {
            foreach (int id in listId)
                delLinkAndObj(id);
        }
        
        protected ArrayList createOrder(ORDERS numOrdre)
        {
            ArrayList ordre = new ArrayList();
            ordre.Add((int)numOrdre);
            _listeOrdres.Add(ordre);
            return ordre;
        }
        
        protected bool orderExist(ORDERS numOrdre, int id)
        {
            foreach (ArrayList ordrePresent in listOrder(numOrdre))
                if ((int)ordrePresent[1] == id)
                    return true;

            return false;
        }
        
        protected ArrayList getOrder(ORDERS numOrdre)
        {
            return getOrder(numOrdre,0);
        }
        protected ArrayList getOrder(ORDERS numOrdre, int complement)
        {
            foreach (ArrayList ordre in _listeOrdres)
                if (((int)ordre[0] == (int)numOrdre))
                    if (((complement == 0) || ((int)ordre[1] == complement)))
                        return ordre;

            return createOrder(numOrdre);
        }

        protected ArrayList listOrder(ORDERS numOrdre)
        {
            ArrayList retour = new ArrayList();
            foreach (ArrayList ordre in _listeOrdres)
                if (((int)ordre[0] == (int)numOrdre))
                    retour.Add(ordre);

            return retour;
        }

        [Obsolete("This type of field doesn't not support this type of set. You must use the orders instead. This type of set 'setValue' is only available for manyToOne type of field.",true)]
        public new void setValue(int id)
        {
 	        base.setValue(id);
        }

        public new object toXmlRpc()
        {
            ArrayList sortie = new ArrayList();
            if ((_listeOrdres.Count > 0))
            {
                foreach (ArrayList obj in _listeOrdres)
                    sortie.Add(obj.ToArray());
                return sortie.ToArray();
            }
            return null;
        }

        /// <summary>
        /// Clear all current orders
        /// </summary>
        /// <remarks></remarks>
        public void clearOrders()
        {
            _listeOrdres.Clear();
        }

        /// <summary>
        /// Retourne vrai si l'ID fourni en parametre est deja present dans la liste, sinon False
        /// </summary>
        /// <param name="id">ID à rechercher dans la liste</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public bool isInList(int id)
        {
            if (_liste!=null)
                foreach (object idin in _liste)
                    if ((idin.GetType() == typeof(int)))
                        if ((int)idin == id)
                            return true;

            return false;
        }
    }
}
