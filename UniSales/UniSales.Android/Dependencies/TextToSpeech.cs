﻿using Android.Speech.Tts;
using UniSales.Core.Contracts.Services.General;
using UniSales.Droid.Dependencies;
using Xamarin.Forms;

[assembly: Dependency(typeof(TextToSpeechImplementation))]
namespace UniSales.Droid.Dependencies
{
    public class TextToSpeechImplementation : Java.Lang.Object, ITextToSpeech, TextToSpeech.IOnInitListener
    {
        private TextToSpeech _speaker;
        private string _textToRead;

        public void ReadText(string text)
        {
            _textToRead = text;
            if (_speaker == null)
            {
                _speaker = new TextToSpeech(MainActivity.Instance, this);
            }
            else
            {
                _speaker.Speak(_textToRead, QueueMode.Flush, null, null);
            }
        }

        public void OnInit(OperationResult status)
        {
            if (status.Equals(OperationResult.Success))
            {
                _speaker.Speak(_textToRead, QueueMode.Flush, null, null);
            }
        }
    }
}