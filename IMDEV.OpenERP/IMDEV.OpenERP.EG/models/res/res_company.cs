using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IMDEV.OpenERP.models.@base;
using IMDEV.OpenERP.models.fields.relations;

namespace IMDEV.OpenERP.EG.models.res
{
    public class res_company : anOpenERPObject
    {
        private manyToOne _f_default_intrastat_type_out_invoice = new manyToOne(); //report.intrastat.type
        public manyToOne default_intrastat_type_out_invoice
        {
            get { return _f_default_intrastat_type_out_invoice; }
        }

        private oneToMany _f_addresses = new oneToMany(); //res.company.address
        public oneToMany addresses
        {
            get { return _f_addresses; }
        }

        public string siret_complement
        {
            get { return (string)listProperties.value("siret_complement", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("siret_complement", value); }
        }

        private manyToOne _f_property_pricelist_carrier_purchase = new manyToOne(); //product.pricelist
        public manyToOne property_pricelist_carrier_purchase
        {
            get { return _f_property_pricelist_carrier_purchase; }
        }

        public double security_lead
        {
            get { return (double)listProperties.value("security_lead", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("security_lead", value); }
        }

        private manyToOne _f_stylesheet_id = new manyToOne(); //report.stylesheets
        public manyToOne stylesheet_id
        {
            get { return _f_stylesheet_id; }
        }

        private manyToOne _f_default_intrastat_type_out_refund = new manyToOne(); //report.intrastat.type
        public manyToOne default_intrastat_type_out_refund
        {
            get { return _f_default_intrastat_type_out_refund; }
        }

        private manyToOne _f_currency_id = new manyToOne(); //res.currency
        public manyToOne currency_id
        {
            get { return _f_currency_id; }
        }

        public string product_ft_files_server_path
        {
            get { return (string)listProperties.value("product_ft_files_server_path", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("product_ft_files_server_path", value); }
        }

        public double po_lead
        {
            get { return (double)listProperties.value("po_lead", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("po_lead", value); }
        }

        private manyToMany _f_user_ids = new manyToMany(); //res.users
        public manyToMany user_ids
        {
            get { return _f_user_ids; }
        }

        public double com_limit
        {
            get { return (double)listProperties.value("com_limit", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("com_limit", value); }
        }

        private oneToMany _f_tracking_max_quantity_ids = new oneToMany(); //res.company.tracking.max.quantity
        public oneToMany tracking_max_quantity_ids
        {
            get { return _f_tracking_max_quantity_ids; }
        }

        public byte[] logo
        {
            get { return (byte[])listProperties.value("logo", aField.FIELD_TYPE.BINARY); }
            set { listProperties.setValue("logo", value); }
        }

        public string cnuf_number
        {
            get { return (string)listProperties.value("cnuf_number", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("cnuf_number", value); }
        }

        private manyToOne _f_partner_id = new manyToOne(); //res.partner
        public manyToOne partner_id
        {
            get { return _f_partner_id; }
        }

        public string rml_header
        {
            get { return (string)listProperties.value("rml_header", aField.FIELD_TYPE.TEXT); }
            set { listProperties.setValue("rml_header", value); }
        }

        public bool workday_thursday
        {
            get { return (bool)listProperties.value("workday_thursday", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("workday_thursday", value); }
        }

        public double manufacturing_lead
        {
            get { return (double)listProperties.value("manufacturing_lead", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("manufacturing_lead", value); }
        }

        public bool workday_monday
        {
            get { return (bool)listProperties.value("workday_monday", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("workday_monday", value); }
        }

        public string default_intrastat_department
        {
            get { return (string)listProperties.value("default_intrastat_department", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("default_intrastat_department", value); }
        }

        private manyToOne _f_country_id = new manyToOne(); //res.country
        public manyToOne country_id
        {
            get { return _f_country_id; }
        }

        public bool workday_saturday
        {
            get { return (bool)listProperties.value("workday_saturday", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("workday_saturday", value); }
        }

        private manyToOne _f_parent_id = new manyToOne(); //res.company
        public manyToOne parent_id
        {
            get { return _f_parent_id; }
        }

        private manyToOne _f_property_reserve_and_surplus_account = new manyToOne(); //account.account
        public manyToOne property_reserve_and_surplus_account
        {
            get { return _f_property_reserve_and_surplus_account; }
        }

        private manyToOne _f_statistical_pricelist_id = new manyToOne(); //product.pricelist
        public manyToOne statistical_pricelist_id
        {
            get { return _f_statistical_pricelist_id; }
        }

        public bool workday_wednesday
        {
            get { return (bool)listProperties.value("workday_wednesday", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("workday_wednesday", value); }
        }

        public enum ENUM_EXPORT_OBLIGATION_LEVEL
        {
            NULL
            ,
            @simplified
                , @detailed
        }
        private string[] _frv_export_obligation_level = new string[] { "NULL", "simplified", "detailed" };
        private string[] _fl_export_obligation_level = new string[] { "NULL", "Simplified", "Detailed" };
        private ENUM_EXPORT_OBLIGATION_LEVEL _fv_export_obligation_level;
        public ENUM_EXPORT_OBLIGATION_LEVEL export_obligation_level
        {
            get { return _fv_export_obligation_level; }
            set { _fv_export_obligation_level = value; }
        }
        public string LIBELLE_export_obligation_level
        {
            get { return _fl_export_obligation_level[(int)_fv_export_obligation_level]; }
        }

        public int scheduler_security
        {
            get { return (int)listProperties.value("scheduler_security", aField.FIELD_TYPE.INTEGER); }
            set { listProperties.setValue("scheduler_security", value); }
        }

        public string account_no
        {
            get { return (string)listProperties.value("account_no", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("account_no", value); }
        }

        public string supplier_files_server_path
        {
            get { return (string)listProperties.value("supplier_files_server_path", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("supplier_files_server_path", value); }
        }

        private oneToMany _f_child_ids = new oneToMany(); //res.company
        public oneToMany child_ids
        {
            get { return _f_child_ids; }
        }

        private manyToOne _f_default_intrastat_type_in_picking = new manyToOne(); //report.intrastat.type
        public manyToOne default_intrastat_type_in_picking
        {
            get { return _f_default_intrastat_type_in_picking; }
        }

        private manyToOne _f_default_intrastat_type_out_picking = new manyToOne(); //report.intrastat.type
        public manyToOne default_intrastat_type_out_picking
        {
            get { return _f_default_intrastat_type_out_picking; }
        }

        private manyToOne _f_default_intrastat_type_in_invoice = new manyToOne(); //report.intrastat.type
        public manyToOne default_intrastat_type_in_invoice
        {
            get { return _f_default_intrastat_type_in_invoice; }
        }

        public double point_value
        {
            get { return (double)listProperties.value("point_value", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("point_value", value); }
        }

        public string rml_header2
        {
            get { return (string)listProperties.value("rml_header2", aField.FIELD_TYPE.TEXT); }
            set { listProperties.setValue("rml_header2", value); }
        }

        public string rml_header3
        {
            get { return (string)listProperties.value("rml_header3", aField.FIELD_TYPE.TEXT); }
            set { listProperties.setValue("rml_header3", value); }
        }

        public string rml_header1
        {
            get { return (string)listProperties.value("rml_header1", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("rml_header1", value); }
        }

        public bool workday_tuesday
        {
            get { return (bool)listProperties.value("workday_tuesday", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("workday_tuesday", value); }
        }

        public double schedule_range
        {
            get { return (double)listProperties.value("schedule_range", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("schedule_range", value); }
        }

        public string rml_footer1
        {
            get { return (string)listProperties.value("rml_footer1", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("rml_footer1", value); }
        }

        public string rml_footer2
        {
            get { return (string)listProperties.value("rml_footer2", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("rml_footer2", value); }
        }

        public string weight_volume_formula
        {
            get { return (string)listProperties.value("weight_volume_formula", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("weight_volume_formula", value); }
        }

        public string name
        {
            get { return (string)listProperties.value("name", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("name", value); }
        }

        public string customs_accreditation
        {
            get { return (string)listProperties.value("customs_accreditation", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("customs_accreditation", value); }
        }

        public string customer_files_server_path
        {
            get { return (string)listProperties.value("customer_files_server_path", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("customer_files_server_path", value); }
        }

        public string overdue_msg
        {
            get { return (string)listProperties.value("overdue_msg", aField.FIELD_TYPE.TEXT); }
            set { listProperties.setValue("overdue_msg", value); }
        }
        private IMDEV.OpenERP.models.fields.texteMultilangue _overdue_msg_multilangue;
        public IMDEV.OpenERP.models.fields.texteMultilangue overdue_msg_multilangue
        {
            get
            {
                if (_overdue_msg_multilangue == null) _overdue_msg_multilangue = new IMDEV.OpenERP.models.fields.texteMultilangue(this, "overdue_msg");
                return _overdue_msg_multilangue;
            }
        }

        private oneToMany _f_currency_ids = new oneToMany(); //res.currency
        public oneToMany currency_ids
        {
            get { return _f_currency_ids; }
        }

        public string analysis_files_server_path
        {
            get { return (string)listProperties.value("analysis_files_server_path", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("analysis_files_server_path", value); }
        }

        public bool workday_friday
        {
            get { return (bool)listProperties.value("workday_friday", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("workday_friday", value); }
        }

        public enum ENUM_DEFAULT_INTRASTAT_TRANSPORT
        {
            NULL
            ,
            @_9
                ,
            @_8
                ,
            @_7
                ,
            @_5
                ,
            @_4
                ,
            @_3
                ,
            @_2
                , @_1
        }
        private string[] _frv_default_intrastat_transport = new string[] { "NULL", "9", "8", "7", "5", "4", "3", "2", "1" };
        private string[] _fl_default_intrastat_transport = new string[] { "NULL", "Propulsion propre", "Transport par navigation intérieure", "Installations de transport fixes", "Envois postaux", "Transport par air", "Transport par route", "Transport par chemin de fer", "Transport maritime" };
        private ENUM_DEFAULT_INTRASTAT_TRANSPORT _fv_default_intrastat_transport;
        public ENUM_DEFAULT_INTRASTAT_TRANSPORT default_intrastat_transport
        {
            get { return _fv_default_intrastat_transport; }
            set { _fv_default_intrastat_transport = value; }
        }
        public string LIBELLE_default_intrastat_transport
        {
            get { return _fl_default_intrastat_transport[(int)_fv_default_intrastat_transport]; }
        }

        public string oneshot_comment
        {
            get { return (string)listProperties.value("oneshot_comment", aField.FIELD_TYPE.TEXT); }
            set { listProperties.setValue("oneshot_comment", value); }
        }

        public string local_media_repository
        {
            get { return (string)listProperties.value("local_media_repository", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("local_media_repository", value); }
        }

        public int company_nb
        {
            get { return (int)listProperties.value("company_nb", aField.FIELD_TYPE.INTEGER); }
            set { listProperties.setValue("company_nb", value); }
        }

        private oneToMany _f_days_validation_ids = new oneToMany(); //res.company.day.validation
        public oneToMany days_validation_ids
        {
            get { return _f_days_validation_ids; }
        }

        private oneToMany _f_specific_working_date_ids = new oneToMany(); //res.company.workdate
        public oneToMany specific_working_date_ids
        {
            get { return _f_specific_working_date_ids; }
        }

        public int id
        {
            get { return (int)listProperties.value("id", aField.FIELD_TYPE.INTEGER); }
            set { listProperties.setValue("id", value); }
        }
        public override string resource_name()
        {
            return "res.company";
        }
    }
}
