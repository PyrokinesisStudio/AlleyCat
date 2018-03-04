using Godot;

namespace AlleyCat.Motion
{
    public interface IOrbiter
    {
        float Pitch { get; set; }

        float Yaw { get; set; }

        float Distance { get; set; }

        Vector3 Pivot { get; }

        Vector3 Up { get; }

        Vector3 Forward { get; }

        void Rotate(Vector2 rotation);
    }
}