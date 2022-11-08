using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Enemy 
{
    public int spawnTime;
    public EnemyType enemyType;
    public int Spawner;
    public bool RandomSpawn;
    public bool isSpawned;
}

public enum EnemyType
{
    Enemy_Basic,
    Enemy_Black,
    Enemy_Neon

}