using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IMDEV.OpenERP.models.@base;
using IMDEV.OpenERP.models.fields.relations;

namespace IMDEV.OpenERP.EG.models.eurogerm_profile
{
    public class risk_danger : anOpenERPObject
    {
        public byte[] logo
        {
            get { return (byte[])listProperties.value("logo", aField.FIELD_TYPE.BINARY); }
            set { listProperties.setValue("logo", value); }
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
            return "risk.danger";
        }
    }
}
