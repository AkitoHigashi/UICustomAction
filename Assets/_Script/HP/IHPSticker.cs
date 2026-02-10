using UnityEngine;

public interface IHPSticker
{
    /// <summary>ダメージを受けた際のメソッド </summary>
    public void ApplyDamage(int damege);
    /// <summary>0~1のHP割合を取得 </summary>
    float GetHPRaito();

    /// <summary>HP割合を設定 </summary>
    void SetHPRatio(float ratio);
}

