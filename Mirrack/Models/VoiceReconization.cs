using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Vosk;
using System.Diagnostics;
using SoundFlow;
using SoundFlow.Abstracts;
using SoundFlow.Backends.MiniAudio;
using SoundFlow.Enums;
using SoundFlow.Components;
using System.IO;
using WebRtcVadSharp;
using SkiaSharp;

namespace Mirrack.Models
{
    internal class VoiceReconization
    {
        public string RecordSpeech()
        {
            //records the microphone and stops when no voice is heard
            bool recording = true;
            AudioEngine audioEngine = new MiniAudioEngine(16000, Capability.Record);
            string outputFilePath = Path.Combine(Directory.GetCurrentDirectory(), "output.wav");
            using var fileStream = new FileStream(outputFilePath, FileMode.Create, FileAccess.Write, FileShare.None);
            byte[] frame = [1, 0, 0, 0, 1, 1, 0];
            WebRtcVad vad = new WebRtcVad();
            while (recording)
            {
                if (!vad.HasSpeech(frame)) 
                {
                    
                }
            }
            
            
            
            vad.HasSpeech(frame);

            return outputFilePath;
        }
        public string Transcribe(string recordingPath)
        {
            //given a recording, vosk will transcribe speech
            VoskRecognizer recognizer = new VoskRecognizer(new Model("model"), 16000.0f);
            return "todo";
        }
    }
}
