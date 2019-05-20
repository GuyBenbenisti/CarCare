using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarCare
{
    public partial class TelemetricForm : Form
    {
        public TelemetricForm()
        {
            InitializeComponent();
        }

        public void changePicBoxMiddle()
        {
            pictureBoxLedsDirection.Invoke(new Action(() =>
            {
                pictureBoxLedsDirection.Image = global::CarCare.Properties.Resources.left_right_green_arrow_icon_svg_hi;
            }));
        }
        public void changePicBoxRightToLeft()
        {
            pictureBoxLedsDirection.Invoke(new Action(() =>
            {
                pictureBoxLedsDirection.Image = global::CarCare.Properties.Resources.rightToLeftArrow;
            }));
        }
        public void changePicBoxLeftToRight()
        {
            pictureBoxLedsDirection.Invoke(new Action(() =>
            {
                pictureBoxLedsDirection.Image = global::CarCare.Properties.Resources.leftToRightArrow;
            }));
        }
        public void updatePosX(double x)
        {
            //this.labelPosX.Text = x.ToString();
            labelPosX.Invoke(new Action(() => {
                labelPosX.Text = x.ToString();
            }));
        }

        public void updatePosY(double y)
        {
            //this.labelPosY.Text = y.ToString();
            labelPosY.Invoke(new Action(() => {
                labelPosY.Text = y.ToString();
            }));
        }

        public void updatePos(double x, double y)
        {
            updatePosX(x);
            updatePosY(y);
        }
    }
}
