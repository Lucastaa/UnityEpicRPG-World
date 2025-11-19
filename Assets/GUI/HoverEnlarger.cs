using UnityEngine;
using UnityEngine.EventSystems;

public class HoverEnlarger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public float sizeDifference = 1.05f;

    private Vector2 originalSize;
    private RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        originalSize = rectTransform.localScale;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        rectTransform.localScale = originalSize * sizeDifference;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        rectTransform.localScale = originalSize;
    }
}
