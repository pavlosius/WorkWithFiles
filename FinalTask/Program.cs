using FinalTask;

string fileName = "Students.dat";
BinaryFileIO.ReadStudentsDataFile(fileName);
string DirectoryName = "Students";
string directoryPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), DirectoryName);
Directory.CreateDirectory(directoryPath);
BinaryFileIO.WriteStudentsData(directoryPath);
Console.ReadKey();
