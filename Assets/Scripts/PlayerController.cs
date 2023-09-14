using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput;
    private float speed = 10;
    private float xrange = 10;
    public GameObject projectilePrefab;
    private Vector3 projectileInitialPositioin;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //投げるオブジェクトのコピーが生成されても参照元の高さをプレーヤーの位置に追加する
        projectileInitialPositioin = new Vector3(transform.position[0], transform.position[1] + projectilePrefab.transform.position.y, transform.position[2]);

        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
        //Playerのx座標を取得して、それが0未満ないし10を超えたらそれぞれ処理をする
        if(transform.position.x > xrange)
        {
            transform.position = new Vector3(xrange, transform.position.y, transform.position.z);
        }else if(transform.position.x < -xrange)
        {
            transform.position = new Vector3(-xrange, transform.position.y, transform.position.z);
        }

        if (Input.GetKeyDown(KeyCode.Space)){

            Instantiate(projectilePrefab, projectileInitialPositioin, projectilePrefab.transform.rotation);
        }
    }
}
