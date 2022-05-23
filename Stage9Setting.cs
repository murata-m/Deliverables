using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage9Setting : MonoBehaviour
{
    public GameObject target1, target2, target3;
    Vector3 pos1, pos2, pos3;
    public static int highScore9;
    private string key1 = "HIGH SCORE9";
    // Start is called before the first frame update
    void Start()
    {
        highScore9 = PlayerPrefs.GetInt(key1, 0);

        ScoreManager.targetNum = 3;
        ScoreManager.timeLimitstart = 120;
        pos1 = target1.transform.position;
        pos2 = target2.transform.position;
        pos3 = target3.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (ScoreManager.targetNum == 0)
        {
            if (ScoreManager.totalscore > highScore9)
            {
                highScore9 = ScoreManager.totalscore;
                PlayerPrefs.SetInt(key1, highScore9);
            }
        }
        if (target1 != null)
        {
            target1.transform.position = new Vector3(pos1.x + Mathf.Sin(Time.time * 0.8f) * 30, pos1.y, pos1.z);

        }
        if (target2 != null)
        {
            target2.transform.position = new Vector3(pos2.x , pos2.y + Mathf.Sin(Time.time) * 25, pos2.z);
        }
        if (target3 != null)
        {
            target3.transform.position = new Vector3(pos3.x , pos3.y, pos3.z + Mathf.Sin(Time.time * 0.8f) * 20);

        }
    }
}
