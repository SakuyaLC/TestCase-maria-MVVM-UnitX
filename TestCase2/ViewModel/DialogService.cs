using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCase.View;

namespace TestCase.Data
{
    public interface IDialogService
    {
        void ShowDialog(string name);
    }

    class DialogService : IDialogService
    {
        public void ShowDialog(string name)
        {
            var dialog = new NotificationTemplate();

            var type = Type.GetType($"TestCase2.View.{name}");

            dialog.Content = Activator.CreateInstance(type);

            dialog.ShowDialog();
        }
    }
}
