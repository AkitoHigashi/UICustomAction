using UnityEngine;
using UnityEngine.UI;

public class HPBarSticker : MonoBehaviour, IHPSticker
{
    [SerializeField] private int _maxHP = 200;
    [SerializeField] private int _currentHP;

    [SerializeField] private Image _fillImage;
    public int MaxHP => _maxHP;
    public int CurrentHP => _currentHP;
    private void Awake()
    {
        _currentHP = _maxHP;
        RefreshUI();
    }

    public void SetHPByRatio(float ratio)
    {
        _currentHP = Mathf.RoundToInt(_maxHP * ratio);//lÌŒÜ“ü‚µ‚Ä®”‚É•ÏŠ·
        RefreshUI();
    }

    public void TakeDamage(int value)
    {
        _currentHP = Mathf.Max(_currentHP - value, 0);//HP‚ª0–¢–‚É‚È‚ç‚È‚¢‚æ‚¤‚É‚·‚é
        RefreshUI();
    }
    public float GetHPRatio()
    {
        return (float)_currentHP / _maxHP;//Š„‡‚ğ•Ô‚·
    }
    private void RefreshUI()
    {
        if (_fillImage != null)
        {
            _fillImage.fillAmount = GetHPRatio();//UI‚ÌXV
        }
    }
}
