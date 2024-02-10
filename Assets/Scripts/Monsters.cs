using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monsters : MonoBehaviour
{
    public int MonstersLives;
    public float MoveSpeed;

    private Transform _transform;
    private float _deathZone = -4.72f;

    private void Awake()
    {
        _transform = GetComponent<Transform>();
    }

    private void Update()
    {
        _transform.Translate(Vector3.down * MoveSpeed * Time.deltaTime);
        if (_transform.position.y < _deathZone)
        {
            Destroy(gameObject);
        }

        if(MonstersLives == 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("laser"))
        {
            MonstersLives--;
        }
    }

}
