using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IMDEV.OpenERP.models.query
{
    public class aQueryReport
    {

        private models.@base.listProperties _listeParam = new models.@base.listProperties();

        public string fileFormat
        {
            get
            {
                return (string)_listeParam.value("report_type", IMDEV.OpenERP.models.@base.aField.FIELD_TYPE.CHAR);
            }
            set
            {
                _listeParam.setValue("report_type", value);
            }
        }

        public int idReport
        {
            get
            {
                return (int)_listeParam.value("id", IMDEV.OpenERP.models.@base.aField.FIELD_TYPE.INTEGER);
            }
            set
            {
                _listeParam.setValue("id", value);
            }
        }

        public string modelName
        {
            get
            {
                return (string)_listeParam.value("model", IMDEV.OpenERP.models.@base.aField.FIELD_TYPE.CHAR);
            }
            set
            {
                _listeParam.setValue("model", value);
            }
        }

        public CookComputing.XmlRpc.XmlRpcStruct toXmlRpc()
        {
            return toXmlRpc(false);
        }
        public CookComputing.XmlRpc.XmlRpcStruct toXmlRpc(bool withId)
        {
            return _listeParam.toArray(withId);
        }
    }
}
