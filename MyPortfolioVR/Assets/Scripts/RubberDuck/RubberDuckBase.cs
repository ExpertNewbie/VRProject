using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubberDuckBase : MonoBehaviour
{
    GameStateManager stateManager;
    GameEffectManager effectManager;
    GameBaseData.MonsterData data;
    [SerializeField] List<AudioClip> normalSound = new List<AudioClip>();
    [SerializeField] AudioClip hitSound;
    [SerializeField] AudioClip deathSound;
    AudioSource audioPlayer;
    float currentHP;
    float lastHP;
    RubberDuckMove moveAgent;
    float reloadTime;
    float currentTime;
    RaycastHit hitInfo;
    // Start is called before the first frame update
    void Start()
    {
        stateManager = GameObject.Find("GameStateManager").GetComponent<GameStateManager>();
        effectManager = GameObject.Find("GameEffectManager").GetComponent<GameEffectManager>();
        data = GameBaseData.Instance().GetDuckData(name);
        currentHP = data.HP;
        moveAgent = GetComponentInParent<RubberDuckMove>();
        audioPlayer = GetComponentInParent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if(currentTime > reloadTime && normalSound.Count > 0)
        {
            audioPlayer.PlayOneShot(normalSound[UnityEngine.Random.Range(0, normalSound.Count-1)]);
            reloadTime = UnityEngine.Random.Range(2.0f, 12.0f);
            currentTime = 0;
        }
    }
    public void OnDamaged(float attackPower, RaycastHit hitInfo)
    {
        this.hitInfo = hitInfo;
        lastHP = currentHP;
        currentHP = Mathf.Clamp(currentHP - attackPower, 0f, data.HP);
        if(currentHP > 0f)
        {
            effectManager.UseEffectPool("HitEffectList", hitInfo.point, hitInfo.normal * -1);
            audioPlayer.PlayOneShot(hitSound);
            if(!data.IsBoss)
                moveAgent.GotoRandomPoint(true);
            else
            {
                float perLast = lastHP / data.HP * 100;
                float perCurrent = currentHP / data.HP * 100;
                if(CheckHPPercentage(perLast, perCurrent))
                    BossSkillActivate();
            }
            return;
        }
        Death();
    }
    void Death()
    {
        // Visual Effect
        effectManager.UseEffectPool("DeathEffectList", hitInfo.point, hitInfo.normal * -1);
        // Common Effect
        stateManager.PlusAddGold(data.Gold);
        if(!data.IsBoss)
            stateManager.PlusKillCount(data.Count);
        else
            stateManager.PlusKillCountBoss(data.Count);
        // Special Visual Effect
        string effectName = FindVisualEffectForName(name);
        if(data.Effect && effectName != null)
        {
            effectManager.UseEffectPool(effectName, hitInfo.point, hitInfo.normal * -1);
            stateManager.DuckScriptEffect(name);
        }
        // Sound Effect
        audioPlayer.PlayOneShot(deathSound);
        StartCoroutine(DeathEffect());
    }
    IEnumerator DeathEffect()
    {
        // 흐릿해지고 넘어지는 모션
        yield return null;
        Destroy(gameObject);
    }
    void OnCollisionEnter(Collision other)
    {
        audioPlayer.PlayOneShot(hitSound);
        moveAgent.GotoRandomPoint(false);
    }
    void BossSkillActivate()
    {
        if(!data.IsBoss)
            return;
        effectManager.UseEffectPool("DuckSPBossSkillList", hitInfo.point, hitInfo.normal * -1);
        GetComponentInParent<RubberDuckBossController>().ActivateSkill();
    }
    string FindVisualEffectForName(string objName) => objName switch
    {
        var a when a.Contains("Ink") => "DuckSPInkList",
        var a when a.Contains("Max") => "DuckSPMaxList",
        var a when a.Contains("Half") => "DuckSPHalfList",
        var a when a.Contains("Gold") => "DuckSPGoldList",
        var a when a.Contains("Time") => "DuckSPTimeList",
        var a when a.Contains("Boss") => "DuckSPBossList",
        _ => null
    };
    bool CheckHPPercentage(float perLast, float perCurrent)
    {
        switch(perLast)
        {
            case float last when last > 70.0f :
                if(perCurrent <= 70.0f)
                    return true;
                return false;
            case float last when last > 50.0f :
                if(perCurrent <= 50.0f)
                    return true;
                return false;
            case float last when last > 20.0f :
                if(perCurrent <= 20.0f)
                    return true;
                return false;
            default :
                return false;
        }
    }
}
