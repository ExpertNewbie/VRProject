using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEffectManager : MonoBehaviour
{
    [SerializeField] GameObject waterAttackSplash;
    [SerializeField] GameObject waterHitSplash;
    [SerializeField] GameObject waterMoveSplash;
    [SerializeField] GameObject duckRun;
    [SerializeField] GameObject duckHit;
    [SerializeField] GameObject duckDeath;
    [SerializeField] GameObject duckSPInk;
    [SerializeField] GameObject duckSPMax;
    [SerializeField] GameObject duckSPHalf;
    [SerializeField] GameObject duckSPGold;
    [SerializeField] GameObject duckSPTime;
    [SerializeField] GameObject duckSPBoss;
    List<GameObject> waterHitSplashList;
    List<GameObject> waterAttackSplashList;
    List<GameObject> waterMoveSplashList;
    List<GameObject> runEffectList;
    List<GameObject> hitEffectList;
    List<GameObject> deathEffectList;
    List<GameObject> duckSPInkList;
    List<GameObject> duckSPMaxList;
    List<GameObject> duckSPHalfList;
    List<GameObject> duckSPGoldList;
    List<GameObject> duckSPTimeList;
    List<GameObject> duckSPBossList;
    public int persistEffectPoolCount = 2;
    public int waterPoolCount = 8;
    public int duckHitPoolCount = 6;
    public int duckDeathPoolCount = 4;
    public int duckPSPoolCount = 3;
    // Start is called before the first frame update
    void Start()
    {
        CreateEffectPool(waterAttackSplash, waterPoolCount, out waterAttackSplashList);
        CreateEffectPool(waterHitSplash, waterPoolCount, out waterHitSplashList);
        CreateEffectPool(duckHit, duckHitPoolCount, out hitEffectList);
        CreateEffectPool(duckDeath, duckDeathPoolCount, out deathEffectList);
        //////////////////////////////////////////////////////////////////////// Duck SP Effect
        CreateEffectPool(duckSPInk, duckPSPoolCount, out duckSPInkList);
        CreateEffectPool(duckSPMax, duckPSPoolCount, out duckSPMaxList);
        CreateEffectPool(duckSPHalf, duckPSPoolCount, out duckSPHalfList);
        CreateEffectPool(duckSPGold, duckPSPoolCount, out duckSPGoldList);
        CreateEffectPool(duckSPTime, duckPSPoolCount, out duckSPTimeList);
        //////////////////////////////////////////////////////////////////////// Duck SP Effect END
        // CreateEffectPool(waterHitSplash, persistEffectPoolCount, out waterHitSplashList);
        // CreateEffectPool(duckRun, persistEffectPoolCount, out runEffectList);
        // CreateEffectPool(duckSPBoss, duckPSPoolCount, out duckSPBossList);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void CreateEffectPool(GameObject effectObj, int listCount, out List<GameObject> list)
    {
        list = new List<GameObject>();
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
            ParticleSystem effect = go.GetComponentInChildren<ParticleSystem>();
            effect.Play();
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
        "DuckSPBossList" => null,
        _ => null
    };
}
