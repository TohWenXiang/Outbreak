using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Outbreak;

public class CharacterManager : MonoBehaviour
{
    static CharacterManager instance;
    public static CharacterManager Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject newInstance = new GameObject("Character Manager");
                newInstance.AddComponent<CharacterManager>();
            }

            return instance;
        }
    }

    public Character characterPrefab;

    public static Character theCharacter;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        instance = this;
    }

    public void CreateCharacter(Vector3 position)
    {
        if (theCharacter == null)
        {
            theCharacter = Instantiate(characterPrefab, position, Quaternion.identity, transform);
        }
    }
}
