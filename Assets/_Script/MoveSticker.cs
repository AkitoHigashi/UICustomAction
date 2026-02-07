using UnityEngine;
using UnityEngine.EventSystems;

public class MoveSticker : MonoBehaviour, IDragHandler
{
    private RectTransform _rectTransform;
    private void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
    }
    public void OnDrag(PointerEventData eventData)
    {
        _rectTransform.position += new Vector3(eventData.delta.x, eventData.delta.y, 0);
    }
}
