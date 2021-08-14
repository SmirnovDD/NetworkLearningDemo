using UnityEngine;

namespace Demo.GameTime
{
    public class GameTime : IGameTime
    {
        public float DeltaTime => Time.deltaTime * GameSpeed;
        public float GameSpeed { get; } = 1;
    }
}