using UnityEngine;

namespace Demo.InputService
{
    public interface IHorizontalMovementInput
    {
        bool Sprint();
        Vector3 GetHorizontalMovementVector();
    }
}