using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public GameObject score_object,timeLimit_object,paraTime_object,paraScore_object,paraTotalScore_object,targetNum_object;
    public static int score;
    public static int totalscore;
    public GameObject UI,clearText,scoreDisplay,timeOverText;
    bool isdisplay=true;
    public static int targetNum;
    public static int timeLimitstart;
    int timeLimit;
    float timebefore;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        timebefore = Time.time;
        clearText.SetActive(false);
        scoreDisplay.SetActive(false);
        paraTime_object.SetActive(false);
        paraScore_object.SetActive(false);
        paraTotalScore_object.SetActive(false);
        UI.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        Text targetNum_text = targetNum_object.GetComponent<Text>();
        Text score_text = score_object.GetComponent<Text>();
        Text timeLimit_text = timeLimit_object.GetComponent<Text>();
        Text paraTime_text = paraTime_object.GetComponent<Text>();
        Text paraScore_text = paraScore_object.GetComponent<Text>();
        Text paraTotalScore_text = paraTotalScore_object.GetComponent<Text>();
        score_text.text = "Score: "+score;
        targetNum_text.text = "Å~ " + targetNum;
        if (targetNum != 0)
        {
            timeLimit = (int)(timeLimitstart - (Time.time-timebefore));
        }
        timeLimit_text.text = "TimeLimit: " + timeLimit;

        if (targetNum == 0)
        {
            int time = timeLimit;
            paraTime_text.text = time+" Å~2 = "+time*2;
            paraScore_text.text = "" + score;
            totalscore = score + time * 2;
            paraTotalScore_text.text = "" + totalscore;
            if (isdisplay)
            {
                clearText.SetActive(true);
            }
            UI.SetActive(false);
            Invoke("DeleteClear", 2f);
            Invoke("ScoreDisplay", 2f);
        }
        if (timeLimit <= 0)
        {
            timeLimit = 0;
            int time = timeLimit;
            score = 0;
            paraTime_text.text = time + " Å~2 = " + (time * 2);
            paraScore_text.text = "" + score;
            paraTotalScore_text.text = "" + (score + time * 2);
            UI.SetActive(false);
            if (isdisplay)
            {
                timeOverText.SetActive(true);
            }
            Invoke("DeleteTimeOver", 2f);
            Invoke("ScoreDisplay", 2f);

        }
    }

    public void DeleteClear()
    {
        clearText.SetActive(false);
        isdisplay = false;
    }

    public void DeleteTimeOver()
    {
        timeOverText.SetActive(false);
        isdisplay = false;
    }
    public void ScoreDisplay()
    {
        scoreDisplay.SetActive(true);
        Invoke("paratime", 1f);
        Invoke("parascore", 2f);
        Invoke("paratotalscore", 4f);
    }
    public void paratime()
    {
        paraTime_object.SetActive(true);
    }
    public void parascore()
    {
        paraScore_object.SetActive(true);
    }
    public void paratotalscore()
    {
        paraTotalScore_object.SetActive(true);
    }
}
