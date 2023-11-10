using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ShowText : MonoBehaviour
{
    [SerializeField] Text description;
    string text = "게임 설명 :\r\n아미노산을 사용하여 상대 식중독균을 물리치고,\n식품에 들어가 인간에게 해를 입히면 승리한다.";

    bool canShow = true;
    int curIdx = 0;
    // Update is called once per frame
    void Update()
    {
        if (canShow && curIdx<text.Length)
        {
            canShow = false;
            description.text += text[curIdx++];
            StartCoroutine(WaitToShow());
        }
        if(curIdx == text.Length)
        {
            curIdx++;
            StartCoroutine(WaitToSkip());
        }
    }

    IEnumerator WaitToShow()
    {
        yield return new WaitForSeconds(0.1f);
        canShow = true;
    }

    IEnumerator WaitToSkip()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Stage1");
    }
}
