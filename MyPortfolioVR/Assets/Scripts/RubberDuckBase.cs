using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RubberDuckBase : MonoBehaviour
{
    [SerializeField] AudioSource normalSound;
    [SerializeField] AudioSource hitSound;
    [SerializeField] AudioSource deathSound;
    float maxHP = 10.0f;
    float currentHP;
    RubberDuckMove moveAgent;
    float reloadTime;
    float currentTime;
    // Start is called before the first frame update
    void Start()
    {
        // maxHP = ??? Import Setting Data
        currentHP = maxHP;
        moveAgent = GetComponentInParent<RubberDuckMove>();
    }
    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if(currentTime > reloadTime && normalSound != null)
        {
            normalSound.Play();
            reloadTime = UnityEngine.Random.Range(2.0f, 12.0f);
            currentTime = 0;
        }
    }
    public void OnDamaged(float attackPower)
    {
        currentHP = Mathf.Clamp(currentHP - attackPower, 0f, maxHP);
        if(currentHP > 0f)
        {
            hitSound.Play();
            moveAgent.GotoRandomPoint(true);
            return;
        }
        Death();
    }
    void Death()
    {
        deathSound.Play();
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
        hitSound.Play();
        moveAgent.GotoRandomPoint(false);
    }
}
