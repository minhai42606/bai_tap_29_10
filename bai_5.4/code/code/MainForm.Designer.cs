namespace GUI
{
    partial class MainForm
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
            dgvPhong = new DataGridView();
            cbLoaiPhong = new ComboBox();
            cbTrangThai = new ComboBox();
            btnCheckIn = new Button();
            btnGoiDichVu = new Button();
            btnCheckOut = new Button();
            btnTaiLai = new Button();
            txtTimLoaiPhong = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvPhong).BeginInit();
            SuspendLayout();
            // 
            // dgvPhong
            // 
            dgvPhong.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPhong.Dock = DockStyle.Bottom;
            dgvPhong.Location = new Point(0, 203);
            dgvPhong.Name = "dgvPhong";
            dgvPhong.Size = new Size(800, 247);
            dgvPhong.TabIndex = 0;
            // 
            // cbLoaiPhong
            // 
            cbLoaiPhong.FormattingEnabled = true;
            cbLoaiPhong.Location = new Point(134, 33);
            cbLoaiPhong.Name = "cbLoaiPhong";
            cbLoaiPhong.Size = new Size(121, 23);
            cbLoaiPhong.TabIndex = 1;
            cbLoaiPhong.SelectedIndexChanged += cbLoaiPhong_SelectedIndexChanged;
            // 
            // cbTrangThai
            // 
            cbTrangThai.FormattingEnabled = true;
            cbTrangThai.Location = new Point(531, 36);
            cbTrangThai.Name = "cbTrangThai";
            cbTrangThai.Size = new Size(121, 23);
            cbTrangThai.TabIndex = 2;
            cbTrangThai.SelectedIndexChanged += cbTrangThai_SelectedIndexChanged_1;
            // 
            // btnCheckIn
            // 
            btnCheckIn.Location = new Point(134, 73);
            btnCheckIn.Name = "btnCheckIn";
            btnCheckIn.Size = new Size(99, 47);
            btnCheckIn.TabIndex = 3;
            btnCheckIn.Text = "Nhận Phòng";
            btnCheckIn.UseVisualStyleBackColor = true;
            btnCheckIn.Click += btnCheckIn_Click;
            // 
            // btnGoiDichVu
            // 
            btnGoiDichVu.Location = new Point(553, 73);
            btnGoiDichVu.Name = "btnGoiDichVu";
            btnGoiDichVu.Size = new Size(99, 47);
            btnGoiDichVu.TabIndex = 4;
            btnGoiDichVu.Text = "Gói dịch vụ";
            btnGoiDichVu.UseVisualStyleBackColor = true;
            btnGoiDichVu.Click += btnGoiDichVu_Click;
            // 
            // btnCheckOut
            // 
            btnCheckOut.Location = new Point(134, 129);
            btnCheckOut.Name = "btnCheckOut";
            btnCheckOut.Size = new Size(99, 40);
            btnCheckOut.TabIndex = 5;
            btnCheckOut.Text = "Trả phòng & Thanh toán";
            btnCheckOut.UseVisualStyleBackColor = true;
            btnCheckOut.Click += btnCheckOut_Click;
            // 
            // btnTaiLai
            // 
            btnTaiLai.Location = new Point(553, 126);
            btnTaiLai.Name = "btnTaiLai";
            btnTaiLai.Size = new Size(99, 47);
            btnTaiLai.TabIndex = 6;
            btnTaiLai.Text = "Làm mới danh sách";
            btnTaiLai.UseVisualStyleBackColor = true;
            btnTaiLai.Click += btnTaiLai_Click;
            // 
            // txtTimLoaiPhong
            // 
            txtTimLoaiPhong.Location = new Point(300, 33);
            txtTimLoaiPhong.Name = "txtTimLoaiPhong";
            txtTimLoaiPhong.Size = new Size(197, 23);
            txtTimLoaiPhong.TabIndex = 7;
            txtTimLoaiPhong.Text = "Nhập tên phòng cần tìm";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txtTimLoaiPhong);
            Controls.Add(btnTaiLai);
            Controls.Add(btnCheckOut);
            Controls.Add(btnGoiDichVu);
            Controls.Add(btnCheckIn);
            Controls.Add(cbTrangThai);
            Controls.Add(cbLoaiPhong);
            Controls.Add(dgvPhong);
            Name = "MainForm";
            Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)dgvPhong).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvPhong;
        private ComboBox cbLoaiPhong;
        private ComboBox cbTrangThai;
        private Button btnCheckIn;
        private Button btnGoiDichVu;
        private Button btnCheckOut;
        private Button btnTaiLai;
        private TextBox txtTimLoaiPhong;
    }
}