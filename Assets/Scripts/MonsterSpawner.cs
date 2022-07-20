using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{

    [SerializeField]
    private GameObject[] monsterReference;
    //kéo cac enemies object vào array ngoài inspector

    private GameObject spawnedMonster;

    [SerializeField]
    private Transform leftPos, rightPos;
    //kéo tương ứng left object và right object vào 

    private int randomIndex;
    private int randomSide;

    void Start()
    {
        StartCoroutine(SpawnMonsters());
    }

    void Update()
    {
        
    }

    IEnumerator SpawnMonsters()
    {
        while (true)
        {
            //sinh ra một monster sau khoảng thời gian 1-5s
            yield return new WaitForSeconds(Random.Range(1,5));
            //tạo routine ở đây để mỗi lần tạo 1 monster thì sẽ đợi trong khoảng 1-5s ms thực thi
            //k thực thi liên tục (gây crash máy)
            // 
            randomIndex = Random.Range(0, monsterReference.Length);
            randomSide = Random.Range(0, 2);

            spawnedMonster = Instantiate(monsterReference[randomIndex]);
            //tạo một copy đối tương (game object)

            if(randomSide == 0)
            {
                //left side
                spawnedMonster.transform.position = leftPos.position;
                spawnedMonster.GetComponent<Monster>().speed = Random.Range(4, 10);
            }
            else
            {
                //right side
                spawnedMonster.transform.position = rightPos.position;
                spawnedMonster.GetComponent<Monster>().speed = -Random.Range(4, 10);
                //set giá trị âm để cho object có thể di chuyển từ phải sang trái (theo trục tọa độ)
                spawnedMonster.transform.localScale = new Vector3(-1f, 1f, 1f);

            }
        }

    }
}
