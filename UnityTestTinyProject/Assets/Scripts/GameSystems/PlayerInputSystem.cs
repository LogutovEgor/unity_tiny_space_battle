using Unity.Entities;
using Unity.Tiny;
using Unity.Tiny.Input;

[UpdateBefore(typeof(SpaceshipRotationSystem))]
public class PlayerInputSystem : SystemBase
{
    //protected override void OnCreate()
    //{
    //    base.OnCreate();

    //    //RequireSingletonForUpdate<PlayerInputComponent>();
    //}
    protected override void OnUpdate()
    {
        InputSystem inputSystem = World.GetExistingSystem<InputSystem>();

        //DisplayInfo displayInfo = GetSingleton<DisplayInfo>();

        //PlayerInputComponent playerInputComponent = GetSingleton<PlayerInputComponent>();

        //playerInputComponent.Left = default;
        //playerInputComponent.Right = default;

        //if (inputSystem.GetKey(KeyCode.A) || inputSystem.GetKey(KeyCode.LeftArrow))
        //    playerInputComponent.Left = true;
        //if (inputSystem.GetKey(KeyCode.D) || inputSystem.GetKey(KeyCode.RightArrow))
        //    playerInputComponent.Right = true;

        // SetSingleton(playerInputComponent);

        

        bool left = inputSystem.GetKey(KeyCode.A) || inputSystem.GetKey(KeyCode.LeftArrow);
        bool right = inputSystem.GetKey(KeyCode.D) || inputSystem.GetKey(KeyCode.RightArrow);

        Entity player = GetSingletonEntity<PlayerSpaceship>();

        SpaceshipRotationComponent spaceshipRotationComponent = EntityManager.GetComponentData<SpaceshipRotationComponent>(player);

        spaceshipRotationComponent.Clockwise = right;
        spaceshipRotationComponent.Counterclockwise = left;

        EntityManager.SetComponentData(player, spaceshipRotationComponent);

        //Entities.ForEach((ref SpaceshipRotationComponent spaceshipRotationComponent, in PlayerSpaceship playerSpaceship) => {
        //    spaceshipRotationComponent.Clockwise = right;
        //    spaceshipRotationComponent.Counterclockwise = left;
        //}).ScheduleParallel();
    }
}
