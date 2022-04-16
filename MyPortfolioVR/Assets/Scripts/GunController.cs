using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public Transform gunPoint;
    [SerializeField] TextMesh textCurrentQuantity;
    [SerializeField] GameObject waterAttackSplash;
    List<GameObject> effectList = new List<GameObject>();
    public int effectPoolCount = 8;
    float reshootCurrentTime = 0.0f;
    float reshootLimitTime = 0.1f;
    float currentQuantity;
    public float recoveryQuantity;
    public float spendQuantity = 5.0f;
    public bool isInWater = false;
    public Transform aim;
    // Start is called before the first frame update
    void Start()
    {
        // recoveryQuantity = ???
        // spendQuantity = ???
        currentQuantity = 100.0f;
        for(int i=0; i<5; i++)
        {
            GameObject go = Instantiate(waterAttackSplash);
            go.transform.position = Vector3.down * 10;
            go.SetActive(false);
            effectList.Add(go);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isInWater)
        {
            Recovery();
        }
        UpdateQuantity();
        reshootCurrentTime = Mathf.Clamp(reshootCurrentTime + Time.deltaTime, 0f, 1.0f);
    }
    void UpdateQuantity()
    {
        textCurrentQuantity.text = Mathf.Floor(currentQuantity) + "%";
    }
    public void Shoot()
    {
Debug.Log("currentQuantity : "+currentQuantity);
Debug.Log("Shoot");
        if(!Spend() && reshootCurrentTime < reshootLimitTime)
        {
            return;
        }
Debug.Log("currentQuantity : "+currentQuantity);
        // Instantiate(shootEffect, gunPoint.position, gunPoint.rotation);
        if(effectList.Count > 0)
        {
            reshootCurrentTime = 0;
            GameObject go = effectList[0];
            effectList.RemoveAt(0);
            go.transform.position = gunPoint.position;
            go.transform.rotation = gunPoint.rotation;
            go.SetActive(true);
            ParticleSystem effect = go.GetComponentInChildren<ParticleSystem>();
            effect.Play();
            effectList.Add(go);
        }
    }
    bool Spend()
    {
Debug.Log("Spend");
        if(currentQuantity < spendQuantity)
        {
            return false;
Debug.Log("Spend false END");
        }
        currentQuantity = Mathf.Clamp(currentQuantity - spendQuantity, 0f, 100.0f);
        return true;
Debug.Log("Spend true END");
    }
    public void BonusRecoveryMax()
    {
        currentQuantity = 100.0f;
    }
    public void BonusRecovery()
    {
        currentQuantity = Mathf.Clamp(currentQuantity + 50.0f, 0f, 100.0f);
    }
    void Recovery()
    {
        currentQuantity = Mathf.Clamp(currentQuantity + (recoveryQuantity*Time.deltaTime), 0f, 100.0f);
    }

}
