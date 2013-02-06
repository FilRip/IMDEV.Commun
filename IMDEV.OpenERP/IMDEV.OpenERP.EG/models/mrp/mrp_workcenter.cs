using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IMDEV.OpenERP.models.@base;
using IMDEV.OpenERP.models.fields.relations;

namespace IMDEV.OpenERP.EG.models.mrp
{
    public class mrp_workcenter : anOpenERPObject
    {
        public string code
        {
            get { return (string)listProperties.value("code", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("code", value); }
        }

        public double costs_cycle
        {
            get { return (double)listProperties.value("costs_cycle", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("costs_cycle", value); }
        }

        public double time_stop
        {
            get { return (double)listProperties.value("time_stop", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("time_stop", value); }
        }

        public int code_automat
        {
            get { return (int)listProperties.value("code_automat", aField.FIELD_TYPE.INTEGER); }
            set { listProperties.setValue("code_automat", value); }
        }

        public double medium_qty
        {
            get { return (double)listProperties.value("medium_qty", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("medium_qty", value); }
        }

        private manyToOne _f_calendar_id = new manyToOne(); //resource.calendar
        public manyToOne calendar_id
        {
            get { return _f_calendar_id; }
        }

        public double maximal_qty
        {
            get { return (double)listProperties.value("maximal_qty", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("maximal_qty", value); }
        }

        public double routing_coefficient
        {
            get { return (double)listProperties.value("routing_coefficient", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("routing_coefficient", value); }
        }

        private manyToOne _f_costs_cycle_account_id = new manyToOne(); //account.analytic.account
        public manyToOne costs_cycle_account_id
        {
            get { return _f_costs_cycle_account_id; }
        }

        public double time_efficiency
        {
            get { return (double)listProperties.value("time_efficiency", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("time_efficiency", value); }
        }

        private manyToOne _f_user_id = new manyToOne(); //res.users
        public manyToOne user_id
        {
            get { return _f_user_id; }
        }

        private manyToOne _f_resource_id = new manyToOne(); //resource.resource
        public manyToOne resource_id
        {
            get { return _f_resource_id; }
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

        private manyToOne _f_costs_hour_account_id = new manyToOne(); //account.analytic.account
        public manyToOne costs_hour_account_id
        {
            get { return _f_costs_hour_account_id; }
        }

        private manyToOne _f_costs_general_account_id = new manyToOne(); //account.account
        public manyToOne costs_general_account_id
        {
            get { return _f_costs_general_account_id; }
        }

        private manyToOne _f_costs_journal_id = new manyToOne(); //account.analytic.journal
        public manyToOne costs_journal_id
        {
            get { return _f_costs_journal_id; }
        }

        private manyToOne _f_warehouse_id = new manyToOne(); //stock.warehouse
        public manyToOne warehouse_id
        {
            get { return _f_warehouse_id; }
        }

        public double costs_hour
        {
            get { return (double)listProperties.value("costs_hour", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("costs_hour", value); }
        }

        private oneToMany _f_overdose_ids = new oneToMany(); //mrp.workcenter.overdose
        public oneToMany overdose_ids
        {
            get { return _f_overdose_ids; }
        }

        public int min_qty_allowed
        {
            get { return (int)listProperties.value("min_qty_allowed", aField.FIELD_TYPE.INTEGER); }
            set { listProperties.setValue("min_qty_allowed", value); }
        }

        public bool active
        {
            get { return (bool)listProperties.value("active", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("active", value); }
        }

        public double time_start
        {
            get { return (double)listProperties.value("time_start", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("time_start", value); }
        }

        public double time_cycle
        {
            get { return (double)listProperties.value("time_cycle", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("time_cycle", value); }
        }

        private manyToOne _f_product_id = new manyToOne(); //product.product
        public manyToOne product_id
        {
            get { return _f_product_id; }
        }

        public double capacity_per_cycle
        {
            get { return (double)listProperties.value("capacity_per_cycle", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("capacity_per_cycle", value); }
        }

        public string name
        {
            get { return (string)listProperties.value("name", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("name", value); }
        }

        public bool merge_product_lines
        {
            get { return (bool)listProperties.value("merge_product_lines", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("merge_product_lines", value); }
        }

        private oneToMany _f_workcenter_location_ids = new oneToMany(); //mrp.workcenter.location
        public oneToMany workcenter_location_ids
        {
            get { return _f_workcenter_location_ids; }
        }

        public enum ENUM_RESOURCE_TYPE
        {
            NULL
            ,
            @user
                , @material
        }
        private string[] _frv_resource_type = new string[] { "NULL", "user", "material" };
        private string[] _fl_resource_type = new string[] { "NULL", "Human", "Material" };
        private ENUM_RESOURCE_TYPE _fv_resource_type;
        public ENUM_RESOURCE_TYPE resource_type
        {
            get { return _fv_resource_type; }
            set { _fv_resource_type = value; }
        }
        public string LIBELLE_resource_type
        {
            get { return _fl_resource_type[(int)_fv_resource_type]; }
        }

        public int id
        {
            get { return (int)listProperties.value("id", aField.FIELD_TYPE.INTEGER); }
            set { listProperties.setValue("id", value); }
        }
        public override string resource_name()
        {
            return "mrp.workcenter";
        }
    }
}
