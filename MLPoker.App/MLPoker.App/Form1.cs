using MLPoker.App.UseCases;

namespace MLPoker.App
{
    public partial class Form1 : Form
    {
        private readonly GetWindowScreenUseCase _useCaseScreen;

        public Form1()
        {
            InitializeComponent();
            _useCaseScreen = new GetWindowScreenUseCase();
        }

        private void btnCapture_Click(object sender, EventArgs e)
        {
            var response = _useCaseScreen.Execute(new GetWindowScreenUseCaseRequest { Path = @"C:\Code\MachineLearning\MLPoker\MLPoker.App\MLPoker.App\DataSet\Imagen_" + DateTime.Now.Ticks + ".jpg" });

            Thread.Sleep(100);
            pbImage.Image = Image.FromFile(response.Path);

        }

        private void btnWindow_Click(object sender, EventArgs e)
        {
            Thread.Sleep(2000);
            _useCaseScreen.Window();
        }
    }
}