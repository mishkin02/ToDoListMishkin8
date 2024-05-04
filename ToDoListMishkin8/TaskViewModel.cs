using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ToDoListMishkin8
{
    public class TaskViewModel : INotifyPropertyChanged
    {
        string name = "";
        private bool check = false;
        bool entryNotEmpty = false;

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
                if (string.IsNullOrEmpty(name))
                {
                    EntryNotEmpty = false;
                }
                else
                {
                    EntryNotEmpty = true;
                }
                OnPropertyChanged();
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
            AddCommand = new Command(() =>
            {
                var a = new ToDoTask(Name, Check);
                Tasks.Add(a);
                a.Name = "123";
                Name = "";
                Check = false;
            });

            DeleteCommand = new Command<ToDoTask>(DeleteTask);
            EntryNotEmpty = false;
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
