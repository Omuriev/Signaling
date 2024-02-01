using UnityEngine;
using System.Collections;

public class Signaling : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    public float MaxVolumeValue { get; private set; } = 1.0f;
    public float MinVolumeValue { get; private set; } = 0.0f;

    public IEnumerator ChangeVolume(float targetVolumeValue)
    {
        float _changeVolumeStepValue = 0.1f;
        _audioSource.Play();

        while (_audioSource.volume != targetVolumeValue)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, targetVolumeValue, _changeVolumeStepValue * Time.deltaTime);

            yield return null;
        }

        if (_audioSource.volume == MinVolumeValue)
        {
            _audioSource.Stop();

            yield break;
        }
    }
}
