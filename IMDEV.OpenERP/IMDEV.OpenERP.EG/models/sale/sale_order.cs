using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IMDEV.OpenERP.models.@base;
using IMDEV.OpenERP.models.fields.relations;

namespace IMDEV.OpenERP.EG.models.sale
{
    public class sale_order : anOpenERPObject
    {
        public string origin
        {
            get { return (string)listProperties.value("origin", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("origin", value); }
        }

        private manyToOne _f_delivery_purchase_id = new manyToOne(); //purchase.order
        public manyToOne delivery_purchase_id
        {
            get { return _f_delivery_purchase_id; }
        }

        public System.DateTime? create_date
        {
            get { return (System.DateTime?)listProperties.value("create_date", aField.FIELD_TYPE.DATETIME); }
        }

        private manyToOne _f_currency_used_id = new manyToOne(); //res.currency
        public manyToOne currency_used_id
        {
            get { return _f_currency_used_id; }
        }

        public System.DateTime? date_depart
        {
            get { return (System.DateTime?)listProperties.value("date_depart", aField.FIELD_TYPE.DATE); }
        }

        private manyToOne _f_payment_term = new manyToOne(); //account.payment.term
        public manyToOne payment_term
        {
            get { return _f_payment_term; }
        }

        public enum ENUM_PICKING_POLICY
        {
            NULL
            ,
            @one
                , @direct
        }
        private string[] _frv_picking_policy = new string[] { "NULL", "one", "direct" };
        private string[] _fl_picking_policy = new string[] { "NULL", "Complete Delivery", "Partial Delivery" };
        private ENUM_PICKING_POLICY _fv_picking_policy;
        public ENUM_PICKING_POLICY picking_policy
        {
            get { return _fv_picking_policy; }
            set { _fv_picking_policy = value; }
        }
        public string LIBELLE_picking_policy
        {
            get { return _fl_picking_policy[(int)_fv_picking_policy]; }
        }
        public string CODE_picking_policy
        {
            get { return _frv_picking_policy[(int)_fv_picking_policy]; }
        }

        public bool direct_delivery
        {
            get { return (bool)listProperties.value("direct_delivery", aField.FIELD_TYPE.BOOLEAN); }
        }

        public double tp_real_price_kg
        {
            get { return (double)listProperties.value("tp_real_price_kg", aField.FIELD_TYPE.FLOAT); }
        }

        public double currency_rate
        {
            get { return (double)listProperties.value("currency_rate", aField.FIELD_TYPE.FLOAT); }
        }

        public double tp_price_kg_marge
        {
            get { return (double)listProperties.value("tp_price_kg_marge", aField.FIELD_TYPE.FLOAT); }
        }

        private manyToOne _f_carrier_id = new manyToOne(); //delivery.carrier
        public manyToOne carrier_id
        {
            get { return _f_carrier_id; }
        }

        private manyToMany _f_invoice_ids = new manyToMany(); //account.invoice
        public manyToMany invoice_ids
        {
            get { return _f_invoice_ids; }
        }

        private manyToOne _f_shop_id = new manyToOne(); //sale.shop
        public manyToOne shop_id
        {
            get { return _f_shop_id; }
        }

        public bool waiting_quality
        {
            get { return (bool)listProperties.value("waiting_quality", aField.FIELD_TYPE.BOOLEAN); }
        }

        public double declared_value
        {
            get { return (double)listProperties.value("declared_value", aField.FIELD_TYPE.FLOAT); }
        }

        public System.DateTime? date_order
        {
            get { return (System.DateTime?)listProperties.value("date_order", aField.FIELD_TYPE.DATE); }
        }

        public double pallet_weight
        {
            get { return (double)listProperties.value("pallet_weight", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("pallet_weight", value); }
        }

        public int id
        {
            get { return (int)listProperties.value("id", aField.FIELD_TYPE.INTEGER); }
        }

        public bool invoiced
        {
            get { return (bool)listProperties.value("invoiced", aField.FIELD_TYPE.BOOLEAN); }
        }

        public string note
        {
            get { return (string)listProperties.value("note", aField.FIELD_TYPE.TEXT); }
            set { listProperties.setValue("note", value); }
        }

        private oneToMany _f_order_line = new oneToMany(); //sale.order.line
        public oneToMany order_line
        {
            get { return _f_order_line; }
        }

        private manyToOne _f_user_id = new manyToOne(); //res.users
        public manyToOne user_id
        {
            get { return _f_user_id; }
        }

        public int delivery_delay
        {
            get { return (int)listProperties.value("delivery_delay", aField.FIELD_TYPE.INTEGER); }
        }

        public bool delivery_with_tailgate
        {
            get { return (bool)listProperties.value("delivery_with_tailgate", aField.FIELD_TYPE.BOOLEAN); }
        }

        private manyToOne _f_partner_id = new manyToOne(); //res.partner
        public manyToOne partner_id
        {
            get { return _f_partner_id; }
        }

        public string after_payment_note
        {
            get { return (string)listProperties.value("after_payment_note", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("after_payment_note", value); }
        }

        public string carrier_note
        {
            get { return (string)listProperties.value("carrier_note", aField.FIELD_TYPE.TEXT); }
            set { listProperties.setValue("carrier_note", value); }
        }

        public enum ENUM_SALE_ORDER_TYPE
        {
            NULL
            ,
            @normal
                , @sample
        }
        private string[] _frv_sale_order_type = new string[] { "NULL", "normal", "sample" };
        private string[] _fl_sale_order_type = new string[] { "NULL", "Normal", "Sample" };
        private ENUM_SALE_ORDER_TYPE _fv_sale_order_type;
        public ENUM_SALE_ORDER_TYPE sale_order_type
        {
            get { return _fv_sale_order_type; }
            set { _fv_sale_order_type = value; }
        }
        public string LIBELLE_sale_order_type
        {
            get { return _fl_sale_order_type[(int)_fv_sale_order_type]; }
        }
        public string CODE_sale_order_type
        {
            get { return _frv_sale_order_type[(int)_fv_sale_order_type]; }
        }

        private manyToOne _f_company_id = new manyToOne(); //res.company
        public manyToOne company_id
        {
            get { return _f_company_id; }
        }

        private oneToMany _f_picking_ids = new oneToMany(); //stock.picking
        public oneToMany picking_ids
        {
            get { return _f_picking_ids; }
        }

        public double amount_tax
        {
            get { return (double)listProperties.value("amount_tax", aField.FIELD_TYPE.FLOAT); }
        }

        private oneToMany _f_pallet_type_ids = new oneToMany(); //sale.product.pallet
        public oneToMany pallet_type_ids
        {
            get { return _f_pallet_type_ids; }
        }

        public enum ENUM_STATE
        {
            NULL
            ,
            @progress
                ,
            @shipping_except
                ,
            @waiting_date
                ,
            @draft
                ,
            @done
                ,
            @invoice_except
                ,
            @cancel
                , @manual
        }
        private string[] _frv_state = new string[] { "NULL", "progress", "shipping_except", "waiting_date", "draft", "done", "invoice_except", "cancel", "manual" };
        private string[] _fl_state = new string[] { "NULL", "In Progress", "Shipping Exception", "Waiting Schedule", "Quotation", "Done", "Invoice Exception", "Cancelled", "Manual In Progress" };
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
        public string CODE_state
        {
            get { return _frv_state[(int)_fv_state]; }
        }

        public bool points_counted
        {
            get { return (bool)listProperties.value("points_counted", aField.FIELD_TYPE.BOOLEAN); }
        }

        public enum ENUM_DEPARTURE_TIME
        {
            NULL
            ,
            @n
                ,
            @_13
                ,
            @_17
                , @_8
        }
        private string[] _frv_departure_time = new string[] { "NULL", "n", "13", "17", "8" };
        private string[] _fl_departure_time = new string[] { "NULL", " ", "13h", "17h", "8h" };
        private ENUM_DEPARTURE_TIME _fv_departure_time;
        public ENUM_DEPARTURE_TIME departure_time
        {
            get { return _fv_departure_time; }
            set { _fv_departure_time = value; }
        }
        public string LIBELLE_departure_time
        {
            get { return _fl_departure_time[(int)_fv_departure_time]; }
        }
        public string CODE_departure_time
        {
            get { return _frv_departure_time[(int)_fv_departure_time]; }
        }

        public int number_of_print
        {
            get { return (int)listProperties.value("number_of_print", aField.FIELD_TYPE.INTEGER); }
            set { listProperties.setValue("number_of_print", value); }
        }

        public enum ENUM_ORDER_POLICY
        {
            NULL
            ,
            @prepaid
                ,
            @postpaid
                ,
            @picking
                , @manual
        }
        private string[] _frv_order_policy = new string[] { "NULL", "prepaid", "postpaid", "picking", "manual" };
        private string[] _fl_order_policy = new string[] { "NULL", "Payment Before Delivery", "Invoice On Order After Delivery", "Invoice From The Picking", "Shipping & Manual Invoice" };
        private ENUM_ORDER_POLICY _fv_order_policy;
        public ENUM_ORDER_POLICY order_policy
        {
            get { return _fv_order_policy; }
            set { _fv_order_policy = value; }
        }
        public string LIBELLE_order_policy
        {
            get { return _fl_order_policy[(int)_fv_order_policy]; }
        }
        public string CODE_order_policy
        {
            get { return _frv_order_policy[(int)_fv_order_policy]; }
        }

        public System.DateTime? validity_proforma
        {
            get { return (System.DateTime?)listProperties.value("validity_proforma", aField.FIELD_TYPE.DATE); }
        }

        private manyToOne _f_pricelist_id = new manyToOne(); //product.pricelist
        public manyToOne pricelist_id
        {
            get { return _f_pricelist_id; }
        }

        private manyToOne _f_project_id = new manyToOne(); //account.analytic.account
        public manyToOne project_id
        {
            get { return _f_project_id; }
        }

        public string contact_phone
        {
            get { return (string)listProperties.value("contact_phone", aField.FIELD_TYPE.CHAR); }
        }

        public bool is_linked
        {
            get { return (bool)listProperties.value("is_linked", aField.FIELD_TYPE.BOOLEAN); }
        }

        public string internal_note
        {
            get { return (string)listProperties.value("internal_note", aField.FIELD_TYPE.TEXT); }
            set { listProperties.setValue("internal_note", value); }
        }

        private manyToOne _f_incoterm = new manyToOne(); //stock.incoterms
        public manyToOne incoterm
        {
            get { return _f_incoterm; }
        }

        public int pallet_nbr
        {
            get { return (int)listProperties.value("pallet_nbr", aField.FIELD_TYPE.INTEGER); }
        }

        public enum ENUM_INVOICE_QUANTITY
        {
            NULL
            ,
            @order
                , @procurement
        }
        private string[] _frv_invoice_quantity = new string[] { "NULL", "order", "procurement" };
        private string[] _fl_invoice_quantity = new string[] { "NULL", "Ordered Quantities", "Shipped Quantities" };
        private ENUM_INVOICE_QUANTITY _fv_invoice_quantity;
        public ENUM_INVOICE_QUANTITY invoice_quantity
        {
            get { return _fv_invoice_quantity; }
            set { _fv_invoice_quantity = value; }
        }
        public string LIBELLE_invoice_quantity
        {
            get { return _fl_invoice_quantity[(int)_fv_invoice_quantity]; }
        }
        public string CODE_invoice_quantity
        {
            get { return _frv_invoice_quantity[(int)_fv_invoice_quantity]; }
        }

        public string departure_place
        {
            get { return (string)listProperties.value("departure_place", aField.FIELD_TYPE.CHAR); }
        }

        public System.DateTime? date_delivering
        {
            get { return (System.DateTime?)listProperties.value("date_delivering", aField.FIELD_TYPE.DATE); }
        }

        public string delivery_place
        {
            get { return (string)listProperties.value("delivery_place", aField.FIELD_TYPE.CHAR); }
        }

        private manyToOne _f_direct_delivery_purchase_id = new manyToOne(); //purchase.order
        public manyToOne direct_delivery_purchase_id
        {
            get { return _f_direct_delivery_purchase_id; }
        }

        private manyToOne _f_partner_order_id = new manyToOne(); //res.partner.address
        public manyToOne partner_order_id
        {
            get { return _f_partner_order_id; }
        }

        public double picked_rate
        {
            get { return (double)listProperties.value("picked_rate", aField.FIELD_TYPE.FLOAT); }
        }

        private manyToOne _f_section_id = new manyToOne(); //crm.case.section
        public manyToOne section_id
        {
            get { return _f_section_id; }
        }

        private manyToOne _f_fiscal_position = new manyToOne(); //account.fiscal.position
        public manyToOne fiscal_position
        {
            get { return _f_fiscal_position; }
        }

        public enum ENUM_TP_TYPE
        {
            NULL
            ,
            @global
                ,
            @line
                ,
            @included_tp
                ,
            @customer
                , @included
        }
        private string[] _frv_tp_type = new string[] { "NULL", "global", "line", "included_tp", "customer", "included" };
        private string[] _fl_tp_type = new string[] { "NULL", "a part", "per line", "included + TP", "Customer", "included" };
        private ENUM_TP_TYPE _fv_tp_type;
        public ENUM_TP_TYPE tp_type
        {
            get { return _fv_tp_type; }
            set { _fv_tp_type = value; }
        }
        public string LIBELLE_tp_type
        {
            get { return _fl_tp_type[(int)_fv_tp_type]; }
        }
        public string CODE_tp_type
        {
            get { return _frv_tp_type[(int)_fv_tp_type]; }
        }

        public string contact_id
        {
            get { return (string)listProperties.value("contact_id", aField.FIELD_TYPE.CHAR); }
        }

        public int container_nbr
        {
            get { return (int)listProperties.value("container_nbr", aField.FIELD_TYPE.INTEGER); }
        }

        public double tp_price_kg
        {
            get { return (double)listProperties.value("tp_price_kg", aField.FIELD_TYPE.FLOAT); }
        }

        private manyToOne _f_partner_invoice_id = new manyToOne(); //res.partner.address
        public manyToOne partner_invoice_id
        {
            get { return _f_partner_invoice_id; }
        }

        public double amount_untaxed
        {
            get { return (double)listProperties.value("amount_untaxed", aField.FIELD_TYPE.FLOAT); }
        }

        public bool eg_waiting_delivery
        {
            get { return (bool)listProperties.value("eg_waiting_delivery", aField.FIELD_TYPE.BOOLEAN); }
        }

        private manyToOne _f_invoice_type_id = new manyToOne(); //sale_journal.invoice.type
        public manyToOne invoice_type_id
        {
            get { return _f_invoice_type_id; }
        }

        public System.DateTime? date_confirm
        {
            get { return (System.DateTime?)listProperties.value("date_confirm", aField.FIELD_TYPE.DATE); }
        }

        public double weight_with_pallet
        {
            get { return (double)listProperties.value("weight_with_pallet", aField.FIELD_TYPE.FLOAT); }
        }

        public double amount_total
        {
            get { return (double)listProperties.value("amount_total", aField.FIELD_TYPE.FLOAT); }
        }

        public double kg_qty_total
        {
            get { return (double)listProperties.value("kg_qty_total", aField.FIELD_TYPE.FLOAT); }
        }

        public bool is_proforma
        {
            get { return (bool)listProperties.value("is_proforma", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("is_proforma", value); }
        }

        public string name
        {
            get { return (string)listProperties.value("name", aField.FIELD_TYPE.CHAR); }
        }

        private manyToOne _f_partner_shipping_id = new manyToOne(); //res.partner.address
        public manyToOne partner_shipping_id
        {
            get { return _f_partner_shipping_id; }
        }

        public int total_points_nbr
        {
            get { return (int)listProperties.value("total_points_nbr", aField.FIELD_TYPE.INTEGER); }
        }

        public bool waiting_panif
        {
            get { return (bool)listProperties.value("waiting_panif", aField.FIELD_TYPE.BOOLEAN); }
        }

        private oneToMany _f_container_ids = new oneToMany(); //sale.product.container
        public oneToMany container_ids
        {
            get { return _f_container_ids; }
        }

        public bool email_sent
        {
            get { return (bool)listProperties.value("email_sent", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("email_sent", value); }
        }

        public bool shipped
        {
            get { return (bool)listProperties.value("shipped", aField.FIELD_TYPE.BOOLEAN); }
        }

        public string after_origin_note
        {
            get { return (string)listProperties.value("after_origin_note", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("after_origin_note", value); }
        }

        public double tp_real_price_total
        {
            get { return (double)listProperties.value("tp_real_price_total", aField.FIELD_TYPE.FLOAT); }
        }

        public string client_order_ref
        {
            get { return (string)listProperties.value("client_order_ref", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("client_order_ref", value); }
        }

        public double tp_price_total
        {
            get { return (double)listProperties.value("tp_price_total", aField.FIELD_TYPE.FLOAT); }
        }

        public double invoiced_rate
        {
            get { return (double)listProperties.value("invoiced_rate", aField.FIELD_TYPE.FLOAT); }
        }

        public bool pallet_weight_used
        {
            get { return (bool)listProperties.value("pallet_weight_used", aField.FIELD_TYPE.BOOLEAN); }
        }

        public string after_sum_note
        {
            get { return (string)listProperties.value("after_sum_note", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("after_sum_note", value); }
        }

        public bool production_freeze
        {
            get { return (bool)listProperties.value("production_freeze", aField.FIELD_TYPE.BOOLEAN); }
        }

        private manyToOne _f_linked_order = new manyToOne(); //sale.order
        public manyToOne linked_order
        {
            get { return _f_linked_order; }
        }

        public bool waiting_payment
        {
            get { return (bool)listProperties.value("waiting_payment", aField.FIELD_TYPE.BOOLEAN); }
        }

        public override string resource_name()
        {
            return "sale.order";
        }
    }
}
