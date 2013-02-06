using System.IO;
using NUnrar.Common;
using NUnrar.Headers;

namespace NUnrar.Reader
{
    public static class RarReaderExtensions
    {
        public static void WriteEntryTo(RarReader reader, string filePath)
        {
            using (Stream stream = File.Open(filePath, FileMode.Create, FileAccess.Write))
            {
                reader.WriteEntryTo(stream);
            }
        }
        public static void WriteEntryTo(RarReader reader, FileInfo filePath)
        {
            using (Stream stream = filePath.Open(FileMode.Create))
            {
                reader.WriteEntryTo(stream);
            }
        }

        public static void WriteEntryToDirectory(RarReader reader, string destinationDirectory)
        {
            WriteEntryToDirectory(reader,destinationDirectory, ExtractOptions.Overwrite);
        }
        /// <summary>
        /// Extract to specific directory, retaining filename
        /// </summary>
        public static void WriteEntryToDirectory(RarReader reader, string destinationDirectory,
            ExtractOptions options)
        {
            string destinationFileName = string.Empty;
            string file = Path.GetFileName(reader.Entry.FilePath);


            if (FlagUtility.HasFlag(options,ExtractOptions.ExtractFullPath))
            {
                string folder = Path.GetDirectoryName(reader.Entry.FilePath);
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

            reader.WriteEntryToFile(destinationFileName, options);
        }

        public static void WriteEntryToFile(RarReader reader, string destinationFileName)
        {
            WriteEntryToFile(reader, destinationFileName, ExtractOptions.Overwrite);
        }
        /// <summary>
        /// Extract to specific file
        /// </summary>
        public static void WriteEntryToFile(RarReader reader, string destinationFileName,
            ExtractOptions options)
        {
            FileMode fm = FileMode.Create;

            if (!options.HasFlag(ExtractOptions.Overwrite))
            {
                fm = FileMode.CreateNew;
            }
            using (FileStream fs = File.Open(destinationFileName, fm))
            {
                reader.WriteEntryTo(fs);
            }
        }
    }
}
