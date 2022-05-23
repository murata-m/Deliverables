using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoMove : MonoBehaviour
{
    public static int go;
    public AudioSource playerSE;
    public AudioClip runningSE;
    public void Go()
    {
        BackMove.back = 0;
        go = 1;
    }
    public void Stop()
    {
        BackMove.back = 0;
        go = 0;
    }
    public void RunningSE()
    {
        playerSE.clip = runningSE;
        playerSE.Play();
    }
    public void StopRunningSE()
    {
        playerSE.Stop();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
