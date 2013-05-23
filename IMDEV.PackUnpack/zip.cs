using System;
using System.Collections.Generic;
using System.Text;
using ICSharpCode.SharpZipLib.Zip;
using System.IO;

namespace IMDEV.PackUnpack
{
    public class zip
    {
        /// <summary>
        /// Compresse un fichier au format ZIP (PK)
        /// </summary>
        /// <param name="cheminSource">Fichier source à compresser</param>
        /// <param name="cheminDestination">Fichier destination (zip)</param>
        /// <param name="tailleBuffer">Taille du buffer mémoire utilisé pour la compression</param>
        /// <param name="forceReplace">Force ou non l'écrasement du fichier destination</param>
        /// <returns></returns>
        public static void compresseFichierAsync(string cheminSource, string cheminDestination, int tailleBuffer, bool forceReplace, System.ComponentModel.RunWorkerCompletedEventHandler callBack)
        {
            System.ComponentModel.BackgroundWorker bg = new System.ComponentModel.BackgroundWorker();
            System.Collections.Hashtable param = new System.Collections.Hashtable();

            param.Add("cheminSource", cheminSource);
            param.Add("cheminDestination", cheminDestination);
            param.Add("tailleBuffer", tailleBuffer);
            param.Add("forceReplace", forceReplace);

            bg.DoWork += new System.ComponentModel.DoWorkEventHandler(bgCompress_DoWork);
            bg.RunWorkerCompleted += callBack;
            bg.RunWorkerAsync(param);
        }

        private static void bgCompress_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            string cheminSource, cheminDestination;
            int tailleBuffer;
            bool forceReplace;

            cheminSource = (string)(((System.Collections.Hashtable)(e.Argument))["cheminSource"]);
            cheminDestination = (string)(((System.Collections.Hashtable)(e.Argument))["cheminDestination"]);
            forceReplace = (bool)(((System.Collections.Hashtable)(e.Argument))["forceReplace"]);
            tailleBuffer = int.Parse(((System.Collections.Hashtable)(e.Argument))["tailleBuffer"].ToString());

            e.Result = compresseFichierData(cheminSource, cheminDestination, tailleBuffer, forceReplace);
        }
        public static bool compresseFichier(string cheminSource, string cheminDestination, int tailleBuffer, bool forceReplace)
        {
            return compresseFichierData(cheminSource, cheminDestination, tailleBuffer, forceReplace);
        }
        private static bool compresseFichierData(string cheminSource, string cheminDestination, int tailleBuffer, bool forceReplace)
        {
            FileStream fileStreamIn = null;
            FileStream fileStreamOut = null;
            ZipOutputStream zipOutStream = null;

            if (File.Exists(cheminDestination))
                if (forceReplace) File.Delete(cheminDestination); else return false;
            int size;
            byte[] buffer = new byte[tailleBuffer];
            ZipEntry entry = new ZipEntry(Path.GetFileName(cheminSource));
            zipOutStream.SetLevel(9);
            zipOutStream.PutNextEntry(entry);
            do
            {
                size = fileStreamIn.Read(buffer, 0, buffer.Length);
                zipOutStream.Write(buffer, 0, size);
            } while (size > 0);
            try { fileStreamIn.Close(); }
            catch { }
            try { fileStreamOut.Close(); }
            catch { }
            try { zipOutStream.Close(); }
            catch { }
            fileStreamIn = null;
            fileStreamOut = null;
            zipOutStream = null;
            return true;
        }

        /// <summary>
        /// Décompresse un fichier au format ZIP (PK)
        /// </summary>
        /// <param name="cheminSource">Fichier zip à décompresser</param>
        /// <param name="cheminDestination">Fichier de sortie (fichier décompressé)</param>
        /// <param name="bufferSize">Taille du buffer mémoire à utiliser pour la décompression</param>
        /// <param name="forceReplace">Force ou non l'écrasement du fichier de sortie</param>
        /// <returns></returns>
        public static void decompresseFichierAsync(string cheminSource, string cheminDestination, int bufferSize, bool forceReplace, System.ComponentModel.RunWorkerCompletedEventHandler callBack)
        {
            System.ComponentModel.BackgroundWorker bg = new System.ComponentModel.BackgroundWorker();
            System.Collections.Hashtable param = new System.Collections.Hashtable();

            param.Add("cheminSource", cheminSource);
            param.Add("cheminDestination", cheminDestination);
            param.Add("forceReplace", forceReplace);
            param.Add("bufferSize", bufferSize);

            bg.DoWork += new System.ComponentModel.DoWorkEventHandler(bgDecompress_DoWork);
            bg.RunWorkerCompleted += callBack;
            bg.RunWorkerAsync(param);
        }

        static void bgDecompress_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            string cheminSource, cheminDestination;
            bool forceReplace;
            int bufferSize;

            cheminSource = (string)(((System.Collections.Hashtable)(e.Argument))["cheminSource"]);
            cheminDestination = (string)(((System.Collections.Hashtable)(e.Argument))["cheminDestination"]);
            forceReplace = (bool)(((System.Collections.Hashtable)(e.Argument))["forceReplace"]);
            bufferSize = int.Parse(((System.Collections.Hashtable)(e.Argument))["bufferSize"].ToString());

            e.Result = decompresseFichierData(cheminSource, cheminDestination, bufferSize, forceReplace);
        }
        public static bool decompresseFichier(string cheminSource, string cheminDestination, int bufferSize, bool forceReplace)
        {
            return decompresseFichierData(cheminSource, cheminDestination, bufferSize, forceReplace);
        }
        private static bool decompresseFichierData(string cheminSource, string cheminDestination, int bufferSize, bool forceReplace)
        {
            FileStream fileStreamIn = null;
            FileStream fileStreamOut = null;
            ZipInputStream zipInStream = null;

            ZipEntry entry;
            int size;
            fileStreamIn = new FileStream(cheminSource, FileMode.Open, FileAccess.Read);
            zipInStream = new ZipInputStream(fileStreamIn);
            entry = zipInStream.GetNextEntry();
            fileStreamOut = new FileStream(cheminDestination + "\\" + entry.Name, FileMode.Create, FileAccess.Write);
            byte[] buffer = new byte[bufferSize];
            do
            {
                size = zipInStream.Read(buffer, 0, buffer.Length);
                fileStreamOut.Write(buffer, 0, size);
            } while (size > 0);
            try { fileStreamIn.Close(); }
            catch { }
            try { fileStreamOut.Close(); }
            catch { }
            try { zipInStream.Close(); }
            catch { }
            fileStreamIn = null;
            fileStreamOut = null;
            zipInStream = null;
            return true;
        }
    }
}
