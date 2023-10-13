using UnityEngine;
public class LorenzAttractorGenerator : MonoBehaviour
{
    private Vector3 _position;
    
    public TrailRenderer attachedTrailRender;
    public float sigma = 10f;
    public float rho = 28f;
    public float beta = 8f;
    
    public void Initialize()
    {
        _position = new Vector3(Random.Range(-20f, 20f), Random.Range(-20f, 20f), Random.Range(-20f, 20f));
        
       attachedTrailRender = GetComponent<TrailRenderer>();
       attachedTrailRender.emitting = true;
       attachedTrailRender.Clear();
    }
    public void Terminate() => Destroy(gameObject, 0.5f);
    private void Update()
    {
        float x_dot = sigma * (_position.y - _position.x);
        float y_dot = _position.x * (rho - _position.z) - _position.y;
        float z_dot = _position.x * _position.y - (beta/3) * _position.z;

        _position.x += x_dot * GameManager.Instance.GlobalDeltaTime;
        _position.y += y_dot * GameManager.Instance.GlobalDeltaTime;
        _position.z += z_dot * GameManager.Instance.GlobalDeltaTime;

        transform.position = _position;
    }
}