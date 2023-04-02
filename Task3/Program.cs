using Task1;

bool exit = false;
while (!exit)
{
    Console.WriteLine("\nВведите путь к папке, которую Вы хотите очистить:");
    string folderPath = Console.ReadLine();
    DirectoryInfo directroyInfo = new DirectoryInfo(folderPath);
    if (directroyInfo.Exists)
    {
        string answer;
        do
        {
            Console.WriteLine("Вы уверены что хотите очистить папку: {0}", folderPath);
            Console.WriteLine("Да или нет?");
            answer = Console.ReadLine().ToUpper();
        } while (!(answer.Contains("ДА") || answer.Contains("НЕТ")));

        switch (answer)
        {
            case "ДА":
                try
                {
                    long directorySize = DirectoryExtention.GetDirectorySize(directroyInfo);
                    long deletedFilesSize = DirectoryExtention.DeleteAllFilesInDirectory(directroyInfo);
                    Console.WriteLine($"\nИсходный размер папки: {directorySize} байт");
                    Console.WriteLine($"Размер удаленных файлов: {deletedFilesSize} байт");
                    Console.WriteLine($"Текущий размер папки: {directorySize} байт");
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
        Console.WriteLine("Ошибка: по заданному адресу папка не существует.");
    }
}
Console.ReadKey();
