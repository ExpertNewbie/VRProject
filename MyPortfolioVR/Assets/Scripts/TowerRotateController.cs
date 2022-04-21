using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerRotateController : MonoBehaviour
{
    GameStateManager stateManager;
    Vector3 angle;
    public float rotateSpeed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        stateManager = GameObject.Find("GameStateManager").GetComponent<GameStateManager>();
        angle.y = Camera.main.transform.eulerAngles.y + 90.0f;
    }
    // Update is called once per frame
    void Update()
    {
        if(stateManager.isPlayStatePlay)
            TowerRotate();
    }
    void TowerRotate()
    {
        angle.y += rotateSpeed * Time.deltaTime;
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, angle.y, transform.eulerAngles.z);
    }
}
