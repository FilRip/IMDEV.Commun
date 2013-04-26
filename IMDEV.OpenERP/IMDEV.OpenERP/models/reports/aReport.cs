using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IMDEV.OpenERP.models.reports
{
    public class aReport : models.@base.aFile
    {
        private bool _etat;
        private string _format;

        /// <summary>
        /// Format (extension) of the file
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public string format
        {
            get { return _format; }
            set { _format = value; }
        }

        public bool state
        {
            get { return _etat; }
            set { _etat = value; }
        }
    }
}
