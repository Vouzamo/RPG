using UnityEngine;

namespace RPG.Assets.Scripts.MonoBehaviour
{
    public abstract class Entity : UnityEngine.MonoBehaviour
    {
        #region Properties

        public string DisplayName;
        public float MovementSpeed;
        public float RotationSpeed;

        #endregion

        #region Methods
        public virtual void Start()
        {

        }

        public virtual void Update()
        {

        }

        protected void Move(Vector3 movementVector)
        {
            if (movementVector != Vector3.zero)
            {
                transform.Translate(movementVector*Time.deltaTime*MovementSpeed);
                transform.Rotate(Vector3.forward, Mathf.Atan2(movementVector.y, movementVector.x)*-1*RotationSpeed);
            }
        }
        #endregion
    }
}
