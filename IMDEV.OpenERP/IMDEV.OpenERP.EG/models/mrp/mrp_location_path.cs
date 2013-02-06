using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IMDEV.OpenERP.models.@base;
using IMDEV.OpenERP.models.fields.relations;

namespace IMDEV.OpenERP.EG.models.mrp
{
    public class mrp_location_path : anOpenERPObject
    {
        private manyToOne _f_location_from_id = new manyToOne(); //stock.location
        public manyToOne location_from_id
        {
            get { return _f_location_from_id; }
        }

        public string name
        {
            get { return (string)listProperties.value("name", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("name", value); }
        }

        public enum ENUM_AUTO
        {
            NULL
            ,
            @transparent
                ,
            @auto
                , @manual
        }
        private string[] _frv_auto = new string[] { "NULL", "transparent", "auto", "manual" };
        private string[] _fl_auto = new string[] { "NULL", "Automatic No Step Added", "Automatic Move", "Manual Operation" };
        private ENUM_AUTO _fv_auto;
        public ENUM_AUTO auto
        {
            get { return _fv_auto; }
            set { _fv_auto = value; }
        }
        public string LIBELLE_auto
        {
            get { return _fl_auto[(int)_fv_auto]; }
        }

        public bool force_assign
        {
            get { return (bool)listProperties.value("force_assign", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("force_assign", value); }
        }

        private manyToOne _f_journal_id = new manyToOne(); //stock.journal
        public manyToOne journal_id
        {
            get { return _f_journal_id; }
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

        private manyToOne _f_company_id = new manyToOne(); //res.company
        public manyToOne company_id
        {
            get { return _f_company_id; }
        }

        public int delay
        {
            get { return (int)listProperties.value("delay", aField.FIELD_TYPE.INTEGER); }
            set { listProperties.setValue("delay", value); }
        }

        private manyToOne _f_location_dest_id = new manyToOne(); //stock.location
        public manyToOne location_dest_id
        {
            get { return _f_location_dest_id; }
        }

        public bool auto_picking
        {
            get { return (bool)listProperties.value("auto_picking", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("auto_picking", value); }
        }

        private manyToOne _f_bom_id = new manyToOne(); //mrp.bom
        public manyToOne bom_id
        {
            get { return _f_bom_id; }
        }

        public enum ENUM_PICKING_TYPE
        {
            NULL
            ,
            @out
                ,
            @internal
                , @in
        }
        private string[] _frv_picking_type = new string[] { "NULL", "out", "internal", "in" };
        private string[] _fl_picking_type = new string[] { "NULL", "Sending Goods", "Internal", "Getting Goods" };
        private ENUM_PICKING_TYPE _fv_picking_type;
        public ENUM_PICKING_TYPE picking_type
        {
            get { return _fv_picking_type; }
            set { _fv_picking_type = value; }
        }
        public string LIBELLE_picking_type
        {
            get { return _fl_picking_type[(int)_fv_picking_type]; }
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
            return "mrp.location.path";
        }
    }
}
