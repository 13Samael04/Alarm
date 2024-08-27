using UnityEngine;

[RequireComponent(typeof(Signaling))]

public class House : MonoBehaviour
{
    private Signaling _signaling;
    private bool _isEnter = false;

    private void Start()
    {
        _signaling = GetComponent<Signaling>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent(out Player player))
        {
            _isEnter = true;
            _signaling.SetVolume(_isEnter);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Player player))
        {
            _isEnter = false;
            _signaling.SetVolume(_isEnter);
        }
    }
}
