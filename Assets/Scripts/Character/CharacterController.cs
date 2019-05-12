using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Outbreak
{
    [RequireComponent(typeof(Rigidbody), typeof(CharacterInput))]
    public class CharacterController : MonoBehaviour
    {
        Rigidbody characterRB;
        Stats characterStats;
        CharacterInput characterInput;

        void Awake()
        {
            characterRB = GetComponent<Rigidbody>();
            characterInput = GetComponent<CharacterInput>();
        }

        private void Start()
        {
            characterStats = GetComponent<Character>().Stats;
        }

        private void Update()
        {
            LookAt();
        }

        void FixedUpdate()
        {
            Movement();
        }
        
        void Movement()
        {
            Vector3 movementVelocity;
            movementVelocity = characterInput.InputDir * characterStats.MovementSpeed;

            Vector3 displacement;
            displacement = movementVelocity * Time.fixedDeltaTime;

            Vector3 newPosition;
            newPosition = characterRB.position + displacement;

            characterRB.MovePosition(newPosition);
        }

        public void LookAt()
        {
            //make it look at the same height as player
            Vector3 correctedLookAtPoint = new Vector3(characterInput.LookAtPoint.x, transform.position.y, characterInput.LookAtPoint.z);

            transform.LookAt(correctedLookAtPoint);

            Debug.DrawLine(transform.position, transform.position + (transform.forward * 2), Color.red);
        }
    }
}