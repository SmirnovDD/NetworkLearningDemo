using System.Collections;
using System.Collections.Generic;

namespace Demo.GameTime
{
    public interface IGameTime
    {
        float DeltaTime { get; }
        float GameSpeed { get; }
    }
}