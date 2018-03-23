using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	private Transform PlayerToFollow;

	void Start(){
		PlayerToFollow = GameObject.FindGameObjectWithTag ("Player").transform;
	}

    float dampFactor = 0.1f;

    void LateUpdate()
    {
        float playerX = PlayerToFollow.position.x;
        float playerY = PlayerToFollow.position.y;

        var velocity = Vector3.zero;

        var newPos = new Vector3(playerX, playerY + 40, transform.position.z);
        transform.position = Vector3.SmoothDamp(transform.position, newPos, ref velocity, dampFactor);
    }
}
