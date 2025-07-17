using System;
using System.Collections.Generic;
using Vosk;
using SoundFlow.Abstracts;
using SoundFlow.Backends.MiniAudio;
using SoundFlow.Enums;
using SoundFlow.Components;
using System.IO;
using WebRtcVadSharp;

namespace Mirrack.Models
{
    internal class VoiceReconization
    {
        public string Transcribe()
        {
            //records the microphone and stops when no voice is heard
            AudioEngine audioEngine = new MiniAudioEngine(16000, Capability.Record);
            WebRtcVad vad = new WebRtcVad();
            vad.FrameLength = FrameLength.Is20ms;
            vad.SampleRate = SampleRate.Is16kHz;

            List<byte[]> recordedFrames = new();


            var stream = new MemoryStream();
            var recorder = new Recorder(stream, SampleFormat.F32, EncodingFormat.Wav, 16000, 1);

            //given a stream, vosk will transcribe speech
            using VoskRecognizer recognizer = new VoskRecognizer(new Model("model"), 16000.0f);
            recognizer.SetMaxAlternatives(0);
            recognizer.SetWords(true);


            byte[] buffer = new byte[320];
            int bytesRead;
            string result = "";
            int silentFrames = 0;
            while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
            {
                if(recognizer.AcceptWaveform(buffer, bytesRead))
                {
                    result = recognizer.Result();
                } else
                {
                    result = recognizer.PartialResult();
                }
                if (!vad.HasSpeech(buffer)) 
                {
                    silentFrames++;
                    if (silentFrames > 100)
                    {
                        break;
                    }
                }
            }

            return result;
        }
    }
}
