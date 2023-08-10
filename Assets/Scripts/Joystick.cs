
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    public RectTransform handle;
    public RectTransform outLine;

    private float deadZone = 0;
    private float handleRange = 1;
    private Vector3 input = Vector3.zero;
    private Canvas canvas;

    public float Horizontal { get { if (input.x > 0) { return 1; } else if (input.x < 0) return -1; else return 0; } }

    void Start()
    {
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        outLine = gameObject.GetComponent<RectTransform>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 radius = outLine.sizeDelta / 2;
        Vector2 clickPosition = eventData.position; // Ŭ���� ��ġ
        Vector2 centerPosition = outLine.position; // �ƿ������� �߽� ��ġ
        Vector2 direction = clickPosition - centerPosition; // Ŭ���� ��ġ�� �ƿ����� �߽ɰ��� ���� ����
        float distance = Mathf.Min(direction.magnitude, radius.x * canvas.scaleFactor); // Ŭ���� ��ġ�� �ƿ����� �߽� ������ �Ÿ��� �ƿ����� ���������� ����
        input = direction.normalized * (distance / (radius.x * canvas.scaleFactor)); // �Է� ���� ���� ������ ����ȭ ������ ����
        HandleInput(input.magnitude, input.normalized);
        handle.anchoredPosition = input * radius * handleRange;
    }

    //public void OnDrag(PointerEventData eventData)
    //{
    //    Vector2 radius = outLine.sizeDelta / 2;
    //    input = (eventData.position - outLine.anchoredPosition) / (radius * canvas.scaleFactor);
    //    HandleInput(input.magnitude, input.normalized);
    //    handle.anchoredPosition = input * radius * handleRange;
    //}

    private void HandleInput(float magnitude, Vector2 normalised)
    {
        if (magnitude > deadZone)
        {
            if (magnitude > 1)
            {
                input = normalised;
            }
        }
        else
        {
            input = Vector2.zero;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        input = Vector2.zero;
        handle.anchoredPosition = Vector2.zero;

    }
}