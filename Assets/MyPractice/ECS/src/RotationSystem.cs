using Unity.Burst;
using Unity.Entities;
using Unity.Transforms;

namespace MyPractice.ECS
{
    public partial struct RotationSystem : ISystem
    {
        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<RotationSpeedComponent>();
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            float deltaTime = SystemAPI.Time.DeltaTime;

            foreach (var (localTransform, speed) in SystemAPI.Query<RefRW<LocalTransform> , RefRO<RotationSpeedComponent>>())
            {
                float radianSpeed = speed.ValueRO.RadianPerSecond;
                localTransform.ValueRW = localTransform.ValueRO.RotateY(radianSpeed * deltaTime);
            }
        }

        [BurstCompile]
        public void OnDestroy(ref SystemState state)
        {
        }
    }
}
