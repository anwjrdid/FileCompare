using System;
using System.IO;
using System.Linq;
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
            // 왼쪽
            lvwLeftDir.View = View.Details;
            lvwLeftDir.FullRowSelect = true;
            lvwLeftDir.GridLines = true;
            lvwLeftDir.Columns.Clear();
            lvwLeftDir.Columns.Add("이름", 200);
            lvwLeftDir.Columns.Add("크기", 100);
            lvwLeftDir.Columns.Add("수정일", 150);

            // 오른쪽 (이름 주의: lvwrightDir)
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
        // 폴더 선택 (왼쪽)
        // =========================
        private void btnLeftDir_Click(object sender, EventArgs e)
        {
            using (var dlg = new FolderBrowserDialog())
            {
                dlg.Description = "왼쪽 폴더 선택";

                if (!string.IsNullOrWhiteSpace(txtLeftDir.Text) && Directory.Exists(txtLeftDir.Text))
                {
                    dlg.SelectedPath = txtLeftDir.Text;
                }

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    txtLeftDir.Text = dlg.SelectedPath;
                    PopulateListView(lvwLeftDir, dlg.SelectedPath);
                }
            }
        }

        // =========================
        // 폴더 선택 (오른쪽)
        // =========================
        private void btnRightDir_Click(object sender, EventArgs e)
        {
            using (var dlg = new FolderBrowserDialog())
            {
                dlg.Description = "오른쪽 폴더 선택";

                if (!string.IsNullOrWhiteSpace(txtRightDir.Text) && Directory.Exists(txtRightDir.Text))
                {
                    dlg.SelectedPath = txtRightDir.Text;
                }

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    txtRightDir.Text = dlg.SelectedPath;
                    PopulateListView(lvwrightDir, dlg.SelectedPath);
                }
            }
        }

        // =========================
        // 파일 목록 출력 핵심 함수
        // =========================
        private void PopulateListView(ListView lv, string folderPath)
        {
            lv.BeginUpdate();
            lv.Items.Clear();

            try
            {
                // 📁 폴더 먼저 표시
                var dirs = Directory.EnumerateDirectories(folderPath)
                                    .Select(p => new DirectoryInfo(p))
                                    .OrderBy(d => d.Name);

                foreach (var d in dirs)
                {
                    var item = new ListViewItem(d.Name);
                    item.SubItems.Add("<DIR>");
                    item.SubItems.Add(d.LastWriteTime.ToString("g"));
                    lv.Items.Add(item);
                }

                // 📄 파일 표시
                var files = Directory.EnumerateFiles(folderPath)
                                     .Select(p => new FileInfo(p))
                                     .OrderBy(f => f.Name);

                foreach (var f in files)
                {
                    var item = new ListViewItem(f.Name);
                    item.SubItems.Add(f.Length.ToString("N0") + " 바이트");
                    item.SubItems.Add(f.LastWriteTime.ToString("g"));
                    lv.Items.Add(item);
                }

                // 컬럼 자동 크기 조절
                for (int i = 0; i < lv.Columns.Count; i++)
                {
                    lv.AutoResizeColumn(i, ColumnHeaderAutoResizeStyle.ColumnContent);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("오류 발생: " + ex.Message);
            }
            finally
            {
                lv.EndUpdate();
            }
        }

        // =========================
        // 복사 버튼 (아직 과제3)
        // =========================
        private void btnCopyFromLeft_Click(object sender, EventArgs e)
        {
            MessageBox.Show("왼쪽 → 오른쪽 복사 (과제3)");
        }

        private void btnCopyFromRight_Click(object sender, EventArgs e)
        {
            MessageBox.Show("오른쪽 → 왼쪽 복사 (과제3)");
        }
    }
}