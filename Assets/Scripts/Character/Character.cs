using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Outbreak
{
    [RequireComponent(typeof(CharacterController), typeof(CharacterInput))]
    public class Character : LivingEntity
    {
        CharacterController theCharacterController;
        CharacterInput theCharacterInput;

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
        }
    }
}