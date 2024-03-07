
using System;
using System.IO;
using System.Runtime.InteropServices;


Console.Write("Pfad: ");
string sourcePfad = Console.ReadLine();

Console.Write("Ziel: ");
string zielPfad = Console.ReadLine();


CheckTimestampsInFolder(sourcePfad, zielPfad);

static string CreateFolder(DateTime timeStamp, string zielPfad)
{
    string output = null;
    string targetPfad = $"{zielPfad}\\{timeStamp.Month}\\{timeStamp.Day}";
    try
    {
        if (!Directory.Exists(targetPfad))
        {
            Directory.CreateDirectory(targetPfad);
            output = targetPfad;
        }
        else
        {
            Console.WriteLine("Folder already exists.");
        }
    }
    catch (Exception ex)
    {
        throw new Exception($"Error creating folder: {ex.Message}");
    }
    return output;
}

static void MoveFileToFolder(string file, DateTime timeStamp, string zielPfad)
{
   
    string targetPfad = $"{zielPfad}\\{timeStamp.Month}\\{timeStamp.Day}\\{timeStamp.Day}{timeStamp.Month}{timeStamp.Year}_{timeStamp.Hour}{timeStamp.Second}.jpg";

    
    File.Copy(file, targetPfad, true);

}

static void CheckTimestampsInFolder(string sourcePfad, string zielPfad)
{
    try
    {
        if (Directory.Exists(sourcePfad))
        {
            string[] files = Directory.GetFiles(sourcePfad);

            foreach (string file in files)
            {
                DateTime timeStamp = Directory.GetLastWriteTime(file);
                CreateFolder(timeStamp, zielPfad);
                MoveFileToFolder(file, timeStamp, zielPfad);
            }


        }
        else
        {
            Console.WriteLine("pfad leer");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
}
