using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Outbreak
{
    [RequireComponent(typeof(CharacterController), typeof(CharacterInput))]
    public class Character : LivingEntity
    {
        private CharacterController theCharacterController;
        private CharacterInput theCharacterInput;

        private Vector3 respawnLocation;

        protected override void Awake()
        {
            base.Awake();
            theCharacterInput = GetComponent<CharacterInput>();
            theCharacterController = GetComponent<CharacterController>();
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

            theCharacterInput.enabled = false;
            theCharacterController.enabled = false;

            StartCoroutine(DelayedRevival());
        }

        protected override void Revive()
        {
            base.Revive();

            theCharacterInput.enabled = true;
            theCharacterController.enabled = true;

            transform.position = respawnLocation;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Spawn Point")
            {
                respawnLocation = other.transform.position + (Vector3.up * 0.5f);
            }
        }
    }
}