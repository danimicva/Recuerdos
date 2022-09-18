using Microsoft.WindowsAPICodePack.Shell;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recuerdos.Utils
{
    class UtilsImagen
    {
        public static Image generarImagen(string ruta, Size tamano) {
            /*
            float nPercent;
            float nPercentW;
            float nPercentH;

            Image img = Image.FromFile(ruta);

            //Get the image current width  
            int sourceWidth = img.Width;
            //Get the image current height  
            int sourceHeight = img.Height;
            
            //Calulate  width with new desired size  
            nPercentW = (float)tamano.Width / (float)sourceWidth;
            //Calculate height with new desired size  
            nPercentH = (float)tamano.Height / (float)sourceHeight;
            if (nPercentH < nPercentW)
                nPercent = nPercentH;
            else
                nPercent = nPercentW;
            //New Width  
            int destWidth = (int)(sourceWidth * nPercent);
            //New Height  
            int destHeight = (int)(sourceHeight * nPercent);
            Bitmap b = new Bitmap(destWidth, destHeight);
            Graphics g = Graphics.FromImage(b);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            // Draw image with new width and height  
            g.DrawImage(img, 0, 0, destWidth, destHeight);
            g.Dispose();
            img.Dispose();
            GC.Collect();
            return b;*/

            ShellFile shellFile = ShellFile.FromFilePath(ruta);
            return shellFile.Thumbnail.Bitmap;
        }
    }
}
