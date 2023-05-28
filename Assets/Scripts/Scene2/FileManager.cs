using System.IO;
using UnityEngine;

/// <summary>
/// Application.persistentDataPath can be replaced by the desired path to the Save Location
/// </summary>
public class FileManager
{
    public static string[] ReadFromFile(string filePath, string fileEnding = ".txt") {
        if (!File.Exists($"{Application.persistentDataPath}/{filePath}{fileEnding}"))
            return new string[0];
        
        return File.ReadAllLines($"{Application.persistentDataPath}/{filePath}{fileEnding}");
    }
    public static void WriteToFile(string[] content, string filePath, string fileEnding = ".txt") {
       // if (!File.Exists($"{Application.persistentDataPath}/{filePath}{fileEnding}"))
            //File.Create($"{Application.persistentDataPath}/{filePath}{fileEnding}");

        //File.WriteAllLines($"{Application.persistentDataPath}/{filePath}{fileEnding}", content);
        using (StreamWriter writer = new StreamWriter($"{Application.persistentDataPath}/{filePath}{fileEnding}"))
        {
            writer.Write(content[0]);
        }

    }
    public static void Delete(string filePath, string fileEnding = ".txt")
    {
        if (!File.Exists($"{Application.persistentDataPath}/{filePath}{fileEnding}"))
            return;

        File.Delete($"{Application.persistentDataPath}/{filePath}{fileEnding}");
    }
}
