using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IMDEV.OpenERP.models.fields.relations;
using IMDEV.OpenERP.models.@base;

namespace IMDEV.OpenERP.models.common
{
    public class res_lang : anOpenERPObject
    {
        public string date_format
        {
            get { return (string)listProperties.value("date_format", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("date_format", value); }
        }


        public enum ENUM_DIRECTION
        {
            NULL,
            ltr,
            rtl,
        }

        private string[] _fl_direction = new string[] { "NULL", "Left-to-Right", "Right-to-Left" };

        private ENUM_DIRECTION _fv_direction;

        public ENUM_DIRECTION direction
        {
            get { return _fv_direction; }
            set { _fv_direction = value; }
        }

        public string LIBELLE_DIRECTION
        {
            get
            {
                return _fl_direction[(int)_fv_direction];
            }
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

        public string thousands_sep
        {
            get { return (string)listProperties.value("thousands_sep", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("thousands_sep", value); }
        }

        public bool translatable
        {
            get { return (bool)listProperties.value("translatable", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("translatable", value); }
        }

        public string time_format
        {
            get { return (string)listProperties.value("time_format", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("time_format", value); }
        }

        public string decimal_point
        {
            get { return (string)listProperties.value("decimal_point", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("decimal_point", value); }
        }

        public bool active
        {
            get { return (bool)listProperties.value("active", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("active", value); }
        }

        public string iso_code
        {
            get { return (string)listProperties.value("iso_code", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("iso_code", value); }
        }

        public string grouping
        {
            get { return (string)listProperties.value("grouping", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("grouping", value); }
        }

        public int id
        {
            get { return (int)listProperties.value("id", aField.FIELD_TYPE.INTEGER); }
            set { listProperties.setValue("id", value); }
        }

        public override string resource_name()
        {
            return "res.lang";
        }
    }
}
