using Unity.Entities;

[GenerateAuthoringComponent]
public struct SpaceshipRotationComponent : IComponentData
{
    public float AngularSpeed;
    public bool Clockwise;
    public bool Counterclockwise;
}
