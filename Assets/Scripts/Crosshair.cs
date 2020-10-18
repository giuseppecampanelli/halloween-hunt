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

    public float fireTime = 3;
    public float fireRate = 0.25f;
    private bool firing;

    void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        transform.position = Input.mousePosition;

        if (!firing) {
            CancelInvoke("FireShot");
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && !firing) {
            firing = true;

            StartCoroutine(DisableContinuousFire());
        }

        if (Input.GetMouseButtonDown(0) && firing) {
            InvokeRepeating("FireShot", 0, fireRate);
        } else if (Input.GetMouseButtonDown(0)) {
            FireShot();
        }
    }

    void FireShot()
    {
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
                Game.scoreValue += 5;
        } else {
            if (!pumpkinVisible) {
                pumpkin.SetActive(true);
                pumpkinVisible = true;
                StartCoroutine(PumpkinDisappear());
            }
            
            Game.scoreValue -= 1;
        }
    }

    IEnumerator PumpkinDisappear()
    {
        if (pumpkinVisible) {
            yield return new WaitForSeconds(pumpkinTime);
 
            if (!Game.gameOver) {
                pumpkinVisible = false;
                pumpkin.SetActive(false);
            }
        }
    }

    IEnumerator DisableContinuousFire()
    {
        yield return new WaitForSeconds(fireTime);
        firing = false;
    }
}
