using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IMDEV.OpenERP.models.@base;
using IMDEV.OpenERP.models.fields.relations;


namespace IMDEV.OpenERP.EG.models.crm
{
    public class crm_case_section : anOpenERPObject
    {
        public string team_email
        {
            get { return (string)listProperties.value("team_email", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("team_email", value); }
        }

        public enum ENUM_TYPE_VIEW
        {
            NULL
            ,
            @normal
                , @view
        }
        private string[] _frv_type_view = new string[] { "NULL", "normal", "view" };
        private string[] _fl_type_view = new string[] { "NULL", "Normal", "View" };
        private ENUM_TYPE_VIEW _fv_type_view;
        public ENUM_TYPE_VIEW type_view
        {
            get { return _fv_type_view; }
            set { _fv_type_view = value; }
        }
        public string LIBELLE_type_view
        {
            get { return _fl_type_view[(int)_fv_type_view]; }
        }

        public string code
        {
            get { return (string)listProperties.value("code", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("code", value); }
        }

        private manyToMany _f_concep_assist_ids = new manyToMany();
        public manyToMany concep_assist_ids
        {
            get { return _f_concep_assist_ids; }
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

        private manyToOne _f_user_id = new manyToOne();
        public manyToOne user_id
        {
            get { return _f_user_id; }
        }

        private oneToMany _f_child_ids = new oneToMany();
        public oneToMany child_ids
        {
            get { return _f_child_ids; }
        }

        private manyToMany _f_stage_ids = new manyToMany();
        public manyToMany stage_ids
        {
            get { return _f_stage_ids; }
        }

        public bool change_responsible
        {
            get { return (bool)listProperties.value("change_responsible", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("change_responsible", value); }
        }

        public string note
        {
            get { return (string)listProperties.value("note", aField.FIELD_TYPE.TEXT); }
            set { listProperties.setValue("note", value); }
        }

        private manyToOne _f_parent_id = new manyToOne();
        public manyToOne parent_id
        {
            get { return _f_parent_id; }
        }

        private manyToMany _f_member_ids = new manyToMany();
        public manyToMany member_ids
        {
            get { return _f_member_ids; }
        }

        public string complete_name
        {
            get { return (string)listProperties.value("complete_name", aField.FIELD_TYPE.CHAR); }
        }

        public string reply_to
        {
            get { return (string)listProperties.value("reply_to", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("reply_to", value); }
        }

        public bool active
        {
            get { return (bool)listProperties.value("active", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("active", value); }
        }

        public double working_hours
        {
            get { return (double)listProperties.value("working_hours", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("working_hours", value); }
        }

        public bool allow_unlink
        {
            get { return (bool)listProperties.value("allow_unlink", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("allow_unlink", value); }
        }

        private manyToOne _f_concep_resp_id = new manyToOne();
        public manyToOne concep_resp_id
        {
            get { return _f_concep_resp_id; }
        }

        private manyToOne _f_resource_calendar_id = new manyToOne();
        public manyToOne resource_calendar_id
        {
            get { return _f_resource_calendar_id; }
        }

        public int id
        {
            get { return (int)listProperties.value("id", aField.FIELD_TYPE.INTEGER); }
            set { listProperties.setValue("id", value); }
        }
        public override string resource_name()
        {
            return "crm.case.section";
        }
    }
}
