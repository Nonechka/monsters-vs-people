using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Monsters : MonoBehaviour
{
    public TMP_Text LivesText;
    public int MonstersLives;
    public float MoveSpeed;
    public Slider Slider;

    private Transform _transform;
    private float _deathZone = -4.72f;

    private void Awake()
    {
        _transform = GetComponent<Transform>();
    }

    private void Update()
    {
        Slider.value = MonstersLives;
        LivesText.text = MonstersLives.ToString();
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
