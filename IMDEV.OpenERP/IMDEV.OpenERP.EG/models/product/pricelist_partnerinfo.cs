using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IMDEV.OpenERP.models.@base;
using IMDEV.OpenERP.models.fields.relations;

namespace IMDEV.OpenERP.EG.models.product
{
    public class pricelist_partnerinfo : anOpenERPObject
    {
        private manyToOne _f_incoterm = new manyToOne(); //stock.incoterms
        public manyToOne incoterm
        {
            get { return _f_incoterm; }
        }

        public System.DateTime date_start
        {
            get { return (System.DateTime)listProperties.value("date_start", aField.FIELD_TYPE.DATE); }
            set { listProperties.setValue("date_start", value); }
        }

        public string name
        {
            get { return (string)listProperties.value("name", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("name", value); }
        }

        public double cost_delivery
        {
            get { return (double)listProperties.value("cost_delivery", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("cost_delivery", value); }
        }

        public double price
        {
            get { return (double)listProperties.value("price", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("price", value); }
        }

        private manyToOne _f_suppinfo_id = new manyToOne(); //product.supplierinfo
        public manyToOne suppinfo_id
        {
            get { return _f_suppinfo_id; }
        }

        public string note
        {
            get { return (string)listProperties.value("note", aField.FIELD_TYPE.TEXT); }
            set { listProperties.setValue("note", value); }
        }

        public System.DateTime date_end
        {
            get { return (System.DateTime)listProperties.value("date_end", aField.FIELD_TYPE.DATE); }
            set { listProperties.setValue("date_end", value); }
        }

        public double cost_taxes
        {
            get { return (double)listProperties.value("cost_taxes", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("cost_taxes", value); }
        }

        public double min_quantity
        {
            get { return (double)listProperties.value("min_quantity", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("min_quantity", value); }
        }

        public double cost_customs
        {
            get { return (double)listProperties.value("cost_customs", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("cost_customs", value); }
        }

        public double cost_total
        {
            get { return (double)listProperties.value("cost_total", aField.FIELD_TYPE.FLOAT); }
        }

        public int id
        {
            get { return (int)listProperties.value("id", aField.FIELD_TYPE.INTEGER); }
            set { listProperties.setValue("id", value); }
        }
        public override string resource_name()
        {
            return "pricelist.partnerinfo";
        }
    }
}
