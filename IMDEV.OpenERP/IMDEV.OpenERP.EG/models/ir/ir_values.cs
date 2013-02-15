using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IMDEV.OpenERP.models.@base;
using IMDEV.OpenERP.models.fields.relations;

namespace IMDEV.OpenERP.EG.models.ir
{
    public class ir_values : anOpenERPObject
    {
        private manyToOne _f_model_id = new manyToOne(); //ir.model
        public manyToOne model_id
        {
            get { return _f_model_id; }
        }

        public bool @object
        {
            get { return (bool)listProperties.value("object", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("object", value); }
        }

        private manyToOne _f_user_id = new manyToOne(); //res.users
        public manyToOne user_id
        {
            get { return _f_user_id; }
        }

        public string name
        {
            get { return (string)listProperties.value("name", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("name", value); }
        }

        public string key2
        {
            get { return (string)listProperties.value("key2", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("key2", value); }
        }

        public string value_unpickle
        {
            get { return (string)listProperties.value("value_unpickle", aField.FIELD_TYPE.TEXT); }
            set { listProperties.setValue("value_unpickle", value); }
        }

        private manyToOne _f_company_id = new manyToOne(); //res.company
        public manyToOne company_id
        {
            get { return _f_company_id; }
        }

        public string value
        {
            get { return (string)listProperties.value("value", aField.FIELD_TYPE.TEXT); }
            set { listProperties.setValue("value", value); }
        }

        public string meta
        {
            get { return (string)listProperties.value("meta", aField.FIELD_TYPE.TEXT); }
            set { listProperties.setValue("meta", value); }
        }

        public enum ENUM_KEY
        {
            NULL
            ,
            @default
                , @action
        }
        private string[] _frv_key = new string[] { "NULL", "default", "action" };
        private string[] _fl_key = new string[] { "NULL", "Default", "Action" };
        private ENUM_KEY _fv_key;
        public ENUM_KEY key
        {
            get { return _fv_key; }
            set { _fv_key = value; }
        }
        public string LIBELLE_key
        {
            get { return _fl_key[(int)_fv_key]; }
        }
        public string CODE_key
        {
            get { return _frv_key[(int)_fv_key]; }
        }

        public int res_id
        {
            get { return (int)listProperties.value("res_id", aField.FIELD_TYPE.INTEGER); }
            set { listProperties.setValue("res_id", value); }
        }

        public string model
        {
            get { return (string)listProperties.value("model", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("model", value); }
        }

        public string meta_unpickle
        {
            get { return (string)listProperties.value("meta_unpickle", aField.FIELD_TYPE.TEXT); }
            set { listProperties.setValue("meta_unpickle", value); }
        }

        private manyToOne _f_action_id = new manyToOne(); //ir.actions.actions
        public manyToOne action_id
        {
            get { return _f_action_id; }
        }

        public int id
        {
            get { return (int)listProperties.value("id", aField.FIELD_TYPE.INTEGER); }
            set { listProperties.setValue("id", value); }
        }
        public override string resource_name()
        {
            return "ir.values";
        }
    }
}
