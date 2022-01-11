using Unity.Entities;

[GenerateAuthoringComponent]
public struct MainCameraComponent : IComponentData 
{
    public float Smoothing;
}
