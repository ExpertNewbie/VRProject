using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEffectManager : MonoBehaviour
{
    [SerializeField] GameObject waterAttackSplash;
    [SerializeField] GameObject waterHitSplash;
    [SerializeField] GameObject duckHit;
    [SerializeField] GameObject duckDeath;
    [SerializeField] GameObject duckSPInk;
    [SerializeField] GameObject duckSPMax;
    [SerializeField] GameObject duckSPHalf;
    [SerializeField] GameObject duckSPGold;
    [SerializeField] GameObject duckSPTime;
    List<GameObject> waterHitSplashList;
    List<GameObject> waterAttackSplashList;
    List<GameObject> hitEffectList;
    List<GameObject> deathEffectList;
    List<GameObject> duckSPInkList;
    List<GameObject> duckSPMaxList;
    List<GameObject> duckSPHalfList;
    List<GameObject> duckSPGoldList;
    List<GameObject> duckSPTimeList;
    public int waterPoolCount = 8;
    public int duckHitPoolCount = 6;
    public int duckDeathPoolCount = 4;
    public int duckPSPoolCount = 3;
    enum EffectType
    {
        Duck,
        Weapon,
        Jetpack,
        Speed
    }
    // Start is called before the first frame update
    void Start()
    {
        CreateEffectPool(waterAttackSplash, waterPoolCount, EffectType.Weapon, out waterAttackSplashList);
        CreateEffectPool(waterHitSplash, waterPoolCount, EffectType.Weapon, out waterHitSplashList);
        CreateEffectPool(duckHit, duckHitPoolCount, EffectType.Duck, out hitEffectList);
        CreateEffectPool(duckDeath, duckDeathPoolCount, EffectType.Duck, out deathEffectList);
        //////////////////////////////////////////////////////////////////////// Duck SP Effect
        CreateEffectPool(duckSPInk, duckPSPoolCount, EffectType.Duck, out duckSPInkList);
        CreateEffectPool(duckSPMax, duckPSPoolCount, EffectType.Duck, out duckSPMaxList);
        CreateEffectPool(duckSPHalf, duckPSPoolCount, EffectType.Duck, out duckSPHalfList);
        CreateEffectPool(duckSPGold, duckPSPoolCount, EffectType.Duck, out duckSPGoldList);
        CreateEffectPool(duckSPTime, duckPSPoolCount, EffectType.Duck, out duckSPTimeList);
        //////////////////////////////////////////////////////////////////////// Duck SP Effect END
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void CreateEffectPool(GameObject effectObj, int listCount, EffectType type, out List<GameObject> list)
    {
        list = new List<GameObject>();
        for(int i=0; i<listCount; i++)
        {
            GameObject go = Instantiate(effectObj);
            int down = SelectDownable(type);
            go.transform.position = Vector3.down * down;
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
            ParticleSystem effect = go.GetComponentInChildren<ParticleSystem>();
            effect.Play();
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
    int SelectDownable(EffectType type) => type switch
    {
        EffectType.Duck => 12,
        EffectType.Jetpack => 13,
        EffectType.Weapon => 14,
        _ => 15,
    };
    List<GameObject> FindPool(string methodName) => methodName switch
    {
        "WaterHitSplashList" => waterHitSplashList,
        "WaterAttackSplashList" => waterAttackSplashList,
        "HitEffectList" => hitEffectList,
        "DeathEffectList" => deathEffectList,
        "DuckSPInkList" => duckSPInkList,
        "DuckSPMaxList" => duckSPMaxList,
        "DuckSPHalfList" => duckSPHalfList,
        "DuckSPGoldList" => duckSPGoldList,
        "DuckSPTimeList" => duckSPTimeList,
        _ => null
    };
}
