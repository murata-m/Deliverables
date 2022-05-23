using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ScoreDisplaySceneManager : MonoBehaviour
{
    public AudioSource ButtonSE;
    public AudioClip pusbuttonSE;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PushStageSelect()
    {
        AdMobInterstitial.buttonstate = "stageselect";
    }
    public void PushRetry()
    {
        AdMobInterstitial.buttonstate = "retry";
    }
    public void PushButtonSE()
    {
        ButtonSE.clip = pusbuttonSE;
        ButtonSE.Play();
    }
}
