using System;
using System.IO;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace FileCompare
{
    public partial class Form1 : Form
    {
        Dictionary<string, FileInfo> leftFiles = new Dictionary<string, FileInfo>();
        Dictionary<string, FileInfo> rightFiles = new Dictionary<string, FileInfo>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitListView();
        }

        // =========================
        // ListView 설정
        // =========================
        private void InitListView()
        {
            lvwLeftDir.View = View.Details;
            lvwLeftDir.FullRowSelect = true;
            lvwLeftDir.GridLines = true;
            lvwLeftDir.MultiSelect = true;
            lvwLeftDir.Columns.Add("이름", 200);
            lvwLeftDir.Columns.Add("크기", 100);
            lvwLeftDir.Columns.Add("수정일", 150);

            lvwrightDir.View = View.Details;
            lvwrightDir.FullRowSelect = true;
            lvwrightDir.GridLines = true;
            lvwrightDir.MultiSelect = true;
            lvwrightDir.Columns.Add("이름", 200);
            lvwrightDir.Columns.Add("크기", 100);
            lvwrightDir.Columns.Add("수정일", 150);
        }

        // =========================
        // 왼쪽 폴더 선택
        // =========================
        private void btnLeftDir_Click(object sender, EventArgs e)
        {
            using (var dlg = new FolderBrowserDialog())
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    txtLeftDir.Text = dlg.SelectedPath;
                    LoadLeft();
                    ApplyColor();
                }
            }
        }

        // =========================
        // 오른쪽 폴더 선택
        // =========================
        private void btnRightDir_Click(object sender, EventArgs e)
        {
            using (var dlg = new FolderBrowserDialog())
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    txtRightDir.Text = dlg.SelectedPath;
                    LoadRight();
                    ApplyColor();
                }
            }
        }

        // =========================
        // 왼쪽 파일 로드
        // =========================
        private void LoadLeft()
        {
            lvwLeftDir.Items.Clear();
            leftFiles.Clear();

            if (!Directory.Exists(txtLeftDir.Text)) return;

            var files = Directory.EnumerateFiles(txtLeftDir.Text)
                .Select(f => new FileInfo(f))
                .OrderBy(f => f.Name);

            foreach (var f in files)
            {
                leftFiles[f.Name] = f;

                var item = new ListViewItem(f.Name);
                item.SubItems.Add(f.Length.ToString("N0"));
                item.SubItems.Add(f.LastWriteTime.ToString("g"));
                lvwLeftDir.Items.Add(item);
            }
        }

        // =========================
        // 오른쪽 파일 로드
        // =========================
        private void LoadRight()
        {
            lvwrightDir.Items.Clear();
            rightFiles.Clear();

            if (!Directory.Exists(txtRightDir.Text)) return;

            var files = Directory.EnumerateFiles(txtRightDir.Text)
                .Select(f => new FileInfo(f))
                .OrderBy(f => f.Name);

            foreach (var f in files)
            {
                rightFiles[f.Name] = f;

                var item = new ListViewItem(f.Name);
                item.SubItems.Add(f.Length.ToString("N0"));
                item.SubItems.Add(f.LastWriteTime.ToString("g"));
                lvwrightDir.Items.Add(item);
            }
        }

        // =========================
        // 색상 비교
        // =========================
        private void ApplyColor()
        {
            // 왼쪽 기준
            foreach (ListViewItem item in lvwLeftDir.Items)
            {
                string name = item.Text;

                if (rightFiles.ContainsKey(name))
                {
                    var lf = leftFiles[name];
                    var rf = rightFiles[name];

                    if (lf.LastWriteTime > rf.LastWriteTime)
                        item.ForeColor = Color.Red;
                    else if (lf.LastWriteTime < rf.LastWriteTime)
                        item.ForeColor = Color.Gray;
                    else
                        item.ForeColor = Color.Black;
                }
                else
                {
                    item.ForeColor = Color.Purple;
                }
            }

            // 오른쪽 기준
            foreach (ListViewItem item in lvwrightDir.Items)
            {
                string name = item.Text;

                if (leftFiles.ContainsKey(name))
                {
                    var lf = leftFiles[name];
                    var rf = rightFiles[name];

                    if (rf.LastWriteTime > lf.LastWriteTime)
                        item.ForeColor = Color.Red;
                    else if (rf.LastWriteTime < lf.LastWriteTime)
                        item.ForeColor = Color.Gray;
                    else
                        item.ForeColor = Color.Black;
                }
                else
                {
                    item.ForeColor = Color.Purple;
                }
            }
        }

        // =========================
        // 왼쪽 → 오른쪽 복사
        // =========================
        private void btnCopyFromLeft_Click(object sender, EventArgs e)
        {
            if (lvwLeftDir.SelectedItems.Count == 0)
            {
                MessageBox.Show("파일을 선택하세요.");
                return;
            }

            if (!Directory.Exists(txtRightDir.Text))
            {
                MessageBox.Show("오른쪽 폴더를 선택하세요.");
                return;
            }

            foreach (ListViewItem item in lvwLeftDir.SelectedItems)
            {
                string name = item.Text;
                string src = Path.Combine(txtLeftDir.Text, name);
                string dest = Path.Combine(txtRightDir.Text, name);

                if (!File.Exists(src)) continue;

                CopyFileWithConfirm(src, dest);
            }

            LoadRight();
            ApplyColor();
        }

        // =========================
        // 오른쪽 → 왼쪽 복사
        // =========================
        private void btnCopyFromRight_Click(object sender, EventArgs e)
        {
            if (lvwrightDir.SelectedItems.Count == 0)
            {
                MessageBox.Show("파일을 선택하세요.");
                return;
            }

            if (!Directory.Exists(txtLeftDir.Text))
            {
                MessageBox.Show("왼쪽 폴더를 선택하세요.");
                return;
            }

            foreach (ListViewItem item in lvwrightDir.SelectedItems)
            {
                string name = item.Text;
                string src = Path.Combine(txtRightDir.Text, name);
                string dest = Path.Combine(txtLeftDir.Text, name);

                if (!File.Exists(src)) continue;

                CopyFileWithConfirm(src, dest);
            }

            LoadLeft();
            ApplyColor();
        }

        // =========================
        // 복사 + 덮어쓰기 확인
        // =========================
        private void CopyFileWithConfirm(string src, string dest)
        {
            try
            {
                if (File.Exists(dest))
                {
                    var srcInfo = new FileInfo(src);
                    var destInfo = new FileInfo(dest);

                    string msg =
                        $"이미 파일이 존재합니다.\n\n" +
                        $"원본: {srcInfo.LastWriteTime}\n" +
                        $"대상: {destInfo.LastWriteTime}\n\n" +
                        $"덮어쓰시겠습니까?";

                    var result = MessageBox.Show(msg, "확인",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result != DialogResult.Yes)
                        return;
                }

                File.Copy(src, dest, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("복사 실패: " + ex.Message);
            }
        }
    }
}