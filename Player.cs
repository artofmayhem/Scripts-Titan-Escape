using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 10f;
    [SerializeField]
    private int _health = 3;
    public float horizontalInput;
    public float verticalInput;

    [SerializeField]
    public GameObject _LaserPrefab;
    [SerializeField]
    public float fireRate = 0.15f;
    private float _canFire = -1f;
    public float _speedMultiplier = 2f;


    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
    }

    void Update()
    {
        calculateMovement();
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _canFire)
        {
            FireLaser();
        }
    }

    void calculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);
        transform.Translate(direction * _speed * Time.deltaTime);

        //  transform.position = new Vector3(transform.position.x, Mathf.Clamp(), 0);
        if (transform.position.y >= 0)
        {
            transform.position = new Vector3(transform.position.x, 0, 0);
        }
        else if (transform.position.y <= -4)
        {
            transform.position = new Vector3(transform.position.x, -4, 0);
        }
        if (transform.position.x >= 11)
        {
            transform.position = new Vector3(-11, transform.position.y, 0);
        }
        else if (transform.position.x <= -11)
        {
            transform.position = new Vector3(11, transform.position.y, 0);
        }
    }

    void FireLaser()
    {
            _canFire = Time.time + fireRate;
            Instantiate(_LaserPrefab, transform.position + new Vector3(0, 1.2f, 0), Quaternion.identity);
    }

    public void Damage()
    {
        _health--;
        if (_health == 0)
        {
            Destroy(this.gameObject);
        }
    }


}
