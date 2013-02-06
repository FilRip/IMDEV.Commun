using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IMDEV.OpenERP.EG.models.mrp;

namespace IMDEV.OpenERP.EG.datatables
{
    public class listBom
    {
        public static mrp_bom aBom(int numFormule, Clients.clientOpenERP clientOERP)
        {
            return aBom(numFormule, clientOERP, null);
        }
        public static mrp_bom aBom(int numFormule, Clients.clientOpenERP clientOERP, List<string> fieldsList)
        {
            try
            {
                return (mrp_bom)clientOERP.search(new IMDEV.OpenERP.models.query.aQuery("num_formulateur", numFormule), typeof(mrp_bom), true, fieldsList)[0];
            }
            catch { }
            return null;
        }
        public static mrp_bom aBomById(int id, Clients.clientOpenERP clientOERP)
        {
            return aBomById(id, clientOERP, null);
        }
        public static mrp_bom aBomById(int id, Clients.clientOpenERP clientOERP, List<string> fieldsList)
        {
            try
            {
                return (mrp_bom)clientOERP.read(new IMDEV.OpenERP.models.query.aQuery(id), typeof(mrp_bom), fieldsList)[0];
            }
            catch { }
            return null;
        }
    }
}
