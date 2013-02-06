using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace IMDEV.OpenERP.models.fields.relations
{

    public class manyToOne
    {
        protected ArrayList _liste;
        private bool _isOrder;

        /// <summary>
        /// Get the actual relation
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public ArrayList getValue
        {
            get { return _liste; }
        }

        /// <summary>
        /// Get the id field in a manyToOne relation
        /// </summary>
        public int id
        {
            get
            {
                try
                {
                    return (int)_liste[0];
                }
                catch
                {
                    return 0;
                }
            }
        }

        /// <summary>
        /// Get the name field in a manyToOne relation
        /// </summary>
        public string name
        {
            get
            {
                try
                {
                    return (string)_liste[1];
                }
                catch
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Set the new id value for a manyToOne relation
        /// </summary>
        /// <param name="id">New id value</param>
        public virtual void setValue(int id)
        {
            if (_liste != null)
            {
                _liste.Clear();
            }
            _liste = new ArrayList();
            if ((id > 0))
            {
                _liste.Add(id);
            }
            else
            {
                _liste.Add(false);
            }
            _isOrder = true;
        }

        public object toXmlRpc()
        {
            if (!_isOrder)
            {
                return null;
            }
            return _liste[0];
        }

        public virtual void copyData(Array source)
        {
            if (_liste != null)
            {
                _liste.Clear();
            }
            _liste = new ArrayList();
            foreach (object Val in source)
            {
                _liste.Add(Val);
            }
        }

        public void copyData(int id)
        {
            if (_liste != null)
            {
                _liste.Clear();
            }
            _liste = new ArrayList();
            _liste.Add(id);
        }
    }
}
