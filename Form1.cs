using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using WindowsInput;

namespace AutoMouseMover
{
    public partial class Form1 : Form
    {
        private readonly InputSimulator simulator = new InputSimulator();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Your code goes here
        }

        private void startcircle()
        {
            int centerX = Screen.PrimaryScreen.Bounds.Width / 2;
            int centerY = Screen.PrimaryScreen.Bounds.Height / 2;

            int radius = 400; // You can adjust the radius as needed
            double angle = 0;

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            // Simulate left mouse button down outside the loop
            simulator.Mouse.LeftButtonDown();

            while (stopwatch.ElapsedMilliseconds < 4000) // Run for 4 seconds
            {
                angle += 0.025;
                int newX = centerX + (int)(radius * Math.Cos(angle));
                int newY = centerY + (int)(radius * Math.Sin(angle));
                Cursor.Position = new System.Drawing.Point(newX, newY);
                Thread.Sleep(10);
            }

            // Simulate left mouse button up after the loop
            simulator.Mouse.LeftButtonUp();

            stopwatch.Stop();
            this.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            startcircle();
        }
    }
}
