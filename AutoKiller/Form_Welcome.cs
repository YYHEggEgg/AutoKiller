using System.Diagnostics;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using _Timer = System.Threading.Timer;

#pragma warning disable IDE1006 // ������ʽ

namespace AutoKiller
{
    public partial class Form_Welcome : Form
    {
        public Form_Welcome()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        Status s = new();
        _Timer timer = new(obj => { }, null, Timeout.Infinite, Timeout.Infinite);
        readonly List<int> progress = new();
        readonly List<int> priority = new();

        private void Form_Welcome_Load(object sender, EventArgs e)
        {
            if (HideWindow)
            {
                //ע�⣬�������Ҫ��ʹ��BeginInvoke��������Ĵ��뽫����Loadִ����Ϻ���÷���û�취ʵ����ΪLoad��ʱ���廹����ʾ����Ȼ�������Shown�¼�
                BeginInvoke(new Action(() =>
                {
                    Hide();
                    Opacity = 1;
                }));
                WindowHidden = true;
            }
            listView_rules.View = View.Details;
            //listView_rules.Columns.Add("����", 120, HorizontalAlignment.Left);
            //listView_rules.Columns.Add("����", 120, HorizontalAlignment.Left);
            Print("AutoKiller����Ҷ�޶��棩������");

            #region Deserialize
            string dic = AppDomain.CurrentDomain.BaseDirectory;
            string staPath = $@"{dic}\status.json";
            if (File.Exists(staPath))
            {
                Print("���ڶ�ȡ����...");
                string jsonString = File.ReadAllText(staPath);
                Status? tmp = JsonSerializer.Deserialize<Status>(jsonString);
                if (tmp != null)
                {
                    s = tmp;
                    CreateUI();
                    Print("��ȡ�ɹ���");
                    #region Init
                    for (int i = 0; i < s.cnt; i++)
                    {
                        progress.Add(0);
                        priority.Add(3);
                    }
                    #endregion
                }
                else
                {
                    if (MessageBox.Show($"�����ļ��𻵣����������޷������ء�{Environment.NewLine}" +
                        $"����ȷ�����ɷ��������ļ���{Environment.NewLine}" +
                        $"����ȡ�������˳�����") != DialogResult.OK)
                    {
                        Process.GetCurrentProcess().Kill();
                    }
                }
            }
            #endregion

            StartService();
        }

        //Control NotifyIcon
        #region HideWindow Control
        public static bool HideWindow = false;
        private void notifyIcon_show_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            WindowHidden = false;
            UpdateUI();
            FlushBuffer();
        }

        private void button_hide_Click(object sender, EventArgs e)
        {
            Hide();
            WindowHidden = true;
        }
        #endregion

        //RichTextBox Console
        #region Console (RichTextBox)
        StringBuilder buffer = new();
        private void Print(string str)
        {
            str = $"{DateTime.Now} {str}{Environment.NewLine}";
            if (WindowHidden) SaveToBuffer(str);
            else richTextBox_output.AppendText(str);
        }

        private void SaveToBuffer(string str)
        {
            buffer.Append(str);
            if (buffer.Length > 10000) FlushBuffer();
        }

        private void FlushBuffer()
        {
            richTextBox_output.AppendText($"[ {DateTime.Now} �ָ��˿���̨ ]{Environment.NewLine}");
            richTextBox_output.AppendText(buffer.ToString());
            buffer = new();
        }
        #endregion

        //Rules Management
        #region Create New Rule
        private void button_new_Click(object sender, EventArgs e)
        {
            Form_Newrule.NewruleCompleted += Form_Welcome_NewruleCompleted;
            new Form_Newrule().ShowDialog();
            Form_Newrule.NewruleCompleted -= Form_Welcome_NewruleCompleted;
        }

        private void Form_Welcome_NewruleCompleted(string content, string description)
        {
            var _today = Today;

            #region Update Rules
            BeginUpdateRules();
            s.rules.Add(new Status.Rule { content = content, description = description });
            s.forbidcnts.Add(new());
            //s.forbidcnts[s.cnt].Add(Today, 0);
            s.forbidcnts[s.cnt][_today] = 0;
            progress.Add(0);
            priority.Add(3);
            Print($"�ɹ������¹���{content} ({description})");
            EndUpdateRules();
            #endregion

            #region Update Listview
            listView_rules.BeginUpdate();

            ListViewItem ls = new();
            ls.Text = s.rules[s.cnt].description;
            ls.SubItems.Add(s.rules[s.cnt].content);
            ls.SubItems.Add(s.forbidcnts[s.cnt][_today].ToString());
            listView_rules.Items.Add(ls);

            listView_rules.EndUpdate();
            #endregion

            s.cnt++;
        }

        private static Date Today
        {
            get
            {
                var now = DateTime.Now;
                return new Date(now.Year, now.Month, now.Day);
            }
        }
        #endregion

        #region Delete Selected rule
        private void DeleteSelectedRules()
        {
            tok.Dispose();
            List<int> selected = new();
            for (int i = 0; i < listView_rules.SelectedItems.Count; i++)
            {
                int index = listView_rules.SelectedItems[i].Index;
                selected.Add(index);
            }
            selected.Sort((l, r) => - l.CompareTo(r));
            listView_rules.BeginUpdate();
            foreach (var index in selected)
            {
                Print($"ɾ���˵� {index} ������{s.rules[index].content} ({s.rules[index].description})");
                listView_rules.Items.RemoveAt(index);
                s.forbidcnts.RemoveAt(index);
                s.rules.RemoveAt(index);
                s.cnt--;
            }
            listView_rules.EndUpdate();
            Print($"ɾ�������ѳɹ�����ɾ���� {selected.Count} ������");
            EndUpdateRules();
        }

        public static event Action? LongTimeActionCompleted;
        public _Timer tok = new(obj => { }, null, Timeout.Infinite, Timeout.Infinite);
        private void button_deleterule_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("���Ҫ����ɾ������Ĳ�����������ͣ������ܼ���������ȷ�����Ա�����ͬ����ͣ���񲢵ȴ����һ��ɨ�������",
                "����", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                Print("�û�����ɾ������");
                new Form_Notice().Show();
                BeginUpdateRules();
                Form_Notice.CancelAndClose += () => Close();
                Print("�ȴ�����ֹͣ...");
                tok = new(obj =>
                {
                    if (!running)
                    {
                        Print("������ֹͣ");
                        tok.Change(Timeout.Infinite, Timeout.Infinite);
                        LongTimeActionCompleted?.Invoke();
                        DeleteSelectedRules();
                    }
                }, null, 500, 1000);
            }
        }
        #endregion

        //Service
        #region Service
        private void StartService()
        {
            for (int i = 0; i < s.rules.Count; i++)
            {
                priority.Add(3);
            }
            timer = new(obj => StopProcess(), null, 0, 3000);
            Print("AutoKiller ����������");
        }

        #region Manage Thread Security
        private bool beginupdate = false;
        private bool running = false;
        private void BeginUpdateRules()
        {
            beginupdate = true;
            Print("AutoKiller ��������ͣ");
        }

        private void EndUpdateRules()
        {
            beginupdate = false;
            Print("AutoKiller �����ѻָ�");
        }
        #endregion

        private void StopProcess()
        {
            if (beginupdate) return;
            running = true;

            #region Priority Examination
            int _rulecnt = s.rules.Count;
            for (int i = 0; i < _rulecnt; i++)
            {
                progress[i] += 3;
            }
            List<int> examinequeue = new();
            for (int i = 0; i < _rulecnt; i++)
            {
                if (progress[i] == priority[i])
                {
                    examinequeue.Add(i);
                    progress[i] = 0;
                }
            }
            if (examinequeue.Count == 0)
            {
                running = false;
                return;
            }
            #endregion

            #region Process Sort (nlogn)
            var pros = Process.GetProcesses();
            List<string> pronames = new(pros.Length);
            foreach (var pro in pros)
            {
                pronames.Add(pro.ProcessName);
            }
            pronames.Sort();
            var prolist = pros.ToList();
            prolist.Sort((l, r) => l.ProcessName.CompareTo(r.ProcessName));
            #endregion

            #region Binary Search Execute
            var _today = Today;
            foreach (int i in examinequeue)
            {
                string nam = s.rules[i].content;
                int it = BinarySearch(pronames, nam);
                if (it >= 0)
                {
                    int j = it;
                    if (priority[i] > 3) priority[i] -= 3;
                    for (; j < prolist.Count; j++)
                    {
                        if (pronames[j] == nam)
                        {
                            var pr = prolist[it];
                            pr.Kill();
                            Print($"ֹͣ�˽��� {pr.ProcessName} [{pr.Id}]");
                        }
                        else break;
                    }
                    if (!s.forbidcnts[i].ContainsKey(_today)) s.forbidcnts[i][_today] = 0;
                    s.forbidcnts[i][_today] += j - it;
                    if (!s.sumforbidcnt.ContainsKey(_today)) s.sumforbidcnt[_today] = 0;
                    s.sumforbidcnt[_today] += j - it;
                    s.sumallcnt += j - it;
                }
            }
            #endregion

            UpdateUI();
            running = false;
        }

        private static int BinarySearch(List<string> list, string value, int l = 1, int r = -1)
        {
            if (r == -1) r = list.Count;
            while (l < r)
            {
                int mid = (l + r) / 2;
                if (value.CompareTo(list[mid]) <= 0) r = mid;
                else l = mid + 1;
            }
            if ((l < list.Count && l >= 0) && list[l] == value) return l;
            return -1;
        }
        #endregion

        #region ListViewUI
        private void CreateUI()
        {
            var _today = Today;
            listView_rules.BeginUpdate();
            for (int i = 0; i < s.rules.Count; i++)
            {
                ListViewItem ls = new();
                ls.Text = s.rules[i].description;
                ls.SubItems.Add(s.rules[i].content);
                if (!s.forbidcnts[i].ContainsKey(_today)) s.forbidcnts[i][_today] = 0;
                ls.SubItems.Add(s.forbidcnts[i][_today].ToString());
                listView_rules.Items.Add(ls);
            }
            listView_rules.EndUpdate();
        }

        private bool WindowHidden;
        private void UpdateUI()
        {
            if (!WindowHidden)
            {
                var _today = Today;
                if (!s.sumforbidcnt.ContainsKey(_today)) s.sumforbidcnt[_today] = 0;
                label_tips.Text = $"���칲��ֹ�� {s.sumforbidcnt[_today]} ��������������������������ֹ�� {s.sumallcnt} ���������������������ҲҪ�ú�Ŭ��Ŷ��";

                listView_rules.BeginUpdate();
                for (int i = 0; i < listView_rules.Items.Count; i++)
                {
                    if (s.forbidcnts[i].ContainsKey(_today))
                        listView_rules.Items[i].SubItems[2].Text = s.forbidcnts[i][_today].ToString();
                }
                listView_rules.EndUpdate();
            }
        }
        #endregion

        //Serialize before closing
        private void Form_Welcome_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer.Dispose();
            string dic = AppDomain.CurrentDomain.BaseDirectory;
            string staPath = $@"{dic}\status.json";
            string jsonString = JsonSerializer.Serialize(s, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(staPath, jsonString);
        }
    }

    public class Status : IJsonOnSerializing, IJsonOnDeserialized
    {
        public Status()
        {
            list_forbidcnts = new();
            list_sumforbidcnt = new();
            forbidcnts = new();
            sumforbidcnt = new();
            sumallcnt = 0;
            rules = new();
            cnt = 0;
        }

        [JsonIgnore] public List<Dictionary<Date, int>> forbidcnts { get; set; }
        [JsonIgnore] public Dictionary<Date, int> sumforbidcnt { get; set; }
        public int sumallcnt { get; set; }

        public List<Rule> rules { get; set; }
        public int cnt { get; set; }

        [Serializable]
        public class Rule
        {
            public string content { get; set; }
            public string description { get; set; }
        }

        #region List Serialize
        public List<List<KeyValuePair<Date, int>>> list_forbidcnts { get; set; }
        public List<KeyValuePair<Date, int>> list_sumforbidcnt { get; set; }

        public void OnSerializing()
        {
            list_forbidcnts = new();
            list_sumforbidcnt = new();

            foreach (var list in forbidcnts)
            {
                list_forbidcnts.Add(list.ToList());
            }

            list_sumforbidcnt = sumforbidcnt.ToList();
        }

        public void OnDeserialized()
        {
            foreach (var list in list_forbidcnts)
            {
                forbidcnts.Add(new(list));
            }

            sumforbidcnt = new(list_sumforbidcnt);

            list_forbidcnts.Clear();
            list_sumforbidcnt.Clear();
        }
        #endregion
    }

    public class Date
    {
        public int year { get; set; }
        public int month { get; set; }
        public int day { get; set; }

        public Date()
        {
            year = 0;
            month = 0;
            day = 0;
        }

        public Date(int y, int m, int d)
        {
            year = y;
            month = m;
            day = d;
        }

        public Date(int hashcode)
        {
            day = hashcode % 100;
            hashcode /= 100;
            month = hashcode % 100;
            hashcode /= 100;
            year = hashcode;
        }

        public override int GetHashCode()
        {
            return year * 10000 + month * 100 + day;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj is not Date) return false;
            return year == ((Date)obj).year && month == ((Date)obj).month && day == ((Date)obj).day;  
        }

        public override string ToString()
        {
            return GetHashCode().ToString();
        }
    }
}