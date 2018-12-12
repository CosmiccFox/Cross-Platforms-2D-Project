using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour {

    public static CharacterControl instance;

    public float playerSpeed;
    public float jumpForce;
    public float enemyHeight = 0.44f;
    public LayerMask enemy1;
    public LayerMask enemy2;
    public Animator anim;
    public List<GameObject> lives = new List<GameObject>();
    public List<GameObject> pUIcons = new List<GameObject>();

    public bool shield = false;
    public bool ghost = false;

    public int jumpCount = 0;
    public int maxJumps = 1;
    public int numberOfLives = 3;
        
    private bool isGrounded;
    private bool fallDeath;

	void Start ()
    {
        instance = this;
	}
	
    // Update is called once per frame
	void Update ()
    {
          
       anim.SetBool("Idle", true);

        // Character Movement

        if (Input.GetKey(KeyCode.RightArrow))
       {
           anim.SetBool("Walk", true);
           transform.position += Vector3.right * playerSpeed * Time.deltaTime;
           transform.rotation = Quaternion.Euler(0, 0, 0);
       }

       if (Input.GetKey(KeyCode.LeftArrow))
       {
           anim.SetBool("Walk", true);
           transform.position += Vector3.left * playerSpeed * Time.deltaTime;
           transform.rotation = Quaternion.Euler(0, 180, 0);
       }

       if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
       {
           anim.SetBool("Walk", false);
       }

       if (Input.GetKeyDown(KeyCode.Space) && jumpCount < maxJumps)
       {
           isGrounded = false;
           anim.SetBool("Jump", true);
           GetComponent<Rigidbody2D>().AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
           jumpCount++;  
           if (maxJumps >=2)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                GetComponent<Rigidbody2D>().AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
            }
       }

       if (isGrounded)
       {
            jumpCount = 0;
       }

        if (ghost)
        {
            gameObject.GetComponentInChildren<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.4f);
            Physics2D.IgnoreLayerCollision(8, 10, ignore: true);
        }

        if (!ghost)
        {
            gameObject.GetComponentInChildren<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
            Physics2D.IgnoreLayerCollision(8, 10, ignore: false);
        }

         //Debug.DrawRay(transform.position, Vector3.down, Color.red);

        for (int i = 0; i < lives.Count; i++)
        {
            lives[i].SetActive(i < numberOfLives);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Ground Collision

        if(collision.gameObject.layer == 9)
        {
            isGrounded = true;
            anim.SetBool("Jump", false);
        }

        // Enemy Collision

        if(collision.gameObject.layer == 10)
        {
            RaycastHit2D hit = Physics2D.BoxCast(transform.position, GetComponent<BoxCollider2D>().size, 0, Vector2.down, Mathf.Infinity, enemy1);
            if (hit.collider != null && hit.collider.gameObject.layer == 10)
            {
              
                GameObject Enemy = collision.rigidbody.gameObject;
                Enemy.GetComponent<EnemyControl>().KillEnemy();                

            }
            else
            {
                //DamagePlayer();
                KillPlayer();
            }

        }

        if (collision.gameObject.layer == 14)
        {
            RaycastHit2D hit = Physics2D.BoxCast(transform.position, GetComponent<BoxCollider2D>().size, 0, Vector2.up, Mathf.Infinity, enemy2);
            if (hit.collider != null && hit.collider.gameObject.layer == 14)
            {

                GameObject CEnemy = collision.rigidbody.gameObject;
                CEnemy.GetComponent<CloudEnemy>().KillEnemy();

            }
            else
            {
                //DamagePlayer();
                KillPlayer();
            }

        }

        if (collision.gameObject.layer == 13)
        {
            fallDeath = true;
            KillPlayer();
        }
        
    }
    

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 9)
        {
            isGrounded = false;
        }

        if (collision.gameObject.layer == 13)
        {
            fallDeath = false;
        }

    }

    //void DamagePlayer()
    //{
    //    numberOfLives--;
    //    if (numberOfLives == 0)
    //    {
    //        KillPlayer();
    //    }
    //}

    void KillPlayer()
    {
        if (fallDeath)
        {
            anim.SetBool("Death", true);
        }
        else if (!fallDeath && !shield)
        {
            numberOfLives--;

            if (numberOfLives <= 0)
            {
                //numberOfLives = 3;
                anim.SetBool("Death", true);
            }
        }
    }

    public void ResetLives()
    {
        numberOfLives = 3;
    }

    public void ResetPowerUps()
    {
        for (int i = 1; i < pUIcons.Count; i++)
        {
            pUIcons[i].SetActive(true);
        }
    }
}
