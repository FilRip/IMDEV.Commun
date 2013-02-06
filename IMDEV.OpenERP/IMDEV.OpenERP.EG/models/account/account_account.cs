using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IMDEV.OpenERP.EG.models.account
{
    using IMDEV.OpenERP.models.@base;
    using IMDEV.OpenERP.models.fields.relations;

    public class account_account : anOpenERPObject
    {
        public string code
        {
            get { return (string)listProperties.value("code", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("code", value); }
        }

        public bool reconcile
        {
            get { return (bool)listProperties.value("reconcile", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("reconcile", value); }
        }

        private manyToOne _f_user_type = new manyToOne(); //account.account.type
        public manyToOne user_type
        {
            get { return _f_user_type; }
        }

        private manyToOne _f_company_currency_id = new manyToOne(); //res.currency
        public manyToOne company_currency_id
        {
            get { return _f_company_currency_id; }
        }

        private manyToMany _f_child_id = new manyToMany(); //account.account
        public manyToMany child_id
        {
            get { return _f_child_id; }
        }

        public string note
        {
            get { return (string)listProperties.value("note", aField.FIELD_TYPE.TEXT); }
            set { listProperties.setValue("note", value); }
        }

        private manyToOne _f_company_id = new manyToOne(); //res.company
        public manyToOne company_id
        {
            get { return _f_company_id; }
        }

        public string shortcut
        {
            get { return (string)listProperties.value("shortcut", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("shortcut", value); }
        }

        private manyToMany _f_child_consol_ids = new manyToMany(); //account.account
        public manyToMany child_consol_ids
        {
            get { return _f_child_consol_ids; }
        }

        private manyToOne _f_parent_id = new manyToOne(); //account.account
        public manyToOne parent_id
        {
            get { return _f_parent_id; }
        }

        public double debit
        {
            get { return (double)listProperties.value("debit", aField.FIELD_TYPE.FLOAT); }
        }

        public enum ENUM_TYPE
        {
            NULL
            ,
            @liquidity
                ,
            @closed
                ,
            @receivable
                ,
            @payable
                ,
            @other
                ,
            @consolidation
                , @view
        }
        private string[] _frv_type = new string[] { "NULL", "liquidity", "closed", "receivable", "payable", "other", "consolidation", "view" };
        private string[] _fl_type = new string[] { "NULL", "Liquidity", "Closed", "Receivable", "Payable", "Regular", "Consolidation", "View" };
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

        private manyToMany _f_tax_ids = new manyToMany(); //account.tax
        public manyToMany tax_ids
        {
            get { return _f_tax_ids; }
        }

        private oneToMany _f_child_parent_ids = new oneToMany(); //account.account
        public oneToMany child_parent_ids
        {
            get { return _f_child_parent_ids; }
        }

        public bool active
        {
            get { return (bool)listProperties.value("active", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("active", value); }
        }

        private manyToOne _f_currency_id = new manyToOne(); //res.currency
        public manyToOne currency_id
        {
            get { return _f_currency_id; }
        }

        public int parent_right
        {
            get { return (int)listProperties.value("parent_right", aField.FIELD_TYPE.INTEGER); }
            set { listProperties.setValue("parent_right", value); }
        }

        public string name
        {
            get { return (string)listProperties.value("name", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("name", value); }
        }

        public int level
        {
            get { return (int)listProperties.value("level", aField.FIELD_TYPE.INTEGER); }
        }

        public double credit
        {
            get { return (double)listProperties.value("credit", aField.FIELD_TYPE.FLOAT); }
        }

        public int parent_left
        {
            get { return (int)listProperties.value("parent_left", aField.FIELD_TYPE.INTEGER); }
            set { listProperties.setValue("parent_left", value); }
        }

        public enum ENUM_CURRENCY_MODE
        {
            NULL
            ,
            @current
                , @average
        }
        private string[] _frv_currency_mode = new string[] { "NULL", "current", "average" };
        private string[] _fl_currency_mode = new string[] { "NULL", "At Date", "Average Rate" };
        private ENUM_CURRENCY_MODE _fv_currency_mode;
        public ENUM_CURRENCY_MODE currency_mode
        {
            get { return _fv_currency_mode; }
            set { _fv_currency_mode = value; }
        }
        public string LIBELLE_currency_mode
        {
            get { return _fl_currency_mode[(int)_fv_currency_mode]; }
        }

        public double balance
        {
            get { return (double)listProperties.value("balance", aField.FIELD_TYPE.FLOAT); }
        }

        public int id
        {
            get { return (int)listProperties.value("id", aField.FIELD_TYPE.INTEGER); }
            set { listProperties.setValue("id", value); }
        }
        public override string resource_name()
        {
            return "account.account";
        }
    }
}
