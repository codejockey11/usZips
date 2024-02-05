using System;
using System.IO;
using System.Text;

namespace usZips
{
    class Program
    {
        static StreamReader sr = new StreamReader("uszips.txt");
        
        static StreamWriter sw = new StreamWriter("uszips_out.txt");

        static void Main(string[] args)
        {
            String rec = sr.ReadLine();
            
            while (!sr.EndOfStream)
            {
                ProcessRec(rec);

                rec = sr.ReadLine();
            }

            ProcessRec(rec);

            sr.Close();

            sw.Close();
        }

        static void ProcessRec(String rec)
        {
            String[] f = rec.Split('~');

            // state
            sw.Write(ConvertString(f[4]));
            sw.Write("~");

            // city
            sw.Write(ConvertString(f[3]));
            sw.Write("~");

            // county
            sw.Write(ConvertString(f[11]));
            sw.Write("~");

            // zipcode
            sw.Write(ConvertString(f[0]));
            sw.Write("~");

            // latitude
            sw.Write(ConvertString(f[1]));
            sw.Write("~");

            // longitude
            sw.Write(ConvertString(f[2]));
            sw.Write("~");

            // timezone
            sw.Write(ConvertString(f[15]));
            sw.Write(sw.NewLine);
        }

        static String ConvertString(String i)
        {
            Encoding ascii = Encoding.ASCII;
            
            Encoding unicode = Encoding.Unicode;

            byte[] unicodeBytes = unicode.GetBytes(i);

            byte[] asciiBytes = Encoding.Convert(unicode, ascii, unicodeBytes);

            char[] asciiChars = new char[ascii.GetCharCount(asciiBytes, 0, asciiBytes.Length)];
            
            ascii.GetChars(asciiBytes, 0, asciiBytes.Length, asciiChars, 0);
            
            string asciiString = new string(asciiChars);

            return asciiString;
        }
    }
}
