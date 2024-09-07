namespace OficioPersuasivoPenalizable
{
    partial class Form1
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
            btnBuscar = new Button();
            rchTxtBxInfo = new RichTextBox();
            openFileDialog1 = new OpenFileDialog();
            SuspendLayout();
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(49, 8);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(94, 29);
            btnBuscar.TabIndex = 0;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // rchTxtBxInfo
            // 
            rchTxtBxInfo.Location = new Point(49, 43);
            rchTxtBxInfo.Name = "rchTxtBxInfo";
            rchTxtBxInfo.Size = new Size(704, 376);
            rchTxtBxInfo.TabIndex = 1;
            rchTxtBxInfo.Text = "";
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(rchTxtBxInfo);
            Controls.Add(btnBuscar);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button btnBuscar;
        private RichTextBox rchTxtBxInfo;
        private OpenFileDialog openFileDialog1;
    }
}
