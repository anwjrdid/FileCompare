using System;
using System.Windows.Forms;

namespace FileCompare
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // =========================
        // 폼 시작
        // =========================
        private void Form1_Load(object sender, EventArgs e)
        {
            InitListView();
            ResetUI();
        }

        // =========================
        // ListView 초기 설정
        // =========================
        private void InitListView()
        {
            // 왼쪽 ListView
            lvwLeftDir.View = View.Details;
            lvwLeftDir.FullRowSelect = true;
            lvwLeftDir.GridLines = true;
            lvwLeftDir.Columns.Clear();
            lvwLeftDir.Columns.Add("이름", 200);
            lvwLeftDir.Columns.Add("크기", 100);
            lvwLeftDir.Columns.Add("수정일", 150);

            // 오른쪽 ListView
            lvwrightDir.View = View.Details;
            lvwrightDir.FullRowSelect = true;
            lvwrightDir.GridLines = true;
            lvwrightDir.Columns.Clear();
            lvwrightDir.Columns.Add("이름", 200);
            lvwrightDir.Columns.Add("크기", 100);
            lvwrightDir.Columns.Add("수정일", 150);
        }

        // =========================
        // 초기화
        // =========================
        private void ResetUI()
        {
            txtLeftDir.Text = "";
            txtRightDir.Text = "";

            lvwLeftDir.Items.Clear();
            lvwrightDir.Items.Clear();
        }

        // =========================
        // 버튼 이벤트
        // =========================

        // 왼쪽 폴더 버튼
        private void btnLeftDir_Click(object sender, EventArgs e)
        {
            MessageBox.Show("왼쪽 폴더 선택 버튼 클릭");
        }

        // 오른쪽 폴더 버튼
        private void btnRightDir_Click(object sender, EventArgs e)
        {
            MessageBox.Show("오른쪽 폴더 선택 버튼 클릭");
        }

        // >>> (왼쪽 → 오른쪽 복사)
        private void btnCopyFromLeft_Click(object sender, EventArgs e)
        {
            MessageBox.Show("왼쪽 → 오른쪽 복사 (과제3)");
        }

        // <<< (오른쪽 → 왼쪽 복사)
        private void btnCopyFromRight_Click(object sender, EventArgs e)
        {
            MessageBox.Show("오른쪽 → 왼쪽 복사 (과제3)");
        }
    }
}