using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct SaveData
{
    public SaveData(bool creater)
    {
        /////////////////////////////////////////////////////////////// Contruct Default
        PlayTime = 0f;
        HaveGold = 0;
        SpendGold = 0;
        AddGold = 0;
        KillCount = 0;
        KillCountBonus = 0;
        StageClearState = StageClear.Stage_0;
        // UpgradeWeaponDamageState = UpgradeWeaponDamage.Upgrade_0;
        // UpgradeWeaponEfficiencyState = UpgradeWeaponEfficiency.Upgrade_0;
        // UpgradeWeaponChargeState = UpgradeWeaponCharge.Upgrade_0;
        // UpgradeJetpackPowerState = UpgradeJetpackPower.Upgrade_0;
        // UpgradeJetpackEfficiencyState = UpgradeJetpackEfficiency.Upgrade_0;
        // UpgradeJetpackChargeState = UpgradeJetpackCharge.Upgrade_0;
        // UpgradeSpeedStrengthState = UpgradeSpeedStrength.Upgrade_0;
        // UpgradeSpeedBoosterState = UpgradeSpeedBooster.Upgrade_0;
        UpgradeWeaponDamageState = UpgradeWeaponDamage.Upgrade_5;
        UpgradeWeaponEfficiencyState = UpgradeWeaponEfficiency.Upgrade_5;
        UpgradeWeaponChargeState = UpgradeWeaponCharge.Upgrade_5;
        UpgradeJetpackPowerState = UpgradeJetpackPower.Upgrade_5;
        UpgradeJetpackEfficiencyState = UpgradeJetpackEfficiency.Upgrade_5;
        UpgradeJetpackChargeState = UpgradeJetpackCharge.Upgrade_5;
        UpgradeSpeedStrengthState = UpgradeSpeedStrength.Upgrade_5;
        UpgradeSpeedBoosterState = UpgradeSpeedBooster.Upgrade_5;
        /////////////////////////////////////////////////////////////// Contruct Default END
    }
    public SaveData(SaveData data)
    {
        /////////////////////////////////////////////////////////////// Contruct Custom
        PlayTime = data.PlayTime;
        HaveGold = data.HaveGold;
        SpendGold = data.SpendGold;
        AddGold = data.AddGold;
        KillCount = data.KillCount;
        KillCountBonus = data.KillCountBonus;
        StageClearState = data.StageClearState;
        UpgradeWeaponDamageState = data.UpgradeWeaponDamageState;
        UpgradeWeaponEfficiencyState = data.UpgradeWeaponEfficiencyState;
        UpgradeWeaponChargeState = data.UpgradeWeaponChargeState;
        UpgradeJetpackPowerState = data.UpgradeJetpackPowerState;
        UpgradeJetpackEfficiencyState = data.UpgradeJetpackEfficiencyState;
        UpgradeJetpackChargeState = data.UpgradeJetpackChargeState;
        UpgradeSpeedStrengthState = data.UpgradeSpeedStrengthState;
        UpgradeSpeedBoosterState = data.UpgradeSpeedBoosterState;
        /////////////////////////////////////////////////////////////// Contruct Custom END
    }
    public float PlayTime { get; set; }
    public int HaveGold { get; set; }
    public int SpendGold { get; set; }
    public int AddGold { get; set; }
    public int KillCount { get; set; }
    public int KillCountBonus { get; set; }
    /////////////////////////////////////////////// State
    public StageClear StageClearState { get; set; }
    public UpgradeWeaponDamage UpgradeWeaponDamageState { get; set; }
    public UpgradeWeaponEfficiency UpgradeWeaponEfficiencyState { get; set; }
    public UpgradeWeaponCharge UpgradeWeaponChargeState { get; set; }
    public UpgradeJetpackPower UpgradeJetpackPowerState { get; set; }
    public UpgradeJetpackEfficiency UpgradeJetpackEfficiencyState { get; set; }
    public UpgradeJetpackCharge UpgradeJetpackChargeState { get; set; }
    public UpgradeSpeedStrength UpgradeSpeedStrengthState { get; set; }
    public UpgradeSpeedBooster UpgradeSpeedBoosterState { get; set; }
    public enum StageClear
    {
        Stage_0,
        Stage_1,
        Stage_2,
        Stage_3,
        Stage_4,
        Stage_5
    }
    public enum UpgradeWeaponDamage
    {
        Upgrade_0,
        Upgrade_1,
        Upgrade_2,
        Upgrade_3,
        Upgrade_4,
        Upgrade_5
    }
    public enum UpgradeWeaponEfficiency
    {
        Upgrade_0,
        Upgrade_1,
        Upgrade_2,
        Upgrade_3,
        Upgrade_4,
        Upgrade_5
    }
    public enum UpgradeWeaponCharge
    {
        Upgrade_0,
        Upgrade_1,
        Upgrade_2,
        Upgrade_3,
        Upgrade_4,
        Upgrade_5
    }
    public enum UpgradeJetpackPower
    {
        Upgrade_0,
        Upgrade_1,
        Upgrade_2,
        Upgrade_3,
        Upgrade_4,
        Upgrade_5
    }
    public enum UpgradeJetpackEfficiency
    {
        Upgrade_0,
        Upgrade_1,
        Upgrade_2,
        Upgrade_3,
        Upgrade_4,
        Upgrade_5
    }
    public enum UpgradeJetpackCharge
    {
        Upgrade_0,
        Upgrade_1,
        Upgrade_2,
        Upgrade_3,
        Upgrade_4,
        Upgrade_5
    }
    public enum UpgradeSpeedStrength
    {
        Upgrade_0,
        Upgrade_1,
        Upgrade_2,
        Upgrade_3,
        Upgrade_4,
        Upgrade_5
    }
    public enum UpgradeSpeedBooster
    {
        Upgrade_0,
        Upgrade_1,
        Upgrade_2,
        Upgrade_3,
        Upgrade_4,
        Upgrade_5
    }
    /////////////////////////////////////////////// State END
}
