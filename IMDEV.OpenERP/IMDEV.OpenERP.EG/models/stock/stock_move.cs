using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IMDEV.OpenERP.models.@base;
using IMDEV.OpenERP.models.fields.relations;

namespace IMDEV.OpenERP.EG.models.stock
{
    public class stock_move : anOpenERPObject
    {
        public string origin
        {
            get { return (string)listProperties.value("origin", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("origin", value); }
        }

        public double product_uos_qty
        {
            get { return (double)listProperties.value("product_uos_qty", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("product_uos_qty", value); }
        }

        private manyToOne _f_address_id = new manyToOne(); //res.partner.address
        public manyToOne address_id
        {
            get { return _f_address_id; }
        }

        public System.DateTime? create_date
        {
            get { return (System.DateTime?)listProperties.value("create_date", aField.FIELD_TYPE.DATETIME); }
        }

        public double weight
        {
            get { return (double)listProperties.value("weight", aField.FIELD_TYPE.FLOAT); }
        }

        public double packaging_size
        {
            get { return (double)listProperties.value("packaging_size", aField.FIELD_TYPE.FLOAT); }
        }

        public double price_unit
        {
            get { return (double)listProperties.value("price_unit", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("price_unit", value); }
        }

        public bool warning_on_reception
        {
            get { return (bool)listProperties.value("warning_on_reception", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("warning_on_reception", value); }
        }

        public int rang
        {
            get { return (int)listProperties.value("rang", aField.FIELD_TYPE.INTEGER); }
            set { listProperties.setValue("rang", value); }
        }

        private manyToOne _f_ul_id = new manyToOne(); //product.ul
        public manyToOne ul_id
        {
            get { return _f_ul_id; }
        }

        private oneToMany _f_procurements = new oneToMany(); //procurement.order
        public oneToMany procurements
        {
            get { return _f_procurements; }
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

        private manyToOne _f_partner_id = new manyToOne(); //res.partner
        public manyToOne partner_id
        {
            get { return _f_partner_id; }
        }

        public enum ENUM_PRIORITY
        {
            NULL
            ,
            @_0
                , @_1
        }
        private string[] _frv_priority = new string[] { "NULL", "0", "1" };
        private string[] _fl_priority = new string[] { "NULL", "Not urgent", "Urgent" };
        private ENUM_PRIORITY _fv_priority;
        public ENUM_PRIORITY priority
        {
            get { return _fv_priority; }
            set { _fv_priority = value; }
        }
        public string LIBELLE_priority
        {
            get { return _fl_priority[(int)_fv_priority]; }
        }

        private manyToOne _f_product_uom = new manyToOne(); //product.uom
        public manyToOne product_uom
        {
            get { return _f_product_uom; }
        }

        private manyToOne _f_sale_line_id = new manyToOne(); //sale.order.line
        public manyToOne sale_line_id
        {
            get { return _f_sale_line_id; }
        }

        public bool auto_validate
        {
            get { return (bool)listProperties.value("auto_validate", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("auto_validate", value); }
        }

        private manyToOne _f_price_currency_id = new manyToOne(); //res.currency
        public manyToOne price_currency_id
        {
            get { return _f_price_currency_id; }
        }

        private manyToOne _f_location_id = new manyToOne(); //stock.location
        public manyToOne location_id
        {
            get { return _f_location_id; }
        }

        private manyToOne _f_company_id = new manyToOne(); //res.company
        public manyToOne company_id
        {
            get { return _f_company_id; }
        }

        public string day
        {
            get { return (string)listProperties.value("day", aField.FIELD_TYPE.CHAR); }
        }

        public string note
        {
            get { return (string)listProperties.value("note", aField.FIELD_TYPE.TEXT); }
            set { listProperties.setValue("note", value); }
        }

        public enum ENUM_STATE
        {
            NULL
            ,
            @draft
                ,
            @done
                ,
            @reserved
                ,
            @confirmed
                ,
            @waiting
                ,
            @assigned
                , @cancel
        }
        private string[] _frv_state = new string[] { "NULL", "draft", "done", "reserved", "confirmed", "waiting", "assigned", "cancel" };
        private string[] _fl_state = new string[] { "NULL", "Draft", "Done", "Reserved", "Not Available", "Waiting", "Available", "Cancelled" };
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

        public int batch_id
        {
            get { return (int)listProperties.value("batch_id", aField.FIELD_TYPE.INTEGER); }
            set { listProperties.setValue("batch_id", value); }
        }

        private manyToOne _f_purchase_line_id = new manyToOne(); //purchase.order.line
        public manyToOne purchase_line_id
        {
            get { return _f_purchase_line_id; }
        }

        private manyToMany _f_move_history_ids = new manyToMany(); //stock.move
        public manyToMany move_history_ids
        {
            get { return _f_move_history_ids; }
        }

        public System.DateTime? date_expected
        {
            get { return (System.DateTime?)listProperties.value("date_expected", aField.FIELD_TYPE.DATETIME); }
            set { listProperties.setValue("date_expected", value); }
        }

        public double pending_quantity
        {
            get { return (double)listProperties.value("pending_quantity", aField.FIELD_TYPE.FLOAT); }
        }

        private manyToOne _f_backorder_id = new manyToOne(); //stock.picking
        public manyToOne backorder_id
        {
            get { return _f_backorder_id; }
        }

        public double weight_net
        {
            get { return (double)listProperties.value("weight_net", aField.FIELD_TYPE.FLOAT); }
        }

        public double last_purchase_price
        {
            get { return (double)listProperties.value("last_purchase_price", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("last_purchase_price", value); }
        }

        private manyToMany _f_production_ids = new manyToMany(); //mrp.production
        public manyToMany production_ids
        {
            get { return _f_production_ids; }
        }

        private manyToOne _f_product_packaging = new manyToOne(); //product.packaging
        public manyToOne product_packaging
        {
            get { return _f_product_packaging; }
        }

        private manyToOne _f_prodlot_id = new manyToOne(); //stock.production.lot
        public manyToOne prodlot_id
        {
            get { return _f_prodlot_id; }
        }

        public bool cancel_cascade
        {
            get { return (bool)listProperties.value("cancel_cascade", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("cancel_cascade", value); }
        }

        private manyToOne _f_move_dest_id = new manyToOne(); //stock.move
        public manyToOne move_dest_id
        {
            get { return _f_move_dest_id; }
        }

        public System.DateTime? date
        {
            get { return (System.DateTime?)listProperties.value("date", aField.FIELD_TYPE.DATETIME); }
        }

        public bool scrapped
        {
            get { return (bool)listProperties.value("scrapped", aField.FIELD_TYPE.BOOLEAN); }
        }

        public double product_forecasted_uos_qty
        {
            get { return (double)listProperties.value("product_forecasted_uos_qty", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("product_forecasted_uos_qty", value); }
        }

        private manyToOne _f_product_id = new manyToOne(); //product.product
        public manyToOne product_id
        {
            get { return _f_product_id; }
        }

        private manyToMany _f_move_history_ids2 = new manyToMany(); //stock.move
        public manyToMany move_history_ids2
        {
            get { return _f_move_history_ids2; }
        }

        public string name
        {
            get { return (string)listProperties.value("name", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("name", value); }
        }

        public string label_barcode_text
        {
            get { return (string)listProperties.value("label_barcode_text", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("label_barcode_text", value); }
        }

        public double received_quantity
        {
            get { return (double)listProperties.value("received_quantity", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("received_quantity", value); }
        }

        public double product_forecasted_qty
        {
            get { return (double)listProperties.value("product_forecasted_qty", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("product_forecasted_qty", value); }
        }

        private manyToOne _f_invoice_line_id = new manyToOne(); //account.invoice.line
        public manyToOne invoice_line_id
        {
            get { return _f_invoice_line_id; }
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

        private manyToOne _f_tracking_id = new manyToOne(); //stock.tracking
        public manyToOne tracking_id
        {
            get { return _f_tracking_id; }
        }

        public System.DateTime? use_date
        {
            get { return (System.DateTime?)listProperties.value("use_date", aField.FIELD_TYPE.DATETIME); }
        }

        private manyToOne _f_production_id = new manyToOne(); //mrp.production
        public manyToOne production_id
        {
            get { return _f_production_id; }
        }

        public enum ENUM_DELIVERY_STATE
        {
            NULL
            ,
            @delivered
                ,
            @none
                , @prepared
        }
        private string[] _frv_delivery_state = new string[] { "NULL", "delivered", "none", "prepared" };
        private string[] _fl_delivery_state = new string[] { "NULL", "Delivered", "", "Prepared" };
        private ENUM_DELIVERY_STATE _fv_delivery_state;
        public ENUM_DELIVERY_STATE delivery_state
        {
            get { return _fv_delivery_state; }
            set { _fv_delivery_state = value; }
        }
        public string LIBELLE_delivery_state
        {
            get { return _fl_delivery_state[(int)_fv_delivery_state]; }
        }

        private manyToOne _f_picking_id = new manyToOne(); //stock.picking
        public manyToOne picking_id
        {
            get { return _f_picking_id; }
        }

        public string label_barcode
        {
            get { return (string)listProperties.value("label_barcode", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("label_barcode", value); }
        }

        public int id
        {
            get { return (int)listProperties.value("id", aField.FIELD_TYPE.INTEGER); }
            set { listProperties.setValue("id", value); }
        }
        public override string resource_name()
        {
            return "stock.move";
        }
    }
}
