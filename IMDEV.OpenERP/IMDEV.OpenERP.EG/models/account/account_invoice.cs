using IMDEV.OpenERP.models.@base;
using IMDEV.OpenERP.models.fields.relations;

namespace IMDEV.OpenERP.EG.models.account
{
    public class account_invoice : anOpenERPObject
    {
        public string origin
        {
            get { return (string)listProperties.value("origin", aField.FIELD_TYPE.CHAR); }
        }

        public string comment
        {
            get { return (string)listProperties.value("comment", aField.FIELD_TYPE.TEXT); }
            set { listProperties.setValue("comment", value); }
        }

        public System.DateTime? date_due
        {
            get { return (System.DateTime?)listProperties.value("date_due", aField.FIELD_TYPE.DATE); }
            set { listProperties.setValue("date_due", value); }
        }

        public double check_total
        {
            get { return (double)listProperties.value("check_total", aField.FIELD_TYPE.FLOAT); }
            set { listProperties.setValue("check_total", value); }
        }

        public string reference
        {
            get { return (string)listProperties.value("reference", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("reference", value); }
        }

        private manyToOne _f_payment_term = new manyToOne(); //account.payment.term
        public manyToOne payment_term
        {
            get { return _f_payment_term; }
        }

        private manyToOne _f_sales_team_id = new manyToOne(); //crm.case.section
        public manyToOne sales_team_id
        {
            get { return _f_sales_team_id; }
        }

        public string number
        {
            get { return (string)listProperties.value("number", aField.FIELD_TYPE.CHAR); }
        }

        private manyToOne _f_journal_id = new manyToOne(); //account.journal
        public manyToOne journal_id
        {
            get { return _f_journal_id; }
        }

        private manyToOne _f_currency_id = new manyToOne(); //res.currency
        public manyToOne currency_id
        {
            get { return _f_currency_id; }
        }

        private manyToOne _f_address_invoice_id = new manyToOne(); //res.partner.address
        public manyToOne address_invoice_id
        {
            get { return _f_address_invoice_id; }
        }

        private manyToOne _f_intrastat_country_id = new manyToOne(); //res.country
        public manyToOne intrastat_country_id
        {
            get { return _f_intrastat_country_id; }
        }

        private oneToMany _f_tax_line = new oneToMany(); //account.invoice.tax
        public oneToMany tax_line
        {
            get { return _f_tax_line; }
        }

        private manyToOne _f_account_id = new manyToOne(); //account.account
        public manyToOne account_id
        {
            get { return _f_account_id; }
        }

        private manyToOne _f_fiscal_position = new manyToOne(); //account.fiscal.position
        public manyToOne fiscal_position
        {
            get { return _f_fiscal_position; }
        }

        private manyToOne _f_user_id = new manyToOne(); //res.users
        public manyToOne user_id
        {
            get { return _f_user_id; }
        }

        private manyToOne _f_payment_term2_id = new manyToOne(); //eg.payment.terms
        public manyToOne payment_term2_id
        {
            get { return _f_payment_term2_id; }
        }

        public enum ENUM_INTRASTAT_TRANSPORT
        {
            NULL
            ,
            @_9
                ,
            @_8
                ,
            @_7
                ,
            @_5
                ,
            @_4
                ,
            @_3
                ,
            @_2
                , @_1
        }
        private string[] _frv_intrastat_transport = new string[] { "NULL", "9", "8", "7", "5", "4", "3", "2", "1" };
        private string[] _fl_intrastat_transport = new string[] { "NULL", "Propulsion propre", "Transport par navigation intérieure", "Installations de transport fixes", "Envois postaux", "Transport par air", "Transport par route", "Transport par chemin de fer", "Transport maritime" };
        private ENUM_INTRASTAT_TRANSPORT _fv_intrastat_transport;
        public ENUM_INTRASTAT_TRANSPORT intrastat_transport
        {
            get { return _fv_intrastat_transport; }
            set { _fv_intrastat_transport = value; }
        }
        public string LIBELLE_intrastat_transport
        {
            get { return _fl_intrastat_transport[(int)_fv_intrastat_transport]; }
        }

        private manyToOne _f_address_contact_id = new manyToOne(); //res.partner.address
        public manyToOne address_contact_id
        {
            get { return _f_address_contact_id; }
        }

        public enum ENUM_REFERENCE_TYPE
        {
            NULL
            , @none
        }
        private string[] _frv_reference_type = new string[] { "NULL", "none" };
        private string[] _fl_reference_type = new string[] { "NULL", "Free Reference" };
        private ENUM_REFERENCE_TYPE _fv_reference_type;
        public ENUM_REFERENCE_TYPE reference_type
        {
            get { return _fv_reference_type; }
            set { _fv_reference_type = value; }
        }
        public string LIBELLE_reference_type
        {
            get { return _fl_reference_type[(int)_fv_reference_type]; }
        }

        private manyToOne _f_company_id = new manyToOne(); //res.company
        public manyToOne company_id
        {
            get { return _f_company_id; }
        }

        public double amount_tax
        {
            get { return (double)listProperties.value("amount_tax", aField.FIELD_TYPE.FLOAT); }
        }

        private manyToOne _f_distribution_id = new manyToOne(); //distribution.costs
        public manyToOne distribution_id
        {
            get { return _f_distribution_id; }
        }

        public enum ENUM_STATE
        {
            NULL
            ,
            @draft
                ,
            @paid
                ,
            @cancel
                ,
            @open
                ,
            @proforma
                , @proforma2
        }
        private string[] _frv_state = new string[] { "NULL", "draft", "paid", "cancel", "open", "proforma", "proforma2" };
        private string[] _fl_state = new string[] { "NULL", "Draft", "Paid", "Cancelled", "Open", "Pro-forma", "Pro-forma" };
        private ENUM_STATE _fv_state;
        public ENUM_STATE state
        {
            get { return _fv_state; }
            set { _fv_state = value; }
        }
        public string LIBELLE_state
        {
            get { return _fl_state[(int)_fv_state]; }
        }

        public bool purchasing_control
        {
            get { return (bool)listProperties.value("purchasing_control", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("purchasing_control", value); }
        }

        public enum ENUM_TYPE
        {
            NULL
            ,
            @out_invoice
                ,
            @out_refund
                ,
            @in_invoice
                , @in_refund
        }
        private string[] _frv_type = new string[] { "NULL", "out_invoice", "out_refund", "in_invoice", "in_refund" };
        private string[] _fl_type = new string[] { "NULL", "Customer Invoice", "Customer Refund", "Supplier Invoice", "Supplier Refund" };
        private ENUM_TYPE _fv_type;
        public ENUM_TYPE type
        {
            get { return _fv_type; }
            set { _fv_type = value; }
        }
        public string LIBELLE_type
        {
            get { return _fl_type[(int)_fv_type]; }
        }

        private oneToMany _f_invoice_line = new oneToMany(); //account.invoice.line
        public oneToMany invoice_line
        {
            get { return _f_invoice_line; }
        }

        public string internal_number
        {
            get { return (string)listProperties.value("internal_number", aField.FIELD_TYPE.CHAR); }
        }

        private manyToMany _f_move_lines = new manyToMany(); //account.move.line
        public manyToMany move_lines
        {
            get { return _f_move_lines; }
        }

        private manyToMany _f_payment_ids = new manyToMany(); //account.move.line
        public manyToMany payment_ids
        {
            get { return _f_payment_ids; }
        }

        private manyToOne _f_order_id = new manyToOne(); //sale.order
        public manyToOne order_id
        {
            get { return _f_order_id; }
        }

        public bool reconciled
        {
            get { return (bool)listProperties.value("reconciled", aField.FIELD_TYPE.BOOLEAN); }
        }

        public double residual
        {
            get { return (double)listProperties.value("residual", aField.FIELD_TYPE.FLOAT); }
        }

        public string move_name
        {
            get { return (string)listProperties.value("move_name", aField.FIELD_TYPE.CHAR); }
        }

        public System.DateTime? date_invoice
        {
            get { return (System.DateTime?)listProperties.value("date_invoice", aField.FIELD_TYPE.DATE); }
            set { listProperties.setValue("date_invoice", value); }
        }

        public double discount
        {
            get { return (double)listProperties.value("discount", aField.FIELD_TYPE.FLOAT); }
        }

        private manyToOne _f_period_id = new manyToOne(); //account.period
        public manyToOne period_id
        {
            get { return _f_period_id; }
        }

        public double currency_rate
        {
            get { return (double)listProperties.value("currency_rate", aField.FIELD_TYPE.FLOAT); }
        }

        public double amount_untaxed
        {
            get { return (double)listProperties.value("amount_untaxed", aField.FIELD_TYPE.FLOAT); }
        }

        public string intrastat_department
        {
            get { return (string)listProperties.value("intrastat_department", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("intrastat_department", value); }
        }

        private manyToOne _f_move_id = new manyToOne(); //account.move
        public manyToOne move_id
        {
            get { return _f_move_id; }
        }

        public double amount_total
        {
            get { return (double)listProperties.value("amount_total", aField.FIELD_TYPE.FLOAT); }
        }

        private manyToOne _f_partner_id = new manyToOne(); //res.partner
        public manyToOne partner_id
        {
            get { return _f_partner_id; }
        }

        public string name
        {
            get { return (string)listProperties.value("name", aField.FIELD_TYPE.CHAR); }
            set { listProperties.setValue("name", value); }
        }

        private manyToOne _f_partner_shipping_id = new manyToOne(); //res.partner.address
        public manyToOne partner_shipping_id
        {
            get { return _f_partner_shipping_id; }
        }

        private manyToOne _f_partner_bank_id = new manyToOne(); //res.partner.bank
        public manyToOne partner_bank_id
        {
            get { return _f_partner_bank_id; }
        }

        private manyToOne _f_intrastat_type_id = new manyToOne(); //report.intrastat.type
        public manyToOne intrastat_type_id
        {
            get { return _f_intrastat_type_id; }
        }

        private manyToOne _f_salesman_duo_id = new manyToOne(); //res.users
        public manyToOne salesman_duo_id
        {
            get { return _f_salesman_duo_id; }
        }

        public bool distribution
        {
            get { return (bool)listProperties.value("distribution", aField.FIELD_TYPE.BOOLEAN); }
            set { listProperties.setValue("distribution", value); }
        }

        public int id
        {
            get { return (int)listProperties.value("id", aField.FIELD_TYPE.INTEGER); }
            set { listProperties.setValue("id", value); }
        }
        public override string resource_name()
        {
            return "account.invoice";
        }
    }
}
