using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IMDEV.OpenERP.models.@base;
using IMDEV.OpenERP.models.fields.relations;

namespace IMDEV.OpenERP.EG.models.account
{
    public class account_tax : anOpenERPObject
    {
        public string domain
        {
            get { return (string)listProperties.value("domain", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("domain", value); }
        }

        private manyToOne _f_ref_tax_code_id = new manyToOne(); //account.tax.code
        public manyToOne ref_tax_code_id
        {
            get { return _f_ref_tax_code_id; }
        }

        public int sequence
        {
            get { return (int)listProperties.value("sequence", aField.FIELD_TYPE.INTEGER); }
            set { listProperties.setValue("sequence", value); }
        }

        public double base_sign
        {
            get { return (double)listProperties.value("base_sign", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("base_sign", value); }
        }

        public bool child_depend
        {
            get { return (bool)listProperties.value("child_depend", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("child_depend", value); }
        }

        public bool include_base_amount
        {
            get { return (bool)listProperties.value("include_base_amount", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("include_base_amount", value); }
        }

        public enum ENUM_APPLICABLE_TYPE
        {
            NULL
            ,
            @code
                , @true
        }
        private string[] _frv_applicable_type = new string[] { "NULL", "code", "true" };
        private string[] _fl_applicable_type = new string[] { "NULL", "Given by Python Code", "Always" };
        private ENUM_APPLICABLE_TYPE _fv_applicable_type;
        public ENUM_APPLICABLE_TYPE applicable_type
        {
            get { return _fv_applicable_type; }
            set { _fv_applicable_type = value; }
        }
        public string LIBELLE_applicable_type
        {
            get { return _fl_applicable_type[(int)_fv_applicable_type]; }
        }

        public double ref_tax_sign
        {
            get { return (double)listProperties.value("ref_tax_sign", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("ref_tax_sign", value); }
        }

        private manyToOne _f_ref_base_code_id = new manyToOne(); //account.tax.code
        public manyToOne ref_base_code_id
        {
            get { return _f_ref_base_code_id; }
        }

        private manyToOne _f_company_id = new manyToOne(); //res.company
        public manyToOne company_id
        {
            get { return _f_company_id; }
        }

        private manyToOne _f_tax_code_id = new manyToOne(); //account.tax.code
        public manyToOne tax_code_id
        {
            get { return _f_tax_code_id; }
        }

        private manyToOne _f_parent_id = new manyToOne(); //account.tax
        public manyToOne parent_id
        {
            get { return _f_parent_id; }
        }

        public string python_compute_inv
        {
            get { return (string)listProperties.value("python_compute_inv", aField.FIELD_TYPE.TEXT); }
            set { listProperties.setValue("python_compute_inv", value); }
        }

        public string python_applicable
        {
            get { return (string)listProperties.value("python_applicable", aField.FIELD_TYPE.TEXT); }
            set { listProperties.setValue("python_applicable", value); }
        }

        public enum ENUM_TYPE
        {
            NULL
            ,
            @code
                ,
            @fixed
                ,
            @percent
                ,
            @none
                , @balance
        }
        private string[] _frv_type = new string[] { "NULL", "code", "fixed", "percent", "none", "balance" };
        private string[] _fl_type = new string[] { "NULL", "Python Code", "Fixed Amount", "Percentage", "None", "Balance" };
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

        public double ref_base_sign
        {
            get { return (double)listProperties.value("ref_base_sign", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("ref_base_sign", value); }
        }

        public string description
        {
            get { return (string)listProperties.value("description", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("description", value); }
        }

        private oneToMany _f_child_ids = new oneToMany(); //account.tax
        public oneToMany child_ids
        {
            get { return _f_child_ids; }
        }

        public enum ENUM_TYPE_TAX_USE
        {
            NULL
            ,
            @purchase
                ,
            @all
                , @sale
        }
        private string[] _frv_type_tax_use = new string[] { "NULL", "purchase", "all", "sale" };
        private string[] _fl_type_tax_use = new string[] { "NULL", "Purchase", "All", "Sale" };
        private ENUM_TYPE_TAX_USE _fv_type_tax_use;
        public ENUM_TYPE_TAX_USE type_tax_use
        {
            get { return _fv_type_tax_use; }
            set { _fv_type_tax_use = value; }
        }
        public string LIBELLE_type_tax_use
        {
            get { return _fl_type_tax_use[(int)_fv_type_tax_use]; }
        }

        private manyToOne _f_base_code_id = new manyToOne(); //account.tax.code
        public manyToOne base_code_id
        {
            get { return _f_base_code_id; }
        }

        public bool active
        {
            get { return (bool)listProperties.value("active", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("active", value); }
        }

        private manyToOne _f_account_paid_id = new manyToOne(); //account.account
        public manyToOne account_paid_id
        {
            get { return _f_account_paid_id; }
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

        private manyToOne _f_account_collected_id = new manyToOne(); //account.account
        public manyToOne account_collected_id
        {
            get { return _f_account_collected_id; }
        }

        public bool exclude_from_intrastat_if_present
        {
            get { return (bool)listProperties.value("exclude_from_intrastat_if_present", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("exclude_from_intrastat_if_present", value); }
        }

        public double amount
        {
            get { return (double)listProperties.value("amount", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("amount", value); }
        }

        public string python_compute
        {
            get { return (string)listProperties.value("python_compute", aField.FIELD_TYPE.TEXT); }
            set { listProperties.setValue("python_compute", value); }
        }

        public double tax_sign
        {
            get { return (double)listProperties.value("tax_sign", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("tax_sign", value); }
        }

        public bool price_include
        {
            get { return (bool)listProperties.value("price_include", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("price_include", value); }
        }

        public int id
        {
            get { return (int)listProperties.value("id", aField.FIELD_TYPE.INTEGER); }
            set { listProperties.setValue("id", value); }
        }
        public override string resource_name()
        {
            return "account.tax";
        }
    }
}
