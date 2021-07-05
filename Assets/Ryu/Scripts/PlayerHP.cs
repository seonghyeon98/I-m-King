using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : HPComponent
{
    protected override void TakeDamage()
    {
        // 피격 애니메이션
        // 사운드 호출
        // HP UI 갱신
    }

    protected override void Heal()
    {
        // 회복 파티클
    }

    protected override void Death()
    {
        Destroy(this.gameObject);
    }
}
