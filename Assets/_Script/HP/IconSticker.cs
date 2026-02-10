using UnityEngine;

public class IconSticker : MonoBehaviour, IHPSticker
{
    [SerializeField, Header("アイコンの最大個数")] private int _maxCountVaule = 5;
    private int _currentCountVaule;

    //受けるダメージ数
    private int _takeDamegeCount = 1;

    public void Awake()
    {
        _currentCountVaule = _maxCountVaule;
    }
    #region HPCore
    public void ApplyDamage(int damege)
    {
        _currentCountVaule -= _takeDamegeCount;
        //0以下防止
        _currentCountVaule = Mathf.Clamp(_currentCountVaule, 0, _maxCountVaule);
    }

    public float GetHPRaito()
    {
        return (float)_currentCountVaule / _maxCountVaule;
    }

    public void SetHPRatio(float ratio)
    {
        _currentCountVaule = Mathf.RoundToInt(_maxCountVaule * ratio);
    }
    #endregion
}
