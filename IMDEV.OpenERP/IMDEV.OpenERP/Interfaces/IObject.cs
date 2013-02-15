using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CookComputing.XmlRpc;

namespace IMDEV.OpenERP.Interfaces
{
    public interface IObject:IXmlRpcProxy
    {
        [XmlRpcMethod("execute")]
        object execute(string bdd, int userId, string password, string resource, string ordre, object quoi);

        [XmlRpcMethod("execute")]
        object recherche(string bdd, int userId, string password, string resource, string ordre, object quoi, int offset, int limit);

        [XmlRpcMethod("execute")]
        object executeTwoParam(string bdd, int userId, string password, string resource, string ordre, object quoi, object toWrite);

        [XmlRpcMethod("execute")]
        object executeThreeParam(string bdd, int userId, string password, string resource, string ordre, object quoi, object toWrite, object comp);

        [XmlRpcMethod("execute")]
        object executeWithoutParam(string bdd, int userId, string password, string resource, string ordre);

        [XmlRpcMethod("execute")]
        object executeFourParam(string bdd, int userId, string password, string resource, string ordre, object quoi, object toWrite, object param1, object param2);

        [XmlRpcMethod("execute")]
        object executeFiveParam(string bdd, int userId, string password, string resource, string ordre, object quoi, object toWrite, object param1, object param2, object param3);

        /* INFO : fonctions restantes, non documentées, lu dans un fichier log des connexion d'un client GTK :
        ' request_get
        ' context_get
        ' get_sc
        ' get (action) (tree_but_open)
        ' get_filters
        ' onchange_allday
        ' onchange_dates
        ' onchange_partner_address_id
        ' get
        ' onchange_stage_id*/

    }
}
