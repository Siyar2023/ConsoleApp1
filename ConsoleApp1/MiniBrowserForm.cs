using System;
using System.Windows.Forms;

namespace MiniWebbrowser
{
    public partial class MiniBrowserForm : Form
    {
        // Declaring private fields for UI elements
        private WebBrowser _webBrowser;   // WebBrowser control to display the web page
        private TextBox _urlBox;          // TextBox for entering URLs
        private Button _goButton;         // Button to navigate to the entered URL
        private Button _backButton;       // Button to go back in the browsing history
        private Button _forwardButton;    // Button to go forward in the browsing history
        private Button _homeButton;       // Button to navigate to the home page (Google)

        // Constructor to initialize the form and controls
        public MiniBrowserForm()
        {
            // Set the title of the window
            this.Text = "Mini Web Browser";
            // Set the dimensions of the window
            this.Width = 900;
            this.Height = 600;

            // Create and configure the URL textbox
            _urlBox = new TextBox { Left = 10, Top = 10, Width = 600 };
            // Add the textbox to the form's controls
            this.Controls.Add(_urlBox);

            // Create and configure the "Go" button
            _goButton = new Button { Left = 620, Top = 10, Text = "Go", Width = 50 };
            // Define what happens when the "Go" button is clicked
            _goButton.Click += (sender, args) =>
            {
                if (!string.IsNullOrEmpty(_urlBox.Text)) // Check if the URL textbox is not empty
                {
                    // Navigate the WebBrowser control to the entered URL
                    _webBrowser.Navigate(_urlBox.Text);
                }
            };
            // Add the "Go" button to the form's controls
            this.Controls.Add(_goButton);

            // Create and configure the "Back" button
            _backButton = new Button { Left = 680, Top = 10, Text = "Back", Width = 50 };
            // Define what happens when the "Back" button is clicked
            _backButton.Click += (sender, args) =>
            {
                // Check if the WebBrowser can go back in history
                if (_webBrowser.CanGoBack)
                {
                    // Navigate back in the WebBrowser's history
                    _webBrowser.GoBack();
                }
            };
            // Add the "Back" button to the form's controls
            this.Controls.Add(_backButton);

            // Create and configure the "Forward" button
            _forwardButton = new Button { Left = 740, Top = 10, Text = "Forward", Width = 60 };
            // Define what happens when the "Forward" button is clicked
            _forwardButton.Click += (sender, args) =>
            {
                // Check if the WebBrowser can go forward in history
                if (_webBrowser.CanGoForward)
                {
                    // Navigate forward in the WebBrowser's history
                    _webBrowser.GoForward();
                }
            };
            // Add the "Forward" button to the form's controls
            this.Controls.Add(_forwardButton);

            // Create and configure the "Home" button
            _homeButton = new Button { Left = 810, Top = 10, Text = "Home", Width = 50 };
            // Define what happens when the "Home" button is clicked
            _homeButton.Click += (sender, args) =>
            {
                // Navigate to Google's homepage when the "Home" button is clicked
                _webBrowser.Navigate("https://www.google.com");
            };
            // Add the "Home" button to the form's controls
            this.Controls.Add(_homeButton);

            // Create and configure the WebBrowser control
            _webBrowser = new WebBrowser { Left = 10, Top = 50, Width = 760, Height = 500 };
            // Suppress script errors to prevent them from displaying on the screen
            _webBrowser.ScriptErrorsSuppressed = true;
            // Add the WebBrowser control to the form's controls
            this.Controls.Add(_webBrowser);

            // Navigate to a test URL (Google homepage) when the form loads
            _webBrowser.Navigate("https://www.google.com");

            // Event handler to update the URL textbox when the web page finishes loading
            _webBrowser.Navigated += (sender, args) =>
            {
                // Update the URL textbox with the current page URL
                _urlBox.Text = _webBrowser.Url.ToString();
            };
        }
    }
}
