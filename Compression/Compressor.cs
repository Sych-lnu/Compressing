using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;


namespace Compression
{
    class Compressor
    {
        public static byte[] Compress(byte[] inputBytes)
        {
            using (var output = new System.IO.MemoryStream()) { //створення набору байтів для повернення
                using (var compression = new GZipStream(output, CompressionLevel.Optimal)) // набір байтів в якому відбудеться стиснення
                {
                    compression.Write(inputBytes, 0, inputBytes.Length);// запис зовнішніх даних в набір для стиснення

                }
                return output.ToArray();//повернення стиснутих даних

            }

        }
        public static byte[] Decompress(byte[] inputBytes)
        {
            using (var input = new System.IO.MemoryStream(inputBytes))//створення набору вхідних байтів
            {
                using (var output = new System.IO.MemoryStream())//створення набору байтів для повернення
                {
                    using (var compression = new GZipStream(input, CompressionMode.Decompress))// набір байтів в якому відбудеться розархівація
                    {
                        compression.CopyTo(output);//копіювання даних

                    }
                    return output.ToArray();

                }
            }


        }

        
    }
}
