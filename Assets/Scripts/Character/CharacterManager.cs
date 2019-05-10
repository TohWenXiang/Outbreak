using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Outbreak
{
    /*
     *      List of things to do manage
     *      1. Searching for a character
     *      2. killing a character
     *      3. reviving a character after a set peroid of time.
     *      4. creating character
     *      5. update it to work with multiple types of character
     */
    public class CharacterManager : MonoBehaviour
    {
        //---------------Singleton----------------
        private static CharacterManager instance;
        public static CharacterManager Instance
        {
            get
            {
                if (instance == null)
                {
                    GameObject go = new GameObject("Character Manager");
                    go.AddComponent<CharacterManager>();
                }

                return instance;
            }
        }
        //----------------------------------------

        public Character characterPrefab;
        public Transform characterGroup;

        public List<Character> characters;

        private void Awake()
        {
            DontDestroyOnLoad(this);
            instance = this;
            characters = new List<Character>();
        }

        public void CreateCharacter(Vector3 position)
        {
            Character newCharacter;

            //create a new character and name it
            newCharacter = Instantiate(characterPrefab, position, Quaternion.identity, characterGroup);
            AddCharacter(newCharacter);
        }

        public void AddCharacter(Character newCharacter)
        {
            newCharacter.name = "Character" + characters.Count;
            characters.Add(newCharacter);
        }
    }
}
