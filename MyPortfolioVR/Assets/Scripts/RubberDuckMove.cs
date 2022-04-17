using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RubberDuckMove : MonoBehaviour
{
    NavMeshAgent agent;
    float speed = 10.0f;
    float run = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
        GotoRandomPoint();
    }
    // Update is called once per frame
    void Update()
    {
        // if(agent.remainingDistance < 2.0f)
        //     GotoRandomPoint();
        // else
        // {
        // }
    }
    void GotoRandomPoint()
    {
        // Vector3 randomPoint = new Vector3(
        //     Random.Range(-70.0f, 70.0f), Random.Range(5.0f, 70.0f), Random.Range(-70.0f, 70.0f));
        // agent.SetDestination(randomPoint);
    }
    public void GotoRandomPoint(bool damaged)
    {
        if(damaged)
        {
            GotoRandomPoint();
        }
        StopAllCoroutines();
        StartCoroutine(RunningTime());
    }
    IEnumerator RunningTime()
    {
        agent.speed = speed * run;
        yield return new WaitForSeconds(7.0f);
        agent.speed = speed;
    }
}
