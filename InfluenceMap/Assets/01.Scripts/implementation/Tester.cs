using UnityEngine;

public class Tester : MonoBehaviour
{
    
    public void TestInfluenceMap()
    {
        InfluenceSystem<TactInfo>.Instance.UpdateInfluence();
    }

}
