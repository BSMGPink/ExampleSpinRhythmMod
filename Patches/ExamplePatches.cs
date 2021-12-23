using HarmonyLib;
using SMU.Reflection;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using BepInEx;
using BepInEx.Logging;
using System.Reflection;
using TMPro;
using UnityEngine.UI;
using ExampleMod;

namespace ExampleMod
{
    public static class ExamplePatches
    {


        [HarmonyPatch(typeof(GameStateManager), "ApplyStartupSettings")]
        [HarmonyPostfix]
        private static void ChangeState_Postfix(GameStateManager __instance)
        {
            //Postfix occurs *After* the method has ran
            //If a given method is private, we use a string instead of nameof
            Plugin.LogInfo("Game started!");
        }




        [HarmonyPatch(typeof(PlayState), nameof(PlayState.SubtractHealth))]
        [HarmonyPrefix]
        private static void ChangeState_Prefix(PlayState __instance, int amount)
        {
            //Prefix occurs *Before* the method has ran
            Plugin.LogInfo("Health Lost: " + amount.ToString());
        }



    }
}
