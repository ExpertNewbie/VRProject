using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectController : MonoBehaviour
{
    float resetTime = 2.0f;
    float currentTime = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if(currentTime > resetTime)
        {
            gameObject.transform.position = Vector3.down * 10;
            gameObject.SetActive(false);
        }
    }
    private void OnEnable()
    {
        currentTime = 0.0f;

    }
}
