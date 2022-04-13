using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public UIActivator activator { get; set; }
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
        Destroy(gameObject);
    }
    public void ButtonRestart()
    {
    }
    public void ButtonNextStage()
    {}
    public void ButtonUpgrade()
    {}
    public void ButtonHome()
    {}
    public void ButtonExit()
    {}
}
