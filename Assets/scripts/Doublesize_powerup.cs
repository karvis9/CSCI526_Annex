using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Doublesize_powerup : MonoBehaviour
{
    List<GameObject> bubbleObjects = new List<GameObject>();
    public Vector2 baseline;
    public float scaleFactor;
    public float totalAnimationTime;
    // Start is called before the first frame update
    void Start()
    {
        scaleFactor = 2.0f;
        baseline = new Vector2(0.3f,0.3f);
        totalAnimationTime = 4.0f;
    }

    // List<GameObject> GetAllObjectsInScene()
    // {
    //  List<GameObject> objectsInScene = new List<GameObject>();
    //  foreach (GameObject go in Resources.FindObjectsOfTypeAll(typeof(GameObject)) as GameObject[])
    //  {
    //      if (go.hideFlags == HideFlags.NotEditable || go.hideFlags == HideFlags.HideAndDontSave)
    //          continue;
    //      if (!EditorUtility.IsPersistent(go.transform.root.gameObject))
    //          continue;
    //      objectsInScene.Add(go);
    //  }
    //  return objectsInScene;
    // }

    private void OnTriggerEnter2D(Collider2D collision)
    {   
        
        // if(collision.gameObject.tag == "TopWall")
        // {
        //     Destroy(this.gameObject,0.6f);
        // }
        if(collision.gameObject.tag == "Arrow")
        {
            // anim.Play("BubblePop");
            // Destroy(this.gameObject,0.6f);
            // Debug.Log("You hit me!");
            // objs = GameObject.FindGameObjectsWithTag("Letter");
            // res = GetAllObjectsInScene();
            // Debug.WriteLine(GetAllObjectsInScene());

            //Getting all the game objects in the scene when arrow hits the object
            List<GameObject> rootObjects = new List<GameObject>();
            Scene scene = SceneManager.GetActiveScene();
            scene.GetRootGameObjects( rootObjects );


            // iterate root objects and filter/find the bubble game objects
            for (int i = 0; i < rootObjects.Count; ++i)
            {
                GameObject gameObject = rootObjects[ i ];
                
                //finding the bubble game objects having tag as letter
                if(gameObject.tag =="Letter"){
                    bubbleObjects.Add(gameObject);
                }
                // GameObject gameObject = rootObjects[ i ];
                // if(gameObject.Find("Bubble 1")) {  
                //     Debug.Log("Found it");
                // }

                // if(gameObject.name == "Bubble 1"){
                //     Debug.Log( gameObject.name);
                // }
                // Debug.Log(gameObject.name);
                
            }
            //performing double scaling using the startcoroutine
            StartCoroutine(waiter());
        }
    }

    //Coroutine for double scaling all the bubbles on screen
    IEnumerator waiter(){
        /*Vector3 vector = letterList[index].transform.localScale;
        letterList[index].transform.localScale = new Vector3(2.8f, 2f, 2f);
        yield return new WaitForSeconds(1);
        letterList[index].transform.localScale = vector;*/

        // make it more interesting

        //setting the baseline 

        //We know the baseline for now which is 0.3f so need to do loop
        //but we can also find Mathf.min(object...) to find the baseline to start with

        // foreach(GameObject obj in bubbleObjects){
        //     baseline = obj.gameObject.transform.localScale;
        // }
        // Vector3 baseline = bubbleObjects.transform.localScale;
        // setting an highpoint for scaling

        Vector2 highpoint = scaleFactor*baseline; // can adjust
        int totalFrames = 50; // can adjust
        for(int i = 0; i < totalFrames; i++) {
            foreach(GameObject obj in bubbleObjects){
                if (obj != null)
                    obj.gameObject.transform.localScale =  (baseline - highpoint) * (i - totalFrames / 2) * (i - totalFrames / 2) / (totalFrames * totalFrames) + highpoint;
            }
            // bubbleObjects.transform.localScale = 4 * (baseline - highpoint) * (i - totalFrames / 2) * (i - totalFrames / 2) / (totalFrames * totalFrames) + highpoint;
            yield return new WaitForSeconds(totalAnimationTime / (float) totalFrames);
        }
        //return to baseline
        foreach(GameObject obj in bubbleObjects){
            if (obj != null)
                obj.gameObject.transform.localScale = baseline;
        }
        // bubbleObjects.transform.localScale = baseline;
        
    }

    // private void OnCollisionEnter2D(Collision2D collision)
    // {
    //     if(collision.gameObject.name == "Terrains"){
    //         Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    //     }
    // }

    // Update is called once per frame
    void Update()
    {
        
    }
}