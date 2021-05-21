using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Windows.Forms;

namespace NSMB_Adress_Helper
{
	public class Form1 : Form
	{
		private int[] overlay_starts = new int[] { 34178784, 34390752, 34390752, 34390752, 34390752, 34390752, 34390752, 34390752, 34390752, 34390752, 34390752, 34779488, 34797824, 34797824, 34797824, 34797824, 34797824, 34797824, 34797824, 34797824, 34797824, 34797824, 34848512, 34848512, 34848512, 34848512, 34848512, 34848512, 34848512, 34848512, 34848512, 34848512, 34872960, 34872960, 34872960, 34872960, 34872960, 34872960, 34872960, 34872960, 34872960, 34872960, 34892896, 34892896, 34892896, 34892896, 34892896, 34892896, 34892896, 34892896, 34892896, 34892896, 34940992, 34983008, 34940992, 35071680, 35071680, 35071680, 35071680, 35071680, 35071680, 35071680, 35071680, 35071680, 35071680, 35071680, 35084704, 35084704, 35084704, 35084704, 35084704, 35084704, 35084704, 35084704, 35084704, 35084704, 35101120, 35101120, 35101120, 35101120, 35101120, 35101120, 35101120, 35101120, 35101120, 35101120, 35117920, 35117920, 35117920, 35117920, 35117920, 35117920, 35117920, 35117920, 35117920, 35117920, 35149312, 35149312, 35149312, 35149312, 35149312, 35149312, 35149312, 35149312, 35149312, 35149312, 35166688, 35166688, 35166688, 35166688, 35166688, 35166688, 35166688, 35166688, 35166688, 35166688, 35178432, 35178432, 35178432, 35178432, 35178432, 35178432, 35178432, 35178432, 35178432, 35178432, 34178784, 34178784, 34310432, 34310432, 34744032, 0x02380000, 0x037F8000, 0x027E0000 };

		private int[] overlay_starts_ida = new int[] { 34178784, 35153504, 35164000, 35168160, 35168192, 35171008, 35173760, 35174624, 35175584, 35328192, 34390752, 34779488, 34797824, 35393472, 35444160, 35458784, 35479104, 35496352, 35514208, 35525760, 35557696, 35573184, 34848512, 35573216, 35585408, 35600736, 35625184, 35632000, 35635904, 35658144, 35658176, 35658208, 35658240, 35665568, 35676192, 35690208, 35698080, 35704864, 35704896, 35710848, 35710880, 35730816, 35730848, 35778944, 35787104, 35787136, 35787168, 35793920, 35800000, 35808000, 35813312, 35819584, 35819616, 35861632, 34940992, 36035840, 36138304, 36151328, 36164064, 36168704, 36177920, 36181824, 36181856, 36181888, 36181920, 36181952, 36181984, 36194944, 36198816, 36214080, 36225408, 36233312, 36249728, 36249760, 36249792, 36249824, 36249856, 36249888, 36261760, 36268992, 36279840, 36296640, 36304832, 36313568, 36313600, 36313632, 36313664, 36318400, 36326176, 35117920, 36345568, 36376960, 36379264, 36379296, 36379328, 36379360, 36379392, 36391040, 36405088, 35149312, 36422464, 36439840, 36448544, 36448576, 36448608, 36448640, 36448672, 36453952, 36458016, 36463776, 36475520, 36479488, 36482976, 36483008, 36483040, 36483072, 36483104, 36494080, 36500768, 36515648, 36522528, 36528992, 36536000, 36536032, 36548448, 36548480, 36548512, 36558336, 36689984, 37008704, 37442304, 0x23CDF80, 0x3845f80, 0x282df80 };

        private bool handleChanges = true;

		private bool lastConvType;

		private IContainer components;

		private NumericUpDown overlayBox;

		private Label label1;

		private Label label2;

		private Label label3;

		private TextBox idaAddress;

		private TextBox nsmbAddress;

		private Label label4;

		private TextBox offsetBox;
        private CheckBox checkBox1;
        private CheckBox onTop;

		public Form1()
		{
			this.InitializeComponent();
			this.updateOffset();
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void idaAddress_TextChanged(object sender, EventArgs e)
		{
			if (!this.handleChanges)
			{
				return;
			}
			int value = (int)this.overlayBox.Value;

            if (this.checkBox1.Checked)
                value = value += 131;

            if (value > overlay_starts.Length - 1)
                return;

            int overlayStartsIda = this.overlay_starts_ida[value] - this.overlay_starts[value];
			this.handleChanges = false;
			try
			{
				int num = this.intFromString(this.idaAddress.Text) - overlayStartsIda;
				if (num < 0)
				{
					num = 0;
				}
				this.nsmbAddress.Text = string.Concat("0x", num.ToString("X8"));
			}
			catch
			{
				this.nsmbAddress.Text = "";
			}
			this.handleChanges = true;
			this.lastConvType = false;
		}

		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.overlayBox = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.idaAddress = new System.Windows.Forms.TextBox();
            this.nsmbAddress = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.offsetBox = new System.Windows.Forms.TextBox();
            this.onTop = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.overlayBox)).BeginInit();
            this.SuspendLayout();
            // 
            // overlayBox
            // 
            this.overlayBox.Location = new System.Drawing.Point(100, 9);
            this.overlayBox.Maximum = new decimal(new int[] {
            130,
            0,
            0,
            0});
            this.overlayBox.Name = "overlayBox";
            this.overlayBox.Size = new System.Drawing.Size(100, 20);
            this.overlayBox.TabIndex = 0;
            this.overlayBox.ValueChanged += new System.EventHandler(this.overlayBox_ValueChanged);
            this.overlayBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.overlayBox_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Overlay ID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "IDA Address:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "NSMB Address:";
            // 
            // idaAddress
            // 
            this.idaAddress.Location = new System.Drawing.Point(100, 84);
            this.idaAddress.Name = "idaAddress";
            this.idaAddress.Size = new System.Drawing.Size(100, 20);
            this.idaAddress.TabIndex = 4;
            this.idaAddress.TextChanged += new System.EventHandler(this.idaAddress_TextChanged);
            // 
            // nsmbAddress
            // 
            this.nsmbAddress.Location = new System.Drawing.Point(100, 110);
            this.nsmbAddress.Name = "nsmbAddress";
            this.nsmbAddress.Size = new System.Drawing.Size(100, 20);
            this.nsmbAddress.TabIndex = 5;
            this.nsmbAddress.TextChanged += new System.EventHandler(this.nsmbAddress_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(56, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Offset:";
            // 
            // offsetBox
            // 
            this.offsetBox.Location = new System.Drawing.Point(100, 58);
            this.offsetBox.Name = "offsetBox";
            this.offsetBox.ReadOnly = true;
            this.offsetBox.Size = new System.Drawing.Size(100, 20);
            this.offsetBox.TabIndex = 4;
            this.offsetBox.TextChanged += new System.EventHandler(this.idaAddress_TextChanged);
            // 
            // onTop
            // 
            this.onTop.AutoSize = true;
            this.onTop.Location = new System.Drawing.Point(116, 136);
            this.onTop.Name = "onTop";
            this.onTop.Size = new System.Drawing.Size(84, 17);
            this.onTop.TabIndex = 6;
            this.onTop.Text = "Stay on Top";
            this.onTop.UseVisualStyleBackColor = true;
            this.onTop.CheckedChanged += new System.EventHandler(this.onTop_CheckedChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(92, 35);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(106, 17);
            this.checkBox1.TabIndex = 7;
            this.checkBox1.Text = "Is ARM7 Section";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(210, 170);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.onTop);
            this.Controls.Add(this.nsmbAddress);
            this.Controls.Add(this.offsetBox);
            this.Controls.Add(this.idaAddress);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.overlayBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.overlayBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		private int intFromDecString(string input)
		{
			return int.Parse(input, NumberStyles.Integer);
		}

		private int intFromHexString(string input)
		{
			if (input.StartsWith("0x"))
			{
				input = input.Substring(2);
				if (input.Length == 0)
				{
					input = "0";
				}
			}
			return int.Parse(input, NumberStyles.HexNumber);
		}

		private int intFromString(string input)
		{
            try
            {
                return Convert.ToInt32(input, 16);
            }
            catch (Exception)
            {
                return 0;
            }
		}

		private void nsmbAddress_TextChanged(object sender, EventArgs e)
		{
			if (!this.handleChanges)
			{
				return;
			}
			int value = (int)this.overlayBox.Value;

            if (this.checkBox1.Checked)
                value = value += 131;

            if (value > overlay_starts.Length -1)
                return;

            int overlayStartsIda = this.overlay_starts_ida[value] - this.overlay_starts[value];
			this.handleChanges = false;
			try
			{
				int num = this.intFromString(this.nsmbAddress.Text) + overlayStartsIda;
				if (num < 0)
				{
					num = 0;
				}
				this.idaAddress.Text = string.Concat("0x", num.ToString("X8"));
			}
			catch
			{
				this.idaAddress.Text = "";
			}
			this.handleChanges = true;
			this.lastConvType = true;
		}

		private void onTop_CheckedChanged(object sender, EventArgs e)
		{
			base.TopMost = this.onTop.Checked;
		}

		private void overlayBox_KeyUp(object sender, KeyEventArgs e)
		{
			this.overlayBox_ValueChanged(null, null);
		}

		private void overlayBox_ValueChanged(object sender, EventArgs e)
		{
			if (this.lastConvType)
			{
				this.nsmbAddress_TextChanged(null, null);
			}
			else
			{
				this.idaAddress_TextChanged(null, null);
			}
			this.updateOffset();
		}

		private void updateOffset()
		{
			int value = (int)this.overlayBox.Value;
            if (this.checkBox1.Checked)
                value = value += 131;

            if (value > overlay_starts.Length - 1)
            {
                this.offsetBox.Text = "Out of bounds!";
                return;
            }
            int overlayStartsIda = this.overlay_starts_ida[value] - this.overlay_starts[value];
			this.offsetBox.Text = string.Concat("0x", overlayStartsIda.ToString("X8"));
		}

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.lastConvType)
            {
                this.nsmbAddress_TextChanged(null, null);
            }
            else
            {
                this.idaAddress_TextChanged(null, null);
            }
            this.updateOffset();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}