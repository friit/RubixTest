using System.Collections;

namespace Rubix
{
    public class Invoker
    {
        public Stack undoStack = new Stack();
        public Stack redoStack = new Stack();

        public void Execute(ICommand command)
        {
            //Clear redo stack
            StackReset(redoStack);
            command.Execute();
            StackPush(command, undoStack);
        }

        public void Undo()
        {
            if(undoStack.Count < 1)
            {
                return;
            }

            var cmd = StackPop(undoStack);
            cmd.Undo();
            StackPush(cmd, redoStack);
        }

        public void Redo()
        {
            if (redoStack.Count < 1)
            {
                return;
            }

            var cmd = StackPop(redoStack);
            cmd.Redo();
            StackPush(cmd, undoStack);
        }

        public virtual void StackPush(ICommand cmd, Stack stack) => stack.Push(cmd);
        public virtual ICommand StackPop(Stack stack) => stack.Pop() as ICommand;
        public virtual void StackReset(Stack stack) => stack.Clear();
    }
}
