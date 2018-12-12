using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {

    public string abilityTag;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<CharacterControl>())
        {
            Ability[] abilities = collision.gameObject.GetComponents<Ability>();

            foreach(Ability a in abilities)
            {
                if (a.abilityTag == abilityTag)
                {
                    a.OnCollect();
                }
                else if(a.enabled)
                {
                    a.OnFinish();
                }
            }

        }

        gameObject.SetActive(false);       
        //Destroy(gameObject);
    }
}
