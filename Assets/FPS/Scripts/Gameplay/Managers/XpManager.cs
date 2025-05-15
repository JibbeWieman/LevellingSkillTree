using System.Collections;
using System.Collections.Generic;
using Unity.FPS.Game;
using UnityEngine;
// Iteration showcase, Skill Points method?
public class XpManager : Manager
{
    public int PlayerLevel { get; private set; }  // Player's current level
    public int PlayerXP { get; private set; }     // Player's current XP
    public int PrevThreshold { get; private set; }  // XP needed to level up
    public int CurThreshold { get; private set; }  // XP needed to level up

    public override void Start()
    {
        base.Start();

        EventManager.AddListener<XpUpdateEvent>(UpdateXP);
        //EventManager.AddListener<LevelUpEvent>(LevelUp);

        PlayerLevel = 1;    // Start at level 1
        PlayerXP = 0;       // Start with 0 XP
        PrevThreshold = 0;
        //CurThreshold = 100;
        CalculateXPThreshold();  // Initialize XP threshold for level-up
    }

    /// <summary>
    /// Update player XP
    /// </summary>
    /// <param name="xpAmount"></param>
    //public void UpdateXP(int xpAmount)
    public void UpdateXP(XpUpdateEvent evt)
    {
        PlayerXP = evt.XP;  // Add XP to player's total

        // Check if the player has enough XP to level up
        if (PlayerXP >= CurThreshold)
        {
            //LevelUp(evt);  // Handle level-up logic
            LevelUpEvent lvlUpEvt = Events.LevelUpEvent;
            //EventManager.Broadcast(levelUpEvent);
            LevelUp(lvlUpEvt);
        }
    }

    // Handles level-up logic
    private void LevelUp(LevelUpEvent evt)
    {
        //m_PlayerLevel++; // Increment the player level
        evt.Level++;
        //evt.SkillPoints++;
        //m_PlayerXP = m_PlayerXP - m_LevelThreshold;  // Carry over excess XP
        //evt.XP -= m_LevelThreshold;  // Carry over excess XP

        PlayerLevel = evt.Level;

        SkillPointsChangedEvent skillPointEvent = Events.SkillPointsChangedEvent;
        skillPointEvent.SkillPoints++;
        //EventManager.Broadcast(skillPointEvent);

        CalculateXPThreshold();  // Recalculate XP needed for the next level

        // Notify the StatManager about the level-up
        //StatManager statManager = GetComponent<StatManager>();
        //if (statManager != null)
        //{
            //statManager.IncreasePoints(1);  // Award stat points upon level-up
        //}


        // Optionally, trigger any level-up feedback or UI updates here
    }

    // Calculate the XP threshold for the next level
    private void CalculateXPThreshold()
    {
        PrevThreshold = CurThreshold;
        CurThreshold = PlayerLevel * 150;
    }

    /* public override void Pause()
    {
        throw new System.NotImplementedException();
    } */

    //Event Manager Iteration 
    void OnDestroy()
    {
        EventManager.RemoveListener<XpUpdateEvent>(UpdateXP);
        //EventManager.RemoveListener<LevelUpEvent>(LevelUp);

        //PlayerLevel = 1;
        //PlayerXP = 0;
        //PrevThreshold_ = 0;
        //Events.SkillPointsChangedEvent.SkillPoints = 0;
    }
}
