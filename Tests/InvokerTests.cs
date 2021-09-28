using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Rubix
{
    public class InvokerTests
    {
        private Mock<Invoker> CreateSut()
        {
            return new Mock<Invoker>() { CallBase = true};
        }

        [Fact]
        public async Task Execute_WhenCalled_ExpectExecutCalledAndStacksUpdated()
        {
            var sut = CreateSut();

            var cmd = new Mock<ICommand>();

            sut.Object.Execute(cmd.Object);

            cmd.Verify(x => x.Execute(), Times.Once);
            sut.Verify(x => x.StackPush(cmd.Object, sut.Object.undoStack), Times.Once);
            sut.Verify(x => x.StackReset( sut.Object.undoStack), Times.Once);
        }

        [Fact]
        public async Task Undo_WhenCalledAndUndoExists_ExpectUndoCalledAndStacksUpdated()
        {
            var sut = CreateSut();

            var cmd = new Mock<ICommand>();
            sut.Object.undoStack.Push(cmd);

            sut.Object.Undo();

            cmd.Verify(x => x.Undo(), Times.Once);
            sut.Verify(x => x.StackPop(sut.Object.undoStack), Times.Once);
            sut.Verify(x => x.StackPush(cmd.Object, sut.Object.redoStack), Times.Once);
        }

        [Fact]
        public async Task Undo_WhenCalledAndDoesNotUndoExist_ExpectUndoCalledAndStacksUpdated()
        {
            var sut = CreateSut();

            var cmd = new Mock<ICommand>();

            sut.Object.Undo();

            cmd.Verify(x => x.Undo(), Times.Never);
            sut.Verify(x => x.StackPop(sut.Object.undoStack), Times.Never);
            sut.Verify(x => x.StackPush(cmd.Object, sut.Object.redoStack), Times.Never);
        }

        [Fact]
        public async Task Redo_WhenCalledAndRedoExists_ExpectRedoCalledAndStacksUpdated()
        {
            var sut = CreateSut();

            var cmd = new Mock<ICommand>();
            sut.Object.redoStack.Push(cmd);

            sut.Object.Redo();

            cmd.Verify(x => x.Redo(), Times.Once);
            sut.Verify(x => x.StackPop(sut.Object.redoStack), Times.Once);
            sut.Verify(x => x.StackPush(cmd.Object, sut.Object.undoStack), Times.Once);
        }

        [Fact]
        public async Task Reddo_WhenCalledAndDoesNotRedoExist_ExpectRedoCalledAndStacksUpdated()
        {
            var sut = CreateSut();

            var cmd = new Mock<ICommand>();

            sut.Object.Undo();

            cmd.Verify(x => x.Undo(), Times.Never);
            sut.Verify(x => x.StackPop(sut.Object.undoStack), Times.Never);
            sut.Verify(x => x.StackPush(cmd.Object, sut.Object.redoStack), Times.Never);
        }

    }
}
