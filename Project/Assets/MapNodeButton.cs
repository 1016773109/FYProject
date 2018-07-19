using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MapNodeButton : MonoBehaviour,
    IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler,
    IBeginDragHandler, IDragHandler, IEndDragHandler,
    IMoveHandler, IInitializePotentialDragHandler,
    ISubmitHandler, ICancelHandler,
    ISelectHandler, IDeselectHandler,
    IUpdateSelectedHandler, IScrollHandler, IDropHandler
{
    private SpriteRenderer sprite;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            Debug.Log("OnPointerClick");
        }
    }

    public void OnMove(AxisEventData eventData)
    {
        Debug.Log("OnMove");
    }

    void OnMouseOver()
    {
        Debug.Log("OnMouseOver");
    }

    void OnMouseDown()
    {
        Debug.Log("OnMouseDown");
    }

    void OnMouseDrag()
    {
        Debug.Log("OnMouseDrag");
    }
    void OnMouseEnter()
    {
        Debug.Log("OnMouseEnter");
    }

    void OnMouseExit()
    {
        Debug.Log("OnMouseExit");
    }
    void OnMouseUp()
    {
        Debug.Log("OnMouseUp");
    }

    void OnMouseUpAsButton()
    {
        Debug.Log("OnMouseUpAsButton");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("OnPointerUp");
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("OnPointerEnter");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("OnPointerExit");
    }

    public void OnDeselect(BaseEventData eventData)
    {
        Debug.Log("OnDeselect");
    }

    public void OnScroll(PointerEventData eventData)
    {
        Debug.Log("OnScroll");
    }

    public void OnUpdateSelected(BaseEventData eventData)
    {
        Debug.Log("OnUpdateSelected");
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
    }

    public void OnInitializePotentialDrag(PointerEventData eventData)
    {
        Debug.Log("OnInitializePotentialDrag");
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
    }

    public void OnSubmit(BaseEventData eventData)
    {
        Debug.Log("OnSubmit");
    }

    public void OnCancel(BaseEventData eventData)
    {
        Debug.Log("OnCancel");
    }

    public void OnSelect(BaseEventData eventData)
    {
        Debug.Log("OnSelect");
    }
}
