using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IMDEV.OpenERP.models.@base;
using IMDEV.OpenERP.models.fields.relations;

namespace IMDEV.OpenERP.EG.models.product
{
    public class product_template : anOpenERPObject
    {
        public double warranty
        {
            get { return (double)listProperties.value("warranty", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("warranty", value); }
        }

        private manyToOne _f_property_stock_procurement = new manyToOne(); //stock.location
        public manyToOne property_stock_procurement
        {
            get { return _f_property_stock_procurement; }
        }

        public enum ENUM_SUPPLY_METHOD
        {
            NULL
            ,
            @produce
                , @buy
        }
        private string[] _frv_supply_method = new string[] { "NULL", "produce", "buy" };
        private string[] _fl_supply_method = new string[] { "NULL", "Produce", "Buy" };
        private ENUM_SUPPLY_METHOD _fv_supply_method;
        public ENUM_SUPPLY_METHOD supply_method
        {
            get { return _fv_supply_method; }
            set { _fv_supply_method = value; }
        }
        public string LIBELLE_supply_method
        {
            get { return _fl_supply_method[(int)_fv_supply_method]; }
        }

        private manyToOne _f_uos_id = new manyToOne(); //product.uom
        public manyToOne uos_id
        {
            get { return _f_uos_id; }
        }

        public double list_price
        {
            get { return (double)listProperties.value("list_price", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("list_price", value); }
        }

        public double weight
        {
            get { return (double)listProperties.value("weight", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("weight", value); }
        }

        public double standard_price
        {
            get { return (double)listProperties.value("standard_price", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("standard_price", value); }
        }

        public System.DateTime seller_nextdate
        {
            get { return (System.DateTime)listProperties.value("seller_nextdate", aField.FIELD_TYPE.DATETIME); }
        }

        public bool naturall
        {
            get { return (bool)listProperties.value("naturall", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("naturall", value); }
        }

        public enum ENUM_MES_TYPE
        {
            NULL
            ,
            @fixed
                , @variable
        }
        private string[] _frv_mes_type = new string[] { "NULL", "fixed", "variable" };
        private string[] _fl_mes_type = new string[] { "NULL", "Fixed", "Variable" };
        private ENUM_MES_TYPE _fv_mes_type;
        public ENUM_MES_TYPE mes_type
        {
            get { return _fv_mes_type; }
            set { _fv_mes_type = value; }
        }
        public string LIBELLE_mes_type
        {
            get { return _fl_mes_type[(int)_fv_mes_type]; }
        }

        private manyToOne _f_uom_id = new manyToOne(); //product.uom
        public manyToOne uom_id
        {
            get { return _f_uom_id; }
        }

        public string description_purchase
        {
            get { return (string)listProperties.value("description_purchase", aField.FIELD_TYPE.TEXT); }
            set { listProperties.setValue("description_purchase", value); }
        }
        private IMDEV.OpenERP.models.fields.texteMultilangue _description_purchase_multilangue;
        public IMDEV.OpenERP.models.fields.texteMultilangue description_purchase_multilangue
        {
            get
            {
                if (_description_purchase_multilangue == null) _description_purchase_multilangue = new IMDEV.OpenERP.models.fields.texteMultilangue(this, "description_purchase");
                return _description_purchase_multilangue;
            }
        }

        private manyToOne _f_property_account_income = new manyToOne(); //account.account
        public manyToOne property_account_income
        {
            get { return _f_property_account_income; }
        }

        public bool exclude_from_intrastat
        {
            get { return (bool)listProperties.value("exclude_from_intrastat", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("exclude_from_intrastat", value); }
        }

        public enum ENUM_COST_METHOD
        {
            NULL
            ,
            @lifo
                ,
            @standard
                , @average
        }
        private string[] _frv_cost_method = new string[] { "NULL", "lifo", "standard", "average" };
        private string[] _fl_cost_method = new string[] { "NULL", "LIFO Price", "Standard Price", "Average Price" };
        private ENUM_COST_METHOD _fv_cost_method;
        public ENUM_COST_METHOD cost_method
        {
            get { return _fv_cost_method; }
            set { _fv_cost_method = value; }
        }
        public string LIBELLE_cost_method
        {
            get { return _fl_cost_method[(int)_fv_cost_method]; }
        }

        public double uos_coeff
        {
            get { return (double)listProperties.value("uos_coeff", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("uos_coeff", value); }
        }

        public bool conventional
        {
            get { return (bool)listProperties.value("conventional", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("conventional", value); }
        }

        public int seller_delay
        {
            get { return (int)listProperties.value("seller_delay", aField.FIELD_TYPE.INTEGER); }
        }

        public bool purchase_ok
        {
            get { return (bool)listProperties.value("purchase_ok", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("purchase_ok", value); }
        }

        private manyToOne _f_product_manager = new manyToOne(); //res.users
        public manyToOne product_manager
        {
            get { return _f_product_manager; }
        }

        private manyToOne _f_country_id = new manyToOne(); //res.country
        public manyToOne country_id
        {
            get { return _f_country_id; }
        }

        private manyToOne _f_company_id = new manyToOne(); //res.company
        public manyToOne company_id
        {
            get { return _f_company_id; }
        }

        public double produce_delay
        {
            get { return (double)listProperties.value("produce_delay", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("produce_delay", value); }
        }

        public enum ENUM_STATE
        {
            NULL
            ,
            @draft
                ,
            @obsolete
                ,
            @sellable
                ,
            _EMPTY_
                ,
            @sample
                , @end
        }
        private string[] _frv_state = new string[] { "NULL", "draft", "obsolete", "sellable", "", "sample", "end" };
        private string[] _fl_state = new string[] { "NULL", "In Development", "Obsolete", "Normal", "", "Sample", "End of Lifecycle" };
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

        public string loc_rack
        {
            get { return (string)listProperties.value("loc_rack", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("loc_rack", value); }
        }

        private manyToOne _f_uom_po_id = new manyToOne(); //product.uom
        public manyToOne uom_po_id
        {
            get { return _f_uom_po_id; }
        }

        private manyToOne _f_intrastat_id = new manyToOne(); //report.intrastat.code
        public manyToOne intrastat_id
        {
            get { return _f_intrastat_id; }
        }

        public enum ENUM_TYPE
        {
            NULL
            ,
            @service
                ,
            @consu
                , @product
        }
        private string[] _frv_type = new string[] { "NULL", "service", "consu", "product" };
        private string[] _fl_type = new string[] { "NULL", "Service", "Consumable", "Stockable Product" };
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

        private manyToOne _f_property_stock_account_input = new manyToOne(); //account.account
        public manyToOne property_stock_account_input
        {
            get { return _f_property_stock_account_input; }
        }

        private manyToOne _f_pallet_state_id = new manyToOne(); //product.pallet.state
        public manyToOne pallet_state_id
        {
            get { return _f_pallet_state_id; }
        }

        public bool bio
        {
            get { return (bool)listProperties.value("bio", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("bio", value); }
        }

        public string loc_case
        {
            get { return (string)listProperties.value("loc_case", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("loc_case", value); }
        }

        private manyToOne _f_seller_packaging_id = new manyToOne(); //product.packaging
        public manyToOne seller_packaging_id
        {
            get { return _f_seller_packaging_id; }
        }

        public string description
        {
            get { return (string)listProperties.value("description", aField.FIELD_TYPE.TEXT); }
            set { listProperties.setValue("description", value); }
        }
        private IMDEV.OpenERP.models.fields.texteMultilangue _description_multilangue;
        public IMDEV.OpenERP.models.fields.texteMultilangue description_multilangue
        {
            get
            {
                if (_description_multilangue == null) _description_multilangue = new IMDEV.OpenERP.models.fields.texteMultilangue(this, "description");
                return _description_multilangue;
            }
        }

        public int seller_range
        {
            get { return (int)listProperties.value("seller_range", aField.FIELD_TYPE.INTEGER); }
        }

        public double weight_net
        {
            get { return (double)listProperties.value("weight_net", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("weight_net", value); }
        }

        private manyToOne _f_property_stock_production = new manyToOne(); //stock.location
        public manyToOne property_stock_production
        {
            get { return _f_property_stock_production; }
        }

        private manyToMany _f_supplier_taxes_id = new manyToMany(); //account.tax
        public manyToMany supplier_taxes_id
        {
            get { return _f_supplier_taxes_id; }
        }

        public double volume
        {
            get { return (double)listProperties.value("volume", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("volume", value); }
        }

        public enum ENUM_PROCURE_METHOD
        {
            NULL
            ,
            @make_to_stock
                , @make_to_order
        }
        private string[] _frv_procure_method = new string[] { "NULL", "make_to_stock", "make_to_order" };
        private string[] _fl_procure_method = new string[] { "NULL", "Make to Stock", "Make to Order" };
        private ENUM_PROCURE_METHOD _fv_procure_method;
        public ENUM_PROCURE_METHOD procure_method
        {
            get { return _fv_procure_method; }
            set { _fv_procure_method = value; }
        }
        public string LIBELLE_procure_method
        {
            get { return _fl_procure_method[(int)_fv_procure_method]; }
        }

        private manyToOne _f_property_stock_inventory = new manyToOne(); //stock.location
        public manyToOne property_stock_inventory
        {
            get { return _f_property_stock_inventory; }
        }

        public double seller_qty
        {
            get { return (double)listProperties.value("seller_qty", aField.FIELD_TYPE.FLOAT); }
        }

        public bool vitamix
        {
            get { return (bool)listProperties.value("vitamix", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("vitamix", value); }
        }

        public string loc_row
        {
            get { return (string)listProperties.value("loc_row", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("loc_row", value); }
        }

        public bool sale_ok
        {
            get { return (bool)listProperties.value("sale_ok", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("sale_ok", value); }
        }

        public bool rental
        {
            get { return (bool)listProperties.value("rental", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("rental", value); }
        }

        private manyToOne _f_seller_id = new manyToOne(); //product.supplierinfo
        public manyToOne seller_id
        {
            get { return _f_seller_id; }
        }

        public double sale_delay
        {
            get { return (double)listProperties.value("sale_delay", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("sale_delay", value); }
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

        public bool auto_consumer
        {
            get { return (bool)listProperties.value("auto_consumer", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("auto_consumer", value); }
        }

        private manyToOne _f_seller_contract_id = new manyToOne(); //product.supplierinfo.contract
        public manyToOne seller_contract_id
        {
            get { return _f_seller_contract_id; }
        }

        public string description_sale
        {
            get { return (string)listProperties.value("description_sale", aField.FIELD_TYPE.TEXT); }
            set { listProperties.setValue("description_sale", value); }
        }
        private IMDEV.OpenERP.models.fields.texteMultilangue _description_sale_multilangue;
        public IMDEV.OpenERP.models.fields.texteMultilangue description_sale_multilangue
        {
            get
            {
                if (_description_sale_multilangue == null) _description_sale_multilangue = new IMDEV.OpenERP.models.fields.texteMultilangue(this, "description_sale");
                return _description_sale_multilangue;
            }
        }

        private manyToOne _f_property_account_expense = new manyToOne(); //account.account
        public manyToOne property_account_expense
        {
            get { return _f_property_account_expense; }
        }

        private manyToOne _f_categ_id = new manyToOne(); //product.category
        public manyToOne categ_id
        {
            get { return _f_categ_id; }
        }

        public bool vitamix_gain
        {
            get { return (bool)listProperties.value("vitamix_gain", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("vitamix_gain", value); }
        }

        public bool sans_gluten
        {
            get { return (bool)listProperties.value("sans_gluten", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("sans_gluten", value); }
        }

        private manyToMany _f_taxes_id = new manyToMany(); //account.tax
        public manyToMany taxes_id
        {
            get { return _f_taxes_id; }
        }

        public bool kasher
        {
            get { return (bool)listProperties.value("kasher", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("kasher", value); }
        }

        private manyToOne _f_property_stock_account_output = new manyToOne(); //account.account
        public manyToOne property_stock_account_output
        {
            get { return _f_property_stock_account_output; }
        }

        private oneToMany _f_seller_ids = new oneToMany(); //product.supplierinfo
        public oneToMany seller_ids
        {
            get { return _f_seller_ids; }
        }

        public bool hallal
        {
            get { return (bool)listProperties.value("hallal", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("hallal", value); }
        }

        public int id
        {
            get { return (int)listProperties.value("id", aField.FIELD_TYPE.INTEGER); }
            set { listProperties.setValue("id", value); }
        }
        public override string resource_name()
        {
            return "product.template";
        }
    }
}
