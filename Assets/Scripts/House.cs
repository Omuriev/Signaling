using UnityEngine;

public class House : MonoBehaviour
{
    [SerializeField] private Signaling _signaling;

    private Coroutine _ChangeVolumeCoroutine;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            if (_ChangeVolumeCoroutine != null)
            {
                StopCoroutine(_ChangeVolumeCoroutine);
            }

            _ChangeVolumeCoroutine = StartCoroutine(_signaling.ChangeVolume(_signaling.MaxVolumeValue));
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

            _ChangeVolumeCoroutine = StartCoroutine(_signaling.ChangeVolume(_signaling.MinVolumeValue));
        }
    }
}
