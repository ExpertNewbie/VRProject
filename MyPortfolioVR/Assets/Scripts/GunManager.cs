using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunManager : MonoBehaviour
{
    List<GameObject> effectList = new List<GameObject>();
    [SerializeField] GameObject gunRight;
    [SerializeField] GameObject gunLeft;
    [SerializeField] GameObject waterHitSplash;
    GunController controllerRight;
    GunController controllerLeft;
    // Start is called before the first frame update
    void Start()
    {
        controllerRight=gunRight.GetComponent<GunController>();
        controllerLeft = gunLeft.GetComponent<GunController>();
        for(int i=0; i<20; i++)
        {
            GameObject go = Instantiate(waterHitSplash);
            go.transform.position = Vector3.down * 10;
            go.SetActive(false);
            effectList.Add(go);
        }
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
Debug.Log("shootWaterPistol : "+hand);
        Ray ray = new Ray();
        ARAVRInput.PlayVibration(hand);
        if(hand == ARAVRInput.Controller.RTouch)
        {
Debug.Log("ARAVRInput.Controller.RTouch");
            controllerRight.Shoot();
            ray = new Ray(gunRight.transform.position, gunRight.transform.forward);
        }
        else
        {
Debug.Log("ARAVRInput.Controller.LTouch");
            controllerLeft.Shoot();
            ray = new Ray(gunLeft.transform.position, gunLeft.transform.forward);
        }
        RaycastHit hitInfo;
        int playerLayer = 1 << LayerMask.NameToLayer("Player");
        int invisibleLayer = 1 << LayerMask.NameToLayer("Invisible");
        int layerMask = playerLayer | invisibleLayer;
        if(Physics.Raycast(ray, out hitInfo, 20.0f, ~layerMask))
        {
Debug.Log("Raycast");
            // GameObject go = Instantiate(waterSplash, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
            if(effectList.Count > 0)
            {
                GameObject go = effectList[0];
                effectList.RemoveAt(0);
                go.transform.position = hitInfo.point;
                go.transform.rotation = Quaternion.LookRotation(hitInfo.normal);
                go.SetActive(true);
                ParticleSystem effect = go.GetComponentInChildren<ParticleSystem>();
                effect.Play();
                effectList.Add(go);
            }
        }
    }
}
