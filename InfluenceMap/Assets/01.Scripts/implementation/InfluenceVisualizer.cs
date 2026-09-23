using InfluenceMap;
using UnityEngine;

public class InfluenceVisualizer : MonoBehaviour
{
    [SerializeField]
    private GameObject visualObj;
    [SerializeField]
    private Color BaseColor;
    [SerializeField]
    private Color EndColor;

    private GameObject[][] objs;
    private Renderer[][] renderers;

    private IInfluenceMap<TactInfo> map;
    

    public void SetMap(IInfluenceMap<TactInfo> mapParam)
    {
        if (mapParam == null) return;        
        
        this.map = mapParam;
        objs = new GameObject[map.Height][];
        renderers = new Renderer[map.Height][];
        for (int i = 0; i < objs.Length; i++)
        {
            objs[i] = new GameObject[map.Witdh];
            renderers[i] = new Renderer[map.Witdh];
            for (int j = 0; j < objs[i].Length; j++)
            {
                GameObject obj = Instantiate(visualObj,this.transform);
                objs[i][j] = obj;
                obj.transform.localPosition = mapParam.Map[i][j].WorldPos;
                renderers[i][j] = obj.GetComponent<Renderer>();
            }            
        }               

    }

    
    public void UpdateVisual()
    {
        MaterialPropertyBlock propertyBlock = new MaterialPropertyBlock();
        for (int i = 0; i < objs.Length; i++)
        {
            for(int j = 0;j < objs[i].Length; j++)
            {
                renderers[i][j].GetPropertyBlock(propertyBlock);  
                propertyBlock.SetColor("_BaseColor", Color.Lerp(BaseColor, EndColor, map.Map[i][j].ThreatRate/3f));
                renderers[i][j].SetPropertyBlock(propertyBlock);
                objs[i][j].transform.localScale = new Vector3(1,1 + (map.Map[i][j].PotentialRate / 2f), 1);

            }
        }
        
    }

}
