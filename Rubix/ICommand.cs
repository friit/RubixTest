namespace Rubix
{
    public interface ICommand 
    {
        void Execute();
        void Undo();
        void Redo();
    }
}
