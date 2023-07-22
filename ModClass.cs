using Modding;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UObject = UnityEngine.Object;

namespace ShyKnight
{
    public class ShyKnight : Mod
    {
        internal static ShyKnight Instance;

        public override string GetVersion() => "v1.3.0.0";

        public ShyKnight() : base("ShyKnight")
        {
            Instance = this;
        }

        public override void Initialize(Dictionary<string, Dictionary<string, GameObject>> preloadedObjects)
        {
            Instance = this;
            On.GameManager.OnNextLevelReady += OnSceneLoad;
        }

        public void OnSceneLoad(On.GameManager.orig_OnNextLevelReady orig, global::GameManager self)
        {
            orig(self);
            RemoveAudience();
        }

        private void RemoveAudience()
        {
            // GODHOME

            // Check if the current scene contains godhome audience
            GameObject arena_prefab = GameObject.Find("GG_Arena_Prefab");
            if (arena_prefab != null)
            {
                // Remove the audience
                GameObject crowd = GameObject.Find("Crowd");
                if (crowd != null)
                {
                    crowd.SetActive(false);
                }
                // Remove audience Godseeker
                GameObject gs_crowd = GameObject.Find("Godseeker Crowd");
                if (gs_crowd != null)
                {
                    gs_crowd.SetActive(false);
                }
            }

            // COLISSEUM

            // Check if you're in colisseum
            GameObject colosseum_manager = GameObject.Find("Colosseum Manager");
            if (colosseum_manager != null)
            {
                // Remove the audience
                // Overcomplicated way to get all objects with "Colosseum Crowd NPC in their name
                tk2dSpriteAnimator[] crowd_npcs = GameObject.FindObjectsOfType<tk2dSpriteAnimator>();
                for(int i=0; i<crowd_npcs.Length; i++)
                {
                    tk2dSpriteAnimator comp = crowd_npcs[i];
                    GameObject obj = comp.gameObject;        

                    if (obj.name.Contains("Colosseum Crowd NPC"))
                    {
                        obj.SetActive(false);
                    }
                }

                // Remove the audience audio
                GameObject crowd_audio = GameObject.Find("Crowd Audio");
                if (crowd_audio != null)
                {
                    crowd_audio.SetActive(false);
                }
            }
        }
    }
}