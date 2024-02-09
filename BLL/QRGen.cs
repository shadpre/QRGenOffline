using System.IO;
using ZXing;
using ZXing.QrCode;
using System.Drawing;

using System.Drawing.Imaging;
using ZXing.Common;
using ZXing.Rendering;
namespace BLL
{
    public static class QRGen
    {
        public static Bitmap GenerateQRCode(string url, int size, Color front, Color background)
        {
            QrCodeEncodingOptions options = new() 
            {
                DisableECI = true,
                CharacterSet = "UTF-8",
                Width = size,
                Height = size,
                Margin = 0
            };

            BarcodeWriterPixelData writer = new()
            {
                Format = BarcodeFormat.QR_CODE,
                Options = options,

                Renderer = new PixelDataRenderer()
                {
                    Foreground = new(front.ToArgb()),
                    Background = new(background.ToArgb())
                }
            };

            var pixelData = writer.Write(url);
            var bitmap = new Bitmap(pixelData.Width, pixelData.Height, PixelFormat.Format32bppRgb);

            // Create the Bitmap from the pixel data
            var bitmapData = bitmap.LockBits(new Rectangle(0, 0, pixelData.Width, pixelData.Height), ImageLockMode.WriteOnly, PixelFormat.Format32bppRgb);
            System.Runtime.InteropServices.Marshal.Copy(pixelData.Pixels, 0, bitmapData.Scan0, pixelData.Pixels.Length);
            bitmap.UnlockBits(bitmapData);

            return bitmap;
        }
    }
}
