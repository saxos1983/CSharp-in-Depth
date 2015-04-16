using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chapter15_Async_Await
{
    using System.Windows.Forms.VisualStyles;

    [Description("Await, Wait (DeadLock), ConfigureAwait")]
    public partial class AsyncFormDeadLock : Form
    {
        public AsyncFormDeadLock()
        {
            InitializeComponent();
        }

        private void btnWaitDeadlock_Click(object sender, EventArgs e)
        {
            var task = this.DoLongRunningTask();
            task.Wait();
            labelStatusValue.Text = task.Result;
        }

        private async void btnAwaitNoDeadlock_Click(object sender, EventArgs e)
        {
            var task = this.DoLongRunningTask();
            var result = await task;
            labelStatusValue.Text = result;
        }

        private void btnConfigureAwaitNoDeadlock_Click(object sender, EventArgs e)
        {
            var task = this.DoLongRunningTaskConfigureAwait();
            task.Wait();
            labelStatusValue.Text = task.Result;
        }

        private async Task<string> DoLongRunningTask()
        {
            labelStatusValue.Text = "Executing...";
            await Task.Delay(TimeSpan.FromSeconds(1));
            return "Finished";
        }
        
        private async Task<string> DoLongRunningTaskConfigureAwait()
        {
            labelStatusValue.Text = "Executing...";
            await Task.Delay(TimeSpan.FromSeconds(1)).ConfigureAwait(false);
            return "Finished";
        }

        static void Main()
        {
            Application.Run(new AsyncFormDeadLock());
        }
    }
}
