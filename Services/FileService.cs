using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace Commander.Services
{
    public class FileService : IFileService
    {
        public float CountPixelPoint(float point1, float point2, float tmp)
        {
            return point1 + (point2 - point1) * tmp;
        }

        public float CountPixel(float point00, float point10, float point01, float point11, float tmpX, float tmpY)
        {
            return CountPixelPoint(CountPixelPoint(point00, point10, tmpX), CountPixelPoint(point01, point11, tmpX), tmpY);
        }

        public Bitmap Scale(Bitmap input, float scaleX, float scaleY)
        {

            int newWidth = (int)(input.Width * scaleX);
            int newHeight = (int)(input.Height * scaleY);
            Bitmap newImage = new Bitmap(newWidth, newHeight);

            for (int x = 0; x < newWidth; x++)
            {
                for (int y = 0; y < newHeight; y++)
                {
                    float pointX = ((float)x) / newWidth * (input.Width - 1);
                    float pointY = ((float)y) / newHeight * (input.Height - 1);

                    int pointXi = (int)pointX;
                    int pointYi = (int)pointY;

                    Color point00 = input.GetPixel(pointXi, pointYi);
                    Color point10 = input.GetPixel(pointXi + 1, pointYi);
                    Color point01 = input.GetPixel(pointXi, pointYi + 1);
                    Color point11 = input.GetPixel(pointXi + 1, pointYi + 1);

                    int red = (int)CountPixel(point00.R, point10.R, point01.R, point11.R, pointX - pointXi, pointY - pointYi);
                    int green = (int)CountPixel(point00.G, point10.G, point01.G, point11.G, pointX - pointXi, pointY - pointYi);
                    int blue = (int)CountPixel(point00.B, point10.B, point01.B, point11.B, pointX - pointXi, pointY - pointYi);

                    newImage.SetPixel(x, y, Color.FromArgb(red, green, blue));
                }
            }
            newImage.Save(@"C:\Users\hp\Desktop\Newf.png");
            return newImage;
        }
    }
}
