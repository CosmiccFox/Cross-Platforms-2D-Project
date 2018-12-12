using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour {

    //public GameObject Character;
    public Transform target;
    public float lerpSpeed = 0.5f;

    private Vector3 offset;

    
    // Use this for initialization
	void Start ()
    {
        //offset = transform.position - target.transform.position;
	}

    void Update()
    {
        //transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, new Vector3(target.position.x, target.position.y, transform.position.z), lerpSpeed * Time.deltaTime);
    }

    //void LateUpdate()
    //{
    //    transform.position = Character.transform.position + offset;
    //}
}
