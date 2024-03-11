using UnityEngine;

public class MatchController : MonoBehaviour
{
    public PlayerController playerController;
    public FloatingJoystick joystick;

    private void Awake()
    {
        playerController.SetPlayer(joystick);
    }
}
