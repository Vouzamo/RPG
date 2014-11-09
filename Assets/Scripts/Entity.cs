using UnityEngine;
using System.Collections;

public abstract class Entity : MonoBehaviour {
	#region Properties
	protected float Friction;
	public string DisplayName;
	public float MovementSpeed;
	public float RotationSpeed;
	#endregion

	#region Constructors
	#endregion

	#region Methods
	public virtual void Start () {

	}
	public virtual void Update () {

	}
	protected void Move(Vector3 movementVector)
	{
		if (movementVector != Vector3.zero)
		{
			Vector3 previousPosition = transform.position;
			transform.Translate(movementVector * Time.deltaTime * MovementSpeed);
			transform.Rotate(Vector3.forward, Mathf.Atan2(movementVector.y, movementVector.x) * -1 * RotationSpeed);
		}
	}
	#endregion
}
