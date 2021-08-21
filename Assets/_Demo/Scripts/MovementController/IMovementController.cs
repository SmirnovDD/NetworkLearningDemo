
using UnityEngine;

namespace Demo.MovementControlService
{
    public interface IMovementController
    {
        Vector3 GetHorizontalMovementVelocity(Vector3 horizontalMovementVectorInput, Transform thirdPersonCameraTransform, bool sprint);
        void CalculateVerticalMovementVelocity(Vector3 verticalMovementInputVector);
        void MoveCharacterController(CharacterController characterController, Vector3 horizontalMovementVelocity, Vector3 verticalMovementVelocity);
    }
}