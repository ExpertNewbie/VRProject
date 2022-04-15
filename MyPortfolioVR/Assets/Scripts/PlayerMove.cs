using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float walkSpeed = 2.0f;
    [SerializeField] float runSpeed = 4.0f;
    [SerializeField] float gravity = -10.0f;
    [SerializeField] float jetFloat = 5.0f;
    Animator anim;
    float yVelocity = 0;
    CharacterController controller;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        // anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        // anim.SetFloat("Speed", v);
        Vector3 dir = new Vector3(h, 0, v);
        dir = Camera.main.transform.TransformDirection(dir);
        yVelocity += gravity * Time.deltaTime;
        if(controller.isGrounded)
        {
            yVelocity = 0;
            // anim.SetBool("Jetpack", false);
        }
        //////////////////////////////////////////////////////////////////// JetPack Use
        if(ARAVRInput.Get(ARAVRInput.Button.HandTrigger))
        {
            yVelocity += (jetFloat + -gravity) * Time.deltaTime;
            // anim.SetBool("Jetpack", true);
        }
        //////////////////////////////////////////////////////////////////// JetPack Use END
        dir.y = yVelocity;
        if(v > 0)
        {
            controller.Move(dir * runSpeed * Time.deltaTime);
        }
        else
        {
            controller.Move(dir * walkSpeed * Time.deltaTime);
        }
    }
}
