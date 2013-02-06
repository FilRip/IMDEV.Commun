using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IMDEV.OpenERP.models.@base;
using IMDEV.OpenERP.models.fields.relations;

namespace IMDEV.OpenERP.EG.models.product
{
    public class product_ul : anOpenERPObject
    {
        public bool multi_ul_location
        {
            get { return (bool)listProperties.value("multi_ul_location", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("multi_ul_location", value); }
        }

        public enum ENUM_TYPE
        {
            NULL
            ,
            @bulk
                ,
            @unit
                ,
            @box
                ,
            @pallet
                , @pack
        }
        private string[] _frv_type = new string[] { "NULL", "bulk", "unit", "box", "pallet", "pack" };
        private string[] _fl_type = new string[] { "NULL", "Bulk", "Unit", "Box", "Pallet", "Pack" };
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

        public bool purchase_merge
        {
            get { return (bool)listProperties.value("purchase_merge", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("purchase_merge", value); }
        }

        public int id
        {
            get { return (int)listProperties.value("id", aField.FIELD_TYPE.INTEGER); }
            set { listProperties.setValue("id", value); }
        }
        public override string resource_name()
        {
            return "product.ul";
        }
    }
}
