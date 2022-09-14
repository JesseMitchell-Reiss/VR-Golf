using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ClubHead : MonoBehaviour

{
	[SerializeField]
	private ClubHeadFollower clubHeadFollowerPrefab;

	private void Awake()
	{
		
		SpawnClubHeadFollower();

	}

	private void SpawnClubHeadFollower()
	{
		var follower = Instantiate(clubHeadFollowerPrefab);
		follower.transform.position = transform.position;
		follower.transform.rotation = transform.rotation;
		follower.SetFollowTarget(this);
	}
}