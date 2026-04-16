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
        Dictionary<string, FileSystemInfo> leftItems = new Dictionary<string, FileSystemInfo>();
        Dictionary<string, FileSystemInfo> rightItems = new Dictionary<string, FileSystemInfo>();

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
        // 공통 함수 (추가된 부분)
        // =========================
        private void PopulateListView(ListView lv, string path, Dictionary<string, FileSystemInfo> dict)
        {
            lv.Items.Clear();
            dict.Clear();

            if (!Directory.Exists(path)) return;

            foreach (var d in Directory.GetDirectories(path))
            {
                var info = new DirectoryInfo(d);
                dict[info.Name] = info;

                var item = new ListViewItem(info.Name);
                item.SubItems.Add("<DIR>");
                item.SubItems.Add(info.LastWriteTime.ToString("g"));
                lv.Items.Add(item);
            }

            foreach (var f in Directory.GetFiles(path))
            {
                var info = new FileInfo(f);
                dict[info.Name] = info;

                double sizeKB = info.Length / 1024.0;
                var item = new ListViewItem(info.Name);
                item.SubItems.Add($"{sizeKB:N1} KB");
                item.SubItems.Add(info.LastWriteTime.ToString("g"));
                lv.Items.Add(item);
            }
        }

        // =========================
        // 폴더 선택
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
        // 데이터 로드 (기존 유지 + KB 적용)
        // =========================
        private void LoadLeft()
        {
            lvwLeftDir.Items.Clear();
            leftItems.Clear();

            if (!Directory.Exists(txtLeftDir.Text)) return;

            foreach (var d in Directory.GetDirectories(txtLeftDir.Text))
            {
                var info = new DirectoryInfo(d);
                leftItems[info.Name] = info;

                var item = new ListViewItem(info.Name);
                item.SubItems.Add("<DIR>");
                item.SubItems.Add(info.LastWriteTime.ToString("g"));
                lvwLeftDir.Items.Add(item);
            }

            foreach (var f in Directory.GetFiles(txtLeftDir.Text))
            {
                var info = new FileInfo(f);
                leftItems[info.Name] = info;

                double sizeKB = info.Length / 1024.0;
                var item = new ListViewItem(info.Name);
                item.SubItems.Add($"{sizeKB:N1} KB");
                item.SubItems.Add(info.LastWriteTime.ToString("g"));
                lvwLeftDir.Items.Add(item);
            }
        }

        private void LoadRight()
        {
            lvwrightDir.Items.Clear();
            rightItems.Clear();

            if (!Directory.Exists(txtRightDir.Text)) return;

            foreach (var d in Directory.GetDirectories(txtRightDir.Text))
            {
                var info = new DirectoryInfo(d);
                rightItems[info.Name] = info;

                var item = new ListViewItem(info.Name);
                item.SubItems.Add("<DIR>");
                item.SubItems.Add(info.LastWriteTime.ToString("g"));
                lvwrightDir.Items.Add(item);
            }

            foreach (var f in Directory.GetFiles(txtRightDir.Text))
            {
                var info = new FileInfo(f);
                rightItems[info.Name] = info;

                double sizeKB = info.Length / 1024.0;
                var item = new ListViewItem(info.Name);
                item.SubItems.Add($"{sizeKB:N1} KB");
                item.SubItems.Add(info.LastWriteTime.ToString("g"));
                lvwrightDir.Items.Add(item);
            }
        }

        // =========================
        // 색상 비교
        // =========================
        private void ApplyColor()
        {
            foreach (ListViewItem item in lvwLeftDir.Items)
            {
                string name = item.Text;

                if (rightItems.ContainsKey(name))
                {
                    var l = leftItems[name];
                    var r = rightItems[name];

                    if (l.LastWriteTime > r.LastWriteTime)
                        item.ForeColor = Color.Red;
                    else if (l.LastWriteTime < r.LastWriteTime)
                        item.ForeColor = Color.Gray;
                    else
                        item.ForeColor = Color.Black;
                }
                else
                {
                    item.ForeColor = Color.Purple;
                }
            }

            foreach (ListViewItem item in lvwrightDir.Items)
            {
                string name = item.Text;

                if (leftItems.ContainsKey(name))
                {
                    var l = leftItems[name];
                    var r = rightItems[name];

                    if (r.LastWriteTime > l.LastWriteTime)
                        item.ForeColor = Color.Red;
                    else if (r.LastWriteTime < l.LastWriteTime)
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
        // 복사 버튼
        // =========================
        private void btnCopyFromLeft_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(txtLeftDir.Text) || !Directory.Exists(txtRightDir.Text))
            {
                MessageBox.Show("폴더를 선택해주세요.");
                return;
            }

            if (lvwLeftDir.SelectedItems.Count == 0)
            {
                MessageBox.Show("파일 또는 폴더를 선택하세요.");
                return;
            }

            foreach (ListViewItem item in lvwLeftDir.SelectedItems)
            {
                CopyRecursive(
                    Path.Combine(txtLeftDir.Text, item.Text),
                    Path.Combine(txtRightDir.Text, item.Text));
            }

            LoadRight();
            ApplyColor();
        }

        private void btnCopyFromRight_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(txtLeftDir.Text) || !Directory.Exists(txtRightDir.Text))
            {
                MessageBox.Show("폴더를 선택해주세요.");
                return;
            }

            if (lvwrightDir.SelectedItems.Count == 0)
            {
                MessageBox.Show("파일 또는 폴더를 선택하세요.");
                return;
            }

            foreach (ListViewItem item in lvwrightDir.SelectedItems)
            {
                CopyRecursive(
                    Path.Combine(txtRightDir.Text, item.Text),
                    Path.Combine(txtLeftDir.Text, item.Text));
            }

            LoadLeft();
            ApplyColor();
        }

        // =========================
        // 재귀 복사
        // =========================
        private void CopyRecursive(string src, string dest, bool overwriteAll = false)
        {
            if (File.Exists(src))
            {
                CopyFileWithConfirm(src, dest, overwriteAll);
            }
            else if (Directory.Exists(src))
            {
                var srcInfo = new DirectoryInfo(src);

                if (Directory.Exists(dest) && !overwriteAll)
                {
                    var destInfo = new DirectoryInfo(dest);

                    var result = MessageBox.Show(
                        $"이미 폴더가 존재합니다.\n\n" +
                        $"원본: {srcInfo.LastWriteTime}\n" +
                        $"대상: {destInfo.LastWriteTime}\n\n" +
                        $"전체 덮어쓰시겠습니까?",
                        "폴더 확인",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (result != DialogResult.Yes)
                        return;

                    overwriteAll = true;
                }

                if (!Directory.Exists(dest))
                    Directory.CreateDirectory(dest);

                foreach (var file in Directory.GetFiles(src))
                {
                    CopyFileWithConfirm(file, Path.Combine(dest, Path.GetFileName(file)), overwriteAll);
                }

                foreach (var dir in Directory.GetDirectories(src))
                {
                    CopyRecursive(dir, Path.Combine(dest, Path.GetFileName(dir)), overwriteAll);
                }
            }
        }

        private void CopyFileWithConfirm(string src, string dest, bool overwriteAll = false)
        {
            try
            {
                if (File.Exists(dest) && !overwriteAll)
                {
                    var srcInfo = new FileInfo(src);
                    var destInfo = new FileInfo(dest);

                    var result = MessageBox.Show(
                        $"이미 파일이 존재합니다.\n\n" +
                        $"원본: {srcInfo.LastWriteTime}\n" +
                        $"대상: {destInfo.LastWriteTime}\n\n" +
                        $"덮어쓰시겠습니까?",
                        "파일 확인",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

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