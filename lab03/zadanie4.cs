using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class zadanie4 : MonoBehaviour
{
    List<Vector3> positions = new List<Vector3>();
    public float delay = 3.0f;
    int objectCounter = 0;
    // obiekt do generowania
    public GameObject block;

    //GameObject pomoc;
    //public Material[] myMaterial;


    void Start()
    {
        ////pobieramy wielkosc platformy
        float xend = gameObject.GetComponent<Renderer>().bounds.size.x - 1;//Renderer; Collider
        float zend = gameObject.GetComponent<Renderer>().bounds.size.z - 1;
        int xEnd = (int)xend;
        int zEnd = (int)zend;
        ////pobieramy 'poczatek' platformy
        float xstart = gameObject.transform.position.x;
        float ystart = gameObject.transform.position.y;
        float zstart = gameObject.transform.position.z + 1;
        int xStart = (int)xstart;
        int yStart = (int)ystart;
        int zStart = (int)zstart;


        // w momecie uruchomienia generuje 10 kostek w losowych miejscach
        List<int> pozycje_x = new List<int>(Enumerable.Range(xStart, xEnd).OrderBy(x => Guid.NewGuid()).Take(10));
        List<int> pozycje_z = new List<int>(Enumerable.Range(zStart, zEnd).OrderBy(x => Guid.NewGuid()).Take(10));

        for (int i = 0; i < 10; i++)
        {
            this.positions.Add(new Vector3(pozycje_x[i], yStart, pozycje_z[i]));
        }
        foreach (Vector3 elem in positions)
        {
            Debug.Log(elem);
        }
        // uruchamiamy coroutine
        StartCoroutine(GenerujObiekt());

    }

    void Update()
    {

    }

    IEnumerator GenerujObiekt()
    {
        Debug.Log("wywołano coroutine");
        foreach (Vector3 pos in positions)
        {
            Instantiate(this.block, this.positions.ElementAt(this.objectCounter++), Quaternion.identity);
            //pomoc = Instantiate(this.block, this.positions.ElementAt(this.objectCounter++), Quaternion.identity);
            //int material = UnityEngine.Random.Range(0, myMaterial.Length);
            //pomoc.GetComponent<MeshRenderer>().material = myMaterial[material];

            yield return new WaitForSeconds(this.delay);
        }
        // zatrzymujemy coroutine
        StopCoroutine(GenerujObiekt());
    }

}
