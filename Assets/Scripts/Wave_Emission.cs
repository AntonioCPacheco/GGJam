using UnityEngine;
using System.Collections;

public class Wave_Emission : MonoBehaviour {

    public GameObject wavePrefab;
    public int mode = 0; //0 - periodic | 1 - one time
    public int period = 10;
    float lastTime;

	// Use this for initialization
	void Start () {
        lastTime = -period;

    }

    // Update is called once per frame
    void Update() {
        switch (mode) {
            case (0):
                if (Time.realtimeSinceStartup >= lastTime + period)
                {
                    EmitWave(mode);
                    lastTime = lastTime = Time.realtimeSinceStartup;
                }
                break;
            case (1):
                if (GetComponent<InputManager>().Left_Mouse_Click() != new Vector3(-1,-1,-1) && Time.realtimeSinceStartup >= lastTime + period)
                {
                    EmitWave(mode);
                    lastTime = lastTime = Time.realtimeSinceStartup;
                }
                break;
        }
	}

    void EmitWave(int mode)
    {
        GameObject go = (GameObject)Instantiate(wavePrefab, transform);
        go.GetComponent<Wave_Behaviour>().mode = mode;
        go.transform.parent = null;
        switch (mode) {
            case (1):
                go.transform.position = transform.position;
                go.GetComponent<Wave_Behaviour>().direction = Camera.main.ScreenToWorldPoint(GetComponent<InputManager>().Left_Mouse_Click());
                break;
        }
    }
}
