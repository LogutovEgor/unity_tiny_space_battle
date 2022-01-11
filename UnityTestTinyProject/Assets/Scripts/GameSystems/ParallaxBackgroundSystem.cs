using Unity.Entities;
using Unity.Tiny.Rendering;
using Unity.Transforms;
using Unity.Mathematics;

public class ParallaxBackgroundSystem : SystemBase
{
    protected override void OnUpdate()
    {
        Entity camera = GetSingletonEntity<MainCameraComponent>();
        //MainCameraComponent mainCameraComponent = EntityManager.GetComponentData<MainCameraComponent>(camera);
        Translation cameraTranslation = EntityManager.GetComponentData<Translation>(camera);

        float3 cameraPosition = cameraTranslation.Value;

        Entities.ForEach((ref MeshRenderer meshRenderer, in ParallaxBackgroundComponent parallaxBackgroundComponent) =>
        {
            Entity materialEntity = meshRenderer.material;
            SimpleMaterial material = EntityManager.GetComponentData<SimpleMaterial>(materialEntity);
            material.offset = new float2(
                cameraPosition.x / parallaxBackgroundComponent.Speed,
                -cameraPosition.y / parallaxBackgroundComponent.Speed
                );
            //material.constAlbedo = new float3(1, 0, 0);
            EntityManager.SetComponentData(meshRenderer.material, material);
        }).WithoutBurst().Run();
    }

    //transform.position = camera.transform.position + positionOffset;
    //renderer.material.SetTextureOffset("_MainTex", (Vector2) camera.transform.position / speedToZero);
}
