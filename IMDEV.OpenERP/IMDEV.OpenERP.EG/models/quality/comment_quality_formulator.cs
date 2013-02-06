using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IMDEV.OpenERP.models.@base;
using IMDEV.OpenERP.models.fields.relations;

namespace IMDEV.OpenERP.EG.models.quality
{
    public class comment_quality_formulator : anOpenERPObject
    {
        public string customer_comment
        {
            get { return (string)listProperties.value("customer_comment", aField.FIELD_TYPE.TEXT); }
            set { listProperties.setValue("customer_comment", value); }
        }

        private manyToMany _f_child_ids = new manyToMany(); //res.partner
        public manyToMany child_ids
        {
            get { return _f_child_ids; }
        }

        public string directory_link
        {
            get { return (string)listProperties.value("directory_link", aField.FIELD_TYPE.CHAR); }
        }

        public string parent_customer_comment
        {
            get { return (string)listProperties.value("parent_customer_comment", aField.FIELD_TYPE.TEXT); }
            set { listProperties.setValue("parent_customer_comment", value); }
        }

        public System.DateTime create
        {
            get { return (System.DateTime)listProperties.value("create", aField.FIELD_TYPE.DATETIME); }
        }

        private manyToOne _f_partner_id = new manyToOne(); //res.partner
        public manyToOne partner_id
        {
            get { return _f_partner_id; }
        }

        public int id
        {
            get { return (int)listProperties.value("id", aField.FIELD_TYPE.INTEGER); }
        }

        public System.DateTime action_last
        {
            get { return (System.DateTime)listProperties.value("action_last", aField.FIELD_TYPE.DATETIME); }
        }

        public override string resource_name()
        {
            return "comment.quality.formulator";
        }
    }
}
