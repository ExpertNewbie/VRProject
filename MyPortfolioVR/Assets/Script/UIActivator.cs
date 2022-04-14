using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIActivator : MonoBehaviour
{
    [SerializeField] GameObject UI;
    [SerializeField] Transform player;
    [SerializeField] float uiUP = 150.0f;
    [SerializeField] float uiDistance = 300.0f;
    public bool isOpen = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(ARAVRInput.Get(ARAVRInput.Button.StartMenu))
        {
            if(!isOpen)
            {
                isOpen = true;
                Vector3 uiPosition = transform.position
                + (transform.forward * uiDistance) + (transform.up * uiUP);
                Vector3 uiV3 = player.rotation.eulerAngles;
                Debug.Log(uiV3.y);
                GameObject clone = Instantiate(UI, uiPosition, Quaternion.Euler(0, uiV3.y, 0));
                ButtonController bc = clone.GetComponent<ButtonController>();
                bc.activator = this;
            }
        }
    }
}
