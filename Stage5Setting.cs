using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage5Setting : MonoBehaviour
{
    public static int highScore5;
    private string key1 = "HIGH SCORE5";
    // Start is called before the first frame update
    void Start()
    {
        highScore5 = PlayerPrefs.GetInt(key1, 0);

        ScoreManager.targetNum = 3;
        ScoreManager.timeLimitstart = 120;
    }

    // Update is called once per frame
    void Update()
    {
        if (ScoreManager.targetNum == 0)
        {
            if (ScoreManager.totalscore > highScore5)
            {
                highScore5 = ScoreManager.totalscore;
                PlayerPrefs.SetInt(key1, highScore5);
            }
        }
    }
}
