using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Outbreak;

public class CharacterGroup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //If there is a child in my manager class
        if (transform.childCount > 0)
        {
            //assign all to list
            for (int i = 0; i < transform.childCount; i++)
            {
                Debug.Log(transform.GetChild(0));
                CharacterManager.Instance.AddCharacter(transform.GetChild(i).GetComponent<Character>());
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
