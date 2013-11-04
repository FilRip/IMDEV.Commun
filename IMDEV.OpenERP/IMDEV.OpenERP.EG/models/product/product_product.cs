using IMDEV.OpenERP.models.@base;
using IMDEV.OpenERP.models.fields.relations;
using System.Collections.Generic;

namespace IMDEV.OpenERP.EG.models.product
{
    public class product_product : anOpenERPObject
    {
        public string ean13
        {
            get { return (string)listProperties.value("ean13", aField.FIELD_TYPE.CHAR); }
        }

        public string code
        {
            get { return (string)listProperties.value("code", aField.FIELD_TYPE.CHAR); }
        }

        public double dosage_tolerance
        {
            get { return (double)listProperties.value("dosage_tolerance", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("dosage_tolerance", value); }
        }

        public double incoming_qty
        {
            get { return (double)listProperties.value("incoming_qty", aField.FIELD_TYPE.FLOAT); }
        }

        public double standard_price
        {
            get { return (double)listProperties.value("standard_price", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("standard_price", value); }
        }

        public bool naturall
        {
            get { return (bool)listProperties.value("naturall", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("naturall", value); }
        }

        public string name_template
        {
            get { return (string)listProperties.value("name_template", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("name_template", value); }
        }

        public string commentaire_reglementaire
        {
            get { return (string)listProperties.value("commentaire_reglementaire", aField.FIELD_TYPE.TEXT); }
            set { listProperties.setValue("commentaire_reglementaire", value); }
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

        public double minimum_order_qty
        {
            get { return (double)listProperties.value("minimum_order_qty", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("minimum_order_qty", value); }
        }

        public string enzyme_complement_code
        {
            get { return (string)listProperties.value("enzyme_complement_code", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("enzyme_complement_code", value); }
        }

        public double density
        {
            get { return (double)listProperties.value("density", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("density", value); }
        }

        public string old_code
        {
            get { return (string)listProperties.value("old_code", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("old_code", value); }
        }

        public double purchasing_price
        {
            get { return (double)listProperties.value("purchasing_price", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("purchasing_price", value); }
        }

        private manyToOne _f_company_id = new manyToOne();
        public manyToOne company_id
        {
            get { return _f_company_id; }
        }

        public int use_time
        {
            get { return (int)listProperties.value("use_time", aField.FIELD_TYPE.INTEGER); }
            set { listProperties.setValue("use_time", value); }
        }

        public string commentaire_produit_dangereux
        {
            get { return (string)listProperties.value("commentaire_produit_dangereux", aField.FIELD_TYPE.TEXT); }
            set { listProperties.setValue("commentaire_produit_dangereux", value); }
        }

        public string loc_rack
        {
            get { return (string)listProperties.value("loc_rack", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("loc_rack", value); }
        }

        public double conception_tolerance
        {
            get { return (double)listProperties.value("conception_tolerance", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("conception_tolerance", value); }
        }

        private manyToOne _f_label_id = new manyToOne();
        public manyToOne label_id
        {
            get { return _f_label_id; }
        }

        private manyToOne _f_pricelist_id = new manyToOne();
        public manyToOne pricelist_id
        {
            get { return _f_pricelist_id; }
        }

        public double outgoing_qty_virtual_done
        {
            get { return (double)listProperties.value("outgoing_qty_virtual_done", aField.FIELD_TYPE.FLOAT); }
        }

        public double price_margin
        {
            get { return (double)listProperties.value("price_margin", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("price_margin", value); }
        }

        private manyToOne _f_property_stock_account_input = new manyToOne();
        public manyToOne property_stock_account_input
        {
            get { return _f_property_stock_account_input; }
        }

        private manyToOne _f_pallet_state_id = new manyToOne();
        public manyToOne pallet_state_id
        {
            get { return _f_pallet_state_id; }
        }

        public bool bio
        {
            get { return (bool)listProperties.value("bio", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("bio", value); }
        }

        private oneToMany _f_machine_setting_ids = new oneToMany();
        public oneToMany machine_setting_ids
        {
            get { return _f_machine_setting_ids; }
        }

        private manyToMany _f_line_code = new manyToMany();
        public manyToMany line_code
        {
            get { return _f_line_code; }
        }

        public int seller_range
        {
            get { return (int)listProperties.value("seller_range", aField.FIELD_TYPE.INTEGER); }
        }

        private oneToMany _f_bom_ids = new oneToMany();
        public oneToMany bom_ids
        {
            get { return _f_bom_ids; }
        }

        private oneToMany _f_flow_pull_ids = new oneToMany();
        public oneToMany flow_pull_ids
        {
            get { return _f_flow_pull_ids; }
        }

        public double outgoing_qty
        {
            get { return (double)listProperties.value("outgoing_qty", aField.FIELD_TYPE.FLOAT); }
        }

        public string transport_produit_dangereux
        {
            get { return (string)listProperties.value("transport_produit_dangereux", aField.FIELD_TYPE.TEXT); }
            set { listProperties.setValue("transport_produit_dangereux", value); }
        }

        public bool have_pqcd_cde
        {
            get { return (bool)listProperties.value("have_pqcd_cde", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("have_pqcd_cde", value); }
        }

        public string default_code
        {
            get { return (string)listProperties.value("default_code", aField.FIELD_TYPE.CHAR); }
        }

        public string variants
        {
            get { return (string)listProperties.value("variants", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("variants", value); }
        }

        public string partner_ref
        {
            get { return (string)listProperties.value("partner_ref", aField.FIELD_TYPE.CHAR); }
        }

        public bool rental
        {
            get { return (bool)listProperties.value("rental", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("rental", value); }
        }

        private oneToMany _f_path_ids = new oneToMany();
        public oneToMany path_ids
        {
            get { return _f_path_ids; }
        }

        private oneToMany _f_packaging = new oneToMany();
        public oneToMany packaging
        {
            get { return _f_packaging; }
        }

        private manyToOne _f_seller_id = new manyToOne();
        public manyToOne seller_id
        {
            get { return _f_seller_id; }
        }

        public bool allow_formulation
        {
            get { return (bool)listProperties.value("allow_formulation", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("allow_formulation", value); }
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

        public double control_delay
        {
            get { return (double)listProperties.value("control_delay", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("control_delay", value); }
        }

        public string code_for_ean
        {
            get { return (string)listProperties.value("code_for_ean", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("code_for_ean", value); }
        }

        public bool repacked_trading
        {
            get { return (bool)listProperties.value("repacked_trading", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("repacked_trading", value); }
        }

        private manyToMany _f_application_type_ids = new manyToMany();
        public manyToMany application_type_ids
        {
            get { return _f_application_type_ids; }
        }

        private oneToMany _f_seller_ids = new oneToMany();
        public oneToMany seller_ids
        {
            get { return _f_seller_ids; }
        }

        public double control_qty
        {
            get { return (double)listProperties.value("control_qty", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("control_qty", value); }
        }

        public string acid_code
        {
            get { return (string)listProperties.value("acid_code", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("acid_code", value); }
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

        public double weight
        {
            get { return (double)listProperties.value("weight", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("weight", value); }
        }

        public string quality_internal_comment
        {
            get { return (string)listProperties.value("quality_internal_comment", aField.FIELD_TYPE.TEXT); }
            set { listProperties.setValue("quality_internal_comment", value); }
        }

        public double pallet_unit
        {
            get { return (double)listProperties.value("pallet_unit", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("pallet_unit", value); }
        }

        private manyToMany _f_securite_ids = new manyToMany();
        public manyToMany securite_ids
        {
            get { return _f_securite_ids; }
        }

        private manyToMany _f_risk_technology_ids = new manyToMany();
        public manyToMany risk_technology_ids
        {
            get { return _f_risk_technology_ids; }
        }

        private manyToOne _f_property_account_income = new manyToOne();
        public manyToOne property_account_income
        {
            get { return _f_property_account_income; }
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

        private manyToOne _f_valnut_id = new manyToOne();
        public manyToOne valnut_id
        {
            get { return _f_valnut_id; }
        }

        public System.DateTime? derniere_maj_pa
        {
            get { return (System.DateTime?)listProperties.value("derniere_maj_pa", aField.FIELD_TYPE.DATE); }
            set { listProperties.setValue("derniere_maj_pa", value); }
        }

        private manyToOne _f_partner_id = new manyToOne();
        public manyToOne partner_id
        {
            get { return _f_partner_id; }
        }

        private manyToMany _f_process_type_ids = new manyToMany();
        public manyToMany process_type_ids
        {
            get { return _f_process_type_ids; }
        }

        public double commercial_price
        {
            get { return (double)listProperties.value("commercial_price", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("commercial_price", value); }
        }

        public double virtual_available
        {
            get { return (double)listProperties.value("virtual_available", aField.FIELD_TYPE.FLOAT); }
        }

        public System.DateTime? fin_validite_pa
        {
            get { return (System.DateTime?)listProperties.value("fin_validite_pa", aField.FIELD_TYPE.DATE); }
            set { listProperties.setValue("fin_validite_pa", value); }
        }

        public System.DateTime? fin_validite_pc
        {
            get { return (System.DateTime?)listProperties.value("fin_validite_pc", aField.FIELD_TYPE.DATE); }
            set { listProperties.setValue("fin_validite_pc", value); }
        }

        private manyToOne _f_country_id = new manyToOne();
        public manyToOne country_id
        {
            get { return _f_country_id; }
        }

        private manyToOne _f_product_tmpl_id = new manyToOne();
        public manyToOne product_tmpl_id
        {
            get { return _f_product_tmpl_id; }
        }

        private oneToMany _f_image_ids = new oneToMany();
        public oneToMany image_ids
        {
            get { return _f_image_ids; }
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

        public bool logo_bio_nop
        {
            get { return (bool)listProperties.value("logo_bio_nop", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("logo_bio_nop", value); }
        }

        public int life_time
        {
            get { return (int)listProperties.value("life_time", aField.FIELD_TYPE.INTEGER); }
            set { listProperties.setValue("life_time", value); }
        }

        public double price
        {
            get { return (double)listProperties.value("price", aField.FIELD_TYPE.FLOAT); }
        }

        public string commentaire_pa
        {
            get { return (string)listProperties.value("commentaire_pa", aField.FIELD_TYPE.TEXT); }
            set { listProperties.setValue("commentaire_pa", value); }
        }

        public bool eg_waiting_quality
        {
            get { return (bool)listProperties.value("eg_waiting_quality", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("eg_waiting_quality", value); }
        }

        public string color_code
        {
            get { return (string)listProperties.value("color_code", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("color_code", value); }
        }

        private manyToMany _f_authorized_partner_ids = new manyToMany();
        public manyToMany authorized_partner_ids
        {
            get { return _f_authorized_partner_ids; }
        }

        private manyToMany _f_authorized_country_ids = new manyToMany();
        public manyToMany authorized_country_ids
        {
            get { return _f_authorized_country_ids; }
        }

        public int receive_dluo
        {
            get { return (int)listProperties.value("receive_dluo", aField.FIELD_TYPE.INTEGER); }
            set { listProperties.setValue("receive_dluo", value); }
        }

        public bool active
        {
            get { return (bool)listProperties.value("active", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("active", value); }
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

        public string quality_comment
        {
            get { return (string)listProperties.value("quality_comment", aField.FIELD_TYPE.TEXT); }
            set { listProperties.setValue("quality_comment", value); }
        }

        public int sale_dluo_mini
        {
            get { return (int)listProperties.value("sale_dluo_mini", aField.FIELD_TYPE.INTEGER); }
            set { listProperties.setValue("sale_dluo_mini", value); }
        }

        public string loc_case
        {
            get { return (string)listProperties.value("loc_case", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("loc_case", value); }
        }

        private manyToOne _f_property_stock_account_output = new manyToOne();
        public manyToOne property_stock_account_output
        {
            get { return _f_property_stock_account_output; }
        }

        public int delivery_dluo
        {
            get { return (int)listProperties.value("delivery_dluo", aField.FIELD_TYPE.INTEGER); }
            set { listProperties.setValue("delivery_dluo", value); }
        }

        public int points_per_uom
        {
            get { return (int)listProperties.value("points_per_uom", aField.FIELD_TYPE.INTEGER); }
            set { listProperties.setValue("points_per_uom", value); }
        }

        public double lst_price
        {
            get { return (double)listProperties.value("lst_price", aField.FIELD_TYPE.FLOAT); }
        }

        public bool sans_gluten
        {
            get { return (bool)listProperties.value("sans_gluten", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("sans_gluten", value); }
        }

        public bool etiquetage_ogm
        {
            get { return (bool)listProperties.value("etiquetage_ogm", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("etiquetage_ogm", value); }
        }

        public bool logo_bio_ab
        {
            get { return (bool)listProperties.value("logo_bio_ab", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("logo_bio_ab", value); }
        }

        public string support
        {
            get { return (string)listProperties.value("support", aField.FIELD_TYPE.TEXT); }
            set { listProperties.setValue("support", value); }
        }

        public double warranty
        {
            get { return (double)listProperties.value("warranty", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("warranty", value); }
        }

        private manyToOne _f_property_stock_procurement = new manyToOne();
        public manyToOne property_stock_procurement
        {
            get { return _f_property_stock_procurement; }
        }

        private manyToOne _f_uos_id = new manyToOne();
        public manyToOne uos_id
        {
            get { return _f_uos_id; }
        }

        public double list_price
        {
            get { return (double)listProperties.value("list_price", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("list_price", value); }
        }

        public string purchase_line_warn_msg
        {
            get { return (string)listProperties.value("purchase_line_warn_msg", aField.FIELD_TYPE.TEXT); }
            set { listProperties.setValue("purchase_line_warn_msg", value); }
        }

        public bool logo_kasher_oud
        {
            get { return (bool)listProperties.value("logo_kasher_oud", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("logo_kasher_oud", value); }
        }

        public System.DateTime? seller_nextdate
        {
            get { return (System.DateTime?)listProperties.value("seller_nextdate", aField.FIELD_TYPE.DATETIME); }
        }

        public string sale_line_warn_msg
        {
            get { return (string)listProperties.value("sale_line_warn_msg", aField.FIELD_TYPE.TEXT); }
            set { listProperties.setValue("sale_line_warn_msg", value); }
        }

        public bool souche_ogm
        {
            get { return (bool)listProperties.value("souche_ogm", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("souche_ogm", value); }
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

        public string nom_reensachage
        {
            get { return (string)listProperties.value("nom_reensachage", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("nom_reensachage", value); }
        }

        private oneToMany _f_risque_ids = new oneToMany();
        public oneToMany risque_ids
        {
            get { return _f_risque_ids; }
        }

        public double qty_available
        {
            get { return (double)listProperties.value("qty_available", aField.FIELD_TYPE.FLOAT); }
        }

        public string commentaire_negoce
        {
            get { return (string)listProperties.value("commentaire_negoce", aField.FIELD_TYPE.TEXT); }
            set { listProperties.setValue("commentaire_negoce", value); }
        }

        public string old_meldens
        {
            get { return (string)listProperties.value("old_meldens", aField.FIELD_TYPE.CHAR); }
        }

        public double uos_coeff
        {
            get { return (double)listProperties.value("uos_coeff", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("uos_coeff", value); }
        }

        public double sample_qty
        {
            get { return (double)listProperties.value("sample_qty", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("sample_qty", value); }
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

        public string collant_code
        {
            get { return (string)listProperties.value("collant_code", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("collant_code", value); }
        }

        public bool purchase_ok
        {
            get { return (bool)listProperties.value("purchase_ok", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("purchase_ok", value); }
        }

        private manyToOne _f_product_manager = new manyToOne();
        public manyToOne product_manager
        {
            get { return _f_product_manager; }
        }

        public string enzyme_code
        {
            get { return (string)listProperties.value("enzyme_code", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("enzyme_code", value); }
        }

        public bool control_gustalis
        {
            get { return (bool)listProperties.value("control_gustalis", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("control_gustalis", value); }
        }

        private oneToMany _f_validation_ids = new oneToMany();
        public oneToMany validation_ids
        {
            get { return _f_validation_ids; }
        }

        public int dluo_pf
        {
            get { return (int)listProperties.value("dluo_pf", aField.FIELD_TYPE.INTEGER); }
            set { listProperties.setValue("dluo_pf", value); }
        }

        public string commentaire_souche
        {
            get { return (string)listProperties.value("commentaire_souche", aField.FIELD_TYPE.TEXT); }
            set { listProperties.setValue("commentaire_souche", value); }
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

        public bool control_physico
        {
            get { return (bool)listProperties.value("control_physico", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("control_physico", value); }
        }

        public string commentaire_interne
        {
            get { return (string)listProperties.value("commentaire_interne", aField.FIELD_TYPE.TEXT); }
            set { listProperties.setValue("commentaire_interne", value); }
        }

        public string declaration_eurogerm
        {
            get { return (string)listProperties.value("declaration_eurogerm", aField.FIELD_TYPE.TEXT); }
            set { listProperties.setValue("declaration_eurogerm", value); }
        }
        private IMDEV.OpenERP.models.fields.texteMultilangue _declaration_eurogerm_multilangue;
        public IMDEV.OpenERP.models.fields.texteMultilangue declaration_eurogerm_multilangue
        {
            get
            {
                if (_declaration_eurogerm_multilangue == null) _declaration_eurogerm_multilangue = new IMDEV.OpenERP.models.fields.texteMultilangue(this, "declaration_eurogerm");
                return _declaration_eurogerm_multilangue;
            }
        }

        private manyToOne _f_seller_packaging_id = new manyToOne();
        public manyToOne seller_packaging_id
        {
            get { return _f_seller_packaging_id; }
        }

        public string allergen_code
        {
            get { return (string)listProperties.value("allergen_code", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("allergen_code", value); }
        }

        public bool track_incoming
        {
            get { return (bool)listProperties.value("track_incoming", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("track_incoming", value); }
        }

        private manyToOne _f_property_stock_production = new manyToOne();
        public manyToOne property_stock_production
        {
            get { return _f_property_stock_production; }
        }

        private manyToMany _f_supplier_taxes_id = new manyToMany();
        public manyToMany supplier_taxes_id
        {
            get { return _f_supplier_taxes_id; }
        }

        public double volume
        {
            get { return (double)listProperties.value("volume", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("volume", value); }
        }

        public string conditions_utilisation
        {
            get { return (string)listProperties.value("conditions_utilisation", aField.FIELD_TYPE.TEXT); }
            set { listProperties.setValue("conditions_utilisation", value); }
        }

        public bool not_printed_saleorder
        {
            get { return (bool)listProperties.value("not_printed_saleorder", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("not_printed_saleorder", value); }
        }

        public string commentaire_interne_pa
        {
            get { return (string)listProperties.value("commentaire_interne_pa", aField.FIELD_TYPE.TEXT); }
            set { listProperties.setValue("commentaire_interne_pa", value); }
        }

        public bool is_label
        {
            get { return (bool)listProperties.value("is_label", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("is_label", value); }
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

        private manyToOne _f_property_stock_inventory = new manyToOne();
        public manyToOne property_stock_inventory
        {
            get { return _f_property_stock_inventory; }
        }

        public double seller_qty
        {
            get { return (double)listProperties.value("seller_qty", aField.FIELD_TYPE.FLOAT); }
        }

        public enum ENUM_VALUATION
        {
            NULL
            ,
            @real_time
                , @manual_periodic
        }
        private string[] _frv_valuation = new string[] { "NULL", "real_time", "manual_periodic" };
        private string[] _fl_valuation = new string[] { "NULL", "Real Time (automated)", "Periodical (manual)" };
        private ENUM_VALUATION _fv_valuation;
        public ENUM_VALUATION valuation
        {
            get { return _fv_valuation; }
            set { _fv_valuation = value; }
        }
        public string LIBELLE_valuation
        {
            get { return _fl_valuation[(int)_fv_valuation]; }
        }

        public string sample_comment
        {
            get { return (string)listProperties.value("sample_comment", aField.FIELD_TYPE.TEXT); }
            set { listProperties.setValue("sample_comment", value); }
        }

        public bool logo_bio_europ
        {
            get { return (bool)listProperties.value("logo_bio_europ", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("logo_bio_europ", value); }
        }

        public bool ft_with_bl
        {
            get { return (bool)listProperties.value("ft_with_bl", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("ft_with_bl", value); }
        }

        public double sale_delay
        {
            get { return (double)listProperties.value("sale_delay", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("sale_delay", value); }
        }

        public bool auto_consumer
        {
            get { return (bool)listProperties.value("auto_consumer", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("auto_consumer", value); }
        }

        private manyToOne _f_seller_contract_id = new manyToOne();
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

        public enum ENUM_PURCHASE_LINE_WARN
        {
            NULL
            ,
            @block
                ,
            @no_LESS_message
                , @warning
        }
        private string[] _frv_purchase_line_warn = new string[] { "NULL", "block", "no-message", "warning" };
        private string[] _fl_purchase_line_warn = new string[] { "NULL", "Blocking Message", "No Message", "Warning" };
        private ENUM_PURCHASE_LINE_WARN _fv_purchase_line_warn;
        public ENUM_PURCHASE_LINE_WARN purchase_line_warn
        {
            get { return _fv_purchase_line_warn; }
            set { _fv_purchase_line_warn = value; }
        }
        public string LIBELLE_purchase_line_warn
        {
            get { return _fl_purchase_line_warn[(int)_fv_purchase_line_warn]; }
        }

        public string manufacturing_instruction
        {
            get { return (string)listProperties.value("manufacturing_instruction", aField.FIELD_TYPE.TEXT); }
            set { listProperties.setValue("manufacturing_instruction", value); }
        }

        private manyToMany _f_waiting_state_ids = new manyToMany();
        public manyToMany waiting_state_ids
        {
            get { return _f_waiting_state_ids; }
        }

        public string allergen_family
        {
            get { return (string)listProperties.value("allergen_family", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("allergen_family", value); }
        }

        public bool quality_info
        {
            get { return (bool)listProperties.value("quality_info", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("quality_info", value); }
        }

        private oneToMany _f_supplier_origin_ids = new oneToMany();
        public oneToMany supplier_origin_ids
        {
            get { return _f_supplier_origin_ids; }
        }

        public string family_code
        {
            get { return (string)listProperties.value("family_code", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("family_code", value); }
        }

        public bool force_show_report
        {
            get { return (bool)listProperties.value("force_show_report", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("force_show_report", value); }
        }

        public bool souche_conventionnelle
        {
            get { return (bool)listProperties.value("souche_conventionnelle", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("souche_conventionnelle", value); }
        }

        public bool control_fournil
        {
            get { return (bool)listProperties.value("control_fournil", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("control_fournil", value); }
        }

        public bool track_production
        {
            get { return (bool)listProperties.value("track_production", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("track_production", value); }
        }

        public enum ENUM_SALE_LINE_WARN
        {
            NULL
            ,
            @block
                ,
            @no_LESS_message
                , @warning
        }
        private string[] _frv_sale_line_warn = new string[] { "NULL", "block", "no-message", "warning" };
        private string[] _fl_sale_line_warn = new string[] { "NULL", "Blocking Message", "No Message", "Warning" };
        private ENUM_SALE_LINE_WARN _fv_sale_line_warn;
        public ENUM_SALE_LINE_WARN sale_line_warn
        {
            get { return _fv_sale_line_warn; }
            set { _fv_sale_line_warn = value; }
        }
        public string LIBELLE_sale_line_warn
        {
            get { return _fl_sale_line_warn[(int)_fv_sale_line_warn]; }
        }

        public bool logo_kasher_ou
        {
            get { return (bool)listProperties.value("logo_kasher_ou", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("logo_kasher_ou", value); }
        }

        public string use_condition
        {
            get { return (string)listProperties.value("use_condition", aField.FIELD_TYPE.TEXT); }
            set { listProperties.setValue("use_condition", value); }
        }

        public double price_extra
        {
            get { return (double)listProperties.value("price_extra", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("price_extra", value); }
        }

        private manyToOne _f_uom_id = new manyToOne();
        public manyToOne uom_id
        {
            get { return _f_uom_id; }
        }

        public string repacked_name
        {
            get { return (string)listProperties.value("repacked_name", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("repacked_name", value); }
        }
        private IMDEV.OpenERP.models.fields.texteMultilangue _repacked_name_multilangue;
        public IMDEV.OpenERP.models.fields.texteMultilangue repacked_name_multilangue
        {
            get
            {
                if (_repacked_name_multilangue == null) _repacked_name_multilangue = new IMDEV.OpenERP.models.fields.texteMultilangue(this, "repacked_name");
                return _repacked_name_multilangue;
            }
        }

        public string sale_name
        {
            get { return (string)listProperties.value("sale_name", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("sale_name", value); }
        }
        private IMDEV.OpenERP.models.fields.texteMultilangue _sale_name_multilangue;
        public IMDEV.OpenERP.models.fields.texteMultilangue sale_name_multilangue
        {
            get
            {
                if (_sale_name_multilangue == null) _sale_name_multilangue = new IMDEV.OpenERP.models.fields.texteMultilangue(this, "sale_name");
                return _sale_name_multilangue;
            }
        }

        public bool hallal
        {
            get { return (bool)listProperties.value("hallal", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("hallal", value); }
        }

        private manyToMany _f_securite_operator_ids = new manyToMany();
        public manyToMany securite_operator_ids
        {
            get { return _f_securite_operator_ids; }
        }

        public bool standard_product
        {
            get { return (bool)listProperties.value("standard_product", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("standard_product", value); }
        }

        public bool subsidiary_trading
        {
            get { return (bool)listProperties.value("subsidiary_trading", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("subsidiary_trading", value); }
        }

        private manyToOne _f_location_id = new manyToOne();
        public manyToOne location_id
        {
            get { return _f_location_id; }
        }

        public string bio_comment
        {
            get { return (string)listProperties.value("bio_comment", aField.FIELD_TYPE.TEXT); }
            set { listProperties.setValue("bio_comment", value); }
        }
        private IMDEV.OpenERP.models.fields.texteMultilangue _bio_comment_multilangue;
        public IMDEV.OpenERP.models.fields.texteMultilangue bio_comment_multilangue
        {
            get
            {
                if (_bio_comment_multilangue == null) _bio_comment_multilangue = new IMDEV.OpenERP.models.fields.texteMultilangue(this, "bio_comment");
                return _bio_comment_multilangue;
            }
        }

        public bool have_pqcd_liv
        {
            get { return (bool)listProperties.value("have_pqcd_liv", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("have_pqcd_liv", value); }
        }

        private oneToMany _f_allergene_a_declarer_ids = new oneToMany();
        public oneToMany allergene_a_declarer_ids
        {
            get { return _f_allergene_a_declarer_ids; }
        }

        public bool track_outgoing
        {
            get { return (bool)listProperties.value("track_outgoing", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("track_outgoing", value); }
        }

        public double incoming_qty_virtual_done
        {
            get { return (double)listProperties.value("incoming_qty_virtual_done", aField.FIELD_TYPE.FLOAT); }
        }

        public string odor_code
        {
            get { return (string)listProperties.value("odor_code", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("odor_code", value); }
        }

        private manyToOne _f_uom_po_id = new manyToOne();
        public manyToOne uom_po_id
        {
            get { return _f_uom_po_id; }
        }

        private manyToOne _f_intrastat_id = new manyToOne();
        public manyToOne intrastat_id
        {
            get { return _f_intrastat_id; }
        }

        public int revision
        {
            get { return (int)listProperties.value("revision", aField.FIELD_TYPE.INTEGER); }
            set { listProperties.setValue("revision", value); }
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

        public double weight_net
        {
            get { return (double)listProperties.value("weight_net", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("weight_net", value); }
        }

        public string meldens
        {
            get { return (string)listProperties.value("meldens", aField.FIELD_TYPE.CHAR); }
        }

        private manyToOne _f_categ_id = new manyToOne();
        public manyToOne categ_id
        {
            get { return _f_categ_id; }
        }

        public int removal_time
        {
            get { return (int)listProperties.value("removal_time", aField.FIELD_TYPE.INTEGER); }
            set { listProperties.setValue("removal_time", value); }
        }

        public double ratio_pa
        {
            get { return (double)listProperties.value("ratio_pa", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("ratio_pa", value); }
        }

        public string commentaire_reensachage
        {
            get { return (string)listProperties.value("commentaire_reensachage", aField.FIELD_TYPE.TEXT); }
            set { listProperties.setValue("commentaire_reensachage", value); }
        }

        public double produce_delay
        {
            get { return (double)listProperties.value("produce_delay", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("produce_delay", value); }
        }

        private manyToOne _f_property_account_expense = new manyToOne();
        public manyToOne property_account_expense
        {
            get { return _f_property_account_expense; }
        }

        private manyToMany _f_stockage_type_ids = new manyToMany();
        public manyToMany stockage_type_ids
        {
            get { return _f_stockage_type_ids; }
        }

        public bool vitamix_gain
        {
            get { return (bool)listProperties.value("vitamix_gain", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("vitamix_gain", value); }
        }

        public int alert_time
        {
            get { return (int)listProperties.value("alert_time", aField.FIELD_TYPE.INTEGER); }
            set { listProperties.setValue("alert_time", value); }
        }

        private manyToMany _f_taxes_id = new manyToMany();
        public manyToMany taxes_id
        {
            get { return _f_taxes_id; }
        }

        public bool kasher
        {
            get { return (bool)listProperties.value("kasher", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("kasher", value); }
        }

        public bool gift_points
        {
            get { return (bool)listProperties.value("gift_points", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("gift_points", value); }
        }

        private manyToOne _f_root_code_id = new manyToOne();
        public manyToOne root_code_id
        {
            get { return _f_root_code_id; }
        }

        public bool logo_halal
        {
            get { return (bool)listProperties.value("logo_halal", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("logo_halal", value); }
        }

        public double futur_purchasing_price
        {
            get { return (double)listProperties.value("futur_purchasing_price", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("futur_purchasing_price", value); }
        }

        public double futur_commercial_price
        {
            get { return (double)listProperties.value("futur_commercial_price", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("futur_commercial_price", value); }
        }

        public int id
        {
            get { return (int)listProperties.value("id", aField.FIELD_TYPE.INTEGER); }
            set { listProperties.setValue("id", value); }
        }

        public bool presence_tier_software
        {
            get { return (bool)listProperties.value("presence_tier_software", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("presence_tier_software", value); }
        }

        public override string resource_name()
        {
            return "product.product";
        }

        #region "Caractéristiques/Formulateur"

        public void removeAllSupplierTaxes()
        {
            if (_f_supplier_taxes_id.getValue != null)
                foreach (int id in _f_supplier_taxes_id.getValue)
                    _f_supplier_taxes_id.removeLink(id);
        }

        public void removeAllTaxes()
        {
            if (_f_taxes_id.getValue != null)
                foreach (int id in _f_taxes_id.getValue)
                    _f_taxes_id.removeLink(id);
        }

        private product_valnut _valnut;
        public product_valnut valnut
        {
            get { return _valnut; }
            set { _valnut = value; }
        }
        public bool loadValnut(Clients.clientOpenERP clientOERP)
        {
            if ((_valnut != null) && (_valnut.id == _f_valnut_id.id)) return true;
            return loadValnutData(clientOERP);
        }
        private bool loadValnutData(Clients.clientOpenERP clientOERP)
        {
            try
            {
                _valnut = (product_valnut)clientOERP.read(new IMDEV.OpenERP.models.query.aQuery(_f_valnut_id.id), typeof(product_valnut))[0];
                return true;
            }
            catch { }
            return false;
        }

        public void removeAllSecurity()
        {
            if (_f_securite_ids.getValue != null)
                foreach (int id in _f_securite_ids.getValue)
                    _f_securite_ids.removeLink(id);
        }

        public void removeAllLineCode()
        {
            if (_f_line_code.getValue != null)
                foreach (int id in _f_line_code.getValue)
                    _f_line_code.removeLink(id);
        }

        public void removeAllStockageType()
        {
            if (_f_stockage_type_ids.getValue != null)
                foreach (int id in _f_stockage_type_ids.getValue)
                    _f_stockage_type_ids.removeLink(id);
        }

        public void removeAllCountry()
        {
            if (_f_authorized_country_ids.getValue != null)
                foreach (int id in _f_authorized_country_ids.getValue)
                    _f_authorized_country_ids.removeLink(id);
        }

        public void removeAllOrigins()
        {
            if (_f_supplier_origin_ids.getValue != null)
                foreach (int id in _f_supplier_origin_ids.getValue)
                    _f_supplier_origin_ids.delLinkAndObj(id);
        }

        public void removeAllRisk()
        {
            if (_f_risque_ids.getValue != null)
                foreach (int id in _f_risque_ids.getValue)
                    _f_risque_ids.delLinkAndObj(id);
        }

        public void removeAllRiskTechnology()
        {
            if (_f_risk_technology_ids.getValue != null)
                foreach (int id in _f_risk_technology_ids.getValue)
                    _f_risk_technology_ids.delLinkAndObj(id);
        }

        public void removeAllAllergens()
        {
            if (_f_allergene_a_declarer_ids.getValue != null)
                foreach (int id in _f_allergene_a_declarer_ids.getValue)
                    _f_allergene_a_declarer_ids.delLinkAndObj(id);
        }

        private product_template _myTemplate;

        public product_template myTemplate()
        {
            return myTemplate(null);
        }
        public product_template myTemplate(Clients.clientOpenERP clientOERP)
        {
            if ((_myTemplate == null) && (_f_product_tmpl_id.id > 0) && (clientOERP != null))
                try
                {
                    _myTemplate = (product_template)clientOERP.read(new IMDEV.OpenERP.models.query.aQuery(_f_product_tmpl_id.id), typeof(product_template))[0];
                }
                catch { }
            return _myTemplate;
        }

        public List<product_supplierinfo> listSuppliers(Clients.clientOpenERP clientOERP)
        {
            return listSuppliers(clientOERP, null);
        }
        public List<product_supplierinfo> listSuppliers(Clients.clientOpenERP clientOERP, List<string> listeChamps)
        {
            try
            {
                OpenERP.models.query.aQuery query = new IMDEV.OpenERP.models.query.aQuery();
                query.addEqualTo("product_id", _f_product_tmpl_id.id);
                List<object> retour;
                retour = clientOERP.search(query, typeof(product_supplierinfo), true,listeChamps);
                if (retour != null)
                {
                    List<product_supplierinfo> back = new List<product_supplierinfo>();
                    foreach (product_supplierinfo obj in retour)
                        back.Add(obj);
                    return back;
                }
            }
            catch { }
            return null;
        }

        public List<product_risk_label> allRisk(Clients.clientOpenERP clientOERP)
        {
            return loadAllRiskData(clientOERP);
        }

        private List<product_risk_label> loadAllRiskData(Clients.clientOpenERP clientOERP)
        {
            List<object> result;
            List<product_risk_label> retour;

            if ((_f_risque_ids.getValue != null) && (_f_risque_ids.getValue.Count > 0))
            {
                result = clientOERP.read(new IMDEV.OpenERP.models.query.aQuery(_f_risque_ids.getValue), typeof(product_risk_label));
                if ((result != null) && (result.Count > 0))
                {
                    retour = new List<product_risk_label>();
                    foreach (product_risk_label r in result)
                        retour.Add(r);
                    return retour;
                }
            }
            return null;
        }

        public List<product_supplierorigins> allOrigins(Clients.clientOpenERP clientOERP)
        {
            return allOriginsData(clientOERP);
        }

        private List<product_supplierorigins> allOriginsData(Clients.clientOpenERP clientOERP)
        {
            List<object> result;
            List<product_supplierorigins> retour;

            if ((_f_supplier_origin_ids.getValue != null) && (_f_supplier_origin_ids.getValue.Count > 0))
            {
                result = clientOERP.read(new IMDEV.OpenERP.models.query.aQuery(_f_supplier_origin_ids.getValue), typeof(product_supplierorigins));
                if ((result != null) && (result.Count > 0))
                {
                    retour = new List<product_supplierorigins>();
                    foreach (product_supplierorigins o in result)
                        retour.Add(o);
                    return retour;
                }
            }
            return null;
        }

        public List<product_security> allSecurity(Clients.clientOpenERP clientOERP)
        {
            return allSecurityData(clientOERP);
        }

        private List<product_security> allSecurityData(Clients.clientOpenERP clientOERP)
        {
            List<object> result;
            List<product_security> retour;

            if ((_f_securite_ids.getValue != null) && (_f_securite_ids.getValue.Count > 0))
            {
                result = clientOERP.read(new IMDEV.OpenERP.models.query.aQuery(_f_securite_ids.getValue), typeof(product_security));
                if ((result != null) && (result.Count > 0))
                {
                    retour = new List<product_security>();
                    foreach (product_security s in result)
                        retour.Add(s);
                    return retour;
                }
            }
            return null;
        }

        public List<product_allergen_to_declare> allAllergens(Clients.clientOpenERP clientOERP)
        {
            return allAllergensData(clientOERP);
        }

        private List<product_allergen_to_declare> allAllergensData(Clients.clientOpenERP clientOERP)
        {
            List<object> result;
            List<product_allergen_to_declare> retour;

            if ((_f_allergene_a_declarer_ids.getValue != null) && (_f_allergene_a_declarer_ids.getValue.Count > 0))
            {
                result = clientOERP.read(new IMDEV.OpenERP.models.query.aQuery(_f_allergene_a_declarer_ids.getValue), typeof(product_allergen_to_declare));
                if ((result!=null) && (result.Count>0))
                {
                    retour = new List<product_allergen_to_declare>();
                    foreach (product_allergen_to_declare a in result)
                        retour.Add(a);
                    return retour;
                }
            }
            return null;
        }

        public List<product_risk_technology> allRiskTechnology(Clients.clientOpenERP clientOERP)
        {
            return allRiskTechnologyData(clientOERP);
        }

        private List<product_risk_technology> allRiskTechnologyData(Clients.clientOpenERP clientOERP)
        {
            List<object> result;
            List<product_risk_technology> retour;

            if ((_f_risk_technology_ids.getValue != null) && (_f_risk_technology_ids.getValue.Count > 0))
            {
                result = clientOERP.read(new IMDEV.OpenERP.models.query.aQuery(_f_risk_technology_ids.getValue), typeof(product_risk_technology));
                if ((result != null) && (result.Count > 0))
                {
                    retour = new List<product_risk_technology>();
                    foreach (product_risk_technology rt in result)
                        retour.Add(rt);
                    return retour;
                }
            }
            return null;
        }

        public void removeAllApplication()
        {
            if ((_f_application_type_ids.getValue != null) && (_f_application_type_ids.getValue.Count > 0))
                foreach (int id in _f_application_type_ids.getValue)
                    _f_application_type_ids.removeLink(id);
        }

        public void removeAllProcess()
        {
            if ((_f_process_type_ids.getValue != null) && (_f_process_type_ids.getValue.Count > 0))
                foreach (int id in _f_process_type_ids.getValue)
                    _f_process_type_ids.removeLink(id);
        }

        public void removeValnut()
        {
            if (_f_valnut_id.id > 0) _f_valnut_id.setValue(0);
        }

        public bool negoce()
        {
            return ((sale_ok) || (subsidiary_trading) || (repacked_trading));
        }

        #endregion
    }
}
