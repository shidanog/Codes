using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;

namespace BytesCopyTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        byte[] test_byte=new byte[26*14*256*5*256];
        byte[] test_dest = new byte[26 * 14 * 256 * 5 * 256];
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < test_byte.Length; i++)
            {
                test_byte[i] = 123;
            }
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Buffer.BlockCopy(test_byte, 0, test_dest, 0, test_byte.Length);
            sw.Stop();
            this.textBox1.Text = sw.Elapsed.Seconds.ToString()+":"+sw.Elapsed.Milliseconds.ToString();

        }
    }
}
