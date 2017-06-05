using System;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Test
{
    public class AsyncCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public Func<Task> ExecutedHandler { get; }

        public Func<bool> CanExecuteHandler { get; }

        public AsyncCommand(Func<Task> executedHandler, Func<bool> canExecuteHandler = null)
        {
            this.ExecutedHandler = executedHandler ?? throw new ArgumentNullException(nameof(executedHandler));
            this.CanExecuteHandler = canExecuteHandler;
        }

        public Task Execute() => this.ExecutedHandler();

        public bool CanExecute() => this.CanExecuteHandler == null || this.CanExecuteHandler();

        public void RaiseCanExecuteChanged() => this.CanExecuteChanged?.Invoke(this, new EventArgs());

        bool ICommand.CanExecute(object parameter) => this.CanExecute();

        async void ICommand.Execute(object parameter) => await this.Execute();
    }

    public class AsyncCommand<T> : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public Func<T, Task> ExecutedHandler { get; }

        public Func<bool> CanExecuteHandler { get; }

        public AsyncCommand(Func<T, Task> executedHandler, Func<bool> canExecuteHandler = null)
        {
            this.ExecutedHandler = executedHandler ?? throw new ArgumentNullException(nameof(executedHandler));
            this.CanExecuteHandler = canExecuteHandler;
        }

        public Task Execute(T t) => this.ExecutedHandler(t);

        public bool CanExecute() => this.CanExecuteHandler == null || this.CanExecuteHandler();

        public void RaiseCanExecuteChanged() => this.CanExecuteChanged?.Invoke(this, new EventArgs());

        bool ICommand.CanExecute(object parameter) => this.CanExecute();

        async void ICommand.Execute(object parameter) => await this.Execute((T)parameter);
    }
}