using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubberDuckBossController : MonoBehaviour
{
    GameBaseData.MonsterData bossData;
    float currentHP;
    [SerializeField] GameObject duckNoraml, duckSpeedy, duckHP, duckInk;
    [SerializeField] GameObject duckInvisible, duckPond, duckTwin;
    [SerializeField] GameObject duckBonusHalf, duckBonusMax, duckBonusTime, duckBonusGold;
    const int First = 7, Second = 10, Last = 15;
    int count;
    // Start is called before the first frame update
    void Start()
    {
        count = 3;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ActivateSkill()
    {
        List<GameObject> puppetList = new List<GameObject>();
        for(int i=0; i<SummonCount(count); i++)
        {
            // puppetList.Add(Instantiate(RandomObjectSelect(Random.Range(0.0f, 100.0f))));
Debug.Log(RandomObjectSelect(Random.Range(0.0f, 100.0f)));
        }
        count--;
    }
    int SummonCount(int cnt) => cnt switch
    {
        3 => Last,
        2 => Second,
        1 => First,
        _ => 0
    };
    // 2.0%     duckBonusMax
    // 3.5%     duckBonusHalf duckBonusTime duckBonusGold
    // 5.0%     duckInvisible
    // 7.5%     duckTwin
    // 10.0%    duckInk duckPond duckSpeedy
    // 15.0%    duckHP
    // 30.0%    duckNoraml
    GameObject RandomObjectSelect(float per) => per switch
    {
        var a when a >= 2.0f => duckBonusMax,       // 2.0%     duckBonusMax
        var a when a >= 5.5f => duckBonusHalf,      // 3.5%     duckBonusHalf
        var a when a >= 9.0f => duckBonusTime,      // 3.5%     duckBonusTime
        var a when a >= 12.5f => duckBonusGold,     // 3.5%     duckBonusGold
        var a when a >= 17.5f => duckInvisible,     // 5.0%     duckInvisible
        var a when a >= 25.0f => duckTwin,          // 7.5%     duckTwin
        var a when a >= 35.0f => duckInk,           // 10.0%    duckInk
        var a when a >= 45.0f => duckPond,          // 10.0%    duckPond
        var a when a >= 55.0f => duckSpeedy,        // 10.0%    duckSpeedy
        var a when a >= 70.0f => duckHP,            // 15.0%    duckHP
        _ => duckNoraml,                            // 30.0%    duckNoraml
    };
}
