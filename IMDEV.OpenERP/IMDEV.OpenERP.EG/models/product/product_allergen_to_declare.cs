using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IMDEV.OpenERP.models.@base;
using IMDEV.OpenERP.models.fields.relations;

namespace IMDEV.OpenERP.EG.models.product
{
    public class product_allergen_to_declare : anOpenERPObject
    {
        public string comment
        {
            get { return (string)listProperties.value("comment", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("comment", value); }
        }

        private manyToOne _f_name = new manyToOne(); //list.allergen
        public manyToOne name
        {
            get { return _f_name; }
        }

        private manyToOne _f_product_id = new manyToOne(); //product.product
        public manyToOne product_id
        {
            get { return _f_product_id; }
        }

        public int id
        {
            get { return (int)listProperties.value("id", aField.FIELD_TYPE.INTEGER); }
            set { listProperties.setValue("id", value); }
        }
        public override string resource_name()
        {
            return "product.allergen.to.declare";
        }
    }
}
