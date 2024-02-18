using System.Collections;
using TMPro;
using UnityEngine;

public class SlotMachine : MonoBehaviour
{
    
    
    [SerializeField] private TextMeshProUGUI[] _slots;

    private int[] _values = new int[] {0, 0, 0, 0, 0, 1, 1, 1, 1, 2, 2, 2, 2, 3, 3, 3, 3};
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L)) // Check for 'l' key press
        {
            StartCoroutine(SpinSlotsForTime(2.0f)); // Start spinning for 2 seconds
        }
    }

    IEnumerator SpinSlotsForTime(float spinTime)
    {
        float endTime = Time.time + spinTime; // Calculate end time

        while (Time.time < endTime)
        {
            foreach (TextMeshProUGUI slotText in _slots)
            {
                slotText.text = "" + _values[Random.Range(0, _values.Length)]; // Change slot text
            }
            yield return null; // Wait for next frame
        }

        /*// After spinning ends, stop slots one by one with a slight delay
        for (int i = 0; i < _slots.Length; i++)
        {
            yield return new WaitForSeconds(0.1f); // Introduce delay before stopping next slot
            _slots[i].text = "" + Random.Range(0, 9); // Change slot text
        }*/
    }
}