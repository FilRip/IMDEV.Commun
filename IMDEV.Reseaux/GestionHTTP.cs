using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Net;
using System.IO;

namespace IMDEV.Reseaux
{
    public class GestionHTTP
    {

        public string retourneContenu(string adresse)
        {
            string retour = "";
            try
            {
                HttpWebRequest oWRequest = (HttpWebRequest)WebRequest.Create(adresse);
                HttpWebResponse oWResponse = (HttpWebResponse)oWRequest.GetResponse();
                Stream oS = oWResponse.GetResponseStream();
                StreamReader oSReader = new StreamReader(oS, System.Text.Encoding.ASCII);
                retour = oSReader.ReadToEnd();
                oSReader.Close();
                oS.Close();
            }
            catch { }
            return retour;
        }

        public bool envoiContenu(string adresse)
        {
            string retour = "";
            try
            {
                HttpWebRequest oWRequest = (HttpWebRequest)WebRequest.Create(adresse);
                HttpWebResponse oWResponse = (HttpWebResponse)oWRequest.GetResponse();
                Stream oS = oWResponse.GetResponseStream();
                StreamReader oSReader = new StreamReader(oS, System.Text.Encoding.ASCII);
                retour = oSReader.ReadToEnd();
                oSReader.Close();
                oS.Close();
                return true;
            }
            catch { }
            return false;
        }

    }
}
