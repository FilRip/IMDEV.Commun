using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IMDEV.OpenERP.models.@base
{
    
    public class aKey {
        
        private int _id;
        
        private string _libelle = "";
        
        public int id {
            get { return _id; }
            set { _id = value; }
        }
        
        public string name {
            get { return _libelle; }
            set { _libelle = value; }
        }
    }
}
