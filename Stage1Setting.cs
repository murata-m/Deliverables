using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1Setting : MonoBehaviour
{
    public static int highScore1;
    private string key1 = "HIGH SCORE1";
    // Start is called before the first frame update
    void Start()
    {
        highScore1 = PlayerPrefs.GetInt(key1, 0);
        ScoreManager.targetNum = 3;
        ScoreManager.timeLimitstart = 120;
    }

    // Update is called once per frame
    void Update()
    {
        if (ScoreManager.targetNum == 0)
        {
            StageSelectSceneManager.clearStage[0] = 1;
            PlayerPrefs.SetInt("Stage" +1 + "Clear", StageSelectSceneManager.clearStage[0]);
            if (ScoreManager.totalscore > highScore1)
            {
                highScore1 = ScoreManager.totalscore;
                PlayerPrefs.SetInt(key1, highScore1);
            }
        }
    }
}
