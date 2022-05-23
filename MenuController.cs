using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject UI,BackGameAndStageSelect,Panel;
    // Start is called before the first frame update
    void Start()
    {
        Panel.SetActive(false);
        BackGameAndStageSelect.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PushMenuBotton()
    {
        UI.SetActive(false);
        Panel.SetActive(true);
        Time.timeScale = 0f;

        BackGameAndStageSelect.SetActive(true);
    }

    public void BackGame()
    {
        UI.SetActive(true);
        Panel.SetActive(false);
        Time.timeScale = 1f;

        BackGameAndStageSelect.SetActive(false);

    }

    public void BackStageSelect()
    {
        SceneManager.LoadScene("StageSelect");
    }
}
