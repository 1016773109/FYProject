using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MapNodeButton : EventTrigger
{
    private SpriteRenderer sprite;
    private Color32 NormalColor = new Color32(255, 255, 255, 255);
    private Color32 HighlightedColor = new Color32(245, 245, 245, 255);
    private Color32 PressedColor = new Color32(200, 200, 200, 255);
    private Color32 DisabledColor = new Color32(200, 200, 200, 128);

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }


    void SetColor(Color32 color)
    {
        sprite.color = color;
    }

    public override void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("OnPointerEnter");
        SetColor(HighlightedColor);
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("OnPointerExit");
        SetColor(NormalColor);
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
        SetColor(PressedColor);
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("OnPointerUp");
        SetColor(HighlightedColor);
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            Debug.Log("OnPointerClick");
        }
    }

    void OnMouseOver()
    {
        Debug.Log("OnMouseOver");
    }

}
