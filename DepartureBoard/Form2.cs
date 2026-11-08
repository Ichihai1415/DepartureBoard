namespace DepartureBoard
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        public void UpdateImage(Bitmap img)
        {
            pictureBox1.BackgroundImage = img;

        }

        bool max = false;
        private void Form2_Click(object sender, EventArgs e)
        {
            if (max)
            {
                Size = new Size(800, 450);
                FormBorderStyle = FormBorderStyle.Sizable;
            }
            else
            {
                FormBorderStyle = FormBorderStyle.None;
                Size = new Size(1920, 1080);
            }

            Location = max ? new Point(100, 100) : new Point(0, 0);

            TopMost = !max;
            max = !max;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (max)
            {
                Size = new Size(800, 450);
                FormBorderStyle = FormBorderStyle.Sizable;
            }
            else
            {
                FormBorderStyle = FormBorderStyle.None;
                Size = new Size(1920, 1080);
            }

            Location = max ? new Point(100, 100) : new Point(0, 0);

            TopMost = !max;
            max = !max;
        }
    }
}
