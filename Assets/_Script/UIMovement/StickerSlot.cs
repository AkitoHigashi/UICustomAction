using UnityEngine;
using UnityEngine.EventSystems;
/// <summary>
/// ステッカーにつける装備用のスクリプト
/// </summary>
public class StickerSlot : MonoBehaviour, IDropHandler
{
    private HPCore _hpCore;
    private IHPSticker _thisSticker;

    private void Awake()
    {
        _thisSticker = GetComponent<IHPSticker>();
    }
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("あああああ");
        var coreDrag = eventData.pointerDrag?.GetComponent<CoreDrag>();
        Debug.Log("あああ");
        if (coreDrag == null) return;

        _hpCore = coreDrag.GetComponent<HPCore>();
        Debug.Log("あああああ");
        if (_hpCore == null) return;

        _hpCore.AttachToSticker(_thisSticker);

        //コアをステッカースロットの子オブジェクトに
        coreDrag.transform.SetParent(transform);
        //コアの位置をステッカースロットと合わせるためにポジション０に戻す。
        coreDrag.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
        //isDropを変更
        coreDrag.DropToSticker();
    }
}
