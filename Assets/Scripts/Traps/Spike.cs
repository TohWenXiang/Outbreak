﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Outbreak
{
    public class Spike : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                collision.gameObject.GetComponent<Character>().TakeDamage(100);
            }
        }
    }
}
