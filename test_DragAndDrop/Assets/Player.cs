using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Invertory invertory;
    Rigidbody rig;
    [Range(0, 100)]
    public float Force;
    [SerializeField] UIIntervertory uIIntervertory;
    // Start is called before the first frame update
    private void Awake()
    {
        uIIntervertory = GameObject.FindObjectOfType<UIIntervertory>();
        rig = GetComponent<Rigidbody>();
    }
    void Start()
    {
        invertory = new Invertory();
        uIIntervertory.SetInventory(invertory);
        ItemWorld.SpwanItemWorld(new Vector3(-6, 2), new UIItem { itemtype = UIItem.Itemtype.HelathPotion, amount = 1 });
        ItemWorld.SpwanItemWorld(new Vector3(5, 1), new UIItem { itemtype = UIItem.Itemtype.ManaPotion, amount = 1 });
        ItemWorld.SpwanItemWorld(new Vector3(-1, -3), new UIItem { itemtype = UIItem.Itemtype.Sword, amount = 1 });
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {
        Move();
    }
    public void Move()
    {
        if (Input.GetKey("right"))
        {
            rig.transform.Translate(rig.transform.right * Force * Time.deltaTime);
        }
        else if (Input.GetKey("up"))
        {
            rig.transform.Translate(rig.transform.up * Force * Time.deltaTime);
        }
        else if (Input.GetKey("down"))
        {
            rig.transform.Translate(rig.transform.up * -Force * Time.deltaTime);
        }
        else if (Input.GetKey("left"))
        {
            rig.transform.Translate(rig.transform.right * -Force * Time.deltaTime);
        }

    }
    private void OnTriggerEnter(Collider Hit)
    {
        ItemWorld itemWorld = Hit.GetComponent<ItemWorld>();
        if (itemWorld != null)
        {
            invertory.AddItem(itemWorld.GetItem());
            itemWorld.DestroySelf();
        }
    }

}

