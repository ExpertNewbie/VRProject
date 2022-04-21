using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    GameStateManager stateManager;
    GameBaseData baseData;
    Text textMesh;
    int TMin = 1;
    float TSec = 5;
    // Start is called before the first frame update
    void Start()
    {
        stateManager = GameObject.Find("GameStateManager").GetComponent<GameStateManager>();
        baseData = GameBaseData.Instance();
        textMesh = GetComponent<Text>();
        InitialSetting();
    }

    // Update is called once per frame
    void Update()
    {
        if(stateManager.isPlayStatePlay)
            RunTimer();
    }
    public void InitialSetting()
    {
        textMesh.text = $"0{TMin}:{TSec}:00";
        textMesh.color = baseData.SelectTextColor(100.0f);
    }
    void RunTimer()
    {
        TSec -= Time.deltaTime;
        if(TSec < 0)
        {
            TMin--;
            TSec = 59.0f;
        }
        if(TMin < 0)
        {
            TMin = 0;
            TSec = 0;
            stateManager.InGameStateInPlayChange(GameStateManager.GameStateInPlay.End);
        }
        textMesh.text = $"{TMin}:{Mathf.Floor(TSec)}:00";
        textMesh.color = baseData.SelectTextColor(100.0f);
    }
}
