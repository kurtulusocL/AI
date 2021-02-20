
using SpeechLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Speech.Recognition;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YapayZekaTemelleir
{
    public partial class Form1 : Form
    {
        ApplicationDbContext _db;
        Person pers = new Person();

        public Form1()
        {
            InitializeComponent();
            _db = new ApplicationDbContext();
        }

        void Clear()
        {
            txtCountry.Clear();
            txtFather.Clear();
            txtMom.Clear();
            txtNameSurname.Clear();
            dtPickerBirthdate.ResetText();
            numKardes.ResetText();
            txtGender.Clear();
        }

        void FormLoad()
        {
            dtGridList.DataSource = _db.Persons.Select(i => new
            {
                i.Id,
                i.NameSurname,
                i.Gender,
                i.Brother,
                i.Country,
                i.Birthdate,
                i.FatherName,
                i.MomName
            }).OrderBy(i => i.Birthdate).ToList();
        }

        void ToolEnabled()
        {
            txtNameSurname.Enabled = false;
            txtMom.Enabled = false;
            txtGender.Enabled = false;
            txtFather.Enabled = false;
            txtCountry.Enabled = false;
            numKardes.Enabled = false;
            dtPickerBirthdate.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //FormLoad();
            ToolEnabled();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            pers.MomName = txtMom.Text;
            pers.NameSurname = txtNameSurname.Text;
            pers.FatherName = txtFather.Text;
            pers.Gender = txtGender.Text;
            pers.Country = txtCountry.Text;
            pers.Brother = Convert.ToInt32(numKardes.Value);
            pers.Birthdate = Convert.ToDateTime(dtPickerBirthdate.Value);

            _db.Persons.Add(pers);
            _db.SaveChanges();
            Clear();
            FormLoad();
        }

        private void btnSpeak_Click(object sender, EventArgs e)
        {
            SpeechRecognitionEngine sr = new SpeechRecognitionEngine();
            Grammar gramer = new DictationGrammar();
            sr.LoadGrammar(gramer);
            try
            {
                btnSpeak.Text = "Please, Speak!";
                sr.SetInputToDefaultAudioDevice();
                RecognitionResult result = sr.Recognize();
                richTextBox1.Text = result.Text;
            }
            catch (Exception)
            {
                btnSpeak.Text = "Error";
            }
        }

        private void btnListen_Click(object sender, EventArgs e)
        {
            SpVoice ses = new SpVoice();
            ses.Speak(richTextBox1.Text);
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (richTextBox1.Text == "Familiy List" || richTextBox1.Text == "Show Family")
            {
                FormLoad();
            }

            if (richTextBox1.Text == "Name Surname" && txtNameSurname.Enabled == true)
            {
                txtNameSurname.Focus();
                txtNameSurname.BackColor = Color.Green;
                if (txtNameSurname.Text==richTextBox1.Text)
                {
                    txtNameSurname.Text = richTextBox1.Text;
                    ToolEnabled();
                }
            }
            if (richTextBox1.Text == "Gender" && txtGender.Enabled == true)
            {
                txtGender.Focus();
                txtGender.BackColor = Color.Blue;
                if (txtGender.Text==richTextBox1.Text)
                {
                    txtGender.Text = richTextBox1.Text;
                    ToolEnabled();
                }
            }
            if (richTextBox1.Text == "Mom Name" && txtMom.Enabled == true)
            {
                txtMom.Focus();
                txtMom.BackColor = Color.Yellow;
                ToolEnabled();
            }
            if (richTextBox1.Text == "Father Name" && txtFather.Enabled == true)
            {
                txtFather.Focus();
                txtFather.BackColor = Color.Red;
                ToolEnabled();
            }
            if (richTextBox1.Text == "Country" && txtCountry.Enabled == true)
            {
                txtCountry.Focus();
                txtCountry.BackColor = Color.Maroon;
                ToolEnabled();
            }
            if (richTextBox1.Text == "Brother" && numKardes.Enabled == true)
            {
                numKardes.Focus();
                ToolEnabled();
            }
            if (richTextBox1.Text == "Birthdate" && dtPickerBirthdate.Enabled == true)
            {
                dtPickerBirthdate.Focus();
                ToolEnabled();
            }
            if (richTextBox1.Text == "Exit Application" || richTextBox1.Text == "Close Application")
            {
                Application.Exit();
            }
        }
    }
}
