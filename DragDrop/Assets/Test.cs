using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Test : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{  
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Begin OnBeginDrag");
    }

    public void OnDrag(PointerEventData eventData)
    {

        transform.position = eventData.position;
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("Begin OnDrop");
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("Begin OnEndDrag");
    }
}
