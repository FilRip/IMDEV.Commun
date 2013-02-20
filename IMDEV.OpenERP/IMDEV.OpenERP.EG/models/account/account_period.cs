using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IMDEV.OpenERP.models.@base;
using IMDEV.OpenERP.models.fields.relations;

namespace IMDEV.OpenERP.EG.models.account
{
    public class account_period : anOpenERPObject
    {
        public System.DateTime? date_stop
        {
            get { return (System.DateTime?)listProperties.value("date_stop", aField.FIELD_TYPE.DATE); }
            set { listProperties.setValue("date_stop", value); }
        }

        public string code
        {
            get { return (string)listProperties.value("code", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("code", value); }
        }

        public string name
        {
            get { return (string)listProperties.value("name", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("name", value); }
        }

        public enum ENUM_STATE
        {
            NULL
            ,
            @draft
                , @done
        }
        private string[] _frv_state = new string[] { "NULL", "draft", "done" };
        private string[] _fl_state = new string[] { "NULL", "Open", "Closed" };
        private ENUM_STATE _fv_state;
        public ENUM_STATE state
        {
            get { return _fv_state; }
            set { _fv_state = value; }
        }
        public string LIBELLE_state
        {
            get { return _fl_state[(int)_fv_state]; }
        }
        public string CODE_state
        {
            get { return _frv_state[(int)_fv_state]; }
        }

        public System.DateTime? date_start
        {
            get { return (System.DateTime?)listProperties.value("date_start", aField.FIELD_TYPE.DATE); }
            set { listProperties.setValue("date_start", value); }
        }

        private manyToOne _f_company_id = new manyToOne(); //res.company
        public manyToOne company_id
        {
            get { return _f_company_id; }
        }

        private manyToOne _f_fiscalyear_id = new manyToOne(); //account.fiscalyear
        public manyToOne fiscalyear_id
        {
            get { return _f_fiscalyear_id; }
        }

        public bool special
        {
            get { return (bool)listProperties.value("special", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("special", value); }
        }

        public int id
        {
            get { return (int)listProperties.value("id", aField.FIELD_TYPE.INTEGER); }
            set { listProperties.setValue("id", value); }
        }
        public override string resource_name()
        {
            return "account.period";
        }
    }
}
