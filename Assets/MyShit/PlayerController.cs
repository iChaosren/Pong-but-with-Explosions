using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour {

	[Range(1,2)]
	public int PlayerNumber = 1;

	public float Speed = 6f; 

	public Rigidbody2D rigidbody;

	void Awake() {
		rigidbody = GetComponent<Rigidbody2D>();
	}
	
	void FixedUpdate () {
		float player_velocity = CrossPlatformInputManager.GetAxis("Player " + PlayerNumber);
		rigidbody.velocity = new Vector2(rigidbody.velocity.x, player_velocity * Speed);
	}
}
