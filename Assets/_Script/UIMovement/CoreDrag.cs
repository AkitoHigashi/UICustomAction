using UnityEngine;
using UnityEngine.EventSystems;

public class CoreDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform _rectTransform;
    private Vector2 _startPos;

    private bool _isDroped = false;
    public bool IsDroped => _isDroped;
    private void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
    }
    public void OnDrag(PointerEventData eventData)
    {
        _rectTransform.position += new Vector3(eventData.delta.x, eventData.delta.y, 0);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _startPos = _rectTransform.position;
        _isDroped = false;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!_isDroped)
        {
            _rectTransform.position = _startPos;
        }
    }

    public void DropToSticker()
    {
        _isDroped = true;
    }
}
