using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SettingDataManager : AbsDataManager<SettingData>
{
    SettingData data = new SettingData();
    void Start()
    {
        LoadData();
    }
    public override SettingData LoadData()
    {
        string path = Application.persistentDataPath + "/setting_data.dat";
        SettingData datas = new SettingData(true);
        if(File.Exists(path))
        {
            FileStream fileStream = File.OpenRead(path);
            BinaryFormatter bf = new BinaryFormatter();
            datas = (SettingData) bf.Deserialize(fileStream);
            fileStream.Close();
        }
        return datas;
    }
    public override void SaveData()
    {
        SaveData(new SettingData(true));
    }
    public override void SaveData(SettingData inputData)
    {
        string path = Application.persistentDataPath + "/setting_data.dat";
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
