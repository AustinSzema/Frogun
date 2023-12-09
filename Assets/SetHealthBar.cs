using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetHealthBar : MonoBehaviour
{
    [SerializeField] private intVariable _playerHealth;

    [SerializeField] private Slider _slider;
    
    // Update is called once per frame
    void Update()
    {
        _slider.value = Mathf.Clamp((float)_playerHealth.Value, 0f, 1f);
    }
}
