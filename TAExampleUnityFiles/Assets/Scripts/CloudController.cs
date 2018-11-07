using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudController : MonoBehaviour {

    private float _speed = .2f;
	void Start () {
        _speed = Random.Range(.005f, .025f);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
       
        transform.position += Vector3.right * -_speed;
        if (transform.position.x < -60)
            transform.position = new Vector3(60, transform.position.y, 0);

    }
}
