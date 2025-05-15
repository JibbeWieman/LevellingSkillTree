//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public struct Buff
//{
//    public string Name;           // Name of the buff (e.g., "Speed Boost", "Health Increase")
//    public float Cost;            // The cost associated with applying this buff (e.g., XP or in-game currency)
//    public Action<PlayerCharacterController> Apply;  // Action that applies the buff to the player
//    public Action<PlayerCharacterController> Remove; // Action that removes the buff from the player

//    // Constructor for the Buff struct
//    public Buff(string name, float cost, Action<PlayerCharacterController> apply, Action<PlayerCharacterController> remove)
//    {
//        Name = name;
//        Cost = cost;
//        Apply = apply;
//        Remove = remove;
//    }
//}

//public class BuffManager
//{
//    private List<Buff> activeBuffs = new List<Buff>();

//    // Apply a buff to the player character
//    public void ApplyBuff(Buff buff, PlayerCharacterController player)
//    {
//        buff.Apply(player);  // Apply the buff effect
//        activeBuffs.Add(buff); // Add the buff to the active list
//        // Deduct cost or any other logic
//        player.XP -= buff.Cost;
//        // Optionally, increase future buff cost here if you want buffs to scale
//    }

//    // Remove a buff from the player character
//    public void RemoveBuff(Buff buff, PlayerCharacterController player)
//    {
//        buff.Remove(player);  // Remove the buff effect
//        activeBuffs.Remove(buff); // Remove it from the active list
//    }
//}