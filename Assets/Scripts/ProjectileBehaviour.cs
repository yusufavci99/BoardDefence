using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    public int velocity;
    private DefenceData defenceData;
    Vector3 originalPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Init(DefenceData defenceData, Vector3 position) {
        this.defenceData = defenceData;
        this.originalPosition = position;
        transform.position = position;
        this.GetComponent<SpriteRenderer>().sprite = defenceData.projectileSprite;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * velocity * Time.deltaTime);
        if ((transform.position - originalPosition).sqrMagnitude > (defenceData.range * defenceData.range)) {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        ReactiveTarget hitTarget = collision.gameObject.GetComponent<ReactiveTarget>();
        if (hitTarget != null) {
            hitTarget.Hit(defenceData.damage);
            Destroy(this.gameObject);
        }

    }
}
