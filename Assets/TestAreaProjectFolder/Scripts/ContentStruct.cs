using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct ContentStruct
{
    [SerializeField] private string titleString;
    [SerializeField] private string contentString;
    [SerializeField] private Texture contentImage;
    [SerializeField] private Vector3 localPosition;
    [SerializeField] private Vector3 localRotation;

    public string TitleString
    {
        get => titleString;
        set => titleString = value;
    }

    public string ContentString
    {
        get => contentString;
        set => contentString = value;
    }

    public Texture ContentImage
    {
        get => contentImage;
        set => contentImage = value;
    }

    public Vector3 LocalPosition
    {
        get => localPosition;
        set => localPosition = value;
    }

    public Vector3 LocalRotation
    {
        get => localRotation;
        set => localRotation = value;
    }
}
