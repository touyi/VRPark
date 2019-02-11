namespace DefaultNamespace
{
    public interface IActionControl
    {
        void Init(IActor actor);
        void Update();
        void DisableMove();
        void ActiveMove();
    }
}