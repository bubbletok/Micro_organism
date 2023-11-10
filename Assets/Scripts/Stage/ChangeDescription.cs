using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChangeDescription : MonoBehaviour
{
    [SerializeField] Sprite description;
    [SerializeField] GameObject memo;
    Camera camera;
    

    private void Awake()
    {
        camera = FindObjectOfType<Camera>();
    }

    // Start is called before the first frame update
    void Start()
    {
/*        memo = GameObject.Find("Description");
        if (memo.activeSelf)
        {
            memo.SetActive(false);
        }*/
    }

    private void Update()
    {
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Physics.Raycast(ray, out hit);
    }

    void OnMouseEnter()
    {
        print("Mouse Over");
        memo.gameObject.SetActive(true);
        memo.GetComponent<Image>().sprite = description;
    }
    void OnMouseExit()
    {
        print("Mouse Exit");
        memo.SetActive(false);
    }
}
