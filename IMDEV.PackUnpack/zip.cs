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
        public static bool compresseFichier(string cheminSource, string cheminDestination, int tailleBuffer, bool forceReplace)
        {
            FileStream fileStreamIn=null;
            FileStream fileStreamOut = null;
            ZipOutputStream zipOutStream=null;
            try
            {
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
            finally
            {
                try { fileStreamIn.Close(); } catch {}
                try { fileStreamOut.Close(); } catch {}
                try { zipOutStream.Close(); } catch {}
                fileStreamIn = null;
                fileStreamOut = null;
                zipOutStream = null;
            }
            return false;
        }

        /// <summary>
        /// Décompresse un fichier au format ZIP (PK)
        /// </summary>
        /// <param name="cheminSource">Fichier zip à décompresser</param>
        /// <param name="cheminDestination">Fichier de sortie (fichier décompressé)</param>
        /// <param name="bufferSize">Taille du buffer mémoire à utiliser pour la décompression</param>
        /// <param name="forceReplace">Force ou non l'écrasement du fichier de sortie</param>
        /// <returns></returns>
        public static bool decompresseFichier(string cheminSource, string cheminDestination, int bufferSize,bool forceReplace)
        {
            FileStream fileStreamIn = null;
            FileStream fileStreamOut = null;
            ZipInputStream zipInStream = null;
            try
            {
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
            finally
            {
                try { fileStreamIn.Close(); } catch {}
                try { fileStreamOut.Close(); } catch {}
                try { zipInStream.Close(); } catch {}
                fileStreamIn=null;
                fileStreamOut=null;
                zipInStream=null;
            }
            return false;
        }
    }
}
