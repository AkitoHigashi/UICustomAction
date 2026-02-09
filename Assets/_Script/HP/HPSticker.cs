using UnityEngine;

public abstract class HPSticker : MonoBehaviour, IHPStrategy
{
    // 装備中の HPコア（必ず1つ）
    protected HPCore _hpCore;
    //ステッカーが有効か
    [SerializeField] protected bool _isActive = false;

    //コア装備時に呼び出す
    public virtual void EquipCore(HPCore hpCore)
    {
        if (_hpCore != null)
        {
            UnequipCore();
        }

        _hpCore = hpCore;
        _hpCore.AttachToSticker(this);
        //ステッカー有効
        _isActive = true;
    }
    //コアを外すときに呼び出す
    public virtual void UnequipCore()
    {
        if (_hpCore == null) return;
        _hpCore.RemoveFromSticker();
        _hpCore = null;
        //ステッカー無効
        _isActive = false;
    }
    /// <summary>
    /// ダメージを受けた時に呼び出すメソッド
    /// Modiferを通してから内部処理する。
    /// </summary>
    public bool TakeDamage(float damage)
    {
        if (!_isActive) return true;

        return ApplyDamageInternal(damage);
    }
    /// <summary>
    /// 派生先でのHP処理
    /// </summary>
    protected abstract bool ApplyDamageInternal(float damage);
    /// <summary>
    /// HPとして有効なのか
    /// </summary>
    public bool IsActive()
    {
        return _isActive;
    }
    /// <summary>
    /// 生きているかを派生先でチェック
    /// </summary>
    public abstract bool IsAlive();

}
