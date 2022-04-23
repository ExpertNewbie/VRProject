using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    GameStateManager stateManager;
    GameBaseData baseData;
    Text textMesh;
    public int Limit { get; set; }
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
        UpdateText();
    }
    void UpdateText()
    {
        int sec = Mathf.FloorToInt(TSec);
        textMesh.text
            = string.Format("{0:D2}:{1:D2}:{2:D2}", TMin, sec, Mathf.FloorToInt(((TSec-sec)*100)));
        textMesh.color = baseData.SelectTextColor(100.0f);
    }
    void RunTimer()
    {
        TSec -= Time.deltaTime;
        if(TSec < 0)
        {
            TSec = 60.0f;
            TMin--;
            if(TMin < 0)
            {
                TMin = 0;
                TSec = 0;
                stateManager.InGameStateInPlayChange(GameStateManager.GameStateInPlay.End);
            }
        }
        UpdateText();
    }
}
