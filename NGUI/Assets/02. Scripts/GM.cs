using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour
{
    public GameObject bgSet;
    public GameObject bgSetDam;
    public float speed;
    public Vector3 bgPos;
    public Vector3 bgPosDam;
    public UILabel scoreLabel;
    public GameObject enemySet;
    public List<GameObject> childEnemy = new List<GameObject> { };
    public float xMove1;
    public float xMove2;
    public GameObject gameOver;
    public UILabel gameOverScore;

    int enemyIdx = 0;
    float yPos;
    float scoreF = 0.0f;
    int score;
    float xPosChk = 0.0f;
    float xPosChkDam = 0.0f;



    // Start is called before the first frame update
    void Start()
    {
        bgPos = bgSet.transform.position;
        bgPosDam = bgSetDam.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        xPosChk += speed;
        xPosChkDam += speed;
        bgSet.transform.Translate(Vector3.left * speed * Time.deltaTime * 0.5f);
        bgSetDam.transform.Translate(Vector3.left * speed * Time.deltaTime);
        enemySet.transform.Translate(Vector3.left * speed * Time.deltaTime);

        if (xPosChk > 960.0f)
        {
            xPosChk = 0.0f;
            bgSet.transform.position = bgPos;
        }

        if (xPosChkDam > 960.0f)
        {
            xPosChkDam = 0.0f;
            bgSetDam.transform.position = bgPosDam;
        }
        if (enemySet.transform.position.x < 0.0f)
        {
            Debug.Log(enemySet.transform.localPosition.x);
        }

            if (enemySet.transform.localPosition.x < xMove1)
        {
            xMove1 -= xMove2;
            ReSetChildSet();
            enemyIdx++;
            if(enemyIdx>=childEnemy.Count)
            {
                enemyIdx = 0;
            }
            Debug.Log("Move");
        }

        scoreF += speed * Time.deltaTime;
        score = (int)scoreF;
        scoreLabel.text = score.ToString();
    }

    private void ReSetChildSet()
    {
        Debug.Log("Reset");
        childEnemy[enemyIdx].transform.localPosition += new Vector3(1440.0f, 0, 0);
        switch(Random.Range(1,4))
        {
            case 1:
                yPos = -140.0f;
                break;
            case 2:
                yPos = 0f;
                break;
            case 3:
                yPos = 140.0f;
                break;
        }
        childEnemy[enemyIdx].transform.localPosition = new Vector3(childEnemy[enemyIdx].transform.localPosition.x, yPos, childEnemy[enemyIdx].transform.localPosition.z);
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        gameOver.SetActive(true);
        gameOverScore.text = score.ToString();
    }

    public void ReStart()
    {
        gameOver.SetActive(false);
        Time.timeScale = 1;
        Application.LoadLevel(0);
    }
}
