using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SettingDataManager : AbsDataManager<SettingData>
{
    public SettingDataManager()
    {
    }
    public override SettingData LoadData()
    {
        string path = Application.persistentDataPath + "/setting_data.txt";
        SettingData data = new SettingData(true);
        if(File.Exists(path))
        {
            FileStream fileStream = File.OpenRead(path);
            BinaryFormatter bf = new BinaryFormatter();
            data = (SettingData) bf.Deserialize(fileStream);
            fileStream.Close();
        }
        return data;
    }
    public override void SaveData()
    {
        SaveData(new SettingData(true));
    }
    public override void SaveData(SettingData inputData)
    {
        string path = Application.persistentDataPath + "/setting_data.txt";
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
