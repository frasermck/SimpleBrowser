using System.ComponentModel.Design;

namespace SimpleBrowser
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private async Task initialized()
        {
            await webView21.EnsureCoreWebView2Async(null);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            webView21.CoreWebView2.GoBack();
        }

        private void btnForward_Click(object sender, EventArgs e)
        {
            webView21.CoreWebView2.GoForward();
        }

        private async void btnGo_Click(object sender, EventArgs e)
        {
            if (urlBox.Text != "")
            {
                await initialized();
                webView21.CoreWebView2.Navigate("http://" + urlBox.Text);
            }
        }

        private void webView21_NavigationCompleted(object sender, Microsoft.Web.WebView2.Core.CoreWebView2NavigationCompletedEventArgs e)
        {
            frmMain.ActiveForm.Text = "SimpleBrowser | " + webView21.CoreWebView2.DocumentTitle;
        }

        private void cboLocation_Click(object sender, EventArgs e)
        {

        }

        private async void urlBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (urlBox.Text != "")
                {
                    await initialized();
                    webView21.CoreWebView2.Navigate("http://" + urlBox.Text);
                }
            }
        }
    }

}