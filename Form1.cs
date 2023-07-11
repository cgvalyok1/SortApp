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
            string inputFilePath = "D:\\Учеба\\Курсовая 2 курс\\SortApp\\SortApp\\input.txt";
            string outputFilePath = "D:\\Учеба\\Курсовая 2 курс\\SortApp\\SortApp\\output.txt";
            MergeSort.SortFile(inputFilePath, outputFilePath);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Находится в разработке");
            //string inputFilePath = "D:\\Учеба\\Курсовая 2 курс\\SortApp\\SortApp\\input.txt";
            //string outputFilePath = "D:\\Учеба\\Курсовая 2 курс\\SortApp\\SortApp\\output.txt";
            //NaturalMergeSort.SortFile(inputFilePath, outputFilePath);
        }
    }
}