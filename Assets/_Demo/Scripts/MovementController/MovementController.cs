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
        [SerializeField] private float _jumpHeight;

        private Vector3 _gravity = Physics.gravity;
        private float _verticalVelocity;
        private float _currentMovementVelocity;
        private float _speedSmoothVelocity;
        private Transform _characterControllerTransform;
        
        private IMovementInput _movementInput;
        private IGameTime _gameTime;
        
        [Inject]
        public void Init(IMovementInput movementInput, IGameTime gameTime)
        {
            _movementInput = movementInput;
            _gameTime = gameTime;
            _characterControllerTransform = _characterController.transform;
        }
        
        void Update()
        {
            Move();
        }

        public Vector3 GetHorizontalMovementVector()
        {
            Vector3 horizontalMovementVectorInput = _movementInput.GetHorizontalMovementVector(); 
            Vector3 horizontalMovementVector = _characterControllerTransform.TransformDirection(horizontalMovementVectorInput);
            Vector3 horizontalMovementVelocity = horizontalMovementVector * _movementVelocity * _gameTime.DeltaTime;
            
            return horizontalMovementVelocity;
        }

        public Vector3 GetVerticalMovementVector()
        {
            if (_characterController.isGrounded == false)
                return Vector3.zero;
            if (_movementInput.GetVerticalMovementVector() == Vector3.zero)
                return Vector3.zero;
            
            float jumpVelocity = Mathf.Sqrt (-2 * _gravity.y * _jumpHeight);
            _verticalVelocity = jumpVelocity;
            
            return Vector3.up * _verticalVelocity;
        }

        public void Move()
        {
            Vector3 movementVector = GetHorizontalMovementVector() + GetVerticalMovementVector();
            
            _currentMovementVelocity = Mathf.SmoothDamp (_currentMovementVelocity, movementVector.magnitude, ref _speedSmoothVelocity, 0.1f);

            _verticalVelocity += _gameTime.DeltaTime * _gravity.y;
            
            Vector3 velocity = transform.forward * _currentMovementVelocity + Vector3.up * _verticalVelocity;

            
            _characterController.Move(velocity);
        }
    }
}