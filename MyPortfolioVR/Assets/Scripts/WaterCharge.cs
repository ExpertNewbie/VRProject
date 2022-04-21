using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterCharge : MonoBehaviour
{
    GameStateManager stateManager;
    // Start is called before the first frame update
    void Start()
    {
        stateManager = GameObject.Find("GameStateManager").GetComponent<GameStateManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision other)
    {
Debug.Log("other.gameObject.name : "+other.gameObject.name);
        if(other.gameObject.name == "Player" && stateManager.isPlayStatePlay)
            stateManager.Charging(true);
    }
    void OnCollisionExit(Collision other)
    {
Debug.Log("other.gameObject.name : "+other.gameObject.name);
        if(other.gameObject.name == "Player" && stateManager.isPlayStatePlay)
            stateManager.Charging(false);
    }
}
