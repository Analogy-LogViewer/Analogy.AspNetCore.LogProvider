namespace Analogy.LogServer.Tests
{
    partial class TestForm
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
            btnProducer = new System.Windows.Forms.Button();
            txtIP = new System.Windows.Forms.TextBox();
            btnProducerLogger = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // btnProducer
            // 
            btnProducer.Location = new System.Drawing.Point(15, 12);
            btnProducer.Name = "btnProducer";
            btnProducer.Size = new System.Drawing.Size(166, 54);
            btnProducer.TabIndex = 0;
            btnProducer.Text = "Produce Messages";
            btnProducer.UseVisualStyleBackColor = true;
            btnProducer.Click += btnProducer_Click;
            // 
            // txtIP
            // 
            txtIP.Location = new System.Drawing.Point(199, 22);
            txtIP.Name = "txtIP";
            txtIP.Size = new System.Drawing.Size(368, 27);
            txtIP.TabIndex = 1;
            txtIP.Text = "localhost:50222";
            // 
            // btnProducerLogger
            // 
            btnProducerLogger.Location = new System.Drawing.Point(15, 72);
            btnProducerLogger.Name = "btnProducerLogger";
            btnProducerLogger.Size = new System.Drawing.Size(166, 54);
            btnProducerLogger.TabIndex = 0;
            btnProducerLogger.Text = "Produce Messages Via Logger";
            btnProducerLogger.UseVisualStyleBackColor = true;
            btnProducerLogger.Click += btnProducerViaLogger_Click;
            // 
            // TestForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(585, 163);
            Controls.Add(btnProducerLogger);
            Controls.Add(txtIP);
            Controls.Add(btnProducer);
            Name = "TestForm";
            Text = "Analogy Log Server Message producer Example";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button btnProducer;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Button btnProducerLogger;
    }
}

