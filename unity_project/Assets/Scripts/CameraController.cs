using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour
{
    private Transform PlayerToFollow;
    private string scene = "";

    void Start()
    {
        PlayerToFollow = GameObject.FindGameObjectWithTag("Player").transform;
        scene = SceneManager.GetActiveScene().name;
    }

    float dampFactor = 0.2f;

    void LateUpdate()
    {
        float playerX = PlayerToFollow.position.x;
        float playerY = PlayerToFollow.position.y;

        var velocity = Vector3.zero;

        float newY;
        if (scene == "final_planet")
            newY = (playerY + 30 > 120 ? playerY + 30 : 120);
        else
            newY = playerY + 7;
        

        var newPos = new Vector3(playerX, newY, transform.position.z);
        transform.position = Vector3.SmoothDamp(transform.position, newPos, ref velocity, dampFactor);
    }
}
