using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	private Transform PlayerToFollow;
	private float offset;

	void Start(){
		PlayerToFollow = GameObject.FindGameObjectWithTag ("Player").transform;
		offset = transform.position.y - PlayerToFollow.transform.position.y;
	}

	void LateUpdate(){

		transform.position = new Vector3(PlayerToFollow.position.x, PlayerToFollow.position.y + offset , transform.position.z);

	}
}
