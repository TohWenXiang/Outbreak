using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Outbreak;

public class CharacterSpawner : MonoBehaviour
{
    

    private static CharacterSpawner instance = null;

    private void Awake()
    {
        if (instance != null)
        {
            if (instance != this)
            {
                Destroy(gameObject);
                Debug.LogError("There must be only one player spawn in the game");
            }
        }
        else
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        CharacterManager.Instance.CreateCharacter(transform.position - (Vector3.up * 1.5f));
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
