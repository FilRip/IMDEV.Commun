using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;

namespace IMDEV.Database.Common
{
    public class unRetourRequete : System.Data.DataSet
    {
        public int nbLignes
        {
            get
            {
                try
                {
                    return Tables[0].Rows.Count;
                }
                catch {}
                return -1;
            }
        }

        public int nbColonnes
        {
            get
            {
                try
                {
                    return Tables[0].Columns.Count;
                }
                catch {}
                return -1;
            }
        }

        public int recherche(string contenu)
        {
            return recherche(contenu,0);
        }
        public int recherche(string contenu, int startLigne)
        {
            if (((startLigne > nbLignes - 1) | (string.IsNullOrEmpty(contenu))))
                return -1;
            for (int i = startLigne; i <= nbLignes - 1; i++)
                for (int j = 0; j <= nbColonnes - 1; j++)
                    try
                    {
                        if ((Tables[0].Rows[i][j].ToString().LastIndexOf(contenu) >= 0))
                            return i;
                    }
                    catch {}
            return -1;
        }

        public DataRow firstLine()
        {
            if ((Tables.Count > 0) && (Tables[0].Rows.Count > 0)) return Tables[0].Rows[0];
            return null;
        }
    }
}
