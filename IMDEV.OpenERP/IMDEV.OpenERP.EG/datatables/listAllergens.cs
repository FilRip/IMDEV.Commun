using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IMDEV.OpenERP.EG.models.eurogerm_profile;

namespace IMDEV.OpenERP.EG.datatables
{
    public class listAllergens
    {
        public static List<list_allergen> allAllergens(Clients.clientOpenERP clientOERP)
        {
            return allAllergens(clientOERP, null);
        }
        public static List<list_allergen> allAllergens(Clients.clientOpenERP clientOERP, OpenERP.models.@base.listProperties context)
        {
            List<object> result;
            List<list_allergen> retour;

            result = clientOERP.search(null, typeof(list_allergen), true, context);
            if ((result != null) && (result.Count > 0))
            {
                retour = new List<list_allergen>();
                foreach (list_allergen a in result)
                    retour.Add(a);
                return retour;
            }
            return null;
        }
    }
}
