using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    public void StartTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }
    public void StartStage(int stage)
    {
        string stageString = "Stage" + stage.ToString();
        SceneManager.LoadScene(stageString);
    }

    public void BackToTitle()
    {
        SceneManager.LoadScene("StartMenu");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
