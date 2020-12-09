using System;
using System.IO;

namespace CryptoLab1
{
    class Program
    {
        static string _fullFilePath = "D:/4KNU/EnctTest/OOP.7z";
        //static string _fullFilePath2 = "D:/4KNU/EnctTest/GMODvid.mp4";
        static void Main(string[] args)
        {
            byte[] data = { 0x32, 0x43, 0xf6, 0xa8, 0x88, 0x5a, 0x30, 0x8d, 0x31, 0x31, 0x98, 0xa2, 0xe0, 0x37, 0x07, 0x34 };
            byte[] ckey = { 0x2b, 0x7e, 0x15, 0x16, 0x28, 0xae, 0xd2, 0xa6, 0xab, 0xf7, 0x15, 0x88, 0x09, 0xcf, 0x4f, 0x3c };
            AES encryption = new AES();
            byte[] encrypted = encryption.Encrypt(data, ckey);
            var res = encryption.KeyExpansion(ckey);
            Console.WriteLine(System.Text.Encoding.UTF8.GetString(encrypted));

            byte[] array = new byte[1000000000];

            using (FileStream fs = new FileStream(_fullFilePath, FileMode.Open, FileAccess.Read))
            {
                var count = fs.Read(array);

                long pos = 0;
                while (pos < count)
                {
                    byte[] small = new byte[128];
                    if (pos + 128 < count)
                    {
                        Array.Copy(array, pos, small, 0, 128);
                        encryption.Encrypt(small, ckey);
                    }
                    pos += 128;
                }
            }

            /*
            using (FileStream fs = new FileStream(_fullFilePath2, FileMode.Open, FileAccess.Read))
            {
                var count = fs.Read(array);

                long pos = 0;
                while (pos < count)
                {
                    byte[] small = new byte[128];
                    if (pos + 128 < count)
                    {
                        Array.Copy(array, pos, small, 0, 128);
                        encryption.Encrypt(small, ckey);
                    }
                    pos += 128;
                }
            }
            */

        }
    }
}