using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float initVelocity = 10;

	// Use this for initialization
	void Start ()
    {

    }
	
	// Update is called once per frame
	void Update ()
    {
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.rigidbody.gameObject.GetComponent<EnemyControl>() != null)
        {
            collision.rigidbody.gameObject.GetComponent<EnemyControl>().KillEnemy();
        }

        Destroy(gameObject);
        
    }

    public void GiveInitVelocity()
    {
        GetComponent<Rigidbody2D>().AddForce(transform.right * initVelocity, ForceMode2D.Impulse);
    }
}
