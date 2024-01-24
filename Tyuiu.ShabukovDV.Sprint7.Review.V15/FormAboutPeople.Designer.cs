
namespace Tyuiu.ShabukovDV.Sprint7.Review.V15
{
    partial class FormAboutPeople
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.groupBoxStats_SIA = new System.Windows.Forms.GroupBox();
            this.chartDohod_SDV = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.labelMaxDohod_SDV = new System.Windows.Forms.Label();
            this.labelMinDohod_SDV = new System.Windows.Forms.Label();
            this.labelSummDohod_SDV = new System.Windows.Forms.Label();
            this.labelPeople_SDV = new System.Windows.Forms.Label();
            this.textBoxMaxDohod_SDV = new System.Windows.Forms.TextBox();
            this.textBoxMinDohod_SDV = new System.Windows.Forms.TextBox();
            this.textBoxSummDohod_SDV = new System.Windows.Forms.TextBox();
            this.textBoxAmountPeople_SDV = new System.Windows.Forms.TextBox();
            this.groupBoxStats_SIA.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartDohod_SDV)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxStats_SIA
            // 
            this.groupBoxStats_SIA.Controls.Add(this.chartDohod_SDV);
            this.groupBoxStats_SIA.Controls.Add(this.labelMaxDohod_SDV);
            this.groupBoxStats_SIA.Controls.Add(this.labelMinDohod_SDV);
            this.groupBoxStats_SIA.Controls.Add(this.labelSummDohod_SDV);
            this.groupBoxStats_SIA.Controls.Add(this.labelPeople_SDV);
            this.groupBoxStats_SIA.Controls.Add(this.textBoxMaxDohod_SDV);
            this.groupBoxStats_SIA.Controls.Add(this.textBoxMinDohod_SDV);
            this.groupBoxStats_SIA.Controls.Add(this.textBoxSummDohod_SDV);
            this.groupBoxStats_SIA.Controls.Add(this.textBoxAmountPeople_SDV);
            this.groupBoxStats_SIA.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBoxStats_SIA.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBoxStats_SIA.Location = new System.Drawing.Point(2, 0);
            this.groupBoxStats_SIA.Name = "groupBoxStats_SIA";
            this.groupBoxStats_SIA.Size = new System.Drawing.Size(798, 450);
            this.groupBoxStats_SIA.TabIndex = 2;
            this.groupBoxStats_SIA.TabStop = false;
            this.groupBoxStats_SIA.Text = "Статистика";
            // 
            // chartDohod_SDV
            // 
            chartArea1.Name = "ChartArea1";
            this.chartDohod_SDV.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartDohod_SDV.Legends.Add(legend1);
            this.chartDohod_SDV.Location = new System.Drawing.Point(172, 12);
            this.chartDohod_SDV.Name = "chartDohod_SDV";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartDohod_SDV.Series.Add(series1);
            this.chartDohod_SDV.Size = new System.Drawing.Size(614, 426);
            this.chartDohod_SDV.TabIndex = 29;
            this.chartDohod_SDV.Text = "chart1";
            this.chartDohod_SDV.Click += new System.EventHandler(this.chartDohod_SDV_Click);
            // 
            // labelMaxDohod_SDV
            // 
            this.labelMaxDohod_SDV.AutoSize = true;
            this.labelMaxDohod_SDV.Location = new System.Drawing.Point(27, 292);
            this.labelMaxDohod_SDV.Name = "labelMaxDohod_SDV";
            this.labelMaxDohod_SDV.Size = new System.Drawing.Size(99, 18);
            this.labelMaxDohod_SDV.TabIndex = 28;
            this.labelMaxDohod_SDV.Text = "Макс. Оклад";
            // 
            // labelMinDohod_SDV
            // 
            this.labelMinDohod_SDV.AutoSize = true;
            this.labelMinDohod_SDV.Location = new System.Drawing.Point(33, 217);
            this.labelMinDohod_SDV.Name = "labelMinDohod_SDV";
            this.labelMinDohod_SDV.Size = new System.Drawing.Size(91, 18);
            this.labelMinDohod_SDV.TabIndex = 27;
            this.labelMinDohod_SDV.Text = "Мин. Оклад";
            // 
            // labelSummDohod_SDV
            // 
            this.labelSummDohod_SDV.AutoSize = true;
            this.labelSummDohod_SDV.Location = new System.Drawing.Point(27, 141);
            this.labelSummDohod_SDV.Name = "labelSummDohod_SDV";
            this.labelSummDohod_SDV.Size = new System.Drawing.Size(102, 18);
            this.labelSummDohod_SDV.TabIndex = 26;
            this.labelSummDohod_SDV.Text = "Сумм. Оклад";
            // 
            // labelPeople_SDV
            // 
            this.labelPeople_SDV.AutoSize = true;
            this.labelPeople_SDV.Location = new System.Drawing.Point(33, 67);
            this.labelPeople_SDV.Name = "labelPeople_SDV";
            this.labelPeople_SDV.Size = new System.Drawing.Size(91, 18);
            this.labelPeople_SDV.TabIndex = 25;
            this.labelPeople_SDV.Text = "Кол-во чел.";
            // 
            // textBoxMaxDohod_SDV
            // 
            this.textBoxMaxDohod_SDV.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxMaxDohod_SDV.Location = new System.Drawing.Point(16, 313);
            this.textBoxMaxDohod_SDV.Name = "textBoxMaxDohod_SDV";
            this.textBoxMaxDohod_SDV.ReadOnly = true;
            this.textBoxMaxDohod_SDV.Size = new System.Drawing.Size(125, 24);
            this.textBoxMaxDohod_SDV.TabIndex = 24;
            // 
            // textBoxMinDohod_SDV
            // 
            this.textBoxMinDohod_SDV.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxMinDohod_SDV.Location = new System.Drawing.Point(16, 237);
            this.textBoxMinDohod_SDV.Name = "textBoxMinDohod_SDV";
            this.textBoxMinDohod_SDV.ReadOnly = true;
            this.textBoxMinDohod_SDV.Size = new System.Drawing.Size(125, 24);
            this.textBoxMinDohod_SDV.TabIndex = 23;
            // 
            // textBoxSummDohod_SDV
            // 
            this.textBoxSummDohod_SDV.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxSummDohod_SDV.Location = new System.Drawing.Point(16, 162);
            this.textBoxSummDohod_SDV.Name = "textBoxSummDohod_SDV";
            this.textBoxSummDohod_SDV.ReadOnly = true;
            this.textBoxSummDohod_SDV.Size = new System.Drawing.Size(125, 24);
            this.textBoxSummDohod_SDV.TabIndex = 22;
            // 
            // textBoxAmountPeople_SDV
            // 
            this.textBoxAmountPeople_SDV.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxAmountPeople_SDV.Location = new System.Drawing.Point(16, 88);
            this.textBoxAmountPeople_SDV.Name = "textBoxAmountPeople_SDV";
            this.textBoxAmountPeople_SDV.ReadOnly = true;
            this.textBoxAmountPeople_SDV.Size = new System.Drawing.Size(125, 24);
            this.textBoxAmountPeople_SDV.TabIndex = 18;
            // 
            // FormAboutPeople
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBoxStats_SIA);
            this.Name = "FormAboutPeople";
            this.Text = "Статик";
            this.Load += new System.EventHandler(this.FormAboutPeople_Load);
            this.groupBoxStats_SIA.ResumeLayout(false);
            this.groupBoxStats_SIA.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartDohod_SDV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxStats_SIA;
        private System.Windows.Forms.Label labelMaxDohod_SDV;
        private System.Windows.Forms.Label labelMinDohod_SDV;
        private System.Windows.Forms.Label labelSummDohod_SDV;
        private System.Windows.Forms.Label labelPeople_SDV;
        private System.Windows.Forms.TextBox textBoxMaxDohod_SDV;
        private System.Windows.Forms.TextBox textBoxMinDohod_SDV;
        private System.Windows.Forms.TextBox textBoxSummDohod_SDV;
        private System.Windows.Forms.TextBox textBoxAmountPeople_SDV;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartDohod_SDV;
    }
}