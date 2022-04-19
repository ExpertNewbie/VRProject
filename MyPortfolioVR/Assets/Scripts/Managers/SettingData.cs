using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct SettingData
{
    public SettingData(bool creater)
    {
        /////////////////////////////////////////////////////////////// Contruct Default
        LanguageState = Language.Korean;
        /////////////////////////////////////////////////////////////// Contruct Default
    }
    public SettingData(SettingData data)
    {
        /////////////////////////////////////////////////////////////// Contruct Custom
        LanguageState = data.LanguageState;
        /////////////////////////////////////////////////////////////// Contruct Custom
    }
    public Language LanguageState;
    public enum Language
    {
        Korean,
        English
    }
}
