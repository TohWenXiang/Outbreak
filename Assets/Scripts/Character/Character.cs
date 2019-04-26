using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Outbreak
{
    [RequireComponent(typeof(CharacterController), typeof(CharacterInput))]
    public class Character : LivingEntity
    {

        protected override void Awake()
        {
            base.Awake();

        }
        // Start is called before the first frame update
        protected override void Start()
        {
            base.Start();
        }

        // Update is called once per frame
        protected override void Update()
        {
            base.Update();
        }

        protected override void Die()
        {
            base.Die();
            gameObject.GetComponent<CharacterInput>().enabled = false;
            gameObject.GetComponent<CharacterController>().enabled = false;
            StartCoroutine(DelayedRevival());
        }

        protected override void Revive()
        {
            base.Revive();
            gameObject.GetComponent<CharacterInput>().enabled = true;
            gameObject.GetComponent<CharacterController>().enabled = true;
        }
    }
}