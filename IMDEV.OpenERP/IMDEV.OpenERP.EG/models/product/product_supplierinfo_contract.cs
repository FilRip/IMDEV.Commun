using IMDEV.OpenERP.models.@base;
using IMDEV.OpenERP.models.fields.relations;

namespace IMDEV.OpenERP.EG.models.product
{
    public class product_supplierinfo_contract : anOpenERPObject
    {
        public int pallet_qty
        {
            get { return (int)listProperties.value("pallet_qty", aField.FIELD_TYPE.INTEGER); }
            set { listProperties.setValue("pallet_qty", value); }
        }

        private manyToOne _f_product_uom = new manyToOne(); //product.uom
        public manyToOne product_uom
        {
            get { return _f_product_uom; }
        }

        public double cost_delivery
        {
            get { return (double)listProperties.value("cost_delivery", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("cost_delivery", value); }
        }

        private oneToMany _f_contract_lines = new oneToMany(); //product.supplierinfo.contract.line
        public oneToMany contract_lines
        {
            get { return _f_contract_lines; }
        }

        public double price_unit
        {
            get { return (double)listProperties.value("price_unit", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("price_unit", value); }
        }

        public double product_uom_qty
        {
            get { return (double)listProperties.value("product_uom_qty", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("product_uom_qty", value); }
        }

        private manyToOne _f_partner_id = new manyToOne(); //res.partner
        public manyToOne partner_id
        {
            get { return _f_partner_id; }
        }

        private manyToOne _f_product_tmpl_id = new manyToOne(); //product.template
        public manyToOne product_tmpl_id
        {
            get { return _f_product_tmpl_id; }
        }

        public int qty_multiple
        {
            get { return (int)listProperties.value("qty_multiple", aField.FIELD_TYPE.INTEGER); }
            set { listProperties.setValue("qty_multiple", value); }
        }

        private manyToOne _f_user_id = new manyToOne(); //res.users
        public manyToOne user_id
        {
            get { return _f_user_id; }
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

        public string note
        {
            get { return (string)listProperties.value("note", aField.FIELD_TYPE.TEXT); }
            set { listProperties.setValue("note", value); }
        }

        public double total_waiting_qty
        {
            get { return (double)listProperties.value("total_waiting_qty", aField.FIELD_TYPE.FLOAT); }
        }

        public double cost_taxes
        {
            get { return (double)listProperties.value("cost_taxes", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("cost_taxes", value); }
        }

        public double total_received_qty
        {
            get { return (double)listProperties.value("total_received_qty", aField.FIELD_TYPE.FLOAT); }
        }

        public bool is_franco
        {
            get { return (bool)listProperties.value("is_franco", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("is_franco", value); }
        }

        private manyToOne _f_incoterm = new manyToOne(); //stock.incoterms
        public manyToOne incoterm
        {
            get { return _f_incoterm; }
        }

        public double bulking_qty
        {
            get { return (double)listProperties.value("bulking_qty", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("bulking_qty", value); }
        }

        public bool active
        {
            get { return (bool)listProperties.value("active", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("active", value); }
        }

        public double min_qty
        {
            get { return (double)listProperties.value("min_qty", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("min_qty", value); }
        }

        public string partner_ref
        {
            get { return (string)listProperties.value("partner_ref", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("partner_ref", value); }
        }

        public double cost_customs
        {
            get { return (double)listProperties.value("cost_customs", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("cost_customs", value); }
        }

        public string name
        {
            get { return (string)listProperties.value("name", aField.FIELD_TYPE.CHAR); }
        }

        public System.DateTime? date_confirmed
        {
            get { return (System.DateTime?)listProperties.value("date_confirmed", aField.FIELD_TYPE.DATE); }
            set { listProperties.setValue("date_confirmed", value); }
        }

        public double cost_total
        {
            get { return (double)listProperties.value("cost_total", aField.FIELD_TYPE.FLOAT); }
        }

        private manyToOne _f_supplierinfo_id = new manyToOne(); //product.supplierinfo
        public manyToOne supplierinfo_id
        {
            get { return _f_supplierinfo_id; }
        }

        public double total_remaining_qty
        {
            get { return (double)listProperties.value("total_remaining_qty", aField.FIELD_TYPE.FLOAT); }
        }

        private manyToOne _f_partner_customer_id = new manyToOne(); //res.partner
        public manyToOne partner_customer_id
        {
            get { return _f_partner_customer_id; }
        }

        public System.DateTime? date_end
        {
            get { return (System.DateTime?)listProperties.value("date_end", aField.FIELD_TYPE.DATE); }
            set { listProperties.setValue("date_end", value); }
        }

        public int id
        {
            get { return (int)listProperties.value("id", aField.FIELD_TYPE.INTEGER); }
            set { listProperties.setValue("id", value); }
        }
        public override string resource_name()
        {
            return "product.supplierinfo.contract";
        }
    }
}
