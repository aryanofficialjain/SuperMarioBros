using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int World {get; private set;}
    public int Stage {get; private set;}

    public int Lives {get; private set;}



    private void Awake()
    {
        if (Instance != null)
        {
            DestroyImmediate(gameObject);

        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }


    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }

    private void Start(){
        NewGame();
    }

    private void NewGame(){
        Lives = 3;
        Loadlevel(1,1);

    }

    private void Loadlevel(int world, int stage){
        this.World = world;
        this.Stage = stage;

        SceneManager.LoadScene($"{World}-{Stage}");
    }

    public void ResetLevel(float delay){
        Invoke(nameof(ResetLevel), delay);

    }

    public void NextLevel(){
        Loadlevel(World, Stage + 1);
        
    }

    public void ResetLevel(){
        Lives--;
        
        if(Lives > 0){
            Loadlevel(World, Stage);
        } else{
            GameOver();
        }

    }

    public void GameOver(){
        // SceneManager.LoadScene("GameOver");
        NewGame();

    }

}

