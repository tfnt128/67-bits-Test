public class InputController : InputControllerBase
{
    public override float Horizontal => enabled ? Joystick.Direction.x: 0f;
    public override float Vertical => enabled ? Joystick.Direction.y : 0f;
}
