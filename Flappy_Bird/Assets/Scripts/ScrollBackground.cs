using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollBackground : MonoBehaviour
{
    private Image image;
    [SerializeField] float scrollSpeed = 5f;
    void Start()
    {
        image= GetComponentInChildren<Image>();
    }

    void Update()
    {
        image.material.mainTextureOffset+=Time.deltaTime*scrollSpeed*Vector2.right;
    }
}
