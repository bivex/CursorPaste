using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CursorPaste {
public partial class Form1 : Form {
    public Form1()
    {
        InitializeComponent();
    }

    private void insertButton_Click ( object sender, EventArgs e )
    {
        // Get the text from the RichTextBox
        string textToInsert = snippetTextBox.Text;

        // Disable the button to prevent recursive calls
        insertButton.Enabled = false;

        // Hide the form temporarily to allow SendKeys to work on other applications
        this.Hide();

        // Add a small delay to ensure the focus shifts to the target application
        System.Threading.Thread.Sleep ( 200 );

        // Send the text to the current cursor position
        SendKeys.SendWait ( textToInsert );

        // Show the form again and re-enable the button
        this.Show();
        this.Activate();
        insertButton.Enabled = true;
    }
}
}
