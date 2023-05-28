using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class GameServer : MonoBehaviour
{
    public string filename = "savedata";
    
    SaveData saveData;

    public void Save()
    {
        var json = JsonUtility.ToJson(saveData);
        var filePath =  filename;
        FileManager.WriteToFile(new string[] {json}, filePath);
    }    

    public SaveData Load()
    {
        var filePath = filename;
        var json = FileManager.ReadFromFile(filePath);
        saveData = JsonUtility.FromJson<SaveData>(json.ElementAtOrDefault(0));
        return saveData;
    }

    public void UpdateData(SaveData saveD)
    {
        saveData = saveD; 
    }
}
