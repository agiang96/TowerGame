using UnityEngine;
using UnityEngine.UI;

public class CannonController : MonoBehaviour
{
    private float _moveIncrement = .2f;
    private float _cannonAngle = 0;
    private float increment = 5f;
    private float _firePower = 25;
    private float _cannonCount = 10;

    public Text angleText;
    public Text powerText;
    public Text cannonballText;

    //reference to our prefab to instantiate it in our code
    public GameObject CannonBallPrefab;
    public Transform CannonballSpawn;

    public void CannonUp()
    {
        if(_cannonAngle >= 0 && _cannonAngle < 90)
        {
            _cannonAngle += increment;
            transform.rotation = Quaternion.Euler(0, 0, _cannonAngle);
            UpdateAngle();
        }
        
    }
    public void CannonDown()
    {
        if (_cannonAngle > 0 && _cannonAngle <= 90)
        {
            _cannonAngle -= increment;
            transform.rotation = Quaternion.Euler(0, 0, _cannonAngle);
            UpdateAngle();
        }
    }
    public void PowerUp()
    {
        _firePower++;
        UpdatePower();

    }
    public void PowerDown()
    {
        _firePower--;
        UpdatePower();
    }

    public void Fire()
    {
        if (_cannonCount > 0)
        {
            //instantiate cannonball (template object, starting position, rotation) identity = no rotation 
            GameObject cannonball = Instantiate(CannonBallPrefab, CannonballSpawn.position, Quaternion.identity) as GameObject;

            // figure out angle to shoot
            //Get a reference to the rigidbody on the cannonball
            Rigidbody2D cannonballRigidbody = cannonball.GetComponent<Rigidbody2D>();

            //get the direction that the ball should fly
            Vector3 velocity = Quaternion.Euler(0, 0, _cannonAngle) * Vector3.right;

            //scale the direction by the speed
            velocity *= _firePower;

            //set velocity
            cannonballRigidbody.velocity = velocity;

            _cannonCount--;
            UpdateCannonball();
        }

    }

    private void Start()
    {
        UpdateAngle();
        UpdatePower();
        UpdateCannonball();
    }

    void UpdateAngle()
    {
        angleText.text = "" + _cannonAngle + "°";
    }
    void UpdatePower()
    {
        powerText.text = "" + _firePower;
    }
    void UpdateCannonball()
    {
        cannonballText.text = "Shots Left: " + _cannonCount;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.parent.position += new Vector3(_moveIncrement, 0, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.parent.position -= new Vector3(_moveIncrement, 0, 0);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            CannonUp();
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            CannonDown();
        }
        if (Input.GetKey(KeyCode.Space))
        {
            Fire(); 
        }
    }
}
