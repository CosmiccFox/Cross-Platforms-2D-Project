using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudEnemy : EnemyControl {

    private float cdirection = 1;

    // Use this for initialization
    void Start ()
    {
        numberofEns++;
        Debug.Log(numberofEns);

    }
	
	// Update is called once per frame
	void Update () 
    {
        if (GetComponent<Collider2D>().enabled == false)
        {
            anim.SetBool("CEDeath", true);
            canMove = false;
        }
        else if (canMove)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, Mathf.Infinity, platformLayer);

            if (hit.collider == null)
            {
                cdirection *= -1;
            }

            transform.position += cdirection * Vector3.right * speed * Time.deltaTime;
            transform.position += Vector3.up * Mathf.Sin(speed * Time.deltaTime);

        }

    }

    public new void KillEnemy()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector3.up * 3, ForceMode2D.Impulse);
        GetComponent<Rigidbody2D>().gravityScale = 0.5f;
        GetComponent<Collider2D>().enabled = false;
    }



}
