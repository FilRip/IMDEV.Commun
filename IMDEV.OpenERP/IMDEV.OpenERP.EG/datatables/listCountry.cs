using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IMDEV.OpenERP.EG.datatables
{
    public class listCountry
    {
        public static List<models.res.res_country> allCountry(Clients.clientOpenERP clientOERP)
        {
            List<object> result;
            List<models.res.res_country> retour;

            result = clientOERP.search(null, typeof(models.res.res_country), true);
            if (result != null)
            {
                retour = new List<IMDEV.OpenERP.EG.models.res.res_country>();
                foreach (models.res.res_country obj in result)
                    retour.Add(obj);
                return retour;
            }
            return null;
        }
    }
}
