using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crosshair : MonoBehaviour
{
    public AudioSource fireSound;
    public GameObject pumpkin;

    private float pumpkinTime = 3;
    private bool pumpkinVisible;

    void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        transform.position = Input.mousePosition;

        if (Input.GetMouseButtonDown(0)) {
            fireSound.Play(0);

            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D[] hits = Physics2D.RaycastAll(pos, new Vector2(0, 0), 0.01f);

            if (hits.Length > 0) {
                int enemiesHit = 0;

                for (int i = 0; i < hits.Length && enemiesHit <= 2; i++) {
                    if (hits[i].collider.tag == "Ghost") {
                        enemiesHit++;
                        Destroy(hits[i].collider.gameObject);
                        Game.scoreValue += 3;
                        Game.enemiesRemaining--;
                    } else if (hits[i].collider.tag == "Witch") {
                        enemiesHit++;
                        Destroy(hits[i].collider.gameObject);
                        Game.scoreValue += 10;
                    }
                }

                if (enemiesHit == 2)
                    Game.scoreValue = 5;
            } else {
                if (!pumpkinVisible) {
                    pumpkin.SetActive(true);
                    pumpkinVisible = true;
                    StartCoroutine(LateCall());
                }
                
                Game.scoreValue -= 1;
            }
        }
    }

    IEnumerator LateCall()
     {
        if (pumpkinVisible) {
            yield return new WaitForSeconds(pumpkinTime);
 
            if (!Game.gameOver) {
                pumpkinVisible = false;
                pumpkin.SetActive(false);
            }
        }
     }
}
