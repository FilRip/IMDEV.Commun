using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace IMDEV.GUI
{
    public class BitmapToRegion
    {
        public static Region getRegion(Bitmap bitmap, Color transparencyKey, int tolerance)
        {
            // Fonction de retour, evite d'exposer la fonction unsafe qui n'est pas forcément compatible avec tous les NET FRAMEWORK
            Region retour;
            retour = getRegionFast(bitmap, transparencyKey, tolerance);
            return retour;
        }

        private unsafe static bool colorsMatch(uint* pixelPtr, Color color1, int tolerance)
        {
            if (tolerance < 0) tolerance = 0;

            //Convert the pixel pointer into a color
            byte a = (byte)(*pixelPtr >> 24);
            byte r = (byte)(*pixelPtr >> 16);
            byte g = (byte)(*pixelPtr >> 8);
            byte b = (byte)(*pixelPtr >> 0);
            Color pointer = Color.FromArgb(a, r, g, b);

            //Each value between the two colors cannot differ more than tolerance
            return Math.Abs(color1.A - pointer.A) <= tolerance &&
                   Math.Abs(color1.R - pointer.R) <= tolerance &&
                   Math.Abs(color1.G - pointer.G) <= tolerance &&
                   Math.Abs(color1.B - pointer.B) <= tolerance;
        }

        //Uses pointers to scan through the bitmap a LOT faster
        //Make sure to check "Allow unsafe code" in the project properties      
        private unsafe static Region getRegionFast(Bitmap bitmap, Color transparencyKey, int tolerance)
        {
            //Bounds
            GraphicsUnit unit = GraphicsUnit.Pixel;
            RectangleF boundsF = bitmap.GetBounds(ref unit);
            Rectangle bounds = new Rectangle((int)boundsF.Left, (int)boundsF.Top,
                                             (int)boundsF.Width, (int)boundsF.Height);

            int yMax = (int)boundsF.Height;
            int xMax = (int)boundsF.Width;

            //Transparency Color
            if (tolerance <= 0) tolerance = 1;


            //Lock Image
            BitmapData bitmapData = bitmap.LockBits(bounds, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            uint* pixelPtr = (uint*)bitmapData.Scan0.ToPointer();

            //Stores all the rectangles for the region
            GraphicsPath path = new GraphicsPath();

            //Scan the image, looking for lines that are NOT the transperancy color
            for (int y = 0; y < yMax; y++)
            {
                byte* basePos = (byte*)pixelPtr;

                for (int x = 0; x < xMax; x++, pixelPtr++)
                {
                    //Go on with the loop if its transperancy color

                    if (colorsMatch(pixelPtr, transparencyKey, tolerance))
                        continue;

                    //Line start
                    int x0 = x;

                    //Find the next transparency colored pixel
                    while (x < xMax && !colorsMatch(pixelPtr, transparencyKey, tolerance))
                    {
                        x++;
                        pixelPtr++;
                    }

                    //Add the line as a rectangle
                    path.AddRectangle(new Rectangle(x0, y, x - x0, 1));
                }

                //Go to next line
                pixelPtr = (uint*)(basePos + bitmapData.Stride);
            }

            //Create the Region
            Region outputRegion = new Region(path);

            //Clean Up
            path.Dispose();
            bitmap.UnlockBits(bitmapData);

            return outputRegion;
        }
    }
}
