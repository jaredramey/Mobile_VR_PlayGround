using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof(Rigidbody))]
public class Ball_Controller : MonoBehaviour
{
    public float moveForce = 0.0f;
    [HideInInspector]
    private Rigidbody playerBody;
    [HideInInspector]
    private float joyStickForceX = 0.0f, joyStickForceZ = 0.0f;

    // Use this for initialization
    void Start()
    {
        playerBody = gameObject.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        joyStickForceX = CrossPlatformInputManager.GetAxis("Horizontal");
        joyStickForceZ = CrossPlatformInputManager.GetAxis("Vertical");

        playerBody.AddForce((-Vector3.left * moveForce) * joyStickForceX);
        playerBody.AddForce((Vector3.forward * moveForce) * joyStickForceZ);
    }
}
