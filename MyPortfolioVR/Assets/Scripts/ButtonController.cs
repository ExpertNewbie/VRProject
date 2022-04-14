using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : AbsButtonController
{
    public UIActivator activator { get; set; }
    [SerializeField] GameObject uiUpgrade;
    [SerializeField] float uiUP = 130.0f;
    [SerializeField] float uiDistance = 270.0f;
    // Start is called before the first frame update
    void Start()
    {
        // 게임 일시중지
        // 플레이어 움직임 금지
        // 타겟 불가시
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void ButtonContinue()
    {
        // 게임 일시중지 해제
        // 플레이어 움직임 금지 해제
        // 타겟 불가시 해제
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
    {}
    public override void ButtonExit()
    {
        activator.isOpen = false;
        Destroy(gameObject);
    }
    public override void DialogOpen(string info)
    {}
    public override void DialogThrowsInfo(bool yn)
    {}
}
