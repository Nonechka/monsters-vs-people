using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonstersSpawner : MonoBehaviour
{
    private float _borderPositionY = 6.18f;
    private float _borderPositionXrigth = 5.26f;
    private float _borderPositionXleft = -10.89f;
    private int _enemySpawnTime = 2;

    public GameObject MonstersPrefab;

    private void Start()
    {
        StartCoroutine(SpawnEnemyTimer());
    }
    private IEnumerator SpawnEnemyTimer()
    {
        while (true)
        {
            MonstersSpawn();
            yield return new WaitForSeconds(_enemySpawnTime);
        }
       
    }
    private void MonstersSpawn()
    {
        Instantiate(MonstersPrefab, new Vector3(Random.Range(_borderPositionXleft, _borderPositionXrigth), _borderPositionY, transform.position.z), Quaternion.identity);

    }
}
