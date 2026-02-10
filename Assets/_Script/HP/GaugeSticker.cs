using UnityEngine;

public class GaugeSticker : MonoBehaviour,IHPSticker
{
    [SerializeField,Header("ÉQÅ[ÉWÇÃç≈ëÂêîíl")] private int _maxVaule = 100;
    private int _currentVaule;


    private void Awake()
    {
        _currentVaule = _maxVaule;
    }

    #region HPCore
    public void ApplyDamage(int damege)
    {
        _currentVaule -= damege;
        //0à»â∫Ç…Ç»ÇÁÇ»Ç¢ÇÊÇ§Ç…
       _currentVaule = Mathf.Max(_currentVaule, 0);
    }

    public float GetHPRaito()
    {
        return (float)_currentVaule / _maxVaule;
    }

    public void SetHPRatio(float ratio)
    {
        _currentVaule = Mathf.RoundToInt(_maxVaule * ratio);
    }
    #endregion
}
