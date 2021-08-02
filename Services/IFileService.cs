using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace Commander.Services
{
    public interface IFileService
    {
        float CountPixelPoint(float p1, float p2, float t);
        float CountPixel(float p1, float p2, float p3, float p4, float x, float y);
        Bitmap Scale(Bitmap input, float scaleX, float scaleY);
    }
}
