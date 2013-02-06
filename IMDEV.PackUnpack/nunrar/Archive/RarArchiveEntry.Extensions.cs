using System.IO;
using NUnrar.Common;
using NUnrar.Headers;

namespace NUnrar.Archive
{

    public static class RarArchiveEntryExtensions
    {
        public static void WriteToDirectory(RarArchiveEntry entry, string destinationDirectory,
            IRarExtractionListener listener)
        {
            WriteToDirectory(entry,destinationDirectory,listener,ExtractOptions.Overwrite);
        }
        /// <summary>
        /// Extract to specific directory, retaining filename
        /// </summary>
        public static void WriteToDirectory(RarArchiveEntry entry, string destinationDirectory,
            IRarExtractionListener listener,
            ExtractOptions options)
        {
            string destinationFileName = string.Empty;
            string file = Path.GetFileName(entry.FilePath);


            if (FlagUtility.HasFlag(options,ExtractOptions.ExtractFullPath))
            {

                string folder = Path.GetDirectoryName(entry.FilePath);
                string destdir = Path.Combine(destinationDirectory, folder);
                if (!Directory.Exists(destdir))
                {
                    Directory.CreateDirectory(destdir);
                }
                destinationFileName = Path.Combine(destdir, file);
            }
            else
            {
                destinationFileName = Path.Combine(destinationDirectory, file);
            }

            entry.WriteToFile(destinationFileName, listener, options);
        }

        public static void WriteToDirectory(RarArchiveEntry entry, string destinationPath)
        {
            WriteToDirectory(entry,destinationPath,ExtractOptions.Overwrite);
        }
        /// <summary>
        /// Extract to specific directory, retaining filename
        /// </summary>
        public static void WriteToDirectory(RarArchiveEntry entry, string destinationPath,
            ExtractOptions options)
        {
            entry.WriteToDirectory(destinationPath, new NullRarExtractionListener(), options);
        }

        public static void WriteToFile(RarArchiveEntry entry, string destinationFileName,
                        IRarExtractionListener listener)
        {
            WriteToFile(entry,destinationFileName,listener,ExtractOptions.Overwrite);
        }
        /// <summary>
        /// Extract to specific file
        /// </summary>
        public static void WriteToFile(RarArchiveEntry entry, string destinationFileName,
                        IRarExtractionListener listener,
            ExtractOptions options)
        {
            FileMode fm = FileMode.Create;

            if (!options.HasFlag(ExtractOptions.Overwrite))
            {
                fm = FileMode.CreateNew;
            }
            using (FileStream fs = File.Open(destinationFileName, fm))
            {
                entry.WriteTo(fs, listener);
            }
        }

        public static void WriteToFile(RarArchiveEntry entry, string destinationFileName)
        {
            WriteToFile(entry, destinationFileName, ExtractOptions.Overwrite);
        }
        /// <summary>
        /// Extract to specific file
        /// </summary>
        public static void WriteToFile(RarArchiveEntry entry, string destinationFileName,
           ExtractOptions options)
        {
            entry.WriteToFile(destinationFileName, new NullRarExtractionListener(), options);
        }

        public static void WriteTo(RarArchiveEntry entry, Stream stream)
        {
            entry.WriteTo(stream, new NullRarExtractionListener());
        }
    }
}
