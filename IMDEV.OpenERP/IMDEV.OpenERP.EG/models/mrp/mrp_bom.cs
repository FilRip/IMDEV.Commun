using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IMDEV.OpenERP.models.@base;
using IMDEV.OpenERP.models.fields.relations;

namespace IMDEV.OpenERP.EG.models.mrp
{
    public class mrp_bom : anOpenERPObject
    {
        private manyToMany _f_property_ids = new manyToMany(); //mrp.property
        public manyToMany property_ids
        {
            get { return _f_property_ids; }
        }

        public double product_uos_qty
        {
            get { return (double)listProperties.value("product_uos_qty", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("product_uos_qty", value); }
        }

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

        public enum ENUM_OVERDOSE_MATERIAL_TYPE
        {
            NULL
            ,
            @gluten
                ,
            @flour
                , @none
        }
        private string[] _frv_overdose_material_type = new string[] { "NULL", "gluten", "flour", "none" };
        private string[] _fl_overdose_material_type = new string[] { "NULL", "Gluten", "Standard", "" };
        private ENUM_OVERDOSE_MATERIAL_TYPE _fv_overdose_material_type;
        public ENUM_OVERDOSE_MATERIAL_TYPE overdose_material_type
        {
            get { return _fv_overdose_material_type; }
            set { _fv_overdose_material_type = value; }
        }
        public string LIBELLE_overdose_material_type
        {
            get { return _fl_overdose_material_type[(int)_fv_overdose_material_type]; }
        }

        public double percent_incorporation
        {
            get { return (double)listProperties.value("percent_incorporation", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("percent_incorporation", value); }
        }

        public int sequence
        {
            get { return (int)listProperties.value("sequence", aField.FIELD_TYPE.INTEGER); }
            set { listProperties.setValue("sequence", value); }
        }

        public string bom_ingredient_de_de
        {
            get { return (string)listProperties.value("bom_ingredient_de_de", aField.FIELD_TYPE.TEXT); }
            set { listProperties.setValue("bom_ingredient_de_de", value); }
        }

        public string bom_recipe_zh_cn
        {
            get { return (string)listProperties.value("bom_recipe_zh_cn", aField.FIELD_TYPE.TEXT); }
            set { listProperties.setValue("bom_recipe_zh_cn", value); }
        }

        private manyToMany _f_child_complete_ids = new manyToMany(); //mrp.bom
        public manyToMany child_complete_ids
        {
            get { return _f_child_complete_ids; }
        }

        public string bom_ingredient_fr_fr
        {
            get { return (string)listProperties.value("bom_ingredient_fr_fr", aField.FIELD_TYPE.TEXT); }
            set { listProperties.setValue("bom_ingredient_fr_fr", value); }
        }

        public bool mp_to_overdose
        {
            get { return (bool)listProperties.value("mp_to_overdose", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("mp_to_overdose", value); }
        }

        public double default_batch_unit
        {
            get { return (double)listProperties.value("default_batch_unit", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("default_batch_unit", value); }
        }

        public double product_qty
        {
            get { return (double)listProperties.value("product_qty", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("product_qty", value); }
        }

        private manyToOne _f_product_uos = new manyToOne(); //product.uom
        public manyToOne product_uos
        {
            get { return _f_product_uos; }
        }

        private manyToOne _f_formulator_id = new manyToOne(); //res.users
        public manyToOne formulator_id
        {
            get { return _f_formulator_id; }
        }

        public bool ultra_confidential
        {
            get { return (bool)listProperties.value("ultra_confidential", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("ultra_confidential", value); }
        }

        private manyToOne _f_product_uom = new manyToOne(); //product.uom
        public manyToOne product_uom
        {
            get { return _f_product_uom; }
        }

        public int num_formulateur
        {
            get { return (int)listProperties.value("num_formulateur", aField.FIELD_TYPE.INTEGER); }
            set { listProperties.setValue("num_formulateur", value); }
        }

        public string bom_ingredient_en_us
        {
            get { return (string)listProperties.value("bom_ingredient_en_us", aField.FIELD_TYPE.TEXT); }
            set { listProperties.setValue("bom_ingredient_en_us", value); }
        }

        private manyToMany _f_reserved_um = new manyToMany(); //stock.tracking
        public manyToMany reserved_um
        {
            get { return _f_reserved_um; }
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

        public string bom_ingredient_pt_pt
        {
            get { return (string)listProperties.value("bom_ingredient_pt_pt", aField.FIELD_TYPE.TEXT); }
            set { listProperties.setValue("bom_ingredient_pt_pt", value); }
        }

        public string bom_ingredient_es_es
        {
            get { return (string)listProperties.value("bom_ingredient_es_es", aField.FIELD_TYPE.TEXT); }
            set { listProperties.setValue("bom_ingredient_es_es", value); }
        }

        private manyToOne _f_label_id = new manyToOne(); //product.label
        public manyToOne label_id
        {
            get { return _f_label_id; }
        }

        private manyToOne _f_routing_id = new manyToOne(); //mrp.routing
        public manyToOne routing_id
        {
            get { return _f_routing_id; }
        }

        public bool print_supplier_lot
        {
            get { return (bool)listProperties.value("print_supplier_lot", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("print_supplier_lot", value); }
        }

        public enum ENUM_TYPE
        {
            NULL
            ,
            @normal
                , @phantom
        }
        private string[] _frv_type = new string[] { "NULL", "normal", "phantom" };
        private string[] _fl_type = new string[] { "NULL", "Normal BoM", "Sets / Phantom" };
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

        public enum ENUM_METHOD
        {
            NULL
            ,
            @set
                ,
            @stock
                ,
            @order
                , _EMPTY_
        }
        private string[] _frv_method = new string[] { "NULL", "set", "stock", "order", "" };
        private string[] _fl_method = new string[] { "NULL", "Set / Pack", "On Stock", "On Order", "" };
        private ENUM_METHOD _fv_method;
        public ENUM_METHOD method
        {
            get { return _fv_method; }
            set { _fv_method = value; }
        }
        public string LIBELLE_method
        {
            get { return _fl_method[(int)_fv_method]; }
        }

        private manyToOne _f_bom_id = new manyToOne(); //mrp.bom
        public manyToOne bom_id
        {
            get { return _f_bom_id; }
        }

        public string bom_recipe_de_de
        {
            get { return (string)listProperties.value("bom_recipe_de_de", aField.FIELD_TYPE.TEXT); }
            set { listProperties.setValue("bom_recipe_de_de", value); }
        }

        public string bom_recipe_other
        {
            get { return (string)listProperties.value("bom_recipe_other", aField.FIELD_TYPE.TEXT); }
            set { listProperties.setValue("bom_recipe_other", value); }
        }

        private manyToOne _f_warehouse_id = new manyToOne(); //stock.warehouse
        public manyToOne warehouse_id
        {
            get { return _f_warehouse_id; }
        }

        private oneToMany _f_parent_ids = new oneToMany(); //mrp.bom
        public oneToMany parent_ids
        {
            get { return _f_parent_ids; }
        }

        public string bom_ingredient_zh_cn
        {
            get { return (string)listProperties.value("bom_ingredient_zh_cn", aField.FIELD_TYPE.TEXT); }
            set { listProperties.setValue("bom_ingredient_zh_cn", value); }
        }

        public string position
        {
            get { return (string)listProperties.value("position", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("position", value); }
        }

        public bool active
        {
            get { return (bool)listProperties.value("active", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("active", value); }
        }

        public double product_efficiency
        {
            get { return (double)listProperties.value("product_efficiency", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("product_efficiency", value); }
        }

        private oneToMany _f_bom_lines = new oneToMany(); //mrp.bom
        public oneToMany bom_lines
        {
            get { return _f_bom_lines; }
        }

        public double product_rounding
        {
            get { return (double)listProperties.value("product_rounding", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("product_rounding", value); }
        }

        public string bom_ingredient_other
        {
            get { return (string)listProperties.value("bom_ingredient_other", aField.FIELD_TYPE.TEXT); }
            set { listProperties.setValue("bom_ingredient_other", value); }
        }

        public string old_code
        {
            get { return (string)listProperties.value("old_code", aField.FIELD_TYPE.CHAR); }
        }

        public string name
        {
            get { return (string)listProperties.value("name", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("name", value); }
        }

        public string bom_recipe_en_us
        {
            get { return (string)listProperties.value("bom_recipe_en_us", aField.FIELD_TYPE.TEXT); }
            set { listProperties.setValue("bom_recipe_en_us", value); }
        }

        public string bom_recipe_fr_fr
        {
            get { return (string)listProperties.value("bom_recipe_fr_fr", aField.FIELD_TYPE.TEXT); }
            set { listProperties.setValue("bom_recipe_fr_fr", value); }
        }

        public string bom_ingredient_it_it
        {
            get { return (string)listProperties.value("bom_ingredient_it_it", aField.FIELD_TYPE.TEXT); }
            set { listProperties.setValue("bom_ingredient_it_it", value); }
        }

        private oneToMany _f_revision_ids = new oneToMany(); //mrp.bom.revision
        public oneToMany revision_ids
        {
            get { return _f_revision_ids; }
        }

        public string bom_recipe_pt_pt
        {
            get { return (string)listProperties.value("bom_recipe_pt_pt", aField.FIELD_TYPE.TEXT); }
            set { listProperties.setValue("bom_recipe_pt_pt", value); }
        }

        public string code_mp
        {
            get { return (string)listProperties.value("code_mp", aField.FIELD_TYPE.CHAR); }
        }

        private manyToOne _f_product_id = new manyToOne(); //product.product
        public manyToOne product_id
        {
            get { return _f_product_id; }
        }

        public string bom_recipe_it_it
        {
            get { return (string)listProperties.value("bom_recipe_it_it", aField.FIELD_TYPE.TEXT); }
            set { listProperties.setValue("bom_recipe_it_it", value); }
        }

        private oneToMany _f_sub_products = new oneToMany(); //mrp.subproduct
        public oneToMany sub_products
        {
            get { return _f_sub_products; }
        }

        private manyToOne _f_mo_type_id = new manyToOne(); //mrp.production.type
        public manyToOne mo_type_id
        {
            get { return _f_mo_type_id; }
        }

        public string bom_recipe_ar_ar
        {
            get { return (string)listProperties.value("bom_recipe_ar_ar", aField.FIELD_TYPE.TEXT); }
            set { listProperties.setValue("bom_recipe_ar_ar", value); }
        }

        public string bom_ingredient_ar_ar
        {
            get { return (string)listProperties.value("bom_ingredient_ar_ar", aField.FIELD_TYPE.TEXT); }
            set { listProperties.setValue("bom_ingredient_ar_ar", value); }
        }

        public string bom_recipe_es_es
        {
            get { return (string)listProperties.value("bom_recipe_es_es", aField.FIELD_TYPE.TEXT); }
            set { listProperties.setValue("bom_recipe_es_es", value); }
        }

        private oneToMany _f_location_path_ids = new oneToMany(); //mrp.location.path
        public oneToMany location_path_ids
        {
            get { return _f_location_path_ids; }
        }

        public enum ENUM_SPECIAL_BOM_TYPE
        {
            NULL
            ,
            @temp
                ,
            @normal
                , @recycl
        }
        private string[] _frv_special_bom_type = new string[] { "NULL", "temp", "normal", "recycl" };
        private string[] _fl_special_bom_type = new string[] { "NULL", "Temporary", "Normal", "Recycle" };
        private ENUM_SPECIAL_BOM_TYPE _fv_special_bom_type;
        public ENUM_SPECIAL_BOM_TYPE special_bom_type
        {
            get { return _fv_special_bom_type; }
            set { _fv_special_bom_type = value; }
        }

        public int id
        {
            get { return (int)listProperties.value("id", aField.FIELD_TYPE.INTEGER); }
            set { listProperties.setValue("id", value); }
        }
        public override string resource_name()
        {
            return "mrp.bom";
        }

        #region "CaractéristiquesMatières/Formulateur"

        public bool addProduct(product.product_product productToAdd, int sequence, double qty, int uomId)
        {
            if (productToAdd==null) return false;
            mrp_bom newLine = new mrp_bom();
            newLine.product_id.setValue(productToAdd.id);
            newLine.product_qty = qty;
            newLine.product_uom.setValue(uomId);
            newLine.product_uos.setValue(uomId);
            newLine.name = productToAdd.name;
            newLine.sequence = sequence;
            bom_lines.createAndLink(newLine);
            return true;
        }
        #endregion
    }
}
