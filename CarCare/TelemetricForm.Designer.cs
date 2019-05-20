namespace CarCare
{
    partial class TelemetricForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelGazePointX = new System.Windows.Forms.Label();
            this.labelGazePosY = new System.Windows.Forms.Label();
            this.labelHasGaze = new System.Windows.Forms.Label();
            this.labelGazeStatus = new System.Windows.Forms.Label();
            this.labelPosY = new System.Windows.Forms.Label();
            this.labelPosX = new System.Windows.Forms.Label();
            this.pictureBoxLedsDirection = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLedsDirection)).BeginInit();
            this.SuspendLayout();
            // 
            // labelGazePointX
            // 
            this.labelGazePointX.AutoSize = true;
            this.labelGazePointX.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGazePointX.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.labelGazePointX.Location = new System.Drawing.Point(28, 34);
            this.labelGazePointX.Name = "labelGazePointX";
            this.labelGazePointX.Size = new System.Drawing.Size(271, 37);
            this.labelGazePointX.TabIndex = 0;
            this.labelGazePointX.Text = "Gaze Position X:";
            // 
            // labelGazePosY
            // 
            this.labelGazePosY.AutoSize = true;
            this.labelGazePosY.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGazePosY.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.labelGazePosY.Location = new System.Drawing.Point(28, 89);
            this.labelGazePosY.Name = "labelGazePosY";
            this.labelGazePosY.Size = new System.Drawing.Size(272, 37);
            this.labelGazePosY.TabIndex = 1;
            this.labelGazePosY.Text = "Gaze Position Y:";                 
            // 
            // labelPosY
            // 
            this.labelPosY.AutoSize = true;
            this.labelPosY.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPosY.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.labelPosY.Location = new System.Drawing.Point(305, 89);
            this.labelPosY.Name = "labelPosY";
            this.labelPosY.Size = new System.Drawing.Size(171, 37);
            this.labelPosY.TabIndex = 4;
            this.labelPosY.Text = "UNKOWN";
            // 
            // labelPosX
            // 
            this.labelPosX.AutoSize = true;
            this.labelPosX.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPosX.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.labelPosX.Location = new System.Drawing.Point(305, 34);
            this.labelPosX.Name = "labelPosX";
            this.labelPosX.Size = new System.Drawing.Size(171, 37);
            this.labelPosX.TabIndex = 5;
            this.labelPosX.Text = "UNKOWN";
            // 
            // pictureBoxLedsDirection
            // 
            this.pictureBoxLedsDirection.Image = global::CarCare.Properties.Resources.left_right_green_arrow_icon_svg_hi;
            this.pictureBoxLedsDirection.Location = new System.Drawing.Point(589, 52);
            this.pictureBoxLedsDirection.Name = "pictureBoxLedsDirection";
            this.pictureBoxLedsDirection.Size = new System.Drawing.Size(340, 170);
            this.pictureBoxLedsDirection.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxLedsDirection.TabIndex = 6;
            this.pictureBoxLedsDirection.TabStop = false;
            // 
            // TelemetricForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(987, 301);
            this.Controls.Add(this.pictureBoxLedsDirection);
            this.Controls.Add(this.labelPosX);
            this.Controls.Add(this.labelPosY);
            this.Controls.Add(this.labelGazeStatus);
            this.Controls.Add(this.labelHasGaze);
            this.Controls.Add(this.labelGazePosY);
            this.Controls.Add(this.labelGazePointX);
            this.Name = "TelemetricForm";
            this.Text = "TelemetricForms";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLedsDirection)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelGazePointX;
        private System.Windows.Forms.Label labelGazePosY;
        private System.Windows.Forms.Label labelHasGaze;
        private System.Windows.Forms.Label labelGazeStatus;
        private System.Windows.Forms.Label labelPosY;
        private System.Windows.Forms.Label labelPosX;
        private System.Windows.Forms.PictureBox pictureBoxLedsDirection;
    }
}