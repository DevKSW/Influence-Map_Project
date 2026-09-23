using InfluenceMap;
using UnityEngine;

public class CalcModuleBase : MonoBehaviour, InfluenceCalcModule<TactInfo>
{  
    public bool InfluenceFunc(IInfluenceObj<TactInfo> obj, IInfluenceMap<TactInfo> map, int range = 3)
    {
        if (obj == null || map == null) return false;
        TactInfo info = obj.InfluenceValue;
        


        for (int y = info.pos.y - range ; y <= info.pos.y + range; ++y)
        {
            for (int x = info.pos.x - range ; x <= info.pos.x + range; ++x)
            {
                TactInfo t_info = info;

                float dx = Mathf.Abs(info.pos.x - x);
                float dy = Mathf.Abs(info.pos.y - y);
                float distance = Mathf.Max(dx, dy); // 정사각형 타일 기준 거리

                float ratio = 1f - (distance / range);
                
                t_info.PotentialRate *= ratio;
                t_info.ThreatRate *= ratio;
                Debug.Log($"{t_info.PotentialRate} , {t_info.ThreatRate} , {ratio} \n {x} , {y}" );
                map.ChangeInfluence(x-1, y-1, t_info);
            }
        }

        return true;
    }

}
