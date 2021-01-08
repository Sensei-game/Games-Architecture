﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenGL_Game.Components;
using OpenGL_Game.Objects;
using OpenTK;
using OpenTK.Audio.OpenAL;

namespace OpenGL_Game.Systems
{
    class SystemAudio:ISystem
    {
        const ComponentTypes MASK = (ComponentTypes.COMPONENT_POSITION | ComponentTypes.COMPONENT_AUDIO);
              
        public string Name
        {
            get { return "SystemAudio"; }
        }

        public void OnAction(Entity entity)
        {
            if ((entity.Mask & MASK) == MASK)
            {
                List<IComponent> components = entity.Components;

                IComponent audioComponent = components.Find(delegate (IComponent component)
                {
                    return component.ComponentType == ComponentTypes.COMPONENT_AUDIO;
                });
                 int audio = ((ComponentAudio)audioComponent).Audio;

                IComponent positionComponent = components.Find(delegate (IComponent component)
                {
                    return component.ComponentType == ComponentTypes.COMPONENT_POSITION;
                });
                Vector3 position = ((ComponentPosition)positionComponent).Position;

                ComponentAudio Audio_Component = (ComponentAudio)audioComponent;

                //((ComponentAudio)audioComponent).SetPosition(position);

                PlayPosition(entity ,position, Audio_Component);
            }
        }

        private void PlayPosition(Entity entity, Vector3 pos, ComponentAudio audio)
        {
            if (entity.Name == "Wraith_Raider_Starship")
            {
                audio.SetMovingPosition(pos);
            }
            else
            {
                audio.PlaySound(pos);
            }


            //if(entity.Name == "Wraith_Raider_Starship")
            //{
            //    audio.PlayLoopingSound();
            //}

            //AL.SourcePause(audio.audioSource);    

            //audio.PlaySound();
        }

       
    }
}
