using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    private CustomInputManager _input;
    private PlayerParametersModel _player;

    private void Start()
    {
        _player = GetComponent<PlayerParametersModel>();
        _input = GetComponent<CustomInputManager>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(_input.LeftRollButton))
        {
            LeftDash(_player.GetDashPower(), _player.GetDashPrice());
        }
        if (Input.GetKeyDown(_input.RightRollButton))
        {
            RightDash(_player.GetDashPower(), _player.GetDashPrice());
        }
    }

    private void LeftDash(float dashpower, float dashprice)
    {
        if (_player.SpendStamina(dashprice))
        {
            GetComponent<Rigidbody>().AddForce(Vector3.left * dashpower, ForceMode.Impulse);
            _player.ToggleGodMode();
        }
    }

    private void RightDash(float dashpower, float dashprice)
    {
        if (_player.SpendStamina(dashprice))
        {
            GetComponent<Rigidbody>().AddForce(Vector3.right * dashpower, ForceMode.Impulse);
            _player.ToggleGodMode();
        }

    }
}
