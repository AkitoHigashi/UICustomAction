using UnityEngine;
public class GaugeHPSticker : HPSticker
{
    [SerializeField] private float _maxHP = 100f;
    private float _crurrentHP;

    protected override bool ApplyDamageInternal(float damage)
    {
        _crurrentHP -= damage;
        if (_crurrentHP <= 0)
        {
            _crurrentHP = 0;
            return false;
        }

        return true;
    }
    public override bool IsAlive()
    {
        return _crurrentHP > 0;
    }

    public override void EquipCore(HPCore hpCore)
    {
        base.EquipCore(hpCore);
    }
    public override void UnequipCore()
    {
        base.UnequipCore();
    }
}
