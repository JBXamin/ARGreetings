using UnityEngine;
using Vuforia;

public class CustomTrackableEventHandler : MonoBehaviour
{
    private ObserverBehaviour observerBehaviour;
    public AudioSource audioSource;  // Public to manually assign in the inspector

    void Start()
    {
        observerBehaviour = GetComponent<ObserverBehaviour>();
        if (observerBehaviour)
        {
            observerBehaviour.OnTargetStatusChanged += OnTargetStatusChanged;
        }
        if (!audioSource)
        {
            Debug.LogError("AudioSource not set on " + gameObject.name);
        }
    }

    private void OnTargetStatusChanged(ObserverBehaviour behaviour, TargetStatus targetStatus)
    {
        if (targetStatus.Status == Status.TRACKED && !audioSource.isPlaying)
        {
            audioSource.Play();
        }
        else if (targetStatus.Status != Status.TRACKED && audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }

    void OnDestroy()
    {
        if (observerBehaviour)
        {
            observerBehaviour.OnTargetStatusChanged -= OnTargetStatusChanged;
        }
    }
}
