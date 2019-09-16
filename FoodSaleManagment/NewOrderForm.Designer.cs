namespace FoodSaleManagment
{
    partial class NewOrderForm
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
            this.label3 = new System.Windows.Forms.Label();
            this.cIdCbo = new System.Windows.Forms.ComboBox();
            this.odDtp = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.oiTxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.dgOrderItems = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.fiCbo = new System.Windows.Forms.ComboBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.bAddToOrder = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.totalLbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgOrderItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(65, 109);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 20);
            this.label3.TabIndex = 11;
            this.label3.Text = "Customer:";
            // 
            // cIdCbo
            // 
            this.cIdCbo.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cIdCbo.FormattingEnabled = true;
            this.cIdCbo.Location = new System.Drawing.Point(153, 109);
            this.cIdCbo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cIdCbo.Name = "cIdCbo";
            this.cIdCbo.Size = new System.Drawing.Size(244, 28);
            this.cIdCbo.TabIndex = 10;
            // 
            // odDtp
            // 
            this.odDtp.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.odDtp.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.odDtp.Location = new System.Drawing.Point(153, 72);
            this.odDtp.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.odDtp.Name = "odDtp";
            this.odDtp.Size = new System.Drawing.Size(244, 26);
            this.odDtp.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(52, 75);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Order Date:";
            // 
            // oiTxt
            // 
            this.oiTxt.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.oiTxt.Location = new System.Drawing.Point(153, 37);
            this.oiTxt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.oiTxt.Name = "oiTxt";
            this.oiTxt.ReadOnly = true;
            this.oiTxt.Size = new System.Drawing.Size(244, 26);
            this.oiTxt.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(73, 40);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Order Id:";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(537, 449);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(231, 30);
            this.button1.TabIndex = 12;
            this.button1.Text = "Save Order";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dgOrderItems
            // 
            this.dgOrderItems.AllowUserToAddRows = false;
            this.dgOrderItems.AllowUserToDeleteRows = false;
            this.dgOrderItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgOrderItems.BackgroundColor = System.Drawing.Color.White;
            this.dgOrderItems.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgOrderItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgOrderItems.Location = new System.Drawing.Point(31, 203);
            this.dgOrderItems.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgOrderItems.Name = "dgOrderItems";
            this.dgOrderItems.ReadOnly = true;
            this.dgOrderItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgOrderItems.Size = new System.Drawing.Size(737, 190);
            this.dgOrderItems.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(102, 149);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 20);
            this.label4.TabIndex = 14;
            this.label4.Text = "Item:";
            // 
            // fiCbo
            // 
            this.fiCbo.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fiCbo.FormattingEnabled = true;
            this.fiCbo.Location = new System.Drawing.Point(153, 147);
            this.fiCbo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.fiCbo.Name = "fiCbo";
            this.fiCbo.Size = new System.Drawing.Size(244, 28);
            this.fiCbo.TabIndex = 15;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDown1.Location = new System.Drawing.Point(537, 158);
            this.numericUpDown1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(85, 26);
            this.numericUpDown1.TabIndex = 16;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(491, 163);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 17);
            this.label5.TabIndex = 17;
            this.label5.Text = "Qty.:";
            // 
            // bAddToOrder
            // 
            this.bAddToOrder.Location = new System.Drawing.Point(639, 156);
            this.bAddToOrder.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bAddToOrder.Name = "bAddToOrder";
            this.bAddToOrder.Size = new System.Drawing.Size(100, 30);
            this.bAddToOrder.TabIndex = 18;
            this.bAddToOrder.Text = "Add";
            this.bAddToOrder.UseVisualStyleBackColor = true;
            this.bAddToOrder.Click += new System.EventHandler(this.bAddToOrder_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(557, 406);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 17);
            this.label6.TabIndex = 19;
            this.label6.Text = "Total: ";
            // 
            // totalLbl
            // 
            this.totalLbl.AutoSize = true;
            this.totalLbl.Location = new System.Drawing.Point(707, 406);
            this.totalLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.totalLbl.Name = "totalLbl";
            this.totalLbl.Size = new System.Drawing.Size(33, 17);
            this.totalLbl.TabIndex = 20;
            this.totalLbl.Text = "0.00";
            // 
            // NewOrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 498);
            this.Controls.Add(this.totalLbl);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.bAddToOrder);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.fiCbo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgOrderItems);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cIdCbo);
            this.Controls.Add(this.odDtp);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.oiTxt);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "NewOrderForm";
            this.Text = "NewOrderForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NewOrderForm_FormClosing);
            this.Load += new System.EventHandler(this.NewOrderForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgOrderItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cIdCbo;
        private System.Windows.Forms.DateTimePicker odDtp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox oiTxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dgOrderItems;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox fiCbo;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button bAddToOrder;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label totalLbl;
    }
}