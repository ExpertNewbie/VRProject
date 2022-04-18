using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    SaveDataManager saveDataManager;        // In Game Data
    SettingDataManager settingDataManager;  // Game Setting Data
    SaveData saveData;
    SettingData settingData;
    // Start is called before the first frame update
    void Start()
    {
        // saveDataManager = new SaveDataManager();
        // settingDataManager = new SettingDataManager();
        // saveData = saveDataManager.LoadData();
        // settingData = settingDataManager.LoadData();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void OnDestroy()
    {
        // saveDataManager.SaveData(saveData);
        // settingDataManager.SaveData(settingData);
    }
    void SetSaveData()
    {
    }
}
