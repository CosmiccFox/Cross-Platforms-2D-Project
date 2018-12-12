using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : MonoBehaviour {

    public string abilityTag;
    public float maxTime = 20;

    private float timer;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        OnUpdate();	
	}

    public virtual void OnCollect()
    {
        enabled = true;
    }

    public virtual void OnUpdate()
    {
        timer += Time.deltaTime;
        if (timer > maxTime || GetComponentInChildren<Animator>().GetBool("Death"))
        {
            timer = 0;
            OnFinish();
        }
    }

    public virtual void OnFinish()
    {
        enabled = false;
    }

}
