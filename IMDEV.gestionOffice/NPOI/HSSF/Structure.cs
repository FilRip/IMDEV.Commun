using System.Runtime.InteropServices;

namespace NPOI.HSSF
{
    [StructLayout(LayoutKind.Sequential)]
    struct FrtHeader
    {
        public ushort rt;
        public ushort grbitFrt;
        public long reserved;
    }
    [StructLayout(LayoutKind.Sequential)]
    struct FrtHeaderOld
    {
        public ushort rt;
        public ushort grbitFrt;
    }
    [StructLayout(LayoutKind.Sequential)]
    struct FrtRefHeader
    {
        public ushort rt;
        public ushort grbitFrt;
        public Ref8 ref8;
    }
    [StructLayout(LayoutKind.Sequential)]
    struct Ref8
    {
        public ushort rwFirst;
        public ushort rwLast;
        public ushort colFirst;
        public ushort colLast;
    }
    
#region xmlToken
    [StructLayout(LayoutKind.Sequential)]
    struct XmlTkHeader
    {
        public sbyte drType;
        public byte unused;
        public ushort xmlTkTag;
    }
    [StructLayout(LayoutKind.Sequential)]
    struct XmlTkBlob
    {
        /// <summary>
        /// The xtHeader.drType field MUST be equal to 0x07.
        /// </summary>
        public XmlTkHeader xtHeader;
        public uint cbBlob;
        public byte[] rgbBlob;
    }

    [StructLayout(LayoutKind.Sequential)]
    struct XmlTkBool
    {
        /// <summary>
        /// The xtHeader.drType field MUST be equal to 0x02.
        /// </summary>
        public XmlTkHeader xtHeader;
        public byte dValue;
        public byte unused;
    }

    struct XmlTkTickMarkSkipFrt
    {
        /// <summary>
        /// The nInterval.xtHeader.xmlTkTag field MUST be equal to 0x0052.
        /// </summary>
    }
#endregion
}
