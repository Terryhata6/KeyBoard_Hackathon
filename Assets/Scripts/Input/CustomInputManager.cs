using UnityEngine;

public class CustomInputManager : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] public KeyCode AimButton;
    [SerializeField] public KeyCode LeftRollButton;
    [SerializeField] public KeyCode RightRollButton;

    [Header("Attack")]
    [SerializeField] public KeyCode BaseAttackButton;
}