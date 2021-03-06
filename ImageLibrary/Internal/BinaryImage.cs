﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace ImageLibrary
{
    /// <summary>
    /// Optimized Implementation of Binary (1 / 0) Image
    /// </summary>
    internal unsafe class BinaryImage : IImage<bool>
    {
        private IntPtr _ptr;
        private int* data;
        private int width;
        private int height;
        private int length;
        private int bytesAlloc;

        internal BinaryImage(int width, int height, bool[] data)
        {
            this.width = width;
            this.height = height;
            this.length = width * height;

            int bytesAlloc = (this.length / 8) + (this.length % 8 != 0 ? 1 : 0) + /* safety buffer */ + 8;

            // 4 bytes in Int32
            if (bytesAlloc % 4 != 0)
            {
                bytesAlloc += bytesAlloc % 32;
            }

            this.bytesAlloc = bytesAlloc;
            this._ptr = Marshal.AllocHGlobal(bytesAlloc);
            this.data = (int*) _ptr.ToPointer();

            //
            for (int i = 0; i < data.Length; i++)
            {
                this[i] = data[i];
            }    
        }

        private BinaryImage(int width, int height, IntPtr from, int bytesAlloc)
        {
            this.width = width;
            this.height = height;
            this.length = width * height;

            this._ptr = Marshal.AllocHGlobal(bytesAlloc);
            NativeMethods.RtlMoveMemory(this._ptr, from, (uint)(bytesAlloc));
            this.data = (int*)_ptr.ToPointer();
        }

        public int Cols
        {
            get { return width; }
        }

        public int Rows
        {
            get { return height; }
        }

        public int Height
        {
            get { return height; }
        }

        public int Width
        {
            get { return width; }
        }

        public bool[] Data
        {
            get {
                var data = new bool[this.length];

                Parallel.For(0, this.length, i => {
                    data[i] = this[i];
                });

                return data;
            }
        }

        public IImage<bool> Copy()
            => new BinaryImage(this.width, this.height, this._ptr, this.bytesAlloc);

        private static BinaryImage Generate(int width, int height, bool[] data)
            => new BinaryImage(width, height, data);

        public IImage<bool> Crop(System.Drawing.Rectangle rect)
            => ImageBase.Crop(this, BinaryImage.Generate, rect);

        public IImage<bool> Crop(int x1, int y1, int width, int height)
            => ImageBase.Crop(this, BinaryImage.Generate, x1, y1, width, height);

        public IImage<bool> Pad(int width, int height)
            => ImageBase.Pad(this, BinaryImage.Generate, width, height);

        public IImage<bool> Upsample()
            => ImageBase.Upsample(this, BinaryImage.Generate);

        public IImage<bool> UpsampleCols()
            => ImageBase.UpsampleCols(this, BinaryImage.Generate);

        public IImage<bool> UpsampleRows()
            => ImageBase.UpsampleRows(this, BinaryImage.Generate);

        public IImage<bool> Downsample()
            => ImageBase.Downsample(this, BinaryImage.Generate);

        public IImage<bool> DownsampleCols()
            => ImageBase.DownsampleCols(this, BinaryImage.Generate);

        public IImage<bool> DownsampleRows()
            => ImageBase.DownsampleRows(this, BinaryImage.Generate);

        public IImage<bool> FlipX()
            => ImageBase.FlipX(this, BinaryImage.Generate);

        public IImage<bool> FlipY()
            => ImageBase.FlipY(this, BinaryImage.Generate);

        public IImage<bool> FlipXY()
            => ImageBase.FlipXY(this, BinaryImage.Generate);

        public IImage<bool> Transpose()
            => ImageBase.Transpose(this, BinaryImage.Generate);

        public bool this[int i, int j]
        {
            get
            {
                return this[i * this.Width + j];
            }
            set
            {
                this[i * this.Width + j] = value;
            }
        }

        public bool this[int index]
        {
            get
            {
                if (index >= this.length)
                {
                    throw new ArgumentOutOfRangeException(nameof(index));
                }

                // Adapted from .NET source code
                return (data[index / 32] & (1 << (index % 32))) != 0;
            }
            set
            {
                if (index >= this.length)
                {
                    throw new ArgumentOutOfRangeException(nameof(index));
                }

                // Adapted from .NET source code
                if (value)
                {
                    *(data + index / 32) |= (1 << (index % 32));
                }
                else
                {
                    *(data + index / 32) &= ~(1 << (index % 32));
                }
            }
        }

        private static readonly BGRA White = new BGRA { B = 255, G = 255, R = 255, A = 255 };

        public void ToIndexedBgra(Action<int, BGRA> iRgba)
        {
            Parallel.For(0, this.length, i => iRgba(i, this[i] ? White : BGRA.Black));
        }

        public byte[] ToBGR()
            => ImageBase.ToRGB(this);

        public byte[] ToBGRA()
            => ImageBase.ToRGBA(this);

        public BGRA[] ToPixelColor()
            => ImageBase.ToPixelColor(this);

        public int Length
        {
            get { return this.length; }
        }

        public void CopyTo(Array array, int index)
            => ImageBase.CopyTo(this, array, index);

        public int Count
        {
            get { return this.length; }
        }

        public bool IsSynchronized
        {
            get { return false; }
        }

        public object SyncRoot
        {
            get { return this; }
        }

        public System.Collections.IEnumerator GetEnumerator()
        {
            return ((IEnumerable<bool>)this).GetEnumerator();
        }

        IEnumerator<bool> IEnumerable<bool>.GetEnumerator()
            => ImageBase.GetEnumerator(this);

        public void Add(bool item)
        {
            throw new NotSupportedException();
        }

        public void Clear()
        {
            throw new NotSupportedException();
        }

        public bool Contains(bool item)
        {
            for (int i = 0; i < this.length; i++)
            {
                if (this[i] == item) {
                    return true;
                }
            }

            return false;
        }

        public void CopyTo(bool[] array, int arrayIndex)
        {
            int start = 0 + arrayIndex;
            int end = this.length + arrayIndex;

            for (; start < end; start++)
            {
                array[start] = this[start];
            }
        }

        public bool IsReadOnly
        {
            get { return true; }
        }

        public bool Remove(bool item)
        {
            throw new NotSupportedException();
        }

        private readonly object _lock = new object();

        public void Dispose()
        {
            lock (_lock)
            { 
                if (this.data == null)
                {
                    return;
                }
                else
                {
                    this.data = null;
                    Marshal.FreeHGlobal(this._ptr);
                    GC.SuppressFinalize(this);
                }
            }
        }

        ~BinaryImage()
        {
            lock (_lock)
            {
                if (this.data == null)
                {
                    return;
                }
                else
                {
                    Marshal.FreeHGlobal(this._ptr);
                }
            }
        }
    }
}
