using System.Collections;
using System.Collections.Generic;

namespace Demo.GameTime
{
    public interface IGameTime
    {
        float DeltaTime { get; }
        float UnscaledDeltaTime { get; }
        float GameSpeed { get; }
    }
}