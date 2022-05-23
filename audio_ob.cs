using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audio_ob : MonoBehaviour
{
    public AudioSource BreakTargetSE;
    public AudioClip breakSE;
    // Start is called before the first frame update
    void Start()
    {
        BreaktargetSE();
        Destroy(gameObject, 1f);
    }
    public void BreaktargetSE()
    {
        BreakTargetSE.clip = breakSE;
        BreakTargetSE.Play();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
