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
        public Form1()
        {
            InitializeComponent();
        }

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
            lvwLeftDir.View = View.Details;
            lvwLeftDir.FullRowSelect = true;
            lvwLeftDir.GridLines = true;
            lvwLeftDir.Columns.Clear();
            lvwLeftDir.Columns.Add("이름", 200);
            lvwLeftDir.Columns.Add("크기", 100);
            lvwLeftDir.Columns.Add("수정일", 150);

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
        // 왼쪽 폴더 선택
        // =========================
        private void btnLeftDir_Click(object sender, EventArgs e)
        {
            using (var dlg = new FolderBrowserDialog())
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    txtLeftDir.Text = dlg.SelectedPath;

                    if (Directory.Exists(txtRightDir.Text))
                        CompareAndDisplay();
                    else
                        PopulateSingle(lvwLeftDir, txtLeftDir.Text);
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

                    if (Directory.Exists(txtLeftDir.Text))
                        CompareAndDisplay();
                    else
                        PopulateSingle(lvwrightDir, txtRightDir.Text);
                }
            }
        }

        // =========================
        // 단일 폴더 표시
        // =========================
        private void PopulateSingle(ListView lv, string folderPath)
        {
            lv.Items.Clear();

            try
            {
                var files = Directory.EnumerateFiles(folderPath)
                                     .Select(f => new FileInfo(f))
                                     .OrderBy(f => f.Name);

                foreach (var f in files)
                {
                    var item = new ListViewItem(f.Name);
                    item.SubItems.Add(f.Length.ToString("N0"));
                    item.SubItems.Add(f.LastWriteTime.ToString("g"));
                    lv.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("오류: " + ex.Message);
            }
        }

        // =========================
        // 🔥 비교 + 색상 표시
        // =========================
        private void CompareAndDisplay()
        {
            lvwLeftDir.Items.Clear();
            lvwrightDir.Items.Clear();

            if (!Directory.Exists(txtLeftDir.Text) || !Directory.Exists(txtRightDir.Text))
                return;

            var leftFiles = Directory.EnumerateFiles(txtLeftDir.Text)
                .Select(f => new FileInfo(f))
                .ToDictionary(f => f.Name);

            var rightFiles = Directory.EnumerateFiles(txtRightDir.Text)
                .Select(f => new FileInfo(f))
                .ToDictionary(f => f.Name);

            var allNames = leftFiles.Keys.Union(rightFiles.Keys).OrderBy(n => n);

            foreach (var name in allNames)
            {
                leftFiles.TryGetValue(name, out var lf);
                rightFiles.TryGetValue(name, out var rf);

                var leftItem = new ListViewItem(name);
                leftItem.SubItems.Add(lf != null ? lf.Length.ToString("N0") : "");
                leftItem.SubItems.Add(lf != null ? lf.LastWriteTime.ToString("g") : "");

                var rightItem = new ListViewItem(name);
                rightItem.SubItems.Add(rf != null ? rf.Length.ToString("N0") : "");
                rightItem.SubItems.Add(rf != null ? rf.LastWriteTime.ToString("g") : "");

                // 색상 처리
                if (lf != null && rf != null)
                {
                    if (lf.LastWriteTime > rf.LastWriteTime)
                    {
                        leftItem.ForeColor = Color.Red;
                        rightItem.ForeColor = Color.Gray;
                    }
                    else if (lf.LastWriteTime < rf.LastWriteTime)
                    {
                        leftItem.ForeColor = Color.Gray;
                        rightItem.ForeColor = Color.Red;
                    }
                }
                else if (lf != null)
                {
                    leftItem.ForeColor = Color.Purple;
                }
                else if (rf != null)
                {
                    rightItem.ForeColor = Color.Purple;
                }

                lvwLeftDir.Items.Add(leftItem);
                lvwrightDir.Items.Add(rightItem);
            }
        }

        // =========================
        // 과제3 (아직)
        // =========================
        private void btnCopyFromLeft_Click(object sender, EventArgs e)
        {
            MessageBox.Show("과제3에서 구현");
        }

        private void btnCopyFromRight_Click(object sender, EventArgs e)
        {
            MessageBox.Show("과제3에서 구현");
        }
    }
}