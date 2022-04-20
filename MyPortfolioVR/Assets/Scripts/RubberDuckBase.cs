using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RubberDuckBase : MonoBehaviour
{
    GameStateManager stateManager;
    GameEffectManager effectManager;
    GameBaseData.MonsterData data;
    [SerializeField] AudioClip normalSound;
    [SerializeField] AudioClip hitSound;
    [SerializeField] AudioClip deathSound;
    [SerializeField] AudioSource audioPlayer;
    // float maxHP = 10.0f;
    float currentHP;
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
    }
    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if(currentTime > reloadTime && normalSound != null)
        {
            audioPlayer.PlayOneShot(normalSound);
            reloadTime = UnityEngine.Random.Range(2.0f, 12.0f);
            currentTime = 0;
        }
    }
    public void OnDamaged(float attackPower, RaycastHit hitInfo)
    {
        this.hitInfo = hitInfo;
        currentHP = Mathf.Clamp(currentHP - attackPower, 0f, data.HP);
        if(currentHP > 0f)
        {
            effectManager.UseEffectPool("HitEffectList", hitInfo.point, hitInfo.normal * -1);
            audioPlayer.PlayOneShot(hitSound);
            if(!name.Contains("Boss"))
                moveAgent.GotoRandomPoint(true);
            else
                BossSkillActivate();
            return;
        }
        Death();
    }
    void Death()
    {
        effectManager.UseEffectPool("DeathEffectList", hitInfo.point, hitInfo.normal * -1);
        string effectName = FindEffectForName(name);
        if(effectName != null)
            effectManager.UseEffectPool(effectName, hitInfo.point, hitInfo.normal * -1);
        audioPlayer.PlayOneShot(deathSound);
        StartCoroutine(DeathEffect());
    }
    IEnumerator DeathEffect()
    {
        // 흐릿해지고 넘어지는 모션
        yield return null;
        Destroy(gameObject);
    }
    void BossSkillActivate()
    {
        // 보스의 효과 발동
    }
    string FindEffectForName(string name)
    {
        switch(name)
        {
            case string a when a.Contains("Ink") : return "DuckSPInkList";
            case string a when a.Contains("Max") : return "DuckSPMaxList";
            case string a when a.Contains("Half") : return "DuckSPHaldList";
            case string a when a.Contains("Gold") : return "DuckSPGoldList";
            case string a when a.Contains("Time") : return "DuckSPTimeList";
            default : return null;
        }
    }
    void OnCollisionEnter(Collision other)
    {
        audioPlayer.PlayOneShot(hitSound);
        moveAgent.GotoRandomPoint(false);
    }
}
