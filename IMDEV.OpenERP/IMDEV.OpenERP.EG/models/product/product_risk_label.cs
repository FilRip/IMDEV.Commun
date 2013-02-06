using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IMDEV.OpenERP.models.@base;
using IMDEV.OpenERP.models.fields.relations;

namespace IMDEV.OpenERP.EG.models.product
{
    public class product_risk_label : anOpenERPObject
    {
        public string name
        {
            get { return (string)listProperties.value("name", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("name", value); }
        }

        public double pourcent_incorporation
        {
            get { return (double)listProperties.value("pourcent_incorporation", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("pourcent_incorporation", value); }
        }

        public string libelle
        {
            get { return (string)listProperties.value("libelle", aField.FIELD_TYPE.CHAR); }
        }

        private manyToOne _f_risk_id = new manyToOne(); //product.risk
        public manyToOne risk_id
        {
            get { return _f_risk_id; }
        }

        public byte[] logo
        {
            get { return (byte[])listProperties.value("logo", aField.FIELD_TYPE.BINARY); }
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
            return "product.risk.label";
        }
    }
}
