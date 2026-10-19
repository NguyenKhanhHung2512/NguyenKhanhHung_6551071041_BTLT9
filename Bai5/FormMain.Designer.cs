namespace Bai5
{
    partial class FormMain
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
            tabChinh = new TabControl();
            tabTour = new TabPage();
            ucTour = new UcTour();
            tabKhachHang = new TabPage();
            ucKhachHang = new UcKhachHang();
            tabDatTour = new TabPage();
            ucDatTour = new UcDatTour();
            tabChinh.SuspendLayout();
            tabTour.SuspendLayout();
            tabKhachHang.SuspendLayout();
            tabDatTour.SuspendLayout();
            SuspendLayout();
            // 
            // tabChinh
            // 
            tabChinh.Controls.Add(tabTour);
            tabChinh.Controls.Add(tabKhachHang);
            tabChinh.Controls.Add(tabDatTour);
            tabChinh.Dock = DockStyle.Fill;
            tabChinh.Font = new Font("Segoe UI", 10F);
            tabChinh.Location = new Point(0, 0);
            tabChinh.Name = "tabChinh";
            tabChinh.Padding = new Point(16, 6);
            tabChinh.SelectedIndex = 0;
            tabChinh.Size = new Size(1120, 680);
            tabChinh.TabIndex = 0;
            tabChinh.SelectedIndexChanged += TabChinh_SelectedIndexChanged;
            // 
            // tabTour
            // 
            tabTour.Controls.Add(ucTour);
            tabTour.Location = new Point(4, 35);
            tabTour.Name = "tabTour";
            tabTour.Padding = new Padding(3);
            tabTour.Size = new Size(1112, 641);
            tabTour.TabIndex = 0;
            tabTour.Text = "Tour";
            tabTour.UseVisualStyleBackColor = true;
            // 
            // ucTour
            // 
            ucTour.Dock = DockStyle.Fill;
            ucTour.Font = new Font("Segoe UI", 9F);
            ucTour.Location = new Point(3, 3);
            ucTour.Name = "ucTour";
            ucTour.Size = new Size(1106, 635);
            ucTour.TabIndex = 0;
            // 
            // tabKhachHang
            // 
            tabKhachHang.Controls.Add(ucKhachHang);
            tabKhachHang.Location = new Point(4, 35);
            tabKhachHang.Name = "tabKhachHang";
            tabKhachHang.Padding = new Padding(3);
            tabKhachHang.Size = new Size(1112, 641);
            tabKhachHang.TabIndex = 1;
            tabKhachHang.Text = "Khách hàng";
            tabKhachHang.UseVisualStyleBackColor = true;
            // 
            // ucKhachHang
            // 
            ucKhachHang.Dock = DockStyle.Fill;
            ucKhachHang.Font = new Font("Segoe UI", 9F);
            ucKhachHang.Location = new Point(3, 3);
            ucKhachHang.Name = "ucKhachHang";
            ucKhachHang.Size = new Size(1106, 635);
            ucKhachHang.TabIndex = 0;
            // 
            // tabDatTour
            // 
            tabDatTour.Controls.Add(ucDatTour);
            tabDatTour.Location = new Point(4, 35);
            tabDatTour.Name = "tabDatTour";
            tabDatTour.Padding = new Padding(3);
            tabDatTour.Size = new Size(1112, 641);
            tabDatTour.TabIndex = 2;
            tabDatTour.Text = "Đặt tour";
            tabDatTour.UseVisualStyleBackColor = true;
            // 
            // ucDatTour
            // 
            ucDatTour.Dock = DockStyle.Fill;
            ucDatTour.Font = new Font("Segoe UI", 9F);
            ucDatTour.Location = new Point(3, 3);
            ucDatTour.Name = "ucDatTour";
            ucDatTour.Size = new Size(1106, 635);
            ucDatTour.TabIndex = 0;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1120, 680);
            Controls.Add(tabChinh);
            MinimumSize = new Size(1000, 650);
            Name = "FormMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý đặt tour";
            WindowState = FormWindowState.Maximized;
            Load += FormMain_Load;
            tabChinh.ResumeLayout(false);
            tabTour.ResumeLayout(false);
            tabKhachHang.ResumeLayout(false);
            tabDatTour.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabChinh;
        private TabPage tabTour;
        private TabPage tabKhachHang;
        private TabPage tabDatTour;
        private UcTour ucTour;
        private UcKhachHang ucKhachHang;
        private UcDatTour ucDatTour;
    }
}
