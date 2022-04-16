using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RubberDuckBase : MonoBehaviour
{
    float hp = 10.0f;
    RubberDuckMove moveAgent;
    // Start is called before the first frame update
    void Start()
    {
        moveAgent = GetComponentInParent<RubberDuckMove>();
    }
    // Update is called once per frame
    void Update()
    {
    }
    void OnCollisionEnter(Collision other)
    {
        bool damaged;
        // string na = other.gameObject.name;
        // if(na == water gun)
        // {
        //     damaged = true;
        //     hp - damage;
        //     sound.play();
        // }
        damaged = true;
        moveAgent.GotoRandomPoint(damaged);
    }
}
