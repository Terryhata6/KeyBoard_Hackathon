using UnityEngine;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour
{
    [SerializeField] private GameObject _mainPanel;
    [SerializeField] private Slider _sliderHP;
    [SerializeField] private Slider _sliderStamina;

    private PlayerParametersModel _player;

    private void Start()
    {
        _player = FindObjectOfType<PlayerParametersModel>();

        _sliderHP.maxValue = _player.GetMaxHP();
        _sliderStamina.maxValue = _player.GetMaxStamina();
    }

    private void Update()
    {
        _sliderHP.value = _player.GetCurrentHP();
        _sliderStamina.value = _player.GetCurrentStamina();
    }

    public void Activate(bool state)
    {
        _mainPanel.SetActive(state);
    }
}
