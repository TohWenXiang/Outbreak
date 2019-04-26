using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Outbreak
{
    [System.Serializable]
    public class Stats
    {
        [SerializeField]
        private float health;
        [SerializeField]
        private float movementSpeed;
        [SerializeField]
        private bool isDead;

        public Stats()
        {
            health = 3.0f;
            movementSpeed = 5.0f;
            isDead = false;
        }

        public Stats(Stats stats)
        {
            health = stats.health;
            movementSpeed = stats.movementSpeed;
            isDead = stats.isDead;
        }

        public float Health
        {
            set
            {
                health = value;
            }
            get
            {
                return health;
            }
        }

        public float MovementSpeed
        {
            set
            {
                movementSpeed = value;
            }
            get
            {
                return movementSpeed;
            }
        }

        public bool IsDead
        {
            set
            {
                isDead = value;
            }
            get
            {
                return isDead;
            }
        }
    }
}