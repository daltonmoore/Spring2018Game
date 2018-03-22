using System.Collections;
using UnityEngine;

class PaintingManager : MonoBehaviour
{
    public PaintingManager singleton;
    public GameObject paintingPrefab;
    ArrayList paintingList = new ArrayList();

    private PaintingManager()
    { 
        
    }

    private void Awake()
    {
        singleton = new PaintingManager();
    }

    public void CreateAnotherPainting(Transform t)
    {
        GameObject g = Instantiate(paintingPrefab);
        Painting p = new Painting(paintingPrefab.GetComponent<SpriteRenderer>(),
            paintingPrefab.GetComponent<Rigidbody2D>(),
            paintingPrefab.GetComponent<BoxCollider2D>(), t, g);
        paintingList.Add(p);
        
    }
   
}
struct Painting
{
    GameObject painting;
    SpriteRenderer paintingSpriteRenderer;
    Rigidbody2D paintingRigid;
    BoxCollider2D paintingBoxCollider;
    Transform paintingTransform;

    public Painting(SpriteRenderer s, Rigidbody2D r, BoxCollider2D b, Transform t, GameObject p)
    {
        paintingSpriteRenderer = s;
        paintingRigid = r;
        paintingBoxCollider = b;
        paintingTransform = t;
        painting = p;
    }

    public GameObject getGameObject()
    {
        return painting;
    }
}


