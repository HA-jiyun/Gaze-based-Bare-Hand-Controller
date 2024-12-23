using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ExperimentSetup : MonoBehaviour
{
    public GameObject objectSphere;

    // Start is called before the first frame update
    void Start()
    {
        /*
        var sr = new StreamReader("Assets/PoissonSampling/test3.txt");
        string line;
        while ((line = sr.ReadLine()) != null)
        {
            break;
        }
        */

        PoissonDiskSampling sampler = new PoissonDiskSampling(20, 20, 20, 3);

        foreach (Vector3 sample in sampler.Samples())
        {
            // ... do something, like instantiate an object at (sample.x, sample.y, sample.z) for example:
            Instantiate(objectSphere, this.transform);
            objectSphere.transform.localPosition = new Vector3(sample.x, sample.y, sample.z);
            

            /*
            string poissonSave = "Assets/PoissonSampling/test3.txt";
            if (!File.Exists(poissonSave))
            {
                var file = File.Create(poissonSave);
                file.Close();
            }
            
            StreamWriter sw = new(poissonSave, true);
            sw.WriteLine(objectSphere.transform.localPosition);
            sw.Close();
            */
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
