using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IMDEV.OpenERP.models.@base;
using IMDEV.OpenERP.models.fields.relations;

namespace IMDEV.OpenERP.EG.models.mrp
{
    public class mrp_subproduct : anOpenERPObject
    {
        public enum ENUM_SUBPRODUCT_TYPE
        {
            NULL
            ,
            @fixed
                ,
            @percent
                , @variable
        }
        private string[] _frv_subproduct_type = new string[] { "NULL", "fixed", "percent", "variable" };
        private string[] _fl_subproduct_type = new string[] { "NULL", "Fixed", "Percent", "Variable" };
        private ENUM_SUBPRODUCT_TYPE _fv_subproduct_type;
        public ENUM_SUBPRODUCT_TYPE subproduct_type
        {
            get { return _fv_subproduct_type; }
            set { _fv_subproduct_type = value; }
        }
        public string LIBELLE_subproduct_type
        {
            get { return _fl_subproduct_type[(int)_fv_subproduct_type]; }
        }

        private manyToOne _f_product_id = new manyToOne(); //product.product
        public manyToOne product_id
        {
            get { return _f_product_id; }
        }

        private manyToOne _f_product_uom = new manyToOne(); //product.uom
        public manyToOne product_uom
        {
            get { return _f_product_uom; }
        }

        public bool sample
        {
            get { return (bool)listProperties.value("sample", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("sample", value); }
        }

        public double product_qty
        {
            get { return (double)listProperties.value("product_qty", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("product_qty", value); }
        }

        private manyToOne _f_bom_id = new manyToOne(); //mrp.bom
        public manyToOne bom_id
        {
            get { return _f_bom_id; }
        }

        public int id
        {
            get { return (int)listProperties.value("id", aField.FIELD_TYPE.INTEGER); }
            set { listProperties.setValue("id", value); }
        }
        public override string resource_name()
        {
            return "mrp.subproduct";
        }
    }
}
