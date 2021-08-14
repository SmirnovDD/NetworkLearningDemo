using UnityEngine;

namespace Demo.InputService
{
    public class MovementInput : IMovementInput
    {
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

        public int GetMouseClick()
        {
            if (Input.GetMouseButtonDown(0))
                return 0;
            if (Input.GetMouseButtonDown(1))
                return 1;
            
            return -1;
        }

        public Vector2 GetMouseMoveDelta()
        {
            return new Vector2(Input.GetAxis ("Mouse X"), Input.GetAxis ("Mouse Y"));
        }
    }
}