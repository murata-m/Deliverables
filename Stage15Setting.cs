using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage15Setting : MonoBehaviour
{
    public static int highScore15;
    private string key1 = "HIGH SCORE15";
    // Start is called before the first frame update
    void Start()
    {
        highScore15 = PlayerPrefs.GetInt(key1, 0);

        ScoreManager.targetNum = 3;
        ScoreManager.timeLimitstart = 120;
    }

    // Update is called once per frame
    void Update()
    {
        if (ScoreManager.targetNum == 0)
        {
            if (ScoreManager.totalscore > highScore15)
            {
                highScore15 = ScoreManager.totalscore;
                PlayerPrefs.SetInt(key1, highScore15);
            }
        }
    }
}
