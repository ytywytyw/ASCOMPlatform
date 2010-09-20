using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ASCOM.TelescopeSimulator
{
    public partial class frmMain : Form
    {
        delegate void SetTextCallback(string text);

        private Utilities.Util m_Util = new ASCOM.Utilities.Util();
        public frmMain()
        {
            InitializeComponent();

        }
        public void DoSetupDialog()
        {
            SetupDialogForm setupForm = new SetupDialogForm();

            setupForm.VersionOneOnly = TelescopeHardware.VersionOneOnly;
            setupForm.CanFindHome = TelescopeHardware.CanFindHome;
            setupForm.CanPark = TelescopeHardware.CanPark;
            setupForm.NumberMoveAxis = TelescopeHardware.NumberMoveAxis;
            setupForm.OnTop = TelescopeHardware.OnTop;
            setupForm.CanPulseGuide = TelescopeHardware.CanPulseGuide;
            setupForm.CanSetEquatorialRates = TelescopeHardware.CanSetEquatorialRates;
            setupForm.CanSetGuideRates = TelescopeHardware.CanSetGuideRates;
            setupForm.CanSetPark = TelescopeHardware.CanSetPark;
            setupForm.CanSetPierSide = TelescopeHardware.CanSetPierSide;
            setupForm.CanSetTracking = TelescopeHardware.CanSetTracking;
            setupForm.CanSlew = TelescopeHardware.CanSlew;
            setupForm.CanAlignmentMode = TelescopeHardware.CanAlignmentMode;
            setupForm.AlignmentMode = TelescopeHardware.AlignmentMode;
            setupForm.CanOptics = TelescopeHardware.CanOptics;
            setupForm.ApertureArea = TelescopeHardware.ApertureArea;
            setupForm.ApertureDiameter = TelescopeHardware.ApertureDiameter;
            setupForm.FocalLength = TelescopeHardware.FocalLength;
            setupForm.CanSlewAltAz = TelescopeHardware.CanSlewAltAz;
            setupForm.CanSlewAltAzAsync = TelescopeHardware.CanSlewAltAzAsync;
            setupForm.CanSlewAsync = TelescopeHardware.CanSlewAsync;
            setupForm.CanSync = TelescopeHardware.CanSync;
            setupForm.CanSyncAltAz = TelescopeHardware.CanSyncAltAz;
            setupForm.CanUnpark = TelescopeHardware.CanUnpark;
            setupForm.CanAltAz = TelescopeHardware.CanAltAz;
            setupForm.CanDateTime = TelescopeHardware.CanDateTime;
            setupForm.CanDoesRefraction = TelescopeHardware.CanDoesRefraction;
            setupForm.CanEquatorial = TelescopeHardware.CanEquatorial;
            setupForm.CanLatLongElev = TelescopeHardware.CanLatLongElev;
            setupForm.CanPierSide = TelescopeHardware.CanPierSide;
            setupForm.CanDualAxisPulseGuide = TelescopeHardware.CanDualAxisPulseGuide;
            setupForm.AutoTrack = TelescopeHardware.AutoTrack;
            setupForm.DisconnectOnPark = TelescopeHardware.DisconnectOnPark;
            setupForm.Refraction = TelescopeHardware.Refraction;
            setupForm.CanTrackingRates = TelescopeHardware.CanTrackingRates;
            setupForm.CanSiderealTime = TelescopeHardware.CanSiderealTime;
            setupForm.NoCoordinatesAtPark = TelescopeHardware.NoCoordinatesAtPark;
            setupForm.EquatorialSystem = TelescopeHardware.EquatorialSystem;
            setupForm.Elevation = TelescopeHardware.Elevation;
            setupForm.Latitude = TelescopeHardware.Latitude;
            setupForm.Longitude = TelescopeHardware.Longitude;
            setupForm.MaximumSlewRate = TelescopeHardware.MaximumSlewRate;

            DialogResult ans = setupForm.ShowDialog(this);

            if (ans == DialogResult.OK)
            {
                TelescopeHardware.VersionOneOnly = setupForm.VersionOneOnly;
                TelescopeHardware.CanFindHome = setupForm.CanFindHome;
                TelescopeHardware.CanPark = setupForm.CanPark;
                TelescopeHardware.NumberMoveAxis = setupForm.NumberMoveAxis;
                TelescopeHardware.OnTop = setupForm.OnTop;
                TelescopeHardware.CanPulseGuide = setupForm.CanPulseGuide;
                TelescopeHardware.CanSetEquatorialRates = setupForm.CanSetEquatorialRates;
                TelescopeHardware.CanSetGuideRates = setupForm.CanSetGuideRates;
                TelescopeHardware.CanSetPark = setupForm.CanSetPark;
                TelescopeHardware.CanSetPierSide = setupForm.CanSetPierSide;
                TelescopeHardware.CanSetTracking = setupForm.CanSetTracking;
                TelescopeHardware.CanSlew = setupForm.CanSlew;
                TelescopeHardware.CanAlignmentMode = setupForm.CanAlignmentMode;
                TelescopeHardware.AlignmentMode = setupForm.AlignmentMode;
                TelescopeHardware.ApertureArea = setupForm.ApertureArea;
                TelescopeHardware.ApertureDiameter = setupForm.ApertureDiameter;
                TelescopeHardware.FocalLength = setupForm.FocalLength;
                TelescopeHardware.CanSlewAltAzAsync = setupForm.CanSlewAltAzAsync;
                TelescopeHardware.CanSlewAltAz = setupForm.CanSlewAltAz;
                TelescopeHardware.CanSync = setupForm.CanSync;
                TelescopeHardware.CanSyncAltAz = setupForm.CanSyncAltAz;
                TelescopeHardware.CanUnpark = setupForm.CanUnpark;
                TelescopeHardware.CanAltAz = setupForm.CanAltAz;
                TelescopeHardware.CanDateTime = setupForm.CanDateTime;
                TelescopeHardware.CanDoesRefraction = setupForm.CanDoesRefraction;
                TelescopeHardware.CanEquatorial = setupForm.CanEquatorial;
                TelescopeHardware.CanLatLongElev = setupForm.CanLatLongElev;
                TelescopeHardware.CanPierSide = setupForm.CanPierSide;
                TelescopeHardware.CanDualAxisPulseGuide = setupForm.CanDualAxisPulseGuide;
                TelescopeHardware.AutoTrack = setupForm.AutoTrack;
                TelescopeHardware.DisconnectOnPark = setupForm.DisconnectOnPark;
                TelescopeHardware.Refraction = setupForm.Refraction;
                TelescopeHardware.CanTrackingRates = setupForm.CanTrackingRates;
                TelescopeHardware.CanSiderealTime = setupForm.CanSiderealTime;
                TelescopeHardware.NoCoordinatesAtPark = setupForm.NoCoordinatesAtPark;
                TelescopeHardware.EquatorialSystem = setupForm.EquatorialSystem;
                TelescopeHardware.Elevation = setupForm.Elevation;
                TelescopeHardware.Latitude = setupForm.Latitude;
                TelescopeHardware.Longitude = setupForm.Longitude;
                TelescopeHardware.MaximumSlewRate = setupForm.MaximumSlewRate;

                this.TopMost = setupForm.OnTop;
            }

            setupForm.Dispose();
        }

        private void buttonSetup_Click(object sender, EventArgs e)
        {
            DoSetupDialog();
            SetSlewButtons();
        }

        private void buttonTraffic_Click(object sender, EventArgs e)
        {
            SharedResources.TrafficForm.Show();
        }
        private void SetSlewButtons()
        {
            if (TelescopeHardware.AlignmentMode == 0)
            {
                buttonSlew1.Text = "U";
                buttonSlew2.Text = "D";
                buttonSlew3.Text = "R";
                buttonSlew4.Text = "L";
            }
            else if (TelescopeHardware.SouthernHemisphere)
            {
                buttonSlew1.Text = "S";
                buttonSlew2.Text = "N";
                buttonSlew3.Text = "E";
                buttonSlew4.Text = "W";
            }
            else
            {
                buttonSlew1.Text = "N";
                buttonSlew2.Text = "S";
                buttonSlew3.Text = "E";
                buttonSlew4.Text = "W";
            }
        }


        public double SiderealTime
        {
            set
            {
                SetTextCallback setText = new SetTextCallback(SetLstText);
                string text = m_Util.HoursToHMS(value);
                try{this.Invoke(setText, text);}
                catch { }
                
           
            }
        }
        public double RightAscension
        {
            set
            {
                SetTextCallback setText = new SetTextCallback(SetRaText);
                string text = m_Util.HoursToHMS(value);
                try { this.Invoke(setText, text); }
                catch { }
            }
        }
        public double Declination
        {
            set
            {
                SetTextCallback setText = new SetTextCallback(SetDecText);
                string text = m_Util.DegreesToDMS(value);
                try { this.Invoke(setText, text); }
                catch { }
            }
        }
        public double Altitude
        {
            set
            {
                SetTextCallback setText = new SetTextCallback(SetAltitudeText);
                string text = m_Util.DegreesToDMS(value);
                try { this.Invoke(setText, text); }
                catch { }
            }
        }
        public double Azimuth
        {
            set
            {
                SetTextCallback setText = new SetTextCallback(SetAzimuthText);
                string text = m_Util.DegreesToDMS(value);
                try { this.Invoke(setText, text); }
                catch { }
            }
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            SetSlewButtons();
            TelescopeHardware.Start();
        }

        #region Thread Safe Callback Functions
        private void SetLstText(string text)
        {
            labelLst.Text = text;
        }
        private void SetRaText(string text)
        {
            labelRa.Text = text;
        }
        private void SetDecText(string text)
        {
            labelDec.Text = text;
        }
        private void SetAltitudeText(string text)
        {
            labelAlt.Text = text;
        }
        private void SetAzimuthText(string text)
        {
            labelAz.Text = text;
        }

        #endregion

        private void checkBoxTrack_CheckedChanged(object sender, EventArgs e)
        {
            TelescopeHardware.Tracking = checkBoxTrack.Checked;
        }

        private void buttonSlew1_MouseDown(object sender, MouseEventArgs e)
        {
            TelescopeHardware.SlewState = SlewType.SlewHandpad;
            if (TelescopeHardware.AlignmentMode == 0)
            {
                
                TelescopeHardware.SlewDirection = SlewDirection.SlewUp;
            }
            else
            {
                
                if (TelescopeHardware.SouthernHemisphere)
                {
                    TelescopeHardware.SlewDirection = SlewDirection.SlewSouth;
                }
                else
                {
                    TelescopeHardware.SlewDirection = SlewDirection.SlewNorth;
                }
            }
            if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift)
            {
                TelescopeHardware.SlewSpeed = SlewSpeed.SlewMedium;
            }
            else if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
            {
                TelescopeHardware.SlewSpeed = SlewSpeed.SlewSlow;
            }
            else
            {
                TelescopeHardware.SlewSpeed = SlewSpeed.SlewFast;
            }

        }

        private void buttonSlew1_MouseUp(object sender, MouseEventArgs e)
        {
            TelescopeHardware.SlewState = SlewType.SlewNone;
        }

        private void buttonSlew2_MouseDown(object sender, MouseEventArgs e)
        {
            TelescopeHardware.SlewState = SlewType.SlewHandpad;
            if (TelescopeHardware.AlignmentMode == 0)
            {
                TelescopeHardware.SlewDirection = SlewDirection.SlewDown;
            }
            else
            {
                if (TelescopeHardware.SouthernHemisphere)
                {
                    TelescopeHardware.SlewDirection = SlewDirection.SlewNorth;
                }
                else
                {
                    TelescopeHardware.SlewDirection = SlewDirection.SlewSouth;
                }
            }
            if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift)
            {
                TelescopeHardware.SlewSpeed = SlewSpeed.SlewMedium;
            }
            else if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
            {
                TelescopeHardware.SlewSpeed = SlewSpeed.SlewSlow;
            }
            else
            {
                TelescopeHardware.SlewSpeed = SlewSpeed.SlewFast;
            }
        }

        private void buttonSlew2_MouseUp(object sender, MouseEventArgs e)
        {
            TelescopeHardware.SlewState = SlewType.SlewNone;
        }

        private void buttonSlew3_MouseDown(object sender, MouseEventArgs e)
        {
            TelescopeHardware.SlewState = SlewType.SlewHandpad;
            if (TelescopeHardware.AlignmentMode == 0)
            {
                TelescopeHardware.SlewDirection = SlewDirection.SlewRight;
            }
            else
            {
                
                TelescopeHardware.SlewDirection = SlewDirection.SlewEast;
                
            }
            if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift)
            {
                TelescopeHardware.SlewSpeed = SlewSpeed.SlewMedium;
            }
            else if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
            {
                TelescopeHardware.SlewSpeed = SlewSpeed.SlewSlow;
            }
            else
            {
                TelescopeHardware.SlewSpeed = SlewSpeed.SlewFast;
            }
        }

        private void buttonSlew3_MouseUp(object sender, MouseEventArgs e)
        {
            TelescopeHardware.SlewState = SlewType.SlewNone;
        }

        private void buttonSlew4_MouseDown(object sender, MouseEventArgs e)
        {
            TelescopeHardware.SlewState = SlewType.SlewHandpad;
            if (TelescopeHardware.AlignmentMode == 0)
            {
                TelescopeHardware.SlewDirection = SlewDirection.SlewRight;
            }
            else
            {

                TelescopeHardware.SlewDirection = SlewDirection.SlewWest;

            }
            if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift)
            {
                TelescopeHardware.SlewSpeed = SlewSpeed.SlewMedium;
            }
            else if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
            {
                TelescopeHardware.SlewSpeed = SlewSpeed.SlewSlow;
            }
            else
            {
                TelescopeHardware.SlewSpeed = SlewSpeed.SlewFast;
            }
        }

        private void buttonSlew4_MouseUp(object sender, MouseEventArgs e)
        {
            TelescopeHardware.SlewState = SlewType.SlewNone;
        }

        private void buttonSlew0_Click(object sender, EventArgs e)
        {
            TelescopeHardware.SlewState = SlewType.SlewNone;
        }

        public void Tracking()
        {
            if (TelescopeHardware.Tracking) checkBoxTrack.Checked = true;
            else checkBoxTrack.Checked = false;
        }
        public void LEDPier(ASCOM.DeviceInterface.PierSide SideOfPier)
        {

        }
    }
}