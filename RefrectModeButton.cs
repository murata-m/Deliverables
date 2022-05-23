using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefrectModeButton : MonoBehaviour
{
    public static bool isRefrectMode;

    public void OnSerectBotton()
    {
        CurveModeButton.isCurveMode = false;
        RefrectModeButton.isRefrectMode = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
