﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PyxisLE_API;
using System.Collections;

namespace PyxisLE_Control
{
    public partial class MainForm : Form
    {

        private Rotators RotatorMonitor;
        private Rotator myRotator;
        private ArrayList ControlList = new ArrayList();
        private const string NC_msg = "No connected Pyxis LE rotators are connected to the PC";
        private bool LastState = false;        

        public MainForm()
        {
            InitializeComponent();    
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ControlList.Add(SkyPA_TB);
            ControlList.Add(HomeBTN);
            
            
            RotatorMonitor = new Rotators();
            RotatorMonitor.RotatorAttached += new EventHandler(RotatorListChanged);
            RotatorMonitor.RotatorRemoved += new EventHandler(RotatorListChanged);
            myRotator = FindMyDevice();

            if (myRotator != null)
            {
                StatusLabel.Text = "Connected to Pyxis LE with serial number: " + myRotator.SerialNumber;
                EnableControls();
            }
            else
            {
 
                StatusLabel.Text = "Searching for Pyxis LE...";
                DisableControls();
            }
        }

        void RotatorListChanged(object sender, EventArgs e)
        {
            if (myRotator != null)
            {
                if (myRotator.IsAttached) return;
                else
                {
                    DisableControls();
                    myRotator = null;
                }
            }
            else  // myRotator = NULL
            {
                myRotator = FindMyDevice();
                if (myRotator != null) EnableControls();
            }
        }

        #region Enable/Disable Controls Methods

        private void EnableControls()
        {
            this.BeginInvoke(new DelNoParms(enableControls));
        }

        private void enableControls()
        {
            StatusLabel.Text = "Connected to Pyxis LE with serial number: " + myRotator.SerialNumber;
            foreach (Control x in ControlList)
            {
                x.Enabled = true;
            }
            SkyPA_TB.Text = myRotator.CurrentSkyPA.ToString() + "°";
            RotatorDiagram.Visible = true;
        }

        private void DisableControls()
        {
            this.BeginInvoke(new DelNoParms(disableControls));
        }

        private void disableControls()
        {
            StatusLabel.Text = "Searching for Pyxis LE...";
            foreach (Control x in ControlList)
            {
                x.Enabled = false;
            }
            SkyPA_TB.Text = "";
            RotatorDiagram.Visible = false;
        }

        private Rotator FindMyDevice()
        {
            Rotator r = null;
            if (RotatorMonitor.RotatorList.Count > 0)
            {
                r = RotatorMonitor.RotatorList[0] as Rotator;
            }
            return r;
        }

        private delegate void DelNoParms();

        #endregion

        #region UpdateDisplay Methods

        private void RotatorDiagram_Paint(object sender, PaintEventArgs e)
        {
            if (myRotator == null || myRotator.IsAttached == false) return;
            PictureBox sndr = sender as PictureBox;
            double center_x = sndr.Size.Width / 2;
            double center_y = sndr.Size.Height / 2;

            double x_zero = 0;
            double y_zero = -((double)center_y * 0.72D);

            double RotationAngle_Rad = myRotator.CurrentSkyPA * (Math.PI / 180);
            double x_rotated = x_zero * Math.Cos(RotationAngle_Rad) + y_zero * Math.Sin(RotationAngle_Rad);
            double y_rotated = (-(x_zero) * Math.Sin(RotationAngle_Rad)) + y_zero * Math.Cos(RotationAngle_Rad);

            Graphics g = e.Graphics;
            Pen p = new Pen(Color.OrangeRed, 3);
            g.DrawLine(p, new Point((int)center_x - 1, (int)center_y), new Point((int)(x_rotated + center_x - 1), (int)(y_rotated + center_y)));

        }

        private void RotatorDiagram_Click(object sender, EventArgs e)
        {
            MouseEventArgs ClickedPt = e as MouseEventArgs;
            double x1 = RotatorDiagram.Size.Width / 2;
            double y1 = RotatorDiagram.Size.Height / 2;
            double x2 = ClickedPt.X;
            double y2 = ClickedPt.Y;
            double dx = x2 - x1;
            double dy = y2 - y1;

            // Make sure it is within the blue border
            double DistFromCenter = Math.Sqrt((Math.Abs(dx) * Math.Abs(dx)) + (Math.Abs(dy) * Math.Abs(dy)));
            if (((DistFromCenter / y1) <= .76) && ((DistFromCenter / y1) >= .45))
            {
                double radians = Math.Atan2(dy, dx);
                double angle = -(radians * (180 / Math.PI) - 180);
                angle = angle + 90;
                if (angle > 360) angle = (angle - 360);
                StartAMove(angle);
            }
        }

        #endregion

        bool Connected
        {
            get
            {
                if(LastState == false)
                {
                    myRotator = FindMyDevice();
                }
                
                if (myRotator == null) return false;
                if (!myRotator.IsAttached)
                {
                    myRotator = null;
                    return false;
                }
                return true;
                
            }
        }

        private void HomeBTN_Click(object sender, EventArgs e)
        {
            myRotator.Home();
            MotionMonitor();
        }

        private void MotionMonitor()
        {
            System.Threading.Thread.Sleep(200);
            while (myRotator.IsMoving || myRotator.IsHoming)
            {
                this.Invoke(new DelNoParms(RotatorDiagram.Refresh));
                this.Invoke(new DelNoParms(UpdateSkyPATextbox));
                Application.DoEvents();
            }
            this.Invoke(new DelNoParms(RotatorDiagram.Refresh));
            this.Invoke(new DelNoParms(UpdateSkyPATextbox));
            Application.DoEvents();
        }

        private void UpdateSkyPATextbox()
        {
            this.SkyPA_TB.Text = myRotator.CurrentSkyPA.ToString() + "°";
        }

        private void SetPA_BTN_Click(object sender, EventArgs e)
        {
            SetSkyPA_Frm frm = new SetSkyPA_Frm();
            frm.OldPAValue = myRotator.CurrentSkyPA;
            DialogResult result = frm.ShowDialog();
            double NewOffset = 0;
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                if (myRotator.CurrentDevicePA <= frm.NewPAValue)
                {
                    NewOffset = frm.NewPAValue - myRotator.CurrentDevicePA;
                }
                else NewOffset = myRotator.CurrentDevicePA - frm.NewPAValue;
                myRotator.SkyPAOffset = NewOffset;
                this.Invoke(new DelNoParms(RotatorDiagram.Refresh));
                this.Invoke(new DelNoParms(UpdateSkyPATextbox));
                Application.DoEvents();
            }

            frm.Dispose();
        }

        private void StartAMove(double newpos)
        {
            myRotator.CurrentSkyPA = newpos;
            MotionMonitor();
        }

        private void AbsoluteMove_TB_Validating(object sender, CancelEventArgs e)
        {
            double NewPA;
            TextBox sndr = sender as TextBox;
            try
            {
                NewPA = double.Parse(sndr.Text);
                errorProvider1.Clear();
                if (NewPA > 360)
                {
                    errorProvider1.SetError(sndr, "Position angle can not exceed 360°");
                    e.Cancel = true;
                }
                if (NewPA < 0)
                {
                    errorProvider1.SetError(sndr, "Position angle must be positive");
                    e.Cancel = true;
                }

            }
            catch
            {
                errorProvider1.SetError(sndr, "Must be a number");
                e.Cancel = true;
            }

        }

        private void AbsoluteMove_BTN_Click(object sender, EventArgs e)
        {
            
            double pos = double.Parse(AbsoluteMove_TB.Text);
            StartAMove(pos);
            if (pos == 360) AbsoluteMove_TB.Text = "0";
        }

        private void RelativeIncrement_TB_Validating(object sender, CancelEventArgs e)
        {
            double NewIncrement;
            TextBox sndr = sender as TextBox;
            try
            {
                NewIncrement = double.Parse(sndr.Text);
                errorProvider1.Clear();
                if (NewIncrement >= 360)
                {
                    errorProvider1.SetError(sndr, "Increment must be less than 360°");
                    e.Cancel = true;
                }
                if (NewIncrement < 0)
                {
                    errorProvider1.SetError(sndr, "Increment must be greater than 0");
                    e.Cancel = true;
                }

            }
            catch
            {
                errorProvider1.SetError(sndr, "Must be a number");

            }

        }

        private void showDeviceDiagramToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void RelativeForward_BTN_Click(object sender, EventArgs e)
        {
            double increment = double.Parse(RelativeIncrement_TB.Text);
            if (increment == 0) return;
            double NewPositon = myRotator.CurrentSkyPA + increment;
            if (NewPositon > 360) NewPositon = NewPositon - 360;
            if (NewPositon < 0) NewPositon = NewPositon + 360;
            StartAMove(NewPositon);
        }

        private void RelativeReverse_Btn_Click(object sender, EventArgs e)
        {
            double increment = double.Parse(RelativeIncrement_TB.Text);
            if (increment == 0) return;
            double NewPositon = myRotator.CurrentSkyPA - increment;
            if (NewPositon > 360) NewPositon = NewPositon - 360;
            if (NewPositon < 0) NewPositon = NewPositon + 360;
            StartAMove(NewPositon);
        }

        private void AbsoluteMove_TB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                CancelEventArgs c = new CancelEventArgs();
                AbsoluteMove_TB_Validating(AbsoluteMove_TB, c);
                if (c.Cancel == false)
                {
                    AbsoluteMove_BTN_Click(this.AbsoluteMove_BTN, EventArgs.Empty);
                    e.Handled = true;
                }
            }
            
        }

        private void RelativeIncrement_TB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                this.RelativeForward_BTN.Focus();
                e.Handled = true;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RotatorMonitor = null;
            this.Close();
        }

        private void advancedSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdvancedForm frm = new AdvancedForm(myRotator);
            frm.ShowDialog();
        }
    }
}
