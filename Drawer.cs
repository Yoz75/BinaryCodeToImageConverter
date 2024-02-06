
using System.Drawing;
using System.IO;

namespace BinaryCodeToImageConverter
{
    public class Drawer
    {
        Bitmap Image;
        public Drawer(Bitmap image)
        {
            Image = image;
        }

        public void DrawToBitmap(string sourcePath)
        {
            byte[] fileSource = File.ReadAllBytes(sourcePath);
            Color[] Colors = new Color[fileSource.Length];
            int lastFileSourceElement = fileSource.Length - 1;
            byte r, g, b, a;

            for(int i = 0; i < Colors.Length; i++)
            {
                r = g = b = a = 0;

                if(i + 3 < lastFileSourceElement)
                {
                    r = fileSource[i + 3];
                }

                if(i + 2 < lastFileSourceElement)
                {
                    g = fileSource[i + 2];
                }

                if(i + 1 < lastFileSourceElement)
                {
                    b = fileSource[i + 1];
                }

                if(i < lastFileSourceElement)
                {
                    a = fileSource[i];
                }
                Colors[i] = Color.FromArgb(((a << 24) | (r << 16) | (g << 8) | b));
            }

            for(int y = 0; y < Image.Height; y++)
            {
                for(int x = 0; x < Image.Width; x++)
                {
                    if(x * Image.Width + y < Colors.Length)
                    {
                        Image.SetPixel(x, y, Colors[x * Image.Width + y]);
                        continue;
                    }
                    Image.SetPixel(x, y, Color.White);
                }
            }
        }

    }
}
