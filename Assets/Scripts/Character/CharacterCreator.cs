using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Outbreak
{
    public class CharacterCreator : MonoBehaviour
    {
        public Character characterPrefab;

        // Start is called before the first frame update
        void Start()
        {
            CreateCharacter(transform.position + Vector3.up * 1.5f);
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void CreateCharacter(Vector3 position)
        {
            Character newCharacter;

            newCharacter = Instantiate(characterPrefab, position, Quaternion.identity, transform);

            newCharacter.name = newCharacter.name.Substring(0, newCharacter.name.Length - 7);
        }
    } 
}
