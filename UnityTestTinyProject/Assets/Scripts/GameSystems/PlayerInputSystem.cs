using Unity.Entities;
using Unity.Tiny.Input;

public class PlayerInputSystem : SystemBase
{
    protected override void OnCreate()
    {
        base.OnCreate();

        //RequireSingletonForUpdate<PlayerInputComponent>();
    }
    protected override void OnUpdate()
    {
        var inputSystem = World.GetExistingSystem<InputSystem>();

        PlayerInputComponent playerInputComponent = GetSingleton<PlayerInputComponent>();
        
        playerInputComponent.Left = default;
        playerInputComponent.Right = default;

        if (inputSystem.GetKey(KeyCode.A) || inputSystem.GetKey(KeyCode.LeftArrow))
            playerInputComponent.Left = true;
        if (inputSystem.GetKey(KeyCode.D) || inputSystem.GetKey(KeyCode.RightArrow))
            playerInputComponent.Right = true;

        SetSingleton(playerInputComponent);
    }
}
