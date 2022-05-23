using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage2Setting : MonoBehaviour
{
    public static int highScore2;
    private string key1 = "HIGH SCORE2";
    // Start is called before the first frame update
    void Start()
    {
        highScore2 = PlayerPrefs.GetInt(key1, 0);
        ScoreManager.targetNum = 3;
        ScoreManager.timeLimitstart = 120;
    }

    // Update is called once per frame
    void Update()
    {
        if (ScoreManager.targetNum == 0)
        {
            if (ScoreManager.totalscore > highScore2)
            {
                highScore2 = ScoreManager.totalscore;
                PlayerPrefs.SetInt(key1, highScore2);
            }
        }
    }
}
