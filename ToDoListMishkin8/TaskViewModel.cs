
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ToDoListMishkin8
{
    public class TaskViewModel : INotifyPropertyChanged
    {
        string name = "";
        private bool check = false;
        bool entryNotEmpty = true;

        public event PropertyChangedEventHandler? PropertyChanged;
        public Command AddCommand { get; }
        public Command DeleteCommand { get; }
        public ObservableCollection<ToDoTask> Tasks { get; } = new ObservableCollection<ToDoTask>();

        public bool EntryNotEmpty
        {
            get => entryNotEmpty;
            set
            {
                entryNotEmpty = value;
                OnPropertyChanged();
            }
        }

        public string Name
        {
            get => name;
            set
            {
                name = value;
                if (string.IsNullOrWhiteSpace(name))
                {
                    EntryNotEmpty = false;
                }
                else
                {
                    EntryNotEmpty = true;
                }
                OnPropertyChanged();
                (AddCommand as Command).ChangeCanExecute();
            }
        }

        public bool Check
        {
            get => check;
            set
            {
                check = value;
            }
        }

        public TaskViewModel()
        {
            AddCommand = new Command(
                execute: () =>
                {
                    var a = new ToDoTask(Name, Check);
                    Tasks.Add(a);
                    //a.Name = "123";
                    Name = "";
                    Check = false;
                },
                canExecute: () =>
                {
                    return EntryNotEmpty;
                });
            DeleteCommand = new Command<ToDoTask>(DeleteTask);
        }

        void DeleteTask(ToDoTask task)
        {
            if (task != null)
            {
                if (task.Check)
                {
                    Tasks.Remove(task);
                }
            }
        }


        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
