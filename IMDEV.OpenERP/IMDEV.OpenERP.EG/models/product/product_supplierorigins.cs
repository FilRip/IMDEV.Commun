using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IMDEV.OpenERP.models.@base;
using IMDEV.OpenERP.models.fields.relations;

namespace IMDEV.OpenERP.EG.models.product
{
    public class product_supplierorigins : anOpenERPObject
    {
        public string animal_plant_origin
        {
            get { return (string)listProperties.value("animal_plant_origin", aField.FIELD_TYPE.TEXT); }
            set { listProperties.setValue("animal_plant_origin", value); }
        }

        public bool ionisation
        {
            get { return (bool)listProperties.value("ionisation", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("ionisation", value); }
        }

        private manyToOne _f_product_id = new manyToOne(); //product.product
        public manyToOne product_id
        {
            get { return _f_product_id; }
        }

        public bool kasher
        {
            get { return (bool)listProperties.value("kasher", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("kasher", value); }
        }

        public System.DateTime security_sheet_last_update
        {
            get { return (System.DateTime)listProperties.value("security_sheet_last_update", aField.FIELD_TYPE.DATE); }
            set { listProperties.setValue("security_sheet_last_update", value); }
        }

        public string filename_location_security_sheet
        {
            get { return (string)listProperties.value("filename_location_security_sheet", aField.FIELD_TYPE.TEXT); }
            set { listProperties.setValue("filename_location_security_sheet", value); }
        }

        public System.DateTime? ogm_last_update
        {
            get { return (System.DateTime?)listProperties.value("ogm_last_update", aField.FIELD_TYPE.DATE); }
            set { listProperties.setValue("ogm_last_update", value); }
        }

        public bool hallal
        {
            get { return (bool)listProperties.value("hallal", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("hallal", value); }
        }

        public string dluo_supplier
        {
            get { return (string)listProperties.value("dluo_supplier", aField.FIELD_TYPE.TEXT); }
            set { listProperties.setValue("dluo_supplier", value); }
        }

        public bool kasher_oud
        {
            get { return (bool)listProperties.value("kasher_oud", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("kasher_oud", value); }
        }

        public bool kasher_oueg
        {
            get { return (bool)listProperties.value("kasher_oueg", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("kasher_oueg", value); }
        }

        public bool security_sheet
        {
            get { return (bool)listProperties.value("security_sheet", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("security_sheet", value); }
        }

        public string contaminants
        {
            get { return (string)listProperties.value("contaminants", aField.FIELD_TYPE.TEXT); }
            set { listProperties.setValue("contaminants", value); }
        }

        public string geographical_origin
        {
            get { return (string)listProperties.value("geographical_origin", aField.FIELD_TYPE.TEXT); }
            set { listProperties.setValue("geographical_origin", value); }
        }

        public System.DateTime? allergens_last_update
        {
            get { return (System.DateTime?)listProperties.value("allergens_last_update", aField.FIELD_TYPE.DATE); }
            set { listProperties.setValue("allergens_last_update", value); }
        }

        private manyToOne _f_name = new manyToOne(); //res.partner
        public manyToOne name
        {
            get { return _f_name; }
        }

        public int id
        {
            get { return (int)listProperties.value("id", aField.FIELD_TYPE.INTEGER); }
            set { listProperties.setValue("id", value); }
        }
        public override string resource_name()
        {
            return "product.supplierorigins";
        }
    }
}
