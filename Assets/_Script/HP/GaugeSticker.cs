using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class GaugeSticker : MonoBehaviour, IHPSticker
{
    [SerializeField, Header("ÉQÅ[ÉWÇÃç≈ëÂêîíl")] private int _maxVaule = 100;
    private Slider _sliders;

    private int _currentVaule;

    private void Awake()
    {
        _sliders = GetComponent<Slider>();
        _currentVaule = _maxVaule;
    }

    public void UpdateUI()
    {
        float target = (float)_currentVaule / _maxVaule;
        _sliders.DOValue(target, 0.3f);
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
