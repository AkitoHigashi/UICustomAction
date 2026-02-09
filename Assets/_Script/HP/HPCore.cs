using UnityEngine;

public class HPCore : MonoBehaviour
{
    private IHPStrategy _currentHPStrategy;

    private bool _isDead = false;

    //ダメージ通知を受け取った時に呼び出すメソッド
    public void ReceiveDamage(float damage)
    {
        if (_isDead) return;

        if (_currentHPStrategy == null) return;

        // HPとして無効ならダメージを渡さない
        if (!_currentHPStrategy.IsActive()) return;

        bool isAlive = _currentHPStrategy.TakeDamage(damage);

        if(!isAlive)
        {
            Die();
        }
    }
    /// <summary>
    /// コアをステッカーに装備時そのステッカーを登録するメソッド
    /// </summary>
    /// <param name="hPSticker"></param>
    public void AttachToSticker(IHPStrategy hPSticker)
    {
        _currentHPStrategy = hPSticker;
    }
    /// <summary>
    /// コアをステッカーに着脱時そのステッカーを解除するメソッド
    /// </summary>
    public void RemoveFromSticker()
    {
        _currentHPStrategy = null;
    }
    //死んだときに呼び出す
    private void Die()
    {
        _isDead = true;
        Debug.Log("Playerはしんだ");
    }

}
