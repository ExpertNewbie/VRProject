using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIUpgradeController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(ARAVRInput.RHandPosition, ARAVRInput.RHandDirection);
        RaycastHit hitInfo;
        if(Physics.Raycast(ray, out hitInfo))
        {
            UIUpgradeActivator activator = hitInfo.transform.GetComponent<UIUpgradeActivator>();
        Debug.Log("activator : "+activator);
            if(activator)
            {
            }
        }
    }
    public void ButtonExit()
    {
        Destroy(gameObject);
    }
    public void ButtonJetpackEfficiency()
    {}
    public void ButtonJetpackPower()
    {}
    public void ButtonSpeedForward()
    {}
    public void ButtonSpeedBackstop()
    {}
    public void ButtonWeaponDamage()
    {}
    public void ButtonWeaponEfficiency()
    {}
}
