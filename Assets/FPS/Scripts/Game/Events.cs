using UnityEngine;

namespace Unity.FPS.Game
{
    // The Game Events used across the Game.
    // Anytime there is a need for a new event, it should be added here.

    public static class Events
    {
        #region Base Events

        public static ObjectiveUpdateEvent ObjectiveUpdateEvent = new();
        public static AllObjectivesCompletedEvent AllObjectivesCompletedEvent = new();
        public static GameOverEvent GameOverEvent = new();
        public static PlayerDeathEvent PlayerDeathEvent = new();
        public static EnemyKillEvent EnemyKillEvent = new();
        public static PickupEvent PickupEvent = new();
        public static AmmoPickupEvent AmmoPickupEvent = new();
        public static DamageEvent DamageEvent = new();
        public static DisplayMessageEvent DisplayMessageEvent = new();

        #endregion

        #region Custom Events (Jibbe)

        public static XpUpdateEvent XpUpdateEvent = new();
        public static LevelUpEvent LevelUpEvent = new();
        public static SkillPointsChangedEvent SkillPointsChangedEvent = new();
        public static SkillUnlockedEvent SkillUnlockedEvent = new();
        public static PlayerEvent PlayerEvent = new();
        public static BlasterDMGIncreasedEvent BlasterDMGIncreasedEvent = new();
        public static HPIncreasedEvent HPIncreasedEvent = new();
        public static SpeedIncreasedEvent SpeedIncreasedEvent = new();
        public static SkillTreeUIClosedEvent SkillTreeUIClosedEvent = new();

        #endregion
    }

    #region Event Classes

    /// <summary>
    /// Event carrying a reference to the Player GameObject.
    /// </summary>
    public class PlayerEvent : GameEvent
    {
        public GameObject player;
    }

    /// <summary>
    /// Event triggered when the blaster damage buff is increased.
    /// </summary>
    public class BlasterDMGIncreasedEvent : GameEvent
    {
        private int dmgBuff;

        /// <summary>
        /// Damage buff amount. Automatically broadcasts event when set.
        /// </summary>
        public int DMGBuff
        {
            get => dmgBuff;
            set
            {
                dmgBuff = value;
                EventManager.Broadcast(Events.BlasterDMGIncreasedEvent);
            }
        }
    }

    /// <summary>
    /// Event triggered when the player's HP is increased.
    /// </summary>
    public class HPIncreasedEvent : GameEvent
    {
        private int hpBuff;

        /// <summary>
        /// HP buff amount. Automatically broadcasts event when set.
        /// </summary>
        public int HPBuff
        {
            get => hpBuff;
            set
            {
                hpBuff = value;
                EventManager.Broadcast(Events.HPIncreasedEvent);
            }
        }
    }

    /// <summary>
    /// Event triggered when the player's speed is increased.
    /// </summary>
    public class SpeedIncreasedEvent : GameEvent
    {
        private int speedBuff;

        /// <summary>
        /// Speed buff amount. Automatically broadcasts event when set.
        /// </summary>
        public int SpeedBuff
        {
            get => speedBuff;
            set
            {
                speedBuff = value;
                EventManager.Broadcast(Events.SpeedIncreasedEvent);
            }
        }
    }

    public class SkillTreeUIClosedEvent : GameEvent
    {
    }

    public class XpUpdateEvent : GameEvent
    {
        private int xp = 0; // Backing field

        public int XP
        {
            get { return xp; }
            set
            {
                xp = value;
                EventManager.Broadcast(Events.XpUpdateEvent);
            }
        }
    }

    public class LevelUpEvent : GameEvent
    {
        private int level = 1; // Backing field

        public int Level
        {
            get { return level; }
            set
            {
                level = value;
                EventManager.Broadcast(Events.LevelUpEvent);
            }
        }
    }

    public class SkillPointsChangedEvent : GameEvent
    {
        private int skillPoints = 0; // Backing field

        public int SkillPoints
        {
            get { return skillPoints; }
            set
            {
                skillPoints = value;
                EventManager.Broadcast(Events.SkillPointsChangedEvent);
            }
        }
    }

    public class SkillUnlockedEvent : GameEvent
    {
        public GameObject node;
        public SkillType skillType;
    }

    // Existing Events
    public class ObjectiveUpdateEvent : GameEvent
    {
        public Objective Objective;
        public string DescriptionText;
        public string CounterText;
        public bool IsComplete;
        public string NotificationText;
    }

    public class AllObjectivesCompletedEvent : GameEvent { }

    public class GameOverEvent : GameEvent
    {
        public bool Win;
    }

    public class PlayerDeathEvent : GameEvent { }

    public class EnemyKillEvent : GameEvent
    {
        public GameObject Enemy;
        public int RemainingEnemyCount;
    }

    public class PickupEvent : GameEvent
    {
        public GameObject Pickup;
    }

    public class AmmoPickupEvent : GameEvent
    {
        public WeaponController Weapon;
    }

    public class DamageEvent : GameEvent
    {
        public GameObject Sender;
        public float DamageValue;
    }

    public class DisplayMessageEvent : GameEvent
    {
        public string Message;
        public float DelayBeforeDisplay;
    }
    #endregion
}
