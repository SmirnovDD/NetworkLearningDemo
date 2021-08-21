using UnityEngine;

namespace Demo.InputService
{
    public class MovementInput : IMovementInput
    {
        private readonly MouseInput _mouseInput = new MouseInput();

        public bool Sprint()
        {
            return Input.GetKey(KeyCode.LeftShift);
        }

        public Vector3 GetHorizontalMovementVector()
        {
            Vector3 movementVector = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
            return movementVector;
        }

        public Vector3 GetVerticalMovementVector()
        {
            Vector3 movementVector = Input.GetKeyDown(KeyCode.Space) ? Vector3.up : Vector3.zero;
            return movementVector;
        }
    }
}