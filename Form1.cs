using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculatorCSharp
{
    public partial class FrmCalculator : Form
    {
        Double resultValue = 0;
        String operationPerformed = "";
        bool isOperationPerformed = false;
        public FrmCalculator()
        {
            InitializeComponent();
        }
        //xoa 1 ky tu
        private void btnX_Click(object sender, EventArgs e)
        {
            if (txtDisplay.Text.Length > 0)
            {
                txtDisplay.Text = txtDisplay.Text.Remove(txtDisplay.Text.Length - 1, 1);
            }
            else if (txtDisplay.Text == "0")
            {
                txtDisplay.Text = "0";
            }

        }
        private void NhapSo(string so)
        {
            if (IsTypingNumber)
            {
                txtDisplay.Text = txtDisplay.Text + so;
            }
            else
            {
                txtDisplay.Text = so;
                IsTypingNumber = true;
            }
        }
        private void Number_Click(object sender, EventArgs e)
        {
            if ((txtDisplay.Text == "0") || (isOperationPerformed)) {
                txtDisplay.Clear();
            }
            isOperationPerformed = false;
            Button button = (Button)sender;
            if (button.Text == ".")
            {
                if (!txtDisplay.Text.Contains("."))
                {
                    txtDisplay.Text = txtDisplay.Text + button.Text;
                }
            }
            else
            {
                txtDisplay.Text = txtDisplay.Text + button.Text;
            }
        }
        //nut cong tru
        double firstNumber, secondNumber;
        private void BtnCongTru_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = ((double.Parse(txtDisplay.Text)) * -1.0).ToString();
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            lblShowOperation.Text = "";
            txtDisplay.Text = "0";
        }

        private void btnCE_Click(object sender, EventArgs e)
        {
            //txtDisplay.Clear();
            lblShowOperation.Text = "";
            txtDisplay.Text = "0";
        }
        //private void buttonOperator(object sender, EventArgs e)
        //{

        //}

        private void bntPI_Click(object sender, EventArgs e)
        {
            //double PI = 3.14;
            txtDisplay.Text = System.Math.PI.ToString();
        }

        private void FrmCalculator_Load(object sender, EventArgs e)
        {
            lblShowOperation.Text = "";
        }
        enum PhepToan {
            Cong, Tru, Nhan, Chia
        };
        bool IsTypingNumber = false;
        PhepToan pheptoan;
        double remember;

        private void btnBinhPhuong_Click(object sender, EventArgs e)
        {
            double a;
            lblShowOperation.Text = txtDisplay.Text + "^2";
            a = Convert.ToDouble(txtDisplay.Text) * Convert.ToDouble(txtDisplay.Text);
            txtDisplay.Text = a.ToString();
            //txtDisplay.Text = ((double.Parse(txtDisplay.Text)) * (double.Parse(txtDisplay.Text))).ToString();
        }

        private void btnLapPhuong_Click(object sender, EventArgs e)
        {
            double b;
            lblShowOperation.Text = txtDisplay.Text + "^3";
            b = Convert.ToDouble(txtDisplay.Text) * Convert.ToDouble(txtDisplay.Text) * Convert.ToDouble(txtDisplay.Text);
            txtDisplay.Text = b.ToString();
        }

        private void btn1ChiaX_Click(object sender, EventArgs e)
        {
            double c;
            lblShowOperation.Text = "1 / ";
            c = 1 / Convert.ToDouble(txtDisplay.Text);
            txtDisplay.Text = c.ToString();
        }

        private void rdbDegree_CheckedChanged(object sender, EventArgs e)
        {
            txtDisplay.Text = "";
            lblShowOperation.Text = "D";

        }

        private void rdbRadian_CheckedChanged(object sender, EventArgs e)
        {
            txtDisplay.Text = "";
            lblShowOperation.Text = "R";
        }

        private void rdbGrads_CheckedChanged(object sender, EventArgs e)
        {
            txtDisplay.Text = "";
            lblShowOperation.Text = "G";
        }
        private double convertToDegree(double rad)
        {
            return (180 / Math.PI) * rad;
        }
        private double convertToRadian(double angle)
        {
            return (System.Math.PI / 180) * angle;
        }
        private void btnCos_Click(object sender, EventArgs e)
        {
            if (rdbRadian.Checked == true)
            {
                double tinhCos = double.Parse(txtDisplay.Text);
                lblShowOperation.Text = "sin" + "(" + txtDisplay.Text + ")";
                tinhCos = Math.Sin(tinhCos);
                txtDisplay.Text = tinhCos.ToString();
            }
            else if (rdbDegree.Checked == true)
            {
                double tinhCos2 = double.Parse(txtDisplay.Text);
                lblShowOperation.Text = "sin" + "(" + txtDisplay.Text + ")";
                tinhCos2 = convertToRadian(tinhCos2);
                txtDisplay.Text = (Math.Sin(tinhCos2)).ToString();
            }
        }

        private void btnTan_Click(object sender, EventArgs e)
        {
            if (rdbRadian.Checked == true)
            {
                double tinhTan = double.Parse(txtDisplay.Text);
                lblShowOperation.Text = "sin" + "(" + txtDisplay.Text + ")";
                tinhTan = Math.Tan(tinhTan);
                txtDisplay.Text = tinhTan.ToString();
            }
            else if (rdbDegree.Checked == true)
            {
                double tinhTan2 = double.Parse(txtDisplay.Text);
                lblShowOperation.Text = "sin" + "(" + txtDisplay.Text + ")";
                tinhTan2 = convertToRadian(tinhTan2);
                txtDisplay.Text = (Math.Tan(tinhTan2)).ToString();
            }
        }

        private void btnSqrt_Click(object sender, EventArgs e)
        {
            double tinhSqrt = double.Parse(txtDisplay.Text);
            lblShowOperation.Text = "sqrt " + "(" + txtDisplay.Text + ")";
            tinhSqrt = Math.Sqrt(tinhSqrt);
            txtDisplay.Text = tinhSqrt.ToString();
        }

        private void btnOperation_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (resultValue != 0)
            {
                btnDauBang.PerformClick();
                operationPerformed = button.Text;
                lblShowOperation.Text = resultValue + " " + operationPerformed;
                isOperationPerformed = true;
            }
            else
            {
                operationPerformed = button.Text;
                resultValue = Double.Parse(txtDisplay.Text);
                lblShowOperation.Text = resultValue + " " + operationPerformed;
                isOperationPerformed = true;
            }

        }

        private void btnDauBang_Click(object sender, EventArgs e)
        {
            TinhKetQua();
        }

        private void btnSin_Click(object sender, EventArgs e)
        {
            if (rdbRadian.Checked == true)
            {
                double tinhSin = double.Parse(txtDisplay.Text);
                lblShowOperation.Text = "sin" + "(" + txtDisplay.Text + ")";
                tinhSin = Math.Sin(tinhSin);
                txtDisplay.Text = tinhSin.ToString();
            }
            else if (rdbDegree.Checked == true)
            {
                double tinhSin2 = double.Parse(txtDisplay.Text);
                lblShowOperation.Text = "sin" + "(" + txtDisplay.Text + ")";
                tinhSin2 = convertToRadian(tinhSin2);
                txtDisplay.Text = (Math.Sin(tinhSin2)).ToString();
            }
        }

        private void bntLog_Click(object sender, EventArgs e)
        {
            double tinhLog = Double.Parse(txtDisplay.Text);
            tinhLog = Math.Log10(tinhLog);
            txtDisplay.Text = System.Convert.ToString(tinhLog);
            lblShowOperation.Text = System.Convert.ToString("log" + "(" + tinhLog + ")");
        }

        private void btnBin_Click(object sender, EventArgs e)
        {
            int tinhBin = int.Parse(txtDisplay.Text);
            txtDisplay.Text = System.Convert.ToString(tinhBin, 2);
        }

        private void btnHex_Click(object sender, EventArgs e)
        {
            int tinhHex = int.Parse(txtDisplay.Text);
            txtDisplay.Text = System.Convert.ToString(tinhHex, 16);
        }

        private void btnOct_Click(object sender, EventArgs e)
        {
            int tinhOct = int.Parse(txtDisplay.Text);
            txtDisplay.Text = System.Convert.ToString(tinhOct, 8);
        }

        private void btnDec_Click(object sender, EventArgs e)
        {
            int tinhDec = int.Parse(txtDisplay.Text);
            txtDisplay.Text = System.Convert.ToString(tinhDec);
        }

        private void btnTanh_Click(object sender, EventArgs e)
        {
            if (rdbRadian.Checked == true)
            {
                double tinhTanh = double.Parse(txtDisplay.Text);
                lblShowOperation.Text = "sin" + "(" + txtDisplay.Text + ")";
                tinhTanh = Math.Tanh(tinhTanh);
                txtDisplay.Text = tinhTanh.ToString();
            }
            else if (rdbDegree.Checked == true)
            {
                double tinhTanh2 = double.Parse(txtDisplay.Text);
                lblShowOperation.Text = "sin" + "(" + txtDisplay.Text + ")";
                tinhTanh2 = convertToRadian(tinhTanh2);
                txtDisplay.Text = (Math.Tanh(tinhTanh2)).ToString();
            }

        }

        private void btnCosh_Click(object sender, EventArgs e)
        {
            if (rdbRadian.Checked == true)
            {
                double tinhCosh = double.Parse(txtDisplay.Text);
                lblShowOperation.Text = "sin" + "(" + txtDisplay.Text + ")";
                tinhCosh = Math.Cosh(tinhCosh);
                txtDisplay.Text = tinhCosh.ToString();
            }
            else if (rdbDegree.Checked == true)
            {
                double tinhCosh2 = double.Parse(txtDisplay.Text);
                lblShowOperation.Text = "sin" + "(" + txtDisplay.Text + ")";
                tinhCosh2 = convertToRadian(tinhCosh2);
                txtDisplay.Text = (Math.Cosh(tinhCosh2)).ToString();
            }

        }

        private void btnSinh_Click(object sender, EventArgs e)
        {
            if (rdbRadian.Checked == true)
            {
                double tinhSinh = double.Parse(txtDisplay.Text);
                lblShowOperation.Text = "sin" + "(" + txtDisplay.Text + ")";
                tinhSinh= Math.Sinh(tinhSinh);
                txtDisplay.Text = tinhSinh.ToString();
            }
            else if (rdbDegree.Checked == true)
            {
                double tinhSinh2 = double.Parse(txtDisplay.Text);
                lblShowOperation.Text = "sin" + "(" + txtDisplay.Text + ")";
                tinhSinh2 = convertToRadian(tinhSinh2);
                txtDisplay.Text = (Math.Sinh(tinhSinh2)).ToString();
            }

        }

        private void btnPhanTram_Click(object sender, EventArgs e)
        {
            lblShowOperation.Text = "%";
            txtDisplay.Text = Convert.ToString(double.Parse(txtDisplay.Text) / 100) .ToString() + "%";
        }


        private void TinhKetQua()
        {
            double secondNum = double.Parse(txtDisplay.Text);
            double ketqua = 0;
            switch (operationPerformed)
            {
                case "+":
                    txtDisplay.Text = (ketqua + double.Parse(txtDisplay.Text)).ToString();
                    break;
                case "-":
                    txtDisplay.Text = (ketqua + double.Parse(txtDisplay.Text)).ToString();
                    break;
                case "*":
                    txtDisplay.Text = (ketqua + double.Parse(txtDisplay.Text)).ToString();
                    break;
                case "/":
                    txtDisplay.Text = (ketqua + double.Parse(txtDisplay.Text)).ToString();
                    break;
            }
            txtDisplay.Text = ketqua.ToString();
        }
    }
}

