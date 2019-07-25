using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using QRCoder;

namespace QRCoderTest
{
    class Program
    {
        static void Main(string[] args)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            Console.Write("QR Code Input: ");
            string input = Console.ReadLine();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(input, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);
            qrCodeImage.Save("./qr-code-" + DateTime.Now.ToString("yyyy-MM-dd-hhmmss") + ".png", ImageFormat.Png);
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(true);
        }
    }
}
