using Leontitas;

namespace PuzzleDungeon.Gameplay.InputHandling;

[Input] public struct PlayerInputComponent : IComponent { public PlayerInput Value; }
[Input] public struct GameplayInputActions : IComponent { public PlayerInput.GameplayActions Value; }

[Input] public struct MousePosition : IComponent { public Vector2 Value; }
[Input] public struct MousePositionDelta : IComponent { public Vector2 Value; }

[Input] public struct InteractionPerformedEvent : IComponent { }
[Input] public struct InteractionPressedEvent : IComponent { }