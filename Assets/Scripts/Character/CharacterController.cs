using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Outbreak
{
    [RequireComponent(typeof(Rigidbody))]
    public class CharacterController : MonoBehaviour
    {
        private Vector3 movementVelocity;
        public Vector3 MovementVelocity
        {
            set
            {
                movementVelocity = value;
            }
        }

        private Rigidbody playerRB;

        void Awake()
        {
            playerRB = GetComponent<Rigidbody>();
            movementVelocity = Vector3.zero;
        }

        void FixedUpdate()
        {
            playerRB.MovePosition(playerRB.position + (movementVelocity * Time.fixedDeltaTime));
        }

        public void LookAtPoint(Vector3 point)
        {
            //make it look at the same height as player
            Vector3 correctedLookAtPoint = new Vector3(point.x, transform.position.y, point.z);

            transform.LookAt(correctedLookAtPoint);

            Debug.DrawLine(transform.position, transform.position + (transform.forward * 2), Color.red);
        }
    }
}