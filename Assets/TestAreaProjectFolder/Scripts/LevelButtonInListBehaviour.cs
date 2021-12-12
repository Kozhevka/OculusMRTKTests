using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelButtonInListBehaviour : MonoBehaviour
{
    [SerializeField] private RawImage levelIcon;

    [SerializeField] private Button thisButton;

    [SerializeField] private LevelSO thisLevel;

    private LevelManager levelManager;
    
    private void Reset()
    {
        if (TryGetComponent(out Button button))
            thisButton = button;
        
        if (transform.GetChild(0).TryGetComponent(out RawImage rawImage))
            levelIcon = rawImage;
    }

    private void OnEnable()
    {
        thisButton.onClick.AddListener(OpenThisLevel);
    }

    private void OnDisable()
    {
        thisButton.onClick.RemoveListener(OpenThisLevel);
    }

    public void LoadData(LevelSO level, LevelManager levelManager)
    {
        this.levelManager = levelManager;
        
        thisLevel = level;
        levelIcon.texture = level.LevelImage;
    }

    private void OpenThisLevel()
    {
        levelManager.OpenSelectedLevel(thisLevel);
    }
}
