using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IMDEV.OpenERP.models.@base;
using IMDEV.OpenERP.models.fields.relations;

namespace IMDEV.OpenERP.EG.models.account
{
    public class account_invoice_tax : anOpenERPObject
    {
        public double factor_tax
        {
            get { return (double)listProperties.value("factor_tax", aField.FIELD_TYPE.FLOAT); }
        }

        public double tax_amount
        {
            get { return (double)listProperties.value("tax_amount", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("tax_amount", value); }
        }

        private manyToOne _f_account_id = new manyToOne(); //account.account
        public manyToOne account_id
        {
            get { return _f_account_id; }
        }

        public int sequence
        {
            get { return (int)listProperties.value("sequence", aField.FIELD_TYPE.INTEGER); }
            set { listProperties.setValue("sequence", value); }
        }

        private manyToOne _f_invoice_id = new manyToOne(); //account.invoice
        public manyToOne invoice_id
        {
            get { return _f_invoice_id; }
        }

        public bool manual
        {
            get { return (bool)listProperties.value("manual", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("manual", value); }
        }

        private manyToOne _f_company_id = new manyToOne(); //res.company
        public manyToOne company_id
        {
            get { return _f_company_id; }
        }

        public double base_amount
        {
            get { return (double)listProperties.value("base_amount", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("base_amount", value); }
        }

        public double factor_base
        {
            get { return (double)listProperties.value("factor_base", aField.FIELD_TYPE.FLOAT); }
        }

        public double amount
        {
            get { return (double)listProperties.value("amount", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("amount", value); }
        }

        public double @base
        {
            get { return (double)listProperties.value("base", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("base", value); }
        }

        private manyToOne _f_tax_code_id = new manyToOne(); //account.tax.code
        public manyToOne tax_code_id
        {
            get { return _f_tax_code_id; }
        }

        private manyToOne _f_base_code_id = new manyToOne(); //account.tax.code
        public manyToOne base_code_id
        {
            get { return _f_base_code_id; }
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
            return "account.invoice.tax";
        }
    }
}
