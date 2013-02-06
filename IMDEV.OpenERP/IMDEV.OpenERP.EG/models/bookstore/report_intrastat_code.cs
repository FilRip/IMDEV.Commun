using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IMDEV.OpenERP.models.@base;
using IMDEV.OpenERP.models.fields.relations;

namespace IMDEV.OpenERP.EG.models.bookstore
{
    public class report_intrastat_code : anOpenERPObject
    {
        private manyToMany _f_tax_ids = new manyToMany(); //account.tax
        public manyToMany tax_ids
        {
            get { return _f_tax_ids; }
        }

        public string intrastat_code
        {
            get { return (string)listProperties.value("intrastat_code", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("intrastat_code", value); }
        }

        public string description
        {
            get { return (string)listProperties.value("description", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("description", value); }
        }

        private manyToOne _f_intrastat_uom_id = new manyToOne(); //product.uom
        public manyToOne intrastat_uom_id
        {
            get { return _f_intrastat_uom_id; }
        }

        public string name
        {
            get { return (string)listProperties.value("name", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("name", value); }
        }

        public int id
        {
            get { return (int)listProperties.value("id", aField.FIELD_TYPE.INTEGER); }
            set { listProperties.setValue("id", value); }
        }
        public override string resource_name()
        {
            return "report.intrastat.code";
        }
    }
}
