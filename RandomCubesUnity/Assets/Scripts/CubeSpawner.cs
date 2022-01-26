using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    public GameObject cubePrefab; //new Gameobject
    public float scalingFactor = 0.95f; //amount each cube will shrink each frame
    public int numberOfCubes = 0; //Total number of cubes instantiated
    [HideInInspector]
    public List<GameObject> gameObjectList; //list for all the cubes 

    // Start is called before the first frame update
    void Start()
    {
        gameObjectList = new List<GameObject>(); //instates the list
    }

    // Update is called once per frame
    void Update()
    {
        numberOfCubes++; //add to the number of cubes

        GameObject gObj = Instantiate<GameObject>(cubePrefab); //creates cube

        gObj.name = "Cube " +numberOfCubes; //name of cube instance
        Color randColor = new Color(Random.value, Random.value, Random.value); //new color generated
        gObj.GetComponent<Renderer>().material.color = randColor; //assigns color to game object
        gObj.transform.position = Random.insideUnitSphere; //random location inside a sphere radius of 1 out from 0,0,0.
        gameObjectList.Add(gObj); //add to list
        List<GameObject> removeList = new List<GameObject>(); //list to be removed
        foreach (GameObject goTemp in gameObjectList)
        {
            float scale = goTemp.transform.localScale.x; //records current scale
            scale *= scalingFactor; //scale multiplied by scale factor
            goTemp.transform.localScale = Vector3.one * scale; //transform scale 

            if (scale <= 0.1f)
            {
                removeList.Add(goTemp);
            }//end if
        }//end foreach
        foreach (GameObject goTemp in removeList)
        {
            gameObjectList.Remove(goTemp); //remove from game object list
            Destroy(goTemp); //destroys game object
        } //ends the other foreach.

    }//end update
}
