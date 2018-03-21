using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

    public Transform[] puntos;
    //public float t;
    // Use this for initialization
	void Start () {
        StartCoroutine(Mover());		
	}
	
	// Update is called once per frame
	void Update () {
        //var pos = PosicionEnCurva(0, t);
        //transform.position = new Vector3(pos.x, pos.y, 0f);
    }

    IEnumerator Mover()
    {
        float t = 0f;
        while(t<1f)
        {
            t += Time.deltaTime;
            var pos = PosicionEnCurva(0, t);
            transform.position = new Vector3(pos.x,pos.y,0f);
            yield return null;
        }
    }

    Vector2 PosicionEnCurva(int i,float t)
    {
        var p0 = puntos[i*4].position;
        var p1 = puntos[i*4+1].position;
        var p2 = puntos[i*4+2].position;
        var p3 = puntos[i*4+3].position;
        var x = Bezier(p0.x, p1.x, p2.x, p3.x, t);
        var y = Bezier(p0.y, p1.y, p2.y, p3.y, t);
        return new Vector2(x,y);
    }

    //float bezier(float p0, float p1, float p2, float p3, float t)
    //{
    //    return p0 * Mathf.Pow(1 - t, 3) + p1 * t * Mathf.Pow(1 - t, 2) + p2 * Mathf.Pow(t, 2) * (1 - t) + p3 * Mathf.Pow(t, 3);
    //}

    float Bezier(float a, float b, float c, float d, float t)
    {
        float bezier =
            a * Mathf.Pow((1f - t), 3f) +
            3f * b * t * Mathf.Pow(1f - t, 2f) +
            3f * c * Mathf.Pow(t, 2f) * (1f - t) +
            d * Mathf.Pow(t, 3f);
        return bezier;
    }

}
