using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Player : MonoBehaviour
{    
    public float MoveSpeed;
    public GameObject LaserPrefab;

    private Transform _transform;
    private SpriteRenderer _spriteRenderer;
    private float _borderPositionXright = 3.83f;
    private float _borderPositionXleft = -7.15f;
    private float _shootForce = 50f;
    // hello! 

    private void Awake()
    {
        _transform = GetComponent<Transform>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        PlayerMovement();
        ChangeSpritePosition();
        Shoot();
    }
    private void PlayerMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        _transform.Translate(Vector3.right * MoveSpeed * horizontal * Time.deltaTime);

        if (_transform.position.x <= _borderPositionXleft)
        {
            _transform.position = new Vector3(_borderPositionXleft, _transform.position.y, _transform.position.z);
        }
        if (_transform.position.x >= _borderPositionXright)
        {
            _transform.position = new Vector3(_borderPositionXright, _transform.position.y, _transform.position.z);
        }

        /*---------------------------------------------------------------------------------------
         
         Second variant

        float horizontal = Input.GetAxis("Horizontal") * MoveSpeed;
        Vector3 newPosition = _transform.position + Vector3.right * horizontal * Time.deltaTime;
        if (newPosition.x >= _borderPositionXleft && newPosition.x <= _borderPositionXright)
        {
            _transform.Translate(Vector3.right * horizontal * Time.deltaTime);
        }

        ---------------------------------------------------------------------------------------*/
    }

    private void ChangeSpritePosition()
    {
        float horizontal = Input.GetAxis("Horizontal");
        if (horizontal < 0)
        {
            _spriteRenderer.flipX = false;

        }
        if (horizontal > 0)
        {
            _spriteRenderer.flipX = true;
        }
    }
    private void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Rigidbody2D laserRB = Instantiate(LaserPrefab, _transform.position+Vector3.up*1.3f, Quaternion.identity).GetComponent<Rigidbody2D>();
            laserRB.velocity = Vector3.up * _shootForce;
        }
    }
}
