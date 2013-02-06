using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IMDEV.OpenERP.models.@base;
using IMDEV.OpenERP.models.fields.relations;

namespace IMDEV.OpenERP.EG.models.stock
{
    public class stock_tracking : anOpenERPObject
    {
        public double stock_available
        {
            get { return (double)listProperties.value("stock_available", aField.FIELD_TYPE.FLOAT); }
        }

        public enum ENUM_UM_RESERVED
        {
            NULL
            ,
            @unreserved
                ,
            @prod
                ,
            @quality
                , @other
        }
        private string[] _frv_um_reserved = new string[] { "NULL", "unreserved", "prod", "quality", "other" };
        private string[] _fl_um_reserved = new string[] { "NULL", "UnReserved", "By Production", "By Quality", "By Other" };
        private ENUM_UM_RESERVED _fv_um_reserved;
        public ENUM_UM_RESERVED um_reserved
        {
            get { return _fv_um_reserved; }
            set { _fv_um_reserved = value; }
        }
        public string LIBELLE_um_reserved
        {
            get { return _fl_um_reserved[(int)_fv_um_reserved]; }
        }

        public string name
        {
            get { return (string)listProperties.value("name", aField.FIELD_TYPE.CHAR); }
        }

        private oneToMany _f_lot_ids = new oneToMany(); //stock.production.lot
        public oneToMany lot_ids
        {
            get { return _f_lot_ids; }
        }

        private manyToOne _f_sale_order_line_production_id = new manyToOne(); //sale.order.line
        public manyToOne sale_order_line_production_id
        {
            get { return _f_sale_order_line_production_id; }
        }

        private manyToOne _f_company_id = new manyToOne(); //res.company
        public manyToOne company_id
        {
            get { return _f_company_id; }
        }

        private oneToMany _f_move_ids = new oneToMany(); //stock.move
        public oneToMany move_ids
        {
            get { return _f_move_ids; }
        }

        public System.DateTime date
        {
            get { return (System.DateTime)listProperties.value("date", aField.FIELD_TYPE.DATETIME); }
            set { listProperties.setValue("date", value); }
        }

        private oneToMany _f_revisions = new oneToMany(); //stock.um.status.revision
        public oneToMany revisions
        {
            get { return _f_revisions; }
        }

        private manyToOne _f_production_id = new manyToOne(); //mrp.production
        public manyToOne production_id
        {
            get { return _f_production_id; }
        }

        private manyToOne _f_um_unusable_reason = new manyToOne(); //stock.um.unusable.reason
        public manyToOne um_unusable_reason
        {
            get { return _f_um_unusable_reason; }
        }

        public bool active
        {
            get { return (bool)listProperties.value("active", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("active", value); }
        }

        private manyToOne _f_sale_order_line_id = new manyToOne(); //sale.order.line
        public manyToOne sale_order_line_id
        {
            get { return _f_sale_order_line_id; }
        }

        public string serial
        {
            get { return (string)listProperties.value("serial", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("serial", value); }
        }

        public bool um_unusable
        {
            get { return (bool)listProperties.value("um_unusable", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("um_unusable", value); }
        }

        public enum ENUM_UM_STATE
        {
            NULL
            ,
            @rebut
                ,
            @non_conforme
                ,
            @recycl_non_conf
                ,
            @conforme
                ,
            @recycl_conf
                , @att_conformite
        }
        private string[] _frv_um_state = new string[] { "NULL", "rebut", "non_conforme", "recycl_non_conf", "conforme", "recycl_conf", "att_conformite" };
        private string[] _fl_um_state = new string[] { "NULL", "Scrapped", "Non-conform", "Non-conform Recycle", "Conform", "Conform Recycle", "Waiting Conformity" };
        private ENUM_UM_STATE _fv_um_state;
        public ENUM_UM_STATE um_state
        {
            get { return _fv_um_state; }
            set { _fv_um_state = value; }
        }
        public string LIBELLE_um_state
        {
            get { return _fl_um_state[(int)_fv_um_state]; }
        }

        public double stock_reserved
        {
            get { return (double)listProperties.value("stock_reserved", aField.FIELD_TYPE.FLOAT); }
        }

        private manyToOne _f_product_id = new manyToOne(); //product.product
        public manyToOne product_id
        {
            get { return _f_product_id; }
        }

        public int id
        {
            get { return (int)listProperties.value("id", aField.FIELD_TYPE.INTEGER); }
            set { listProperties.setValue("id", value); }
        }
        public override string resource_name()
        {
            return "stock.tracking";
        }
    }
}
