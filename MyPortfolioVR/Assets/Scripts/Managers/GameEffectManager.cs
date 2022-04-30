using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEffectManager : MonoBehaviour
{
    [SerializeField] GameObject waterAttackSplash, waterHitSplash, waterMoveSplash;
    [SerializeField] GameObject jetpackLaunch;
    [SerializeField] GameObject duckRun, duckHit, duckDeath;
    [SerializeField] GameObject duckSPInk, duckSPMax ,duckSPHalf ,duckSPGold, duckSPTime;
    [SerializeField] GameObject duckSPBoss, duckSPBossSkill;
    List<GameObject> waterHitSplashList, waterAttackSplashList, waterMoveSplashList;
    List<GameObject> jetpackLaunchList;
    List<GameObject> runEffectList, hitEffectList, deathEffectList;
    List<GameObject> duckSPInkList, duckSPMaxList, duckSPHalfList, duckSPGoldList, duckSPTimeList;
    List<GameObject> duckSPBossList, duckSPBossSkillList;
    public int continuousEffectPoolCount = 2;
    public int waterPoolCount = 8;
    public int duckHitPoolCount = 6;
    public int duckDeathPoolCount = 4;
    public int duckPSPoolCount = 3;
    // Start is called before the first frame update
    void Start()
    {
        CreateEffectPool(waterAttackSplash, waterPoolCount, out waterAttackSplashList);
        CreateEffectPool(waterHitSplash, waterPoolCount, out waterHitSplashList);
        CreateEffectPool(jetpackLaunch, continuousEffectPoolCount, out jetpackLaunchList);
        CreateEffectPool(duckHit, duckHitPoolCount, out hitEffectList);
        CreateEffectPool(duckDeath, duckDeathPoolCount, out deathEffectList);
        //////////////////////////////////////////////////////////////////////// Duck SP Effect
        CreateEffectPool(duckSPInk, duckPSPoolCount, out duckSPInkList);
        CreateEffectPool(duckSPMax, duckPSPoolCount, out duckSPMaxList);
        CreateEffectPool(duckSPHalf, duckPSPoolCount, out duckSPHalfList);
        CreateEffectPool(duckSPGold, duckPSPoolCount, out duckSPGoldList);
        CreateEffectPool(duckSPTime, duckPSPoolCount, out duckSPTimeList);
        //////////////////////////////////////////////////////////////////////// Duck SP Effect END
        CreateEffectPool(waterMoveSplash, continuousEffectPoolCount, out waterMoveSplashList);
        CreateEffectPool(duckRun, continuousEffectPoolCount, out runEffectList);
        CreateEffectPool(duckSPBoss, duckPSPoolCount, out duckSPBossList);
        CreateEffectPool(duckSPBossSkill, duckPSPoolCount, out duckSPBossSkillList);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void CreateEffectPool(GameObject effectObj, int listCount, out List<GameObject> list)
    {
        list = new List<GameObject>();
        if(effectObj == null) return;
        for(int i=0; i<listCount; i++)
        {
            GameObject go = Instantiate(effectObj);
            go.transform.position = Vector3.down * 15;
            go.SetActive(false);
            list.Add(go);
        }
    }
    public bool UseEffectPool(string poolName, Vector3 point, Vector3 rot)
    {
        List<GameObject> pool = FindPool(poolName);
        if(pool != null && pool.Count > 0)
        {
            GameObject go = pool[0];
            pool.RemoveAt(0);
            go.transform.position = point;
            go.transform.forward = rot;
            go.SetActive(true);
            go.GetComponentInChildren<ParticleSystem>().Play();
            AudioSource se = go.GetComponentInChildren<AudioSource>();
            EffectController ec = go.GetComponentInChildren<EffectController>();
            if(se && ec.soundEffectList.Count > 0)
            {
                AudioClip sound = ec.soundEffectList[Random.Range(0, ec.soundEffectList.Count-1)];
                se.PlayOneShot(sound);
            }
            pool.Add(go);
            return true;
        }
        return false;
    }
    public bool UseEffectPool(string poolName, Transform usePoint)
    {
        List<GameObject> pool = FindPool(poolName);
        if(pool != null && pool.Count > 0)
        {
            GameObject go = pool[0];
            pool.RemoveAt(0);
            go.transform.position = usePoint.position;
            go.transform.rotation = usePoint.rotation;
            go.SetActive(true);
            go.GetComponentInChildren<ParticleSystem>().Play();
            AudioSource se = go.GetComponentInChildren<AudioSource>();
            EffectController ec = go.GetComponentInChildren<EffectController>();
            if(se && ec.soundEffectList.Count > 0)
            {
                AudioClip sound = ec.soundEffectList[Random.Range(0, ec.soundEffectList.Count-1)];
                se.PlayOneShot(sound);
            }
            pool.Add(go);
            return true;
        }
        return false;
    }
    List<GameObject> FindPool(string methodName) => methodName switch
    {
        "WaterHitSplashList" => waterHitSplashList,
        "WaterAttackSplashList" => waterAttackSplashList,
        "WaterMoveSplashList" => null,
        "RunEffectList" => null,
        "HitEffectList" => hitEffectList,
        "DeathEffectList" => deathEffectList,
        "DuckSPInkList" => duckSPInkList,
        "DuckSPMaxList" => duckSPMaxList,
        "DuckSPHalfList" => duckSPHalfList,
        "DuckSPGoldList" => duckSPGoldList,
        "DuckSPTimeList" => duckSPTimeList,
        "DuckSPBossList" => duckSPBossList,
        "DuckSPBossSkillList" => duckSPBossSkillList,
        _ => null
    };
}
