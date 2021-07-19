using UnityEngine;

namespace JHS
{
    #region 머리말 주석
    /// <summary>
    ///
    /// 원 저작자(개발자) : 진호성 <para></para>
    /// 개요 : 사운드 제어 기능 정의 <para></para>
    ///
    /// </summary>
     #endregion
    public class SoundSystem : SystemObject<SoundSystem>
    {
        #region 필드

        [SerializeField, LabelName("배경음 오디오 소스")] AudioSource m_audioSourceForBgm;
        [SerializeField, LabelName("효과음 오디오 소스")] AudioSource m_audioSourceForEffects;

        #endregion

        #region 공개 메소드

        /// <summary>
        /// 해당 오디오 클립으로 BGM 재생 (반복 재생)
        /// </summary>
        /// <param name="_clip"> 재생할 오디오 클립 </param>
        public void PlaySoundBGM(AudioClip _clip)
        {
            if (!_clip) return;
            m_audioSourceForBgm.clip = _clip;
            m_audioSourceForBgm.Play();
        }

        /// <summary>
        /// BGM 재생 중지
        /// </summary>
        public void StopSoundBGM()
        {
            m_audioSourceForBgm.Stop();
        }

        /// <summary>
        /// 해당 오디오 클립으로 효과음 재생
        /// </summary>
        /// <param name="_clip"> 재생할 오디오 클립  </param>
        public void PlaySoundEffect(AudioClip _clip)
        {
            m_audioSourceForEffects.PlayOneShot(_clip);
        }

        #endregion
    } 
}
