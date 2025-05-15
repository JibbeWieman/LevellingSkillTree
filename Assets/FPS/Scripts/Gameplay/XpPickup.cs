using Unity.FPS.Game;
using UnityEngine;

namespace Unity.FPS.Gameplay
{
    public class XpPickup : Pickup
    {
        [Header("Parameters")]
        [Tooltip("Amount of experience to grant on pickup"), Range(1, 20)]
        public int xpAmount = 1;

        [SerializeField]
        private SceneTypeObject ST_Player;

        [SerializeField]
        private float checkArea = 5f; // Radius of the area within which the object starts moving towards the player

        [SerializeField]
        private float pullSpeed = 2f; // Base speed at which the object moves towards the player

        //[SerializeField]
        //private SceneTypeObject ST_GameManager;

        private GameObject player;
        private bool isPlayerInCheckArea = false;

        protected override void Start()
        {
            base.Start();
            player = ST_Player.Objects[0];

            ScaleXpOrb();
        }

        private void ScaleXpOrb()
        {
            // Scale factor to control size growth based on XP amount
            float scaleFactor = 1f + (xpAmount - 1) * 0.01f;
            transform.localScale = new Vector3(scaleFactor, scaleFactor, scaleFactor);
        }


        private void Update()
        {
            // Check if the player is within the defined check area
            float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

            if (distanceToPlayer <= checkArea)
            {
                isPlayerInCheckArea = true;
            }
            else
            {
                isPlayerInCheckArea = false;
            }

            // If the player is in the check area, move towards the player
            if (isPlayerInCheckArea)
            {
                MoveTowardsPlayer(distanceToPlayer);
            }
        }

        protected override void OnPicked(PlayerCharacterController player)
        {
            //XpManager xpManager = ST_GameManager.Objects[0].GetComponent<XpManager>();
            //if (xpManager != null)
            //{
                // OLD CODE: xpManager.UpdateXP(XpAmount); // Grant the player XP
                
            XpUpdateEvent evt = Events.XpUpdateEvent;
            evt.XP += xpAmount;

            //broadcast xpevent
            //EventManager.Broadcast(evt);

            PlayPickupFeedback(); // Play any pickup feedback such as sound or VFX
            Destroy(gameObject); // Destroy the XP pickup after it has been collected
            //}
        }

        private void MoveTowardsPlayer(float distanceToPlayer)
        {
            // Calculate the pull strength based on the player's distance to the object
            float pullStrength = Mathf.Lerp(0, pullSpeed, 1 - (distanceToPlayer / checkArea));

            // Move the object towards the player
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, pullStrength * Time.deltaTime);
        }

        // Draw the check area radius using Gizmos
        private void OnDrawGizmosSelected()
        {
            // Set the color of the gizmos (yellow for visibility)
            Gizmos.color = Color.yellow;

            // Draw a wireframe sphere at the object's position with the defined checkArea radius
            Gizmos.DrawWireSphere(transform.position, checkArea);
        }
    }
}