using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentUtil : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static T GetComponentOfObject<T>(string objectName)
    {
        GameObject go = GameObject.Find(objectName);

        return go.GetComponent<T>();
    }
}
