using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IMDEV.OpenERP.models.@base;
using IMDEV.OpenERP.models.fields.relations;

namespace IMDEV.OpenERP.EG.models.product
{
    using IMDEV.OpenERP.models.@base;
    using IMDEV.OpenERP.models.fields.relations;

    public class product_validation : anOpenERPObject
    {
        private manyToOne _f_user_id = new manyToOne(); //res.users
        public manyToOne user_id
        {
            get { return _f_user_id; }
        }

        private manyToOne _f_product_id = new manyToOne(); //product.product
        public manyToOne product_id
        {
            get { return _f_product_id; }
        }

        public int sequence
        {
            get { return (int)listProperties.value("sequence", aField.FIELD_TYPE.INTEGER); }
        }

        public string note
        {
            get { return (string)listProperties.value("note", aField.FIELD_TYPE.CHAR); }
        }

        public enum ENUM_STATE
        {
            NULL
            ,
            @draft
                ,
            @nack
                , @ack
        }
        private string[] _frv_state = new string[] { "NULL", "draft", "nack", "ack" };
        private string[] _fl_state = new string[] { "NULL", "Waiting Validation", "Non-Validated", "Validated" };
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

        public string department
        {
            get { return (string)listProperties.value("department", aField.FIELD_TYPE.CHAR); }
        }

        private manyToOne _f_group_id = new manyToOne(); //res.groups
        public manyToOne group_id
        {
            get { return _f_group_id; }
        }

        public System.DateTime? date_validation
        {
            get { return (System.DateTime?)listProperties.value("date_validation", aField.FIELD_TYPE.DATE); }
        }

        private oneToMany _f_control_points_ids = new oneToMany(); //product.service.validation
        public oneToMany control_points_ids
        {
            get { return _f_control_points_ids; }
        }

        public int id
        {
            get { return (int)listProperties.value("id", aField.FIELD_TYPE.INTEGER); }
            set { listProperties.setValue("id", value); }
        }
        public override string resource_name()
        {
            return "product.validation";
        }
    }
}
