using UnityEngine;

public class ParallaxLayer : MonoBehaviour
{
    public float parallaxMultiplier = 0.3f;

    private Transform cam;
    private Vector3 lastCamPos;
    private float spriteWidth;

    void Start()
    {
        cam = Camera.main.transform;
        lastCamPos = cam.position;

        SpriteRenderer sr = GetComponentInChildren<SpriteRenderer>();
        spriteWidth = sr.bounds.size.x;
    }

    void LateUpdate()
    {
        // Parallax movement
        Vector3 delta = cam.position - lastCamPos;
        transform.position += new Vector3(delta.x * parallaxMultiplier, 0, 0);
        lastCamPos = cam.position;

        // Looping
        foreach (Transform child in transform)
        {
            float diff = cam.position.x - child.position.x;

            if (Mathf.Abs(diff) >= spriteWidth)
            {
                float direction = Mathf.Sign(diff);
                child.position += new Vector3(spriteWidth * 2f * direction, 0, 0);
            }
        }
    }
}

