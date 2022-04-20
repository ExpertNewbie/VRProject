using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RubberDuckMove : MonoBehaviour
{
    GameEffectManager effectManager;
    GameBaseData.MonsterData data;
    NavMeshAgent agent;
    // float speed = 10.0f;
    // float run = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        effectManager = GameObject.Find("GameEffectManager").GetComponent<GameEffectManager>();
        data = GameBaseData.Instance().GetDuckData(name);
        agent = GetComponent<NavMeshAgent>();
        agent.speed = data.Speed;
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
        agent.speed = data.Speed * data.RunPower;
        yield return new WaitForSeconds(7.0f);
        agent.speed = data.Speed;
    }
}
