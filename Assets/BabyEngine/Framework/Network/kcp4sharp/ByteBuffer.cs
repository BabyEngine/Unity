using System;
using System.Text;

public class ByteBuffer {
    private byte[] data;
    private int readerIndex;
    private int writerIndex;
    private int markReader;
    private int markWriter;

    public ByteBuffer(int capacity) {
        this.data = new byte[capacity];
        readerIndex = 0;
        writerIndex = 0;
        markReader = 0;
        markWriter = 0;
    }
    public ByteBuffer(byte[] content) {
        if (content == null) {
            content = new byte[0];
        }
        this.data = content;
        readerIndex = 0;
        writerIndex = content.Length;
        markReader = 0;
        markWriter = 0;
    }
    private ByteBuffer() {

    }
    public int Capacity() {
        return data.Length;
    }
    public ByteBuffer Capacity(int nc) {
        if (nc > data.Length) {
            byte[] old = data;
            data = new byte[nc];
            Array.Copy(old, data, old.Length);
        }
        return this;
    }
    public ByteBuffer Clear() {
        readerIndex = 0;
        writerIndex = 0;
        markReader = 0;
        markWriter = 0;
        return this;
    }
    public ByteBuffer Copy() {
        ByteBuffer item = new ByteBuffer(data.Length);
        Array.Copy(this.data, item.data, data.Length);
        item.readerIndex = readerIndex;
        item.writerIndex = writerIndex;
        item.markReader = markReader;
        item.markWriter = markWriter;
        return item;
    }
    public ByteBuffer Duplicate() {
        ByteBuffer item = new ByteBuffer();
        item.readerIndex = readerIndex;
        item.writerIndex = writerIndex;
        item.markReader = markReader;
        item.markWriter = markWriter;
        item.data = data;
        return item;
    }
    public byte GetByte(int index) {
        if (index < data.Length) {
            return data[index];
        }
        return (byte)0;
    }

    public int GetInt(int index) {
        if (index + 3 < data.Length) {
            int ret = ((int)data[index]) << 24;
            ret |= ((int)data[index + 1]) << 16;
            ret |= ((int)data[index + 2]) << 8;
            ret |= ((int)data[index + 3]);
            return ret;
        }
        return 0;
    }
    public int GetIntLE(int index) {
        if (index + 3 < data.Length) {
            int ret = ((int)data[index]);
            ret |= ((int)data[index + 1]) << 8;
            ret |= ((int)data[index + 2]) << 16;
            ret |= ((int)data[index + 3]) << 24;
            return ret;
        }
        return 0;
    }

    public short GetShort(int index) {
        if (index + 1 < data.Length) {
            short r1 = (short)(data[index] << 8);
            short r2 = (short)(data[index + 1]);
            short ret = (short)(r1 | r2);
            return ret;
        }
        return 0;
    }
    public short GetShortLE(int index) {
        if (index + 1 < data.Length) {
            short r1 = (short)(data[index]);
            short r2 = (short)(data[index + 1] << 8);
            short ret = (short)(r1 | r2);
            return ret;
        }
        return 0;
    }

    public ByteBuffer MarkReaderIndex() {
        markReader = readerIndex;
        return this;
    }
    public ByteBuffer MarkWriterIndex() {
        markWriter = writerIndex;
        return this;
    }
    public int MaxWritableBytes() {
        return data.Length - writerIndex;
    }
    public byte ReadByte() {
        if (readerIndex < writerIndex) {
            byte ret = data[readerIndex++];
            return ret;
        }
        return (byte)0;
    }
    public int ReadInt() {
        if (readerIndex + 3 < writerIndex) {
            int ret = (int)(((data[readerIndex++]) << 24) & 0xff000000);
            ret |= (((data[readerIndex++]) << 16) & 0x00ff0000);
            ret |= (((data[readerIndex++]) << 8) & 0x0000ff00);
            ret |= (((data[readerIndex++])) & 0x000000ff);
            return ret;
        }
        return 0;
    }
    public int ReadIntLE() {
        if (readerIndex + 3 < writerIndex) {
            int ret = (((data[readerIndex++])) & 0x000000ff);
            ret |= (((data[readerIndex++]) << 8) & 0x0000ff00);
            ret |= (((data[readerIndex++]) << 16) & 0x00ff0000);
            ret |= (int)(((data[readerIndex++]) << 24) & 0xff000000);
            return ret;
        }
        return 0;
    }
    public short ReadShort() {
        if (readerIndex + 1 < writerIndex) {
            int h = data[readerIndex++];
            int l = data[readerIndex++] & 0x000000ff;
            int len = ((h << 8) & 0x0000ff00) | (l);
            return (short)len;
        }
        return 0;
    }
    public short ReadShortLE() {
        if (readerIndex + 1 < writerIndex) {
            int l = data[readerIndex++];
            int h = data[readerIndex++] & 0x000000ff;
            int len = ((h << 8) & 0x0000ff00) | (l);
            return (short)len;
        }
        return 0;
    }
    public int ReadableBytes() {
        return writerIndex - readerIndex;
    }
    public int ReaderIndex() {
        return readerIndex;
    }
    public ByteBuffer ReaderIndex(int readerIndex) {
        if (readerIndex <= writerIndex) {
            this.readerIndex = readerIndex;
        }
        return this;
    }
    public ByteBuffer ResetReaderIndex() {
        if (markReader <= writerIndex) {
            this.readerIndex = markReader;
        }
        return this;
    }
    public ByteBuffer ResetWriterIndex() {
        if (markWriter >= readerIndex) {
            writerIndex = markWriter;
        }
        return this;
    }
    public ByteBuffer SetByte(int index, byte value) {
        if (index < data.Length) {
            data[index] = value;
        }
        return this;
    }
    public ByteBuffer SetBytes(int index, byte[] src, int from, int len) {
        if (index + len <= len) {
            Array.Copy(src, from, data, index, len);
        }
        return this;
    }
    public ByteBuffer SetIndex(int readerIndex, int writerIndex) {
        if (readerIndex >= 0 && readerIndex <= writerIndex && writerIndex <= data.Length) {
            this.readerIndex = readerIndex;
            this.writerIndex = writerIndex;
        }
        return this;
    }
    public ByteBuffer SetInt(int index, int value) {
        if (index + 4 <= data.Length) {
            data[index++] = (byte)((value >> 24) & 0xff);
            data[index++] = (byte)((value >> 16) & 0xff);
            data[index++] = (byte)((value >> 8) & 0xff);
            data[index++] = (byte)(value & 0xff);
        }
        return this;
    }
    public ByteBuffer SetIntLE(int index, int value) {
        if (index + 4 <= data.Length) {
            data[index++] = (byte)(value & 0xff);
            data[index++] = (byte)((value >> 8) & 0xff);
            data[index++] = (byte)((value >> 16) & 0xff);
            data[index++] = (byte)((value >> 24) & 0xff);
        }
        return this;
    }
    public ByteBuffer SetShort(int index, short value) {
        if (index + 2 <= data.Length) {
            data[index++] = (byte)((value >> 8) & 0xff);
            data[index++] = (byte)(value & 0xff);
        }
        return this;
    }
    public ByteBuffer SetShortLE(int index, short value) {
        if (index + 2 <= data.Length) {
            data[index++] = (byte)(value & 0xff);
            data[index++] = (byte)((value >> 8) & 0xff);
        }
        return this;
    }
    public ByteBuffer SkipBytes(int length) {
        if (readerIndex + length <= writerIndex) {
            readerIndex += length;
        }
        return this;
    }
    public int WritableBytes() {
        return data.Length - writerIndex;
    }
    public ByteBuffer WriteByte(byte value) {
        this.Capacity(writerIndex + 1);
        this.data[writerIndex++] = value;
        return this;
    }
    public ByteBuffer WriteInt(int value) {
        Capacity(writerIndex + 4);
        data[writerIndex++] = (byte)((value >> 24) & 0xff);
        data[writerIndex++] = (byte)((value >> 16) & 0xff);
        data[writerIndex++] = (byte)((value >> 8) & 0xff);
        data[writerIndex++] = (byte)(value & 0xff);
        return this;
    }
    public ByteBuffer WriteIntLE(int value) {
        Capacity(writerIndex + 4);
        data[writerIndex++] = (byte)(value & 0xff);
        data[writerIndex++] = (byte)((value >> 8) & 0xff);
        data[writerIndex++] = (byte)((value >> 16) & 0xff);
        data[writerIndex++] = (byte)((value >> 24) & 0xff);
        return this;
    }
    public ByteBuffer WriteShort(short value) {
        Capacity(writerIndex + 2);
        data[writerIndex++] = (byte)((value >> 8) & 0xff);
        data[writerIndex++] = (byte)(value & 0xff);
        return this;
    }
    public ByteBuffer WriteShortLE(short value) {
        Capacity(writerIndex + 2);
        data[writerIndex++] = (byte)(value & 0xff);
        data[writerIndex++] = (byte)((value >> 8) & 0xff);
        return this;
    }
    public ByteBuffer WriteBytes(ByteBuffer src) {
        int sum = src.writerIndex - src.readerIndex;
        Capacity(writerIndex + sum);
        if (sum > 0) {
            Array.Copy(src.data, src.readerIndex, data, writerIndex, sum);
            writerIndex += sum;
            src.readerIndex += sum;
        }
        return this;
    }
    public ByteBuffer WriteBytes(ByteBuffer src, int len) {
        if (len > 0) {
            Capacity(writerIndex + len);
            Array.Copy(src.data, src.readerIndex, data, writerIndex, len);
            writerIndex += len;
            src.readerIndex += len;
        }
        return this;
    }
    public ByteBuffer WriteBytes(byte[] src) {
        int sum = src.Length;
        Capacity(writerIndex + sum);
        if (sum > 0) {
            Array.Copy(src, 0, data, writerIndex, sum);
            writerIndex += sum;
        }
        return this;
    }
    public ByteBuffer WriteBytes(byte[] src, int off, int len) {
        int sum = len;
        if (sum > 0) {
            Capacity(writerIndex + sum);
            Array.Copy(src, off, data, writerIndex, sum);
            writerIndex += sum;
        }
        return this;
    }
    public string ReadUTF8() {
        int len = ReadInt(); // 字节数
        byte[] charBuff = new byte[len]; //
        Array.Copy(data, readerIndex, charBuff, 0, len);
        readerIndex += len;
        return Encoding.UTF8.GetString(charBuff);
    }
    public string ReadUTF8LE() {
        int len = ReadIntLE(); // 字节数
        byte[] charBuff = new byte[len]; //
        Array.Copy(data, readerIndex, charBuff, 0, len);
        readerIndex += len;
        return Encoding.UTF8.GetString(charBuff);
    }
    public ByteBuffer WriteUTF8(string value) {
        byte[] content = Encoding.UTF8.GetBytes(value.ToCharArray());
        int len = content.Length;
        Capacity(writerIndex + len + 2);
        WriteInt(len);
        Array.Copy(content, 0, data, writerIndex, len);
        writerIndex += len;
        return this;
    }
    public ByteBuffer WriteUTF8LE(string value) {
        byte[] content = Encoding.UTF8.GetBytes(value.ToCharArray());
        int len = content.Length;
        Capacity(writerIndex + len + 2);
        WriteIntLE(len);
        Array.Copy(content, 0, data, writerIndex, len);
        writerIndex += len;
        return this;
    }
    public int WriterIndex() {
        return writerIndex;
    }
    public ByteBuffer WriterIndex(int writerIndex) {
        if (writerIndex >= readerIndex && writerIndex <= data.Length) {
            this.writerIndex = writerIndex;
        }
        return this;
    }
    public byte[] GetRaw() {
        return data;
    }
}

