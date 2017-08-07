using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartOnCollision : MonoBehaviour
{

    public float PuckInitialForce = 8f;

    public Direction PuckDirection = Direction.Right;

    public GameObject Puck;
    public GameObject Player1;
    public GameObject Player2;

    private Vector3 PuckStartingPosition;
    private Vector3 Player1StartingPosition;
    private Vector3 Player2StartingPosition;

    public Text ScorePlayer;

    void Start()
    {
        PuckStartingPosition = Puck.transform.position;
        Player1StartingPosition = Player1.transform.position;
        Player2StartingPosition = Player2.transform.position;
		isColliding = false;
    }

	void Update() {
		isColliding = false;
	}

	private bool isColliding;

    void OnTriggerEnter2D(Collider2D other)
    {
		if(isColliding) return; //Two colliders on Puck, causes double collision.
     	isColliding = true;

        int PlayerScore = int.Parse(ScorePlayer.text);
        ScorePlayer.text = (PlayerScore + 1).ToString();

        Puck.transform.position = PuckStartingPosition;
        Player1.transform.position = Player1StartingPosition;
        Player2.transform.position = Player2StartingPosition;

        Rigidbody2D puckRigidbody = Puck.GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;
        puckRigidbody.velocity = new Vector2(0, 0);

        puckRigidbody.AddForce(new Vector2(PuckInitialForce * (PuckDirection == Direction.Left ? -1f : 1f), PuckInitialForce * 1.5f), ForceMode2D.Impulse);
    }
}

public enum Direction
{
    Left,
    Right,
    Up,
    Down
}