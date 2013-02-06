using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IMDEV.OpenERP.models.@base;
using IMDEV.OpenERP.models.fields.relations;

namespace IMDEV.OpenERP.EG.models.product
{
    public class product_risk_technology : anOpenERPObject
    {
        private manyToOne _f_risk_id = new manyToOne(); //list.risk.technology
        public manyToOne risk_id
        {
            get { return _f_risk_id; }
        }

        private manyToOne _f_name = new manyToOne(); //res.partner
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
            return "product.risk.technology";
        }
    }
}
