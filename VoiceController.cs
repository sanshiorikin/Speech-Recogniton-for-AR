using System.Collections;
using System.Collections.Generic;
using TextSpeech;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Android;

public class VoiceController : MonoBehaviour
{
    public Text uiText; 
    public AvatarController avatarController;

    const string LANG_CODE = "fil-PH";

    private TextToSpeech textToSpeech;
    private SpeechToText speechToText;

    void Start()
    {

        textToSpeech = new TextToSpeech();
        speechToText = new SpeechToText();

        Setup(LANG_CODE);

       
        if (Permission.HasUserAuthorizedPermission(Permission.Microphone))
        {
           
            Debug.Log("Microphone permission granted.");
        }
        else
        {
           
            Permission.RequestUserPermission(Permission.Microphone);
        }
    }

    #region Speech To Text
    public void StartListening()
    {
        if (Permission.HasUserAuthorizedPermission(Permission.Microphone))
        {
            StartRecognition(); 
        }
        else
        {
            Debug.LogError("Microphone permission not granted.");
        }
    }

    private void StartRecognition()
    {
        string recognizedText = "Kamusta"; 
        OnSpeechRecognized(recognizedText);
    }


    private void OnSpeechRecognized(string recognizedText)
    {

        uiText.text = recognizedText;

        avatarController.PerformSignLanguage(recognizedText);
    }

    #endregion

    private void Setup(string languageCode)
    {

        textToSpeech.Setting(languageCode, 1, 1); 
        speechToText.Setting(languageCode);
    }
}
