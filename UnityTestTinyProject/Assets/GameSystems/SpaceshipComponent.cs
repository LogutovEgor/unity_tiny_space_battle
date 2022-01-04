using Unity.Entities;

[GenerateAuthoringComponent]
public struct SpaceshipComponent : IComponentData
{
    public float Speed;
    public float AngularSpeed;
}