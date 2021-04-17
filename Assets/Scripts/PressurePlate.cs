using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    [SerializeField] float affectableRadius;

    // Start is called before the first frame update
    void Start()
    {
        // when pressed, activates affectables in radius
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D( Collision2D collision )
    {
        if ( !collision.gameObject.CompareTag( "Effectable" ) ) return;


        var affectables = GameObject.FindGameObjectsWithTag( "Affectable" );

        foreach ( var af in affectables )
        {
            var affectable = af.GetComponent<IAffectable>();

            if ( affectable == null )
            {
                continue;
            }

            var dist = Vector3.Distance( transform.position, af.transform.position );

            if ( dist <= affectableRadius )
            {
                affectable.OnActivate();
            }
        }
    }
}
