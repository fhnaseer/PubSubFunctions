using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace PubsSubFunctions.Helpers
{
    public static class Helpers
    {
        public static byte[] ToByteArray(this Image image, ImageFormat format)
        {
            using (var ms = new MemoryStream())
            {
                image.Save(ms, format);
                return ms.ToArray();
            }
        }
    }
}