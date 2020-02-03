using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SourceManager : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject sourcePrefab;
    public int numsOfObject;
    public float radius;
    public float playInterval;

    private GameObject[] objects;
    private int obj_index;
    private float countInterval;

    private void Awake()
    {
        Vector3 basePosition = mainCamera.transform.position;
        objects = new GameObject[numsOfObject];
        for (int i=0; i<numsOfObject; i++)
        {
            GameObject gobj = Instantiate(sourcePrefab);
            float radian = 2.0f * Mathf.PI / (float)numsOfObject * (float)i;
            gobj.transform.position = new Vector3(basePosition.x + radius * Mathf.Cos(radian),  basePosition.y, basePosition.z + radius * Mathf.Sin(radian));
            objects[i] = gobj;
        }
        obj_index = 0;
        countInterval = 0.0f;
    }

    // Start is called before the first frame update
    void Start()
    {
        PlaySound();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        countInterval += Time.deltaTime;
        if(countInterval >= playInterval)
        {
            PlaySound();
            countInterval = 0.0f;
        }
    }

    void PlaySound()
    {
        objects[obj_index].GetComponent<TestSoundPlayer>().PlaySound();
        obj_index = (obj_index + 1) % numsOfObject;
    }
}
