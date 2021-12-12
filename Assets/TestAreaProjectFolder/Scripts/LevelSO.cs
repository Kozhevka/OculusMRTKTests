using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "ScriptableObjects/LevelData", order = 1)]
public class LevelSO : ScriptableObject
{
    [SerializeField] private string title;
    [SerializeField] private Texture level360Texture;
    [SerializeField] private Texture levelImage;
    [SerializeField] private ContentStruct[] contentDatas;

    public string Title => title;
    public Texture Level360Texture => level360Texture;
    public Texture LevelImage => levelImage;
    public ContentStruct[] ContentDatas => contentDatas;

    public void LoadData(Texture levelTexture, ContentStruct[] content)
    {
        contentDatas = content;
        
        if (levelTexture != null)
        {
            level360Texture = levelTexture;
            return;
        }
        
        Debug.Log("360 texture is null");
    }
}
