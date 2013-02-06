using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IMDEV.OpenERP.models.@base;
using IMDEV.OpenERP.models.fields.relations;

namespace IMDEV.OpenERP.EG.models.product
{
    public class product_uom : anOpenERPObject
    {
        public string intrastat_label
        {
            get { return (string)listProperties.value("intrastat_label", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("intrastat_label", value); }
        }

        public string name
        {
            get { return (string)listProperties.value("name", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("name", value); }
        }
        private IMDEV.OpenERP.models.fields.texteMultilangue _name_multilangue;
        public IMDEV.OpenERP.models.fields.texteMultilangue name_multilangue
        {
            get
            {
                if (_name_multilangue == null) _name_multilangue = new IMDEV.OpenERP.models.fields.texteMultilangue(this, "name");
                return _name_multilangue;
            }
        }

        public double factor_inv
        {
            get { return (double)listProperties.value("factor_inv", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("factor_inv", value); }
        }

        public double rounding
        {
            get { return (double)listProperties.value("rounding", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("rounding", value); }
        }

        public int id
        {
            get { return (int)listProperties.value("id", aField.FIELD_TYPE.INTEGER); }
            set { listProperties.setValue("id", value); }
        }
        public override string resource_name()
        {
            return "product.uom";
        }
    }
}
