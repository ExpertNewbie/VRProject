using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectContinuousController : MonoBehaviour
{
    public List<AudioClip> soundEffectList = new List<AudioClip>();
    [SerializeField] ParticleSystem ve;
    [SerializeField] AudioSource se;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Play()
    {
        se.clip = soundEffectList[Random.Range(0, soundEffectList.Count-1)];
        se.Play();
        ve.Play();
    }
    public void Stop()
    {
        se.Stop();
        ve.Stop();
    }
}
