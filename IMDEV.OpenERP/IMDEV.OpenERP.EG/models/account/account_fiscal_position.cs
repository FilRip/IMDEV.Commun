using IMDEV.OpenERP.models.@base;
using IMDEV.OpenERP.models.fields.relations;

namespace IMDEV.OpenERP.EG.models.account
{
    public class account_fiscal_position : anOpenERPObject
    {
        public string name
        {
            get { return (string)listProperties.value("name", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("name", value); }
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
        private IMDEV.OpenERP.models.fields.texteMultilangue _note_multilangue;
        public IMDEV.OpenERP.models.fields.texteMultilangue note_multilangue
        {
            get
            {
                if (_note_multilangue == null) _note_multilangue = new IMDEV.OpenERP.models.fields.texteMultilangue(this, "note");
                return _note_multilangue;
            }
        }

        private oneToMany _f_account_ids = new oneToMany(); //account.fiscal.position.account
        public oneToMany account_ids
        {
            get { return _f_account_ids; }
        }

        public bool is_printed
        {
            get { return (bool)listProperties.value("is_printed", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("is_printed", value); }
        }

        private oneToMany _f_tax_ids = new oneToMany(); //account.fiscal.position.tax
        public oneToMany tax_ids
        {
            get { return _f_tax_ids; }
        }

        public int id
        {
            get { return (int)listProperties.value("id", aField.FIELD_TYPE.INTEGER); }
            set { listProperties.setValue("id", value); }
        }
        public override string resource_name()
        {
            return "account.fiscal.position";
        }
    }
}
