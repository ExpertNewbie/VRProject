using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    GameStateManager stateManager;
    GameEffectManager effectManager;
    public Transform gunPoint;
    [SerializeField] TextMesh textCurrentQuantity;
    float reshootCurrentTime = 0.0f;
    float reshootLimitTime = 0.1f;
    float currentQuantity;
    public bool isInWater = false;
    public Transform aim;
    Vector3 originScale = Vector3.one * 0.02f;
    Ray ray;
    RaycastHit hitInfo;
    // Start is called before the first frame update
    void Start()
    {
        stateManager = GameObject.Find("GameStateManager").GetComponent<GameStateManager>();
        effectManager = GameObject.Find("GameEffectManager").GetComponent<GameEffectManager>();
        currentQuantity = 100.0f;
    }
    // Update is called once per frame
    void Update()
    {
        if(isInWater)
        {
            Charge();
        }
        DrawAimPoint();
        UpdateQuantity();
        reshootCurrentTime = Mathf.Clamp(reshootCurrentTime + Time.deltaTime, 0f, 1.0f);
    }
    public void Shoot()
    {
        if(!Spend() && reshootCurrentTime < reshootLimitTime)
        {
            return;
        }
        if(effectManager.UseEffectPool("WaterAttackSplashList", gunPoint))
            reshootCurrentTime = 0;
        HitTarget();
    }
    bool Spend()
    {
        if(currentQuantity < stateManager.WeaponEfficiency)
        {
            return false;
        }
        currentQuantity = Mathf.Clamp(currentQuantity - stateManager.WeaponEfficiency, 0f, 100.0f);
        return true;
    }
    void HitTarget()
    {
        if(RayCast())
        {
            effectManager.UseEffectPool("WaterHitSplashList", hitInfo.point, hitInfo.normal *-1);
            /////////////////////////////////////////////////////////// RubberDuck Damaged
            if(hitInfo.transform.name.Contains("Duck"))
            {
                RubberDuckBase duck = hitInfo.transform.GetComponent<RubberDuckBase>();
                if(duck)
                {
                    duck.OnDamaged(stateManager.WeaponPower, hitInfo);
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
    public void BonusChargeMax()
    {
        currentQuantity = 100.0f;
    }
    public void BonusCharge()
    {
        currentQuantity = Mathf.Clamp(currentQuantity + 50.0f, 0f, 100.0f);
    }
    void Charge()
    {
        currentQuantity = Mathf.Clamp(currentQuantity
                                    + (stateManager.WeaponCharge * Time.deltaTime), 0f, 100.0f);
    }
    void UpdateQuantity()
    {
        textCurrentQuantity.text = Mathf.Floor(currentQuantity) + "%";
        textCurrentQuantity.color = GameBaseData.Instance().SelectTextColor(currentQuantity);
    }
}
