using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IMDEV.OpenERP.models.@base
{
    
    public class aLanguage : aKey {
        
        private string _id;
        
        public new string id {
            get { return _id; }
            set { _id = value; }
        }
    }
}
