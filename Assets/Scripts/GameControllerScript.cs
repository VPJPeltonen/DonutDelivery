using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameControllerScript : MonoBehaviour
{
    public TargetController[] Targets;
    public GameObject GameUI, LoseScreen;
    public int score;
    public TextMeshProUGUI Message, FinalProfit, Profit;
    private Vector3 pickUpLocation,deliveryLocation; 
    private float startTime, deliveryTime;
    private List<BalloonController> AIBalloons;
    private int currentTarget = 0;
    private string playerState = "retrieving";
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] tempShips;
        AIBalloons = new List<BalloonController>();
        tempShips = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(GameObject ship in tempShips){
            AIBalloons.Add(ship.GetComponent<BalloonController>());
        }
    }

    public void StartGame(){
        Targets[currentTarget].ActivateTarget();
    }

    public void Restart(){
        SceneManager.LoadScene(0,LoadSceneMode.Single);
    }

    public void GameOver(){
        foreach(BalloonController balloon in AIBalloons){
            balloon.active = false;
        }
        FinalProfit.text = score.ToString();
        GameUI.SetActive(false);
        LoseScreen.SetActive(true);
    }

    public void IndicatorActivated(bool pickUp,Vector3 location){
        if(pickUp){
            DeliveryStarted(location);
        }else{
            DeliveryDone(location);
        }
    }

    private void AddScore(int newpoints){
        score += newpoints;
        if(score > 1000){
            foreach(BalloonController balloon in AIBalloons){
                balloon.SetGameStage(5);
            }
        }else if(score > 750){
            foreach(BalloonController balloon in AIBalloons){
                balloon.SetGameStage(4);
            }            
        }else if(score > 500){
            foreach(BalloonController balloon in AIBalloons){
                balloon.SetGameStage(3);
            }
        }else if(score > 250){
            foreach(BalloonController balloon in AIBalloons){
                balloon.SetGameStage(2);
            }
        }else if(score > 100){
            foreach(BalloonController balloon in AIBalloons){
                balloon.SetGameStage(1);
            }
        }
        Profit.text = score.ToString();
    }

    private void DeliveryDone(Vector3 location){
        Message.text = "Assigment:\nRetrieve more donuts from purple indicator";
        ActivateDonutTarget();  
        float distance = Vector3.Distance(pickUpLocation,location);
        float timeBonus = Time.time - startTime;
        float newScore = timeBonus*distance;
        AddScore((int)distance);
    }

    private void DeliveryStarted(Vector3 location){
        Message.text = "Assigment:\nDeliver donuts to green indicator";
        pickUpLocation = location;
        startTime = Time.time; 
    }

    private void ActivateDonutTarget(){
        int newTarget;
        while(true){
            newTarget = Random.Range(0,Targets.Length);
            if(newTarget != currentTarget){break;}
        }
        currentTarget = newTarget;
        Targets[currentTarget].ActivateTarget();
    }
}
