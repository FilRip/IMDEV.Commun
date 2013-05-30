using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IMDEV.OpenERP.models.@base;
using IMDEV.OpenERP.models.fields.relations;

namespace IMDEV.OpenERP.EG.models.quality
{
    public class quality_pqcd_setting : anOpenERPObject
    {
        private oneToMany _f_analysis_line_ids = new oneToMany(); //pqcd.analysis.setting.line
        public oneToMany analysis_line_ids
        {
            get { return _f_analysis_line_ids; }
        }

        private manyToOne _f_product_id = new manyToOne(); //product.product
        public manyToOne product_id
        {
            get { return _f_product_id; }
        }

        public string product_comments
        {
            get { return (string)listProperties.value("product_comments", aField.FIELD_TYPE.TEXT); }
        }

        public bool all_product
        {
            get { return (bool)listProperties.value("all_product", aField.FIELD_TYPE.BOOLEAN); }
        }

        private manyToOne _f_company_id = new manyToOne(); //res.company
        public manyToOne company_id
        {
            get { return _f_company_id; }
        }

        public string comments
        {
            get { return (string)listProperties.value("comments", aField.FIELD_TYPE.TEXT); }
        }

        public enum ENUM_STATE
        {
            NULL
            ,
            @draft
                , @progress
        }
        private string[] _frv_state = new string[] { "NULL", "draft", "progress" };
        private string[] _fl_state = new string[] { "NULL", "Draft", "In Progress" };
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

        public string partner_internal_name
        {
            get { return (string)listProperties.value("partner_internal_name", aField.FIELD_TYPE.CHAR); }
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
            return "quality.pqcd.setting";
        }
    }
}
