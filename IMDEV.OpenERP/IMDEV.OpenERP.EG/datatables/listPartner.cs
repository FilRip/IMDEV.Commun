using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IMDEV.OpenERP.EG.models.res;

namespace IMDEV.OpenERP.EG.datatables
{
    public class listPartner
    {
        public static res_partner aPartner(int id, Clients.clientOpenERP clientOERP)
        {
            return aPartner(id, clientOERP, null);
        }
        public static res_partner aPartner(int id, Clients.clientOpenERP clientOERP, List<string> fieldsList)
        {
            try
            {
                return (res_partner)clientOERP.read(new IMDEV.OpenERP.models.query.aQuery(id), typeof(res_partner), fieldsList)[0];
            }
            catch { }
            return null;
        }

        public static res_partner aCustomer(string oldCode, Clients.clientOpenERP clientOERP)
        {
            try
            {
                IMDEV.OpenERP.models.query.aQuery query = new IMDEV.OpenERP.models.query.aQuery();
                query.addEqualTo("customer", true);
                query.addAND();
                query.addEqualTo("old_code", oldCode);
                return (res_partner)clientOERP.search(query, typeof(res_partner),true)[0];
            }
            catch { }
            return null;
        }

        public static res_partner aSupplier(string oldCode, Clients.clientOpenERP clientOERP)
        {
            try
            {
                IMDEV.OpenERP.models.query.aQuery query = new IMDEV.OpenERP.models.query.aQuery();
                query.addEqualTo("supplier", true);
                query.addAND();
                query.addEqualTo("old_code", oldCode);
                return (res_partner)clientOERP.search(query, typeof(res_partner), true)[0];
            }
            catch { }
            return null;
        }

        public static List<res_partner> allSuppliers(Clients.clientOpenERP clientOERP)
        {
            return allSuppliers(clientOERP, null);
        }
        public static List<res_partner> allSuppliers(Clients.clientOpenERP clientOERP, List<string> fieldsList)
        {
            List<object> lo;
            List<res_partner> retour = null;
            lo = clientOERP.search(new IMDEV.OpenERP.models.query.aQuery("active", true), typeof(res_partner), true, fieldsList);
            if (lo != null)
            {
                retour = new List<res_partner>();
                foreach (res_partner obj in lo)
                    retour.Add(obj);
            }
            return retour;
        }
    }
}
