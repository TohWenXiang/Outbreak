using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Outbreak
{
    [RequireComponent(typeof(Character), typeof(CharacterController))]
    public class CharacterInput : MonoBehaviour
    {
        //passing it the calculated input
        CharacterController playerController;
        //accessing player stats
        Stats playerStats;
        //ray casting
        Camera playerView;

        private void Awake()
        {
            playerController = GetComponent<CharacterController>();
            playerView = Camera.main;
        }

        void Start()
        {
            playerStats = GetComponent<Character>().Stats;
        }

        void Update()
        {
            //input is done here to ensure no input lag
            MovementInput();
            LookInput();
        }

        void MovementInput()
        {
            /*
             *      gather input here as a vector,
             *      normalize it into a direction vector with a magnitude of one,
             *      then calculate the velocity by multiplying input direction with the moving speed(magnitude)
             *      and pass movement velocity to controller so that it can move the player
             */
            playerController.MovementVelocity = new Vector3(
                Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")
                ).normalized * playerStats.MovementSpeed;
        }

        void LookInput()
        {
            //create a ray from the camera that goes through the mouse position to infinity
            Ray ray = playerView.ScreenPointToRay(Input.mousePosition);

            //create a plane for plane to intersect with
            Plane ground = new Plane(Vector3.up, Vector3.zero);

            //stores ray distance when ray intersects the plane
            float rayDist;


            //check if ray intersects with ground
            if (ground.Raycast(ray, out rayDist))
            {
                //get point of intersection using ray distance
                Vector3 intersectPoint = ray.GetPoint(rayDist);
                //Debug.DrawLine(ray.origin, intersectPoint, Color.red);
                playerController.LookAtPoint(intersectPoint);
            }
        }
    }
}