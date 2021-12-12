using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class NewLevelReader : MonoBehaviour
{
    [SerializeField] private Transform contentHolder;
    [SerializeField] private Renderer sphereRenderer;
    [SerializeField] private string folderPathAndDefaultName = "Assets/yourFileName.asset";

#if  UNITY_EDITOR
    
    [ContextMenu("Create new levelSO based on current setup")]
    public void CreateLevelSOAsset()
    {
        var newLevel = ScriptableObject.CreateInstance<LevelSO>();

        AssetDatabase.CreateAsset(newLevel, folderPathAndDefaultName);
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();
        
        newLevel.LoadData(sphereRenderer.material.mainTexture, GetAllStructs()); 
        
        Debug.Log($"New levelSO created with {newLevel.ContentDatas.Length} points of interest");
        Selection.activeObject = newLevel;
    }
    
#endif

    private ContentStruct[] GetAllStructs()
    {
        var contentStructs = new ContentStruct[contentHolder.childCount];
        
        for (int i = 0; i < contentStructs.Length; i++)
        {
            if (contentHolder.GetChild(i).TryGetComponent(out ContentBehaviour contentBehaviour))
            {
                contentStructs[i] = contentBehaviour.GetContentDataStruct();
                continue;
            }
            Debug.LogError($"Cant get content behaviour in {i} child");
        }

        return contentStructs;
    }
    
    
}
