using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CursorPaste;
using System.IO;
using System.Diagnostics;

namespace CursorPaste {
public partial class Form1 : Form {
    private readonly PromptManager _promptManager;
    private AppSettings _appSettings;

    public Form1()
    {
        InitializeComponent();
        try
        {
            _promptManager = new PromptManager();
            LoadPromptsToListBox();

            // Load settings and apply to checkbox
            _appSettings = AppSettings.Load();
            sendOnEnterCheckBox.Checked = _appSettings.SendOnEnter;

            // Attach event handler for checkbox change to save settings
            sendOnEnterCheckBox.CheckedChanged += SendOnEnterCheckBox_CheckedChanged;

            // Attach FormClosing event handler to save settings
            this.FormClosing += Form1_FormClosing;
        }
        catch (IOException ex)
        {
            MessageBox.Show($"Error initializing prompts: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            // Optionally, disable functionality that relies on prompts or exit the application
            this.Close(); // Close the application if prompts cannot be loaded
        }
    }

    private async void InsertButton_Click ( object sender, EventArgs e )
    {
        // Get the text from the RichTextBox
        string textToInsert = snippetTextBox.Text;

        // If the "Send on Enter" checkbox is checked, append an Enter key press
        if (sendOnEnterCheckBox.Checked)
        {
            textToInsert += "{ENTER}";
            Debug.WriteLine("InsertButton_Click: Appending {ENTER} to the text to insert.");
        }

        Debug.WriteLine($"InsertButton_Click: Attempting to insert text: \"{textToInsert}\"");

        // Disable the button to prevent recursive calls
        insertButton.Enabled = false;

        // Ensure the snippetTextBox loses focus before hiding the form
        // This might help in ensuring the SendKeys targets the correct external application
        this.ActiveControl = null; // Remove focus from any control on the form

        // Hide the form temporarily to allow SendKeys to work on other applications
        this.Hide();

        // Add a small delay to ensure the focus shifts to the target application
        await Task.Delay ( 200 );

        // Send the text to the current cursor position
        SendKeys.SendWait ( textToInsert );

        // Show the form again and re-enable the button
        this.Show();
        this.Activate();
        insertButton.Enabled = true;
        Debug.WriteLine("InsertButton_Click: Text insertion process completed.");
    }

    private void SnippetTextBox_KeyDown(object sender, KeyEventArgs e)
    {
        Debug.WriteLine($"SnippetTextBox_KeyDown: KeyCode = {e.KeyCode}, SendOnEnterChecked = {sendOnEnterCheckBox.Checked}");
        if (e.KeyCode == Keys.Enter && sendOnEnterCheckBox.Checked)
        {
            Debug.WriteLine("SnippetTextBox_KeyDown: Enter key pressed and Send on Enter is checked. Triggering InsertButton_Click.");
            InsertButton_Click(this, EventArgs.Empty);
            e.Handled = true; // Prevent the default Enter key behavior (e.g., new line)
            e.SuppressKeyPress = true; // Suppress further key processing
        }
    }

    private void LoadPromptsToListBox()
    {
        promptsListBox.DataSource = null;
        promptsListBox.DataSource = _promptManager.Prompts.ToList();
        promptsListBox.DisplayMember = "Name"; // Display the Name property in the ListBox
        promptsListBox.ValueMember = "Content"; // Use Content as the value (optional, but good practice)
    }

    private void PromptsListBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (promptsListBox.SelectedItem is Prompt selectedPrompt)
        {
            promptNameTextBox.Text = selectedPrompt.Name;
            promptContentRichTextBox.Text = selectedPrompt.Content;
            snippetTextBox.Text = selectedPrompt.Content; // Also set the insert snippet box
        }
    }

    private void AddButton_Click(object sender, EventArgs e)
    {
        try
        {
            string name = promptNameTextBox.Text.Trim();
            string content = promptContentRichTextBox.Text;

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Prompt name cannot be empty.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Prompt newPrompt = new Prompt(name, content);
            _promptManager.AddPrompt(newPrompt);
            LoadPromptsToListBox();
            ClearPromptInputFields();
            MessageBox.Show("Prompt added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (ArgumentException ex)
        {
            MessageBox.Show(ex.Message, "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        catch (IOException ex)
        {
            MessageBox.Show($"Error saving prompt: {ex.Message}", "File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"An unexpected error occurred while adding the prompt: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void UpdateButton_Click(object sender, EventArgs e)
    {
        Prompt selectedPrompt = promptsListBox.SelectedItem as Prompt;
        if (selectedPrompt == null)
        {
            MessageBox.Show("Please select a prompt to update.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        try
        {
            string originalName = selectedPrompt.Name;
            string newName = promptNameTextBox.Text.Trim();
            string newContent = promptContentRichTextBox.Text;

            if (string.IsNullOrWhiteSpace(newName))
            {
                MessageBox.Show("Prompt name cannot be empty.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Prompt updatedPrompt = new Prompt(newName, newContent);
            _promptManager.UpdatePrompt(originalName, updatedPrompt);
            LoadPromptsToListBox();
            ClearPromptInputFields();
            MessageBox.Show("Prompt updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (ArgumentException ex)
        {
            MessageBox.Show(ex.Message, "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        catch (KeyNotFoundException ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        catch (IOException ex)
        {
            MessageBox.Show($"Error saving prompt updates: {ex.Message}", "File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"An unexpected error occurred while updating the prompt: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void DeleteButton_Click(object sender, EventArgs e)
    {
        Prompt selectedPrompt = promptsListBox.SelectedItem as Prompt;
        if (selectedPrompt == null)
        {
            MessageBox.Show("Please select a prompt to delete.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this prompt?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (dialogResult == DialogResult.Yes)
        {
            try
            {
                _promptManager.DeletePrompt(selectedPrompt.Name);
                LoadPromptsToListBox();
                ClearPromptInputFields();
                MessageBox.Show("Prompt deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (KeyNotFoundException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (IOException ex)
            {
                MessageBox.Show($"Error deleting prompt: {ex.Message}", "File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred while deleting the prompt: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    private void ClearPromptInputFields()
    {
        promptNameTextBox.Text = string.Empty;
        promptContentRichTextBox.Text = string.Empty;
        snippetTextBox.Text = string.Empty;
    }

    private void SendOnEnterCheckBox_CheckedChanged(object sender, EventArgs e)
    {
        // Update the setting and save it
        _appSettings.SendOnEnter = sendOnEnterCheckBox.Checked;
        _appSettings.Save();
        Debug.WriteLine($"AppSettings: SendOnEnter set to {_appSettings.SendOnEnter} and saved.");
    }

    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
        // Save settings when the form is closing
        _appSettings.Save();
        Debug.WriteLine("AppSettings: Settings saved on form closing.");
    }
}
}
