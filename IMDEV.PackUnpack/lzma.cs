using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using SevenZip;

namespace IMDEV.PackUnpack
{
    public class lzma
    {
        private const Int32 DEFAULT_DICTIONARY = 1 << 21;
        private const Int32 DEFAULT_POSSTATEBITS = 2;
        private const Int32 DEFAULT_LITCONTEXTBITS = 3; // for normal files // 0 for 32-bit data
        private const Int32 DEFAULT_LITPOSBITS = 0; // 2 for 32-bit data
        private const Int32 DEFAULT_ALGORITHM = 2;
        private const Int32 DEFAULT_NUMFASTBYTES = 128;
        private const bool DEFAULT_EOS = false;
        private const string DEFAULT_MF = "bt4";

        /// <summary>
        /// Décompresse un fichier au format LZMA de 7zip
        /// </summary>
        /// <param name="source">Fichier à décompresser (.lzma)</param>
        /// <param name="destination">Fichier de sortie (décompressé)</param>
        /// <param name="replace">Force ou non l'écrasement du fichier destination</param>
        /// <param name="progress">Interface pour la progression (non utilisé encore)</param>
        public static void decompressAsync(string source, string destination, bool replace, System.ComponentModel.RunWorkerCompletedEventHandler callBack, ICodeProgress progress)
        {
            System.ComponentModel.BackgroundWorker bg = new System.ComponentModel.BackgroundWorker();
            System.Collections.Hashtable param = new System.Collections.Hashtable();

            param.Add("source", source);
            param.Add("destination", destination);
            param.Add("replace", replace);
            param.Add("progress", progress);

            bg.DoWork += new System.ComponentModel.DoWorkEventHandler(bgDecompress_DoWork);
            bg.RunWorkerCompleted += callBack;
            bg.RunWorkerAsync(param);
        }

        private static void bgDecompress_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            string source, destination;
            bool replace;
            ICodeProgress progress;

            source = (string)(((System.Collections.Hashtable)(e.Argument))["source"]);
            destination = (string)(((System.Collections.Hashtable)(e.Argument))["destination"]);
            replace = (bool)(((System.Collections.Hashtable)(e.Argument))["replace"]);
            progress = (ICodeProgress)(((System.Collections.Hashtable)(e.Argument))["progress"]);

            try
            {
                decompressData(source, destination, replace, progress);
                e.Result = true;
            }
            catch
            {
                e.Result = false;
            }
        }
        public static void decompress(string source, string destination, bool replace, ICodeProgress progress)
        {
            decompressData(source, destination, replace, progress);
        }

        private static void decompressData(string source, string destination, bool replace, ICodeProgress progress)
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
        public static void compressWithDefaultParamAsync(string source, string destination, ICodeProgress progress, System.ComponentModel.RunWorkerCompletedEventHandler callBack)
        {
            compressAsync(source, destination, DEFAULT_DICTIONARY, DEFAULT_POSSTATEBITS, DEFAULT_LITCONTEXTBITS, DEFAULT_LITPOSBITS, DEFAULT_ALGORITHM, DEFAULT_NUMFASTBYTES, DEFAULT_EOS, DEFAULT_MF, progress, callBack);
        }
        public static void compressWithDefaultParam(string source, string destination, ICodeProgress progress)
        {
            compressData(source, destination, DEFAULT_DICTIONARY, DEFAULT_POSSTATEBITS, DEFAULT_LITCONTEXTBITS, DEFAULT_LITPOSBITS, DEFAULT_ALGORITHM, DEFAULT_NUMFASTBYTES, DEFAULT_EOS, DEFAULT_MF, progress);
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
        public static void compressAsync(string source, string destination, Int32 dictionary, Int32 posStateBits, Int32 litContextBits, Int32 litPosBits, Int32 algorithm, Int32 numFastBytes, bool eos, string mf, ICodeProgress progress, System.ComponentModel.RunWorkerCompletedEventHandler callBack)
        {
            System.ComponentModel.BackgroundWorker bg = new System.ComponentModel.BackgroundWorker();
            System.Collections.Hashtable param = new System.Collections.Hashtable();

            param.Add("source", source);
            param.Add("destinations", destination);
            param.Add("dictionary", dictionary);
            param.Add("posStateBits", posStateBits);
            param.Add("litContextBits", litContextBits);
            param.Add("litPosBits", litPosBits);
            param.Add("algorithm", algorithm);
            param.Add("numFastBytes", numFastBytes);
            param.Add("eos", eos);
            param.Add("mf", mf);
            param.Add("progress", progress);

            bg.DoWork += new System.ComponentModel.DoWorkEventHandler(bgCompress_DoWork);
            bg.RunWorkerCompleted += callBack;
            bg.RunWorkerAsync(param);
        }

        private static void bgCompress_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            string source, destination, mf;
            Int32 dictionary, posStateBits, litContextBits, litPosBits, algorithm, numFastBytes;
            bool eos;
            ICodeProgress progress;

            source = (string)(((System.Collections.Hashtable)(e.Argument))["source"]);
            destination = (string)(((System.Collections.Hashtable)(e.Argument))["destination"]);
            dictionary = Int32.Parse(((System.Collections.Hashtable)(e.Argument))["dictionary"].ToString());
            posStateBits = Int32.Parse(((System.Collections.Hashtable)(e.Argument))["posStateBits"].ToString());
            litContextBits = Int32.Parse(((System.Collections.Hashtable)(e.Argument))["litContextBits"].ToString());
            litPosBits = Int32.Parse(((System.Collections.Hashtable)(e.Argument))["litPosBits"].ToString());
            algorithm = Int32.Parse(((System.Collections.Hashtable)(e.Argument))["algorithm"].ToString());
            numFastBytes = Int32.Parse(((System.Collections.Hashtable)(e.Argument))["numFastBytes"].ToString());
            mf = (string)(((System.Collections.Hashtable)(e.Argument))["mf"]);
            eos = (bool)(((System.Collections.Hashtable)(e.Argument))["eos"]);
            progress = (ICodeProgress)(((System.Collections.Hashtable)(e.Argument))["progress"]);

            try
            {
                compressData(source, destination, dictionary, posStateBits, litContextBits, litPosBits, algorithm, numFastBytes, eos, mf, progress);
                e.Result = true;
            }
            catch
            {
                e.Result = false;
            }
        }
        public static void compress(string source, string destination, Int32 dictionary, Int32 posStateBits, Int32 litContextBits, Int32 litPosBits, Int32 algorithm, Int32 numFastBytes, bool eos, string mf, ICodeProgress progress)
        {
            compressData(source, destination, dictionary, posStateBits, litContextBits, litPosBits, algorithm, numFastBytes, eos, mf, progress);
        }
        private static void compressData(string source, string destination, Int32 dictionary, Int32 posStateBits, Int32 litContextBits, Int32 litPosBits, Int32 algorithm, Int32 numFastBytes, bool eos, string mf, ICodeProgress progress)
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
