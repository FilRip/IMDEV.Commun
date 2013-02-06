using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IMDEV.OpenERP.models.@base;
using IMDEV.OpenERP.models.fields.relations;

namespace IMDEV.OpenERP.EG.models.product
{
    public class product_risk : anOpenERPObject
    {
        public byte[] logo
        {
            get { return (byte[])listProperties.value("logo", aField.FIELD_TYPE.BINARY); }
        }

        private manyToOne _f_danger_id = new manyToOne(); //risk.danger
        public manyToOne danger_id
        {
            get { return _f_danger_id; }
        }

        public string libelle
        {
            get { return (string)listProperties.value("libelle", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("libelle", value); }
        }
        private IMDEV.OpenERP.models.fields.texteMultilangue _libelle_multilangue;
        public IMDEV.OpenERP.models.fields.texteMultilangue libelle_multilangue
        {
            get
            {
                if (_libelle_multilangue == null) _libelle_multilangue = new IMDEV.OpenERP.models.fields.texteMultilangue(this, "libelle");
                return _libelle_multilangue;
            }
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
            return "product.risk";
        }
    }
}
