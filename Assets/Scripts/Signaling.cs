using UnityEngine;
using System.Collections;

public class Signaling : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    private float _targetVolumeValue;
    private float _maxVolumeValue = 1.0f;
    private float _minVolumeValue = 0.0f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            _audioSource.Play();
            _targetVolumeValue = _maxVolumeValue;
            StartCoroutine(SignalingWorker(_targetVolumeValue));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _targetVolumeValue = _minVolumeValue;
    }

    private IEnumerator SignalingWorker(float targetVolumeValue)
    {
        while (_audioSource.volume != targetVolumeValue)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _targetVolumeValue, 0.1f * Time.deltaTime);

            if (_audioSource.volume == _minVolumeValue)
            {
                _audioSource.Stop();

                yield break;
            }

            yield return null;
        }
    }
}
