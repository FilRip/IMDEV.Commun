using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IMDEV.OpenERP.models.@base;
using IMDEV.OpenERP.models.fields.relations;

namespace IMDEV.OpenERP.EG.models.product
{
    public class product_packaging : anOpenERPObject
    {
        private manyToOne _f_ul = new manyToOne(); //product.ul
        public manyToOne ul
        {
            get { return _f_ul; }
        }

        public string code
        {
            get { return (string)listProperties.value("code", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("code", value); }
        }

        public string name
        {
            get { return (string)listProperties.value("name", aField.FIELD_TYPE.CHAR); }
        }

        public double weight
        {
            get { return (double)listProperties.value("weight", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("weight", value); }
        }

        public int sequence
        {
            get { return (int)listProperties.value("sequence", aField.FIELD_TYPE.INTEGER); }
            set { listProperties.setValue("sequence", value); }
        }

        public int ul_qty
        {
            get { return (int)listProperties.value("ul_qty", aField.FIELD_TYPE.INTEGER); }
            set { listProperties.setValue("ul_qty", value); }
        }

        private manyToOne _f_palletisation_id = new manyToOne(); //product.packaging.palletisation
        public manyToOne palletisation_id
        {
            get { return _f_palletisation_id; }
        }

        public double length
        {
            get { return (double)listProperties.value("length", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("length", value); }
        }

        public double qty
        {
            get { return (double)listProperties.value("qty", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("qty", value); }
        }

        public string note
        {
            get { return (string)listProperties.value("note", aField.FIELD_TYPE.TEXT); }
            set { listProperties.setValue("note", value); }
        }

        public double width
        {
            get { return (double)listProperties.value("width", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("width", value); }
        }

        public string ean
        {
            get { return (string)listProperties.value("ean", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("ean", value); }
        }

        public int rows
        {
            get { return (int)listProperties.value("rows", aField.FIELD_TYPE.INTEGER); }
            set { listProperties.setValue("rows", value); }
        }

        public bool packaging_for_sale
        {
            get { return (bool)listProperties.value("packaging_for_sale", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("packaging_for_sale", value); }
        }

        public double height
        {
            get { return (double)listProperties.value("height", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("height", value); }
        }

        public double weight_ul
        {
            get { return (double)listProperties.value("weight_ul", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("weight_ul", value); }
        }

        private manyToOne _f_product_id = new manyToOne(); //product.product
        public manyToOne product_id
        {
            get { return _f_product_id; }
        }

        public int id
        {
            get { return (int)listProperties.value("id", aField.FIELD_TYPE.INTEGER); }
            set { listProperties.setValue("id", value); }
        }
        public override string resource_name()
        {
            return "product.packaging";
        }
    }
}
