using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Terrain : MonoBehaviour
{
    public int hpCurrent;
    public int hpMax;
    [SerializeField] Slider hpSlider;
    private Coroutine sliderCoroutine;

    void Start()
    {
        if (hpSlider != null )
        {
            hpSlider.maxValue = hpMax;
            hpSlider.value = hpCurrent;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            TakeDamage(5);
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            TakeDamage(-3);
        }
    }

    public void TakeDamage(int dmg)
    {
        if (hpCurrent - dmg < 0)
        {
            hpCurrent = 0;
        }
        else if (hpCurrent - dmg > hpMax)
        {
            hpCurrent = hpMax;
        }
        else
        {
            hpCurrent -= dmg;
        }

        if (sliderCoroutine != null) StopCoroutine(sliderCoroutine);
        sliderCoroutine = StartCoroutine(AdjustSlider(hpCurrent));
    }

    private IEnumerator AdjustSlider(int target)
    {
        Debug.Log(target);
        while (hpSlider.value != target)
        {
            if (target > hpSlider.value)
            {
                hpSlider.value += 1;
            }
            else
            {
                hpSlider.value -= 1;
            }
            yield return new WaitForSeconds(0.2f);
        }
    }
}
