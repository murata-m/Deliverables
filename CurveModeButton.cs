using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurveModeButton : MonoBehaviour
{
    public static bool isCurveMode;
    public void OnSerectButton()
    {
        CurveModeButton.isCurveMode = true;
        RefrectModeButton.isRefrectMode = false;
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
