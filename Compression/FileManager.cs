using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Compression
{
    class FileManager
    {
        public static int IsCorrectName(string inputFile)//перевірка на існування файла
        {
            if(File.Exists(inputFile))
                return 0;
            return 1;
        }
        public static void CompressOneFileIntoOneZip(string inputFile, string outputFile)
        {
            var bytes = File.ReadAllBytes(inputFile);//отримання вхідних даних
            bytes = Compressor.Compress(bytes);//стиснення
            File.WriteAllBytes(outputFile, bytes);//запис стиснених даних в архів

        }
        public static void DecompressZipIntoOneFile(string inputFile, string outputFile)
        {
            var bytes = File.ReadAllBytes(inputFile);//отримання вхідних даних
            bytes = Compressor.Decompress(bytes);//розархівування
            File.WriteAllBytes(outputFile, bytes);//запис розархівованих даних в файл
        }

        public static void CompressManyFilesIntoOneZip(string[] inputFiles, string outputFile)
        {
            int bytesSize = 0;
            for(int i = 0; i < inputFiles.Length; i++)
            {
                bytesSize += GetBytesFromFile(inputFiles[i]).Length; //визначення розміру вхідних даних
            }
            var bytes = new byte[bytesSize];// створення матису вхідних даних
            int index = 0;
            for(int i = 0; i < inputFiles.Length; i++)//зведення всіх даних в один масив
            {
                var temp = File.ReadAllBytes(inputFiles[i]);
                for(int j = 0; j< temp.Length; j++)
                {
                    bytes[index] = temp[j];
                    index++;
                }
            }
            bytes = Compressor.Compress(bytes);//стиснення
            File.WriteAllBytes(outputFile, bytes);//запис стиснених даних в файл



        }
        public static void DecompressManyZipsIntoOneFile(string[] inputFiles, string outputFile)
        {
            int bytesSize = 0;
            for (int i = 0; i < inputFiles.Length; i++)
            {
                bytesSize += GetBytesFromFile(inputFiles[i]).Length;//визначення розміру вхідних даних
            }
            var bytes = new byte[bytesSize];// створення матису вхідних даних
            int index = 0;
            for (int i = 0; i < inputFiles.Length; i++)//зведення всіх даних в один масив
            {
                var temp = File.ReadAllBytes(inputFiles[i]);
                for (int j = 0; j < temp.Length; j++)
                {
                    bytes[index] = temp[j];
                    index++;
                }
            }
            bytes = Compressor.Decompress(bytes);//розархівування
            File.WriteAllBytes(outputFile, bytes);//запис даних в файл


        }


        public static byte[] GetBytesFromFile(string fileName)
        {
            return File.ReadAllBytes(fileName);//повкрнкння даних з файла
        }

    }
}
