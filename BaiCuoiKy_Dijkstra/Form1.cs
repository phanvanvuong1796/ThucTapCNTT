using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiCuoiKy_Dijkstra
{
    public partial class Form1 : Form
    {
        int mNumberPoints = -1;
        int mNumberEdges = -1;
        int mStartPoint = -1;
        int mEndPoint = -1;
        List<Point> mListPoint = new List<Point>();
        List<List<int>> mMattrixDistance = new List<List<int>>();
        List<Mark> mListMark = new List<Mark>();

        int mRadius = 12;
        int mScale = 3;

        bool displayRoad = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        public int distanceP2P(Point aPoint, Point bPoint)
        {
            int distance = 0;
            int deltaX = (aPoint.X - bPoint.X)/mScale;
            int deltaY = (aPoint.Y - bPoint.Y)/mScale;

            distance = Convert.ToInt32(Math.Sqrt(Math.Pow(deltaX, 2) + Math.Pow(deltaY, 2)));
            return distance;
        }

        public void initMattrixDistance()
        {
            mMattrixDistance = new List<List<int>>();
            for (int i = 0; i < mNumberPoints; i++)
            {
                List<int> listRow = new List<int>();
                for (int j = 0; j < mNumberPoints; j++)
                {
                    listRow.Add(0);
                }
                mMattrixDistance.Add(listRow);
            }
        }

        public void initPoint(int index)
        {
            Point point = new Point();
            Random random = new Random();

            bool checkExist = false;
            do
            {
                checkExist = false;
                point.X = mScale * (100 + random.Next(-100, 100));
                point.Y = mScale * (100 + random.Next(-100, 100));

                if (index > 0)
                {
                    for (int i = 0; i < mListPoint.Count; i++)
                    {
                        int distance = distanceP2P(point, mListPoint[i]);
                        if (distance >= 0 && distance <= 24)
                        {
                            checkExist = true;
                        }
                    }
                }

            } while (index > 0 && checkExist);
            mListPoint.Add(point);
        }

        private void drawAllPoint()
        {

            DialogResult result;
            //ngoại lệ
            if (txtNumberPoints.Text == "")
            {
                result = MessageBox.Show("Bạn không được để trống ô nhập dữ liệu! Yêu cầu nhập", "Lỗi thiếu đầu vào", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtNumberPoints.Text == "0" || txtNumberPoints.Text == "1")
            {
                result = MessageBox.Show("Nhập vào số điểm lớn hơn 1", "Nhập sai dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            try
            {
                if (int.Parse(txtNumberPoints.Text) > 20)
                {
                    result = MessageBox.Show("Nhập vào số điểm không quá 20", "Nhập sai dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Yêu cầu nhập số", "Nhập sai dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            mNumberPoints = int.Parse(txtNumberPoints.Text);

            initMattrixDistance();

            Random random = new Random();
            int index = 0;
            while (index < mNumberPoints)
            {
                initPoint(index);
                index++;
            }

            Draw();
        }

        public void Dijkstra()
        {
            mListMark = new List<Mark>();
            Mark mark;
            // Khởi tạo các điểm trong history và điểm bắt đầu
            for (int i = 0; i < mNumberPoints; i++)
            {
                mark = new Mark();
                mark.ToPoint = mStartPoint;
                mListMark.Add(mark);   
            }

            mListMark[mStartPoint].Length = 0;
            mListMark[mStartPoint].ToPoint = mStartPoint;
            mListMark[mStartPoint].CheckMark = true;

            // xu ly
            int tempMark = mStartPoint;
            int sum = 0;
            while (true)
            {

                // tinh do dai den cac diem ke cua diem hien tai tempMark
                for (int i = 0; i < mNumberPoints; i++)
                {
                    if (mListMark[i].CheckMark == true) continue;

                    // neu chua Duyet ta xem co ke hay khong
                    if (mMattrixDistance[i][tempMark] != 0)
                    {
                        if (mListMark[i].CheckMark == false) sum++;
                        if (mListMark[i].Length == -1 || mListMark[tempMark].Length + mMattrixDistance[i][tempMark] < mListMark[i].Length)
                        {
                            mListMark[i].Length = mListMark[tempMark].Length + mMattrixDistance[i][tempMark];
                            mListMark[i].ToPoint = tempMark;
                        }


                    }

                }

                // Tim ra diem be nhat duoc chon
                //  sum = 0;
                int dMin = 1000000;
                int tempi = 0;
                int nextTo = 0;
                for (int i = 0; i < mNumberPoints; i++)
                {
                    if (mListMark[i].CheckMark == true || mListMark[i].Length == -1) continue;

                    if (mListMark[i].Length < dMin)
                    {
                        dMin = mListMark[i].Length;
                        tempi = i;
                        nextTo++;
                    }

                }

                if (nextTo == 0) break;
                // danh dau va cap nhat lai diem duoc chon
                // history[tempi].DiemDiToi = tempMark;
                mListMark[tempi].CheckMark = true;
                tempMark = tempi;
                if (tempMark == mEndPoint) break;
            } // ket thuc while


            if (mListMark[mEndPoint].Length == -1)
            {
                rtbResult.Text = "không tồn tại đường đi từ điểm " + (mStartPoint + 1) + " tới điểm " + (mEndPoint + 1) +"\n";
            }
            else
            {
                rtbResult.Text = "Độ dài nhỏ nhất từ điểm " + (mStartPoint + 1) + " đến điểm " + (mEndPoint + 1) + " là: " + mListMark[mEndPoint].Length + "\n\nLộ trình: ";
                displayRoad = true;
            }
        }

        private void Draw()
        {
            Pen arrowPen = new Pen(Color.BlueViolet, 2);
            AdjustableArrowCap bigArrow = new AdjustableArrowCap(5, 5);
            arrowPen.CustomEndCap = bigArrow;


            Pen pen = new Pen(Color.Black, 1);
            //pen.CustomEndCap = bigArrow;

            SolidBrush brNormalPoint = new SolidBrush(Color.White);

            SolidBrush brStartPoint = new SolidBrush(Color.Green);

            SolidBrush brEndPoint = new SolidBrush(Color.Red);

            Bitmap bm = new Bitmap(ptbBackground.Width, ptbBackground.Height);
            Graphics gr = Graphics.FromImage(bm);
            gr.Clear(Color.FromArgb(219, 208, 208));
            gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            for (int i = 0; i < mNumberPoints; i++)
            {
                for (int j = 0; j < mNumberPoints; j++)
                {
                    if (mMattrixDistance[i][j] != 0)
                    {
                        gr.DrawLine(pen, mListPoint[i], mListPoint[j]);

                        gr.DrawString(mMattrixDistance[i][j].ToString(), new Font("Consolas", 8), new SolidBrush(Color.DodgerBlue), (mListPoint[i].X + mListPoint[j].X) / 2, (mListPoint[i].Y + mListPoint[j].Y) / 2);
                    }

                }
            }

            for (int i = 0; i < mNumberPoints; i++)
            {
                if (i == mStartPoint)
                {
                    gr.FillEllipse(brStartPoint, mListPoint[i].X - mRadius, mListPoint[i].Y - mRadius, mRadius * 2, mRadius * 2);
                    gr.DrawString((i + 1) + "", new Font("Consolas", 9), new SolidBrush(Color.Black), mListPoint[i].X - 6 * (mScale - 2), mListPoint[i].Y - 6 * (mScale - 2));
                }
                else if (i == mEndPoint)
                {
                    gr.FillEllipse(brEndPoint, mListPoint[i].X - mRadius, mListPoint[i].Y - mRadius, mRadius * 2, mRadius * 2);
                    gr.DrawString((i + 1) + "", new Font("Consolas", 9), new SolidBrush(Color.Black), mListPoint[i].X - 6 * (mScale - 2), mListPoint[i].Y - 6 * (mScale - 2));
                }
                else
                {
                    gr.FillEllipse(brNormalPoint, mListPoint[i].X - mRadius, mListPoint[i].Y - mRadius, mRadius * 2, mRadius * 2);
                    gr.DrawString((i + 1) + "", new Font("Consolas", 9), new SolidBrush(Color.Black), mListPoint[i].X - 6 * (mScale - 2), mListPoint[i].Y - 6 * (mScale - 2));
                }
            }

            if (displayRoad == true)
            {
                String displayPointRoad = "";
                int tempToPoint = mEndPoint;
                while (true)
                {

                    int tempFromPoint = mListMark[tempToPoint].ToPoint;
                    gr.DrawLine(arrowPen, mListPoint[tempFromPoint], mListPoint[tempToPoint]);

                    displayPointRoad = "->"+(tempToPoint+1) + displayPointRoad;


                    if (tempFromPoint == mStartPoint)
                    {
                        displayPointRoad = (tempFromPoint + 1) + displayPointRoad;
                        break;
                    }
                    
                    tempToPoint = tempFromPoint;
                }
                rtbResult.Text += displayPointRoad;
            }


            ptbBackground.Image = bm;
        }

        private void txtNumberPoints_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                drawAllPoint();
                txtNumberEdges.Focus();
            }
        }

        private void btnDrawPoint_Click(object sender, EventArgs e)
        {
            drawAllPoint();
            txtNumberEdges.Focus();
        }

        private void btnDrawEdges_Click(object sender, EventArgs e)
        {
            DialogResult result;
            //ngoại lệ
            if (mNumberPoints == -1)
            {
                result = MessageBox.Show("Nhập và khởi tạo số điểm trước", "Lỗi thiếu đầu vào", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtNumberEdges.Text == "")
            {
                result = MessageBox.Show("Bạn không được để trống ô nhập dữ liệu! Yêu cầu nhập", "Lỗi thiếu đầu vào", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                mNumberEdges = int.Parse(txtNumberEdges.Text);
            }
            catch (Exception)
            {
                result = MessageBox.Show("Yêu cầu nhập đúng số", "Lỗi sai dữ liệu đầu vào", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            //Khởi tạo lại ma trận kề
            initMattrixDistance();

            Random random = new Random();
            int x, y, distance;

            int t = 0;
            while (true)
            {
                if (t == mNumberEdges) break;

                x = random.Next(0, mNumberPoints);
                y = random.Next(0, mNumberPoints);

                if (mMattrixDistance[x][y] != 0 || x == y) continue;
                distance = distanceP2P(mListPoint[x], mListPoint[y]);
                mMattrixDistance[x][y] = distance;
                mMattrixDistance[y][x] = distance;
                t++;
            }

            Draw();
            txtStartPoint.Focus();
        }


        //public void calMaxNumberEdges()
        //{
        //    if (txtPoint.Text != null && txtPoint.Text != "")
        //    {
        //        int soDiem = int.Parse(txtPoint.Text);
        //        int soDC;
        //        if (soDiem == 0 || soDiem == 1) lbEdges.Text = "Lỗi";
        //        else if (soDiem == 2) lbEdges.Text = "1";
        //        else
        //        {
        //            soDC = soDiem + soDiem * (soDiem - 3) / 2;
        //            lbEdges.Text = soDC.ToString();
        //        }
        //    }
        //    else
        //    {
        //        lbEdges.Text = "0";
        //    }
        //}



        private void txtNumberEdges_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                DialogResult result;
                //ngoại lệ
                if (mNumberPoints == -1)
                {
                    result = MessageBox.Show("Nhập và khởi tạo số điểm trước", "Lỗi thiếu đầu vào", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (txtNumberEdges.Text == "")
                {
                    result = MessageBox.Show("Bạn không được để trống ô nhập dữ liệu! Yêu cầu nhập", "Lỗi thiếu đầu vào", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    mNumberEdges = int.Parse(txtNumberEdges.Text);
                }
                catch (Exception)
                {
                    result = MessageBox.Show("Yêu cầu nhập đúng số", "Lỗi sai dữ liệu đầu vào", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                //Khởi tạo lại ma trận kề
                initMattrixDistance();

                Random random = new Random();
                int x, y, distance;

                int t = 0;
                while (true)
                {
                    if (t == mNumberEdges) break;

                    x = random.Next(0, mNumberPoints);
                    y = random.Next(0, mNumberPoints);

                    if (mMattrixDistance[x][y] != 0 || x == y) continue;
                    distance = distanceP2P(mListPoint[x], mListPoint[y]);
                    mMattrixDistance[x][y] = distance;
                    mMattrixDistance[y][x] = distance;
                    t++;
                }

                Draw();
                txtStartPoint.Focus();
            }
        }

        int dx, dy;
        private bool checkInsideCircle(int cx, int cy, Point point)
        {

            dx = cx - (point.X);
            dy = cy - (point.Y);

            return dx * dx + dy * dy <= mRadius * mRadius;
        }

        private bool checkInside = false;
        private int checkPoint;


        private void ptbBackground_MouseDown(object sender, MouseEventArgs e)
        {
            checkInside = false;
            for (int i = 0; i < mNumberPoints; i++)
            {
                if (checkInsideCircle(e.X, e.Y, mListPoint[i]))
                {
                    if (mMouseState != PICK_START_POINT && mMouseState != PICK_END_POINT)
                    {
                        checkInside = true;
                    }
                    checkPoint = i;
                    break;
                }
                else
                {
                    if (mMouseState == MOUSE_DRAW_POINT)
                    {
                        Point point = new Point(e.X, e.Y);
                        mListPoint.Add(point);
                        mNumberPoints++;
                        Draw();
                    }
                }
            }
        }

        private void ptbBackground_MouseMove(object sender, MouseEventArgs e)
        {
            if (checkInside)
            {
                Point point = mListPoint[checkPoint];
                point.X = e.X - dx;
                point.Y = e.Y - dy;

                mListPoint[checkPoint] = point;


                for (int i = 0; i < mNumberPoints; i++)
                {
                    for (int j = 0; j < mNumberPoints; j++)
                    {
                        if (mMattrixDistance[i][j] != 0)
                        {
                            int distance = distanceP2P(mListPoint[i], mListPoint[j]);
                            mMattrixDistance[i][j] = distance;
                            mMattrixDistance[j][i] = distance;
                        }

                    }

                }

                Draw();
            }
        }

        private void ptbBackground_MouseUp(object sender, MouseEventArgs e)
        {
            checkInside = false;
            if (checkInsideCircle(e.X, e.Y, mListPoint[checkPoint]))
            {
                if (mMouseState == PICK_START_POINT)
                {
                    mStartPoint = checkPoint;
                    txtStartPoint.Text = (mStartPoint + 1) + "";
                    Draw();
                }
                else if (mMouseState == PICK_END_POINT)
                {
                    mEndPoint = checkPoint;
                    txtEndPoint.Text = (mEndPoint + 1) + "";
                    Draw();
                }
            }
            mMouseState = NORMAL_MOUSE;
        }

        const int NORMAL_MOUSE = 0;
        const int PICK_START_POINT = 1;
        const int PICK_END_POINT = 2;
        const int MOUSE_DRAW_EDGES = 3;
        const int MOUSE_MOVE = 4;
        const int MOUSE_DRAW_POINT = 5;
        


        int mMouseState = NORMAL_MOUSE;


        private void btnClickStart_Click(object sender, EventArgs e)
        {
            mMouseState = PICK_START_POINT;
        }

        private void txtStartPoint_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DialogResult result;
                //ngoại lệ
                if (txtStartPoint.Text == "")
                {
                    result = MessageBox.Show("Bạn không được để trống ô nhập dữ liệu! Yêu cầu nhập", "Lỗi thiếu đầu vào", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (txtStartPoint.Text == "0")
                {
                    result = MessageBox.Show("Nhập vào số điểm lớn hơn 1", "Nhập sai dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                try
                {
                    if (int.Parse(txtStartPoint.Text) > 20)
                    {
                        result = MessageBox.Show("Điểm nhập vào không quá 20", "Nhập sai dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Yêu cầu nhập số", "Nhập sai dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                mStartPoint = int.Parse(txtStartPoint.Text) - 1;

                txtEndPoint.Focus();
                Draw();
            }
        }

        private void btnStartPoint_Click(object sender, EventArgs e)
        {

            DialogResult result;
            //ngoại lệ
            if (txtStartPoint.Text == "")
            {
                result = MessageBox.Show("Bạn không được để trống ô nhập dữ liệu! Yêu cầu nhập", "Lỗi thiếu đầu vào", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtStartPoint.Text == "0")
            {
                result = MessageBox.Show("Nhập vào số điểm lớn hơn 1", "Nhập sai dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            try
            {
                if (int.Parse(txtStartPoint.Text) > 20)
                {
                    result = MessageBox.Show("Điểm nhập vào không quá 20", "Nhập sai dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Yêu cầu nhập số", "Nhập sai dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            mStartPoint = int.Parse(txtStartPoint.Text) - 1;

            txtEndPoint.Focus();
            Draw();
        }

        private void txtEndPoint_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DialogResult result;
                //ngoại lệ
                if (txtEndPoint.Text == "")
                {
                    result = MessageBox.Show("Bạn không được để trống ô nhập dữ liệu! Yêu cầu nhập", "Lỗi thiếu đầu vào", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (txtEndPoint.Text == "0")
                {
                    result = MessageBox.Show("Nhập vào số điểm lớn hơn 1", "Nhập sai dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                try
                {
                    if (int.Parse(txtEndPoint.Text) > 20)
                    {
                        result = MessageBox.Show("Điểm nhập vào không quá 20", "Nhập sai dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Yêu cầu nhập số", "Nhập sai dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                mEndPoint = int.Parse(txtEndPoint.Text) - 1;

                Draw();
            }
        }

        private void btnClickEnd_Click(object sender, EventArgs e)
        {
            mMouseState = PICK_END_POINT;
        }

        private void btnShowResult_Click(object sender, EventArgs e)
        {
            Dijkstra();
            displayRoad = true;
            Draw();
            displayRoad = false;
        }

        private void btnAddPoint_Click(object sender, EventArgs e)
        {
            mMouseState = MOUSE_DRAW_POINT;
        }

        private void btnAddEdge_Click(object sender, EventArgs e)
        {
            mMouseState = MOUSE_DRAW_EDGES;
        }

        private void btnEndPoint_Click(object sender, EventArgs e)
        {
            DialogResult result;
            //ngoại lệ
            if (txtEndPoint.Text == "")
            {
                result = MessageBox.Show("Bạn không được để trống ô nhập dữ liệu! Yêu cầu nhập", "Lỗi thiếu đầu vào", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtEndPoint.Text == "0")
            {
                result = MessageBox.Show("Nhập vào số điểm lớn hơn 1", "Nhập sai dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            try
            {
                if (int.Parse(txtEndPoint.Text) > 20)
                {
                    result = MessageBox.Show("Điểm nhập vào không quá 20", "Nhập sai dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Yêu cầu nhập số", "Nhập sai dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            mEndPoint = int.Parse(txtEndPoint.Text) - 1;

            Draw();
        }

    }

}
