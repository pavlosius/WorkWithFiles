using System.IO;
using Task1;

bool exit = false;
while (!exit)
{
    Console.WriteLine("\nВведите путь к папке, в которой хотите удалить все файлы, которые не использовались 30 мин:");
    string folderPath = Console.ReadLine();
    DirectoryInfo directroyInfo = new DirectoryInfo(folderPath);
    if (directroyInfo.Exists)
    {
        string answer;
        do
        {
            Console.WriteLine("Вы уверены что хотите удалить файлы, которые не использовались 30 мин, в папке: {0}", folderPath);
            Console.WriteLine("Да или нет?");
            answer = Console.ReadLine().ToUpper();
        } while (!(answer.Contains("ДА") || answer.Contains("НЕТ")));
        
        switch (answer)
        {
            case "ДА":
                try
                {
                    long deletedFilesCount = DirectoryExtention.DeleteAllFilesInDirectory(directroyInfo);
                    Console.WriteLine("Операция завершена.");
                    Console.WriteLine($"Размер удаленных файлов: {deletedFilesCount} байт");
                    exit = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Операция не выполнена. Ошибка: " + e.Message);
                }
                break;
            default:
                break;
        }
    }
    else
    {
        Console.WriteLine("Ошибка. По заданному адресу папка не существует.");
    }
}
Console.ReadKey();






