using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManger : MonoBehaviour
{
    [HideInInspector] public static GameManger Instance;
    [HideInInspector] public  bool GameEnded { get; set; }

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (GameEnded && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
