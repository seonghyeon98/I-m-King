using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    // �������������������������� HP ���¿� ���� UI Slider HPBar�� �����ҷ���
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
