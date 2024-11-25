using Unity.Entities;
using Unity.Mathematics;

namespace MyPractice.ECS
{
    struct Spawner : IComponentData
    {
        public Entity Prefab;
        public float3 SpawnPosition;
        public float NextSpawnTime;
        public float SpawnRate;
    }
}
