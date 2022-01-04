using Unity.Entities;
using Unity.Mathematics;
using Unity.U2D.Entities.Physics;
[UpdateAfter(typeof(PlayerInputSystem))]
public class SpaceshipRotationSystem : SystemBase
{
    protected override void OnUpdate()
    {        
        PlayerInputComponent playerInputComponent = GetSingleton<PlayerInputComponent>();

        if (!playerInputComponent.Left && !playerInputComponent.Right)
            return;
        
        
        Entity player = GetSingletonEntity<PlayerInputComponent>();
        SpaceshipComponent spaceshipComponent = EntityManager.GetComponentData<SpaceshipComponent>(player);
        PhysicsVelocity  physicsVelocity = EntityManager.GetComponentData<PhysicsVelocity>(player);

        physicsVelocity.Angular += math.mul(Time.DeltaTime, spaceshipComponent.AngularSpeed);

        EntityManager.SetComponentData(player, physicsVelocity);
    }
}
