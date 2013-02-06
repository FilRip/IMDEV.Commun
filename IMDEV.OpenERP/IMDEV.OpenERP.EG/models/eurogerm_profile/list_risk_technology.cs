using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IMDEV.OpenERP.models.@base;
using IMDEV.OpenERP.models.fields.relations;

namespace IMDEV.OpenERP.EG.models.eurogerm_profile
{
    public class list_risk_technology : anOpenERPObject
    {
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

        public int id
        {
            get { return (int)listProperties.value("id", aField.FIELD_TYPE.INTEGER); }
            set { listProperties.setValue("id", value); }
        }
        public override string resource_name()
        {
            return "list.risk.technology";
        }
    }
}
