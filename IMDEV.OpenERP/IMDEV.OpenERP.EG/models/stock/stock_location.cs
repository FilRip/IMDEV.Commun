using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IMDEV.OpenERP.models.@base;
using IMDEV.OpenERP.models.fields.relations;

namespace IMDEV.OpenERP.EG.models.stock
{
    public class stock_location : anOpenERPObject
    {
        public string comment
        {
            get { return (string)listProperties.value("comment", aField.FIELD_TYPE.TEXT); }
            set { listProperties.setValue("comment", value); }
        }

        private manyToOne _f_address_id = new manyToOne(); //res.partner.address
        public manyToOne address_id
        {
            get { return _f_address_id; }
        }

        public string code
        {
            get { return (string)listProperties.value("code", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("code", value); }
        }

        public bool check_type
        {
            get { return (bool)listProperties.value("check_type", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("check_type", value); }
        }

        public int sequence
        {
            get { return (int)listProperties.value("sequence", aField.FIELD_TYPE.INTEGER); }
            set { listProperties.setValue("sequence", value); }
        }

        public double stock_virtual_value
        {
            get { return (double)listProperties.value("stock_virtual_value", aField.FIELD_TYPE.FLOAT); }
        }

        private manyToOne _f_chained_company_id = new manyToOne(); //res.company
        public manyToOne chained_company_id
        {
            get { return _f_chained_company_id; }
        }

        public string intrastat_department
        {
            get { return (string)listProperties.value("intrastat_department", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("intrastat_department", value); }
        }

        private manyToOne _f_ul_id = new manyToOne(); //product.ul
        public manyToOne ul_id
        {
            get { return _f_ul_id; }
        }

        public string type_text
        {
            get { return (string)listProperties.value("type_text", aField.FIELD_TYPE.CHAR); }
        }

        private manyToOne _f_valuation_in_account_id = new manyToOne(); //account.account
        public manyToOne valuation_in_account_id
        {
            get { return _f_valuation_in_account_id; }
        }

        public double qty_available
        {
            get { return (double)listProperties.value("qty_available", aField.FIELD_TYPE.FLOAT); }
        }

        private manyToOne _f_location_id = new manyToOne(); //stock.location
        public manyToOne location_id
        {
            get { return _f_location_id; }
        }

        public bool is_silo
        {
            get { return (bool)listProperties.value("is_silo", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("is_silo", value); }
        }

        public bool scrap_location
        {
            get { return (bool)listProperties.value("scrap_location", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("scrap_location", value); }
        }

        public double max_weigth
        {
            get { return (double)listProperties.value("max_weigth", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("max_weigth", value); }
        }

        private manyToOne _f_chained_location_id = new manyToOne(); //stock.location
        public manyToOne chained_location_id
        {
            get { return _f_chained_location_id; }
        }

        private manyToOne _f_chained_journal_id = new manyToOne(); //stock.journal
        public manyToOne chained_journal_id
        {
            get { return _f_chained_journal_id; }
        }

        private manyToOne _f_company_id = new manyToOne(); //res.company
        public manyToOne company_id
        {
            get { return _f_company_id; }
        }

        public string name
        {
            get { return (string)listProperties.value("name", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("name", value); }
        }
        private IMDEV.OpenERP.models.fields.texteMultilangue _name_multilangue;
        public IMDEV.OpenERP.models.fields.texteMultilangue name_multilangue
        {
            get
            {
                if (_name_multilangue == null) _name_multilangue = new IMDEV.OpenERP.models.fields.texteMultilangue(this, "name");
                return _name_multilangue;
            }
        }

        public string complete_name
        {
            get { return (string)listProperties.value("complete_name", aField.FIELD_TYPE.CHAR); }
        }

        public enum ENUM_USAGE
        {
            NULL
            ,
            @inventory
                ,
            @customer
                ,
            @transit
                ,
            @production
                ,
            @supplier
                ,
            @internal
                ,
            @view
                , @procurement
        }
        private string[] _frv_usage = new string[] { "NULL", "inventory", "customer", "transit", "production", "supplier", "internal", "view", "procurement" };
        private string[] _fl_usage = new string[] { "NULL", "Inventory", "Customer Location", "Transit Location for Inter-Companies Transfers", "Production", "Supplier Location", "Internal Location", "View", "Procurement" };
        private ENUM_USAGE _fv_usage;
        public ENUM_USAGE usage
        {
            get { return _fv_usage; }
            set { _fv_usage = value; }
        }
        public string LIBELLE_usage
        {
            get { return _fl_usage[(int)_fv_usage]; }
        }

        public double stock_real_value
        {
            get { return (double)listProperties.value("stock_real_value", aField.FIELD_TYPE.FLOAT); }
        }

        public enum ENUM_CHAINED_LOCATION_TYPE
        {
            NULL
            ,
            @fixed
                ,
            @none
                , @customer
        }
        private string[] _frv_chained_location_type = new string[] { "NULL", "fixed", "none", "customer" };
        private string[] _fl_chained_location_type = new string[] { "NULL", "Fixed Location", "None", "Customer" };
        private ENUM_CHAINED_LOCATION_TYPE _fv_chained_location_type;
        public ENUM_CHAINED_LOCATION_TYPE chained_location_type
        {
            get { return _fv_chained_location_type; }
            set { _fv_chained_location_type = value; }
        }
        public string LIBELLE_chained_location_type
        {
            get { return _fl_chained_location_type[(int)_fv_chained_location_type]; }
        }

        public int id
        {
            get { return (int)listProperties.value("id", aField.FIELD_TYPE.INTEGER); }
            set { listProperties.setValue("id", value); }
        }
        public override string resource_name()
        {
            return "stock.location";
        }
    }
}
