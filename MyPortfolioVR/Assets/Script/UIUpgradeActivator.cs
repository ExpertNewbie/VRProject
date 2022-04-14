using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class UIUpgradeActivator : MonoBehaviour
{
    [SerializeField] GameObject panelText;
    [SerializeField] GameObject panelButtonJetpack;
    [SerializeField] GameObject panelButtonSpeed;
    [SerializeField] GameObject panelButtonWeapon;
    const string jetpack = "Jetpack";
    const string speed = "Speed";
    const string weapon = "Weapon";
    string buttonName;
    Text[] texts;
    // Start is called before the first frame update
    void Start()
    {
        texts = panelText.GetComponentsInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ButtonParts(Button button)
    {
        if(button.name.Contains(jetpack))
        {
            buttonName = jetpack;
        }
        else if(button.name.Contains(speed))
        {
            buttonName = speed;
        }
        else if(button.name.Contains(weapon))
        {
            buttonName = weapon;
        }
        activeButtonPanel();
    }
    private void activeButtonPanel()
    {
        panelButtonJetpack.SetActive(false);
        panelButtonSpeed.SetActive(false);
        panelButtonWeapon.SetActive(false);
        panelText.SetActive(true);
        switch(buttonName)
        {
            case jetpack : 
                panelButtonJetpack.SetActive(true);
                break;
            case speed : 
                panelButtonSpeed.SetActive(true);
                break;
            case weapon : 
                panelButtonWeapon.SetActive(true);
                break;
        }
    }
}
