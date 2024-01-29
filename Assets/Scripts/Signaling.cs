using UnityEngine;

public class Signaling : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    private float _targetVolumeValue;
    private float _maxVolumeValue = 1.0f;
    private float _minVolumeValue = 0.0f;

    private void Update()
    {
        _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _targetVolumeValue, 0.1f * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        _targetVolumeValue = _maxVolumeValue;
    }

    private void OnTriggerExit(Collider other)
    {
        _targetVolumeValue = _minVolumeValue;
    }
}
