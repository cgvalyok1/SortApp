namespace SortApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string inputFilePath = "D:\\�����\\�������� 2 ����\\SortApp\\SortApp\\input.txt";
            string outputFilePath = "D:\\�����\\�������� 2 ����\\SortApp\\SortApp\\output.txt";
            MergeSort.SortFile(inputFilePath, outputFilePath);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"��������� � ����������");
            //string inputFilePath = "D:\\�����\\�������� 2 ����\\SortApp\\SortApp\\input.txt";
            //string outputFilePath = "D:\\�����\\�������� 2 ����\\SortApp\\SortApp\\output.txt";
            //NaturalMergeSort.SortFile(inputFilePath, outputFilePath);
        }
    }
}