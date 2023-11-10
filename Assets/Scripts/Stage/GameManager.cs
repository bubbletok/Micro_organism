using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.Rendering.DebugUI;

public class GameManager : MonoBehaviour
{
    public float aw,ph,temp;
    //public bool oxygen;
    public int amino;
    [SerializeField] GameObject winUI;
    [SerializeField] GameObject defeatUI;
    [SerializeField] GameObject resumeUI;
    [SerializeField] string nextScene;

    GameObject ourSpawner;
    GameObject[] enemySpanwer;
    bool canGetAmino = true;

    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            return _instance;
        }
    }

    void Awake()
    {
        _instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        ourSpawner = GameObject.FindGameObjectWithTag("OurSpawner");
        enemySpanwer = GameObject.FindGameObjectsWithTag("EnemySpawner");
    }


    // Update is called once per frame
    void Update()
    {
        ourSpawner = GameObject.FindGameObjectWithTag("OurSpawner");
        enemySpanwer = GameObject.FindGameObjectsWithTag("EnemySpawner");
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseResumeGame();
        }
        if (enemySpanwer.Length == 0)
        {
            StartCoroutine(StartNext());
            //winUI.SetActive(true);
        }
        if (ourSpawner == null)
        {
            StartCoroutine(Defeat());
            //defeatUI.SetActive(false);
        }
        if (canGetAmino)
        {
            canGetAmino = false;
            amino++;
            StartCoroutine(WaitToGetAmino());
        }
        if (amino < 0)
        {
            amino = 0;
        }
    }

    IEnumerator WaitToGetAmino()
    {
        yield return new WaitForSeconds(3);
        canGetAmino = true;
    }


    IEnumerator StartNext()
    {
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene(nextScene);
    }

    IEnumerator Defeat()
    {
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene("DefeatEnding");
    }

    IEnumerator Restart()
    {
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    void PauseResumeGame()
    {
        Time.timeScale = Time.timeScale == 0 ? 1 : 0;
    }
}
