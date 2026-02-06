using UnityEngine;

public interface IHPSticker
{
    public int MaxHP { get; }
    public int CurrentHP { get; }
    /// <summary>
    /// 割合からHPを設定する
    /// </summary>
    /// <param name="ratio"></param>
    public void SetHPByRatio(float ratio);
    /// <summary>
    ///　 現在のHP割合を取得する
    /// </summary>
    /// <returns></returns>
    public float GetHPRatio();
    /// <summary>
    /// ダメージ処理をする場所
    /// </summary>
    /// <param name="value"></param>
    public void TakeDamage(int value);
}
