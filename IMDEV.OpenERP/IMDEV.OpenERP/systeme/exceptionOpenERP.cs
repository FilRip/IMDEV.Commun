using System;

namespace IMDEV.OpenERP.Systeme
{
    public class exceptionOpenERP : Exception
    {
        public enum ERRORS
        {
            NC,
            NOT_CONNECTED,
            ERR_NOMTYPE_OBJET_OPENERP,
            ALREADY_BUSY,
            NO_HOST,
            MANQUE_PARAM,
            TIMEOUT_REPORT,
            REPORT_WRONG_FORMAT,
            LIB_XMLRPC,
            NO_LANGUAGE,
            ERR_LOAD_TRANSLATE,
            ERR_SAVE_TRANSLATE,
            ERROR_READING_VALUES,
            ERR_READ_FIELD,
            ERR_READING_OBJECT,
            ERR_SAVE_OBJECT,
            ERR_DEL_OBJECT
        }

        private ERRORS _numError;
        private string _more = "";

        public exceptionOpenERP()
        {
        }

        public exceptionOpenERP(ERRORS numError)
        {
            _numError = numError;
        }

        public exceptionOpenERP(ERRORS numError, string more)
        {
            _numError = numError;
            _more = more;
        }

        public override string Message
        {
            get
            {
                if (_numError != ERRORS.NC)
                {
                    return (IMDEV.OpenERP.Properties.Resources.ResourceManager.GetString(_numError.ToString(), System.Threading.Thread.CurrentThread.CurrentCulture) + ((_more != "") ? ("\r\n" + _more) : ""));
                }
                else
                {
                    return base.Message;
                }
            }
        }
    }
}
