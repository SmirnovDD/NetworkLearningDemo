using UnityEngine;

namespace Demo.MovementControlService
{
    public interface IThirdPersonCamera
    {
        Transform Transform { get; }
        void RotateAround();
        void Zoom(Vector2 zoomInputVector);
    }
}