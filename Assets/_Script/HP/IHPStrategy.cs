using UnityEngine;

/// <summary>
/// HPの「意味」を定義するための共通インターフェース
/// ゲージ型・アイコン型などは、必ずこれを実装する
/// </summary>
public interface IHPStrategy
{
    //ダメージを受けたときの処理
    public bool TakeDamage(float damege);
    //生きているか
    public bool IsAlive();
    //HPとして有効か
    public bool IsActive();


}
