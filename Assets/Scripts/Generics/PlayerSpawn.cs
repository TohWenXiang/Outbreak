using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Outbreak;

public class PlayerSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        CharacterManager.Instance.CreateCharacter(transform.position + (Vector3.up));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
