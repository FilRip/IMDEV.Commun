using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IMDEV.GestString
{
    public class traitement
    {
        public static List<string> returnParams(string text, char separator)
        {
            return returnParams(text, separator, '"');
        }

        public static List<string> returnParams(string text, char separator, char textSeparator)
        {
            List<string> ret = new List<string>();
            string currentString = "";
            string curApos = "";

            while (text.LastIndexOf(separator.ToString() + separator.ToString())>=0)
                text = text.Replace(separator.ToString() + separator.ToString(), separator.ToString());
            foreach (char t in text)
            {
                if (t == textSeparator)
                    if (curApos == "")
                        curApos = textSeparator.ToString();
                    else if (curApos == textSeparator.ToString())
                        curApos = "";
                if ((t == separator) && (curApos == ""))
                {
                    ret.Add(currentString);
                    currentString = "";
                }
                else
                    currentString = currentString.Replace(textSeparator.ToString(),"") + t;
            }

            if (currentString != "") ret.Add(currentString);
            return ret;
        }

        public static int numberOfString(string text, string toSearch)
        {
            int i=0;
            int start=0;
            int lastFound;

            if ((text != null) && (text != ""))
                while (true)
                {
                    if (start >= text.Length) break;
                    lastFound = text.IndexOf(toSearch, start);
                    if (lastFound >= 0)
                    {
                        start = lastFound + 1;
                        i++;
                    }
                    else
                        break;
                }
            return i;
        }

        public static string returnParam(string text, char separator, string param)
        {
            List<string> ret;
            bool returnNext = false;

            ret = returnParams(text, separator);
            if (ret!=null)
                foreach (string t in ret)
                {
                    if (returnNext) return t;
                    if (t.Trim().ToLower().StartsWith(param.Trim().ToLower()))
                    {
                        if (t.Trim().Length > param.Trim().Length)
                            return t.Substring(param.Trim().Length);
                        else
                            returnNext = true;
                    }
                }
            return null;
        }
    }
}
