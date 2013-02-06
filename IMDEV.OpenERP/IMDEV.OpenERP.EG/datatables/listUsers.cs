using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IMDEV.OpenERP.EG.models.res;

namespace IMDEV.OpenERP.EG.datatables
{
    public class listUsers
    {
        public static res_users aUser(int id, Clients.clientOpenERP clientOERP)
        {
            try
            {
                return (res_users)clientOERP.read(new IMDEV.OpenERP.models.query.aQuery(id), typeof(res_users))[0];
            }
            catch { }
            return null;
        }
    }
}
