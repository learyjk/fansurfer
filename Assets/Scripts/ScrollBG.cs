using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBG : MonoBehaviour
{
    public GameObject bgPrefab;
    public SpriteRenderer sr;
    private float width;
    private bool has_spawned;

    [SerializeField] private float speed;

    private void Start() 
    {
        sr = GetComponent<SpriteRenderer>();
        width = sr.bounds.size.x;
        has_spawned = false;
    }

    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        if (transform.position.x <= 0.2f && !has_spawned)
        {
            has_spawned = true;
            //Instantiate new one
            Vector3 newPos = new Vector3 (width, transform.position.y, 0f);
            GameObject clone = Instantiate(bgPrefab, newPos, Quaternion.identity);
            clone.name = "cloneBG";
            
        }
        if (transform.position.x <= -width)
        {
            //Destroy the object
            Destroy(this.gameObject);
            has_spawned = false;
        }
    }
}
