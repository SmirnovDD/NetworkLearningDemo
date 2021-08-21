using Demo.GameTime;
using Demo.InputService;
using UnityEngine;
using Zenject;

namespace Demo.MovementControlService
{
    public class ThirdPersonCamera : MonoBehaviour, IThirdPersonCamera
    {
        public Transform Transform => transform;
        
        [SerializeField] private bool _lockCursor;
        [SerializeField] private float _mouseSensitivity = 10;
        [SerializeField] private float _zoomScrollSensitivity = 10;
        [SerializeField] private Transform _target;
        [SerializeField] private float _dstFromTarget = 2;
        [SerializeField] private Vector2 _pitchMinMax = new Vector2(-40, 85);
        [SerializeField] private float _minCameraDistance = 3;
        [SerializeField] private float _maxCameraDistance = 7;
        [SerializeField] private float _rotationSmoothTime = .12f;

        private Vector3 _rotationSmoothVelocity;
        private Vector3 _currentRotation;

        private float _yaw;
        private float _pitch;
        private Transform _transform;

        private IMouseInput _mouseInput;
        private IGameTime _gameTime;
        
        [Inject]
        public void Init(IMouseInput mouseInput, IGameTime gameTime)
        {
            _mouseInput = mouseInput;
            _gameTime = gameTime;
            _transform = transform;
            
            if (_lockCursor)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
        
        private void LateUpdate()
        {
            RotateAround();
            Vector2 zoomVector = _mouseInput.GetMouseWheel();
            Zoom(zoomVector);
        }

        public void RotateAround()
        {
            _yaw += _mouseInput.GetMouseMoveDelta().x * _gameTime.DeltaTime * _mouseSensitivity;
            _pitch -= _mouseInput.GetMouseMoveDelta().y * _gameTime.DeltaTime * _mouseSensitivity;

            _pitch = Mathf.Clamp(_pitch, _pitchMinMax.x, _pitchMinMax.y);

            _currentRotation = Vector3.SmoothDamp(_currentRotation, new Vector3(_pitch, _yaw), ref _rotationSmoothVelocity,
                _rotationSmoothTime);

            _transform.eulerAngles = _currentRotation;
        }

        public void Zoom(Vector2 zoomInputVector)
        {
            if (zoomInputVector != Vector2.zero)
                _dstFromTarget -= zoomInputVector.y * _gameTime.DeltaTime * _zoomScrollSensitivity;
            
            _dstFromTarget = Mathf.Clamp(_dstFromTarget, _minCameraDistance, _maxCameraDistance);
            _transform.position = _target.position - transform.forward * _dstFromTarget;
        }
    }
}