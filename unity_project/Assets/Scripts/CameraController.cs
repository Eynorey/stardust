using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	private Transform PlayerToFollow;

	void Start(){
		PlayerToFollow = GameObject.FindGameObjectWithTag ("Player").transform;
	}

	void Update(){
		transform.position = new Vector3 (PlayerToFollow.position.x, transform.position.y, transform.position.z);
	}
}
