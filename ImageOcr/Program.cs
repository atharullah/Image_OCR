using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using tessnet2;
using System.Drawing;
namespace ImageOcr
{
    class Program
    {
        static void Main(string[] args)
        {
            string result = "";
            try
            {
                string imagepath = "E:\\Extra Projects\\New folder\\ImageOcr\\Image.bmp";
                Bitmap image = new Bitmap(imagepath);
                Console.WriteLine("image path is " + imagepath);

                tessnet2.Tesseract test = new Tesseract();
                Console.WriteLine("Strating OCR ");
                test.SetVariable("tessedit_char_whitelist", @"123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ.,/?\][}-_+=*@#!$%^&()");
                test.Init(@"E:\Extra Projects\New folder\ImageOcr\tessdata", "eng", true);
                Console.WriteLine("OCR Started ");
                List<tessnet2.Word> words = test.DoOCR(image, Rectangle.Empty);
                
                foreach (tessnet2.Word word in words)
                {
                    result += word.Confidence + " , " + word.Text + " , " + word.Left + " , " + word.Right + " , " + word.Top + " , " + word.Bottom + "\n";
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
               
            }
            Console.WriteLine("value is "+result);
            Console.Read();
            
        }
    }
}
