using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelListBehaviour : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI curentLevelText;
    [SerializeField] private Transform contentHolder;
    [SerializeField] private LevelButtonInListBehaviour levelButtonInListPrefab;

    public TextMeshProUGUI CurentLevelText => curentLevelText;
    public Transform ContentHolder => contentHolder;
    
    public void CreateLevelButtonForEachLevel(LevelSO[] levelsSO, LevelManager levelManager)
    {
        foreach (Transform child in contentHolder)
            Destroy(child.gameObject);
        
        foreach (var levelSo in levelsSO)
        {
            var newLevelButton = Instantiate(levelButtonInListPrefab, contentHolder);
            newLevelButton.LoadData(levelSo, levelManager);
        }
    }
}
