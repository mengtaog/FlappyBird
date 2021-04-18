using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tools 
{
    private static Tools _instance = null;

    public static Tools Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = new Tools();
            }
            return _instance;
        }
    }

    public void ShowUIObj(GameObject obj, float time = 0.5f)
    {
        obj.SetActive(true);
        obj.GetComponent<CanvasGroup>().alpha = 0;
        obj.GetComponent<UIManager>().ShowUI(time);
    }

    public void HideUIObj(GameObject obj)
    {
        obj.GetComponent<UIManager>().HideUI();
        obj.SetActive(false);
    }

    Tools()
    {

    }

   

}
