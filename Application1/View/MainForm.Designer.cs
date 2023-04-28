namespace Application1
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            inputLabel = new Label();
            textBox = new TextBox();
            messagesTextBox = new TextBox();
            sendButton = new Button();
            timer = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // inputLabel
            // 
            inputLabel.AutoSize = true;
            inputLabel.Location = new Point(12, 13);
            inputLabel.Name = "inputLabel";
            inputLabel.Size = new Size(35, 15);
            inputLabel.TabIndex = 0;
            inputLabel.Text = "Input";
            // 
            // textBox
            // 
            textBox.Location = new Point(53, 9);
            textBox.Name = "textBox";
            textBox.Size = new Size(189, 23);
            textBox.TabIndex = 1;
            // 
            // messagesTextBox
            // 
            messagesTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            messagesTextBox.Location = new Point(12, 38);
            messagesTextBox.Multiline = true;
            messagesTextBox.Name = "messagesTextBox";
            messagesTextBox.Size = new Size(561, 304);
            messagesTextBox.TabIndex = 2;
            // 
            // sendButton
            // 
            sendButton.Location = new Point(248, 9);
            sendButton.Name = "sendButton";
            sendButton.Size = new Size(75, 23);
            sendButton.TabIndex = 3;
            sendButton.Text = "Send";
            sendButton.UseVisualStyleBackColor = true;
            sendButton.Click += sendButton_Click;
            // 
            // timer
            // 
            timer.Enabled = true;
            timer.Tick += timer_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(585, 354);
            Controls.Add(sendButton);
            Controls.Add(messagesTextBox);
            Controls.Add(textBox);
            Controls.Add(inputLabel);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label inputLabel;
        private TextBox textBox;
        private TextBox messagesTextBox;
        private Button sendButton;
        private System.Windows.Forms.Timer timer;
    }
}