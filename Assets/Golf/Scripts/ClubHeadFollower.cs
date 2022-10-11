using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClubHeadFollower : MonoBehaviour
{
	private ClubHead clubFollower;
	private Rigidbody rb;
	private Vector3 velocity;

	public GameObject ball;
	StartPoint start;

	public int strokeCount = 0;

	[SerializeField]
	private float sensitivity = 100f;

	private void Start()
	{
		rb = GetComponent<Rigidbody>();
		start = FindObjectOfType<StartPoint>();
	}

	private void FixedUpdate()
	{
		Vector3 destination = clubFollower.transform.position;
		
		rb.transform.rotation = transform.rotation;
		
		velocity = (destination - rb.transform.position) * sensitivity;

		rb.velocity = velocity;
		
		transform.rotation = clubFollower.transform.rotation;
	}

	public void SetFollowTarget(ClubHead _clubFollower)
	{
		clubFollower = _clubFollower;
	}

	private void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.CompareTag("Ball"))
		{
			strokeCount++;

			
		}
	}
}

