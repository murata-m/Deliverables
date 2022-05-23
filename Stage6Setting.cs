using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage6Setting : MonoBehaviour
{
    public static int highScore6;
    private string key1 = "HIGH SCORE6";
    // Start is called before the first frame update
    void Start()
    {
        highScore6 = PlayerPrefs.GetInt(key1, 0);

        ScoreManager.targetNum = 3;
        ScoreManager.timeLimitstart = 120;
    }

    // Update is called once per frame
    void Update()
    {
        if (ScoreManager.targetNum == 0)
        {
            if (ScoreManager.totalscore > highScore6)
            {
                highScore6 = ScoreManager.totalscore;
                PlayerPrefs.SetInt(key1, highScore6);
            }
        }
    }
}
