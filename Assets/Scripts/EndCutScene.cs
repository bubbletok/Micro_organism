using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            showDelay = 2f;
        }
        if (canShow && curIdx<cuts.Length)
        {
            canShow = false;
            cuts[curIdx++].SetActive(true);
            StartCoroutine(WaitToShow());
        }

    }

    IEnumerator WaitToShow()
    {
        yield return new WaitForSeconds(showDelay);
        canShow = true;
    }
}
