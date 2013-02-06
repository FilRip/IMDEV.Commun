using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IMDEV.OpenERP.models.@base;
using IMDEV.OpenERP.models.fields.relations;

namespace IMDEV.OpenERP.EG.models.res
{
    public class res_partner_address : anOpenERPObject
    {
        public string website
        {
            get { return (string)listProperties.value("website", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("website", value); }
        }

        public string street
        {
            get { return (string)listProperties.value("street", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("street", value); }
        }

        private manyToOne _f_partner_id = new manyToOne();
        public manyToOne partner_id
        {
            get { return _f_partner_id; }
        }

        public string city
        {
            get { return (string)listProperties.value("city", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("city", value); }
        }

        private manyToOne _f_job_id = new manyToOne();
        public manyToOne job_id
        {
            get { return _f_job_id; }
        }

        public string zip
        {
            get { return (string)listProperties.value("zip", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("zip", value); }
        }

        private manyToOne _f_title = new manyToOne();
        public manyToOne title
        {
            get { return _f_title; }
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

        public enum ENUM_TYPE
        {
            NULL
            ,
            @default
                ,
            @contact
                ,
            @head
                ,
            @delivery
                ,
            @shipment
                ,
            @other
                , @invoice
        }
        private string[] _frv_type = new string[] { "NULL", "default", "contact", "head", "delivery", "shipment", "other", "invoice" };
        private string[] _fl_type = new string[] { "NULL", "Default", "Contact", "Head office", "Delivery", "Shipment", "Other", "Invoice" };
        private ENUM_TYPE _fv_type;
        public ENUM_TYPE type
        {
            get { return _fv_type; }
            set { _fv_type = value; }
        }
        public string LIBELLE_type
        {
            get { return _fl_type[(int)_fv_type]; }
        }

        public string email
        {
            get { return (string)listProperties.value("email", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("email", value); }
        }

        public string function
        {
            get { return (string)listProperties.value("function", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("function", value); }
        }

        public string fax
        {
            get { return (string)listProperties.value("fax", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("fax", value); }
        }

        public string street2
        {
            get { return (string)listProperties.value("street2", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("street2", value); }
        }

        public string phone
        {
            get { return (string)listProperties.value("phone", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("phone", value); }
        }

        public bool active
        {
            get { return (bool)listProperties.value("active", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("active", value); }
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

        public string mobile
        {
            get { return (string)listProperties.value("mobile", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("mobile", value); }
        }

        public bool is_customer_add
        {
            get { return (bool)listProperties.value("is_customer_add", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("is_customer_add", value); }
        }

        public string birthdate
        {
            get { return (string)listProperties.value("birthdate", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("birthdate", value); }
        }

        private manyToOne _f_state_id = new manyToOne();
        public manyToOne state_id
        {
            get { return _f_state_id; }
        }

        public bool is_supplier_add
        {
            get { return (bool)listProperties.value("is_supplier_add", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("is_supplier_add", value); }
        }

        public int id
        {
            get { return (int)listProperties.value("id", aField.FIELD_TYPE.INTEGER); }
            set { listProperties.setValue("id", value); }
        }
        public override string resource_name()
        {
            return "res.partner.address";
        }
    }
}
