using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class Signaling : MonoBehaviour
{
    [SerializeField] private float _rateOfChangeSound;

    private float _minVolume = 0f;
    private float _maxVolume = 1f;
    private float _delay = 0.5f;
    private AudioSource _audioSource;
    private Coroutine _coroutine;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        _audioSource.volume = _minVolume;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        { 
            TurnOnAlarm(); 
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            TurnOffAlarm();
        }
    }

    private  void SetVolume(float volume)
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        _coroutine = StartCoroutine(ChangeVolume(volume));
    }

    private void TurnOnAlarm()
    {
        if (_audioSource.isPlaying == false)
        {
            _audioSource.Play();
        }

        SetVolume(_maxVolume);
    }

    private void TurnOffAlarm() 
    {
        SetVolume(_minVolume); 
    }

    private IEnumerator ChangeVolume(float targetVolume)
    {
        WaitForSeconds delay = new WaitForSeconds(_delay);
        float scale = _maxVolume / _rateOfChangeSound;

        while(_audioSource.volume != targetVolume)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, targetVolume, scale);

            yield return delay;
        }

        if(_audioSource.volume <= _minVolume)
        {
            _audioSource.Stop();
        }
    }
}
