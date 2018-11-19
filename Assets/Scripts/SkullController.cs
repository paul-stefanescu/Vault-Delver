using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SkullController : MonoBehaviour
{

	private Rigidbody2D myRigidbody;
	private Animator anim;
	public float moveSpeed;
	private bool moving;
	public float timeToMove;
	private float timeToMoveCounter;
	public float timeBetweenMove;
	private float timeBetweenMoveCounter;
	private Vector3 moveDirection;
	public float waitToReload;
	private bool reloading;
	private GameObject thePlayer;

	private Vector3 lastMove;

	void Start()
	{

		myRigidbody = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		//timeBetweenMoveCounter = timeToMove;
		//timeToMoveCounter = timeToMove;

		timeBetweenMoveCounter = Random.Range(timeBetweenMove * .75f, timeBetweenMove * 1.25f);
		timeToMoveCounter = Random.Range(timeToMove * .75f, timeToMove * 1.25f);


	}

	// Update is called once per frame
	void Update()
	{

		if (moving)
		{
			timeToMoveCounter -= Time.deltaTime;
			myRigidbody.velocity = moveDirection;

			if (timeToMoveCounter < 0f)
			{
				moving = false;
				//timeBetweenMoveCounter = timeBetweenMove;
				timeBetweenMoveCounter = Random.Range(timeBetweenMove * .75f, timeBetweenMove * 1.25f);
				anim.SetBool("moving", true);
			}

		}
		else
		{
			timeBetweenMoveCounter -= Time.deltaTime;
			myRigidbody.velocity = Vector2.zero;
			anim.SetBool("moving", false);
			if (timeBetweenMoveCounter < 0f)
			{

				moving = true;
				//timeToMoveCounter = timeToMove;
				moveDirection = new Vector3(Random.Range(-1f, 1f) * moveSpeed, Random.Range(-1f, 1f) * moveSpeed, 0f);
				lastMove = moveDirection;
				timeToMoveCounter = Random.Range(timeToMove * .75f, timeToMove * 1.25f);
				anim.SetBool("moving", true);

				anim.SetFloat("input_x", moveDirection.x);
				anim.SetFloat("input_y", moveDirection.y);
				/*if (Mathf.Abs(lastMove.x) < Mathf.Abs(lastMove.y))
				{
					if (lastMove.x > 0f)
						anim.SetFloat("lastmove_x", 1);
					else
						anim.SetFloat("lastmove_x", -1);
				}
				else
				{
					if (lastMove.y > 0f)
						anim.SetFloat("lastmove_y", 1);
					else
						anim.SetFloat("lastmove_y", -1);
				}*/
			}
		}

		if (reloading)
		{
			waitToReload -= Time.deltaTime;


			if (waitToReload < 0)
			{
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
				thePlayer.SetActive(true);
			}

		}
	}

	private void OnCollisionEnter2D(Collision2D other)
	{
		/*if (other.gameObject.name == "Player")
		{
			other.gameObject.SetActive(false);
			reloading = true;
			thePlayer = other.gameObject;

		}
		else
			moving = false;
		*/
	}

}