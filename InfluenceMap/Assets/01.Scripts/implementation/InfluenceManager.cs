using InfluenceMap;
using System.Collections.Generic;

public class InfluenceSystem <T> where T : struct 
{
    private static InfluenceSystem<T> instance;
    public static InfluenceSystem<T> Instance
    {
        get
        {
            if (instance == null)
                instance = new InfluenceSystem<T>();
            return instance;
        }        
    }    

    private IInfluenceMap<T> map;
    private List<IInfluenceObj<T>> objs = new List<IInfluenceObj<T>>();
    protected Dictionary<int, InfluenceCalcModule<T>> calcModules;
    

    public bool SetMap(IInfluenceMap<T> mapParam)
    {
        map = mapParam;
        return true;
    }
    public IInfluenceMap<T> GetMap()
    {
        return map;
    }

    public bool RegisterObj(IInfluenceObj<T> obj)
    {
        if (obj == null && objs.Contains(obj)) return false;
        objs.Add(obj);
        return true;
    }
    public IInfluenceObj<T> UnRegisterObj(IInfluenceObj<T> obj)
    {
        if (objs.Contains(obj)) return obj;
        return null;
    }

    public void UpdateInfluence()
    {
        map.ClearInfluence();
        foreach (var obj in objs)
        {
            obj.CalcMoudule.InfluenceFunc(obj, map,3);
        }
    }



}
