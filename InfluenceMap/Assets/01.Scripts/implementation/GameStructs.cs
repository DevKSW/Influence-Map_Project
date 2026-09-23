using System;
using Unity.VisualScripting;
using UnityEngine;


[Serializable]
public struct TactInfo
{
    public Vector2Int pos;
    public Vector3 WorldPos;
    public float PotentialRate;
    public float ThreatRate;  
    
}

public interface IDamageable
{
    public int CurrentHP {  get; }    
    public void TakeDamage(int damage); 
}

public interface IUnit : IDamageable 
{
    public Vector2Int TilePos { get; }
    public Vector3 WorldPos { get; }
}