using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public Transform gunPoint;
    [SerializeField] TextMesh textCurrentQuantity;
    [SerializeField] ParticleSystem shootEffect;
    public float recoveryQuantity;
    public float spendQuantity;
    float currentQuantity;
    public bool isInWater = false;
    // Start is called before the first frame update
    void Start()
    {
        // recoveryQuantity = ???
        // spendQuantity = ???
        currentQuantity = 100.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(isInWater)
        {
            Recovery();
        }
        UpdateQuantity();
    }
    void UpdateQuantity()
    {
        textCurrentQuantity.text = Mathf.Floor(currentQuantity) + "%";
    }
    public void Shoot()
    {
Debug.Log("currentQuantity : "+currentQuantity);
Debug.Log("Shoot");
        if(!Spend())
        {
            return;
        }
Debug.Log("currentQuantity : "+currentQuantity);
        Instantiate(shootEffect, gunPoint.position, gunPoint.rotation);
    }
    bool Spend()
    {
Debug.Log("Spend");
        if(currentQuantity < spendQuantity)
        {
            return false;
        }
        currentQuantity = Mathf.Clamp(currentQuantity - spendQuantity, 0f, 100.0f);
        return true;
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
        currentQuantity = Mathf.Clamp(currentQuantity + recoveryQuantity, 0f, 100.0f);
    }

}
