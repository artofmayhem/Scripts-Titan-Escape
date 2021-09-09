using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 4f;
    public float fireRate = 0.3f;
    public float health = 2;
    public int score = 100;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        if (transform.position.y < -5.5f)
        {
            transform.position = new Vector3(Random.Range(-9.5f, 9.5f), 5.5f, 0);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision: " + other.transform.name);
        if (other.transform.tag == "Laser")
        {
            Destroy(other.gameObject);
            if (health > 1)
            {
                health--;
            }
            else
            {
                // destroy the laser then self


                Destroy(this.gameObject);
                
            }
        }
        if (other.transform.tag == "Player")
        {
            Player player = other.transform.GetComponent<Player>();
            if (player != null)
            {
                player.Damage(); // this is a method on the player script
                Destroy(this.gameObject);
            }
           
        }
    }

}
