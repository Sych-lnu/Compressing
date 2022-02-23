using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Compression
{
    class Menu
    {
        private static void CompressOneDocIntoOneZip()
        {
            string inputName, outputName;
            int inputLength = 0, compressedLength = 0;
            Console.Write("Enter path to your doc file: ");//отримання шляху до вхідних даних
            inputName = Console.ReadLine();

            if (FileManager.IsCorrectName(inputName) == 1)//перевірка наявності файла
            {
                Console.WriteLine("Incorrect path entered!");
                CompressOneDocIntoOneZip();
            }
            

            

            Console.Write("Enter path to your zip file: ");//отримання шляху до вихідних даних
            outputName = Console.ReadLine();
            inputLength = FileManager.GetBytesFromFile(inputName).Length;//розміри вхідних даних
            FileManager.CompressOneFileIntoOneZip(inputName, outputName);//стиснення
            Console.WriteLine("Input file is " + inputLength + " bytes");
            compressedLength = FileManager.GetBytesFromFile(outputName).Length;
            Console.WriteLine("Compressed file is " + compressedLength + " bytes");//вивід результату




            ShowMenu();//вивід можливих операцій
        }
        private static void CompressSomeDocIntoOneZip()
        {
            string outputName, inputNamesStr;
            int inputLength = 0, compressedLength = 0;
            Console.Write("Enter pathes to your doc files in this way: path1,path2,....,pathN: ");
            inputNamesStr = Console.ReadLine();//отримання шляху до вхідних даних

            string[] inputNamesArr = inputNamesStr.Split(',');//зведення стрічки з усіма шляхами до масиву
            for (int i = 0; i < inputNamesArr.Length; i++)
            {
                if (FileManager.IsCorrectName(inputNamesArr[i]) == 1)//перевірка існування всіх файлів
                {
                    Console.WriteLine("Incorrect path for file number {0} entered!", i + 1);
                    CompressOneDocIntoOneZip();
                }
            }



            Console.Write("Enter path to your zip file: ");
            outputName = Console.ReadLine();//отримання шляху до вихідних даних
            for (int i = 0; i < inputNamesArr.Length; i++)
            {
                inputLength+= FileManager.GetBytesFromFile(inputNamesArr[i]).Length;
            }
            Console.WriteLine("Input files is " + inputLength + " bytes");
            FileManager.CompressManyFilesIntoOneZip(inputNamesArr, outputName);//стиснення
            compressedLength = FileManager.GetBytesFromFile(outputName).Length;
            Console.WriteLine("Compressed file is " + compressedLength + " bytes");




            ShowMenu();

        }
        private static void DecompressOneZipIntoOneDoc()
        {
            string compressedName, decompressName;
            int compressedLength = 0, decompressedLength = 0;
            Console.Write("Enter path to your zip file: ");
            compressedName = Console.ReadLine();//отримання шляху до вхідних даних

            if (FileManager.IsCorrectName(compressedName) == 1)//перевірка існування
            {
                Console.WriteLine("Incorrect path entered!");
                CompressOneDocIntoOneZip();
            }




            Console.Write("Enter path to your doc file: ");//отримання шляху до вихідних даних
            decompressName = Console.ReadLine();
            compressedLength = FileManager.GetBytesFromFile(compressedName).Length;
            Console.WriteLine("Compressed file is " + compressedLength + " bytes");
            FileManager.DecompressZipIntoOneFile(compressedName, decompressName);//розархівування
            decompressedLength = FileManager.GetBytesFromFile(decompressName).Length;
            Console.WriteLine("Decompressed file is " + decompressedLength + " bytes");




            ShowMenu();

        }
        private static void DecompressSomeZipIntoOneDoc()
        {
            string decompressName, compressedNamesStr;
            int compressedLength = 0, decompressedLength = 0;
            Console.Write("Enter pathes to your zip files in this way: path1,path2,....,pathN: ");
            compressedNamesStr = Console.ReadLine();//отримання шляху до вхідних даних

            string[] sompressedNamesArr = compressedNamesStr.Split(',');
            for (int i = 0; i < sompressedNamesArr.Length; i++)
            {
                if (FileManager.IsCorrectName(sompressedNamesArr[i]) == 1)//перевірка існування файлів
                {
                    Console.WriteLine("Incorrect path for file number {0} entered!", i + 1);
                    CompressOneDocIntoOneZip();
                }
            }



            Console.Write("Enter path to your doc file: ");
            decompressName = Console.ReadLine();//отримання шляху до вихідних даних
            for (int i = 0; i < sompressedNamesArr.Length; i++)
            {
                compressedLength += FileManager.GetBytesFromFile(sompressedNamesArr[i]).Length;
            }
            Console.WriteLine("Compressed files is " + compressedLength + " bytes");
            FileManager.CompressManyFilesIntoOneZip(sompressedNamesArr, decompressName);//розархівування
            decompressedLength = FileManager.GetBytesFromFile(decompressName).Length;
            Console.WriteLine("Decompressed file is " + decompressedLength + " bytes");




            ShowMenu();

        }

        private static void CompressManyDocFilesIntoManyZipFiles()
        {
            string outputNamesStr, inputNamesStr;
            int inputLength = 0, compressedLength = 0;
            Console.Write("Enter pathes to your doc files in this way: path1,path2,....,pathN: ");
            inputNamesStr = Console.ReadLine();//отримання шляху до вхідних даних

            string[] inputNamesArr = inputNamesStr.Split(',');
            for (int i = 0; i < inputNamesArr.Length; i++)
            {
                if (FileManager.IsCorrectName(inputNamesArr[i]) == 1)//перевірка існування файлів
                {
                    Console.WriteLine("Incorrect path for file number {0} entered!", i + 1);
                    CompressManyDocFilesIntoManyZipFiles();
                }
            }



            Console.Write("Enter pathes to your zip files in this way: path1,path2,....,pathN: ");
            outputNamesStr = Console.ReadLine();//отримання шляху до вихідних даних
            string[] outputNamesArr = outputNamesStr.Split(',');
            if (inputNamesArr.Length != outputNamesArr.Length)//перевірка відношення кількості вхідних файлів до кількості вихідних
            {
                Console.WriteLine("Count of doc files isn't equal to count of zip files!");
                CompressManyDocFilesIntoManyZipFiles();
            }
            for (int i = 0; i < inputNamesArr.Length; i++)
            {
                inputLength += FileManager.GetBytesFromFile(inputNamesArr[i]).Length;
            }
            Console.WriteLine("Input files are " + inputLength + " bytes");
            for (int i = 0; i < inputNamesArr.Length; i++)
            {
                FileManager.CompressOneFileIntoOneZip(inputNamesArr[i], outputNamesArr[i]);//стиснення даних одного файла і подальший їхній запис у відповідний йому архів
                compressedLength += FileManager.GetBytesFromFile(outputNamesArr[i]).Length;
            }
            Console.WriteLine("Compressed files are " + compressedLength + " bytes");




            ShowMenu();

        }private static void DecompressManyZipFilesIntoManyDocFiles()
        {
            string outputNamesStr, inputNamesStr;
            int inputLength = 0, decompressedLength = 0;
            Console.Write("Enter pathes to your zip files in this way: path1,path2,....,pathN: ");
            inputNamesStr = Console.ReadLine();//отримання шляху до вхідних даних

            string[] inputNamesArr = inputNamesStr.Split(',');
            for (int i = 0; i < inputNamesArr.Length; i++)
            {
                if (FileManager.IsCorrectName(inputNamesArr[i]) == 1)//перевірка існування файлів
                {
                    Console.WriteLine("Incorrect path for file number {0} entered!", i + 1);
                    DecompressManyZipFilesIntoManyDocFiles();
                }
            }



            Console.Write("Enter pathes to your doc files in this way: path1,path2,....,pathN: ");
            outputNamesStr = Console.ReadLine();//отримання шляху до вихідних даних
            string[] outputNamesArr = outputNamesStr.Split(',');
            if (inputNamesArr.Length != outputNamesArr.Length)//перевірка відношення кількості вхідних файлів до кількості вихідних
            {
                Console.WriteLine("Count of doc files isn't equal to count of zip files!");
                DecompressManyZipFilesIntoManyDocFiles();
            }
            for (int i = 0; i < inputNamesArr.Length; i++)
            {
                inputLength += FileManager.GetBytesFromFile(inputNamesArr[i]).Length;
            }
            Console.WriteLine("Compressed files are " + inputLength + " bytes");
            for (int i = 0; i < inputNamesArr.Length; i++)
            {
                FileManager.DecompressZipIntoOneFile(inputNamesArr[i], outputNamesArr[i]);//срозархівування даних одного архіва і подальший їхній запис у відповідний йому файл
                decompressedLength += FileManager.GetBytesFromFile(outputNamesArr[i]).Length;
            }
            Console.WriteLine("Decompressed files are " + decompressedLength + " bytes");




            ShowMenu();

        }

        public static void ShowMenu()
        { //перелік доступних операцій
            Console.Write("Wellcome to our Compressing Program!\n" + 
                "1) Compress one doc file into one zip file\n" +
                "2) Compress some doc files into one zip file\n" +
                "3) Compress some doc files into some zip files\n" +
                "4) Decompress one zip file into one doc file\n" +
                "5) Decompress some zip files into one doc file\n" +
                "6) Decompress some zip files into some doc files\n" +
                "0) Exit program\n" +
                "Choose your action: ");
            string input = Console.ReadLine();


            switch (input)//обробка вибору користувача
            {
                case "1":
                    CompressOneDocIntoOneZip();
                    break;
                case "2":
                    CompressSomeDocIntoOneZip();
                    break;
                case "3":
                    CompressManyDocFilesIntoManyZipFiles();
                    break;
                case "4":
                    DecompressOneZipIntoOneDoc();
                    break;
                case "5":
                    DecompressSomeZipIntoOneDoc();
                    break;
                case "6":
                    DecompressManyZipFilesIntoManyDocFiles();
                    break;
                case "0":
                    break;
                default:
                    Console.WriteLine("Choose correct option please!");
                    ShowMenu();
                    break;
            }

        }
    }
}
