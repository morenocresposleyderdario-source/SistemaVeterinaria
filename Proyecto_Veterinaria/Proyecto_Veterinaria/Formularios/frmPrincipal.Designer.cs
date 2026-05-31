namespace Proyecto_Veterinaria.Formularios
{
    partial class frmPrincipal
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.gestionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guiaConsultaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultaMedicaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adminDueñoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adminMascotaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adminMedicoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gestionToolStripMenuItem,
            this.guiaConsultaToolStripMenuItem,
            this.reportesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 30);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // gestionToolStripMenuItem
            // 
            this.gestionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adminDueñoToolStripMenuItem,
            this.adminMascotaToolStripMenuItem,
            this.adminMedicoToolStripMenuItem});
            this.gestionToolStripMenuItem.Name = "gestionToolStripMenuItem";
            this.gestionToolStripMenuItem.Size = new System.Drawing.Size(73, 26);
            this.gestionToolStripMenuItem.Text = "Gestion";
            // 
            // guiaConsultaToolStripMenuItem
            // 
            this.guiaConsultaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.consultaMedicaToolStripMenuItem});
            this.guiaConsultaToolStripMenuItem.Name = "guiaConsultaToolStripMenuItem";
            this.guiaConsultaToolStripMenuItem.Size = new System.Drawing.Size(114, 26);
            this.guiaConsultaToolStripMenuItem.Text = "Guia Consulta";
            // 
            // consultaMedicaToolStripMenuItem
            // 
            this.consultaMedicaToolStripMenuItem.Name = "consultaMedicaToolStripMenuItem";
            this.consultaMedicaToolStripMenuItem.Size = new System.Drawing.Size(202, 26);
            this.consultaMedicaToolStripMenuItem.Text = "Consulta Medica";
            this.consultaMedicaToolStripMenuItem.Click += new System.EventHandler(this.consultaMedicaToolStripMenuItem_Click);
            // 
            // reportesToolStripMenuItem
            // 
            this.reportesToolStripMenuItem.Name = "reportesToolStripMenuItem";
            this.reportesToolStripMenuItem.Size = new System.Drawing.Size(82, 26);
            this.reportesToolStripMenuItem.Text = "Reportes";
            // 
            // adminDueñoToolStripMenuItem
            // 
            this.adminDueñoToolStripMenuItem.Name = "adminDueñoToolStripMenuItem";
            this.adminDueñoToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.adminDueñoToolStripMenuItem.Text = "AdminDueño";
            this.adminDueñoToolStripMenuItem.Click += new System.EventHandler(this.adminDueñoToolStripMenuItem_Click);
            // 
            // adminMascotaToolStripMenuItem
            // 
            this.adminMascotaToolStripMenuItem.Name = "adminMascotaToolStripMenuItem";
            this.adminMascotaToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.adminMascotaToolStripMenuItem.Text = "AdminMascota";
            this.adminMascotaToolStripMenuItem.Click += new System.EventHandler(this.adminMascotaToolStripMenuItem_Click);
            // 
            // adminMedicoToolStripMenuItem
            // 
            this.adminMedicoToolStripMenuItem.Name = "adminMedicoToolStripMenuItem";
            this.adminMedicoToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.adminMedicoToolStripMenuItem.Text = "AdminMedico";
            this.adminMedicoToolStripMenuItem.Click += new System.EventHandler(this.adminMedicoToolStripMenuItem_Click);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmPrincipal";
            this.Text = "frmPrincipal";
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem gestionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guiaConsultaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultaMedicaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adminDueñoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adminMascotaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adminMedicoToolStripMenuItem;
    }
}