using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenGL_Game.Managers;
using OpenTK.Audio.OpenAL;
using System.IO;
using OpenTK;

namespace OpenGL_Game.Components
{
    class ComponentAudio : IComponent
    {
        private int audioSource;
        private Vector3 sourcePosition;
        private int audio;

        private bool notPlayed = true;

        private string audiosourcedeath = "Audio/Ghost kill.wav";   /*= insert name path;*/
        private int audioDeath;
        private int DeathSource;
        

        public ComponentAudio(string audioName)
        {
            audio = ResourceManager.LoadAudio(audioName);
            //audioBuffer = ResourceManager.LoadAudio("Audio/buzz.wav");

            audioSource = AL.GenSource();
            AL.Source(audioSource, ALSourcei.Buffer, audio); // attach the buffer to a source

           // AL.Source(audioSource, ALSourceb.Looping, true); // source loops infinitely

            // sourcePosition = new Vector3(10.0f, 0.0f, 0.0f); // give the source a position

            // AL.Source(audioSource, ALSource3f.Position, ref sourcePosition);

            //AL.SourcePlay(audioSource); // play the audio source
        }

        public void SetMovingPosition(Vector3 emitterPosition)
        {
            if (emitterPosition != sourcePosition)
            {
                sourcePosition = emitterPosition;

                AL.Source(audioSource, ALSourceb.Looping, true);

                AL.Source(audioSource, ALSource3f.Position, ref sourcePosition);

                // AL.SourcePlay(audioSource); // play the audio source
            }

            if (notPlayed == true)
            {
                AL.SourcePlay(audioSource);
                notPlayed = false;
            }

        }
        
        public void UpdatePosition(Vector3 singlePos)
        {
            if (singlePos != sourcePosition)
            {
                sourcePosition = singlePos;
            }
        }

        public void Playonce()
        {
            AL.Source(audioSource, ALSourceb.Looping, false); // source loops infinitely NO
            AL.Source(audioSource, ALSource3f.Position, ref sourcePosition);
            AL.SourcePlay(audioSource);
        }

        public void PlayDeath()
        {
            audioDeath = ResourceManager.LoadAudio(audiosourcedeath);
            DeathSource = AL.GenSource();
            AL.Source(DeathSource, ALSourcei.Buffer, audioDeath);
            AL.Source(DeathSource, ALSourceb.Looping, false); // source loops infinitely NO
            AL.Source(DeathSource, ALSource3f.Position, ref sourcePosition);
            AL.SourcePlay(DeathSource);
        }


        public int Audio 
        {
            get { return audio; }
        }

        public void Close()
        {
            //Stop Sound
            AL.SourceStop(audioSource);

            AL.DeleteSource(audioSource);
        }

        public ComponentTypes ComponentType
        {
            get { return ComponentTypes.COMPONENT_AUDIO; }
        }
    }
}
