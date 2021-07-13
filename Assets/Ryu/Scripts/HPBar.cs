using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    // けいしけししけしけけし薄仙 HP 雌殿拭 魚虞 UI Slider HPBar拭 旋遂拝掘遂
    Slider hpBar;

    private void Awake()
    {
        hpBar = GetComponent<Slider>();
    }

    public void ApplyHPBarUI(float value)
    {
        hpBar.value = value;
    }
}
