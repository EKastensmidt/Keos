using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MudLineBehaviour : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public EdgeCollider2D edgeCollider;
    [SerializeField] private float maxPointRange = 0.1f;
    [SerializeField] private int maxPoints = 30;

    private List<Vector2> points;
    private PlayerController _playerController;
    private bool lineEnded = false;

    private void Start()
    {
        _playerController = GameObject.Find("Maguito").GetComponent<PlayerController>();
    }

    private void Update()
    {
        if (lineEnded)
            return;

        if (_playerController.IsPlaying)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            UpdateLine(mousePos);
        }
        else
        {
            lineEnded = true;
            Destroy(gameObject, 3f);
        }
    }

    public void UpdateLine(Vector2 mousePosition)
    {
        if(points == null)
        {
            points = new List<Vector2>();
            SetPoint(mousePosition);
            return;
        }

        if (maxPoints < points.Count)
            return;

        if (Vector2.Distance(points.Last(), mousePosition) > maxPointRange)
        {
            SetPoint(mousePosition);
        }
    }

    void SetPoint(Vector2 point)
    {
        points.Add(point);

        lineRenderer.positionCount = points.Count;
        lineRenderer.SetPosition(points.Count - 1, point);

        if(points.Count > 1)
            edgeCollider.points = points.ToArray();
    }

}
