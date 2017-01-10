using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class SpinningCube : MonoBehaviour 
{
	public float m_Speed = 20f;
    public float MoveForce = 0.0f;

    private Rigidbody CubeBody;
	private Vector3 m_RotationDirection = Vector3.up;

    private void Start()
    {
        CubeBody = gameObject.GetComponent<Rigidbody>();
    }

	public void ToggleRotationDirection()
	{
		Debug.Log ("Toggling rotation direction");

		if (m_RotationDirection == Vector3.up) 
		{
			m_RotationDirection = Vector3.down;
		}
		else 
		{
			m_RotationDirection = Vector3.up;
		}
	}

    public void Toggle_MoveLeft()
    {
        Debug.Log("Moving Left");
        CubeBody.AddForce((Vector3.left * MoveForce));
    }

	void Update() 
	{
		transform.Rotate(m_RotationDirection * Time.deltaTime * m_Speed);
	}
}
