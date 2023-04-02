using System.Threading.Tasks;
using Task1;

bool exit = false;
while (!exit)
{
    Console.WriteLine("\nВведите путь к папке, размер которой Вы хотите узнать:");
    string folderPath = Console.ReadLine();
    DirectoryInfo directroyInfo = new DirectoryInfo(folderPath);
    if (directroyInfo.Exists)
    {
        try
        {
            long directorySize = DirectoryExtention.GetDirectorySize(directroyInfo);
            Console.WriteLine("Операция завершена.");
            Console.WriteLine($"Размер папки: {directorySize} байт");
            exit = true;
        }
        catch (Exception e)
        {
            Console.WriteLine("Операция не выполнена. Ошибка: " + e.Message);
        }
    }
    else
    {
        Console.WriteLine("Ошибка. По заданному адресу папка не существует.");
    }
}
Console.ReadKey();