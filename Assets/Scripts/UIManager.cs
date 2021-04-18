using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public CanvasGroup canvasGroup;

    public void ShowUI(float time = 0.5f)
    {
        //canvasGroup.alpha = Mathf.Lerp(0, 1, 0.5f);
        canvasGroup.DOFade(1, time);
    } 

    public void HideUI()
    {
        canvasGroup.DOFade(0, 1f).onComplete = () =>
        {
            gameObject.SetActive(false);
        };
    }
}
