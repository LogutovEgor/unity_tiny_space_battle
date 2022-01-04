using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;
using Unity.U2D.Entities.Physics;

public class SpaceshipMovementSystem : SystemBase
{
    protected override void OnUpdate()
    {
        var dt = Time.DeltaTime;
        Entities.ForEach((ref PhysicsVelocity velocity, in SpaceshipComponent spaceshipComponent, in LocalToWorld localToWorld) => {

            float2 entityUp = new float2(localToWorld.Up.x, localToWorld.Up.y);

            float speed = math.mul(spaceshipComponent.Speed, dt);

            float xVelocity = math.mul(entityUp.x, speed);
            float yVelocity = math.mul(entityUp.y, speed);

            velocity.Linear = new float2(xVelocity, yVelocity);

        }).ScheduleParallel();
    }
}