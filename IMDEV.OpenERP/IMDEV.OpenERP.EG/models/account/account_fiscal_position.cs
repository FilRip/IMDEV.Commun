using IMDEV.OpenERP.models.@base;
using IMDEV.OpenERP.models.fields.relations;
using System.Collections.Generic;

namespace IMDEV.OpenERP.EG.models.account
{
    public class account_fiscal_position : anOpenERPObject
    {
        private List<account_fiscal_position_account> _listAccounts;
        private List<account_fiscal_position_tax> _listTaxes;

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

        public List<account_fiscal_position_tax> listTaxes()
        {
            return _listTaxes;
        }
        public void chargeTaxes(Clients.clientOpenERP cli)
        {
            List<object> _listObj;
            if ((tax_ids != null) && (tax_ids.getValue != null) && (tax_ids.getValue.Count > 0))
            {
                _listObj = cli.read(new IMDEV.OpenERP.models.query.aQuery(tax_ids.getValue), typeof(account_fiscal_position_tax));
                _listTaxes = new List<account_fiscal_position_tax>();
                foreach (account_fiscal_position_tax f in _listObj)
                    _listTaxes.Add(f);
            }
        }
        public int taxAffectee(int id)
        {
            if (_listTaxes != null)
                foreach (account_fiscal_position_tax t in _listTaxes)
                    if (t.tax_src_id.id == id) return t.tax_dest_id.id;

            return id;
        }

        public List<account_fiscal_position_account> listAccounts()
        {
            return _listAccounts;
        }
        public void chargeAccounts(Clients.clientOpenERP cli)
        {
            List<object> _listObj;
            if ((account_ids != null) && (account_ids.getValue != null) && (account_ids.getValue.Count > 0))
            {
                _listObj = cli.read(new IMDEV.OpenERP.models.query.aQuery(account_ids.getValue), typeof(account_fiscal_position_account));
                _listAccounts = new List<account_fiscal_position_account>();
                foreach (account_fiscal_position_account f in _listObj)
                    _listAccounts.Add(f);
            }
        }
        public int compteAffectee(int accountId)
        {
            if (_listAccounts != null)
                foreach (account_fiscal_position_account t in _listAccounts)
                    if (t.account_src_id.id == accountId) return t.account_dest_id.id;

            return accountId;
        }
    }
}
