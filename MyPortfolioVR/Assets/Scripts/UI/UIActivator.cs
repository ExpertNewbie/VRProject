using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIActivator : MonoBehaviour
{
    GameStateManager stateManager;
    [SerializeField] GameObject UI;
    [SerializeField] Transform player;
    float uiUP = 150.0f;
    float uiDistance = 300.0f;
    public bool isOpen { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        stateManager = GameObject.Find("GameStateManager").GetComponent<GameStateManager>();
        isOpen = false;
    }
    // Update is called once per frame
    void Update()
    {
        if(ARAVRInput.Get(ARAVRInput.Button.StartMenu))
        {
            if(!isOpen)
            {
                stateManager.InGameStateInPlayChange(GameStateManager.GameStateInPlay.Pause);
                isOpen = true;
                Vector3 uiPosition = transform.position
                + (transform.forward * uiDistance) + (transform.up * uiUP);
                Vector3 uiV3 = player.rotation.eulerAngles;
                GameObject clone = Instantiate(UI, uiPosition, Quaternion.Euler(0, uiV3.y, 0));
                ButtonController bc = clone.GetComponent<ButtonController>();
                bc.activator = this;
            }
        }
    }
    public void UIClose()
    {
        isOpen = false;
        if(stateManager.isPlayStatePause)
            stateManager.InGameStateInPlayChange(GameStateManager.GameStateInPlay.Play);
    }
}
