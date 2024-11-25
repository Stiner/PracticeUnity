using Unity.Entities;
using Unity.Transforms;

namespace MyPractice.ECS
{
    struct RotationSpeed : IComponentData
    {
        public float RadianPerSecond;
    }
}
