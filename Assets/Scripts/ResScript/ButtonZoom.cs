using UnityEngine;
using UnityEngine.EventSystems;

public class UIButtonZoom : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public float zoomFactor = 1.2f; 
    public float zoomSpeed = 5f;

    private Vector3 originalScale;
    private Vector3 targetScale;
    private bool isHovered = false;

    void Awake()
    {
        originalScale = GetComponent<RectTransform>().localScale;
        targetScale = originalScale * zoomFactor;
    }

    void Update()
    {
        Vector3 desiredScale = isHovered ? targetScale : originalScale;
        GetComponent<RectTransform>().localScale = Vector3.Lerp(
            GetComponent<RectTransform>().localScale,
            desiredScale,
            Time.deltaTime * zoomSpeed
        );
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isHovered = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isHovered = false;
    }
}
