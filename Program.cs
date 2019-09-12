using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using QRCoder;
using System.IO;
using System.ComponentModel;
using System.Xml.Linq;
using System.Xml;

namespace QRCoderTest
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlWriter xmlWriter = XmlWriter.Create("./test.xml", null);
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            Console.Write("QR Code Input: ");
            string input = Console.ReadLine();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(input, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);
            qrCodeImage.Save("./qr-code-" + DateTime.Now.ToString("yyyy-MM-dd-hhmmss") + ".png", ImageFormat.Png);
            TypeConverter converter = TypeDescriptor.GetConverter(typeof(Bitmap));
            XElement img = new XElement("image", Convert.ToBase64String((byte[])converter.ConvertTo(qrCodeImage, typeof(byte[]))));
            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("qrcodertest");
            xmlWriter.WriteString(img.Value);
            xmlWriter.WriteEndElement();
            xmlWriter.Close();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(true);
        }
    }
}
