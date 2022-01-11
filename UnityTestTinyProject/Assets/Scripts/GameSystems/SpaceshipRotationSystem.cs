using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using Unity.U2D.Entities.Physics;

//[UpdateAfter(typeof(PlayerInputSystem))]
public class SpaceshipRotationSystem : SystemBase
{
    //protected override void OnUpdate()
    //{        
    //    PlayerInputComponent playerInputComponent = GetSingleton<PlayerInputComponent>();

    //    if (!playerInputComponent.Left && !playerInputComponent.Right)
    //        return;

    //    Entity player = GetSingletonEntity<PlayerInputComponent>();
    //    SpaceshipComponent spaceshipComponent = EntityManager.GetComponentData<SpaceshipComponent>(player);
    //    PhysicsVelocity  physicsVelocity = EntityManager.GetComponentData<PhysicsVelocity>(player);

    //    if (playerInputComponent.Right)
    //        physicsVelocity.Angular -= math.mul(Time.DeltaTime, spaceshipComponent.AngularSpeed);
    //    else if (playerInputComponent.Left)
    //        physicsVelocity.Angular += math.mul(Time.DeltaTime, spaceshipComponent.AngularSpeed);

    //    EntityManager.SetComponentData(player, physicsVelocity);
    //}

    protected override void OnUpdate()
    {
        float dt = Time.DeltaTime;
        Entities.ForEach((ref PhysicsVelocity physicsVelocity, in SpaceshipRotationComponent spaceshipRotationComponent) => {

            if ((spaceshipRotationComponent.Clockwise && spaceshipRotationComponent.Counterclockwise) ||
            (!spaceshipRotationComponent.Clockwise && !spaceshipRotationComponent.Counterclockwise))
                return;

            if (spaceshipRotationComponent.Clockwise)
                physicsVelocity.Angular -= math.mul(dt, spaceshipRotationComponent.AngularSpeed);
            else if (spaceshipRotationComponent.Counterclockwise)
                physicsVelocity.Angular += math.mul(dt, spaceshipRotationComponent.AngularSpeed);

        }).ScheduleParallel();
    }
}
