using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace IMDEV.OpenERP.models.fields.relations
{
    public class manyToMany : oneToMany {
        
        /// <summary>
        /// Order 3  of OpenERP. Remove the link to an object
        /// </summary>
        /// <param name="id">Id of the object to unlink</param>
        /// <remarks></remarks>
        public void removeLink(int id)
        {
            ArrayList ordre;
            if (orderExist(ORDERS.REMOVE_LINK, id)) {
                return;
            }
            ordre = createOrder(ORDERS.REMOVE_LINK);
            ordre.Add(id);
        }
        
        /// <summary>
        /// Order 3  of OpenERP. Remove the link to a list of objects
        /// </summary>
        /// <param name="listId">List of id of objects to unlink</param>
        /// <remarks></remarks>
        public void removeLink(List<int> listId)
        {
            foreach (int id in listId)
                removeLink(id);
        }
        
        /// <summary>
        /// Order 3  of OpenERP. Remove the link to a list of objects
        /// </summary>
        /// <param name="listId">List of id of objects to unlink</param>
        /// <remarks></remarks>
        public void removeLink(ArrayList listId)
        {
            foreach (int id in listId)
                removeLink(id);
        }
        
        /// <summary>
        /// Order 4 of OpenERP. Add link to an existing object
        /// </summary>
        /// <param name="id">Id of object to link</param>
        /// <remarks></remarks>
        public void addLink(int id)
        {
            ArrayList ordre;
            if (orderExist(ORDERS.ADD_LINK, id))
                return;

            ordre = createOrder(ORDERS.ADD_LINK);
            ordre.Add(id);
        }
        
        /// <summary>
        /// Order 4 of OpenERP. Add links to a list of existing objects
        /// </summary>
        /// <param name="listId">List of Id of objects to link</param>
        /// <remarks></remarks>
        public void addLink(List<int> listId)
        {
            foreach (int id in listId)
                addLink(id);
        }
        
        /// <summary>
        /// Order 4 of OpenERP. Add links to a list of existing objects
        /// </summary>
        /// <param name="listId">List of Id of objects to link</param>
        /// <remarks></remarks>
        public void addLink(ArrayList listId)
        {
            foreach (int id in listId)
                addLink(id);
        }
        
        /// <summary>
        /// Order 5 of OpenERP. Remove all current link of this object
        /// </summary>
        /// <remarks></remarks>
        public void removeAllLinks()
        {
            getOrder(ORDERS.REMOVE_ALL_LINK);
        }
        
        /// <summary>
        /// Order 6 of OpenERP. Set the link to an existing object
        /// </summary>
        /// <param name="id">id of object to link</param>
        /// <remarks></remarks>
        public void setLink(int id)
        {
            ArrayList ordre;
            ArrayList listId = new ArrayList();
            ordre = getOrder(ORDERS.SET_LINK);
            if ((ordre.Count == 1)) {
                ordre.Add(0);
                listId.Add(id);
                ordre.Add(listId);
            }
            else
            {
                ((ArrayList)(ordre[2])).Add(id);
            }
        }
        
        /// <summary>
        /// Order 6 of OpenERP. Set the link to a list of existing objects
        /// </summary>
        /// <param name="listId">List of Id of objects to link</param>
        /// <remarks></remarks>
        public void setLink(List<int> listId)
        {
            foreach (int id in listId)
                setLink(id);
        }
        
        /// <summary>
        /// Order 6 of OpenERP. Set the link to a list of existing objects
        /// </summary>
        /// <param name="listId">List of Id of objects to link</param>
        /// <remarks></remarks>
        public void setLink(ArrayList listId)
        {
            foreach (int id in listId)
                setLink(id);
        }
    }
}
