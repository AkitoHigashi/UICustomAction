using UnityEngine;

public class HPStickerManeger : MonoBehaviour
{
    [SerializeField] GameObject _obj;
    void Start()
    {
        //初期装備
        EquipHPSticker(_obj.GetComponent<IHPSticker>());
    }
    private IHPSticker _currentSticker;
    public void EquipHPSticker(IHPSticker newSticker)
    {
        float ratio = 1f;//初期値

        if (_currentSticker != null)
        {
            //付け替え前の体力割合を保存
            ratio = _currentSticker.GetHPRatio();
        }
        _currentSticker = newSticker;
        _currentSticker.SetHPByRatio(ratio);
    }
    /// <summary>
    /// ダメージを受けた際に呼び出す
    /// </summary>
    /// <param name="value"></param>
    public void TakeDamage(int value)
    {
        _currentSticker?.TakeDamage(value);
        Debug.Log($"{value}ダメージウケる");
    }
}
