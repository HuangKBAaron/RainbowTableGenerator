
using System.Windows.Forms;


namespace RainbowTableGenerator
{


    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();
            NativeMethods.SetPlaceHolderText(this.txtNumDigits, "Num Digits");
        }


        private void btnPermute_Click(object sender, System.EventArgs e)
        {
            int digits;
            if (!System.Int32.TryParse(this.txtNumDigits.Text, out digits))
                digits = 2;

            this.dgvDisplayData.DataSource = Permute(digits);
        }


        public static string MD5(string input, System.Text.Encoding enc)
        {
            // step 1, calculate MD5 hash from input
            System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = enc.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }


        public System.Data.DataTable Permute(int digits)
        {
            this.txtNumDigits.Text = digits.ToString();

            System.Data.DataTable dt = new System.Data.DataTable();
            dt.Columns.Add("i", typeof(System.Numerics.BigInteger));
            dt.Columns.Add("Text", typeof(string));
            dt.Columns.Add("MD5-Hash (ASCII)", typeof(string));
            dt.Columns.Add("MD5-Hash (UTF8)", typeof(string));


            // char[] allowedAlphabet = new char[] { '0', '1'};
            // char[] allowedAlphabet = new char[] { '0', '1', '2'};
            // char[] allowedAlphabet = new char[] { 'a', 'b', 'c'};
            // char[] allowedAlphabet = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

            char[] allowedAlphabet = @"aåáàâäbcç¢deéèêëfghiïjklmnñoœóôöpqrsßtuûüvwxyzAÅÁÀÂÄBCÇ¢DEÉÈÊËFGHIÏJKLMNÑOŒÓÔÖPQRSTUÛÜVWXYZ#=+-_*°§%@¦|&!?.:;~^()[]{}<>\/€$£¬'`´""".ToCharArray();

            // Add reference to System.Numerics.dll
            System.Numerics.BigInteger numChars = allowedAlphabet.LongLength;
            
            // int nm = (int)System.Math.Pow(numChars, digits);
            System.Numerics.BigInteger nm = System.Numerics.BigInteger.Pow(numChars, digits);

            System.Data.DataRow dr = null;
            for (System.Numerics.BigInteger i = 0; i < nm; ++i)
            {

                // int decimalNumber = i;
                // int remainder;
                System.Numerics.BigInteger decimalNumber = i;
                System.Numerics.BigInteger remainder;

                string result = string.Empty;
                do
                {
                    // remainder = decimalNumber % numChars;
                    // decimalNumber /= numChars;
                    // result = remainder.ToString() + result;

                    remainder = System.Numerics.BigInteger.Remainder(decimalNumber, numChars);
                    decimalNumber = System.Numerics.BigInteger.Divide(decimalNumber, numChars);

                    int iRemain = (int)remainder;
                    result = allowedAlphabet[iRemain].ToString() + result;
                } while (decimalNumber > 0);


                dr = dt.NewRow();
                dr["i"] = i;
                dr["Text"] = result;
                dr["MD5-Hash (ASCII)"] = MD5(result, System.Text.Encoding.ASCII);
                dr["MD5-Hash (UTF8)"] = MD5(result, System.Text.Encoding.UTF8);

                dt.Rows.Add(dr);
                // System.Console.WriteLine("Combination:  {0}", result);
            } // Next i 

            System.Console.WriteLine("Finished {0} entries", dt.Rows.Count);
            System.Console.WriteLine(System.Environment.NewLine);

            return dt;
        } // End Function Permute


    }


}
