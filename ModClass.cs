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

        public override string GetVersion() => "v1.2.1";

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
        }
    }
}