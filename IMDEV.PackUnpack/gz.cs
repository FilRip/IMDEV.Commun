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
        public static bool compresserFichier(string cheminSource, string cheminDestination, bool forceReplace)
        {
            try
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
#pragma warning disable 0168
            catch (Exception e)
            {
#if debug
                msgbox(ex.message)
#endif
            }
#pragma warning restore 0168
            return false;
        }

        /// <summary>
        /// Décompresse un fichier gz Microsoft
        /// </summary>
        /// <param name="cheminSource">Fichier gz à décompresser</param>
        /// <param name="cheminDestination">Fichier de sortie (fichier décompressé)</param>
        /// <param name="forceReplace">Force ou non l'écrasement du fichier de sortie</param>
        /// <returns></returns>
        public static bool decompression(string cheminSource, string cheminDestination, bool forceReplace)
        {
            try
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
                byte[] buffer=new byte[tailleFichier+100];
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
#pragma warning disable 0168
            catch (Exception e)
            {
#if debug
                msgbox(ex.message)
#endif
            }
#pragma warning restore 0168
            return false;
        }
    }
}
