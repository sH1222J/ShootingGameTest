using UnityEngine;
using UnityEngine.UI;

public class Player_Score : MonoBehaviour
{
    public static float countDown = 0f;
    public float time = 30f;
    Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>();
        countDown = time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Floor(countDown) <= 0)
        {
            // Count 0일때 동작할 함수 삽입
        }
        else
        {
            countDown -= Time.deltaTime;
            scoreText.text = string.Format("{0:0.##}", countDown);
        }
    }
}