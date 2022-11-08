using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<GameObject> enemiesPrefabs;
    public List<Enemy> enemies;

    private void Update()
    {
        foreach (Enemy enemy in enemies)
        {
            if (enemy.isSpawned == false && enemy.spawnTime <= Time.time)
            {

                if (enemy.RandomSpawn)
                {
                    enemy.Spawner = Random.Range(0, transform.childCount);
                }
                GameObject enemyInstance = Instantiate(enemiesPrefabs[(int)enemy.enemyType], transform.GetChild(enemy.Spawner).transform);
                transform.GetChild(enemy.Spawner).GetComponent<SpawnPoint>().enemies.Add(enemyInstance);
                enemy.isSpawned = true;
               
            }
        }
    }
}
