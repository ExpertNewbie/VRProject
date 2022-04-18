using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIUpgradeController : AbsButtonController
{
    GameObject cloneUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Ray ray = new Ray(ARAVRInput.RHandPosition, ARAVRInput.RHandDirection);
        // RaycastHit hitInfo;
        // if(Physics.Raycast(ray, out hitInfo))
        // {
        //     UIUpgradeActivator activator = hitInfo.transform.GetComponent<UIUpgradeActivator>();
        // Debug.Log("activator : "+activator);
        //     if(activator)
        //     {
        //     }
        // }
    }
    public override void ButtonExit()
    {
        Destroy(gameObject);
    }
    public void ButtonJetpackEfficiency()
    {
        DialogOpen("Jetpack Efficiency");
    }
    public void ButtonJetpackPower()
    {
        DialogOpen("Jetpack Power");
    }
    public void ButtonJetpackCharge()
    {
        DialogOpen("Jetpack Charge");
    }
    public void ButtonSpeedStrength()
    {
        DialogOpen("Speed Strength");
    }
    public void ButtonSpeedBooster()
    {
        DialogOpen("Speed Booster");
    }
    public void ButtonWeaponDamage()
    {
        DialogOpen("Weapon Damage");
    }
    public void ButtonWeaponEfficiency()
    {
        DialogOpen("Weapon Efficiency");
    }
    public void ButtonWeaponCharge()
    {
        DialogOpen("Weapon Charge");
    }
    public override void DialogOpen(string info)
    {
        if(!isDialogOpen)
        {
            isDialogOpen = true;
            Vector3 uiPosition = transform.position + (transform.forward * -30) + (transform.up * -30);
            cloneUI = Instantiate(uiDialog, uiPosition, transform.rotation);
            cloneUI.GetComponentInChildren<Text>().text = info + " Upgrade";
            UIDialogController controller = cloneUI.GetComponent<UIDialogController>();
            controller.SetAbsButtonController(this);
        }
    }
    public override void DialogThrowsInfo(bool yn)
    {
        isDialogOpen = false;
    }
}
