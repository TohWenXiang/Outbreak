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
            Debug.Log(defaultStats.IsDead);

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
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            //prevent any collision
            gameObject.GetComponent<CapsuleCollider>().enabled = false;
            //prevent player detecting collision
            gameObject.GetComponent<Rigidbody>().detectCollisions = false;
            //set to kinematic
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
        }

        protected IEnumerator DelayedRevival()
        {
            yield return new WaitForSeconds(3.0f);
            Revive();
            yield return null;
        }

        protected virtual void Revive()
        {
            //2.  reset to default stats
            stats = new Stats(defaultStats);
            //stats.IsDead = false;
            //stats.Health = 3;
            //stats.MovementSpeed = 10;
            //stats = defaultStats;

            //1. set position to last respawn point location
            transform.position = Vector3.zero + (Vector3.up * 1.5f);

            //make player visible
            gameObject.GetComponent<MeshRenderer>().enabled = true;
            //allow for collision
            gameObject.GetComponent<CapsuleCollider>().enabled = true;
            //allow player to detect collision
            gameObject.GetComponent<Rigidbody>().detectCollisions = true;
            //set to dynamic
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
        }
    }
}