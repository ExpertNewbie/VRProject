using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveDataManager : AbsDataManager<SaveData>
{
    public static SaveData data = new SaveData();
    public int PlayerNumber = 0;
    void Start()
    {
        data = LoadData();
    }
    public override SaveData LoadData()
    {
        string path = Application.persistentDataPath + $"/save_data_{PlayerNumber}.dat";
        SaveData datas = new SaveData(true);
        if(File.Exists(path))
        {
            FileStream fileStream = File.OpenRead(path);
            BinaryFormatter bf = new BinaryFormatter();
            datas = (SaveData) bf.Deserialize(fileStream);
            fileStream.Close();
        }
        return datas;
    }
    public override void SaveData()
    {
        SaveData(new SaveData(true));
    }
    public override void SaveData(SaveData inputData)
    {
        string path = Application.persistentDataPath + $"/save_data_{PlayerNumber}.dat";
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
        data = inputData;
        fileStream.Close();
    }
    void OnDestroy()
    {
        SaveData(data);
    }
}
