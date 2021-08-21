using System.Collections;
using System.Collections.Generic;
using Demo.GameTime;
using Demo.InputService;
using UnityEngine;
using Zenject;

namespace Demo.MovementControlService
{
    [RequireComponent(typeof(CharacterController))]
    public class MovementController : MonoBehaviour, IMovementController
    {
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private float _movementVelocity;
        [SerializeField] private float _jumpVelocity;
        [SerializeField] private float _fallSpeedMultiplier;
        [SerializeField] private float _rotationSpeed = 3f;
        [SerializeField] private float _sprintSpeedModifier = 1.5f;

        private Vector3 _gravity = Physics.gravity;
        private Vector3 _verticalMovementVelocity;
        
        private Transform _characterControllerTransform;
        private Transform _thirdPersonCameraTransform;
        
        private IMovementInput _movementInput;
        private IGameTime _gameTime;
        private IThirdPersonCamera _thirdPersonCamera;
        
        [Inject]
        public void Init(IMovementInput movementInput, IThirdPersonCamera thirdPersonCamera, IGameTime gameTime)
        {
            _movementInput = movementInput;
            _thirdPersonCamera = thirdPersonCamera;
            _gameTime = gameTime;
            
            _characterControllerTransform = _characterController.transform;
            _thirdPersonCameraTransform = _thirdPersonCamera.Transform;
        }

        public void SetCharacterController(CharacterController characterController)
        {
            _characterController = characterController;
        }
        
        private void Update()
        {
            ApplyGravity();

            Vector3 verticalMovementInputVector = _movementInput.GetVerticalMovementVector();
            
            CalculateVerticalMovementVelocity(verticalMovementInputVector);
            
            Vector3 horizontalMovementVectorInput = _movementInput.GetHorizontalMovementVector();

            bool sprint = _movementInput.Sprint();
            
            Vector3 horizontalMovementVelocity = GetHorizontalMovementVelocity(horizontalMovementVectorInput, _thirdPersonCameraTransform, sprint);
            
            Rotate(horizontalMovementVelocity);
            
            MoveCharacterController(_characterController, horizontalMovementVelocity, _verticalMovementVelocity);
        }

        public Vector3 GetHorizontalMovementVelocity(Vector3 horizontalMovementVectorInput, Transform thirdPersonCameraTransform, bool sprint)
        {
            Vector3 horizontalMovementVector = Vector3.ProjectOnPlane(thirdPersonCameraTransform.TransformDirection(horizontalMovementVectorInput), Vector3.up).normalized;
            Vector3 horizontalMovementVelocity = horizontalMovementVector * _movementVelocity;
            horizontalMovementVelocity = sprint ? horizontalMovementVelocity * _sprintSpeedModifier : horizontalMovementVelocity;
            return horizontalMovementVelocity;
        }

        public void CalculateVerticalMovementVelocity(Vector3 verticalMovementInputVector)
        {
            if (_characterController.isGrounded && verticalMovementInputVector != Vector3.zero)
                _verticalMovementVelocity = Vector3.up * _jumpVelocity;
        }

        public void MoveCharacterController(CharacterController characterController, Vector3 horizontalMovementVelocity, Vector3 verticalMovementVelocity)
        {
            Vector3 velocity = horizontalMovementVelocity + verticalMovementVelocity;
            characterController.Move(velocity * _gameTime.DeltaTime);
        }

        private void ApplyGravity()
        {
            _verticalMovementVelocity += _gravity * _fallSpeedMultiplier;
            
            if (_characterController.isGrounded)
                _verticalMovementVelocity = Vector3.zero;
        }

        private void Rotate(Vector3 movementVectorVelocity)
        {
            if (movementVectorVelocity != Vector3.zero)
            {
                _characterControllerTransform.forward = Vector3.Lerp(_characterControllerTransform.forward, movementVectorVelocity.normalized, _gameTime.DeltaTime * _rotationSpeed);
            }
        }
    }
}