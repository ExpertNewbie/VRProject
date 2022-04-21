using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRotate : MonoBehaviour
{
    Vector3 angle;
    [SerializeField] float moveSensitivity = 200.0f;
    // Start is called before the first frame update
    void Start()
    {
        // angle.x = Camera.main.transform.eulerAngles.y;
        // angle.y =-Camera.main.transform.eulerAngles.x;
        // angle.z = Camera.main.transform.eulerAngles.z;
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");
        angle.x += x * moveSensitivity * Time.deltaTime;
        angle.y += y * moveSensitivity * Time.deltaTime;
        transform.eulerAngles = new Vector3(-angle.y, angle.x, transform.eulerAngles.z);
    }
}
