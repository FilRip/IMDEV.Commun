using IMDEV.OpenERP.models.@base;
using IMDEV.OpenERP.models.fields.relations;

namespace IMDEV.OpenERP.EG.models.account
{
    public class account_invoice_line : anOpenERPObject
    {
        public string origin
        {
            get { return (string)listProperties.value("origin", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("origin", value); }
        }

        private manyToOne _f_distribution_id = new manyToOne(); //distribution.costs
        public manyToOne distribution_id
        {
            get { return _f_distribution_id; }
        }

        private manyToOne _f_uos_id = new manyToOne(); //product.uom
        public manyToOne uos_id
        {
            get { return _f_uos_id; }
        }

        private manyToOne _f_account_id = new manyToOne(); //account.account
        public manyToOne account_id
        {
            get { return _f_account_id; }
        }

        private manyToOne _f_sale_line_id = new manyToOne(); //sale.order.line
        public manyToOne sale_line_id
        {
            get { return _f_sale_line_id; }
        }

        public int sequence
        {
            get { return (int)listProperties.value("sequence", aField.FIELD_TYPE.INTEGER); }
            set { listProperties.setValue("sequence", value); }
        }

        private manyToOne _f_invoice_id = new manyToOne(); //account.invoice
        public manyToOne invoice_id
        {
            get { return _f_invoice_id; }
        }

        public double price_unit
        {
            get { return (double)listProperties.value("price_unit", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("price_unit", value); }
        }

        public string prodlot_note
        {
            get { return (string)listProperties.value("prodlot_note", aField.FIELD_TYPE.TEXT); }
            set { listProperties.setValue("prodlot_note", value); }
        }

        public double price_subtotal
        {
            get { return (double)listProperties.value("price_subtotal", aField.FIELD_TYPE.FLOAT); }
        }

        private manyToOne _f_company_id = new manyToOne(); //res.company
        public manyToOne company_id
        {
            get { return _f_company_id; }
        }

        private manyToMany _f_invoice_line_tax_id = new manyToMany(); //account.tax
        public manyToMany invoice_line_tax_id
        {
            get { return _f_invoice_line_tax_id; }
        }

        public string note
        {
            get { return (string)listProperties.value("note", aField.FIELD_TYPE.TEXT); }
            set { listProperties.setValue("note", value); }
        }

        public double discount
        {
            get { return (double)listProperties.value("discount", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("discount", value); }
        }

        private manyToOne _f_product_id = new manyToOne(); //product.product
        public manyToOne product_id
        {
            get { return _f_product_id; }
        }

        public string bottom_note
        {
            get { return (string)listProperties.value("bottom_note", aField.FIELD_TYPE.TEXT); }
            set { listProperties.setValue("bottom_note", value); }
        }

        private manyToOne _f_account_analytic_id = new manyToOne(); //account.analytic.account
        public manyToOne account_analytic_id
        {
            get { return _f_account_analytic_id; }
        }

        public double quantity
        {
            get { return (double)listProperties.value("quantity", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("quantity", value); }
        }

        private manyToOne _f_partner_id = new manyToOne(); //res.partner
        public manyToOne partner_id
        {
            get { return _f_partner_id; }
        }

        private manyToOne _f_picking_id = new manyToOne(); //stock.picking
        public manyToOne picking_id
        {
            get { return _f_picking_id; }
        }

        public string name
        {
            get { return (string)listProperties.value("name", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("name", value); }
        }

        public int id
        {
            get { return (int)listProperties.value("id", aField.FIELD_TYPE.INTEGER); }
            set { listProperties.setValue("id", value); }
        }
        public override string resource_name()
        {
            return "account.invoice.line";
        }
    }
}
