using MLPoker.App.Helpers;
using MLPoker_App;
using System.Drawing.Imaging;

namespace MLPoker.App.UseCases
{

    public class GetWindowScreenUseCaseResponse
    {
        public string Players { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public bool Pair { get; set; } = false;
        public string Path { get; set; } = string.Empty;
        public bool Suited { get; set; } = false;
        public string Cards { get; set; } = string.Empty;

    }

    public class GetWindowScreenUseCaseRequest
    {
        public string Path { get; set; } = string.Empty;
        public string Path2 { get; set; } = string.Empty;
    }

    public class GetWindowScreenUseCase
    {
        private IntPtr _handle = IntPtr.Zero;

        public GetWindowScreenUseCaseResponse Execute(GetWindowScreenUseCaseRequest request)
        {
            var response = new GetWindowScreenUseCaseResponse();

            //Image img = CaptureScreenHelper.CaptureWindow(_handle);
            //Image img2 = CaptureScreenHelper.CaptureWindowByPosition(_handle);

            //img.Save(request.Path, ImageFormat.Jpeg);
            //img2.Save(request.Path2, ImageFormat.Jpeg);

            response.Path = request.Path2;
            response.Position = GetPositionModel(request.Path);
            //response.Pair = GetPairsModel(request.Path).Key;
            //response.Cards = GetPairsModel(request.Path).Value;
            response.Suited = GetSuitedModel(request.Path);

            //if(!response.Pair)
                response.Cards = GetAllCardsModel(request.Path);

            return response;
        }

        public void Window()
        {
            _handle = CaptureScreenHelper.User32.GetForegroundWindow();
        }

        private string GetPositionModel(string path)
        {
            //Load sample data
            var imageBytes = File.ReadAllBytes(path);
            PositionsModel.ModelInput sampleData = new PositionsModel.ModelInput()
            {
                ImageSource = imageBytes,
            };

            //Load model and predict output
            var result = PositionsModel.Predict(sampleData);

            return result.Score.Max() >= 0.98 ? result.PredictedLabel : string.Empty;


        }

        private KeyValuePair<bool, string> GetPairsModel(string path)
        {
            var response = false;

            //Load sample data
            var imageBytes = File.ReadAllBytes(path);
            PairsModel.ModelInput sampleData = new PairsModel.ModelInput()
            {
                ImageSource = imageBytes,
            };

            //Load model and predict output
            var result = PairsModel.Predict(sampleData);

            return result.Score.Max() >= 0.98 ? new KeyValuePair<bool, string>(true, result.PredictedLabel) : new KeyValuePair<bool, string>(false, string.Empty);

        }


        private bool GetSuitedModel(string path)
        {
            //Load sample data
            var imageBytes = File.ReadAllBytes(path);
            SuitedModel.ModelInput sampleData = new SuitedModel.ModelInput()
            {
                ImageSource = imageBytes,
            };

            //Load model and predict output
            var result = SuitedModel.Predict(sampleData);

            return result.PredictedLabel == "Suited" && result.Score.Max() >= 0.98 ? true : false;

        }

        private string GetAllCardsModel(string path)
        {
            //Load sample data
            var imageBytes = File.ReadAllBytes(path);
            AllCardsModel.ModelInput sampleData = new AllCardsModel.ModelInput()
            {
                ImageSource = imageBytes,
            };

            //Load model and predict output
            var result = AllCardsModel.Predict(sampleData);

            return result.PredictedLabel;

        }

        private void GetTwoModel(string path)
        {
            //Load sample data
            var imageBytes = File.ReadAllBytes(path);
            TwoModel.ModelInput sampleData = new TwoModel.ModelInput()
            {
                ImageSource = imageBytes,
            };

            //Load model and predict output
            var result = TwoModel.Predict(sampleData);

        }


        private void GetFourModel(string path)
        {
            //Load sample data
            var imageBytes = File.ReadAllBytes(path);
            FourModel.ModelInput sampleData = new FourModel.ModelInput()
            {
                ImageSource = imageBytes,
            };

            //Load model and predict output
            var result = FourModel.Predict(sampleData);

        }

        private void GetThreeModel(string path)
        {
            //Load sample data
            var imageBytes = File.ReadAllBytes(path);
            TrheeModel.ModelInput sampleData = new TrheeModel.ModelInput()
            {
                ImageSource = imageBytes,
            };

            //Load model and predict output
            var result = TrheeModel.Predict(sampleData);

        }
        private void GetFiveModel(string path)
        {
            //Load sample data
            var imageBytes = File.ReadAllBytes(path);
            FiveModel.ModelInput sampleData = new FiveModel.ModelInput()
            {
                ImageSource = imageBytes,
            };

            //Load model and predict output
            var result = FiveModel.Predict(sampleData);


        }

        private void GetSixModel(string path)
        {
            //Load sample data
            var imageBytes = File.ReadAllBytes(path);
            SixModel.ModelInput sampleData = new SixModel.ModelInput()
            {
                ImageSource = imageBytes,
            };

            //Load model and predict output
            var result = SixModel.Predict(sampleData);

        }

        public void GetSevenModel(string path)
        {
            //Load sample data
            var imageBytes = File.ReadAllBytes(path);
            SevenModel.ModelInput sampleData = new SevenModel.ModelInput()
            {
                ImageSource = imageBytes,
            };

            //Load model and predict output
            var result = SevenModel.Predict(sampleData);

        }

        public void GetEightModel(string path)
        {
            //Load sample data
            var imageBytes = File.ReadAllBytes(path);
            EightModel.ModelInput sampleData = new EightModel.ModelInput()
            {
                ImageSource = imageBytes,
            };

            //Load model and predict output
            var result = EightModel.Predict(sampleData);

        }

        public void GetNineModel(string path)
        {
            //Load sample data
            var imageBytes = File.ReadAllBytes(path);
            NineModel.ModelInput sampleData = new NineModel.ModelInput()
            {
                ImageSource = imageBytes,
            };

            //Load model and predict output
            var result = NineModel.Predict(sampleData);

        }

        public void GetTenModel(string path)
        {
            //Load sample data
            var imageBytes = File.ReadAllBytes(path);
            TenModel.ModelInput sampleData = new TenModel.ModelInput()
            {
                ImageSource = imageBytes,
            };

            //Load model and predict output
            var result = TenModel.Predict(sampleData);

        }

        public void GetJackModel(string path)
        {
            //Load sample data
            var imageBytes = File.ReadAllBytes(path);
            JackModel.ModelInput sampleData = new JackModel.ModelInput()
            {
                ImageSource = imageBytes,
            };

            //Load model and predict output
            var result = JackModel.Predict(sampleData);

        }

        public void GetDameModel(string path)
        {
            //Load sample data
            var imageBytes = File.ReadAllBytes(path);
            DameModel.ModelInput sampleData = new DameModel.ModelInput()
            {
                ImageSource = imageBytes,
            };

            //Load model and predict output
            var result = DameModel.Predict(sampleData);

        }

        private void GetKingModel(string path)
        {
            //Load sample data
            var imageBytes = File.ReadAllBytes(path);
            KingModel.ModelInput sampleData = new KingModel.ModelInput()
            {
                ImageSource = imageBytes,
            };

            //Load model and predict output
            var result = KingModel.Predict(sampleData);

        }

        private void GetAsModel(string path)
        {
            //Load sample data
            var imageBytes = File.ReadAllBytes(path);
            AsModel.ModelInput sampleData = new AsModel.ModelInput()
            {
                ImageSource = imageBytes,
            };

            //Load model and predict output
            var result = AsModel.Predict(sampleData);

        }
    }

   



}
