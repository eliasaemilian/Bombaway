using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Affectable : MonoBehaviour, IAffectable
{
    public void OnActivate()
    {
        Debug.Log( "Affectable got activated" );
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
