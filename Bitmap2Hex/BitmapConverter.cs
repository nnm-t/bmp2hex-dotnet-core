using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Bitmap2Hex
{
    public class BitmapConverter
    {
        private const byte RShift16RB = 3;
        private const byte RShift16G = 2;

        private const byte LShift16R = 11;
        private const byte LShift16G = 5;
        
        private const byte LShift32A = 24;
        private const byte LShift32R = 16;
        private const byte LShift32G = 8;

        private readonly Bitmap bitmap;

        public BitmapConverter(string fileName)
        {
            bitmap = new Bitmap(fileName);
        }

        public uint[][] ToHexArray(BitmapType type)
        {
            return EnumerateBitmap(type).ToArray();
        }

        private IEnumerable<uint[]> EnumerateBitmap(BitmapType type)
        {
            for (int y = 0; y < bitmap.Height; y++)
            {
                yield return RowToHex(y, type).ToArray();
            }
        }

        private IEnumerable<uint> RowToHex(int y, BitmapType type)
        {
            for (int x = 0; x < bitmap.Width; x++)
            {
                Color pixel = bitmap.GetPixel(x, y);

                yield return ColorToHex(pixel, type);
            }
        }

        private static uint ColorToHex(Color color, BitmapType type)
        {
            var a = color.A;
            var r = color.R;
            var g = color.G;
            var b = color.B;

            switch (type)
            {
                case BitmapType.ARGB32:
                    return (uint) ((a << LShift32A) | (r << LShift32R) | (g << LShift32G) | b);
                case BitmapType.RGB16:
                    return (uint) (((r >> RShift16RB) << LShift16R) | ((g >> RShift16G) << LShift16G) | (b >> RShift16RB));
                default:
                    throw new InvalidOperationException();
            }
        }
    }
}