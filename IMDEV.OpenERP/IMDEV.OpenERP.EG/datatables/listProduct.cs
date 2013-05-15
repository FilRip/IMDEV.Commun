using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IMDEV.OpenERP.EG.models.product;

namespace IMDEV.OpenERP.EG.datatables
{
    public class listProduct
    {
        public static product_product aProduct(int id, Clients.clientOpenERP clientOERP)
        {
            try
            {
                return (product_product)clientOERP.read(new IMDEV.OpenERP.models.query.aQuery(id), typeof(product_product))[0];
            }
            catch { }
            return null;
        }

        public static product_product aProduct(string oldCode, Clients.clientOpenERP clientOERP, OpenERP.models.@base.listProperties context)
        {
            return aProduct(oldCode, clientOERP, null, context);
        }
        public static product_product aProduct(string oldCode, Clients.clientOpenERP clientOERP)
        {
            return aProduct(oldCode, clientOERP, null, null);
        }
        public static product_product aProduct(string oldCode, Clients.clientOpenERP clientOERP, List<string> fieldsList)
        {
            return aProduct(oldCode, clientOERP, fieldsList, null);
        }
        public static product_product aProduct(string oldCode, Clients.clientOpenERP clientOERP, List<string> fieldsList, IMDEV.OpenERP.models.@base.listProperties context)
        {
            try
            {
                return (product_product)clientOERP.search(new IMDEV.OpenERP.models.query.aQuery("old_code", oldCode), typeof(product_product), true, fieldsList, context)[0];
            }
            catch { }
            return null;
        }

        public static product_product aProductByDefaultCode(string defaultCode, Clients.clientOpenERP clientOERP)
        {
            return aProductByDefaultCode(defaultCode, clientOERP, null, null);
        }
        public static product_product aProductByDefaultCode(string defaultCode, Clients.clientOpenERP clientOERP, List<string> fieldsList)
        {
            return aProductByDefaultCode(defaultCode, clientOERP, fieldsList, null);
        }
        public static product_product aProductByDefaultCode(string defaultCode, Clients.clientOpenERP clientOERP, OpenERP.models.@base.listProperties context)
        {
            return aProductByDefaultCode(defaultCode, clientOERP, null, context);
        }
        public static product_product aProductByDefaultCode(string defaultCode, Clients.clientOpenERP clientOERP, List<string> fieldsList, OpenERP.models.@base.listProperties context)
        {
            try
            {
                return (product_product)clientOERP.search(new IMDEV.OpenERP.models.query.aQuery("default_code", defaultCode), typeof(product_product), true, fieldsList, context)[0];
            }
            catch { }
            return null;
        }
    }
}
