using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBaseData
{
    ///////////////////////////////////////////////////////////////////////////////// Contruct
    private static GameBaseData instance;
    public static GameBaseData Instance()
    {
        if(instance == null)
            instance = new GameBaseData();
        return instance;
    }
    private GameBaseData()
    {
        //////////////////////////////////////////////////////////////////// Color Image
        ColorUtility.TryParseHtmlString("#46FF00", out ImageColor_Green);
        ColorUtility.TryParseHtmlString("#FF5200", out ImageColor_Yellow);
        ColorUtility.TryParseHtmlString("#FFA300", out ImageColor_Orange);
        ColorUtility.TryParseHtmlString("#FF001A", out ImageColor_Red);
        //////////////////////////////////////////////////////////////////// Color Image END
        //////////////////////////////////////////////////////////////////// Color Text
        ColorUtility.TryParseHtmlString("#34D149", out TextColor_Green);
        ColorUtility.TryParseHtmlString("#FFFF00", out TextColor_Yellow);
        ColorUtility.TryParseHtmlString("#FF9900", out TextColor_Orange);
        ColorUtility.TryParseHtmlString("#FF0007", out TextColor_Red);
        //////////////////////////////////////////////////////////////////// Color Text END
    }
    ///////////////////////////////////////////////////////////////////////////////// Contruct END
    ///////////////////////////////////////////////////////////////////////////////// Timer
    Time time;
    public Time GameTimer()
    {
        return time;
    }
    ///////////////////////////////////////////////////////////////////////////////// Timer END
    ///////////////////////////////////////////////////////////////////////////////// Select Color
    Color ImageColor_Green; Color ImageColor_Yellow; Color ImageColor_Orange; Color ImageColor_Red;
    Color TextColor_Green; Color TextColor_Yellow; Color TextColor_Orange; Color TextColor_Red;
    public Color SelectTextImage(float quantity) => quantity switch
    {
        var a when a >= 75.0f => ImageColor_Green,
        var a when a >= 50.0f => ImageColor_Yellow,
        var a when a >= 25.0f => ImageColor_Orange,
        _ => ImageColor_Red
    };
    public Color SelectTextColor(float quantity) => quantity switch
    {
        var a when a >= 75.0f => TextColor_Green,
        var a when a >= 50.0f => TextColor_Yellow,
        var a when a >= 25.0f => TextColor_Orange,
        _ => TextColor_Red,
    };
    ///////////////////////////////////////////////////////////////////////////////// Select Color END
    ///////////////////////////////////////////////////////////////////////////////// Upgrade Data
    const float max = 100.0f;
    const float oneMinute = 60.0f;
    const float initialWeaponPower = 5.0f;
    const float initialJetpackPower = 0.6f;
    const float initialSpeed = 4.0f;
    const float initialBooster = 0.0f;
    //////////////////////////////////////////////////////////////////// Upgrade Weapon
    public float StateUpgradeWeaponDamage(SaveData.UpgradeWeaponDamage state) => state switch
    {
        SaveData.UpgradeWeaponDamage.Upgrade_5 => initialWeaponPower + (2 * 5), // Damage 15
        SaveData.UpgradeWeaponDamage.Upgrade_4 => initialWeaponPower + (2 * 4),
        SaveData.UpgradeWeaponDamage.Upgrade_3 => initialWeaponPower + (2 * 3),
        SaveData.UpgradeWeaponDamage.Upgrade_2 => initialWeaponPower + (2 * 2),
        SaveData.UpgradeWeaponDamage.Upgrade_1 => initialWeaponPower + (2 * 1),
        _ => initialWeaponPower,                                                // Damage 5
    };
    public float StateUpgradeWeaponEfficiency(SaveData.UpgradeWeaponEfficiency state) => state switch
    {
        SaveData.UpgradeWeaponEfficiency.Upgrade_5 => max / 20.0f,  // Use 20 Times
        SaveData.UpgradeWeaponEfficiency.Upgrade_4 => max / 18.0f,
        SaveData.UpgradeWeaponEfficiency.Upgrade_3 => max / 16.0f,
        SaveData.UpgradeWeaponEfficiency.Upgrade_2 => max / 14.0f,
        SaveData.UpgradeWeaponEfficiency.Upgrade_1 => max / 12.0f,
        _ => max / 10.0f,                                           // Use 10 Times
    };
    public float StateUpgradeWeaponCharge(SaveData.UpgradeWeaponCharge state) => state switch
    {
        SaveData.UpgradeWeaponCharge.Upgrade_5 => max / (oneMinute - (3 * 5)),  // Full Charge 45 sec
        SaveData.UpgradeWeaponCharge.Upgrade_4 => max / (oneMinute - (3 * 4)),
        SaveData.UpgradeWeaponCharge.Upgrade_3 => max / (oneMinute - (3 * 3)),
        SaveData.UpgradeWeaponCharge.Upgrade_2 => max / (oneMinute - (3 * 2)),
        SaveData.UpgradeWeaponCharge.Upgrade_1 => max / (oneMinute - (3 * 1)),
        _ => max / oneMinute,                                                   // Full Charge 60 sec
    };
    //////////////////////////////////////////////////////////////////// Upgrade Weapon END
    //////////////////////////////////////////////////////////////////// Upgrade Jetpack
    public float StateUpgradeJetpackPower(SaveData.UpgradeJetpackPower state) => state switch
    {
        SaveData.UpgradeJetpackPower.Upgrade_5 => initialJetpackPower * 6.0f,   // Power 3.6
        SaveData.UpgradeJetpackPower.Upgrade_4 => initialJetpackPower * 5.0f,
        SaveData.UpgradeJetpackPower.Upgrade_3 => initialJetpackPower * 4.0f,
        SaveData.UpgradeJetpackPower.Upgrade_2 => initialJetpackPower * 3.0f,
        SaveData.UpgradeJetpackPower.Upgrade_1 => initialJetpackPower * 2.0f,
        _ => initialJetpackPower,                                               // Power 0.6
    };
    public float StateUpgradeJetpackEfficiency(SaveData.UpgradeJetpackEfficiency state) => state switch
    {
        SaveData.UpgradeJetpackEfficiency.Upgrade_5 => max / oneMinute,             // Use 60 sec
        SaveData.UpgradeJetpackEfficiency.Upgrade_4 => max /(oneMinute - (6 * 1)),
        SaveData.UpgradeJetpackEfficiency.Upgrade_3 => max /(oneMinute - (6 * 2)),
        SaveData.UpgradeJetpackEfficiency.Upgrade_2 => max /(oneMinute - (6 * 3)),
        SaveData.UpgradeJetpackEfficiency.Upgrade_1 => max /(oneMinute - (6 * 4)),
        _ => max / (oneMinute - (6 * 5)),                                           // Use 30 sec
    };
    public float StateUpgradeJetpackCharge(SaveData.UpgradeJetpackCharge state) => state switch
    {
        SaveData.UpgradeJetpackCharge.Upgrade_5 => max / (oneMinute - (3 * 5)), // Full Charge 45 sec
        SaveData.UpgradeJetpackCharge.Upgrade_4 => max / (oneMinute - (3 * 4)),
        SaveData.UpgradeJetpackCharge.Upgrade_3 => max / (oneMinute - (3 * 3)),
        SaveData.UpgradeJetpackCharge.Upgrade_2 => max / (oneMinute - (3 * 2)),
        SaveData.UpgradeJetpackCharge.Upgrade_1 => max / (oneMinute - (3 * 1)),
        _ => max / oneMinute,                                                   // Full Charge 60 sec
    };
    //////////////////////////////////////////////////////////////////// Upgrade Jetpack END
    //////////////////////////////////////////////////////////////////// Upgrade Speed
    public float StateUpgradeSpeedStrength(SaveData.UpgradeSpeedStrength state) => state switch
    {
        SaveData.UpgradeSpeedStrength.Upgrade_5 => initialSpeed * 2.0f, // Speed 8.0
        SaveData.UpgradeSpeedStrength.Upgrade_4 => initialSpeed * 1.8f,
        SaveData.UpgradeSpeedStrength.Upgrade_3 => initialSpeed * 1.6f,
        SaveData.UpgradeSpeedStrength.Upgrade_2 => initialSpeed * 1.4f,
        SaveData.UpgradeSpeedStrength.Upgrade_1 => initialSpeed * 1.2f,
        _ => initialSpeed,                                              // Speed 4.0
    };
    public float StateUpgradeSpeedBooster(SaveData.UpgradeSpeedBooster state) => state switch
    {
        SaveData.UpgradeSpeedBooster.Upgrade_5 => initialBooster + 3.0f,    // Booster 3.0
        SaveData.UpgradeSpeedBooster.Upgrade_4 => initialBooster + 2.5f,
        SaveData.UpgradeSpeedBooster.Upgrade_3 => initialBooster + 2.0f,
        SaveData.UpgradeSpeedBooster.Upgrade_2 => initialBooster + 1.5f,
        SaveData.UpgradeSpeedBooster.Upgrade_1 => initialBooster + 1.0f,
        _ => initialBooster,                                                // Booster 0.0
    };
    //////////////////////////////////////////////////////////////////// Upgrade Speed END
    ///////////////////////////////////////////////////////////////////////////////// Upgrade Data END
    ///////////////////////////////////////////////////////////////////////////////// Duck Data
    public class MonsterData
    {
        public MonsterData(int gold, int count, float hP, float speed, float runPower,
                            bool isBoss = false, bool effect = false)
        {
            Gold = gold;
            Count = count;
            HP = hP;
            Speed = speed;
            RunPower = runPower;
            IsBoss = IsBoss;
            Effect = effect;
        }
        public int Gold { get; private set; }
        public int Count { get; private set; }
        public float HP { get; private set; }
        public float Speed { get; private set; }
        public float RunPower { get; private set; }
        public bool IsBoss { get; private set;}
        public bool Effect { get; private set;}
    } 
    const int initialGold = 10;
    const int initialDefaultCount = 1;
    const float initailDuckHP = 10.0f;
    const float initialDuckSpeed = 3.0f;
    const float initialDuckRunPower = 5.0f;
    public MonsterData GetDuckData(string duckName)
    {
        int gold = (int) Mathf.Floor(SelectDuckGoldData(duckName));
        int count = SelectDuckCountData(duckName);
        float hP = SelectDuckHPData(duckName);
        float speed = SelectDuckSpeedData(duckName);
        float runPower = SelectDuckRunPowerData(duckName);
        bool isBoss = SelectDuckBossData(duckName);
        bool effect = SelectDuckEffectData(duckName);
        MonsterData md =  new MonsterData(gold, count, hP, speed, runPower, isBoss, effect);
        return md;
    }
    float SelectDuckGoldData(string duckName) => duckName switch
    {
        var a when a.Contains("Ink") => initialGold * 1.5f,
        var a when a.Contains("Speedy") => initialGold * 1.5f,
        var a when a.Contains("HP") => initialGold * 2.0f,
        var a when a.Contains("Twin") => initialGold * 2.5f,
        var a when a.Contains("Pond") => initialGold * 2.0f,
        var a when a.Contains("Gold") => initialGold * 30.0f,
        var a when a.Contains("Max") => initialGold * 1.5f,
        var a when a.Contains("Half") => initialGold * 1.5f,
        var a when a.Contains("Time") => initialGold * 1.5f,
        var a when a.Contains("Boss") => initialGold * 15.0f,
        _ => initialGold,
    };
    int SelectDuckCountData(string duckName) => duckName switch
    {
        var a when a.Contains("Gold") => 0,
        var a when a.Contains("Max") => 0,
        var a when a.Contains("Half") => 0,
        var a when a.Contains("Time") => 0,
        _ => initialDefaultCount,
    };
    float SelectDuckHPData(string duckName) => duckName switch
    {
        var a when a.Contains("Ink") => initailDuckHP * 2.0f,
        var a when a.Contains("HP") => initailDuckHP * 5.0f,
        var a when a.Contains("Twin") => initailDuckHP * 2.0f,
        var a when a.Contains("Pond") => initailDuckHP * 3.0f,
        var a when a.Contains("Gold") => initailDuckHP * 2.0f,
        var a when a.Contains("Max") => initailDuckHP * 2.0f,
        var a when a.Contains("Half") => initailDuckHP * 2.0f,
        var a when a.Contains("Time") => initailDuckHP * 2.0f,
        var a when a.Contains("Large") => initailDuckHP * 10.0f,
        var a when a.Contains("Boss") => initailDuckHP * 20.0f,
        _ => initailDuckHP,
    };
    float SelectDuckSpeedData(string duckName) => duckName switch
    {
        var a when a.Contains("Speedy") => initialSpeed * 3.0f,
        var a when a.Contains("Twin") => initialSpeed * 1.5f,
        var a when a.Contains("Pond") => initialSpeed * 2.0f,
        var a when a.Contains("Gold") => initialSpeed * 2.0f,
        var a when a.Contains("Max") => initialSpeed * 2.0f,
        var a when a.Contains("Half") => initialSpeed * 2.0f,
        var a when a.Contains("Time") => initialSpeed * 2.0f,
        var a when a.Contains("Large") => initialSpeed / 2.0f,
        var a when a.Contains("Boss") => initialSpeed / 2.5f,
        _ => initialSpeed,
    };
    float SelectDuckRunPowerData(string duckName) => duckName switch
    {
        var a when a.Contains("Speedy") => initialDuckRunPower + 5.0f,
        var a when a.Contains("Twin") => initialDuckRunPower + 2.0f,
        var a when a.Contains("Pond") => initialDuckRunPower + 2.0f,
        var a when a.Contains("Gold") => initialDuckRunPower + 2.0f,
        var a when a.Contains("Max") => initialDuckRunPower + 2.0f,
        var a when a.Contains("Half") => initialDuckRunPower + 2.0f,
        var a when a.Contains("Time") => initialDuckRunPower + 2.0f,
        var a when a.Contains("Large") => initialDuckRunPower - 2.5f,
        var a when a.Contains("Boss") => 1.0f,
        _ => initialDuckRunPower,
    };
    bool SelectDuckBossData(string duckName) => duckName switch
    {
        var a when a.Contains("Boss") => true,
        _ => false,
    };
    bool SelectDuckEffectData(string duckName) => duckName switch
    {
        var a when a.Contains("Ink") => true,
        var a when a.Contains("Gold") => true,
        var a when a.Contains("Max") => true,
        var a when a.Contains("Half") => true,
        var a when a.Contains("Time") => true,
        var a when a.Contains("Boss") => true,
        _ => false,
    };
    ///////////////////////////////////////////////////////////////////////////////// Duck Data END
}
