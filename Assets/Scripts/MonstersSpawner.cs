using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonstersSpawner : MonoBehaviour
{
    private float _borderPositionY = 6.18f;
    private float _borderPositionXrigth = 3.54f;
    private float _borderPositionXleft = -7f;
    private int _enemySpawnTime = 2;

    private float _upBorderPositionY = 4f;
    private float _downBorderPositionY = -2f;
    private float _borderPositionX = -10f;



    public GameObject MonstersPrefab;
    public GameObject MonstersPrefab2;

    private void Start()
    {
        StartCoroutine(SpawnEnemyTimer());
    }
    private IEnumerator SpawnEnemyTimer()
    {
        while (true)
        {
            MonstersSpawn();
            MonstersSpawn2();
            yield return new WaitForSeconds(_enemySpawnTime);
        }
       
    }
    private void MonstersSpawn()
    {
        Instantiate(MonstersPrefab, new Vector3(Random.Range(_borderPositionXleft, _borderPositionXrigth), _borderPositionY, transform.position.z), Quaternion.identity);

    }
    private void MonstersSpawn2()
    {
        GameObject monsterPrefab2 = Instantiate(MonstersPrefab2, new Vector3(_borderPositionX, Random.Range(_downBorderPositionY, _upBorderPositionY), transform.position.z), Quaternion.Euler(0, 180, 0));
        StartCoroutine(MoveMonster2(monsterPrefab2.transform,monsterPrefab2));
    }
    private IEnumerator MoveMonster2(Transform MonsterPrefab2,GameObject monsterprefab2)
    {
        while (true)
        {
            
            int moveSpeed = 1;
            MonsterPrefab2.Translate(Vector3.left * moveSpeed * Time.deltaTime);
            yield return null;
            int destroyBorderPosition = 10;
            if (monsterprefab2 == null)
            {
                yield break;
            }
            if (MonsterPrefab2.position.x > destroyBorderPosition)
            {
                Destroy(monsterprefab2);
            }
            
        }
       
    }
}
