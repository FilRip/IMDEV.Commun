using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IMDEV.OpenERP.models.@base;
using IMDEV.OpenERP.models.fields.relations;

namespace IMDEV.OpenERP.EG.models.res
{
    public class res_partner_contact : anOpenERPObject
    {
        public string website
        {
            get { return (string)listProperties.value("website", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("website", value); }
        }

        public string function
        {
            get { return (string)listProperties.value("function", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("function", value); }
        }

        public string first_name
        {
            get { return (string)listProperties.value("first_name", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("first_name", value); }
        }

        private manyToOne _f_job_id = new manyToOne();
        public manyToOne job_id
        {
            get { return _f_job_id; }
        }

        private manyToOne _f_title = new manyToOne();
        public manyToOne title
        {
            get { return _f_title; }
        }

        public string mobile
        {
            get { return (string)listProperties.value("mobile", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("mobile", value); }
        }

        public byte[] photo
        {
            get { return (byte[])listProperties.value("photo", aField.FIELD_TYPE.BINARY); }
            set { listProperties.setValue("photo", value); }
        }

        private manyToOne _f_country_id = new manyToOne();
        public manyToOne country_id
        {
            get { return _f_country_id; }
        }

        private manyToOne _f_company_id = new manyToOne();
        public manyToOne company_id
        {
            get { return _f_company_id; }
        }

        public string comment
        {
            get { return (string)listProperties.value("comment", aField.FIELD_TYPE.TEXT); }
            set { listProperties.setValue("comment", value); }
        }
        private IMDEV.OpenERP.models.fields.texteMultilangue _comment_multilangue;
        public IMDEV.OpenERP.models.fields.texteMultilangue comment_multilangue
        {
            get
            {
                if (_comment_multilangue == null) _comment_multilangue = new IMDEV.OpenERP.models.fields.texteMultilangue(this, "comment");
                return _comment_multilangue;
            }
        }

        public string email
        {
            get { return (string)listProperties.value("email", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("email", value); }
        }

        private manyToOne _f_lang_id = new manyToOne();
        public manyToOne lang_id
        {
            get { return _f_lang_id; }
        }

        public System.DateTime birthdate
        {
            get { return (System.DateTime)listProperties.value("birthdate", aField.FIELD_TYPE.DATE); }
            set { listProperties.setValue("birthdate", value); }
        }

        public bool active
        {
            get { return (bool)listProperties.value("active", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("active", value); }
        }

        public string function_id
        {
            get { return (string)listProperties.value("function_id", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("function_id", value); }
        }

        private manyToOne _f_partner_id = new manyToOne();
        public manyToOne partner_id
        {
            get { return _f_partner_id; }
        }

        private oneToMany _f_job_ids = new oneToMany();
        public oneToMany job_ids
        {
            get { return _f_job_ids; }
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
            return "res.partner.contact";
        }
    }
}
