using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TitleSceneManager : MonoBehaviour
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

    public void pushStart()
    {
        SceneManager.LoadScene("StageSelect");
    }
    public void PushButtonSE()
    {
        ButtonSE.clip = pusbuttonSE;
        ButtonSE.Play();
    }
}
