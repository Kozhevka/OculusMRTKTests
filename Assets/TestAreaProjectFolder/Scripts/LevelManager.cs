using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private LevelSO[] levelsSO;
    [SerializeField] private Renderer sphere360Renderer;
    [SerializeField] private Transform contentHolder;
    [SerializeField] private ContentBehaviour contentPrefab;

    [SerializeField] private LevelListBehaviour levelListPanel;

    private void Start()
    {
        levelListPanel.CreateLevelButtonForEachLevel(levelsSO, this);
    }

    public void OpenSelectedLevel(LevelSO level)
    {
        foreach (Transform child in contentHolder)
            Destroy(child.gameObject);
        
        levelListPanel.CurentLevelText.text = level.Title;
        sphere360Renderer.material.mainTexture = level.Level360Texture;
        
        foreach (var contentData in level.ContentDatas)
        {
            var newPointOfInterest = Instantiate(contentPrefab, contentHolder);

            newPointOfInterest.transform.localPosition = contentData.LocalPosition;
            newPointOfInterest.transform.localRotation = Quaternion.Euler(contentData.LocalRotation);
            
            newPointOfInterest.LoadData(contentData);
        }
    }
}
