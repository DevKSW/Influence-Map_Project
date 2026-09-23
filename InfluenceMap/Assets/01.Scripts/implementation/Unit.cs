using InfluenceMap;
using UnityEngine;

public class Unit : MonoBehaviour , IUnit , IInfluenceObj<TactInfo>
{
    [SerializeField]
    protected int MaxHP;
    [SerializeField]
    private int range;
    protected int curHP;
    [SerializeField]
    private TactInfo tactInfo;
    private InfluenceCalcModule<TactInfo> calcModule;

    private bool isDeadFlag;

    public Vector2Int TilePos => tactInfo.pos;

    public Vector3 WorldPos => transform.position;

    public int CurrentHP => curHP;    

    public InfluenceCalcModule<TactInfo> CalcMoudule => calcModule;

    int IInfluenceObj<TactInfo>.PosX => tactInfo.pos.x;

    int IInfluenceObj<TactInfo>.PosY => tactInfo.pos.y;

    TactInfo IInfluenceObj<TactInfo>.InfluenceValue => tactInfo;

    bool IInfluenceObj<TactInfo>.Enable => isDeadFlag;

    public void TakeDamage(int damage)
    {
        if (isDeadFlag == true) return;
        if (CurrentHP <= damage) isDeadFlag = true;

        curHP -= damage;

    }

    private void Start()
    {
        calcModule = GetComponent<CalcModuleBase>();
        InfluenceSystem<TactInfo>.Instance.RegisterObj(this);
    }


}
