using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CoreDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform _rectTransform;
    private Image _image;
    private Vector2 _startPos;

    private bool _isDroped = false;
    public bool IsDroped => _isDroped;
    private void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
        _image = GetComponent<Image>();
    }
    public void OnDrag(PointerEventData eventData)
    {
        _rectTransform.position += new Vector3(eventData.delta.x, eventData.delta.y, 0);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _startPos = _rectTransform.position;
        _isDroped = false;
        _image.raycastTarget = false;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!_isDroped)
        {
            _rectTransform.position = _startPos;
        }
        _image.raycastTarget = true;
    }

    public void DropToSticker()
    {
        _isDroped = true;
    }
}
