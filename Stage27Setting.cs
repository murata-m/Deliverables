using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage27Setting : MonoBehaviour
{
    public static int highScore27;
    private string key1 = "HIGH SCORE27";
    public GameObject target1, target2, target3, pillar, block;
    Vector3 pos1, pos2, pos3;
    // Start is called before the first frame update
    void Start()
    {
        highScore27 = PlayerPrefs.GetInt(key1, 0);

        ScoreManager.targetNum = 3;
        ScoreManager.timeLimitstart = 120;
        pos1 = target1.transform.localPosition;
        pos2 = target2.transform.localPosition;
        pos3 = target3.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (ScoreManager.totalscore > highScore27)
        {
            highScore27 = ScoreManager.totalscore;
            PlayerPrefs.SetInt(key1, highScore27);
        }
        pillar.transform.Rotate(new Vector3(0, 0, -1.5f));
        //block.transform.Rotate(new Vector3(1.05f * Mathf.Sin(Time.time * 0.5f), 0, 0));
        if (target1 != null)
        {
            target1.transform.localPosition = new Vector3(pos1.x, pos1.y, pos1.z) + target1.transform.forward* Mathf.Sin(Time.time * 0.6f) * 5 ;
            //target1.transform.Rotate(new Vector3(0, 0, 1));
        }
        if (target2 != null)
        {
            target2.transform.localPosition = new Vector3(pos2.x, pos2.y, pos2.z) + target2.transform.right * Mathf.Sin(Time.time * 0.6f) * 8;
        }
        if (target3 != null)
        {
            // target3.transform.localPosition = new Vector3(pos3.x, pos3.y, pos3.z) + target3.transform.right * Mathf.Sin(Time.time * 0.5f) * 8;
            target3.transform.Rotate(new Vector3(0, 0, 2));
        }
    }
}
