using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public UIActivator activator { get; set; }
    SceneManager sceneManager;
    [SerializeField] GameObject uiUpgrade;
    float uiUP = 130.0f;
    float uiDistance = 270.0f;
    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
    }
    public void ButtonContinue()
    {
        ButtonExit();
    }
    public void ButtonRestart()
    {
    }
    public void ButtonNextStage()
    {}
    public void ButtonUpgrade()
    {
        Vector3 uiPosition = transform.position + (transform.forward * -30) + (transform.up * -20);
        GameObject clone = Instantiate(uiUpgrade, uiPosition, transform.rotation);
    }
    public void ButtonHome()
    {
        // sceneManager
    }
    public void ButtonExit()
    {
        activator.UIClose();
        Destroy(gameObject);
    }
    public void DialogOpen(string info)
    {}
    public void DialogThrowsInfo(bool yn)
    {}
}
