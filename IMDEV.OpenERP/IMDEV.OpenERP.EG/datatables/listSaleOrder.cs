using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IMDEV.OpenERP.EG.datatables
{
    public class listSaleOrder
    {
        public static models.sale.sale_order returnSaleOrder(int id, Clients.clientOpenERP cliERP, List<string> listFields)
        {
            List<object> retour;
            retour = cliERP.read(new IMDEV.OpenERP.models.query.aQuery(id), typeof(models.sale.sale_order), listFields);
            if ((retour != null) && (retour.Count == 1)) return (models.sale.sale_order)retour[0];
            return null;
        }
    }
}
