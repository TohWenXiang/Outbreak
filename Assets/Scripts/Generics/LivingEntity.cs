using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *      things to do:
 *      1. respawn point
 *      2. fix this strange bug
 */
namespace Outbreak
{
    public class LivingEntity : MonoBehaviour, IDamageable
    {
        public Stats defaultStats;
        public event System.Action OnDeath;

        MeshRenderer theMeshRenderer;
        CapsuleCollider theCapsuleCollider;
        Rigidbody theRigidbody;

        protected Stats stats;
        public Stats Stats
        {
            get
            {
                return stats;
            }
        }

        protected virtual void Awake()
        {
            stats = new Stats(defaultStats);
            theMeshRenderer = GetComponent<MeshRenderer>();
            theCapsuleCollider = GetComponent<CapsuleCollider>();
            theRigidbody = GetComponent<Rigidbody>();
        }

        // Start is called before the first frame update
        protected virtual void Start()
        {

        }

        // Update is called once per frame
        protected virtual void Update()
        {

        }

        public void TakeDamage(float damage)
        {
            //if not dead
            if (stats.IsDead == false)
            {
                //and it still has health left
                if (stats.Health > 0)
                {
                    //take damage
                    stats.Health -= damage; 
                }
                //after taking damage check if health is depleted.
                if (stats.Health <= 0)
                {
                    //pronouce it dead
                    Die();
                }
            }  
        }

        protected virtual void Die()
        {
            //set its status to dead
            stats.IsDead = true;

            //broadcast to all listener that this player is dead
            if (OnDeath != null)
            {
                OnDeath();
            }

            //make player invisible
            theMeshRenderer.enabled = false;
            //prevent any collision
            theCapsuleCollider.enabled = false;
            //prevent player detecting collision
            theRigidbody.detectCollisions = false;
            //set to kinematic
            theRigidbody.isKinematic = true;
        }

        protected IEnumerator DelayedRevival()
        {
            yield return new WaitForSeconds(3.0f);
            Revive();
            yield return null;
        }

        protected virtual void Revive()
        {
            //reset to default stats
            stats = new Stats(defaultStats);

            //make player visible
            theMeshRenderer.enabled = true;
            //allow any collision
            theCapsuleCollider.enabled = true;
            //allow player to detect collision
            theRigidbody.detectCollisions = true;
            //set to dynamic
            theRigidbody.isKinematic = false;
        }
    }
}