using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class Slot : MonoBehaviour, IDropHandler
{
    [SerializeField] private ScoreManager scoreManager; 
    public int slotId;
    TextMeshProUGUI nameTxt;

    private void Awake()
    {
        nameTxt = GetComponentInChildren<TextMeshProUGUI>();
        nameTxt.text = slotId.ToString();
    }

    public void OnDrop(PointerEventData eventData)
    {
        GameObject draggedItem = eventData.pointerDrag;
        DragAndDrop draggable = draggedItem.GetComponent<DragAndDrop>();
        if(draggable != null)
        {
            if(draggable.id == slotId)
            {
                draggedItem.GetComponent<RectTransform>().position = GetComponent<RectTransform>().position;
                draggedItem.GetComponent<Image>().color = Color.grey;
                draggable.canDrag = false;
                // Add Score
                scoreManager.AddScore(1);

            }
            else
            {
                draggable.ResetPosition();
            }
        }
        
        

    }
}
