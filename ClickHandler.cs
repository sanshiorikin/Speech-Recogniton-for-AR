using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ClickHandler : MonoBehaviour
{
    public Button speechButton;
    public VoiceController voiceController;

    void Start()
    {
        speechButton.onClick.AddListener(OnSpeechButtonClick);
    }

    void OnSpeechButtonClick()
    {
        voiceController.StartListening();
    }
}

