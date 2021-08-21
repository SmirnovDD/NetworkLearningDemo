using System.Collections;
using System.Collections.Generic;
using Demo.GameTime;
using Demo.InputService;
using Demo.MovementControlService;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using UnityEngine;

namespace DemoTests
{
    public class TestMovementController
    {
        [Test]
        public void WhenInputIsForward_AndCharacterPositionIsVector3Zero_ThenCharacterPositionShouldNotBeVector3Zero()
        {
            // Arrange.
            GameObject character = new GameObject();
            character.transform.position = Vector3.zero;
            
            CharacterController characterController = character.AddComponent<CharacterController>();
            MovementController movementController = character.AddComponent<MovementController>();
            IMovementInput movementInput = Substitute.For<IMovementInput>();
            IThirdPersonCamera thirdPersonCamera = Substitute.For<IThirdPersonCamera>();
            IGameTime gameTime = Substitute.For<IGameTime>();
            
            gameTime.DeltaTime.Returns(0.2f);

            movementController.SetCharacterController(characterController);
            movementController.Init(movementInput, thirdPersonCamera, gameTime);
            
            // Act.
            movementController.MoveCharacterController(characterController, Vector3.forward, Vector3.zero);
            // Assert.

            character.transform.position.Should().NotBe(Vector3.zero);
        }
    }
    
}
