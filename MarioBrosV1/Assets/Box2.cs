using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box2 : MonoBehaviour {

    public AnimationCurve curve;
    void OnCollisionEnter2D(Collision2D coll)
    {
        // collision below?
        if (coll.contacts[0].point.y < transform.position.y)
        {
            // Do stuff...
        }
    }
    IEnumerator sample()
    {
        // start position
        Vector2 pos = transform.position;

        // go through curve time
        for (float t = 0; t < curve.keys[curve.length - 1].time; t += Time.deltaTime)
        {
            // move a bit
            transform.position = new Vector2(pos.x, pos.y + curve.Evaluate(t));

            // come back next Update
            yield return null;
        }
    }
}
