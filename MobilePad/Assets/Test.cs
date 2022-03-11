using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Test : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    [SerializeField] private RectTransform rect_Background;
    [SerializeField] private RectTransform rect_Joystick;

    private float radius;

    [SerializeField] private GameObject go_Player;
    [SerializeField] private float moveSpeed;

    private bool isTouch = false;
    private Vector3 movePostion;

 
    void Start()
    {
        radius = rect_Background.rect.width * 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if(isTouch)
        {
            go_Player.transform.position += movePostion;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 value = eventData.position - (Vector2) rect_Background.position;

        value = Vector2.ClampMagnitude(value, radius);
        rect_Joystick.localPosition = value;

        float distance = Vector2.Distance(rect_Background.position, rect_Joystick.position) / radius;
        value = value.normalized;
        movePostion = new Vector3(
            value.x * moveSpeed * distance * Time.deltaTime,
            0f,
            value.y * moveSpeed * distance * Time.deltaTime
        );
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isTouch = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isTouch = false;
        rect_Joystick.localPosition = Vector3.zero;
        movePostion = Vector3.zero;
    }

}
