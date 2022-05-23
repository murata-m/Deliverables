using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage8Settig : MonoBehaviour
{
    public GameObject target1, target2, target3;
    Vector3 pos1, pos2, pos3; 
    public static int highScore8;
    private string key1 = "HIGH SCORE8";
    // Start is called before the first frame update
    void Start()
    {
        highScore8 = PlayerPrefs.GetInt(key1, 0);

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
            if (ScoreManager.totalscore > highScore8)
            {
                highScore8 = ScoreManager.totalscore;
                PlayerPrefs.SetInt(key1, highScore8);
            }
        }
        if (target1 != null)
        {
            target1.transform.position = new Vector3(pos1.x + Mathf.Sin(Time.time * 0.5f) * 30, pos1.y, pos1.z);

        }
        if (target2 != null)
        {
            target2.transform.position = new Vector3(pos2.x + Mathf.Sin(Time.time) * 30, pos2.y, pos2.z);
        }
        if (target3 != null)
        {
            target3.transform.position = new Vector3(pos3.x + Mathf.Sin(Time.time * 0.8f) * 20, pos3.y, pos3.z);

        }
    }
}
