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
    PlayerMove playerMove;
    GunController gunRightController;
    GunController gunLeftController;
    // Start is called before the first frame update
    void Start()
    {
        settingDataManager = new SettingDataManager();
        this.SettingData = settingDataManager.LoadData();
        saveDataManager = new SaveDataManager();
        this.SaveData = saveDataManager.LoadData();
        baseData = GameBaseData.Instance();
        ResetGame();
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
    public void ResetGame()
    {
        SetUpgradeData();
        AddGold = 0;
        killCount = 0;
        KillCountBoss = 0;
        playerMove = GameObject.Find("Player").GetComponent<PlayerMove>();
        gunRightController = GameObject.Find("WaterGunRight").GetComponent<GunController>();
        gunLeftController = GameObject.Find("WaterGunLeft").GetComponent<GunController>();
        // Test
        InPlayState = GameStateInPlay.Play; 
Debug.Log("InPlayState : "+InPlayState);
    }
    public void Charging(bool isInWater)
    {
        playerMove.isInWater = isInWater;
        gunRightController.isInWater = isInWater;
        gunLeftController.isInWater = isInWater;
    }
    ///////////////////////////////////////////////////////////////////////////////// Upgrade Info
    public float WeaponPower { get; private set; }
    public float WeaponEfficiency { get; private set; }
    public float WeaponCharge { get; private set; }
    public float JetpackPower { get; private set; }
    public float JetpackEfficiency { get; private set; }
    public float JetpackCharge { get; private set; }
    public float Speed { get; private set; }
    public float Booster { get; private set; }
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
    ///////////////////////////////////////////////////////////////////////////////// Upgrade Info END
    ///////////////////////////////////////////////////////////////////////////////// Duck Info
    public int AddGold { get; private set; }
    public int killCount { get; private set; }
    public int KillCountBoss { get; private set; }
    public void PlusAddGold(int gold) { AddGold += gold; }
    public void PlusKillCount(int killCount) { killCount += killCount; }
    public void PlusKillCountBoss(int killCount) { KillCountBoss += killCount; }
    public void DuckScriptEffect(string duckName)
    {
        string methodName = FindScriptEffectForName(duckName);
        if(methodName != null)
            Invoke(methodName, 0f);
    }
    string FindScriptEffectForName(string duckName) => duckName switch
    {
        var a when a.Contains("Max") => "DuckSPMaxScriptEffct",
        var a when a.Contains("Half") => "DuckSPHalfScriptEffct",
        var a when a.Contains("Time") => "DuckSPTimeScriptEffct",
        var a when a.Contains("Boss") => "DuckSPBossScriptEffct",
        _ => null
    };
    void DuckSPMaxScriptEffct()
    {
Debug.Log("DuckSP Max ScriptEffct");
        playerMove.BonusChargeMax();
        gunRightController.BonusChargeMax();
        gunLeftController.BonusChargeMax();
    }
    void DuckSPHalfScriptEffct()
    {
Debug.Log("DuckSP Half ScriptEffct");
        playerMove.BonusCharge();
        gunRightController.BonusCharge();
        gunLeftController.BonusCharge();
    }
    void DuckSPTimeScriptEffct()
    {
        // Time Limit
Debug.Log("DuckSP Time ScriptEffct");
    }
    void DuckSPBossScriptEffct()
    {
        // Summoned Lower Monster
Debug.Log("DuckSP Boss ScriptEffct");
    }
    ///////////////////////////////////////////////////////////////////////////////// Duck Info END
    ///////////////////////////////////////////////////////////////////////////////// GameState Info
    public enum GameState
    {
        Menu,
        Training,
        Playing
    }
    public enum GameStateInPlay
    {
        NoPlay,
        Start,
        Play,
        Pause,
        End
    }
    GameState InGameState;
    GameStateInPlay InPlayState;
    public bool isGameStateMenu { get {return InGameState == GameState.Menu;} }
    public bool isGameStateTraning { get {return InGameState == GameState.Training;} }
    public bool isGameStatePlaying { get {return InGameState == GameState.Playing;} }
    public bool isPlayStateNoPlay { get {return InPlayState == GameStateInPlay.NoPlay;} }
    public bool isPlayStateStart { get {return InPlayState == GameStateInPlay.Start;} }
    public bool isPlayStatePlay { get {return InPlayState == GameStateInPlay.Play;} }
    public bool isPlayStatePause { get {return InPlayState == GameStateInPlay.Pause;} }
    public bool isPlayStateEnd { get {return InPlayState == GameStateInPlay.End;} }
    public void InGameStateChange(GameState state)
    {
        InGameState = state;
        switch(InGameState)
        {
            case GameState.Menu : 
                InPlayState = GameStateInPlay.NoPlay;
                Debug.Log("GameState.Menu");
                break;
            case GameState.Playing : 
                // InPlayState = GameStateInPlay.Start;
                Debug.Log("GameState.Playing");
                break;
            case GameState.Training : 
                // InPlayState = GameStateInPlay.Start;
                Debug.Log("GameState.Training");
                break;
        }
    }
    public void InGameStateInPlayChange(GameStateInPlay state)
    {
        InPlayState = state;
        switch(InPlayState)
        {
            case GameStateInPlay.NoPlay :
                Debug.Log("GameStateInPlay.NoPlay");
                break;
            case GameStateInPlay.Start :
                Debug.Log("GameStateInPlay.Start");
                break;
            case GameStateInPlay.Play :
                Debug.Log("GameStateInPlay.Play");
                // 게임 일시중지 해제
                // 플레이어 움직임 금지 해제
                // 타겟 불가시 해제
                break;
            case GameStateInPlay.Pause :
                Debug.Log("GameStateInPlay.Pause");
                // 게임 일시중지
                // 플레이어 움직임 금지
                // 타겟 불가시
                break;
            case GameStateInPlay.End :
                Debug.Log("GameStateInPlay.End");
                // 게임 일시중지
                // UI Activate
                // 플레이어 움직임 금지
                // 오리 돌아다니면서 비틱질
                break;
        }
    }
    ///////////////////////////////////////////////////////////////////////////////// GameState Info END
}
