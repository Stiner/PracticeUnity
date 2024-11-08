using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;

namespace MyPractice.ECS
{
    public class RotationSpeedAuthoring : MonoBehaviour
    {
        [SerializeField]
        protected float _DegreesPerSecond = 10.0f;

        public float DegreesPerScond => _DegreesPerSecond;
    }

    class Baker : Baker<RotationSpeedAuthoring>
    {
        public override void Bake(RotationSpeedAuthoring authoring)
        {
            Entity entity = GetEntity(TransformUsageFlags.Dynamic);

            AddComponent(entity, new RotationSpeedComponent
            {
                RadianPerSecond = math.radians(authoring.DegreesPerScond)
            });
        }
    }
}
