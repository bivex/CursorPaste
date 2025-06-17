namespace CursorPaste {
partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose ( bool disposing )
    {
        if ( disposing && ( components != null ) )
            {
                components.Dispose();
        }
        base.Dispose ( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(1200, 600);
        this.Text = "CursorPaste";
        this.snippetTextBox = new System.Windows.Forms.RichTextBox();
        this.insertButton = new System.Windows.Forms.Button();
        this.instructionsLabel = new System.Windows.Forms.Label();
        this.promptsListBox = new System.Windows.Forms.ListBox();
        this.promptNameLabel = new System.Windows.Forms.Label();
        this.promptNameTextBox = new System.Windows.Forms.TextBox();
        this.promptContentLabel = new System.Windows.Forms.Label();
        this.promptContentRichTextBox = new System.Windows.Forms.RichTextBox();
        this.addButton = new System.Windows.Forms.Button();
        this.updateButton = new System.Windows.Forms.Button();
        this.deleteButton = new System.Windows.Forms.Button();
        this.SuspendLayout();
        //
        // snippetTextBox
        //
        this.snippetTextBox.Location = new System.Drawing.Point(550, 50);
        this.snippetTextBox.Name = "snippetTextBox";
        this.snippetTextBox.Size = new System.Drawing.Size(600, 300);
        this.snippetTextBox.TabIndex = 0;
        this.snippetTextBox.Text = "Enter your snippet, template, or phrase here.";
        //
        // insertButton
        //
        this.insertButton.Location = new System.Drawing.Point(550, 370);
        this.insertButton.Name = "insertButton";
        this.insertButton.Size = new System.Drawing.Size(600, 50);
        this.insertButton.TabIndex = 1;
        this.insertButton.Text = "Insert text at cursor";
        this.insertButton.UseVisualStyleBackColor = true;
        this.insertButton.Click += new System.EventHandler(this.insertButton_Click);
        //
        // instructionsLabel
        //
        this.instructionsLabel.AutoSize = true;
        this.instructionsLabel.Location = new System.Drawing.Point(550, 18);
        this.instructionsLabel.Name = "instructionsLabel";
        this.instructionsLabel.Size = new System.Drawing.Size(515, 17);
        this.instructionsLabel.TabIndex = 2;
        this.instructionsLabel.Text = "Paste the text you want to use into the field below, then click the button.";
        //
        // promptsListBox
        //
        this.promptsListBox.FormattingEnabled = true;
        this.promptsListBox.ItemHeight = 16;
        this.promptsListBox.Location = new System.Drawing.Point(12, 50);
        this.promptsListBox.Name = "promptsListBox";
        this.promptsListBox.Size = new System.Drawing.Size(200, 500);
        this.promptsListBox.TabIndex = 3;
        this.promptsListBox.SelectedIndexChanged += new System.EventHandler(this.promptsListBox_SelectedIndexChanged);
        //
        // promptNameLabel
        //
        this.promptNameLabel.AutoSize = true;
        this.promptNameLabel.Location = new System.Drawing.Point(230, 20);
        this.promptNameLabel.Name = "promptNameLabel";
        this.promptNameLabel.Size = new System.Drawing.Size(91, 17);
        this.promptNameLabel.TabIndex = 4;
        this.promptNameLabel.Text = "Prompt Name:";
        //
        // promptNameTextBox
        //
        this.promptNameTextBox.Location = new System.Drawing.Point(230, 40);
        this.promptNameTextBox.Name = "promptNameTextBox";
        this.promptNameTextBox.Size = new System.Drawing.Size(300, 22);
        this.promptNameTextBox.TabIndex = 5;
        //
        // promptContentLabel
        //
        this.promptContentLabel.AutoSize = true;
        this.promptContentLabel.Location = new System.Drawing.Point(230, 80);
        this.promptContentLabel.Name = "promptContentLabel";
        this.promptContentLabel.Size = new System.Drawing.Size(103, 17);
        this.promptContentLabel.TabIndex = 6;
        this.promptContentLabel.Text = "Prompt Content:";
        //
        // promptContentRichTextBox
        //
        this.promptContentRichTextBox.Location = new System.Drawing.Point(230, 100);
        this.promptContentRichTextBox.Name = "promptContentRichTextBox";
        this.promptContentRichTextBox.Size = new System.Drawing.Size(300, 300);
        this.promptContentRichTextBox.TabIndex = 7;
        this.promptContentRichTextBox.Text = "";
        //
        // addButton
        //
        this.addButton.Location = new System.Drawing.Point(230, 420);
        this.addButton.Name = "addButton";
        this.addButton.Size = new System.Drawing.Size(90, 30);
        this.addButton.TabIndex = 8;
        this.addButton.Text = "Add";
        this.addButton.UseVisualStyleBackColor = true;
        this.addButton.Click += new System.EventHandler(this.addButton_Click);
        //
        // updateButton
        //
        this.updateButton.Location = new System.Drawing.Point(330, 420);
        this.updateButton.Name = "updateButton";
        this.updateButton.Size = new System.Drawing.Size(90, 30);
        this.updateButton.TabIndex = 9;
        this.updateButton.Text = "Update";
        this.updateButton.UseVisualStyleBackColor = true;
        this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
        //
        // deleteButton
        //
        this.deleteButton.Location = new System.Drawing.Point(430, 420);
        this.deleteButton.Name = "deleteButton";
        this.deleteButton.Size = new System.Drawing.Size(90, 30);
        this.deleteButton.TabIndex = 10;
        this.deleteButton.Text = "Delete";
        this.deleteButton.UseVisualStyleBackColor = true;
        this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
        //
        // Form1
        //
        this.Controls.Add(this.deleteButton);
        this.Controls.Add(this.updateButton);
        this.Controls.Add(this.addButton);
        this.Controls.Add(this.promptContentRichTextBox);
        this.Controls.Add(this.promptContentLabel);
        this.Controls.Add(this.promptNameTextBox);
        this.Controls.Add(this.promptNameLabel);
        this.Controls.Add(this.promptsListBox);
        this.Controls.Add(this.instructionsLabel);
        this.Controls.Add(this.insertButton);
        this.Controls.Add(this.snippetTextBox);
        this.Name = "Form1";
        this.Text = "CursorPaste";
        this.ResumeLayout(false);
        this.PerformLayout();
        }

        #endregion

    private System.Windows.Forms.RichTextBox snippetTextBox;
    private System.Windows.Forms.Button insertButton;
    private System.Windows.Forms.Label instructionsLabel;
    private System.Windows.Forms.ListBox promptsListBox;
    private System.Windows.Forms.Label promptNameLabel;
    private System.Windows.Forms.TextBox promptNameTextBox;
    private System.Windows.Forms.Label promptContentLabel;
    private System.Windows.Forms.RichTextBox promptContentRichTextBox;
    private System.Windows.Forms.Button addButton;
    private System.Windows.Forms.Button updateButton;
    private System.Windows.Forms.Button deleteButton;
    }
}

