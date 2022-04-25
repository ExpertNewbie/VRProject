using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEffectManager : MonoBehaviour
{
    [SerializeField] GameObject waterAttackSplash, waterHitSplash, waterMoveSplash;
    [SerializeField] GameObject jetpackLaunch;
    [SerializeField] GameObject duckRun, duckHit, duckDeath;
    [SerializeField] GameObject duckSPInk, duckSPMax ,duckSPHalf ,duckSPGold, duckSPTime, duckSPBoss;
    List<GameObject> waterHitSplashList, waterAttackSplashList, waterMoveSplashList;
    List<GameObject> jetpackLaunchList;
    List<GameObject> runEffectList, hitEffectList, deathEffectList;
    List<GameObject> duckSPInkList, duckSPMaxList, duckSPHalfList, duckSPGoldList, duckSPTimeList;
    List<GameObject> duckSPBossList;
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
    public bool UseEffectPool(string poolName, Transform point)
    {
        return UseEffectPool<Quaternion>(FindPool(poolName), point.position, point.rotation) != null;
    }
    public bool UseEffectPool(string poolName, Vector3 point, Vector3 rot)
    {
        return UseEffectPool<Vector3>(FindPool(poolName), point, rot) != null;
    }
    public GameObject UseAndGetEffectPool<T>(string poolName, Vector3 point, T rot)
    {
        return UseEffectPool<T>(FindPool(poolName), point, rot);
    }
    GameObject UseEffectPool<T>(List<GameObject> pool, Vector3 point, T rot)
    {
        if(pool != null && pool.Count > 0)
        {
            GameObject go = pool[0];
            pool.RemoveAt(0);
            go.transform.position = point;
            switch(rot)
            {
                case Quaternion a :
                    go.transform.rotation = a;
                    break;
                case Vector3 b :
                    go.transform.forward = b;
                    break;
            }
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
            return go;
        }
        return null;
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
