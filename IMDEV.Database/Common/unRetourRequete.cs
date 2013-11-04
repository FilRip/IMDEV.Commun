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

        /// <summary>
        /// Search the first occurence of a string in all lines & columns
        /// </summary>
        /// <param name="contenu">String to search</param>
        /// <returns>Number of line where we found String</returns>
        public int recherche(string contenu)
        {
            return recherche(contenu,0, -1);
        }

        /// <summary>
        /// Search the first occurence of a string in all columns
        /// </summary>
        /// <param name="contenu">String to search</param>
        /// <param name="startLigne">Number of line where to start search</param>
        /// <returns>Number of line where we found String</returns>
        public int recherche(string contenu, int startLigne)
        {
            return recherche(contenu, startLigne, -1);
        }

        /// <summary>
        /// Search the first occurence of a string
        /// </summary>
        /// <param name="contenu">String to search</param>
        /// <param name="startLigne">Number of line where to start search</param>
        /// <param name="numColonne">Number of column where search String</param>
        /// <returns>Number of line where we found String</returns>
        public int recherche(string contenu, int startLigne, int numColonne)
        {
            if ((startLigne > nbLignes - 1) || (string.IsNullOrEmpty(contenu)) || (Tables.Count==0) || (Tables[0].Rows.Count==0))
                return -1;
            for (int i = startLigne; i <= nbLignes - 1; i++)
                if (numColonne >= 0)
                {
                    if (valeurContient(contenu, i,numColonne))
                        return i;
                }
                else
                    for (int j = 0; j <= nbColonnes - 1; j++)
                        try
                        {
                            if (valeurContient(contenu, i, j))
                                return i;
                        }
                        catch { }
            return -1;
        }
        public bool valeurContient(string texte, int numLigne, int numColonne)
        {
            try
            {
                return Tables[0].Rows[numLigne][numColonne].ToString().LastIndexOf(texte) >= 0;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Search one string value in all lignes and all columns
        /// </summary>
        /// <param name="contenu">String to research</param>
        /// <returns>List of integer corresponding to line number where string has been finded</returns>
        public List<int> rechercheTout(string contenu)
        {
            List<int> retour = null;
            int curNumLigne = 0;
            bool trouve = true;
            int ret;

            while (trouve)
            {
                trouve = false;
                ret = recherche(contenu, curNumLigne);
                if (ret >= 0)
                {
                    trouve = true;
                    if (retour == null) retour = new List<int>();
                    retour.Add(curNumLigne);
                    curNumLigne = ret + 1;
                }
            }
            return retour;
        }

        /// <summary>
        /// Return the first line of the result if exist
        /// </summary>
        /// <returns></returns>
        public DataRow firstLine()
        {
            if ((Tables.Count > 0) && (Tables[0].Rows.Count > 0)) return Tables[0].Rows[0];
            return null;
        }

        public List<string> nomColonnes()
        {
            List<string> retour = null;
            if (Tables.Count > 0)
            {
                retour = new List<string>();
                foreach (DataColumn dc in Tables[0].Columns)
                    retour.Add(dc.ColumnName);
            }
            return retour;
        }

        /// <summary>
        /// Calculate the sum of one column
        /// </summary>
        /// <param name="nomColonne">Number of column</param>
        /// <returns>the sum</returns>
        public double totalColonne(int numColonne)
        {
            if ((Tables.Count > 0) && (Tables[0].Columns.Count>0)) return totalColonne(Tables[0].Columns[numColonne].ColumnName);
            return 0;
        }

        /// <summary>
        /// Calculate the sum of one column
        /// </summary>
        /// <param name="nomColonne">Name of column</param>
        /// <returns>the sum</returns>
        public double totalColonne(string nomColonne)
        {
            double retour=0;
             
            if (Tables.Count > 0)
            {
                if (Tables[0].Rows.Count>0)
                    foreach (DataRow line in Tables[0].Rows)
                        try
                        {
                            retour += double.Parse(line[nomColonne].ToString());
                        }
                        catch { }
            }

            return retour;
        }
    }
}
