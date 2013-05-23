using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.IO.Compression;

namespace IMDEV.PackUnpack
{
    public class gz
    {
        /// <summary>
        /// Compresser un fichier en gz Microsoft
        /// </summary>
        /// <param name="cheminSource">Fichier à compresser</param>
        /// <param name="cheminDestination">Fichier résultant (gz)</param>
        /// <param name="forceReplace">Force ou non l'écrasement du fichier de sortie</param>
        /// <returns></returns>
        public static void compresserFichierAsync(string cheminSource, string cheminDestination, bool forceReplace, System.ComponentModel.RunWorkerCompletedEventHandler callBack)
        {
            System.ComponentModel.BackgroundWorker bg = new System.ComponentModel.BackgroundWorker();
            System.Collections.Hashtable param = new System.Collections.Hashtable();

            param.Add("cheminSource", cheminSource);
            param.Add("cheminDestination", cheminDestination);
            param.Add("forceReplace", forceReplace);

            bg.DoWork+=new System.ComponentModel.DoWorkEventHandler(bgCompress_DoWork);
            bg.RunWorkerCompleted += callBack;
            bg.RunWorkerAsync(param);
        }

        private static void bgCompress_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            string cheminSource, cheminDestination;
            bool forceReplace;

            cheminSource = (string)(((System.Collections.Hashtable)(e.Argument))["cheminSource"]);
            cheminDestination = (string)(((System.Collections.Hashtable)(e.Argument))["cheminDestination"]);
            forceReplace = (bool)(((System.Collections.Hashtable)(e.Argument))["forceReplace"]);

            e.Result = compresserFichierData(cheminSource, cheminDestination, forceReplace);
        }

        public static bool compresserFichier(string cheminSource, string cheminDestination, bool forceReplace)
        {
            return compresserFichierData(cheminSource, cheminDestination, forceReplace);
        }
        private static bool compresserFichierData(string cheminSource, string cheminDestination, bool forceReplace)
        {
            if (File.Exists(cheminDestination))
                if (forceReplace) File.Delete(cheminDestination); else return false;
            FileStream monFileStream = new FileStream(cheminSource, FileMode.Open);
            byte[] monBuffer = new byte[monFileStream.Length];
            monFileStream.Read(monBuffer, 0, (int)monFileStream.Length);
            monFileStream.Close();
            monFileStream = new FileStream(cheminDestination, FileMode.Create);
            GZipStream monGZipStream = new GZipStream(monFileStream, CompressionMode.Compress, false);
            monGZipStream.Write(monBuffer, 0, monBuffer.Length);
            monGZipStream.Close();
            return true;
        }

        /// <summary>
        /// Décompresse un fichier gz Microsoft
        /// </summary>
        /// <param name="cheminSource">Fichier gz à décompresser</param>
        /// <param name="cheminDestination">Fichier de sortie (fichier décompressé)</param>
        /// <param name="forceReplace">Force ou non l'écrasement du fichier de sortie</param>
        /// <returns></returns>
        public static void decompressionAsync(string cheminSource, string cheminDestination, bool forceReplace, System.ComponentModel.RunWorkerCompletedEventHandler callBack)
        {
            System.ComponentModel.BackgroundWorker bg=new System.ComponentModel.BackgroundWorker();
            System.Collections.Hashtable param=new System.Collections.Hashtable();

            param.Add("cheminSource", cheminSource);
            param.Add("cheminDestination", cheminDestination);
            param.Add("forceReplace", forceReplace);

            bg.DoWork+=new System.ComponentModel.DoWorkEventHandler(bg_DoWork);
            bg.RunWorkerCompleted+=callBack;

            bg.RunWorkerAsync(param);
        }

        private static void  bg_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            string cheminSource, cheminDestination;
            bool forceReplace;

            cheminSource = (string)(((System.Collections.Hashtable)(e.Argument))["cheminSource"]);
            cheminDestination = (string)(((System.Collections.Hashtable)(e.Argument))["cheminDestination"]);
            forceReplace = (bool)(((System.Collections.Hashtable)(e.Argument))["forceReplace"]);

            e.Result = decompressionData(cheminSource, cheminDestination, forceReplace);
        }

        public static bool decompression(string cheminSource, string cheminDestination, bool forceReplace)
        {
            return decompressionData(cheminSource, cheminDestination, forceReplace);
        }
        private static bool decompressionData(string cheminSource, string cheminDestination, bool forceReplace)
        {
            if (File.Exists(cheminDestination))
                if (forceReplace) File.Delete(cheminDestination); else return false;
            FileStream monFileStream = new FileStream(cheminSource, FileMode.Open);
            GZipStream monGZipStream = new GZipStream(monFileStream, CompressionMode.Decompress);
            byte[] tailleOctets = new byte[3];
            int position = (int)monFileStream.Length - 4;
            monFileStream.Position = position;
            monFileStream.Read(tailleOctets, 0, 4);
            monFileStream.Position = 0;
            int tailleFichier = BitConverter.ToInt32(tailleOctets, 0);
            byte[] buffer = new byte[tailleFichier + 100];
            int monOffset = 0;
            while (true)
            {
                int decompressionOctets = monGZipStream.Read(buffer, monOffset, 100);
                if (decompressionOctets == 0) break;
                monOffset += decompressionOctets;
            }
            monFileStream = new FileStream(cheminDestination, FileMode.Create);
            monFileStream.Write(buffer, 0, tailleFichier - 1);
            monFileStream.Flush();
            monFileStream.Close();
            monGZipStream.Close();
            return true;
        }
    }
}
