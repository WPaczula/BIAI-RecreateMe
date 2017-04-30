using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;

namespace RecreateMeUtils
{
    public static class BitmapConverter
    {
        public static unsafe byte[] ByteTableFrom(Bitmap bitmap)
        {
            //Prepare variables
            Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
            BitmapData bmpData = bitmap.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            //Get data pointer
            IntPtr ptr = bmpData.Scan0;
            int bytes = Math.Abs(bmpData.Stride) * bitmap.Height;
            byte[] rgbValues = new byte[bytes];

            //Copy the RGB values into the array.
            System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes);
            bitmap.UnlockBits(bmpData);
            return rgbValues;
        }

        public static float[] FloatTableFrom(Bitmap bitmap)
        {
            var table = ByteTableFrom(bitmap);
            return FloatTableFrom(table);
        }

        public static float[] FloatTableFrom(byte[] table)
        {
            float[] output = new float[table.Count()];
            for (int i = 0; i < table.Count(); i++)
            {
                output[i] = (float)table[i] / 255f;
            }
            return output;
        }
    }
}

