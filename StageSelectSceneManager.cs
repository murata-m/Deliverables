using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageSelectSceneManager : MonoBehaviour
{
    public Text highScoreText1, highScoreText2, highScoreText3, highScoreText4, highScoreText5, highScoreText6, highScoreText7, highScoreText8, highScoreText9, highScoreText10, highScoreText11, highScoreText12, highScoreText13, highScoreText14, highScoreText15, highScoreText16, highScoreText17, highScoreText18, highScoreText19, highScoreText20, highScoreText21, highScoreText22, highScoreText23, highScoreText24, highScoreText25, highScoreText26, highScoreText27, highScoreText28;
    public static int[] clearStage;
    int maxStage;
    public Button[] stageBotton;
    public AudioSource ButtonSE;
    public AudioClip pusbuttonSE;
    // Start is called before the first frame update
    [System.Obsolete]
    void Start()
    {
        maxStage = 28;
        highScoreText1.text = Stage1Setting.highScore1.ToString();
        highScoreText2.text = Stage2Setting.highScore2.ToString();
        highScoreText3.text = Stage3Setting.highScore3.ToString();
        highScoreText4.text = Stage4Setting.highScore4.ToString();
        highScoreText5.text = Stage5Setting.highScore5.ToString();
        highScoreText6.text = Stage6Setting.highScore6.ToString();
        highScoreText7.text = Stage7Settinng.highScore7.ToString();
        highScoreText8.text = Stage8Settig.highScore8.ToString();
        highScoreText9.text = Stage9Setting.highScore9.ToString();
        highScoreText10.text = Stage10Setting.highScore10.ToString();
        highScoreText11.text = Stage11Setting.highScore11.ToString();
        highScoreText12.text = Stage12Setting.highScore12.ToString();
        highScoreText13.text = Stage13Setting.highScore13.ToString();
        highScoreText14.text = Stage14Setting.highScore14.ToString();
        highScoreText15.text = Stage15Setting.highScore15.ToString();
        highScoreText16.text = Stage16Setting.highScore16.ToString();
        highScoreText17.text = Stage17Setting.highScore17.ToString();
        highScoreText18.text = Stage18Setting.highScore18.ToString();
        highScoreText19.text = Stage19Setting.highScore19.ToString();
        highScoreText20.text = Stage20Setting.highScore20.ToString();
        highScoreText21.text = Stage21Setting.highScore21.ToString();
        highScoreText22.text = Stage22Setting.highScore22.ToString();
        highScoreText23.text = Stage23Setting.highScore23.ToString();
        highScoreText24.text = Stage24Setting.highScore24.ToString();
        highScoreText25.text = Stage25Setting.highScore25.ToString();
        highScoreText26.text = Stage26Setting.highScore26.ToString();
        highScoreText27.text = Stage27Setting.highScore27.ToString();
        highScoreText28.text = Stage28Setting.highScore28.ToString();
        clearStage = new int[maxStage];
        for (int i = 0; i<maxStage; i++)
        {
            clearStage[i] = PlayerPrefs.GetInt("Stage" + (i + 1) + "Clear",0);
            if (i == 0)
            {
                stageBotton[i].interactable = true;
            }
            else
            {
                stageBotton[i].interactable = false;
                Debug.Log(stageBotton[i].interactable);
            }

        }
        

    }

    // Update is called once per frame
    [System.Obsolete]
    void Update()
    {
        for (int i = 0; i < maxStage; i++)
        {
            if (clearStage[i]==1)
            {
                stageBotton[i + 1].interactable = true;
            }

        }
    }
    public void PushStage1()
    {
        SceneManager.LoadScene("Stage 1");
    }
    public void PushStage2()
    {
        SceneManager.LoadScene("Stage 2");
    }
    public void PushStage3()
    {
        SceneManager.LoadScene("Stage 3");
    }
    public void PushStage4()
    {
        SceneManager.LoadScene("Stage 4");
    }
    public void PushStage5()
    {
        SceneManager.LoadScene("Stage 5");
    }
    public void PushStage6()
    {
        SceneManager.LoadScene("Stage 6");
    }
    public void PushStage7()
    {
        SceneManager.LoadScene("Stage 7");
    }
    public void PushStage8()
    {
        SceneManager.LoadScene("Stage 8");
    }
    public void PushStage9()
    {
        SceneManager.LoadScene("Stage 9");
    }
    public void PushStage10()
    {
        SceneManager.LoadScene("Stage 10");
    }
    public void PushStage11()
    {
        SceneManager.LoadScene("Stage 11");
    }
    public void PushStage12()
    {
        SceneManager.LoadScene("Stage 12");
    }
    public void PushStage13()
    {
        SceneManager.LoadScene("Stage 13");
    }
    public void PushStage14()
    {
        SceneManager.LoadScene("Stage 14");
    }
    public void PushStage15()
    {
        SceneManager.LoadScene("Stage 15");
    }
    public void PushStage16()
    {
        SceneManager.LoadScene("Stage 16");
    }
    public void PushStage17()
    {
        SceneManager.LoadScene("Stage 17");
    }
    public void PushStage18()
    {
        SceneManager.LoadScene("Stage 18");
    }
    public void PushStage19()
    {
        SceneManager.LoadScene("Stage 19");
    }
    public void PushStage20()
    {
        SceneManager.LoadScene("Stage 20");
    }
    public void PushStage21()
    {
        SceneManager.LoadScene("Stage 21");
    }
    public void PushStage22()
    {
        SceneManager.LoadScene("Stage 22");
    }
    public void PushStage23()
    {
        SceneManager.LoadScene("Stage 23");
    }
    public void PushStage24()
    {
        SceneManager.LoadScene("Stage 24");
    }
    public void PushStage25()
    {
        SceneManager.LoadScene("Stage 25");
    }
    public void PushStage26()
    {
        SceneManager.LoadScene("Stage 26");
    }
    public void PushStage27()
    {
        SceneManager.LoadScene("Stage 27");
    }
    public void PushStage28()
    {
        SceneManager.LoadScene("Stage 28");
    }
    public void PushButtonSE()
    {
        ButtonSE.clip = pusbuttonSE;
        ButtonSE.Play();
    }
}
