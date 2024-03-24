using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] AudioClip shootingClip;
    [SerializeField] [Range(0.0f, 1.0f)] float shootingVolume = 1.0f;

    [Header("Damage")]
    [SerializeField] AudioClip damageClip;
    [SerializeField][Range(0.0f, 1.0f)] float damageVolume = 1.0f;

    static AudioPlayer instance;

    void Awake()
    {
        ManageSingleton();
    }

    public void PlayShootingClip()
    {
        PlayAudioClip(shootingClip, shootingVolume);
    }

    public void PlayDamageClip()
    {
        PlayAudioClip(damageClip, damageVolume);
    }

    private void PlayAudioClip(AudioClip audioClip, float volume)
    {
        if (audioClip != null)
        {
            AudioSource.PlayClipAtPoint(
                audioClip,
                Camera.main.transform.position,
                volume);
        }
    }

    void ManageSingleton()
    {
        if (instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
