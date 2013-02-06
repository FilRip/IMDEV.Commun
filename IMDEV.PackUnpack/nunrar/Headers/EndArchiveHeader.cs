using NUnrar.IO;

namespace NUnrar.Headers
{
    internal class EndArchiveHeader : RarHeader
    {
        protected override void ReadFromReader(MarkingBinaryReader reader)
        {
            if (FlagUtility.HasFlag(EndArchiveFlag,EndArchiveFlags.EARC_DATACRC))
                ArchiveCRC = reader.ReadInt32();
            if (FlagUtility.HasFlag(EndArchiveFlag, EndArchiveFlags.EARC_VOLNUMBER))
                VolumeNumber = reader.ReadInt16();
        }

        internal EndArchiveFlags EndArchiveFlag
        {
            get
            {
                return (EndArchiveFlags)base.Flags;
            }
        }

        internal int? ArchiveCRC
        {
            get;
            private set;
        }

        internal short? VolumeNumber
        {
            get;
            private set;
        }
    }
}
