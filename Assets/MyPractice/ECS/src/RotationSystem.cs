using Unity.Burst;
using Unity.Entities;
using Unity.Transforms;

namespace MyPractice.ECS
{
    [BurstCompile]
    partial struct RotationSystem : ISystem
    {
        public void OnCreate(ref SystemState state)
        {
        }

        public void OnDestroy(ref SystemState state)
        {
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            float deltaTime = SystemAPI.Time.DeltaTime;

            //foreach (var (localTransform, speed) in SystemAPI.Query<RefRW<LocalTransform> , RefRO<RotationSpeed>>())
            //{
            //    float radianSpeed = speed.ValueRO.RadianPerSecond;
            //    localTransform.ValueRW = localTransform.ValueRO.RotateY(radianSpeed * deltaTime);
            //}

            foreach (var comp in SystemAPI.Query<MyRotationAspect>())
            {
                comp.Rotate(deltaTime);
            }
        }
    }
}
