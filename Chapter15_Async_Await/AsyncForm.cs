using System.Windows.Forms;

namespace Chapter15_Async_Await
{
    using System;
    using System.ComponentModel;
    using System.Globalization;
    using System.Net.Http;

    [Description("Async Call from Form")]
    public partial class AsyncForm : Form
    {
        public AsyncForm()
        {
            InitializeComponent();
            btnFetchLength.Click += this.GetLength;
        }

        private async void GetLength(object sender, EventArgs e)
        {
            using (HttpClient client = new HttpClient())
            {
                lblLengthValue.Text = "Fetching ...";
                string result = await client.GetStringAsync("http://www.google.ch/");
                lblLengthValue.Text = result.Length.ToString(CultureInfo.InvariantCulture);
            }
        }

        static void Main()
        {
            Application.Run(new AsyncForm());
        }
    }
}
