using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IMDEV.OpenERP.EG.models.mrp;

namespace IMDEV.OpenERP.EG.datatables
{
    public class listBom
    {
        public static IMDEV.OpenERP.EG.models.mrp.mrp_bom bomOfProduct(int numProduct, Clients.clientOpenERP clientOERP)
        {
            try
            {
                models.product.product_product prodERP;
                models.mrp.mrp_bom mrpBom;
                prodERP=datatables.listProduct.aProduct(numProduct, clientOERP);
                if ((prodERP != null) && (prodERP.bom_ids.getValue != null))
                {
                    foreach (int bomId in prodERP.bom_ids.getValue)
                    {
                        mrpBom = aBomById(bomId,clientOERP);
                        if ((mrpBom!=null) && (mrpBom.active) && (mrpBom.special_bom_type== mrp_bom.ENUM_SPECIAL_BOM_TYPE.normal))
                            return mrpBom;
                    }
                }
            }
            catch { }
            return null;
        }
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
