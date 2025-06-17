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
        this.ClientSize = new System.Drawing.Size ( 800, 450 );
        this.Text = "CursorPaste";
        this.snippetTextBox = new System.Windows.Forms.RichTextBox();
        this.insertButton = new System.Windows.Forms.Button();
        this.instructionsLabel = new System.Windows.Forms.Label();
        this.SuspendLayout();
        //
        // snippetTextBox
        //
        this.snippetTextBox.Location = new System.Drawing.Point ( 12, 50 );
        this.snippetTextBox.Name = "snippetTextBox";
        this.snippetTextBox.Size = new System.Drawing.Size ( 776, 300 );
        this.snippetTextBox.TabIndex = 0;
        this.snippetTextBox.Text = "Enter your snippet, template, or phrase here.";
        //
        // insertButton
        //
        this.insertButton.Location = new System.Drawing.Point ( 12, 370 );
        this.insertButton.Name = "insertButton";
        this.insertButton.Size = new System.Drawing.Size ( 776, 50 );
        this.insertButton.TabIndex = 1;
        this.insertButton.Text = "Insert text at cursor";
        this.insertButton.UseVisualStyleBackColor = true;
        this.insertButton.Click += new System.EventHandler ( this.insertButton_Click );
        //
        // instructionsLabel
        //
        this.instructionsLabel.AutoSize = true;
        this.instructionsLabel.Location = new System.Drawing.Point ( 12, 18 );
        this.instructionsLabel.Name = "instructionsLabel";
        this.instructionsLabel.Size = new System.Drawing.Size ( 515, 17 );
        this.instructionsLabel.TabIndex = 2;
        this.instructionsLabel.Text = "Paste the text you want to use into the field below, then click the button.";
        //
        // Form1
        //
        this.Controls.Add ( this.instructionsLabel );
        this.Controls.Add ( this.insertButton );
        this.Controls.Add ( this.snippetTextBox );
        this.ResumeLayout ( false );
        this.PerformLayout();
    }

    #endregion

    private System.Windows.Forms.RichTextBox snippetTextBox;
    private System.Windows.Forms.Button insertButton;
    private System.Windows.Forms.Label instructionsLabel;
}
}

