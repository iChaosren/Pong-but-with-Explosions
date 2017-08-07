using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuckController : MonoBehaviour {

	public float InitialForce = 1f;
    public Rigidbody2D rigidbody;



	// Use this for initialization
	void Start () {
		rigidbody = gameObject.GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;
		rigidbody.AddForce(new Vector2(InitialForce, InitialForce*1.5f), ForceMode2D.Impulse);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
