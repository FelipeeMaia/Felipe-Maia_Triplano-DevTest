using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NipponRunner.Player
{

    [RequireComponent(typeof(Rigidbody))]
    public class PlayerControler : MonoBehaviour
    {
        [SerializeField] private float moveDuration;
        [SerializeField] private float moveDistance;

        private new Rigidbody rigidbody;
        private bool isMoving;

        // Start is called before the first frame update
        void Start()
        {
            rigidbody = GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        void Update()
        {
            _TemporaryInputs();
        }

        private void _TemporaryInputs()
        {
            if (isMoving) return;

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (transform.localPosition.x < moveDistance)
                {
                    Vector3 movement = moveDistance * Vector3.right;
                    StartCoroutine(LerpMovement(movement));
                }
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (transform.localPosition.x > -moveDistance)
                {
                    Vector3 movement = moveDistance * Vector3.left;
                    StartCoroutine(LerpMovement(movement));
                }
            }

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {

            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {

            }
        }

        private IEnumerator LerpMovement(Vector3 movement)
        {
            isMoving = true;

            Vector3 startPosition = rigidbody.position;
            Vector3 finalPosition = startPosition + movement;

            float elapsedTime = 0;
            while(elapsedTime < moveDuration)
            {
                yield return new WaitForFixedUpdate();

                elapsedTime += Time.fixedDeltaTime;
                float lerpPoint = elapsedTime / moveDuration;
                Vector3 step = Vector3.Lerp(startPosition, finalPosition, lerpPoint);
                rigidbody.MovePosition(step);
            }

            isMoving = false;
        }
    }
}
