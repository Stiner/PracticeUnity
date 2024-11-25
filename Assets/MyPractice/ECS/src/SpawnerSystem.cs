using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

using Random = Unity.Mathematics.Random;

namespace MyPractice.ECS
{
    [BurstCompile]
    partial struct SpawnerSystem : ISystem
    {
        static readonly Random rand = new Random(256);

        public void OnCreate(ref SystemState state)
        {
        }

        public void OnDestroy()
        {
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            double elapsedTime = SystemAPI.Time.ElapsedTime;

            foreach (RefRW<Spawner> spawner in SystemAPI.Query<RefRW<Spawner>>())
            {
                Entity prefab        = spawner.ValueRO.Prefab;
                float3 spawnPosition = spawner.ValueRO.SpawnPosition;
                float nextSpawnTime  = spawner.ValueRO.NextSpawnTime;

                if (nextSpawnTime < elapsedTime)
                {
                    Entity newEntity = state.EntityManager.Instantiate(prefab);

                    spawnPosition += rand.NextFloat3(new float3(10f, 10f, 10f));

                    LocalTransform spawnTransform = LocalTransform.FromPosition(spawnPosition);
                    state.EntityManager.SetComponentData(newEntity, spawnTransform);

                    spawner.ValueRW.NextSpawnTime = (float)elapsedTime + spawner.ValueRO.SpawnRate;
                }
            }
        }
    }
}

