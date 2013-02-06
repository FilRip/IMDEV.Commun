using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IMDEV.OpenERP.models.@base;
using IMDEV.OpenERP.models.fields.relations;

namespace IMDEV.OpenERP.EG.models.product
{
    public class product_root_code : anOpenERPObject
    {
        public bool raw_material
        {
            get { return (bool)listProperties.value("raw_material", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("raw_material", value); }
        }

        public string code
        {
            get { return (string)listProperties.value("code", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("code", value); }
        }

        private manyToOne _f_sequence_id = new manyToOne(); //ir.sequence
        public manyToOne sequence_id
        {
            get { return _f_sequence_id; }
        }

        public string name
        {
            get { return (string)listProperties.value("name", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("name", value); }
        }

        public int id
        {
            get { return (int)listProperties.value("id", aField.FIELD_TYPE.INTEGER); }
            set { listProperties.setValue("id", value); }
        }
        public override string resource_name()
        {
            return "product.root.code";
        }
    }
}
