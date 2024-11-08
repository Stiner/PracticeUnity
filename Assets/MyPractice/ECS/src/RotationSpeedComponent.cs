using Unity.Entities;

namespace MyPractice.ECS
{
    public struct RotationSpeedComponent : IComponentData
    {
        public float RadianPerSecond;
    }
}
