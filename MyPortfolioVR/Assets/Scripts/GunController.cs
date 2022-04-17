using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public Transform gunPoint;
    [SerializeField] TextMesh textCurrentQuantity;
    [SerializeField] GameObject waterAttackSplash;
    [SerializeField] GameObject waterHitSplash;
    List<GameObject> waterHitSplashList = new List<GameObject>();
    List<GameObject> waterAttackSplashList = new List<GameObject>();
    public int effectPoolCount = 4;
    float reshootCurrentTime = 0.0f;
    float reshootLimitTime = 0.1f;
    float currentQuantity;
    float attackPower = 6.0f;
    public float recoveryQuantity = 5/3;
    public float spendQuantity = 5.0f;
    public bool isInWater = false;
    public Transform aim;
    Vector3 originScale = Vector3.one * 0.02f;
    Ray ray;
    RaycastHit hitInfo;
    readonly string TextColor_Green = "#34D149";
    readonly string TextColor_Orange = "#C3FF00";
    readonly string TextColor_Yellow = "#FF9900";
    readonly string TextColor_Red = "#FF0007";
    // Start is called before the first frame update
    void Start()
    {
        // recoveryQuantity = ???    Import Save Data
        // spendQuantity = ???       Import Save Data
        currentQuantity = 100.0f;
        for(int i=0; i<effectPoolCount; i++)
        {
            GameObject go = Instantiate(waterAttackSplash);
            go.transform.position = Vector3.down * 10;
            go.SetActive(false);
            waterAttackSplashList.Add(go);
        }
        for(int i=0; i<effectPoolCount; i++)
        {
            GameObject go = Instantiate(waterHitSplash);
            go.transform.position = Vector3.down * 10;
            go.SetActive(false);
            waterHitSplashList.Add(go);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(isInWater)
        {
            Recovery();
        }
        UpdateQuantityText();
        reshootCurrentTime = Mathf.Clamp(reshootCurrentTime + Time.deltaTime, 0f, 1.0f);
    }
    public void Shoot()
    {
        if(!Spend() || reshootCurrentTime < reshootLimitTime)
        {
            return;
        }
        if(waterAttackSplashList.Count > 0)
        {
            reshootCurrentTime = 0;
            GameObject go = waterAttackSplashList[0];
            waterAttackSplashList.RemoveAt(0);
            go.transform.position = gunPoint.position;
            go.transform.rotation = gunPoint.rotation;
            go.SetActive(true);
            ParticleSystem effect = go.GetComponentInChildren<ParticleSystem>();
            effect.Play();
            waterAttackSplashList.Add(go);
        }
        HitTarget();
    }
    bool Spend()
    {
        if(currentQuantity < spendQuantity)
        {
            return false;
        }
        currentQuantity = Mathf.Clamp(currentQuantity - spendQuantity, 0f, 100.0f);
        return true;
    }
    void HitTarget()
    {
        if(RayCast())
        {
            GameObject go = waterHitSplashList[0];
            waterHitSplashList.RemoveAt(0);
            go.transform.position = hitInfo.point;
            go.transform.forward = hitInfo.normal * -1;
            go.SetActive(true);
            ParticleSystem effect = go.GetComponentInChildren<ParticleSystem>();
            effect.Play();
            waterHitSplashList.Add(go);
            /////////////////////////////////////////////////////////// RubberDuck Damaged
            if(hitInfo.transform.name.Contains("Duck"))
            {
                RubberDuckBase duck = hitInfo.transform.GetComponent<RubberDuckBase>();
                if(duck)
                {
                    duck.OnDamaged(attackPower);
                }
            }
            /////////////////////////////////////////////////////////// RubberDuck Damaged
        }
    }
    void DrawAimPoint()
    {
        if(RayCast())
        {
            aim.position = hitInfo.point;
            aim.forward = gunPoint.forward;
            aim.localScale = originScale * Mathf.Max(1, hitInfo.distance);
        }
        else
        {
            aim.position = Vector3.down * 10;
            aim.localScale = originScale;
        }
    }
    bool RayCast()
    {
        ray = new Ray(gunPoint.position, gunPoint.forward * -1);
        if(Physics.Raycast(ray, out hitInfo, 20.0f))
        {
            return true;
        }
        return false;
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
    void UpdateQuantityText()
    {
        textCurrentQuantity.text = Mathf.Floor(currentQuantity) + "%";
        Color color;
        ColorUtility.TryParseHtmlString(SelectColor(), out color);
        textCurrentQuantity.color = color;
    }
    string SelectColor() => currentQuantity switch
    {
        var a when a >= 75.0f => TextColor_Green,
        var a when a >= 50.0f => TextColor_Orange,
        var a when a >= 25.0f => TextColor_Yellow,
        _ => TextColor_Red,
    };
}
