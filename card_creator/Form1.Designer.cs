namespace card_creator
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
            label1 = new Label();
            titleInput = new TextBox();
            subtitle1Input = new TextBox();
            label2 = new Label();
            subtitle2Input = new TextBox();
            label3 = new Label();
            flagsButton = new Button();
            iconButton = new Button();
            generateButton = new Button();
            saveFileDialog1 = new SaveFileDialog();
            openFileDialog1 = new OpenFileDialog();
            iconDisplay = new PictureBox();
            label4 = new Label();
            languageCombo = new ComboBox();
            color2preview = new PictureBox();
            color1preview = new PictureBox();
            R1 = new TextBox();
            label5 = new Label();
            label6 = new Label();
            G1 = new TextBox();
            label7 = new Label();
            B1 = new TextBox();
            label10 = new Label();
            B2 = new TextBox();
            label9 = new Label();
            G2 = new TextBox();
            label8 = new Label();
            R2 = new TextBox();
            gradientPreview = new PictureBox();
            label11 = new Label();
            ((System.ComponentModel.ISupportInitialize)iconDisplay).BeginInit();
            ((System.ComponentModel.ISupportInitialize)color2preview).BeginInit();
            ((System.ComponentModel.ISupportInitialize)color1preview).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gradientPreview).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 15);
            label1.Name = "label1";
            label1.Size = new Size(29, 15);
            label1.TabIndex = 0;
            label1.Text = "Title";
            // 
            // titleInput
            // 
            titleInput.Location = new Point(95, 12);
            titleInput.Name = "titleInput";
            titleInput.Size = new Size(175, 23);
            titleInput.TabIndex = 1;
            // 
            // subtitle1Input
            // 
            subtitle1Input.Location = new Point(95, 41);
            subtitle1Input.Name = "subtitle1Input";
            subtitle1Input.Size = new Size(175, 23);
            subtitle1Input.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 44);
            label2.Name = "label2";
            label2.Size = new Size(56, 15);
            label2.TabIndex = 2;
            label2.Text = "Subtitle 1";
            // 
            // subtitle2Input
            // 
            subtitle2Input.Location = new Point(95, 70);
            subtitle2Input.Name = "subtitle2Input";
            subtitle2Input.Size = new Size(175, 23);
            subtitle2Input.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 73);
            label3.Name = "label3";
            label3.Size = new Size(56, 15);
            label3.TabIndex = 4;
            label3.Text = "Subtitle 2";
            // 
            // flagsButton
            // 
            flagsButton.Location = new Point(13, 153);
            flagsButton.Name = "flagsButton";
            flagsButton.Size = new Size(258, 23);
            flagsButton.TabIndex = 5;
            flagsButton.Text = "Select Sub-Images";
            flagsButton.UseVisualStyleBackColor = true;
            flagsButton.Click += flagsButton_Click;
            // 
            // iconButton
            // 
            iconButton.Location = new Point(12, 99);
            iconButton.Name = "iconButton";
            iconButton.Size = new Size(258, 23);
            iconButton.TabIndex = 4;
            iconButton.Text = "Select Icon";
            iconButton.UseVisualStyleBackColor = true;
            iconButton.Click += iconButton_Click;
            // 
            // generateButton
            // 
            generateButton.Location = new Point(12, 436);
            generateButton.Name = "generateButton";
            generateButton.Size = new Size(258, 23);
            generateButton.TabIndex = 12;
            generateButton.Text = "Generate Card";
            generateButton.UseVisualStyleBackColor = true;
            generateButton.Click += generateButton_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // iconDisplay
            // 
            iconDisplay.BackColor = SystemColors.ControlLightLight;
            iconDisplay.Location = new Point(276, 12);
            iconDisplay.Name = "iconDisplay";
            iconDisplay.Size = new Size(450, 450);
            iconDisplay.TabIndex = 9;
            iconDisplay.TabStop = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 471);
            label4.Name = "label4";
            label4.Size = new Size(157, 15);
            label4.TabIndex = 14;
            label4.Text = "Created by Elite Watermelon";
            // 
            // languageCombo
            // 
            languageCombo.FormattingEnabled = true;
            languageCombo.Items.AddRange(new object[] { "English", "日本語", "Español" });
            languageCombo.Location = new Point(605, 468);
            languageCombo.Name = "languageCombo";
            languageCombo.Size = new Size(121, 23);
            languageCombo.TabIndex = 13;
            languageCombo.SelectedIndexChanged += languageCombo_SelectedIndexChanged;
            // 
            // color2preview
            // 
            color2preview.BackColor = SystemColors.ControlLightLight;
            color2preview.Location = new Point(195, 211);
            color2preview.Name = "color2preview";
            color2preview.Size = new Size(76, 23);
            color2preview.TabIndex = 18;
            color2preview.TabStop = false;
            // 
            // color1preview
            // 
            color1preview.BackColor = SystemColors.ControlLightLight;
            color1preview.Location = new Point(195, 182);
            color1preview.Name = "color1preview";
            color1preview.Size = new Size(76, 23);
            color1preview.TabIndex = 17;
            color1preview.TabStop = false;
            // 
            // R1
            // 
            R1.Location = new Point(33, 182);
            R1.Name = "R1";
            R1.Size = new Size(30, 23);
            R1.TabIndex = 6;
            R1.Text = "0";
            R1.TextChanged += R1_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(13, 185);
            label5.Name = "label5";
            label5.Size = new Size(14, 15);
            label5.TabIndex = 20;
            label5.Text = "R";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(76, 185);
            label6.Name = "label6";
            label6.Size = new Size(15, 15);
            label6.TabIndex = 22;
            label6.Text = "G";
            // 
            // G1
            // 
            G1.Location = new Point(96, 182);
            G1.Name = "G1";
            G1.Size = new Size(30, 23);
            G1.TabIndex = 7;
            G1.Text = "0";
            G1.TextChanged += G1_TextChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(139, 185);
            label7.Name = "label7";
            label7.Size = new Size(14, 15);
            label7.TabIndex = 26;
            label7.Text = "B";
            // 
            // B1
            // 
            B1.Location = new Point(159, 182);
            B1.Name = "B1";
            B1.Size = new Size(30, 23);
            B1.TabIndex = 8;
            B1.Text = "0";
            B1.TextChanged += B1_TextChanged;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(139, 214);
            label10.Name = "label10";
            label10.Size = new Size(14, 15);
            label10.TabIndex = 32;
            label10.Text = "B";
            // 
            // B2
            // 
            B2.Location = new Point(159, 211);
            B2.Name = "B2";
            B2.Size = new Size(30, 23);
            B2.TabIndex = 11;
            B2.Text = "0";
            B2.TextChanged += B2_TextChanged;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(76, 214);
            label9.Name = "label9";
            label9.Size = new Size(15, 15);
            label9.TabIndex = 30;
            label9.Text = "G";
            // 
            // G2
            // 
            G2.Location = new Point(96, 211);
            G2.Name = "G2";
            G2.Size = new Size(30, 23);
            G2.TabIndex = 10;
            G2.Text = "0";
            G2.TextChanged += G2_TextChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(13, 214);
            label8.Name = "label8";
            label8.Size = new Size(14, 15);
            label8.TabIndex = 28;
            label8.Text = "R";
            // 
            // R2
            // 
            R2.Location = new Point(33, 211);
            R2.Name = "R2";
            R2.Size = new Size(30, 23);
            R2.TabIndex = 9;
            R2.Text = "0";
            R2.TextChanged += R2_TextChanged;
            // 
            // gradientPreview
            // 
            gradientPreview.BackColor = SystemColors.ControlLightLight;
            gradientPreview.Location = new Point(13, 240);
            gradientPreview.Name = "gradientPreview";
            gradientPreview.Size = new Size(258, 23);
            gradientPreview.TabIndex = 33;
            gradientPreview.TabStop = false;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(13, 125);
            label11.Name = "label11";
            label11.Size = new Size(175, 15);
            label11.TabIndex = 34;
            label11.Text = "Recommended image size is 1:1";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(734, 494);
            Controls.Add(label11);
            Controls.Add(gradientPreview);
            Controls.Add(label10);
            Controls.Add(B2);
            Controls.Add(label9);
            Controls.Add(G2);
            Controls.Add(label8);
            Controls.Add(R2);
            Controls.Add(label7);
            Controls.Add(B1);
            Controls.Add(label6);
            Controls.Add(G1);
            Controls.Add(label5);
            Controls.Add(R1);
            Controls.Add(color2preview);
            Controls.Add(color1preview);
            Controls.Add(languageCombo);
            Controls.Add(label4);
            Controls.Add(iconDisplay);
            Controls.Add(generateButton);
            Controls.Add(iconButton);
            Controls.Add(flagsButton);
            Controls.Add(subtitle2Input);
            Controls.Add(label3);
            Controls.Add(subtitle1Input);
            Controls.Add(label2);
            Controls.Add(titleInput);
            Controls.Add(label1);
            MaximizeBox = false;
            Name = "Form1";
            Text = "Card Creator";
            ((System.ComponentModel.ISupportInitialize)iconDisplay).EndInit();
            ((System.ComponentModel.ISupportInitialize)color2preview).EndInit();
            ((System.ComponentModel.ISupportInitialize)color1preview).EndInit();
            ((System.ComponentModel.ISupportInitialize)gradientPreview).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox titleInput;
        private TextBox subtitle1Input;
        private Label label2;
        private TextBox subtitle2Input;
        private Label label3;
        private Button flagsButton;
        private Button iconButton;
        private Button generateButton;
        private SaveFileDialog saveFileDialog1;
        private OpenFileDialog openFileDialog1;
        private PictureBox iconDisplay;
        private Label label4;
        private ComboBox languageCombo;
        private PictureBox color2preview;
        private PictureBox color1preview;
        private TextBox R1;
        private Label label5;
        private Label label6;
        private TextBox G1;
        private Label label7;
        private TextBox B1;
        private Label label10;
        private TextBox B2;
        private Label label9;
        private TextBox G2;
        private Label label8;
        private TextBox R2;
        private PictureBox gradientPreview;
        private Label label11;
    }
}