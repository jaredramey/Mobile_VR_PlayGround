using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;


[RequireComponent(typeof(Rigidbody2D))]
public class Controller_Test : MonoBehaviour
{
    public float MoveForce = 0.0f;
    public float JumpForce = 0.0f;
    private bool canJump;
    [HideInInspector]
    private float JoystickForce = 0.0f;
    [HideInInspector]
    private Rigidbody2D PlayerBody;

    // Use this for initialization
    void Start()
    {
        PlayerBody = gameObject.GetComponent<Rigidbody2D>();
        canJump = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        JoystickForce = CrossPlatformInputManager.GetAxis("Horizontal");

        if (CrossPlatformInputManager.GetButton("Jump") && canJump)
        {
            canJump = !canJump;
            Debug.Log("Jumping");
            PlayerBody.AddForce((Vector2.up) * (MoveForce * 100));
        }

        PlayerBody.AddForce((-Vector2.left * MoveForce) * JoystickForce);   
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        //Debug.Log(coll.gameObject.layer.ToString());

        if (coll.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            Debug.Log("Collision");
            if(!canJump)
            {
                canJump = !canJump;
            }
        }
    }
}
