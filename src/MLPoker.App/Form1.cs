using MLPoker.App.UseCases;

namespace MLPoker.App
{
    public partial class Form1 : Form
    {
        private readonly GetWindowScreenUseCase _useCaseScreen;
        private  GetWindowScreenUseCaseResponse _response = new GetWindowScreenUseCaseResponse();


        private string _orCC = "OR / C / C";
        private string _call = "CALL";
        private string _allIn = "ALL-IN";
        private string _fold = "FOLD";

        public Form1()
        {
            InitializeComponent();
            _useCaseScreen = new GetWindowScreenUseCase();
        }

        private void btnCapture_Click(object sender, EventArgs e)
        {
            _response = _useCaseScreen.Execute(new GetWindowScreenUseCaseRequest
            {

                //Path = @"C:\Code\MachineLearning\MLPoker\MLPoker.App\MLPoker.App\DataSet\Imagen_" + DateTime.Now.Ticks + ".jpg",
                Path = @"C:\Code\MachineLearning\MLPoker\MLPoker.App\MLPoker.App\DataSet\Cards\1.jpg",
                Path2 = @"C:\Code\MachineLearning\MLPoker\MLPoker.App\MLPoker.App\DataSet\Cards\Imagen_" + DateTime.Now.Ticks + ".jpg",

            });

            Thread.Sleep(100);
            //pbImage.Image = Image.FromFile(response.Path);


            var suited = string.Empty;
            suited = _response.Suited ? "s" : "o";
            lbCards.Text = $"{_response.Cards}{suited} - {_response.Position}";

        }

        private void btnWindow_Click(object sender, EventArgs e)
        {
            Thread.Sleep(2000);
            _useCaseScreen.Window();
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            gbAction1.Visible = false;
            gbAction2.Visible = false;
            gbAction3.Visible = false;
            gbAction4.Visible = false;
        }

        private void rbBTN_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rbSB_CheckedChanged(object sender, EventArgs e)
        {
            if (rbSB.Checked)
            {
                gbAction1.Visible = true;
                gbAction1.Text = "SB vs LIMP";

                gbAction2.Visible = true;
                gbAction2.Text = "SB vs OR";

                gbAction3.Visible = true;
                gbAction3.Text = "SB vs ALL-IN";

                var actions = GetSBActions(_response.Cards, _response.Suited);

                lbAction1_25.Text = actions.VsLimp25 == string.Empty ? _fold : actions.VsLimp25;
                lbAction1_20.Text = actions.VsLimp20 == string.Empty ? _fold : actions.VsLimp20;
                lbAction1_12.Text = actions.VsLimp12 == string.Empty ? _fold : actions.VsLimp12;
                lbAction1_10.Text = actions.VsLimp10 == string.Empty ? _fold : actions.VsLimp10;
                lbAction1_8.Text = actions.VsLimp8 == string.Empty ? _fold : actions.VsLimp8;

                //lbAction2_25.Text = actions.VsOpenRaise25 == string.Empty ? _fold : actions.VsOpenRaise25;
                //lbAction2_20.Text = actions.VsOpenRaise20 == string.Empty ? _fold : actions.VsOpenRaise20;
                //lbAction2_12.Text = actions.VsOpenRaise12 == string.Empty ? _fold : actions.VsOpenRaise12;
                //lbAction2_10.Text = actions.VsOpenRaise10 == string.Empty ? _fold : actions.VsOpenRaise10;
                //lbAction2_8.Text = actions.VsOpenRaise8 == string.Empty ? _fold : actions.VsOpenRaise8;

                //lbAction3_25.Text = actions.VsAllIn25 == string.Empty ? _fold : actions.VsAllIn25;
                //lbAction3_20.Text = actions.VsAllIn20 == string.Empty ? _fold : actions.VsAllIn20;
                //lbAction3_12.Text = actions.VsAllIn12 == string.Empty ? _fold : actions.VsAllIn12;
                //lbAction3_10.Text = actions.VsAllIn10 == string.Empty ? _fold : actions.VsAllIn10;
                //lbAction3_8.Text = actions.VsAllIn8 == string.Empty ? _fold : actions.VsAllIn8;
            }
        }

        private SbVsLimpActionResponse GetSBActions(string cards, bool suited)
        {
            var response = new SbVsLimpActionResponse();

            if (suited)
            {
                switch (cards)
                {
                    case "AA":
                        response.VsLimp25 = response.VsLimp20 = response.VsLimp12 = response.VsLimp10 = response.VsLimp8 = _orCC;
                        //response.VsOpenRaise25 = response.VsOpenRaise20 = response.VsOpenRaise12 = response.VsOpenRaise10 = response.VsOpenRaise8 = _orCC;
                        //response.VsAllIn25 = response.VsAllIn20 = response.VsAllIn12 = response.VsAllIn10 = response.VsAllIn8 = _call;
                        break;
                    case "AK":
                    case "AQ":
                    case "AJ":
                    case "AT":
                    case "A8":
                    case "A7":
                    case "A6":
                        response.VsLimp25 = response.VsLimp20 = response.VsLimp12 = response.VsLimp10 = response.VsLimp8 = _allIn;
                        //response.VsOpenRaise25 = response.VsOpenRaise20 = response.VsOpenRaise12 = response.VsOpenRaise10 = response.VsOpenRaise8 = _allIn;
                        //response.VsAllIn25 = response.VsAllIn20 = response.VsAllIn12 = response.VsAllIn10 = response.VsAllIn8 = _allIn;
                        break;
                    case "KQ":
                        response.VsLimp25 = _orCC;
                        response.VsLimp20 = _orCC;
                        response.VsLimp12 = response.VsLimp10 = response.VsLimp8 = _allIn;
                        //response.VsOpenRaise25 = response.VsOpenRaise20 = response.VsOpenRaise12 = response.VsOpenRaise10 = response.VsOpenRaise8 = _call;
                        //response.VsAllIn8 = _call;
                        break;
                    default:
                        break;
                }
            }
            else
            {
                switch (cards)
                {
                    case "AK":
                    case "AQ":
                    case "AJ":
                    case "AT":
                    case "A8":
                    case "A7":
                        response.VsLimp25 = response.VsLimp20 = response.VsLimp12 = response.VsLimp10 = response.VsLimp8 = _allIn;
                        //response.VsOpenRaise25 = response.VsOpenRaise20 = response.VsOpenRaise12 = response.VsOpenRaise10 = response.VsOpenRaise8 = _allIn;
                        //response.VsAllIn25 = response.VsAllIn20 = response.VsAllIn12 = response.VsAllIn10 = response.VsAllIn8 = _allIn;
                        break;
                    case "A6":
                    case "A5":
                    case "A4":
                    case "A3":
                    case "A2":
                        response.VsLimp25 = response.VsLimp20 = _call;
                        response.VsLimp12 = response.VsLimp10 = response.VsLimp8 = _allIn;
                        //response.VsOpenRaise25
                        break;

                    case "KQ":
                        response.VsLimp25 = _orCC;
                        response.VsLimp20 = _orCC;
                        response.VsLimp12 = response.VsLimp10 = response.VsLimp8 = _allIn;
                        //response.VsOpenRaise25 = response.VsOpenRaise20 = response.VsOpenRaise12 = response.VsOpenRaise10 = response.VsOpenRaise8 = _call;
                        //response.VsAllIn8 = _call;                        
                        break;
                    default:
                        break;
                }
            }

            return response;
        }

    }

    public class SbVsLimpActionResponse
    {
        public string VsLimp25 { get; set; } = string.Empty;
        public string VsLimp20 { get; set; } = string.Empty;
        public string VsLimp12 { get; set; } = string.Empty;
        public string VsLimp10 { get; set; } = string.Empty;
        public string VsLimp8 { get; set; } = string.Empty;        
    }

    public class SbVsOpenRaiseActionResponse
    {
        public string VsOpenRaise25 { get; set; } = string.Empty;
        public string VsOpenRaise20 { get; set; } = string.Empty;
        public string VsOpenRaise12 { get; set; } = string.Empty;
        public string VsOpenRaise10 { get; set; } = string.Empty;
        public string VsOpenRaise8 { get; set; } = string.Empty;
    }

    public class SbVsAllInActionResponse
    {
        public string VsAllIn25 { get; set; } = string.Empty;
        public string VsAllIn20 { get; set; } = string.Empty;
        public string VsAllIn12 { get; set; } = string.Empty;
        public string VsAllIn10 { get; set; } = string.Empty;
        public string VsAllIn8 { get; set; } = string.Empty;
    }
}