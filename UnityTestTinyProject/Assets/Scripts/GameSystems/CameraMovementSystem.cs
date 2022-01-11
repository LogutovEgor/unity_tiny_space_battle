using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

public class CameraMovementSystem : SystemBase
{
    protected override void OnUpdate()
    {
        RequireSingletonForUpdate<MainCameraComponent>();

        float3 playerPosition = float3.zero;

        Entities
            .WithAll<PlayerSpaceship>()
            .ForEach((in Translation translation) => playerPosition = translation.Value).Run();

        Entity camera = GetSingletonEntity<MainCameraComponent>();
        MainCameraComponent mainCameraComponent = EntityManager.GetComponentData<MainCameraComponent>(camera);
        Translation cameraTranslation = EntityManager.GetComponentData<Translation>(camera);

        cameraTranslation.Value = new float3(
            math.lerp(cameraTranslation.Value.x, playerPosition.x, mainCameraComponent.Smoothing * Time.DeltaTime),
            math.lerp(cameraTranslation.Value.y, playerPosition.y, mainCameraComponent.Smoothing * Time.DeltaTime), 
            cameraTranslation.Value.z);

        EntityManager.SetComponentData(camera, cameraTranslation);
    }
}
