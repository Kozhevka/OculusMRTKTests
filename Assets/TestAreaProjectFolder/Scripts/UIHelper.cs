using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHelper : MonoBehaviour
{
    private const float visibleValue = 1;
    private const float invisibleValue = 0;


    public void ToggleCanvasGroupVisibility(CanvasGroup canvasGroup, bool bValue)
    {
        canvasGroup.blocksRaycasts = bValue ? true : false;
        canvasGroup.alpha = bValue ? visibleValue : invisibleValue;
    }
}
