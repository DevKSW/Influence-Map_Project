using System;
using System.Collections.Generic;
using UnityEngine.Animations;

namespace InfluenceMap
{
    public interface IInfluenceMap<T> where T : struct
    {
        public int Witdh { get; }
        public int Height { get; }

        public T[][] Map { get; }

        public void ClearInfluence();
        public bool ChangeInfluence(int posX , int posY, T influenceData);

        public bool ShowInfluence();

    }

    public interface IInfluenceObj<T> where T : struct
    {
        protected int PosX { get; }
        protected int PosY { get; }

        T InfluenceValue { get; }

        bool Enable { get; }

        InfluenceCalcModule<T> CalcMoudule { get; }

    }

    public interface  InfluenceCalcModule<T> where T : struct
    {        
        public  bool InfluenceFunc(IInfluenceObj<T> obj, IInfluenceMap<T> map, int range = 5);
    }

}