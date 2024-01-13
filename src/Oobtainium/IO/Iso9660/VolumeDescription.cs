using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OoBDev.Oobtainium.IO.Iso9660;

public class VolumeDescription : IEnumerable<DirectoryRecord>, IDisposable
{
    private VolumeDescription(byte[] buffer, Encoding encoding, Stream reader)
    {
        //  1      1
        var offset = 1;
        //  6      67, 68, 48, 48, 49 and 1, respectively (same as Volume
        //           Descriptor Set Terminator)
        DescriptorSet = buffer.GetString(ref offset, 6, encoding);
        //  1      0
        offset += 1;    //padding
        // 32      system identifier
        SystemIdentifier = buffer.GetString(ref offset, 32, encoding);
        // 32      volume identifier
        VolumeIdentifier = buffer.GetString(ref offset, 32, encoding);
        //  8      zeros
        offset += 8;    // padding
        //  8      total number of sectors, as a both endian double word
        SectorCount = buffer.GetUInt32(ref offset, 8);
        // 32      zeros
        offset += 32;   // padding
        //  4      1, as a both endian word [volume set size]
        VolumeSetSize = buffer.GetUInt16(ref offset, 4);
        //  4      1, as a both endian word [volume sequence number]
        VolumeSequenceNumber = buffer.GetUInt16(ref offset, 4);
        //  4      2048 (the sector size), as a both endian word
        SectorSize = buffer.GetUInt16(ref offset, 4);
        //  8      path table length in bytes, as a both endian double word
        PathTableLength = buffer.GetUInt32(ref offset, 8);
        //  4      number of first sector in first little endian path table,
        //           as a little endian double word
        var v1 = buffer.GetUInt32(ref offset, 4);
        //offset += 4;   // padding
        //  4      number of first sector in second little endian path table,
        //           as a little endian double word, or zero if there is no
        //           second little endian path table
        var v2 = buffer.GetUInt32(ref offset, 4);
        //offset += 4;   // padding
        //  4      number of first sector in first big endian path table,
        //           as a big endian double word
        FirstSectorFirst = buffer.GetUInt32(ref offset, 4);
        //  4      number of first sector in second big endian path table,
        //           as a big endian double word, or zero if there is no
        //           second big endian path table
        FirstSectorSecond = buffer.GetUInt32(ref offset, 4);
        // 34      root directory record, as described below
        var rootDir = new byte[34];
        Array.Copy(buffer, offset, rootDir, 0, 34);
        DirectoryRecord = new DirectoryRecord(rootDir, 0, reader, null);
        offset += 34;    // 4 big endian
        //128      volume set identifier
        VolumeSetIdentifier = buffer.GetString(ref offset, 128, encoding);
        //128      publisher identifier
        PublisherIdentifier = buffer.GetString(ref offset, 128, encoding);
        //128      data preparer identifier
        DataPreparerIdentifier = buffer.GetString(ref offset, 128, encoding);
        //128      application identifier
        ApplicationIdentifier = buffer.GetString(ref offset, 128, encoding);
        // 37      copyright file identifier
        CopyRightFileIdentifier = buffer.GetString(ref offset, 37, encoding);
        // 37      abstract file identifier
        AbstractFileIdentifier = buffer.GetString(ref offset, 37, encoding);
        // 37      bibliographical file identifier
        BibliographyFileIdentifier = buffer.GetString(ref offset, 37, encoding);
        // 17      date and time of volume creation
        VolumeCreation = buffer.GetDateTime(ref offset, 17);
        // 17      date and time of most recent modification
        VolumeModification = buffer.GetDateTime(ref offset, 17);
        // 17      date and time when volume expires
        VolumeExpires = buffer.GetDateTime(ref offset, 17);
        // 17      date and time when volume is effective
        VolumeEffective = buffer.GetDateTime(ref offset, 17);
        //  1      1
        //  1      0
        //512      reserved for application use (usually zeros)
        //653      zeros
    }

    public string DescriptorSet { get; protected set; }
    public string SystemIdentifier { get; protected set; }
    public string VolumeIdentifier { get; protected set; }
    public uint SectorCount { get; protected set; }
    public ushort VolumeSetSize { get; protected set; }
    public ushort VolumeSequenceNumber { get; protected set; }
    public ushort SectorSize { get; protected set; }
    public uint PathTableLength { get; protected set; }
    public uint FirstSectorFirst { get; protected set; }
    public uint FirstSectorSecond { get; protected set; }
    public DirectoryRecord DirectoryRecord { get; protected set; }
    public string VolumeSetIdentifier { get; protected set; }
    public string PublisherIdentifier { get; protected set; }
    public string DataPreparerIdentifier { get; protected set; }
    public string ApplicationIdentifier { get; protected set; }
    public string CopyRightFileIdentifier { get; protected set; }
    public string AbstractFileIdentifier { get; protected set; }
    public string BibliographyFileIdentifier { get; protected set; }
    public DateTime VolumeCreation { get; protected set; }
    public DateTime VolumeModification { get; protected set; }
    public DateTime VolumeExpires { get; protected set; }
    public DateTime VolumeEffective { get; protected set; }

    public static VolumeDescription Create(Stream stream)
    {
        var sector = new byte[2048];
        var bufferLen = 0;

        lock (stream)
        {
            //skip the first 16 sectors
            stream.Seek(16 * sector.Length, SeekOrigin.Begin);
            bufferLen = stream.Read(sector, 0, sector.Length);
        }
        return new VolumeDescription(sector, Encoding.ASCII, stream);
    }
    protected Stream BaseStream { get; set; }

    #region IEnumerable<DirectoryRecord> Members

    public IEnumerator<DirectoryRecord> GetEnumerator()
    {
        if (DirectoryRecord == null)
            return null;
        return DirectoryRecord.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    #endregion

    #region IDisposable Members

    public void Dispose()
    {
        BaseStream?.Dispose();
    }

    #endregion
}
