using UnityEngine;

namespace Demo.InputService
{
    public class MouseInput : IMouseInput
    {
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

        public Vector2 GetMouseWheel()
        {
            return Input.mouseScrollDelta;
        }
    }
}