using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectActivator : MonoBehaviour
{
    public List<GameObject> effectList = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
    }
    public void ActivateEffects()
    {
        foreach(GameObject go in effectList)
        {
            go.SetActive(true);
            EffectContinuousController controller = go.GetComponent<EffectContinuousController>();
            controller.Play();
        }
    }
    public void DeactivateEffects()
    {
        foreach(GameObject go in effectList)
        {
            EffectContinuousController controller = go.GetComponent<EffectContinuousController>();
            controller.Stop();
            go.SetActive(false);
        }
    }
}
