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

    float dampFactor = 0.15f;

    void LateUpdate()
    {
        float playerX = PlayerToFollow.position.x;
        float playerY = PlayerToFollow.position.y;
        float playerZ = PlayerToFollow.position.z;

        var velocity = Vector3.zero;

        float newY, newZ;
        if (scene == "final_planet")
        {
            newY = (playerY + 20 > 100 ? playerY + 20 : 100);
            newZ = (playerZ - 30);
            var oldRot = transform.rotation;
            if ((playerX > 60 && playerX < 175) || (playerX > 375 && playerX < 615))
            {
                transform.rotation = Quaternion.RotateTowards(oldRot, Quaternion.Euler(8f, oldRot.y, oldRot.z), 10 * Time.deltaTime);
                newY -= 15;
                newZ += 15;
            }
            else
            {
                transform.rotation = Quaternion.RotateTowards(oldRot, Quaternion.Euler(34f, oldRot.y, oldRot.z), 10 * Time.deltaTime);
            }
            
        }
        else
        {
            newZ = transform.position.z;
            newY = playerY + 7;
        }

        var newPos = new Vector3(playerX, newY, newZ);
        transform.position = Vector3.SmoothDamp(transform.position, newPos, ref velocity, dampFactor);
    }
}
