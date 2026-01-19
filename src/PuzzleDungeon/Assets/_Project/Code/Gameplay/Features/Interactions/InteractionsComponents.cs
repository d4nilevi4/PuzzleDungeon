using Leontitas;
using UnityEngine;

namespace PuzzleDungeon.Gameplay.Interactions;

[Game] public struct Interactable : IComponent { }
[Game] public struct Hovered : IComponent { }
[Game] public struct InteractionCollider : IComponent { public Collider Value; }