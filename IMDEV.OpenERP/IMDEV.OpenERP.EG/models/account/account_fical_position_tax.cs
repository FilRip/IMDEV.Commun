﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IMDEV.OpenERP.models.@base;
using IMDEV.OpenERP.models.fields.relations;

namespace IMDEV.OpenERP.EG.models.account
{
    public class account_fiscal_position_tax : anOpenERPObject
    {
        private manyToOne _f_position_id = new manyToOne(); //account.fiscal.position
        public manyToOne position_id
        {
            get { return _f_position_id; }
        }

        private manyToOne _f_tax_dest_id = new manyToOne(); //account.tax
        public manyToOne tax_dest_id
        {
            get { return _f_tax_dest_id; }
        }

        private manyToOne _f_tax_src_id = new manyToOne(); //account.tax
        public manyToOne tax_src_id
        {
            get { return _f_tax_src_id; }
        }

        public int id
        {
            get { return (int)listProperties.value("id", aField.FIELD_TYPE.INTEGER); }
            set { listProperties.setValue("id", value); }
        }
        public override string resource_name()
        {
            return "account.fiscal.position.tax";
        }
    }
}
