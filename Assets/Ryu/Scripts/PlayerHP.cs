using JHS;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : HPComponent
{
    [SerializeField] HPBar hpBar;
    [SerializeField] AudioClip deathSound;

    protected override void TakeDamage(float delta)
    {
        // 피격 애니메이션
        // 사운드 호출
        // HP UI 갱신
    }

    protected override void Heal(float delta)
    {
        // 회복 파티클
    }

    protected override void Death()
    {
        this.gameObject.SetActive(false);
        SoundSystem.Instance.PlaySoundEffect(deathSound);
    }

    protected override void RefreshUIElement()
    {
        hpBar.ApplyHPBarUI(CurrentHP / maxHP);
    }
}
