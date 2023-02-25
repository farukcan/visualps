using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Visual_PowerShell.Helpers
{
    public static class Prompt
    {
        public static string ShowDialog(string text, string caption,string buttonText= "Save")
        {
            Form prompt = new Form()
            {
                Width = 440,
                Height = 140,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen
            };
            Label textLabel = new Label() { Left = 10, Top = 10, Width = 400, Text = text };
            TextBox textBox = new TextBox() { Left = 10, Top = 30, Width = 400 };
            Button confirmation = new Button() { Text = buttonText, Left = 10, Width = 100, Top = 60, DialogResult = DialogResult.OK };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
        }
    }
}
