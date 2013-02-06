using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IMDEV.OpenERP.models.@base;
using IMDEV.OpenERP.models.fields.relations;

namespace IMDEV.OpenERP.EG.models.product
{
    public class product_supplierinfo : anOpenERPObject
    {
        private manyToOne _f_product_uom = new manyToOne(); //product.uom
        public manyToOne product_uom
        {
            get { return _f_product_uom; }
        }

        public int sequence
        {
            get { return (int)listProperties.value("sequence", aField.FIELD_TYPE.INTEGER); }
            set { listProperties.setValue("sequence", value); }
        }

        public double pallet_unit
        {
            get { return (double)listProperties.value("pallet_unit", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("pallet_unit", value); }
        }

        private manyToOne _f_company_id = new manyToOne(); //res.company
        public manyToOne company_id
        {
            get { return _f_company_id; }
        }

        public bool delivery_wednesday
        {
            get { return (bool)listProperties.value("delivery_wednesday", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("delivery_wednesday", value); }
        }

        private manyToOne _f_packaging_id = new manyToOne(); //product.packaging
        public manyToOne packaging_id
        {
            get { return _f_packaging_id; }
        }

        public int packing_delay
        {
            get { return (int)listProperties.value("packing_delay", aField.FIELD_TYPE.INTEGER); }
            set { listProperties.setValue("packing_delay", value); }
        }

        public bool is_contract
        {
            get { return (bool)listProperties.value("is_contract", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("is_contract", value); }
        }

        public string product_code
        {
            get { return (string)listProperties.value("product_code", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("product_code", value); }
        }

        public string line_note
        {
            get { return (string)listProperties.value("line_note", aField.FIELD_TYPE.TEXT); }
            set { listProperties.setValue("line_note", value); }
        }

        public double pallet_brut_weight
        {
            get { return (double)listProperties.value("pallet_brut_weight", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("pallet_brut_weight", value); }
        }

        public bool specific_label
        {
            get { return (bool)listProperties.value("specific_label", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("specific_label", value); }
        }

        public int qty_multiple
        {
            get { return (int)listProperties.value("qty_multiple", aField.FIELD_TYPE.INTEGER); }
            set { listProperties.setValue("qty_multiple", value); }
        }

        public int sequence_step
        {
            get { return (int)listProperties.value("sequence_step", aField.FIELD_TYPE.INTEGER); }
            set { listProperties.setValue("sequence_step", value); }
        }

        public int delay
        {
            get { return (int)listProperties.value("delay", aField.FIELD_TYPE.INTEGER); }
            set { listProperties.setValue("delay", value); }
        }

        private manyToOne _f_origin_country_id = new manyToOne(); //res.country
        public manyToOne origin_country_id
        {
            get { return _f_origin_country_id; }
        }

        public bool delivery_friday
        {
            get { return (bool)listProperties.value("delivery_friday", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("delivery_friday", value); }
        }

        public bool delivery_thursday
        {
            get { return (bool)listProperties.value("delivery_thursday", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("delivery_thursday", value); }
        }

        public string product_name
        {
            get { return (string)listProperties.value("product_name", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("product_name", value); }
        }
        private IMDEV.OpenERP.models.fields.texteMultilangue _product_name_multilangue;
        public IMDEV.OpenERP.models.fields.texteMultilangue product_name_multilangue
        {
            get
            {
                if (_product_name_multilangue == null) _product_name_multilangue = new IMDEV.OpenERP.models.fields.texteMultilangue(this, "product_name");
                return _product_name_multilangue;
            }
        }

        private oneToMany _f_pricelist_ids = new oneToMany(); //pricelist.partnerinfo
        public oneToMany pricelist_ids
        {
            get { return _f_pricelist_ids; }
        }

        private oneToMany _f_contracts = new oneToMany(); //product.supplierinfo.contract
        public oneToMany contracts
        {
            get { return _f_contracts; }
        }

        public bool neutral_package
        {
            get { return (bool)listProperties.value("neutral_package", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("neutral_package", value); }
        }

        public System.DateTime? delivery_last_date
        {
            get { return (System.DateTime?)listProperties.value("delivery_last_date", aField.FIELD_TYPE.DATE); }
            set { listProperties.setValue("delivery_last_date", value); }
        }

        public System.DateTime? delivery_next_date
        {
            get { return (System.DateTime?)listProperties.value("delivery_next_date", aField.FIELD_TYPE.DATE); }
        }

        public string product_barcode
        {
            get { return (string)listProperties.value("product_barcode", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("product_barcode", value); }
        }

        public double min_qty
        {
            get { return (double)listProperties.value("min_qty", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("min_qty", value); }
        }

        public double qty
        {
            get { return (double)listProperties.value("qty", aField.FIELD_TYPE.FLOAT); }
        }

        public bool delivery_monday
        {
            get { return (bool)listProperties.value("delivery_monday", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("delivery_monday", value); }
        }

        public int schedule_range
        {
            get { return (int)listProperties.value("schedule_range", aField.FIELD_TYPE.INTEGER); }
            set { listProperties.setValue("schedule_range", value); }
        }

        private manyToOne _f_name = new manyToOne(); //res.partner
        public manyToOne name
        {
            get { return _f_name; }
        }

        public double uom_uos_coef
        {
            get { return (double)listProperties.value("uom_uos_coef", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("uom_uos_coef", value); }
        }

        public bool delivery_tuesday
        {
            get { return (bool)listProperties.value("delivery_tuesday", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("delivery_tuesday", value); }
        }

        private manyToOne _f_product_id = new manyToOne(); //product.template
        public manyToOne product_id
        {
            get { return _f_product_id; }
        }

        public double ul_brut_weight
        {
            get { return (double)listProperties.value("ul_brut_weight", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("ul_brut_weight", value); }
        }

        public int delivery_frequency
        {
            get { return (int)listProperties.value("delivery_frequency", aField.FIELD_TYPE.INTEGER); }
            set { listProperties.setValue("delivery_frequency", value); }
        }

        public int supplier_priority
        {
            get { return (int)listProperties.value("supplier_priority", aField.FIELD_TYPE.INTEGER); }
            set { listProperties.setValue("supplier_priority", value); }
        }

        private manyToOne _f_product_uos_id = new manyToOne(); //product.uom
        public manyToOne product_uos_id
        {
            get { return _f_product_uos_id; }
        }

        public int id
        {
            get { return (int)listProperties.value("id", aField.FIELD_TYPE.INTEGER); }
            set { listProperties.setValue("id", value); }
        }
        public override string resource_name()
        {
            return "product.supplierinfo";
        }
    }
}
