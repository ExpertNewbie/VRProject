using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    SaveDataManager saveDataManager;
    SettingDataManager settingDataManager;
    GameBaseData baseData;
    public SaveData SaveData { get; private set; }
    public SettingData SettingData { get; private set; }
    public float WeaponPower { get; private set; }
    public float WeaponEfficiency { get; private set; }
    public float WeaponCharge { get; private set; }
    public float JetpackPower { get; private set; }
    public float JetpackEfficiency { get; private set; }
    public float JetpackCharge { get; private set; }
    public float Speed { get; private set; }
    public float Booster { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        settingDataManager = new SettingDataManager();
        this.SettingData = settingDataManager.LoadData();
        saveDataManager = new SaveDataManager();
        this.SaveData = saveDataManager.LoadData();
        baseData = GameBaseData.Instance();
        SetUpgradeData();
    }
    // Update is called once per frame
    void Update()
    {
    }
    void OnDestroy()
    {
        // settingDataManager.SaveData(settingData);
        // saveDataManager.SaveData(saveData);
    }
    public void DataToSettingData(SettingData data)
    {
        this.SettingData = data;
        settingDataManager.SaveData(data);
    }
    public void DataToSaveData(SaveData data)
    {
        this.SaveData = data;
        saveDataManager.SaveData(data);
        SetUpgradeData();
    }
    void SetUpgradeData()
    {
        WeaponPower = baseData.StateUpgradeWeaponDamage(this.SaveData.UpgradeWeaponDamageState);
        WeaponEfficiency = baseData.StateUpgradeWeaponEfficiency(this.SaveData.UpgradeWeaponEfficiencyState);
        WeaponCharge = baseData.StateUpgradeWeaponCharge(this.SaveData.UpgradeWeaponChargeState);
        JetpackPower = baseData.StateUpgradeJetpackPower(this.SaveData.UpgradeJetpackPowerState);
        JetpackEfficiency = baseData.StateUpgradeJetpackEfficiency(this.SaveData.UpgradeJetpackEfficiencyState);
        JetpackCharge = baseData.StateUpgradeJetpackCharge(this.SaveData.UpgradeJetpackChargeState);
        Speed = baseData.StateUpgradeSpeedStrength(this.SaveData.UpgradeSpeedStrengthState);
        Booster = baseData.StateUpgradeSpeedBooster(this.SaveData.UpgradeSpeedBoosterState);
    }
}
