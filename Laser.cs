using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField]
    private float _speed = 15.0f;

    // Update is called once per frame
    void Update()
    {
       LaserMovement();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Destroy(this.gameObject);
        }
    }

    void LaserMovement()
    {
        transform.Translate(Vector3.up * _speed * Time.deltaTime);
        if (transform.position.y > 8.0f)
        {
            Destroy(this.gameObject);
        }
    }

}
