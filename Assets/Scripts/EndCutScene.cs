using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndCutScene : MonoBehaviour
{
    [SerializeField] GameObject[] cuts;
    [SerializeField] float showDelay;
    int curIdx = 0;
    bool canShow = true;
    // Update is called once per frame
    void Update()
    {
        if (curIdx == 3)
        {
            showDelay = 3.0f;
        }
        if (canShow && curIdx<cuts.Length)
        {
            canShow = false;
            cuts[curIdx++].SetActive(true);
            StartCoroutine(WaitToShow());
        }
        if (curIdx == cuts.Length)
        {
            StartCoroutine(WaitToGoTitle());
        }

    }


    IEnumerator WaitToGoTitle()
    {
        yield return new WaitForSeconds(5.0f);
        SceneManager.LoadScene("StartMenu");
    }

    IEnumerator WaitToShow()
    {
        yield return new WaitForSeconds(showDelay);
        canShow = true;
    }
}
