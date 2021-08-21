using UnityEngine;

namespace Demo.InputService
{
    public interface IMouseInput
    {
        int GetMouseClick();
        Vector2 GetMouseMoveDelta();
        Vector2 GetMouseWheel();
    }
}