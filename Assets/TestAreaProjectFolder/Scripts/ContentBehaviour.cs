using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ContentBehaviour : UIHelper
{
    [SerializeField] private Button buttonOnSphere;
    [SerializeField] private Button closeWindowButton;
    
    [SerializeField] private CanvasGroup canvasWindow;
    [SerializeField] private RawImage contentImage;
    [SerializeField] private TextMeshProUGUI titleTextHolder;
    [SerializeField] private TextMeshProUGUI contentTextHolder;

    [Header("Quick data writer, after enter, loadData in contextMenu")]
    [SerializeField] private string title;
    [SerializeField, TextArea(2,5)] private string description;
    [SerializeField] private Texture image;
    
    
    private void OnEnable()
    {
        buttonOnSphere.onClick.AddListener(OpenButtonClick);
        closeWindowButton.onClick.AddListener(CloseButtonClick);
    }

    private void OnDisable()
    {
        buttonOnSphere.onClick.RemoveListener(OpenButtonClick);
        closeWindowButton.onClick.RemoveListener(CloseButtonClick);
    }

    public void LoadData(ContentStruct contentData)
    {
        transform.localPosition = contentData.LocalPosition;
        transform.localRotation = Quaternion.Euler(contentData.LocalRotation);

        titleTextHolder.text = contentData.TitleString;
        contentTextHolder.text = contentData.ContentString;
        contentImage.texture = contentData.ContentImage;
    }

    public ContentStruct GetContentDataStruct()
    {
        var contentData = new ContentStruct();
        contentData.LocalPosition = transform.localPosition;
        contentData.LocalRotation = transform.localRotation.eulerAngles;

        contentData.TitleString = titleTextHolder.text == "" ? "NUll" : titleTextHolder.text;
        contentData.ContentString = contentTextHolder.text == "" ? "NUll" : contentTextHolder.text;
        contentData.ContentImage = contentImage.texture == null ? null : contentImage.texture;

        return contentData;
    }

    [ContextMenu("Overwrite fields")]
    private void OverwriteData()
    {
        titleTextHolder.text = title;
        contentTextHolder.text = description;
        contentImage.texture = image;
    }
    
    private void OpenButtonClick()
    {
        ToggleCanvasGroupVisibility(canvasWindow, true);
    }

    private void CloseButtonClick()
    {
        ToggleCanvasGroupVisibility(canvasWindow, false);
    }
}
