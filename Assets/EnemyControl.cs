using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{

    public static int numberofEns = 0;

    public float speed = 4;
    public LayerMask platformLayer;
    public Animator anim;
    public bool canMove = true;
    

    private float direction = 1;
    

    void Start()
    {
        numberofEns++;
        Debug.Log(numberofEns);
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Collider2D>().enabled == false)
        {            
            anim.SetBool("EDeath", true);
            canMove = false;
        }
        else if (canMove)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, Mathf.Infinity, platformLayer);
            
            if (hit.collider == null)
            {
                direction *= -1;
            }

            transform.position += direction * Vector3.right * speed * Time.deltaTime;

        }

        //anim.SetBool("Pause", GameManager.GetInstance().currentState == GameManager.GameState.pause);

    }

    public void KillEnemy()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector3.up * 3, ForceMode2D.Impulse);
        GetComponent<Collider2D>().enabled = false;
    }
}
