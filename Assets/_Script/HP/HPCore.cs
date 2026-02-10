using System;
using UnityEngine;

public class HPCore : MonoBehaviour
{
    private bool _isDead = false;
    private IHPSticker _currentHPSticker;

    public IHPSticker CurrentSticker => _currentHPSticker;
    public bool IsDead => _isDead;

    public event Action OnPlayerDead;
    /// <summary>ステッカーに装着</summary>
    public void AttachToSticker(IHPSticker newSticker)
    {
        if (newSticker == null)
        {
            Debug.Log("ステッカー無いぞ");
            return;
        }

        float raito = 1f;

        if (_currentHPSticker != null)
        {
            //HP割合の取得
            raito = _currentHPSticker.GetHPRaito();
        }

        _currentHPSticker = newSticker;
        //HPの割合を引き継ぐ
        _currentHPSticker.SetHPRatio(raito);

        _isDead = raito <= 0f;

    }

    public void ApplyDamage(int damage)
    {
        if (_currentHPSticker == null)
        {
            Debug.Log("ステッカー無いぞからダメージ処理無理");
            return;
        }
        //ダメージ処理
        _currentHPSticker.ApplyDamage(damage);

        if (_currentHPSticker.GetHPRaito() <= 0f && !_isDead)
        {
            _isDead = true;
            //死亡イベントを起動
            OnPlayerDead?.Invoke();
        }
    }
    /// <summary>ステッカーから着脱、あとで実装</summary>
    public void detachFromSticker(IHPSticker currentSticker)
    {

    }
}
