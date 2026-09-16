using System.Collections.Generic;

namespace InfluenceMap
{
    public interface IInfluenceMap<T> where T : struct
    {
        protected int Witdh { get; }
        protected int Height { get; }

        protected T[][] Map { get; }


        public bool ChangeInfluence(int posX , int posY, T influenceData);

        public bool ShowInfluence();

    }

    public interface IInfluenceObj<T> where T : struct
    {
        protected int PosX { get; }
        protected int PosY { get; }

        T InfluenceValue { get; }

        bool Enable { get; }



    }

    public static class InfluenceSpreader
    {        
        
    }

    public abstract class InfluenceCalcModule <T> where T : struct
    {
        public abstract bool InfluenceFunc(int posX, int posY,int range, T Influence, IInfluenceMap<T> map);
    }

}