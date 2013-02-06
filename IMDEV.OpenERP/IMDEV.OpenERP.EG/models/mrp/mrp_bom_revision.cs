using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IMDEV.OpenERP.models.@base;
using IMDEV.OpenERP.models.fields.relations;

namespace IMDEV.OpenERP.EG.models.mrp
{
    public class mrp_bom_revision : anOpenERPObject
    {
        public string indice
        {
            get { return (string)listProperties.value("indice", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("indice", value); }
        }

        public string name
        {
            get { return (string)listProperties.value("name", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("name", value); }
        }

        private manyToOne _f_bom_id = new manyToOne(); //mrp.bom
        public manyToOne bom_id
        {
            get { return _f_bom_id; }
        }

        public string last_indice
        {
            get { return (string)listProperties.value("last_indice", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("last_indice", value); }
        }

        public System.DateTime date
        {
            get { return (System.DateTime)listProperties.value("date", aField.FIELD_TYPE.DATE); }
            set { listProperties.setValue("date", value); }
        }

        private manyToOne _f_author_id = new manyToOne(); //res.users
        public manyToOne author_id
        {
            get { return _f_author_id; }
        }

        public string description
        {
            get { return (string)listProperties.value("description", aField.FIELD_TYPE.TEXT); }
            set { listProperties.setValue("description", value); }
        }

        public int id
        {
            get { return (int)listProperties.value("id", aField.FIELD_TYPE.INTEGER); }
            set { listProperties.setValue("id", value); }
        }
        public override string resource_name()
        {
            return "mrp.bom.revision";
        }
    }
}
