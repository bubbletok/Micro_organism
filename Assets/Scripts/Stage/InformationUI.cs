using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InformationUI : MonoBehaviour
{
    [SerializeField] Text aminoText;
    [SerializeField] Slider awPercent;
    [SerializeField] Slider phPercent;
    [SerializeField] Slider tempPercent;
    //[SerializeField] Image oxygenImage;

    int amino;
    float aw;
    float ph;
    float temp;
    //bool oxygen;

    void Update()
    {
        amino = GameManager.Instance.amino;
        aw = GameManager.Instance.aw;
        ph = GameManager.Instance.ph;
        temp = GameManager.Instance.temp;
        //oxygen = GameManager.Instance.oxygen;
    }

    void LateUpdate()
    {
        aminoText.text = amino.ToString();
        updateAw();
        updatepH();
        updateTemp();
        //updateOxygen();
    }

    void updateAw()
    {
        if (awPercent.value <= 0)
        {
            awPercent.transform.Find("Fill Area").gameObject.SetActive(false);
        }
        else
        {
            awPercent.transform.Find("Fill Area").gameObject.SetActive(true);
        }
        awPercent.value = aw;
        awPercent.transform.Find("Figure").GetComponent<Text>().text = (aw*100).ToString() + "%";
    }

    void updatepH()
    {
        if (phPercent.value <= 0)
        {
            phPercent.transform.Find("Fill Area").gameObject.SetActive(false);
        }
        else
        {
            phPercent.transform.Find("Fill Area").gameObject.SetActive(true);
        }
        phPercent.value = ph/14;
        phPercent.transform.Find("Figure").GetComponent<Text>().text = ph.ToString();
    }

    void updateTemp()
    {
        if (tempPercent.value <= 0)
        {
            tempPercent.transform.Find("Fill Area").gameObject.SetActive(false);
        }
        else
        {
            tempPercent.transform.Find("Fill Area").gameObject.SetActive(true);
        }
        tempPercent.value = temp/100;
        tempPercent.transform.Find("Figure").GetComponent<Text>().text = temp.ToString();
    }

    /*void updateOxygen()
    {
        if (oxygen)
        {
            oxygenImage.color = new Color(0.2f, 0.2f, 0.2f, 0.4f);
        }
        else
        {
            oxygenImage.color = new Color(1, 1, 1, 1);
        }
    }*/
}
