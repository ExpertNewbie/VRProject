using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    GameStateManager stateManager;
    GameBaseData baseData;
    [SerializeField] TextMesh textCurrentQuantity;
    [SerializeField] Image imageCurrentQuantity;
    [SerializeField] Transform aim;
    float gravity = -10.0f;
    float currentQuantity;
    bool isInWater = false;
    Animator anim;
    float yVelocity = 0;
    CharacterController controller;
    // Start is called before the first frame update
    void Start()
    {
        baseData = GameBaseData.Instance();
        stateManager = GameObject.Find("GameStateManager").GetComponent<GameStateManager>();
        currentQuantity = 100.0f;
        controller = GetComponent<CharacterController>();
        // anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        ARAVRInput.DrawCrosshair(aim);

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        // anim.SetFloat("Speed", v);
        Vector3 dir = new Vector3(h, 0, v);
        dir = Camera.main.transform.TransformDirection(dir);
        yVelocity += gravity * Time.deltaTime;
        if(controller.isGrounded)
        {
            yVelocity = 0;
            // anim.SetBool("Jetpack", false);
        }
        //////////////////////////////////////////////////////////////////// JetPack Use
        if(ARAVRInput.Get(ARAVRInput.Button.HandTrigger))
        {
            if(Spend())
            {
                yVelocity += (stateManager.JetpackPower + -gravity) * Time.deltaTime;
            }
            // anim.SetBool("Jetpack", true);
        }
        //////////////////////////////////////////////////////////////////// JetPack Use END
        dir.y = yVelocity;
        if(v > 0)
        {
            controller.Move(dir * (stateManager.Speed + stateManager.Booster) * Time.deltaTime);
        }
        else
        {
            controller.Move(dir * ((stateManager.Speed/2) + stateManager.Booster) * Time.deltaTime);
        }
        UpdateQuantity();
    }
    bool Spend()
    {
        if(currentQuantity == 0)
        {
            return false;
        }
        currentQuantity = Mathf.Clamp(
            currentQuantity - (stateManager.JetpackEfficiency * Time.deltaTime), 0f, 100.0f);
        return true;
    }
    void UpdateQuantity()
    {
        textCurrentQuantity.text = Mathf.Floor(currentQuantity) + "%";
        textCurrentQuantity.color = GameBaseData.Instance().SelectTextColor(currentQuantity);
        imageCurrentQuantity.color = GameBaseData.Instance().SelectTextColor(currentQuantity);
        textCurrentQuantity.transform.forward = Camera.main.transform.forward;
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
                            + (stateManager.JetpackCharge * Time.deltaTime), 0f, 100.0f);
    }
}
