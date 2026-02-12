using UnityEngine;
using UnityEngine.EventSystems;
/// <summary>
/// ステッカーにつける装備用のスクリプト
/// </summary>
public class StickerSlot : MonoBehaviour, IDropHandler
{
    [SerializeField] GameObject _slot;
    private HPCore _hpCore;
    private IHPSticker _thisSticker;

    private void Awake()
    {
        _thisSticker = GetComponent<IHPSticker>();
    }
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            Debug.Log("ドロップされた");
            var coreDrag = eventData.pointerDrag.gameObject.GetComponent<CoreDrag>();
            Debug.Log("コアドラッグ持てるかチェック");
            if (coreDrag == null) return;

            _hpCore = coreDrag.GetComponent<HPCore>();
            Debug.Log("コア持ってるかチェック");
            if (_hpCore == null) return;

            _hpCore.AttachToSticker(_thisSticker);

            //isDropを変更
            coreDrag.DropToSticker();
            //コアをステッカースロットの子オブジェクトに
            coreDrag.transform.SetParent(_slot.transform);
            //コアの位置をステッカースロットと合わせるためにポジション０に戻す。
            coreDrag.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;

        }
    }
}
