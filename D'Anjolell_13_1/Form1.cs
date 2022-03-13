using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace D_Anjolell_13_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            //Richard D'Anjolell
            //Declare Variables
            var stringFile = File.ReadAllLines("..\\..\\random.txt");
            var stringList = new List<string>(stringFile);
            List<int> numList = new List<int>();

            // Create a Predicate to determine whether a number is base (between 1 and 10)
            Predicate<int> IsBase = delegate (int x)
            {
                bool isBaseNumber = false;

                if (x >= 1 && x <= 10)
                {
                    isBaseNumber = true;
                }

                return isBaseNumber;
            };

            //Turns string list into int list
            foreach (string i in stringList)
            {
                numList.Add(int.Parse(i));
            }

            // Find all of the base numbers in the list
            List<int> baseNum = numList.FindAll(IsBase);

            //Clears list box each time before filling it up
            lstBxResults.Items.Clear();
            // Display the base numbers in list box
            foreach (int i in baseNum)
            {
                lstBxResults.Items.Add(i);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            //Declare Variables
            var stringFile = File.ReadAllLines("..\\..\\random.txt");
            var stringList = new List<string>(stringFile);
            List<int> numList = new List<int>();

            //Turns string list into int list
            foreach (string i in stringList)
            {
                numList.Add(int.Parse(i));
            }

            // Remove all the elements containing a negative value.
            numList.RemoveAll(x => x < 0);

            //Clears list box each time before filling it up
            lstBxResults.Items.Clear();
            // Display positive numbers in list box
            numList.ForEach(x => lstBxResults.Items.Add(x));
        }
    }
}
