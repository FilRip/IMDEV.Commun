using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IMDEV.OpenERP.EG.models.stock
{
    using IMDEV.OpenERP.models.@base;
    using IMDEV.OpenERP.models.fields.relations;

    public class stock_production_lot : anOpenERPObject
    {
        public enum ENUM_LOT_RESERVED
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
        private string[] _frv_lot_reserved = new string[] { "NULL", "unreserved", "prod", "quality", "other" };
        private string[] _fl_lot_reserved = new string[] { "NULL", "UnReserved", "By Production", "By Quality", "By Other" };
        private ENUM_LOT_RESERVED _fv_lot_reserved;
        public ENUM_LOT_RESERVED lot_reserved
        {
            get { return _fv_lot_reserved; }
            set { _fv_lot_reserved = value; }
        }
        public string LIBELLE_lot_reserved
        {
            get { return _fl_lot_reserved[(int)_fv_lot_reserved]; }
        }

        private oneToMany _f_lot_att_conf_state_ids = new oneToMany(); //prodlot.attconf.status
        public oneToMany lot_att_conf_state_ids
        {
            get { return _f_lot_att_conf_state_ids; }
        }

        private manyToMany _f_quality_problem_ids = new manyToMany(); //prodlot.quality.problem
        public manyToMany quality_problem_ids
        {
            get { return _f_quality_problem_ids; }
        }

        public double real_price
        {
            get { return (double)listProperties.value("real_price", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("real_price", value); }
        }

        public System.DateTime? requalification_date
        {
            get { return (System.DateTime?)listProperties.value("requalification_date", aField.FIELD_TYPE.DATE); }
            set { listProperties.setValue("requalification_date", value); }
        }

        public string prefix
        {
            get { return (string)listProperties.value("prefix", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("prefix", value); }
        }

        public string origin_lot
        {
            get { return (string)listProperties.value("origin_lot", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("origin_lot", value); }
        }

        private manyToOne _f_packaging_id = new manyToOne(); //product.packaging
        public manyToOne packaging_id
        {
            get { return _f_packaging_id; }
        }

        public double initial_price
        {
            get { return (double)listProperties.value("initial_price", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("initial_price", value); }
        }

        private oneToMany _f_revisions = new oneToMany(); //stock.production.lot.revision
        public oneToMany revisions
        {
            get { return _f_revisions; }
        }

        public double stock_available
        {
            get { return (double)listProperties.value("stock_available", aField.FIELD_TYPE.FLOAT); }
        }

        private oneToMany _f_um_ids = new oneToMany(); //stock.tracking
        public oneToMany um_ids
        {
            get { return _f_um_ids; }
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

        private manyToOne _f_parent_id = new manyToOne(); //stock.production.lot
        public manyToOne parent_id
        {
            get { return _f_parent_id; }
        }

        public enum ENUM_TYPE
        {
            NULL
            ,
            @batch
                ,
            @normal
                , @view
        }
        private string[] _frv_type = new string[] { "NULL", "batch", "normal", "view" };
        private string[] _fl_type = new string[] { "NULL", "Batch", "Normal", "View" };
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

        public enum ENUM_LOT_STATE
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
        private string[] _frv_lot_state = new string[] { "NULL", "rebut", "non_conforme", "recycl_non_conf", "conforme", "recycl_conf", "att_conformite" };
        private string[] _fl_lot_state = new string[] { "NULL", "Scrapped", "Non-conform", "Non-conform Recycle", "Conform", "Conform Recycle", "Waiting Conformity" };
        private ENUM_LOT_STATE _fv_lot_state;
        public ENUM_LOT_STATE lot_state
        {
            get { return _fv_lot_state; }
            set { _fv_lot_state = value; }
        }
        public string LIBELLE_lot_state
        {
            get { return _fl_lot_state[(int)_fv_lot_state]; }
        }

        public System.DateTime? life_date
        {
            get { return (System.DateTime?)listProperties.value("life_date", aField.FIELD_TYPE.DATE); }
            set { listProperties.setValue("life_date", value); }
        }

        public System.DateTime? date
        {
            get { return (System.DateTime?)listProperties.value("date", aField.FIELD_TYPE.DATETIME); }
            set { listProperties.setValue("date", value); }
        }

        private oneToMany _f_out_of_tolerance_ids = new oneToMany(); //mrp.production.lot.tolerance
        public oneToMany out_of_tolerance_ids
        {
            get { return _f_out_of_tolerance_ids; }
        }

        public string name
        {
            get { return (string)listProperties.value("name", aField.FIELD_TYPE.CHAR); }
        }

        private manyToOne _f_product_id = new manyToOne(); //product.product
        public manyToOne product_id
        {
            get { return _f_product_id; }
        }

        public string @ref
        {
            get { return (string)listProperties.value("ref", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("ref", value); }
        }

        public System.DateTime? removal_date
        {
            get { return (System.DateTime?)listProperties.value("removal_date", aField.FIELD_TYPE.DATE); }
            set { listProperties.setValue("removal_date", value); }
        }

        public string suffix
        {
            get { return (string)listProperties.value("suffix", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("suffix", value); }
        }

        public string bom_revision
        {
            get { return (string)listProperties.value("bom_revision", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("bom_revision", value); }
        }

        private manyToOne _f_production_id = new manyToOne(); //mrp.production
        public manyToOne production_id
        {
            get { return _f_production_id; }
        }

        public System.DateTime? alert_date
        {
            get { return (System.DateTime?)listProperties.value("alert_date", aField.FIELD_TYPE.DATE); }
            set { listProperties.setValue("alert_date", value); }
        }

        public System.DateTime? use_date
        {
            get { return (System.DateTime?)listProperties.value("use_date", aField.FIELD_TYPE.DATETIME); }
            set { listProperties.setValue("use_date", value); }
        }

        public int id
        {
            get { return (int)listProperties.value("id", aField.FIELD_TYPE.INTEGER); }
            set { listProperties.setValue("id", value); }
        }
        public override string resource_name()
        {
            return "stock.production.lot";
        }
    }
}
