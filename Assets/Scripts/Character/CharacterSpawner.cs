using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Outbreak;

public class CharacterSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        CharacterManager.Instance.CreateCharacter(transform.position - (Vector3.up * 1.5f));
        transform.GetChild(1).parent = transform.parent;
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
