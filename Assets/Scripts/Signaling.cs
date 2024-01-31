using UnityEngine;
using System.Collections;

public class Signaling : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    private float _maxVolumeValue = 1.0f;
    private float _minVolumeValue = 0.0f;
    private Coroutine _ChangeVolumeCoroutine;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            if (_ChangeVolumeCoroutine != null)
            {
                StopCoroutine(_ChangeVolumeCoroutine);
            }

            _ChangeVolumeCoroutine = StartCoroutine(ChangeVolume(_maxVolumeValue));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            if (_ChangeVolumeCoroutine != null)
            {
                StopCoroutine(_ChangeVolumeCoroutine);
            }

            _ChangeVolumeCoroutine = StartCoroutine(ChangeVolume(_minVolumeValue));
        }
    }

    private IEnumerator ChangeVolume(float targetVolumeValue)
    {
        float _changeVolumeStepValue = 0.1f;
        _audioSource.Play();

        while (_audioSource.volume != targetVolumeValue)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, targetVolumeValue, _changeVolumeStepValue * Time.deltaTime);

            yield return null;
        }

        if (_audioSource.volume == _minVolumeValue)
        {
            _audioSource.Stop();

            yield break;
        }
    }
}
