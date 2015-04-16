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
        /// <summary>
        /// Have a look at http://blog.stephencleary.com/2012/07/dont-block-on-async-code.html
        /// to understand the different scenarios how you can initiate/prevent a DeadLock.
        /// </summary>
        public AsyncFormDeadLock()
        {
            InitializeComponent();
        }

        /// <summary>
        /// This will cause a DeadLock because the method waits synchronously
        /// for the task to complete. The task will try to marshal the continuation
        /// back to the calling context (which is the UI thread) but the UI thread is
        /// already waiting for the task completion --> DeadLock.
        /// </summary>
        private void btnWaitDeadlock_Click(object sender, EventArgs e)
        {
            var task = this.DoLongRunningTask();
            task.Wait();
            labelStatusValue.Text = task.Result;
        }

        /// <summary>
        /// Because the task is being awaited, the UI will remain responsive.
        /// </summary>
        private async void btnAwaitNoDeadlock_Click(object sender, EventArgs e)
        {
            var task = this.DoLongRunningTask();
            var result = await task;
            labelStatusValue.Text = result;
        }

        /// <summary>
        /// The UI will not remain responsive during the execution of the task,
        /// but no DeadLock will occur because the continuation will not be marshalled
        /// back to the original context (which is the UI thread) due to the
        /// ConfigureAwait(false).
        /// </summary>
        private void btnConfigureAwaitNoDeadlock_Click(object sender, EventArgs e)
        {
            var task = this.DoLongRunningTaskConfigureAwait();
            task.Wait();
            labelStatusValue.Text = task.Result;
        }

        /// <summary>
        /// This will cause an exception, because the task will run in the thread pool
        /// and will then, after it finished, continue to update the element in the UI.
        /// Because the update happens in the thread pool thread and not in the UI thread
        /// an "InvalidOperationException: cross-thread operation not valid." will be thrown.
        /// </summary>
        private async void btnExecuteUpdateUIFromBackground_Click(object sender, EventArgs e)
        {
            try
            {
                await this.CallLongRunningTaskAndUpdateUI();
            }
            catch (AggregateException ex)
            {
                labelStatusValue.Text = ex.InnerExceptions[0].Message;
            }
        }

        private async Task<string> DoLongRunningTask()
        {
            labelStatusValue.Text = "Executing...";
            await Task.Delay(TimeSpan.FromSeconds(3));
            return "Finished";
        }

        private async Task<string> DoLongRunningTaskConfigureAwait()
        {
            labelStatusValue.Text = "Executing...";
            await Task.Delay(TimeSpan.FromSeconds(3)).ConfigureAwait(false);
            return "Finished";
        }

        private Task CallLongRunningTaskAndUpdateUI()
        {
            return Task.Run(() => this.DoLongRunningTask().ContinueWith(
                t =>
                    {
                        this.labelStatusValue.Text = t.Result;
                    }));
        }

        static void Main()
        {
            Application.Run(new AsyncFormDeadLock());
        }
    }
}
