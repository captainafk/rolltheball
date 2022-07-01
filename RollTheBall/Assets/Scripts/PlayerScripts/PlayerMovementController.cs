using UnityEngine;

namespace RollTheBall
{
    public class PlayerMovementController : MonoBehaviour
    {
        [SerializeField] private float _force;
        [SerializeField] private FloatingJoystick _Joystick;
        [SerializeField] private Rigidbody _rigidbody;

        public Rigidbody Rigidbody { get => _rigidbody; set => _rigidbody = value; }

        public void FixedUpdate()
        {
            var direction = Vector3.forward * _Joystick.Vertical +
                            Vector3.right * _Joystick.Horizontal;

            _rigidbody.AddForce(_force *
                                  Time.fixedDeltaTime *
                                  direction,
                                ForceMode.VelocityChange);
        }
    }
}