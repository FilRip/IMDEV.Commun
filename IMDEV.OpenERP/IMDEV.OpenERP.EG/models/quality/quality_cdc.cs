using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IMDEV.OpenERP.models.@base;
using IMDEV.OpenERP.models.fields.relations;

namespace IMDEV.OpenERP.EG.models.quality
{
    public class quality_cdc : anOpenERPObject
    {
        public System.DateTime pf_update_date
        {
            get { return (System.DateTime)listProperties.value("pf_update_date", aField.FIELD_TYPE.DATE); }
            set { listProperties.setValue("pf_update_date", value); }
        }

        private manyToOne _f_product_id = new manyToOne(); //product.product
        public manyToOne product_id
        {
            get { return _f_product_id; }
        }

        public bool flg_origin_geo
        {
            get { return (bool)listProperties.value("flg_origin_geo", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("flg_origin_geo", value); }
        }

        public int origin_id
        {
            get { return (int)listProperties.value("origin_id", aField.FIELD_TYPE.INTEGER); }
            set { listProperties.setValue("origin_id", value); }
        }

        public System.DateTime allergen_update_date
        {
            get { return (System.DateTime)listProperties.value("allergen_update_date", aField.FIELD_TYPE.DATE); }
            set { listProperties.setValue("allergen_update_date", value); }
        }

        public System.DateTime kasher_hallal_update_date
        {
            get { return (System.DateTime)listProperties.value("kasher_hallal_update_date", aField.FIELD_TYPE.DATE); }
            set { listProperties.setValue("kasher_hallal_update_date", value); }
        }

        public System.DateTime cdc_update_date
        {
            get { return (System.DateTime)listProperties.value("cdc_update_date", aField.FIELD_TYPE.DATE); }
            set { listProperties.setValue("cdc_update_date", value); }
        }

        public System.DateTime origin_geo_update_date
        {
            get { return (System.DateTime)listProperties.value("origin_geo_update_date", aField.FIELD_TYPE.DATE); }
            set { listProperties.setValue("origin_geo_update_date", value); }
        }

        public string directory_link
        {
            get { return (string)listProperties.value("directory_link", aField.FIELD_TYPE.CHAR); }
        }

        public bool flg_kasher_hallal
        {
            get { return (bool)listProperties.value("flg_kasher_hallal", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("flg_kasher_hallal", value); }
        }

        public System.DateTime last_update_date
        {
            get { return (System.DateTime)listProperties.value("last_update_date", aField.FIELD_TYPE.DATE); }
            set { listProperties.setValue("last_update_date", value); }
        }

        public bool flg_pf
        {
            get { return (bool)listProperties.value("flg_pf", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("flg_pf", value); }
        }

        public bool flg_allergen
        {
            get { return (bool)listProperties.value("flg_allergen", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("flg_allergen", value); }
        }

        public bool flg_cdc
        {
            get { return (bool)listProperties.value("flg_cdc", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("flg_cdc", value); }
        }

        private manyToOne _f_partner_id = new manyToOne(); //res.partner
        public manyToOne partner_id
        {
            get { return _f_partner_id; }
        }

        public int id
        {
            get { return (int)listProperties.value("id", aField.FIELD_TYPE.INTEGER); }
            set { listProperties.setValue("id", value); }
        }
        public override string resource_name()
        {
            return "quality.cdc";
        }
    }
}
