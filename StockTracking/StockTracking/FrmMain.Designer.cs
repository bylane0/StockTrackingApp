namespace StockTracking
{
    partial class FrmMain
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
            this.btnExit = new System.Windows.Forms.Button();
            this.btnAddStock = new System.Windows.Forms.Button();
            this.btnCategory = new System.Windows.Forms.Button();
            this.btnDeleted = new System.Windows.Forms.Button();
            this.btnCustomers = new System.Windows.Forms.Button();
            this.btnProducts = new System.Windows.Forms.Button();
            this.btnSales = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Image = global::StockTracking.Properties.Resources.Exit;
            this.btnExit.Location = new System.Drawing.Point(149, 256);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(131, 116);
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "Salida";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnAddStock
            // 
            this.btnAddStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddStock.Image = global::StockTracking.Properties.Resources.addStock;
            this.btnAddStock.Location = new System.Drawing.Point(12, 134);
            this.btnAddStock.Name = "btnAddStock";
            this.btnAddStock.Size = new System.Drawing.Size(131, 116);
            this.btnAddStock.TabIndex = 5;
            this.btnAddStock.Text = "Añadir stock";
            this.btnAddStock.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAddStock.UseVisualStyleBackColor = true;
            this.btnAddStock.Click += new System.EventHandler(this.btnAddStock_Click);
            // 
            // btnCategory
            // 
            this.btnCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCategory.Image = global::StockTracking.Properties.Resources.Task;
            this.btnCategory.Location = new System.Drawing.Point(149, 134);
            this.btnCategory.Name = "btnCategory";
            this.btnCategory.Size = new System.Drawing.Size(131, 116);
            this.btnCategory.TabIndex = 4;
            this.btnCategory.Text = "Categorías";
            this.btnCategory.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCategory.UseVisualStyleBackColor = true;
            this.btnCategory.Click += new System.EventHandler(this.btnCategory_Click);
            // 
            // btnDeleted
            // 
            this.btnDeleted.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleted.Image = global::StockTracking.Properties.Resources.deleted;
            this.btnDeleted.Location = new System.Drawing.Point(286, 134);
            this.btnDeleted.Name = "btnDeleted";
            this.btnDeleted.Size = new System.Drawing.Size(131, 116);
            this.btnDeleted.TabIndex = 3;
            this.btnDeleted.Text = "Eliminado";
            this.btnDeleted.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDeleted.UseVisualStyleBackColor = true;
            this.btnDeleted.Click += new System.EventHandler(this.btnDeleted_Click);
            // 
            // btnCustomers
            // 
            this.btnCustomers.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCustomers.Image = global::StockTracking.Properties.Resources.Employee;
            this.btnCustomers.Location = new System.Drawing.Point(12, 12);
            this.btnCustomers.Name = "btnCustomers";
            this.btnCustomers.Size = new System.Drawing.Size(131, 116);
            this.btnCustomers.TabIndex = 2;
            this.btnCustomers.Text = "Clientes";
            this.btnCustomers.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCustomers.UseVisualStyleBackColor = true;
            this.btnCustomers.Click += new System.EventHandler(this.btnCustomers_Click);
            // 
            // btnProducts
            // 
            this.btnProducts.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProducts.Image = global::StockTracking.Properties.Resources.product;
            this.btnProducts.Location = new System.Drawing.Point(149, 12);
            this.btnProducts.Name = "btnProducts";
            this.btnProducts.Size = new System.Drawing.Size(131, 116);
            this.btnProducts.TabIndex = 1;
            this.btnProducts.Text = "Productos";
            this.btnProducts.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnProducts.UseVisualStyleBackColor = true;
            this.btnProducts.Click += new System.EventHandler(this.btnProducts_Click);
            // 
            // btnSales
            // 
            this.btnSales.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSales.Image = global::StockTracking.Properties.Resources.Salary;
            this.btnSales.Location = new System.Drawing.Point(286, 12);
            this.btnSales.Name = "btnSales";
            this.btnSales.Size = new System.Drawing.Size(131, 116);
            this.btnSales.TabIndex = 0;
            this.btnSales.Text = "Ventas";
            this.btnSales.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSales.UseVisualStyleBackColor = true;
            this.btnSales.Click += new System.EventHandler(this.btnSales_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 382);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnAddStock);
            this.Controls.Add(this.btnCategory);
            this.Controls.Add(this.btnDeleted);
            this.Controls.Add(this.btnCustomers);
            this.Controls.Add(this.btnProducts);
            this.Controls.Add(this.btnSales);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stock Tracking - menú";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmMain_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSales;
        private System.Windows.Forms.Button btnProducts;
        private System.Windows.Forms.Button btnCustomers;
        private System.Windows.Forms.Button btnAddStock;
        private System.Windows.Forms.Button btnCategory;
        private System.Windows.Forms.Button btnDeleted;
        private System.Windows.Forms.Button btnExit;
    }
}