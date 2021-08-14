
using UnityEngine;

namespace Demo.MovementControlService
{
    public interface IMovementController
    {
        Vector3 GetHorizontalMovementVector();
        Vector3 GetVerticalMovementVector();
        void Move();
    }
}