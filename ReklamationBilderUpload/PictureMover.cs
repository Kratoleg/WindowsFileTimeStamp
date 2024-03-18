using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReklamationBilderUpload;

class PictureMover
{
    private string _sourceDir { get; }
    private string _destinationDir { get; }

    public PictureMover(string sourceDir, string destDir)
    {
        _sourceDir = sourceDir;
        _destinationDir = destDir;

    }
    private string CreateFolder(DateTime timeStamp, string _destinationDir)
    {
        string output = null;
        string targetPfad = $"{_destinationDir}\\{timeStamp.Year}\\{timeStamp.Month}\\{timeStamp.Day}";
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
    private void MoveFileToFolder(string file, DateTime timeStamp, string _destinationDir)
    {

        string targetPfad = $"{_destinationDir}\\{timeStamp.Year}\\{timeStamp.Month}\\{timeStamp.Day}\\{timeStamp.Day}{timeStamp.Month}{timeStamp.Year}_{timeStamp.Hour}{timeStamp.Second}.jpg";

        if(File.Exists(targetPfad) == false)
        {
            File.Copy(file, targetPfad, true);
        }

    }
    public void MoveEverything()
    {

        try
        {
            if (Directory.Exists(_sourceDir))
            {
                string[] files = Directory.GetFiles(_sourceDir);

                foreach (string file in files)
                {
                    DateTime timeStamp = Directory.GetLastWriteTime(file);
                    CreateFolder(timeStamp, _destinationDir);
                    MoveFileToFolder(file, timeStamp, _destinationDir);
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

}
