﻿using System.Windows.Forms;

namespace Visual_PowerShell.Helpers
{
    public static class Prompt
    {
        class PromptForm : Form
        {
            protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
            {
                switch (keyData)
                {
                    case Keys.Escape:
                        this.Close();
                        break;
                }
                return base.ProcessCmdKey(ref msg, keyData);
            }
        }
        public static (bool, string) ShowDialog(string text, string caption, string buttonText = "Save", string defaultvalue = "")
        {
            Form prompt = new PromptForm()
            {
                Width = 440,
                Height = 140,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen,
            };
            Label textLabel = new Label() { Left = 10, Top = 10, Width = 400, Text = text };
            TextBox textBox = new TextBox() { Left = 10, Top = 30, Width = 400, Text = defaultvalue };
            Button confirmation = new Button() { Text = buttonText, Left = 10, Width = 100, Top = 60, DialogResult = DialogResult.OK };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;
            return (prompt.ShowDialog() == DialogResult.OK, textBox.Text);
        }
    }
}
