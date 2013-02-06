using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IMDEV.OpenERP.models.@base;
using IMDEV.OpenERP.models.fields.relations;

namespace IMDEV.OpenERP.EG.models.stock
{
    public class stock_picking : anOpenERPObject
    {
        public string origin
        {
            get { return (string)listProperties.value("origin", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("origin", value); }
        }

        private manyToOne _f_address_id = new manyToOne(); //res.partner.address
        public manyToOne address_id
        {
            get { return _f_address_id; }
        }

        public int number_of_packages
        {
            get { return (int)listProperties.value("number_of_packages", aField.FIELD_TYPE.INTEGER); }
            set { listProperties.setValue("number_of_packages", value); }
        }

        public double weight
        {
            get { return (double)listProperties.value("weight", aField.FIELD_TYPE.FLOAT); }
        }

        public bool transit
        {
            get { return (bool)listProperties.value("transit", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("transit", value); }
        }

        public string carrier_tracking_ref
        {
            get { return (string)listProperties.value("carrier_tracking_ref", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("carrier_tracking_ref", value); }
        }

        private manyToOne _f_carrier_id = new manyToOne(); //delivery.carrier
        public manyToOne carrier_id
        {
            get { return _f_carrier_id; }
        }

        public string intrastat_department
        {
            get { return (string)listProperties.value("intrastat_department", aField.FIELD_TYPE.CHAR); }
        }

        public string container_number
        {
            get { return (string)listProperties.value("container_number", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("container_number", value); }
        }

        public System.DateTime? min_date
        {
            get { return (System.DateTime?)listProperties.value("min_date", aField.FIELD_TYPE.DATETIME); }
            set { listProperties.setValue("min_date", value); }
        }

        private manyToOne _f_partner_id = new manyToOne(); //res.partner
        public manyToOne partner_id
        {
            get { return _f_partner_id; }
        }

        private oneToMany _f_move_lines = new oneToMany(); //stock.move
        public oneToMany move_lines
        {
            get { return _f_move_lines; }
        }

        private manyToOne _f_purchase_id = new manyToOne(); //purchase.order
        public manyToOne purchase_id
        {
            get { return _f_purchase_id; }
        }

        public string security_info_filename
        {
            get { return (string)listProperties.value("security_info_filename", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("security_info_filename", value); }
        }

        private manyToOne _f_user_id = new manyToOne(); //res.users
        public manyToOne user_id
        {
            get { return _f_user_id; }
        }

        public System.DateTime? date_done
        {
            get { return (System.DateTime?)listProperties.value("date_done", aField.FIELD_TYPE.DATETIME); }
            set { listProperties.setValue("date_done", value); }
        }

        public enum ENUM_INTRASTAT_TRANSPORT
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
        private string[] _frv_intrastat_transport = new string[] { "NULL", "9", "8", "7", "5", "4", "3", "2", "1" };
        private string[] _fl_intrastat_transport = new string[] { "NULL", "Propulsion propre", "Transport par navigation intérieure", "Installations de transport fixes", "Envois postaux", "Transport par air", "Transport par route", "Transport par chemin de fer", "Transport maritime" };
        private ENUM_INTRASTAT_TRANSPORT _fv_intrastat_transport;
        public ENUM_INTRASTAT_TRANSPORT intrastat_transport
        {
            get { return _fv_intrastat_transport; }
            set { _fv_intrastat_transport = value; }
        }
        public string LIBELLE_intrastat_transport
        {
            get { return _fl_intrastat_transport[(int)_fv_intrastat_transport]; }
        }

        public bool auto_picking
        {
            get { return (bool)listProperties.value("auto_picking", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("auto_picking", value); }
        }

        private manyToOne _f_location_id = new manyToOne(); //stock.location
        public manyToOne location_id
        {
            get { return _f_location_id; }
        }

        public enum ENUM_MOVE_TYPE
        {
            NULL
            ,
            @one
                , @direct
        }
        private string[] _frv_move_type = new string[] { "NULL", "one", "direct" };
        private string[] _fl_move_type = new string[] { "NULL", "All at once", "Partial Delivery" };
        private ENUM_MOVE_TYPE _fv_move_type;
        public ENUM_MOVE_TYPE move_type
        {
            get { return _fv_move_type; }
            set { _fv_move_type = value; }
        }
        public string LIBELLE_move_type
        {
            get { return _fl_move_type[(int)_fv_move_type]; }
        }

        private manyToOne _f_sale_id = new manyToOne(); //sale.order
        public manyToOne sale_id
        {
            get { return _f_sale_id; }
        }

        private manyToOne _f_company_id = new manyToOne(); //res.company
        public manyToOne company_id
        {
            get { return _f_company_id; }
        }

        public string note
        {
            get { return (string)listProperties.value("note", aField.FIELD_TYPE.TEXT); }
            set { listProperties.setValue("note", value); }
        }

        private oneToMany _f_picking_internal_line_ids = new oneToMany(); //stock.picking.internal.line
        public oneToMany picking_internal_line_ids
        {
            get { return _f_picking_internal_line_ids; }
        }

        private oneToMany _f_history_ids = new oneToMany(); //stock.picking.history
        public oneToMany history_ids
        {
            get { return _f_history_ids; }
        }

        public byte[] security_info_icon
        {
            get { return (byte[])listProperties.value("security_info_icon", aField.FIELD_TYPE.BINARY); }
        }

        public enum ENUM_TYPE
        {
            NULL
            ,
            @out
                ,
            @internal
                , @in
        }
        private string[] _frv_type = new string[] { "NULL", "out", "internal", "in" };
        private string[] _fl_type = new string[] { "NULL", "Sending Goods", "Internal", "Getting Goods" };
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

        public byte[] security_picto_8
        {
            get { return (byte[])listProperties.value("security_picto_8", aField.FIELD_TYPE.BINARY); }
        }

        private manyToOne _f_backorder_id = new manyToOne(); //stock.picking
        public manyToOne backorder_id
        {
            get { return _f_backorder_id; }
        }

        private manyToOne _f_intrastat_type_id = new manyToOne(); //report.intrastat.type
        public manyToOne intrastat_type_id
        {
            get { return _f_intrastat_type_id; }
        }

        public enum ENUM_STATE
        {
            NULL
            ,
            @draft
                ,
            @done
                ,
            @confirmed
                ,
            @assigned
                ,
            @auto
                , @cancel
        }
        private string[] _frv_state = new string[] { "NULL", "draft", "done", "confirmed", "assigned", "auto", "cancel" };
        private string[] _fl_state = new string[] { "NULL", "Draft", "Done", "Confirmed", "Available", "Waiting", "Cancelled" };
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

        public double weight_net
        {
            get { return (double)listProperties.value("weight_net", aField.FIELD_TYPE.FLOAT); }
        }

        public string seal_number
        {
            get { return (string)listProperties.value("seal_number", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("seal_number", value); }
        }

        private manyToOne _f_warehouse_id = new manyToOne(); //stock.warehouse
        public manyToOne warehouse_id
        {
            get { return _f_warehouse_id; }
        }

        public double volume
        {
            get { return (double)listProperties.value("volume", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("volume", value); }
        }

        public bool pallet_declared
        {
            get { return (bool)listProperties.value("pallet_declared", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("pallet_declared", value); }
        }

        public bool eg_waiting_delivery
        {
            get { return (bool)listProperties.value("eg_waiting_delivery", aField.FIELD_TYPE.BOOLEAN); }
        }

        public System.DateTime? date
        {
            get { return (System.DateTime?)listProperties.value("date", aField.FIELD_TYPE.DATETIME); }
            set { listProperties.setValue("date", value); }
        }

        private oneToMany _f_burst_ids = new oneToMany(); //stock.picking.burst
        public oneToMany burst_ids
        {
            get { return _f_burst_ids; }
        }

        private manyToOne _f_invoice_type_id = new manyToOne(); //sale_journal.invoice.type
        public manyToOne invoice_type_id
        {
            get { return _f_invoice_type_id; }
        }

        public bool flg_info_security
        {
            get { return (bool)listProperties.value("flg_info_security", aField.FIELD_TYPE.BOOLEAN); }
        }

        private manyToOne _f_stock_journal_id = new manyToOne(); //stock.journal
        public manyToOne stock_journal_id
        {
            get { return _f_stock_journal_id; }
        }

        public string name
        {
            get { return (string)listProperties.value("name", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("name", value); }
        }

        public string delivery_comments
        {
            get { return (string)listProperties.value("delivery_comments", aField.FIELD_TYPE.TEXT); }
        }

        public enum ENUM_INVOICE_STATE
        {
            NULL
            ,
            @invoiced
                ,
            @_2binvoiced
                , @none
        }
        private string[] _frv_invoice_state = new string[] { "NULL", "invoiced", "2binvoiced", "none" };
        private string[] _fl_invoice_state = new string[] { "NULL", "Invoiced", "To Be Invoiced", "Not Applicable" };
        private ENUM_INVOICE_STATE _fv_invoice_state;
        public ENUM_INVOICE_STATE invoice_state
        {
            get { return _fv_invoice_state; }
            set { _fv_invoice_state = value; }
        }
        public string LIBELLE_invoice_state
        {
            get { return _fl_invoice_state[(int)_fv_invoice_state]; }
        }

        private manyToOne _f_contract_line_id = new manyToOne(); //product.supplierinfo.contract.line
        public manyToOne contract_line_id
        {
            get { return _f_contract_line_id; }
        }

        private manyToOne _f_location_dest_id = new manyToOne(); //stock.location
        public manyToOne location_dest_id
        {
            get { return _f_location_dest_id; }
        }

        public System.DateTime? max_date
        {
            get { return (System.DateTime?)listProperties.value("max_date", aField.FIELD_TYPE.DATETIME); }
            set { listProperties.setValue("max_date", value); }
        }

        private oneToMany _f_delivery_line_ids = new oneToMany(); //stock.delivery.line
        public oneToMany delivery_line_ids
        {
            get { return _f_delivery_line_ids; }
        }

        public byte[] security_picto_5
        {
            get { return (byte[])listProperties.value("security_picto_5", aField.FIELD_TYPE.BINARY); }
        }

        public byte[] security_picto_4
        {
            get { return (byte[])listProperties.value("security_picto_4", aField.FIELD_TYPE.BINARY); }
        }

        public byte[] security_picto_7
        {
            get { return (byte[])listProperties.value("security_picto_7", aField.FIELD_TYPE.BINARY); }
        }

        public byte[] security_picto_6
        {
            get { return (byte[])listProperties.value("security_picto_6", aField.FIELD_TYPE.BINARY); }
        }

        public byte[] security_picto_1
        {
            get { return (byte[])listProperties.value("security_picto_1", aField.FIELD_TYPE.BINARY); }
        }

        public byte[] security_picto_3
        {
            get { return (byte[])listProperties.value("security_picto_3", aField.FIELD_TYPE.BINARY); }
        }

        public byte[] security_picto_2
        {
            get { return (byte[])listProperties.value("security_picto_2", aField.FIELD_TYPE.BINARY); }
        }

        public int id
        {
            get { return (int)listProperties.value("id", aField.FIELD_TYPE.INTEGER); }
            set { listProperties.setValue("id", value); }
        }

        public bool sent_to_quadra
        {
            get { return (bool)listProperties.value("sent_to_quadra", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("sent_to_quadra", value); }
        }
        
        public override string resource_name()
        {
            return "stock.picking";
        }
    }
}
