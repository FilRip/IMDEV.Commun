using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IMDEV.OpenERP.EG.datatables
{
    public class listState
    {
        public static List<models.res.res_country_state> allState(Clients.clientOpenERP clientOERP)
        {
            List<object> result;
            List<models.res.res_country_state> retour;

            result = clientOERP.search(null, typeof(models.res.res_country_state), true);
            if (result != null)
            {
                retour = new List<IMDEV.OpenERP.EG.models.res.res_country_state>();
                foreach (models.res.res_country_state s in result)
                    retour.Add(s);
                return retour;
            }
            return null;
        }
    }
}
