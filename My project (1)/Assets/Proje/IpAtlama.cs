using UnityEngine;

public class IpAtlama : MonoBehaviour
{
    [SerializeField] Transform startPoint;
    [SerializeField] Transform endPoint;
    [SerializeField] float radius = 0.5f;
    [SerializeField] float speed = 2.0f;
    [SerializeField] int segments = 50;

    private LineRenderer lineRenderer;
    private float angle = 0.0f;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = segments;
    }

    void Update()
    {
        DrawRope();
    }

    void DrawRope()
    {
        angle += speed * Time.deltaTime;

        lineRenderer.SetPosition(0, startPoint.position);
        lineRenderer.SetPosition(segments - 1, endPoint.position);


        for (int i = 1; i < segments - 1; i++)
        {
            float t = (float)i / (segments - 1); // Normalized position along the rope [0, 1]


            Vector3 pointPosition = HermiteInterpolate(startPoint.position, endPoint.position, t, angle);

            lineRenderer.SetPosition(i, pointPosition);
        }
    }

    Vector3 HermiteInterpolate(Vector3 p0, Vector3 p1, float t, float angle)
    {

        Vector3 tangent0 = (p1 - p0).normalized * radius;
        Vector3 tangent1 = tangent0;


        float h00 = 2 * Mathf.Pow(t, 3) - 3 * Mathf.Pow(t, 2) + 1;
        float h10 = Mathf.Pow(t, 3) - 2 * Mathf.Pow(t, 2) + t;
        float h01 = -2 * Mathf.Pow(t, 3) + 3 * Mathf.Pow(t, 2);
        float h11 = Mathf.Pow(t, 3) - Mathf.Pow(t, 2);


        Vector3 interpolatedPosition = h00 * p0 + h10 * tangent0 + h01 * p1 + h11 * tangent1;


        float angleOffset = angle + Mathf.PI * t;
        interpolatedPosition.x += Mathf.Sin(angleOffset) * radius;
        interpolatedPosition.y += Mathf.Cos(angleOffset) * radius;

        return interpolatedPosition;
    }
}
