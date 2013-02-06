using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IMDEV.OpenERP.models.@base
{
    
    public class aGenericObject : @base.anOpenERPObject {
        
        private string _nomRessource = "";
        
        public aGenericObject(string resourceName) {
            _nomRessource = resourceName;
        }
        
        public override string resource_name() {
            return _nomRessource;
        }
    }
}
