using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IMDEV.OpenERP.models.@base;
using IMDEV.OpenERP.models.fields.relations;

namespace IMDEV.OpenERP.EG.models.mrp
{
    public class mrp_property : anOpenERPObject
    {
        private manyToOne _f_group_id = new manyToOne(); //mrp.property.group
        public manyToOne group_id
        {
            get { return _f_group_id; }
        }

        public enum ENUM_COMPOSITION
        {
            NULL
            ,
            @min
                ,
            @plus
                , @max
        }
        private string[] _frv_composition = new string[] { "NULL", "min", "plus", "max" };
        private string[] _fl_composition = new string[] { "NULL", "min", "plus", "max" };
        private ENUM_COMPOSITION _fv_composition;
        public ENUM_COMPOSITION composition
        {
            get { return _fv_composition; }
            set { _fv_composition = value; }
        }
        public string LIBELLE_composition
        {
            get { return _fl_composition[(int)_fv_composition]; }
        }

        public string name
        {
            get { return (string)listProperties.value("name", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("name", value); }
        }

        public string description
        {
            get { return (string)listProperties.value("description", aField.FIELD_TYPE.TEXT); }
            set { listProperties.setValue("description", value); }
        }

        public int id
        {
            get { return (int)listProperties.value("id", aField.FIELD_TYPE.INTEGER); }
            set { listProperties.setValue("id", value); }
        }
        public override string resource_name()
        {
            return "mrp.property";
        }
    }
}
