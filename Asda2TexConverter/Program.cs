namespace Asda2TexConverter
{
    using System;
    using System.IO;
    using System.Linq;

    internal class Program
    {
        private static void Main(string[] args)
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string[] files = Directory.GetFiles(baseDirectory);
            string path = baseDirectory + "result";
            Directory.CreateDirectory(path);
            Directory.SetCurrentDirectory(path);
            foreach (string str3 in files)
            {
                byte[] source = File.ReadAllBytes(str3);
                string str4 = str3.Substring(0, str3.Length - 3);
                switch (source[0x24])
                {
                    case 0x89:
                        str4 = str4 + "png";
                        break;

                    case 0xff:
                        str4 = str4 + "jfif";
                        break;

                    case 0x42:
                        str4 = str4 + "bmp";
                        break;

                    case 0x43:
                    {
                        continue;
                    }
                    case 0x44:
                        str4 = str4 + "dds";
                        break;

                    case 0:
                        str4 = str4 + "tga";
                        break;

                    default:
                    {
                        continue;
                    }
                }
                File.WriteAllBytes(path + @"\" + Path.GetFileName(str4), source.Skip<byte>(0x24).ToArray<byte>());
            }
        }
    }
}

