using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject winUI;
    public void StartGame(){
        SceneManager.LoadScene("Stage1");
    }
    public void StartStage2(){
        SceneManager.LoadScene("Stage2");
    }

    void Update(){
        bool win = true;
        if(win){
            winUI.SetActive(true);
        }
    }
}
