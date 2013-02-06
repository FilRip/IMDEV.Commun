using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IMDEV.OpenERP.models.@base;
using IMDEV.OpenERP.models.fields.relations;

namespace IMDEV.OpenERP.EG.models.product
{
    public class product_category : anOpenERPObject
    {
        private manyToOne _f_property_account_expense_categ = new manyToOne(); //account.account
        public manyToOne property_account_expense_categ
        {
            get { return _f_property_account_expense_categ; }
        }

        private manyToOne _f_property_stock_journal = new manyToOne(); //account.journal
        public manyToOne property_stock_journal
        {
            get { return _f_property_stock_journal; }
        }

        public string code
        {
            get { return (string)listProperties.value("code", aField.FIELD_TYPE.CHAR); }
        }

        private manyToOne _f_intrastat_id = new manyToOne(); //report.intrastat.code
        public manyToOne intrastat_id
        {
            get { return _f_intrastat_id; }
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

        public int sequence
        {
            get { return (int)listProperties.value("sequence", aField.FIELD_TYPE.INTEGER); }
            set { listProperties.setValue("sequence", value); }
        }

        private manyToOne _f_property_stock_account_input_categ = new manyToOne(); //account.account
        public manyToOne property_stock_account_input_categ
        {
            get { return _f_property_stock_account_input_categ; }
        }

        private manyToOne _f_company_id = new manyToOne(); //res.company
        public manyToOne company_id
        {
            get { return _f_company_id; }
        }

        private manyToOne _f_parent_id = new manyToOne(); //product.category
        public manyToOne parent_id
        {
            get { return _f_parent_id; }
        }

        public string complete_name
        {
            get { return (string)listProperties.value("complete_name", aField.FIELD_TYPE.CHAR); }
        }

        private manyToOne _f_property_stock_variation = new manyToOne(); //account.account
        public manyToOne property_stock_variation
        {
            get { return _f_property_stock_variation; }
        }

        private manyToOne _f_property_account_income_categ = new manyToOne(); //account.account
        public manyToOne property_account_income_categ
        {
            get { return _f_property_account_income_categ; }
        }

        public bool visible_tier_software
        {
            get { return (bool)listProperties.value("visible_tier_software", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("visible_tier_software", value); }
        }

        public enum ENUM_TYPE
        {
            NULL
            ,
            @normal
                , @view
        }
        private string[] _frv_type = new string[] { "NULL", "normal", "view" };
        private string[] _fl_type = new string[] { "NULL", "Normal", "View" };
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

        private oneToMany _f_child_id = new oneToMany(); //product.category
        public oneToMany child_id
        {
            get { return _f_child_id; }
        }

        private manyToOne _f_property_stock_account_output_categ = new manyToOne(); //account.account
        public manyToOne property_stock_account_output_categ
        {
            get { return _f_property_stock_account_output_categ; }
        }

        public bool fret
        {
            get { return (bool)listProperties.value("fret", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("fret", value); }
        }

        public int id
        {
            get { return (int)listProperties.value("id", aField.FIELD_TYPE.INTEGER); }
            set { listProperties.setValue("id", value); }
        }
        public override string resource_name()
        {
            return "product.category";
        }
    }
}
