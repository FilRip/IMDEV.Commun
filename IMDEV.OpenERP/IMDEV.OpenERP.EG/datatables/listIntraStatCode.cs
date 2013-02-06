using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IMDEV.OpenERP.EG.models.bookstore;

namespace IMDEV.OpenERP.EG.datatables
{
    public class listIntraStatCode
    {
        public static report_intrastat_code anIntraStatCode(int id, Clients.clientOpenERP clientOERP)
        {
            try
            {
                return (report_intrastat_code)clientOERP.read(new IMDEV.OpenERP.models.query.aQuery(id), typeof(report_intrastat_code))[0];
            }
            catch { }
            return null;
        }
    }
}
