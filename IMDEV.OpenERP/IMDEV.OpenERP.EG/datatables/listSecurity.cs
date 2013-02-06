using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IMDEV.OpenERP.EG.datatables
{
    public class listSecurity
    {
        public static models.product.product_security aSecurity(string name, Clients.clientOpenERP clientOERP)
        {
            List<object> retour;
            retour = clientOERP.search(new IMDEV.OpenERP.models.query.aQuery("name", name), typeof(models.product.product_security), true);
            if ((retour != null) && (retour.Count == 1)) return (models.product.product_security)retour[0];
            return null;
        }

        public static List<models.product.product_security> allSecurity(Clients.clientOpenERP clientOERP)
        {
            List<object> result;
            List<models.product.product_security> retour;

            result = clientOERP.search(null, typeof(models.product.product_security), true);
            if ((result != null) && (result.Count > 0))
            {
                retour = new List<IMDEV.OpenERP.EG.models.product.product_security>();
                foreach (models.product.product_security ps in result)
                    retour.Add(ps);
                return retour;
            }
            return null;
        }
    }
}
