using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Amazon
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            trackBar1.Value = 5;
        }
        public int i = 2;
        public void FindBooks(string html, int amount) {
            HttpClientHandler handler = new HttpClientHandler()
            {
                AutomaticDecompression = DecompressionMethods.GZip,
            };

            using (var client = new HttpClient(handler))
            {
                using (HttpResponseMessage response = client.GetAsync(html).Result)
                {
                    using (HttpContent content = response.Content)
                    {
                        string htmlCode = content.ReadAsStringAsync().Result;

                        MatchCollection author = Regex.Matches(htmlCode, "<div class=\"product-author\">(\n|\r|\r\n).*?<a href=\".*?\" title=\"(.*?)\"");
                        MatchCollection name = Regex.Matches(htmlCode, "data-name=\"(.*?)\"");
                        MatchCollection price = Regex.Matches(htmlCode, "data-discount-price=\"(.*?)\"");
                        MatchCollection pubhouse = Regex.Matches(htmlCode, "data-pubhouse=\"(.*?)\"");
                        MatchCollection id = Regex.Matches(htmlCode, "data-product-id=\"(.*?)\"");
                        MatchCollection dir = Regex.Matches(htmlCode, "data-dir=\"(.*?)\"");
                        Match crawler = Regex.Match(htmlCode, ".*?\"pagination-next__text\" href=\"(.*?)\"");
                       
                        
                            for (int i = 0; i < Math.Min(amount, author.Count); i++)
                            {
                                ListViewItem item = new ListViewItem { Text = name[i].Groups[1].Value.ToString() };
                                item.SubItems.Add(author[i].Groups[2].Value);
                                item.SubItems.Add(price[i].Groups[1].Value.ToString());
                                item.SubItems.Add(pubhouse[i].Groups[1].Value.ToString());
                                string s = "https://www.labirint.ru/ebooks/10000623/";
                                s = s.Replace("ebooks", dir[i].Groups[1].Value.ToString());
                                s = s.Replace("10000623", id[i].Groups[1].Value.ToString());
                                item.SubItems.Add(s);
                                listView1.Items.Add(item);
                            }
                    }
                }
            }
            }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                listView1.Items.Clear();
                FindBooks("https://www.labirint.ru/search/python/?stype=0", trackBar1.Value);

                if (listView1.Items.Count == 60 && listView1.Items.Count < trackBar1.Value)
                {
                    while (listView1.Items.Count != trackBar1.Value)
                    {
                        string scrawler = "https://www.labirint.ru/search/python/?stype=0&page=" + i.ToString();
                        FindBooks(scrawler, trackBar1.Value - listView1.Items.Count); i++;
                    }
                }
            }
        }
        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
           System.Diagnostics.Process.Start(listView1.SelectedItems[0].SubItems[4].Text);
        }
        
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                listView1.Items.Clear();
                FindBooks("https://www.labirint.ru/search/c%23/?stype=0", trackBar1.Value);
                if (listView1.Items.Count == 60 && listView1.Items.Count < trackBar1.Value)
                {
                    while (listView1.Items.Count != trackBar1.Value)
                    {
                        string scrawler = "https://www.labirint.ru/search/c%23/?stype=0&page=" + i.ToString();
                        FindBooks(scrawler, trackBar1.Value - listView1.Items.Count); i++;
                    }
                }
            }
        }
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                listView1.Items.Clear();
                FindBooks("https://www.labirint.ru/search/Java/?stype=0", trackBar1.Value);
                if (listView1.Items.Count == 60 && listView1.Items.Count < trackBar1.Value)
                {
                    while (listView1.Items.Count != trackBar1.Value)
                    {
                        string scrawler = "https://www.labirint.ru/search/Java/?stype=0&page=" + i.ToString();
                        FindBooks(scrawler, trackBar1.Value - listView1.Items.Count); i++;
                    }
                }
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label3.Text = trackBar1.Value.ToString();
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton6.Checked)
            {
                listView1.Items.Clear();
                FindBooks("https://www.labirint.ru/search/php/?stype=0", trackBar1.Value);
                if (listView1.Items.Count == 60 && listView1.Items.Count < trackBar1.Value)
                {
                    while (listView1.Items.Count != trackBar1.Value)
                    {
                        string scrawler = "https://www.labirint.ru/search/php/?stype=0&page=" + i.ToString();
                        FindBooks(scrawler, trackBar1.Value - listView1.Items.Count); i++;
                    }
                }
            }
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton5.Checked)
            {
                listView1.Items.Clear();
                FindBooks("https://www.labirint.ru/search/c%2B%2B/?stype=0", trackBar1.Value);
                if (listView1.Items.Count == 60 && listView1.Items.Count < trackBar1.Value)
                {
                    while (listView1.Items.Count != trackBar1.Value)
                    {
                        string scrawler = "https://www.labirint.ru/search/c%2B%2B/?stype=0&page=" + i.ToString();
                        FindBooks(scrawler, trackBar1.Value - listView1.Items.Count); i++;
                    }
                }
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked)
            {
                listView1.Items.Clear();
                FindBooks("https://www.labirint.ru/search/kotlin%20программирование/?stype=0", trackBar1.Value);
                if (listView1.Items.Count == 60 && listView1.Items.Count < trackBar1.Value)
                {
                    try
                    {
                        while (listView1.Items.Count != trackBar1.Value)
                        {
                            string scrawler = "https://www.labirint.ru/search/kotlin%20программирование/?stype=0&page=" + i.ToString();
                            FindBooks(scrawler, trackBar1.Value - listView1.Items.Count); i++;
                        }
                    }
                    catch { }
                }
            }
            }

        private void radioButton9_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton9.Checked)
            {
                listView1.Items.Clear();
                FindBooks("https://www.labirint.ru/search/swift%20программирование/?stype=0", trackBar1.Value);
                if (listView1.Items.Count == 60 && listView1.Items.Count < trackBar1.Value)
                {
                    try
                    {
                        while (listView1.Items.Count != trackBar1.Value)
                        {
                            string scrawler = "https://www.labirint.ru/search/swift%20программирование/?stype=0&page=" + i.ToString();
                            FindBooks(scrawler, trackBar1.Value - listView1.Items.Count); i++;
                        }
                    }
                    catch { }
                }
            }
        }
        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton8.Checked)
            {
                listView1.Items.Clear();
                FindBooks("https://www.labirint.ru/search/pascal%20программирование/?stype=0", trackBar1.Value);
                if (listView1.Items.Count == 60 && listView1.Items.Count < trackBar1.Value)
                {
                    try
                    {
                        while (listView1.Items.Count != trackBar1.Value)
                        {
                            string scrawler = "https://www.labirint.ru/search/pascal%20программирование/?stype=0&page=" + i.ToString();
                            FindBooks(scrawler, trackBar1.Value - listView1.Items.Count); i++;
                        }
                    }
                    catch { }
                }
            }
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton7.Checked)
            {
                listView1.Items.Clear();
                FindBooks("https://www.labirint.ru/search/javascript/?stype=0", trackBar1.Value);
                if (listView1.Items.Count == 60 && listView1.Items.Count < trackBar1.Value)
                {
                    try
                    {
                        while (listView1.Items.Count != trackBar1.Value)
                        {
                            string scrawler = "https://www.labirint.ru/search/javascript/?stype=0&page=" + i.ToString();
                            FindBooks(scrawler, trackBar1.Value - listView1.Items.Count); i++;
                        }
                    }
                    catch { }
                }
            }
        }
    }
}
