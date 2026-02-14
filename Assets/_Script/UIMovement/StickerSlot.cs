using UnityEngine;
using UnityEngine.EventSystems;
/// <summary>
/// ステッカー側につけるスクリプト(アイテム装備用)
/// </summary>
public class StickerSlot : MonoBehaviour, IDropHandler
{
    [SerializeField] private GameObject _slot;

    private IHPSticker _thisSticker;
    private HPCore _hpCore;

    private void Awake()
    {
        _thisSticker = GetComponent<IHPSticker>();
    }
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("ドロップされたオブジェクトがあるかチェック");
        if (eventData.pointerDrag == null) return;

        var dropObj = eventData.pointerDrag;

        var coreDrag = dropObj.GetComponent<CoreDrag>();

        if (coreDrag != null)
        {
            var core = dropObj.GetComponent<HPCore>();

            //コアをステッカーに装着（内部）
            core.AttachToSticker(_thisSticker);

            //isDropを変更
            coreDrag.DropToSticker();
            //コアUIの見た目を装着
            coreDrag.transform.SetParent(_slot.transform);
            coreDrag.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
        }

        //解除装置かをチェック
        var remover = dropObj.GetComponent<RemoveTool>();
        if (remover != null)
        {
            RemoveItem();
        }
    }
    private void RemoveItem()
    {
        if (_slot != null)
        {

        }
    }
}
