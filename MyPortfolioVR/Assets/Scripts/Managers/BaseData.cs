using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseData
{
    //////////////////////////////////////////////////////////////////// Contruct
    private static BaseData instance;
    public static BaseData Instance()
    {
        if(instance == null)
            instance = new BaseData();
        return instance;
    }
    private BaseData()
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
    //////////////////////////////////////////////////////////////////// Contruct END
    Color ImageColor_Green; Color ImageColor_Yellow; Color ImageColor_Orange; Color ImageColor_Red;
    Color TextColor_Green; Color TextColor_Yellow; Color TextColor_Orange; Color TextColor_Red;
    public Color SelectTextImage(float quantity) => quantity switch
    {
        var a when a >= 75.0f => ImageColor_Green,
        var a when a >= 50.0f => ImageColor_Yellow,
        var a when a >= 25.0f => ImageColor_Orange,
        _ => ImageColor_Red,
    };
    public Color SelectTextColor(float quantity) => quantity switch
    {
        var a when a >= 75.0f => TextColor_Green,
        var a when a >= 50.0f => TextColor_Yellow,
        var a when a >= 25.0f => TextColor_Orange,
        _ => TextColor_Red,
    };
}
