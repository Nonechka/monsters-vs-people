using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Monsters2 : MonoBehaviour
{
    public TMP_Text LivesText2;
    public int MonstersLives2;
    public Slider Slider2;
    

    private Transform _transform;
    private float _deathZone = -4.72f;

    private void Awake()
    {
        _transform = GetComponent<Transform>();
    }

    private void Update()
    {
        Slider2.value = MonstersLives2;
        LivesText2.text = MonstersLives2.ToString();
        if (MonstersLives2 == 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("laser"))
        {
            MonstersLives2-=2;
        }
    }
}