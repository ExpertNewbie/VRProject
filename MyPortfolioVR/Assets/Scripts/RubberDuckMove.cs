using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RubberDuckMove : MonoBehaviour
{
    NavMeshAgent agent;
    float speed = 2.0f;
    float run = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
        agent.height = 20.0f;
        GotoRandomPoint();
    }
    // Update is called once per frame
    void Update()
    {
        if(agent.remainingDistance < 2.0f)
            GotoRandomPoint();
    }
    void GotoRandomPoint()
    {
        Vector3 randomPoint = new Vector3(
            Random.Range(-240.0f, 240.0f), 
            Random.Range(5.0f, 300.0f), 
            Random.Range(-240.0f, 240.0f));
Debug.Log(randomPoint);
        agent.SetDestination(randomPoint);
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
        yield return new WaitForSeconds(5.0f);
        agent.speed = speed;
    }
}
