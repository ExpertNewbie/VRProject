using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveDataManager : AbsDataManager<SaveData>
{
    public int PlayerNumber = 0;
    public SaveDataManager()
    {
    }
    public override SaveData LoadData()
    {
        string path = Application.persistentDataPath + $"/save_data_{PlayerNumber}.txt";
        SaveData data = new SaveData(false);
        if(File.Exists(path))
        {
            FileStream fileStream = File.OpenRead(path);
            BinaryFormatter bf = new BinaryFormatter();
            data = (SaveData) bf.Deserialize(fileStream);
            fileStream.Close();
        }
        return data;
    }
    public override void SaveData()
    {
        SaveData(new SaveData(false));
    }
    public override void SaveData(SaveData inputData)
    {
        string path = Application.persistentDataPath + $"/save_data_{PlayerNumber}.txt";
        FileStream fileStream;
        if(File.Exists(path))
        {
            fileStream = File.OpenWrite(path);
        }
        else
        {
            fileStream = File.Create(path);
        }
        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(fileStream, inputData);
        fileStream.Close();
    }
}
