using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using SevenZip;

namespace IMDEV.PackUnpack
{
    public class lzma
    {
        /// <summary>
        /// Décompresse un fichier au format LZMA de 7zip
        /// </summary>
        /// <param name="source">Fichier à décompresser (.lzma)</param>
        /// <param name="destination">Fichier de sortie (décompressé)</param>
        /// <param name="replace">Force ou non l'écrasement du fichier destination</param>
        /// <param name="progress">Interface pour la progression (non utilisé encore)</param>
        public static void decompress(string source, string destination, bool replace, ICodeProgress progress)
        {
            if (File.Exists(destination))
            {
                if (!replace) throw new Exception("Destination filename already exist");
                File.Delete(destination);
            }

            Stream inStream = null;
            inStream = new FileStream(source.Replace(@"\", @"\\"), FileMode.Open, FileAccess.Read);

            FileStream outStream = null;
            outStream = new FileStream(destination.Replace(@"\", @"\\"), FileMode.Create, FileAccess.Write);
            
            byte[] properties = new byte[5];
            if (inStream.Read(properties, 0, 5) != 5)
                throw (new Exception("input .lzma is too short"));

            SevenZip.Compression.LZMA.Decoder decoder = new SevenZip.Compression.LZMA.Decoder();
            decoder.SetDecoderProperties(properties);
            long outSize = 0;
            for (int i = 0; i < 8; i++)
            {
                int v = inStream.ReadByte();
                if (v < 0)
                    throw (new Exception("Can't Read 1"));
                outSize |= ((long)(byte)v) << (8 * i);
            }
            long compressedSize = inStream.Length - inStream.Position;
            decoder.Code(inStream, outStream, compressedSize, outSize, progress);
            inStream.Close();
            outStream.Close();
        }

        /// <summary>
        /// Compresse un fichier au format LZMA (avec les paramètres LZMA par défaut)
        /// </summary>
        /// <param name="source">Fichier à compresser</param>
        /// <param name="destination">Fichier résultant (fichier compressé .lzma)</param>
        /// <param name="progress">Interface pour la progression (non utilisé encore)</param>
        public static void compressWithDefaultParam(string source, string destination, ICodeProgress progress)
        {
            Int32 dictionary = 1 << 21;

            Int32 posStateBits = 2;
            Int32 litContextBits = 3; // for normal files
            // UInt32 litContextBits = 0; // for 32-bit data
            Int32 litPosBits = 0;
            // UInt32 litPosBits = 2; // for 32-bit data
            Int32 algorithm = 2;
            Int32 numFastBytes = 128;
            bool eos = false;
            string mf = "bt4";
            compress(source, destination, dictionary, posStateBits, litContextBits, litPosBits, algorithm, numFastBytes, eos, mf, progress);
        }

        /// <summary>
        /// Compresse un fichier au format LZMA
        /// </summary>
        /// <param name="source">Fichier à compresser</param>
        /// <param name="destination">Fichier résultant (fichier compressé .lzma)</param>
        /// <param name="dictionary">Taille du dictionaire</param>
        /// <param name="posStateBits"></param>
        /// <param name="litContextBits"></param>
        /// <param name="litPosBits"></param>
        /// <param name="algorithm"></param>
        /// <param name="numFastBytes"></param>
        /// <param name="eos"></param>
        /// <param name="mf"></param>
        /// <param name="progress">Interface pour la progression (non utilisé encore)</param>
        public static void compress(string source, string destination, Int32 dictionary, Int32 posStateBits, Int32 litContextBits, Int32 litPosBits, Int32 algorithm, Int32 numFastBytes, bool eos, string mf, ICodeProgress progress)
        {
            Stream inStream = null;
            inStream = new FileStream(source, FileMode.Open, FileAccess.Read);

            FileStream outStream = null;
            outStream = new FileStream(destination, FileMode.Create, FileAccess.Write);

            SevenZip.CoderPropID[] propIDs = 
				{
					SevenZip.CoderPropID.DictionarySize,
					SevenZip.CoderPropID.PosStateBits,
					SevenZip.CoderPropID.LitContextBits,
					SevenZip.CoderPropID.LitPosBits,
					SevenZip.CoderPropID.Algorithm,
					SevenZip.CoderPropID.NumFastBytes,
					SevenZip.CoderPropID.MatchFinder,
					SevenZip.CoderPropID.EndMarker
				};
            object[] properties = 
				{
					(Int32)(dictionary),
					(Int32)(posStateBits),
					(Int32)(litContextBits),
					(Int32)(litPosBits),
					(Int32)(algorithm),
					(Int32)(numFastBytes),
					mf,
					eos
				};

            SevenZip.Compression.LZMA.Encoder encoder = new SevenZip.Compression.LZMA.Encoder();
            encoder.SetCoderProperties(propIDs, properties);
            encoder.WriteCoderProperties(outStream);
            Int64 fileSize;
            if (eos)
                fileSize = -1;
            else
                fileSize = inStream.Length;
            for (int i = 0; i < 8; i++)
                outStream.WriteByte((Byte)(fileSize >> (8 * i)));
            encoder.Code(inStream, outStream, -1, -1, progress);
            inStream.Close();
            outStream.Close();
        }
    }
}
