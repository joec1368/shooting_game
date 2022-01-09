using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class changescene : MonoBehaviour , IPointerClickHandler
{
    public int number = 2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
        
    }
    

    public void OnPointerClick(PointerEventData eventData)
    {
        SceneManager.LoadScene(number);
    }
   
}
