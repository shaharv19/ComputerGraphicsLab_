using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagment : MonoBehaviour
{
    public Text txt;
    // Start is called before the first frame update
    public MeshRenderer targetObject1;
    public MeshRenderer targetObject2;
    public MeshRenderer targetObject3;
    public MeshRenderer targetObject4;
    public MeshRenderer targetObject5;
    public MeshRenderer targetObject6;
    public MeshRenderer targetObject7;
    public MeshRenderer  targetObject8;
    public MeshRenderer targetObject9;
    public MeshRenderer targetObject10;
    public MeshRenderer targetObject11;
    public MeshRenderer targetObject12;
    public MeshRenderer targetObject13;
    public MeshRenderer targetObject14;
    public MeshRenderer targetObject15;
    public MeshRenderer targetObject16;
    public MeshRenderer targetObject17;
    public MeshRenderer targetObject18;
    public MeshRenderer targetObject19;
    public MeshRenderer targetObject20;
    public MeshRenderer targetObject21;
    public MeshRenderer targetObject22;
    public MeshRenderer targetObject23;
    private MeshRenderer[] gameObjects = new MeshRenderer[23];
    public int currentTarget;
    public bool collisionWithTarget;
    public bool isCurrentTarget;
    void Start()
    {
        gameObjects[0] = targetObject1;
        gameObjects[1] = targetObject2;
        gameObjects[2] = targetObject3;
        gameObjects[3] = targetObject4;
        gameObjects[4] = targetObject5;
        gameObjects[5] = targetObject6;
        gameObjects[6] = targetObject7;
        gameObjects[7] = targetObject8;
        gameObjects[8] = targetObject9;
        gameObjects[9] = targetObject10;
        gameObjects[10] = targetObject11;
        gameObjects[11] = targetObject12;
        gameObjects[12] = targetObject13;
        gameObjects[13] = targetObject14; 
        gameObjects[14] = targetObject15;
        gameObjects[15] = targetObject16; 
        gameObjects[16] = targetObject17;
        gameObjects[17] = targetObject18;
        gameObjects[18] = targetObject19;
        gameObjects[19] = targetObject20; 
        gameObjects[20] = targetObject21;
        gameObjects[21] = targetObject22;
        gameObjects[22] = targetObject23;

        for(int i=0;i<23;i++)
        {
            gameObjects[i].enabled = false;
        }
        int randomInt = Random.Range(0, 23); 
        gameObjects[randomInt].enabled = true;
        currentTarget = randomInt;


    }

    // Update is called once per frame
    void Update()
    { 
        if (collisionWithTarget == true && isCurrentTarget==true)
        {
            gameObjects[currentTarget].enabled = false;
            float randomFloat = Random.value;
            // Generate a random integer between minValue (inclusive) and maxValue (exclusive)
            int randomInt = Random.Range(0, 23); // Generates a number between 1 and 100
            gameObjects[randomInt].enabled = true;
            collisionWithTarget = false;
            currentTarget = randomInt;
            isCurrentTarget = false;
            int score = int.Parse(txt.text) + 10;
            txt.text = score.ToString();
        }

    }
}
