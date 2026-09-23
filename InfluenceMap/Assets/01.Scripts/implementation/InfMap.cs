using UnityEngine;
using InfluenceMap;
using UnityEngine.Rendering;


public class InfMap : MonoBehaviour  , IInfluenceMap<TactInfo>
{
    [SerializeField]
    private bool debugFlag = false;
    [SerializeField]
    private InfluenceVisualizer visualizer;
    [SerializeField]
    private GameObject tilePrefab;
    

    [SerializeField]
    private int witdh,height;
    [SerializeField]
    private TactInfo[][] map;



    public int Witdh => witdh;
    public int Height => height;
    public TactInfo[][] Map => map;    

    public void Awake()
    {
        map = new TactInfo[Height][];
        for (int i = 0; i < Height; i++)
        {
            map[i] = new TactInfo[Witdh];
            for (int j = 0; j < Witdh; j++)
            {
                map[i][j].PotentialRate = Random.Range(0, 5);
                map[i][j].ThreatRate = Random.Range(0,5);
                map[i][j].WorldPos = new Vector3(i + 1, 0, j + 1);

                GameObject tile = Instantiate(tilePrefab, transform);
                tile.transform.position = map[i][j].WorldPos;
            }
        }      

    }
    private void Start()
    {
        visualizer.SetMap(this);
        visualizer.UpdateVisual();
        InfluenceSystem<TactInfo>.Instance.SetMap(this);
    }    


    public bool ShowInfluence()
    {
        debugFlag = !debugFlag;        

        return debugFlag;
    }
    

    public bool ChangeInfluence(int posX, int posY, TactInfo influenceData)
    {

        if ((posY >= height || posY < 0) || (posX >= witdh || posX < 0)) return false;

        map[posY][posX].ThreatRate += influenceData.ThreatRate;
        map[posY][posX].PotentialRate += influenceData.PotentialRate;

        return true;
    }

    public void ClearInfluence()
    {
        for (int i = 0; i < Height; i++) 
        {
            for (int j = 0; j < Witdh; j++)
            {
                map[i][j].ThreatRate = 0;
                map[i][j].PotentialRate = 0;
            }
        }      
    }
}
