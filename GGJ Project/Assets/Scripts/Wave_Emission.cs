using UnityEngine;
using System.Collections;

public class Wave_Emission : MonoBehaviour {

    public GameObject wavePrefab;
    public int mode = 0; //0 - periodic | 1 - one time
    public int period = 10;
    float lastTime = 0;

	// Use this for initialization
	void Start () {
        lastTime = Time.realtimeSinceStartup;

    }

    // Update is called once per frame
    void Update() {
        switch (mode) {
            case (0):
                if (Time.realtimeSinceStartup >= lastTime + period)
                {
                    EmitWave();
                    lastTime = lastTime = Time.realtimeSinceStartup;
                }
                break;
        }
	}

    void EmitWave()
    {
        Instantiate(wavePrefab, transform);
    }
}
