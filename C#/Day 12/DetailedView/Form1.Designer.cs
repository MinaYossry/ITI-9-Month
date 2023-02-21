namespace DetailedView
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
            this.prdName = new System.Windows.Forms.TextBox();
            this.prdID = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.prdUnitPrice = new System.Windows.Forms.NumericUpDown();
            this.prdUnitsInStock = new System.Windows.Forms.NumericUpDown();
            this.prdUnitsOnOrder = new System.Windows.Forms.NumericUpDown();
            this.prdReorderLevel = new System.Windows.Forms.NumericUpDown();
            this.prdDiscontinued = new System.Windows.Forms.CheckBox();
            this.prdQunatityPerUnit = new System.Windows.Forms.TextBox();
            this.prdSupplier = new System.Windows.Forms.ComboBox();
            this.prdCategory = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.prdUnitPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.prdUnitsInStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.prdUnitsOnOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.prdReorderLevel)).BeginInit();
            this.SuspendLayout();
            // 
            // prdName
            // 
            this.prdName.Location = new System.Drawing.Point(205, 134);
            this.prdName.Name = "prdName";
            this.prdName.Size = new System.Drawing.Size(125, 27);
            this.prdName.TabIndex = 0;
            // 
            // prdID
            // 
            this.prdID.AutoSize = true;
            this.prdID.Location = new System.Drawing.Point(205, 88);
            this.prdID.Name = "prdID";
            this.prdID.Size = new System.Drawing.Size(50, 20);
            this.prdID.TabIndex = 3;
            this.prdID.Text = "label1";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(343, 410);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(94, 28);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(79, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "ProductID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(79, 139);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "ProductName";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(79, 193);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Supplier";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(79, 244);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Category";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(79, 297);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "Quantity";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(452, 88);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 20);
            this.label6.TabIndex = 10;
            this.label6.Text = "Unit Price";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(452, 139);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 20);
            this.label7.TabIndex = 11;
            this.label7.Text = "Units In Stock";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(452, 193);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(107, 20);
            this.label8.TabIndex = 12;
            this.label8.Text = "Units On Order";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(452, 244);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 20);
            this.label9.TabIndex = 13;
            this.label9.Text = "Reorder Level";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(452, 297);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(96, 20);
            this.label10.TabIndex = 14;
            this.label10.Text = "Discontinued";
            // 
            // prdUnitPrice
            // 
            this.prdUnitPrice.DecimalPlaces = 3;
            this.prdUnitPrice.Location = new System.Drawing.Point(597, 86);
            this.prdUnitPrice.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.prdUnitPrice.Name = "prdUnitPrice";
            this.prdUnitPrice.Size = new System.Drawing.Size(125, 27);
            this.prdUnitPrice.TabIndex = 16;
            // 
            // prdUnitsInStock
            // 
            this.prdUnitsInStock.Location = new System.Drawing.Point(597, 134);
            this.prdUnitsInStock.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.prdUnitsInStock.Name = "prdUnitsInStock";
            this.prdUnitsInStock.Size = new System.Drawing.Size(125, 27);
            this.prdUnitsInStock.TabIndex = 17;
            // 
            // prdUnitsOnOrder
            // 
            this.prdUnitsOnOrder.Location = new System.Drawing.Point(597, 190);
            this.prdUnitsOnOrder.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.prdUnitsOnOrder.Name = "prdUnitsOnOrder";
            this.prdUnitsOnOrder.Size = new System.Drawing.Size(125, 27);
            this.prdUnitsOnOrder.TabIndex = 18;
            // 
            // prdReorderLevel
            // 
            this.prdReorderLevel.Location = new System.Drawing.Point(597, 241);
            this.prdReorderLevel.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.prdReorderLevel.Name = "prdReorderLevel";
            this.prdReorderLevel.Size = new System.Drawing.Size(125, 27);
            this.prdReorderLevel.TabIndex = 19;
            // 
            // prdDiscontinued
            // 
            this.prdDiscontinued.AutoSize = true;
            this.prdDiscontinued.Location = new System.Drawing.Point(597, 295);
            this.prdDiscontinued.Name = "prdDiscontinued";
            this.prdDiscontinued.Size = new System.Drawing.Size(18, 17);
            this.prdDiscontinued.TabIndex = 20;
            this.prdDiscontinued.UseVisualStyleBackColor = true;
            // 
            // prdQunatityPerUnit
            // 
            this.prdQunatityPerUnit.Location = new System.Drawing.Point(205, 294);
            this.prdQunatityPerUnit.Name = "prdQunatityPerUnit";
            this.prdQunatityPerUnit.Size = new System.Drawing.Size(125, 27);
            this.prdQunatityPerUnit.TabIndex = 21;
            // 
            // prdSupplier
            // 
            this.prdSupplier.FormattingEnabled = true;
            this.prdSupplier.Location = new System.Drawing.Point(205, 189);
            this.prdSupplier.Name = "prdSupplier";
            this.prdSupplier.Size = new System.Drawing.Size(125, 28);
            this.prdSupplier.TabIndex = 22;
            // 
            // prdCategory
            // 
            this.prdCategory.FormattingEnabled = true;
            this.prdCategory.Location = new System.Drawing.Point(205, 240);
            this.prdCategory.Name = "prdCategory";
            this.prdCategory.Size = new System.Drawing.Size(125, 28);
            this.prdCategory.TabIndex = 23;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.prdCategory);
            this.Controls.Add(this.prdSupplier);
            this.Controls.Add(this.prdQunatityPerUnit);
            this.Controls.Add(this.prdDiscontinued);
            this.Controls.Add(this.prdReorderLevel);
            this.Controls.Add(this.prdUnitsOnOrder);
            this.Controls.Add(this.prdUnitsInStock);
            this.Controls.Add(this.prdUnitPrice);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.prdID);
            this.Controls.Add(this.prdName);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.prdUnitPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.prdUnitsInStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.prdUnitsOnOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.prdReorderLevel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox prdName;
        private Label prdID;
        private Button btnSave;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private NumericUpDown prdQuantity;
        private NumericUpDown prdUnitPrice;
        private NumericUpDown prdUnitsInStock;
        private NumericUpDown prdUnitsOnOrder;
        private NumericUpDown prdReorderLevel;
        private CheckBox prdDiscontinued;
        private TextBox prdQunatityPerUnit;
        private ComboBox prdSupplier;
        private ComboBox prdCategory;
    }
}