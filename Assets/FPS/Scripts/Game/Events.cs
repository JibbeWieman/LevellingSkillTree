using UnityEngine;

namespace Unity.FPS.Game
{
    // The Game Events used across the Game.
    // Anytime there is a need for a new event, it should be added here.

    public static class Events
    {
        public static ObjectiveUpdateEvent ObjectiveUpdateEvent = new ObjectiveUpdateEvent();
        public static AllObjectivesCompletedEvent AllObjectivesCompletedEvent = new AllObjectivesCompletedEvent();
        public static GameOverEvent GameOverEvent = new GameOverEvent();
        public static PlayerDeathEvent PlayerDeathEvent = new PlayerDeathEvent();
        public static EnemyKillEvent EnemyKillEvent = new EnemyKillEvent();
        public static PickupEvent PickupEvent = new PickupEvent();
        public static AmmoPickupEvent AmmoPickupEvent = new AmmoPickupEvent();
        public static DamageEvent DamageEvent = new DamageEvent();
        public static DisplayMessageEvent DisplayMessageEvent = new DisplayMessageEvent();

        // Jibbe's Events
        public static XpUpdateEvent XpUpdateEvent = new();
        public static LevelUpEvent LevelUpEvent = new();
        public static SkillPointsChangedEvent SkillPointsChangedEvent = new();
        public static SkillUnlockedEvent SkillUnlockedEvent = new();
        public static PlayerEvent PlayerEvent = new();
        public static BlasterDMGIncreasedEvent BlasterDMGIncreasedEvent = new();
        public static HPIncreasedEvent HPIncreasedEvent = new();
        public static SpeedIncreasedEvent SpeedIncreasedEvent = new();
        public static SkillTreeUIClosedEvent SkillTreeUIClosedEvent = new();
    }


    // Jibbe's Events
    public class PlayerEvent : GameEvent
    {
        public GameObject player;
    }

    public class BlasterDMGIncreasedEvent : GameEvent
    {
        private int dmgBuff; // Backing field

        public int DMGBuff
        {
            get { return dmgBuff; }
            set
            {
                dmgBuff = value;
                EventManager.Broadcast(Events.BlasterDMGIncreasedEvent);
            }
        }
    }

    public class HPIncreasedEvent : GameEvent
    {
        private int hpBuff; // Backing field

        public int HPBuff
        {
            get { return hpBuff; }
            set
            {
                hpBuff = value;
                EventManager.Broadcast(Events.HPIncreasedEvent);
            }
        }
    }

    public class SpeedIncreasedEvent : GameEvent
    {
        private int speedBuff; // Backing field

        public int SpeedBuff
        {
            get { return speedBuff; }
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
}
