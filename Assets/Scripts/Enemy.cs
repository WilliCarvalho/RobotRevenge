using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float velocity;
    private int life;

    // Start is called before the first frame update
    void Start()
    {
        //life will always be related with the level
        life = GameControlller.level;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * velocity * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Bullet collision
        if(collision.collider.tag == "Bullet")
        {
            //remove life and verify if it has to be destroyed
            life--;
            if(life <= 0)
            {
                Destroy(gameObject);
            }
        }

        //Character collision
        if(collision.collider.tag == "Character")
        {
            Destroy(gameObject);
        }
    }

}
