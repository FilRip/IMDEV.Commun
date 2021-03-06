﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IMDEV.OpenERP.EG.models.account;

namespace IMDEV.OpenERP.EG.datatables
{
    public class listAccountTax
    {
        public static List<account_tax> allTaxes(Clients.clientOpenERP clientOERP)
        {
            List<object> result;
            List<account_tax> retour;

            result = clientOERP.search(null, typeof(account_tax), true);
            if ((result != null) && (result.Count > 0))
            {
                retour = new List<account_tax>();
                foreach (account_tax t in result)
                    retour.Add(t);
                return retour;
            }
            return null;
        }

        public static account_tax aTax(int i, Clients.clientOpenERP clientOERP)
        {
            return aTax(i, clientOERP, null);
        }
        public static account_tax aTax(int i, Clients.clientOpenERP clientOERP, OpenERP.models.@base.listProperties context)
        {
            List<object> result;

            result = clientOERP.search(new IMDEV.OpenERP.models.query.aQuery("id",i), typeof(account_tax), true, context);
            if ((result != null) && (result.Count > 0))
            {
                return (account_tax)result[0];
            }
            return null;
        }
    }
}
