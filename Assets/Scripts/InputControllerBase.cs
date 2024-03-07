using UnityEngine;

public abstract class InputControllerBase : MonoBehaviour
{
    public FloatingJoystick Joystick { get; set; }

    public abstract float Horizontal { get; }
    public abstract float Vertical { get; }
}
