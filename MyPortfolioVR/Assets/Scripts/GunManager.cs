using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunManager : MonoBehaviour
{
    List<GameObject> effectList = new List<GameObject>();
    [SerializeField] GameObject gunRight;
    [SerializeField] GameObject gunLeft;
    GunController controllerRight;
    GunController controllerLeft;
    // Start is called before the first frame update
    void Start()
    {
        controllerRight=gunRight.GetComponent<GunController>();
        controllerLeft = gunLeft.GetComponent<GunController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(ARAVRInput.GetDown(ARAVRInput.Button.IndexTrigger, ARAVRInput.Controller.LTouch))
        {
            shootWaterPistol(ARAVRInput.Controller.LTouch);
        }
        if(ARAVRInput.GetDown(ARAVRInput.Button.IndexTrigger, ARAVRInput.Controller.RTouch))
        {
            shootWaterPistol(ARAVRInput.Controller.RTouch);
        }
    }
    void shootWaterPistol(ARAVRInput.Controller hand)
    {
        // ARAVRInput.PlayVibration(hand);
        switch(hand)
        {
            case ARAVRInput.Controller.RTouch :
                controllerRight.Shoot();
                break;
            default :
                controllerLeft.Shoot();
                break;
        }
    }
}
