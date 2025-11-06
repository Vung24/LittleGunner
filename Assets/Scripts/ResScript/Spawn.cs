using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] enemies;
    public float minX, maxX, minY, maxY;
    public float startTimeBtwSpawn;
    private float timeBtwSpawn;

    public float decreaseTime;
    public float minTime;
    public int isInf = 1, numberRepawn = 3;

    void Update()
    {
        if(timeBtwSpawn <=0){
            if(isInf == 1 || (isInf == 0 && numberRepawn>0))
            {
                if(isInf==0)
                    numberRepawn--;
                int randEnemy = Random.Range(0, enemies.Length);
                float randX= Random.Range(minX, maxX),randY= Random.Range(minY, maxY);
                Vector2 randPos = new Vector2(randX, randY);

                Instantiate(enemies[randEnemy] ,randPos, Quaternion.identity);
                timeBtwSpawn = startTimeBtwSpawn;
                if(startTimeBtwSpawn > minTime)
                {
                    startTimeBtwSpawn -= decreaseTime;
                }
            }
        } else{
            timeBtwSpawn -= Time.deltaTime;
        }
    }
}
