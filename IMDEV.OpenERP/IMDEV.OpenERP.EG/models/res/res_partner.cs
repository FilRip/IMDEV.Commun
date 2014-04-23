using IMDEV.OpenERP.models.@base;
using IMDEV.OpenERP.models.fields.relations;
using System.Collections.Generic;

namespace IMDEV.OpenERP.EG.models.res
{
    public class res_partner : anOpenERPObject
    {
        public string ean13
        {
            get { return (string)listProperties.value("ean13", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("ean13", value); }
        }

        private manyToOne _f_property_account_position = new manyToOne();
        public manyToOne property_account_position
        {
            get { return _f_property_account_position; }
        }

        private oneToMany _f_ref_companies = new oneToMany();
        public oneToMany ref_companies
        {
            get { return _f_ref_companies; }
        }

        public int pallet_qty
        {
            get { return (int)listProperties.value("pallet_qty", aField.FIELD_TYPE.INTEGER); }
            set { listProperties.setValue("pallet_qty", value); }
        }

        public bool eg_waiting_no_production
        {
            get { return (bool)listProperties.value("eg_waiting_no_production", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("eg_waiting_no_production", value); }
        }

        private manyToOne _f_intrastat_fiscal_representative = new manyToOne();
        public manyToOne intrastat_fiscal_representative
        {
            get { return _f_intrastat_fiscal_representative; }
        }

        public int delivery_nbr_lot
        {
            get { return (int)listProperties.value("delivery_nbr_lot", aField.FIELD_TYPE.INTEGER); }
            set { listProperties.setValue("delivery_nbr_lot", value); }
        }

        private manyToOne _f_property_stock_customer = new manyToOne();
        public manyToOne property_stock_customer
        {
            get { return _f_property_stock_customer; }
        }

        private manyToOne _f_property_product_pricelist = new manyToOne();
        public manyToOne property_product_pricelist
        {
            get { return _f_property_product_pricelist; }
        }

        public string note_account
        {
            get { return (string)listProperties.value("note_account", aField.FIELD_TYPE.TEXT); }
            set { listProperties.setValue("note_account", value); }
        }

        private manyToOne _f_title = new manyToOne();
        public manyToOne title
        {
            get { return _f_title; }
        }

        public string old_code
        {
            get { return (string)listProperties.value("old_code", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("old_code", value); }
        }

        private manyToOne _f_company_id = new manyToOne();
        public manyToOne company_id
        {
            get { return _f_company_id; }
        }

        private oneToMany _f_pallet_type_ids = new oneToMany();
        public oneToMany pallet_type_ids
        {
            get { return _f_pallet_type_ids; }
        }

        public System.DateTime last_reconciliation_date
        {
            get { return (System.DateTime)listProperties.value("last_reconciliation_date", aField.FIELD_TYPE.DATETIME); }
            set { listProperties.setValue("last_reconciliation_date", value); }
        }

        public bool employee
        {
            get { return (bool)listProperties.value("employee", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("employee", value); }
        }

        public bool eg_waiting_payment
        {
            get { return (bool)listProperties.value("eg_waiting_payment", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("eg_waiting_payment", value); }
        }

        public string note_reception
        {
            get { return (string)listProperties.value("note_reception", aField.FIELD_TYPE.TEXT); }
            set { listProperties.setValue("note_reception", value); }
        }

        private oneToMany _f_child_ids = new oneToMany();
        public oneToMany child_ids
        {
            get { return _f_child_ids; }
        }

        public bool is_standard
        {
            get { return (bool)listProperties.value("is_standard", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("is_standard", value); }
        }

        private manyToMany _f_assistant_ids = new manyToMany();
        public manyToMany assistant_ids
        {
            get { return _f_assistant_ids; }
        }

        public bool have_pqcd_cde
        {
            get { return (bool)listProperties.value("have_pqcd_cde", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("have_pqcd_cde", value); }
        }

        private oneToMany _f_emails = new oneToMany();
        public oneToMany emails
        {
            get { return _f_emails; }
        }

        public string analysis_link
        {
            get { return (string)listProperties.value("analysis_link", aField.FIELD_TYPE.CHAR); }
        }

        public string name
        {
            get { return (string)listProperties.value("name", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("name", value); }
        }

        public double debit_limit
        {
            get { return (double)listProperties.value("debit_limit", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("debit_limit", value); }
        }

        private manyToOne _f_property_delivery_carrier = new manyToOne();
        public manyToOne property_delivery_carrier
        {
            get { return _f_property_delivery_carrier; }
        }

        private manyToOne _f_property_account_receivable = new manyToOne();
        public manyToOne property_account_receivable
        {
            get { return _f_property_account_receivable; }
        }

        private oneToMany _f_contract_ids = new oneToMany();
        public oneToMany contract_ids
        {
            get { return _f_contract_ids; }
        }

        public int points_nbr
        {
            get { return (int)listProperties.value("points_nbr", aField.FIELD_TYPE.INTEGER); }
            set { listProperties.setValue("points_nbr", value); }
        }

        public string pql_note
        {
            get { return (string)listProperties.value("pql_note", aField.FIELD_TYPE.TEXT); }
            set { listProperties.setValue("pql_note", value); }
        }

        private manyToOne _f_company_bank_id = new manyToOne();
        public manyToOne company_bank_id
        {
            get { return _f_company_bank_id; }
        }

        public string siret_number
        {
            get { return (string)listProperties.value("siret_number", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("siret_number", value); }
        }

        public bool vat_subjected
        {
            get { return (bool)listProperties.value("vat_subjected", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("vat_subjected", value); }
        }

        public bool delivery_with_tailgate
        {
            get { return (bool)listProperties.value("delivery_with_tailgate", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("delivery_with_tailgate", value); }
        }

        public string internal_name
        {
            get { return (string)listProperties.value("internal_name", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("internal_name", value); }
        }

        public double debit
        {
            get { return (double)listProperties.value("debit", aField.FIELD_TYPE.FLOAT); }
        }

        public bool supplier
        {
            get { return (bool)listProperties.value("supplier", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("supplier", value); }
        }

        public bool special_prices
        {
            get { return (bool)listProperties.value("special_prices", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("special_prices", value); }
        }

        public bool mail_cac
        {
            get { return (bool)listProperties.value("mail_cac", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("mail_cac", value); }
        }

        public string @ref
        {
            get { return (string)listProperties.value("ref", aField.FIELD_TYPE.CHAR); }
        }

        public string email
        {
            get { return (string)listProperties.value("email", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("email", value); }
        }

        public enum ENUM_PICKING_WARN
        {
            NULL
            ,
            @block
                ,
            @no_LESS_message
                , @warning
        }
        private string[] _frv_picking_warn = new string[] { "NULL", "block", "no-message", "warning" };
        private string[] _fl_picking_warn = new string[] { "NULL", "Blocking Message", "No Message", "Warning" };
        private ENUM_PICKING_WARN _fv_picking_warn;
        public ENUM_PICKING_WARN picking_warn
        {
            get { return _fv_picking_warn; }
            set { _fv_picking_warn = value; }
        }
        public string LIBELLE_picking_warn
        {
            get { return _fl_picking_warn[(int)_fv_picking_warn]; }
        }

        public bool web_subscribe
        {
            get { return (bool)listProperties.value("web_subscribe", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("web_subscribe", value); }
        }

        private manyToOne _f_company_partner_id = new manyToOne();
        public manyToOne company_partner_id
        {
            get { return _f_company_partner_id; }
        }

        public string team_resp
        {
            get { return (string)listProperties.value("team_resp", aField.FIELD_TYPE.CHAR); }
        }

        private oneToMany _f_opportunity_ids = new oneToMany();
        public oneToMany opportunity_ids
        {
            get { return _f_opportunity_ids; }
        }

        private manyToOne _f_agent_id = new manyToOne();
        public manyToOne agent_id
        {
            get { return _f_agent_id; }
        }

        private oneToMany _f_address = new oneToMany();
        public oneToMany address
        {
            get { return _f_address; }
        }

        public bool active
        {
            get { return (bool)listProperties.value("active", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("active", value); }
        }

        public string internal_compta_num
        {
            get { return (string)listProperties.value("internal_compta_num", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("internal_compta_num", value); }
        }

        public int lot_dluo_mini
        {
            get { return (int)listProperties.value("lot_dluo_mini", aField.FIELD_TYPE.INTEGER); }
            set { listProperties.setValue("lot_dluo_mini", value); }
        }

        private manyToOne _f_property_product_pricelist_purchase = new manyToOne();
        public manyToOne property_product_pricelist_purchase
        {
            get { return _f_property_product_pricelist_purchase; }
        }

        private manyToOne _f_country = new manyToOne();
        public manyToOne country
        {
            get { return _f_country; }
        }

        public string pqexp_note
        {
            get { return (string)listProperties.value("pqexp_note", aField.FIELD_TYPE.TEXT); }
            set { listProperties.setValue("pqexp_note", value); }
        }

        public double credit
        {
            get { return (double)listProperties.value("credit", aField.FIELD_TYPE.FLOAT); }
        }

        private manyToOne _f_bulking_uom_id = new manyToOne();
        public manyToOne bulking_uom_id
        {
            get { return _f_bulking_uom_id; }
        }

        private oneToMany _f_product_ids = new oneToMany();
        public oneToMany product_ids
        {
            get { return _f_product_ids; }
        }

        public string comment
        {
            get { return (string)listProperties.value("comment", aField.FIELD_TYPE.TEXT); }
            set { listProperties.setValue("comment", value); }
        }

        public enum ENUM_SALE_WARN
        {
            NULL
            ,
            @block
                ,
            @no_LESS_message
                , @warning
        }
        private string[] _frv_sale_warn = new string[] { "NULL", "block", "no-message", "warning" };
        private string[] _fl_sale_warn = new string[] { "NULL", "Blocking Message", "No Message", "Warning" };
        private ENUM_SALE_WARN _fv_sale_warn;
        public ENUM_SALE_WARN sale_warn
        {
            get { return _fv_sale_warn; }
            set { _fv_sale_warn = value; }
        }
        public string LIBELLE_sale_warn
        {
            get { return _fl_sale_warn[(int)_fv_sale_warn]; }
        }

        public enum ENUM_PURCHASE_WARN
        {
            NULL
            ,
            @block
                ,
            @no_LESS_message
                , @warning
        }
        private string[] _frv_purchase_warn = new string[] { "NULL", "block", "no-message", "warning" };
        private string[] _fl_purchase_warn = new string[] { "NULL", "Blocking Message", "No Message", "Warning" };
        private ENUM_PURCHASE_WARN _fv_purchase_warn;
        public ENUM_PURCHASE_WARN purchase_warn
        {
            get { return _fv_purchase_warn; }
            set { _fv_purchase_warn = value; }
        }
        public string LIBELLE_purchase_warn
        {
            get { return _fl_purchase_warn[(int)_fv_purchase_warn]; }
        }

        public double gasoil_cost
        {
            get { return (double)listProperties.value("gasoil_cost", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("gasoil_cost", value); }
        }

        private oneToMany _f_invoice_ids = new oneToMany();
        public oneToMany invoice_ids
        {
            get { return _f_invoice_ids; }
        }

        public double tp_additional_cost
        {
            get { return (double)listProperties.value("tp_additional_cost", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("tp_additional_cost", value); }
        }

        private manyToOne _f_property_invoice_type = new manyToOne();
        public manyToOne property_invoice_type
        {
            get { return _f_property_invoice_type; }
        }

        private oneToMany _f_supplier_rc_ids = new oneToMany();
        public oneToMany supplier_rc_ids
        {
            get { return _f_supplier_rc_ids; }
        }

        public bool eg_waiting_quality
        {
            get { return (bool)listProperties.value("eg_waiting_quality", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("eg_waiting_quality", value); }
        }

        public string city
        {
            get { return (string)listProperties.value("city", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("city", value); }
        }

        private oneToMany _f_phonecall_ids = new oneToMany();
        public oneToMany phonecall_ids
        {
            get { return _f_phonecall_ids; }
        }

        private manyToOne _f_property_payment_term2 = new manyToOne();
        public manyToOne property_payment_term2
        {
            get { return _f_property_payment_term2; }
        }

        private manyToOne _f_user_id = new manyToOne();
        public manyToOne user_id
        {
            get { return _f_user_id; }
        }

        private manyToOne _f_parent_id = new manyToOne();
        public manyToOne parent_id
        {
            get { return _f_parent_id; }
        }

        public bool gift_points
        {
            get { return (bool)listProperties.value("gift_points", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("gift_points", value); }
        }

        public bool with_shipment
        {
            get { return (bool)listProperties.value("with_shipment", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("with_shipment", value); }
        }

        public string vat
        {
            get { return (string)listProperties.value("vat", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("vat", value); }
        }

        public string website
        {
            get { return (string)listProperties.value("website", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("website", value); }
        }

        public string picking_warn_msg
        {
            get { return (string)listProperties.value("picking_warn_msg", aField.FIELD_TYPE.TEXT); }
            set { listProperties.setValue("picking_warn_msg", value); }
        }

        public string note_supplier
        {
            get { return (string)listProperties.value("note_supplier", aField.FIELD_TYPE.TEXT); }
            set { listProperties.setValue("note_supplier", value); }
        }

        public string phone
        {
            get { return (string)listProperties.value("phone", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("phone", value); }
        }

        public bool subsidiary
        {
            get { return (bool)listProperties.value("subsidiary", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("subsidiary", value); }
        }

        public bool customer
        {
            get { return (bool)listProperties.value("customer", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("customer", value); }
        }

        public string purchase_warn_msg
        {
            get { return (string)listProperties.value("purchase_warn_msg", aField.FIELD_TYPE.TEXT); }
            set { listProperties.setValue("purchase_warn_msg", value); }
        }

        public int shipment_delay
        {
            get { return (int)listProperties.value("shipment_delay", aField.FIELD_TYPE.INTEGER); }
            set { listProperties.setValue("shipment_delay", value); }
        }

        public string invoice_warn_msg
        {
            get { return (string)listProperties.value("invoice_warn_msg", aField.FIELD_TYPE.TEXT); }
            set { listProperties.setValue("invoice_warn_msg", value); }
        }

        private oneToMany _f_relation_ids = new oneToMany();
        public oneToMany relation_ids
        {
            get { return _f_relation_ids; }
        }

        public bool eg_waiting_no_delivering
        {
            get { return (bool)listProperties.value("eg_waiting_no_delivering", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("eg_waiting_no_delivering", value); }
        }

        private oneToMany _f_meeting_ids = new oneToMany();
        public oneToMany meeting_ids
        {
            get { return _f_meeting_ids; }
        }

        public bool have_pqcd_liv
        {
            get { return (bool)listProperties.value("have_pqcd_liv", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("have_pqcd_liv", value); }
        }

        public int delivery_delay
        {
            get { return (int)listProperties.value("delivery_delay", aField.FIELD_TYPE.INTEGER); }
            set { listProperties.setValue("delivery_delay", value); }
        }

        public enum ENUM_INVOICE_WARN
        {
            NULL
            ,
            @block
                ,
            @no_LESS_message
                , @warning
        }
        private string[] _frv_invoice_warn = new string[] { "NULL", "block", "no-message", "warning" };
        private string[] _fl_invoice_warn = new string[] { "NULL", "Blocking Message", "No Message", "Warning" };
        private ENUM_INVOICE_WARN _fv_invoice_warn;
        public ENUM_INVOICE_WARN invoice_warn
        {
            get { return _fv_invoice_warn; }
            set { _fv_invoice_warn = value; }
        }
        public string LIBELLE_invoice_warn
        {
            get { return _fl_invoice_warn[(int)_fv_invoice_warn]; }
        }

        private manyToOne _f_property_account_payable = new manyToOne();
        public manyToOne property_account_payable
        {
            get { return _f_property_account_payable; }
        }

        private manyToOne _f_property_stock_supplier = new manyToOne();
        public manyToOne property_stock_supplier
        {
            get { return _f_property_stock_supplier; }
        }

        private oneToMany _f_events = new oneToMany();
        public oneToMany events
        {
            get { return _f_events; }
        }

        public string ape_number
        {
            get { return (string)listProperties.value("ape_number", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("ape_number", value); }
        }

        private oneToMany _f_bank_ids = new oneToMany();
        public oneToMany bank_ids
        {
            get { return _f_bank_ids; }
        }

        public double bulking_qty
        {
            get { return (double)listProperties.value("bulking_qty", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("bulking_qty", value); }
        }

        private manyToOne _f_section_id = new manyToOne();
        public manyToOne section_id
        {
            get { return _f_section_id; }
        }

        public string directory_link
        {
            get { return (string)listProperties.value("directory_link", aField.FIELD_TYPE.CHAR); }
        }

        private manyToOne _f_salesman_duo_id = new manyToOne();
        public manyToOne salesman_duo_id
        {
            get { return _f_salesman_duo_id; }
        }

        public System.DateTime date
        {
            get { return (System.DateTime)listProperties.value("date", aField.FIELD_TYPE.DATE); }
            set { listProperties.setValue("date", value); }
        }

        private manyToMany _f_category_id = new manyToMany();
        public manyToMany category_id
        {
            get { return _f_category_id; }
        }

        public enum ENUM_LANG
        {
            NULL
            ,
            @es_ES
                ,
            @it_IT
                ,
            @fr_FR
                ,
            @zh_CN
                ,
            _EMPTY_
                ,
            @de_DE
                ,
            @pt_PT
                ,
            @fr
                ,
            @en_US
                , @ar_AR
        }
        private string[] _frv_lang = new string[] { "NULL", "es_ES", "it_IT", "fr_FR", "zh_CN", "", "de_DE", "pt_PT", "fr", "en_US", "ar_AR" };
        private string[] _fl_lang = new string[] { "NULL", "Spanish / Español", "Italian / Italiano", "French / Français", "Chinese (CN) / 简体中文", "", "German / Deutsch", "Portugese / Português", "fr", "English", "Arabic / الْعَرَبيّة" };
        private ENUM_LANG _fv_lang;
        public ENUM_LANG lang
        {
            get { return _fv_lang; }
            set { _fv_lang = value; }
        }
        public string LIBELLE_lang
        {
            get { return _fl_lang[(int)_fv_lang]; }
        }

        public string pqp_note
        {
            get { return (string)listProperties.value("pqp_note", aField.FIELD_TYPE.TEXT); }
            set { listProperties.setValue("pqp_note", value); }
        }

        public double credit_limit
        {
            get { return (double)listProperties.value("credit_limit", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("credit_limit", value); }
        }

        public bool mail_analyses
        {
            get { return (bool)listProperties.value("mail_analyses", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("mail_analyses", value); }
        }

        public string mobile
        {
            get { return (string)listProperties.value("mobile", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("mobile", value); }
        }

        private oneToMany _f_visit_report_ids = new oneToMany();
        public oneToMany visit_report_ids
        {
            get { return _f_visit_report_ids; }
        }

        private manyToOne _f_property_payment_term = new manyToOne();
        public manyToOne property_payment_term
        {
            get { return _f_property_payment_term; }
        }

        public string sale_warn_msg
        {
            get { return (string)listProperties.value("sale_warn_msg", aField.FIELD_TYPE.TEXT); }
            set { listProperties.setValue("sale_warn_msg", value); }
        }

        public string internal_compta_num_supplier
        {
            get { return (string)listProperties.value("internal_compta_num_supplier", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("internal_compta_num_supplier", value); }
        }

        public string chronotec_email
        {
            get { return (string)listProperties.value("chronotec_email", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("chronotec_email", value); }
        }

        public int id
        {
            get { return (int)listProperties.value("id", aField.FIELD_TYPE.INTEGER); }
            set { listProperties.setValue("id", value); }
        }
        public override string resource_name()
        {
            return "res.partner";
        }

        public string pqcd_note
        {
            get { return (string)listProperties.value("pqcd_note", aField.FIELD_TYPE.TEXT); }
            set { listProperties.setValue("pqcd_note", value); }
        }

        #region "CaractéristiquesMatières/Formulateur"

        public res_partner_address getAddress(OpenERP.Clients.clientOpenERP clientOpenERP)
        {
            return getAddress(clientOpenERP, res_partner_address.ENUM_TYPE.@default, null);
        }
        public res_partner_address getAddress(OpenERP.Clients.clientOpenERP clientOpenERP, List<string> listeChamps)
        {
            return getAddress(clientOpenERP, res_partner_address.ENUM_TYPE.@default, listeChamps);
        }
        public res_partner_address getAddress(OpenERP.Clients.clientOpenERP clientOpenERP, res_partner_address.ENUM_TYPE typeAdr)
        {
            return getAddress(clientOpenERP, typeAdr, null);
        }
        public res_partner_address getAddress(OpenERP.Clients.clientOpenERP clientOpenERP, res_partner_address.ENUM_TYPE typeAdr, List<string> listeChamps)
        {
            if ((_f_address.getValue != null) && (_f_address.getValue.Count > 0))
            {
                List<object> retour;
                OpenERP.models.query.aQuery req;

                req = new IMDEV.OpenERP.models.query.aQuery();
                req.addEqualTo("type", typeAdr.ToString());
                req.addAND();
                req.addEqualTo("partner_id", id);
                retour = clientOpenERP.search(req, typeof(res_partner_address), true, listeChamps);
                if ((retour != null) && (retour.Count >= 1))
                    return (res_partner_address)retour[0];
            }
            return null;
        }

        public List<res_partner_contact> getContacts(OpenERP.Clients.clientOpenERP clientOpenERP)
        {
            return getContacts(clientOpenERP, null);
        }
        public List<res_partner_contact> getContacts(OpenERP.Clients.clientOpenERP clientOpenERP, List<string> listeChamps)
        {
            if ((_f_contract_ids.getValue != null) && (_f_contract_ids.getValue.Count > 0))
            {
                IMDEV.OpenERP.models.query.aQuery req=new IMDEV.OpenERP.models.query.aQuery();
                List<object> retour;
                List<res_partner_contact> result;
                req.addEqualTo("partner_id", id);
                retour = clientOpenERP.search(req, typeof(res_partner_contact), true, listeChamps);
                if ((retour != null) && (retour.Count > 0))
                {
                    result = new List<res_partner_contact>();
                    foreach (res_partner_contact rpc in retour)
                        result.Add(rpc);
                    return result;
                }
            }
            return null;
        }

        public crm.crm_case_section getCommercialTeam(OpenERP.Clients.clientOpenERP clientOERP)
        {
            return getCommercialTeam(clientOERP, null);
        }
        public crm.crm_case_section getCommercialTeam(OpenERP.Clients.clientOpenERP clientOERP, List<string> fieldsList)
        {
            if (_f_section_id.id > 0)
            {
                return (crm.crm_case_section)clientOERP.read(new IMDEV.OpenERP.models.query.aQuery(_f_section_id.id), typeof(crm.crm_case_section), fieldsList)[0];
            }
            return null;
        }

        public List<quality.quality_cdc> allCDCQuality(Clients.clientOpenERP clientOERP)
        {
            List<object> result;
            List<quality.quality_cdc> retour;

            result = clientOERP.search(new IMDEV.OpenERP.models.query.aQuery("partner_id", id), typeof(quality.quality_cdc), true);
            if (result != null)
            {
                retour = new List<IMDEV.OpenERP.EG.models.quality.quality_cdc>();
                foreach (quality.quality_cdc obj in result)
                    retour.Add(obj);
                return retour;
            }
            return null;
        }

        public quality.comment_quality_formulator aCommentQualityFormulator(Clients.clientOpenERP clientOERP)
        {
            try
            {
                return (quality.comment_quality_formulator)clientOERP.search(new IMDEV.OpenERP.models.query.aQuery("partner_id", id), typeof(quality.comment_quality_formulator), true)[0];
            }
            catch {}
            return null;
        }

        #endregion
    }
}
