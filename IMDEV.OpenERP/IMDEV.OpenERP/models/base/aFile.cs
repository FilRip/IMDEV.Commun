using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IMDEV.OpenERP.models.@base
{
    
    public class aFile
    {
        private string _contenu;
        
        /// <summary>
        /// The content of the file, encoded in base64
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public string contains
        {
            get { return _contenu; }
            set { _contenu = value; }
        }
        
        public byte[] decodedFileContent
        {
            get { return IMDEV.Decrypt.Base64.decodeBase64(ref _contenu); }
        }

        public void saveFile(string destination)
        {
            saveFile(destination, false);
        }

        public void saveFile(string destination, bool replace) {
            byte[] donnees;
            if (System.IO.File.Exists(destination))
            {
                if (!replace)
                    throw new System.IO.IOException(("File already exist" + ("\r\n" + "And not authorized by parameters to overrides it")));
                System.IO.File.Delete(destination);
            }
            System.IO.FileStream fs = new System.IO.FileStream(destination, System.IO.FileMode.Create, System.IO.FileAccess.Write, System.IO.FileShare.Write);
            donnees = IMDEV.Decrypt.Base64.decodeBase64(ref _contenu);
            foreach (byte octet in donnees)
                fs.WriteByte(octet);
            fs.Close();
        }
    }
}