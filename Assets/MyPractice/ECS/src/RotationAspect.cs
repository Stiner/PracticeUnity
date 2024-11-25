using Unity.Entities;
using Unity.Transforms;

namespace MyPractice.ECS
{
    readonly partial struct MyRotationAspect : IAspect
    {
        readonly RefRW<LocalTransform> _Transform;
        readonly RefRO<RotationSpeed> _Speed;

        public void Rotate(float deltaTime)
        {
            float anglePerSec = deltaTime * _Speed.ValueRO.RadianPerSecond;
            _Transform.ValueRW = _Transform.ValueRO.RotateY(anglePerSec);
        }
    }
}
