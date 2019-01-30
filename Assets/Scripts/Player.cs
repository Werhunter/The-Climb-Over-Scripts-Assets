using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class Player : MonoBehaviour
{
    [SerializeField] private XboxController playerNumber;
    [SerializeField] private GameObject MainBodyObject; // de empty gameobject waar alle soorten body's aan vast zitten
    [SerializeField] private GameObject Small_Body;
    [SerializeField] private GameObject Big_Body;
    [SerializeField] private float MovementSpeed = 10f;
    [SerializeField] private float JumpHeight = 250f;
    [SerializeField] private float JumpRechargeTime = 0.4f;
    [SerializeField] private WinTracker wintrack;

    private Rigidbody2D rigid2D;
    [SerializeField] private int Force = 500;

    private float BodySwitchTimer = 5f;
    private bool HasSwitchedBodys = false;

    private bool acitvateJumpTimer = false;
    private float JumpTimer = 5f;
    private bool hasjumped = false;

    private bool isonground = false;

    private void Start()
    {
        //RaycastHit2D = GetComponent<RaycastHit2D>
        rigid2D = this.gameObject.GetComponent<Rigidbody2D>();
        MovementSpeed = MovementSpeed * Time.deltaTime;
    }

    private void Update()
    {
        #region Controller Movement

        //hier mee kan ik bewegen op de X-as
        transform.position += new Vector3(XCI.GetAxisRaw(XboxAxis.LeftStickX, playerNumber) * MovementSpeed, 0);

        if (XCI.GetButton(XboxButton.X, playerNumber))
        {
            rigid2D.velocity = Vector2.zero;
            rigid2D.AddForce(Vector2.down * 50);
            transform.Translate(Vector2.down * MovementSpeed * 2);
            print("down");
        }

        //if (XCI.GetDPadDown(XboxDPad.Left, playerNumber))
        //{
        //    transform.Translate(Vector2.left * MovementSpeed);
        //}

        //if (XCI.GetDPadDown(XboxDPad.Right, playerNumber))
        //{
        //    transform.Translate(Vector2.right * MovementSpeed);
        //}

        #endregion Controller Movement

        #region Keyboard Movment

        if (Input.GetKey(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.Translate(Vector2.left * MovementSpeed);
            print("a");
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.Translate(Vector2.right * MovementSpeed);
            print("d");
        }

        if (Input.GetKey(KeyCode.S) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.Translate(Vector2.down * MovementSpeed);
            print("s");
        }

        #endregion Keyboard Movment

        #region Dashmovement

        //if (XCI.GetButtonDown(XboxButton.X, playerNumber) && XCI.GetAxisRaw(XboxAxis.LeftStickX) < 0 || Input.GetKey(KeyCode.A) && Input.GetKeyDown(KeyCode.Q))
        //{
        //    rigid2D.velocity = Vector2.zero;
        //    rigid2D.AddForce(Vector2.left * Force);
        //    print("x");
        //}

        //if (XCI.GetButtonDown(XboxButton.X, playerNumber) && XCI.GetAxisRaw(XboxAxis.LeftStickX) > 0 || Input.GetKey(KeyCode.A) && Input.GetKeyDown(KeyCode.Q))
        //{
        //    rigid2D.velocity = Vector2.zero;
        //    rigid2D.AddForce(Vector2.right * Force);
        //    print("b");
        //}

        //if (XCI.GetButtonDown(XboxButton.X, playerNumber) && XCI.GetAxisRaw(XboxAxis.LeftStickY) < 0 || Input.GetKey(KeyCode.A) && Input.GetKeyDown(KeyCode.Q))
        //{
        //    rigid2D.velocity = Vector2.zero;
        //    rigid2D.AddForce(Vector2.down * Force);
        //    print("a");
        //}

        //if (XCI.GetButtonDown(XboxButton.X, playerNumber) && XCI.GetAxisRaw(XboxAxis.LeftStickY) > 0 || Input.GetKey(KeyCode.A) && Input.GetKeyDown(KeyCode.Q))
        //{
        //    rigid2D.velocity = Vector2.zero;
        //    rigid2D.AddForce(Vector2.up * Force);
        //    print("g");
        //}

        #endregion Dashmovement

        #region Controller_BodyChange

        if (HasSwitchedBodys == true)
        {
            BodySwitchTimer += Time.deltaTime;
        }

        if (BodySwitchTimer > 1)
        {
            HasSwitchedBodys = false;
            BodySwitchTimer = 0;
        }

        if (XCI.GetButtonDown(XboxButton.B, playerNumber) && Small_Body.activeSelf == true && HasSwitchedBodys == false)
        {
            Big_Body.transform.position = Small_Body.transform.position;
            Big_Body.SetActive(true);
            Small_Body.SetActive(false);
            hasjumped = true;
            acitvateJumpTimer = true;
            HasSwitchedBodys = true;
        }
        if (XCI.GetButtonDown(XboxButton.B, playerNumber) && Big_Body.activeSelf == true && HasSwitchedBodys == false)
        {
            Small_Body.transform.position = Big_Body.transform.position;
            Big_Body.SetActive(false);
            Small_Body.SetActive(true);
            hasjumped = true;
            acitvateJumpTimer = true;
            HasSwitchedBodys = true;
        }

        #endregion Controller_BodyChange

        #region Keyboard_BodyChange

        if (Input.GetKeyDown(KeyCode.Q) && Small_Body.activeSelf == true)
        {
            Big_Body.transform.position = Small_Body.transform.position;
            Big_Body.SetActive(true);
            Small_Body.SetActive(false);
            hasjumped = true;
            acitvateJumpTimer = true;
        }
        if (Input.GetKeyDown(KeyCode.E) && Big_Body.activeSelf == true)
        {
            Small_Body.transform.position = Big_Body.transform.position;
            Big_Body.SetActive(false);
            Small_Body.SetActive(true);
            hasjumped = true;
            acitvateJumpTimer = true;
        }

        #endregion Keyboard_BodyChange

        #region isplayeronground

        //if (Physics2D.Raycast(transform.position, Vector2.down, 1.2f))
        //{
        //    isonground = true;
        //}
        //else
        //{
        //    isonground = false;
        //}

        //if (isonground == true)
        //{
        //    JumpTimer += 50f;
        //}

        #endregion isplayeronground

        PLayerOutofBoundsCheck();
    }

    private void FixedUpdate()
    {
        #region Controller_Jump

        if (XCI.GetButtonDown(XboxButton.A, playerNumber) || XCI.GetDPadDown(XboxDPad.Up, playerNumber))
        {
            if (hasjumped == false)
            {
                rigid2D.velocity = Vector2.zero;
                rigid2D.AddForce(transform.up * JumpHeight);
                hasjumped = true;
                acitvateJumpTimer = true;
            }
        }

        if (acitvateJumpTimer == true)
        {
            JumpTimer += Time.deltaTime;
        }

        if (JumpTimer > JumpRechargeTime)
        {
            hasjumped = false;
            JumpTimer = 0f;
            acitvateJumpTimer = false;
        }

        #endregion Controller_Jump

        #region Keyboard_Jump

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (hasjumped == false)
            {
                rigid2D.AddForce(transform.up * JumpHeight);
                hasjumped = true;
                acitvateJumpTimer = true;
            }
        }

        #endregion Keyboard_Jump
    }

    private void PLayerOutofBoundsCheck()
    {
        //this is the bottom-left point of the screen
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        //this is the top-right point of the screen
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        //deze is van boven naar onder
        //if (transform.position.y > max.y)
        //{
        //    wintrack.DeathCount += 1;
        //    this.gameObject.SetActive(false);
        //}

        //deze is van onder naar boven
        if (transform.position.y < min.y)
        {
            wintrack.DeathCount += 1;
            MainBodyObject.SetActive(false);
        }

        //deze is van rechts naar links
        if (transform.position.x > max.x)
        {
            wintrack.DeathCount += 1;
            MainBodyObject.SetActive(false);
        }

        //deze is van links naar rechts
        if (transform.position.x < min.x)
        {
            wintrack.DeathCount += 1;

            MainBodyObject.SetActive(false);
        }
        // als de speler uit het scherm/speelveld is dan wordt die gedestroyed en 1 punt gegeven aan de player deathcount
    }
}