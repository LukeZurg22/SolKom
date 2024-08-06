namespace SolKom.TK
{
    /// Maybe inherit from some tertiary class that dictates GameObject.
    public class CelestialBody
    {
        public CelestialBody() { }
        void SpawnBody()
        {
            Spawn();
        }
        void DestroyBody()
        {
            Destroy();
        }
        public virtual void Spawn() { }
        public virtual void Destroy() { }
    }
}