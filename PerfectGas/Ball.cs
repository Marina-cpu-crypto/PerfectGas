﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PerfectGas
{
    class Ball: PictureBox
    {
        protected double x, y;
        int radius;
        static Random random = new Random();
        Form form;

        public Ball()
        {
            this.x = random.Next(400);
            this.y = random.Next(400);
            this.radius = 20;
            this.Load("images/red_ball.png");
            this.Width = 2 * radius;
            this.Height = 2 * radius;
            this.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        public Ball(int x, int y, Form form):this()
        {
            this.x = x;
            this.y = y;
            this.form = form;
            this.form.Controls.Add(this);
            Show();
        }

        public void Show()
        {
            this.Top = (int)y - radius;
            this.Left = (int)x - radius;
        }
    }

    class MoveBall : Ball
    {
        double vx=5, vy=5;
        Timer timer;
        public MoveBall(int x, int y, Form form): base(x,y,form)
        {
            timer = new Timer();
            timer.Enabled = true;
            timer.Interval = 10;
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            Move();
            Show();
        }

        public void Move()
        {
            x = x + vx;
            y = y + vy;
        }
    }
}
