using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void ResetPlayerPos()
    {        
        GetComponent<Animator>().SetBool("Death", false);
        transform.parent.position = new Vector3(-9, -1, 0);
        transform.parent.GetComponent<CharacterControl>().ResetLives();
        transform.parent.GetComponent<CharacterControl>().ResetPowerUps();
    }

}
