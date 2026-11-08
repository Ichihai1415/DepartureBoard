using System.Diagnostics;
using System.Text.Json.Nodes;

namespace DepartureBoard
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Form2 displayForm = new();
        JsonNode dotJson = JsonNode.Parse(File.ReadAllText("dot-text.json"));

        private void Form1_Load(object sender, EventArgs e)
        {
            displayForm.Show();
            Ti_Sub.Enabled = true;
            //Ti_Scroll.Enabled = true;
            if (File.Exists("last.txt"))
                TB_main.Text = File.ReadAllText("last.txt");


        }

        Dictionary<char, Color> color = new()
        {
            {'0', Color.FromArgb(48,32,32) },
            {'1', Color.FromArgb(0, 255, 0)},
            {'2', Color.FromArgb(255, 136, 68)},
            {'3', Color.FromArgb(255, 0, 0)},
            {'4', Color.FromArgb(255, 255, 255)},
            {'5', Color.FromArgb(68, 68, 255)},
            {'6', Color.FromArgb(221, 170, 34)},
            {'7', Color.FromArgb(0, 187, 255)}
        };


        private void B_Restart_Click(object sender, EventArgs e)
        {
            Draw();
            File.WriteAllText("last.txt", TB_main.Text);
        }

        public void Draw()
        {
            //Task.Run(() =>
            //{
            var text = TB_main.Text;
            var lines = text.Replace("\r", "").Split("\n");

            var datas = lines.Select(Line2Dots).ToArray();


            var img = new Bitmap(1920, 1080);
            using var g = Graphics.FromImage(img);
            g.Clear(Color.Black);

            g.FillRectangle(Brushes.Gray, 0, 0, 1920, 1080);
            g.FillRectangle(new SolidBrush(Color.FromArgb(32, 32, 32)), 48, 48, 1824, 984);
            for (int i = 0; i < 10; i++)
            {

                var data = datas.Length > i ? datas[i].Replace("\r", "").Split("\n") : null;

                g.FillRectangle(Brushes.Black, 48, 48 + i * 99, 1824, 96);

                var offset = 0;
                if (data != null)
                    if (data[0].Length > 16 * 19)
                    {
                        var p = scrollNum % (16 * 19);
                        offset = -16 * 19 + p;
                        Debug.WriteLine(offset);
                    }


                //96  6 16*(16*18)
                for (int j = 0; j < 16 * 19; j++)
                {

                    for (int k = 0; k < 16; k++)
                    {
                        if (data is null)
                            g.FillEllipse(new SolidBrush(color['0']), 49 + j * 6, 49 + 99 * i + k * 6, 4, 4);
                        else
                            if (data.Length > k)
                                if (j + offset >= 0 && data[k].Length > j + offset)
                                    g.FillEllipse(new SolidBrush(color[data[k][j + offset]]), 49 + j * 6, 49 + 99 * i + k * 6, 4, 4);
                                else
                                    g.FillEllipse(new SolidBrush(color['0']), 49 + j * 6, 49 + 99 * i + k * 6, 4, 4);
                            else
                                g.FillEllipse(new SolidBrush(color['0']), 49 + j * 6, 49 + 99 * i + k * 6, 4, 4);



                        // g.FillEllipse(new SolidBrush(color["0"]), 49 + j * 6, 49 + 99 * i + k * 6, 4, 4);//int.Parse(data[k][j].ToString())
                    }
                }
            }
            Invoke(() =>
            {
                displayForm.UpdateImage(img);
            });
            //});
            return;
        }

        bool isMain = true;

        private void Ti_Sub_Tick(object sender, EventArgs e)
        {
            isMain = !isMain;
            Draw();
        }

        int scrollNum = 0;
        private void Ti_Scroll_Tick(object sender, EventArgs e)
        {
            scrollNum++;
            Draw();

        }

        public string Line2Dots(string line)
        {
            var t = line.Split("|").Select(x => x.Split(";").Select(x => x.Split(",")).ToArray()).ToArray();
            var dots = new string[16];

            var m = 0;
            if (t.Length == 2 && !isMain)
                m = 1;
            foreach (var item in t[m])
            {
                var text = item[0].Replace("　", "  ");
                var color = "1";
                var backColor = "0";
                if (item.Length > 1)
                    color = item[1];
                if (item.Length > 2)
                    backColor = item[2];

                for (int i = 0; i < text.Length; i++)
                {
                    var dot = dotJson[((int)((char)text[i])).ToString()]?.ToString();
                    if (dot is null || dot.Length < 2)
                        continue;
                    var dotL = dot.Split("\n");
                    for (int j = 0; j < 16; j++)
                        dots[j] += dotL[j].Replace("1", "_").Replace("0", backColor).Replace("_", color);
                }

            }

            return string.Join("\n", dots);
        }

    }

    public class Display
    {
        public DisplaySingle[] Displays { get; set; } = [];

        public class DisplaySingle
        {
            public required int Index { get; set; }
            public required int Width { get; set; }
            public required int Height { get; set; }

            public required System.Threading.Timer Timer { get; set; }
        }


    }

    public class Data
    {
        public required int Index { get; set; }

        public required int[][] DrawData { get; set; }
        public required int[][] DrawData_sub { get; set; }

        public required int ChangeSubMs { get; set; }


    }
}
