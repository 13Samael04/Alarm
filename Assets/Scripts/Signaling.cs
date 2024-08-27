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

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = _minVolume;
    }

    public void SetVolume(bool isEnter)
    {
        float targetVolume;

        if(_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        if(isEnter == true)
        {
            targetVolume = _maxVolume;
            _audioSource.Play();
        }
        else
        {
            targetVolume= _minVolume;
        }

        _coroutine = StartCoroutine(ChangeVolume(targetVolume));
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
