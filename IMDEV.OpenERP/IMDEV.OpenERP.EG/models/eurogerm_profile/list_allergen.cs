using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IMDEV.OpenERP.models.@base;
using IMDEV.OpenERP.models.fields.relations;

namespace IMDEV.OpenERP.EG.models.eurogerm_profile
{
    public class list_allergen : anOpenERPObject
    {
        public bool not_declared
        {
            get { return (bool)listProperties.value("not_declared", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("not_declared", value); }
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

        public bool systematic
        {
            get { return (bool)listProperties.value("systematic", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("systematic", value); }
        }

        public int sequence
        {
            get { return (int)listProperties.value("sequence", aField.FIELD_TYPE.INTEGER); }
            set { listProperties.setValue("sequence", value); }
        }

        public int id
        {
            get { return (int)listProperties.value("id", aField.FIELD_TYPE.INTEGER); }
            set { listProperties.setValue("id", value); }
        }
        public override string resource_name()
        {
            return "list.allergen";
        }
    }
}
