using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CookComputing.XmlRpc;

namespace IMDEV.OpenERP.Interfaces
{
    public interface Ireport:IXmlRpcProxy
    {
        [XmlRpcMethod("report")]
        object report(string db, int userId, string password, string resource, Array id, XmlRpcStruct model);

        [XmlRpcMethod("report_get")]
        object getReport(string db, int userId, string password, int idReport);
    }
}
