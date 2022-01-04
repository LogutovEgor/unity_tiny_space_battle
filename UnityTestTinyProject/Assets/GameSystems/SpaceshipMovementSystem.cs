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
            //    rot.Value = math.mul(rot.Value, quaternion.RotateY(dt * rc.Speed));

            //float3 pos = translation.Value;


            //pos.y += math.mul(spaceshipComponent.Speed, dt);

            //translation.Value = pos;



            float2 entityUp = new float2(localToWorld.Up.x, localToWorld.Up.y);

            float speed = math.mul(spaceshipComponent.Speed, dt);

            float xVelocity = math.mul(entityUp.x, speed);
            float yVelocity = math.mul(entityUp.y, speed);


            velocity.Linear = new float2(xVelocity, yVelocity);


            //velocity.Linear = new float2(0, 1f);
        }).ScheduleParallel();


    //    float currentSpeed =
    //motorCharacteristics.MinSpeed + ((motorCharacteristics.MaxSpeed - motorCharacteristics.MinSpeed) * enginePower);
    //    rigidbody2D.AddForce(transform.up * currentSpeed * Time.deltaTime);
    }
}