using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class DragAndDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas canvas;
    public int id;
    public bool canDrag = true;

    RectTransform rectTransform;
    CanvasGroup canvasGroup;
    TextMeshProUGUI nameTxt;
    Vector2 intPosition;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        nameTxt = GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Start()
    {
        nameTxt.text = id.ToString();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        intPosition = rectTransform.anchoredPosition;
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (canDrag) rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
        if (canDrag)
        {
            ResetPosition();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
    }

    public void ResetPosition()
    {
        rectTransform.anchoredPosition = intPosition;
    }
}
