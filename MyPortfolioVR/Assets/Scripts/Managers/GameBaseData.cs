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
    const float initialWeaponPower = 6.0f;
    const float initialJetpackPower = 0.5f;
    const float initialSpeed = 4.0f;
    const float initialBooster = 0.0f;
    //////////////////////////////////////////////////////////////////// Upgrade Weapon
    public float StateUpgradeWeaponDamage(SaveData.UpgradeWeaponDamage state) => state switch
    {
        SaveData.UpgradeWeaponDamage.Upgrade_5 => initialWeaponPower * 3.0f,
        SaveData.UpgradeWeaponDamage.Upgrade_4 => initialWeaponPower * 2.5f,
        SaveData.UpgradeWeaponDamage.Upgrade_3 => initialWeaponPower * 2.0f,
        SaveData.UpgradeWeaponDamage.Upgrade_2 => initialWeaponPower * 1.7f,
        SaveData.UpgradeWeaponDamage.Upgrade_1 => initialWeaponPower * 1.35f,
        _ => initialWeaponPower,
    };
    public float StateUpgradeWeaponEfficiency(SaveData.UpgradeWeaponEfficiency state) => state switch
    {
        SaveData.UpgradeWeaponEfficiency.Upgrade_5 => max / 25.0f,
        SaveData.UpgradeWeaponEfficiency.Upgrade_4 => max / 24.0f,
        SaveData.UpgradeWeaponEfficiency.Upgrade_3 => max / 23.0f,
        SaveData.UpgradeWeaponEfficiency.Upgrade_2 => max / 22.0f,
        SaveData.UpgradeWeaponEfficiency.Upgrade_1 => max / 21.0f,
        _ => max / 20.0f,
    };
    public float StateUpgradeWeaponCharge(SaveData.UpgradeWeaponCharge state) => state switch
    {
        SaveData.UpgradeWeaponCharge.Upgrade_5 => oneMinute - (3 * 5),
        SaveData.UpgradeWeaponCharge.Upgrade_4 => oneMinute - (3 * 4),
        SaveData.UpgradeWeaponCharge.Upgrade_3 => oneMinute - (3 * 3),
        SaveData.UpgradeWeaponCharge.Upgrade_2 => oneMinute - (3 * 2),
        SaveData.UpgradeWeaponCharge.Upgrade_1 => oneMinute - (3 * 1),
        _ => oneMinute,
    };
    //////////////////////////////////////////////////////////////////// Upgrade Weapon END
    //////////////////////////////////////////////////////////////////// Upgrade Jetpack
    public float StateUpgradeJetpackPower(SaveData.UpgradeJetpackPower state) => state switch
    {
        SaveData.UpgradeJetpackPower.Upgrade_5 => initialJetpackPower * 10.0f,
        SaveData.UpgradeJetpackPower.Upgrade_4 => initialJetpackPower * 8.0f,
        SaveData.UpgradeJetpackPower.Upgrade_3 => initialJetpackPower * 6.0f,
        SaveData.UpgradeJetpackPower.Upgrade_2 => initialJetpackPower * 4.0f,
        SaveData.UpgradeJetpackPower.Upgrade_1 => initialJetpackPower * 2.0f,
        _ => initialJetpackPower,
    };
    public float StateUpgradeJetpackEfficiency(SaveData.UpgradeJetpackEfficiency state) => state switch
    {
        SaveData.UpgradeJetpackEfficiency.Upgrade_5 => max / (oneMinute + (6 * 5)),
        SaveData.UpgradeJetpackEfficiency.Upgrade_4 => max / (oneMinute + (6 * 4)),
        SaveData.UpgradeJetpackEfficiency.Upgrade_3 => max / (oneMinute + (6 * 3)),
        SaveData.UpgradeJetpackEfficiency.Upgrade_2 => max / (oneMinute + (6 * 2)),
        SaveData.UpgradeJetpackEfficiency.Upgrade_1 => max / (oneMinute + (6 * 1)),
        _ => max / oneMinute,
    };
    public float StateUpgradeJetpackCharge(SaveData.UpgradeJetpackCharge state) => state switch
    {
        SaveData.UpgradeJetpackCharge.Upgrade_5 => oneMinute - (3 * 5),
        SaveData.UpgradeJetpackCharge.Upgrade_4 => oneMinute - (3 * 4),
        SaveData.UpgradeJetpackCharge.Upgrade_3 => oneMinute - (3 * 3),
        SaveData.UpgradeJetpackCharge.Upgrade_2 => oneMinute - (3 * 2),
        SaveData.UpgradeJetpackCharge.Upgrade_1 => oneMinute - (3 * 1),
        _ => oneMinute,
    };
    //////////////////////////////////////////////////////////////////// Upgrade Jetpack END
    //////////////////////////////////////////////////////////////////// Upgrade Speed
    public float StateUpgradeSpeedStrength(SaveData.UpgradeSpeedStrength state) => state switch
    {
        SaveData.UpgradeSpeedStrength.Upgrade_5 => initialSpeed * 2.0f,
        SaveData.UpgradeSpeedStrength.Upgrade_4 => initialSpeed * 1.8f,
        SaveData.UpgradeSpeedStrength.Upgrade_3 => initialSpeed * 1.6f,
        SaveData.UpgradeSpeedStrength.Upgrade_2 => initialSpeed * 1.4f,
        SaveData.UpgradeSpeedStrength.Upgrade_1 => initialSpeed * 1.2f,
        _ => initialSpeed,
    };
    public float StateUpgradeSpeedBooster(SaveData.UpgradeSpeedBooster state) => state switch
    {
        SaveData.UpgradeSpeedBooster.Upgrade_5 => initialBooster + 3.0f,
        SaveData.UpgradeSpeedBooster.Upgrade_4 => initialBooster + 2.5f,
        SaveData.UpgradeSpeedBooster.Upgrade_3 => initialBooster + 2.0f,
        SaveData.UpgradeSpeedBooster.Upgrade_2 => initialBooster + 1.5f,
        SaveData.UpgradeSpeedBooster.Upgrade_1 => initialBooster + 1.0f,
        _ => initialBooster,
    };
    //////////////////////////////////////////////////////////////////// Upgrade Speed END
    ///////////////////////////////////////////////////////////////////////////////// Upgrade Data END
}
