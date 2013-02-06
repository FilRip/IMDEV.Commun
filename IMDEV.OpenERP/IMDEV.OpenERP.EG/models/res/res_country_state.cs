using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IMDEV.OpenERP.models.@base;
using IMDEV.OpenERP.models.fields.relations;

namespace IMDEV.OpenERP.EG.models.res
{
    public class res_country_state : anOpenERPObject
    {
        public string code
        {
            get { return (string)listProperties.value("code", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("code", value); }
        }

        private manyToOne _f_country_id = new manyToOne();
        public manyToOne country_id
        {
            get { return _f_country_id; }
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
            return "res.country.state";
        }
    }
}
