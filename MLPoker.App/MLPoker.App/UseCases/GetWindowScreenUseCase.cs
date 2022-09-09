using MLPoker.App.Helpers;
using System.Drawing.Imaging;

namespace MLPoker.App.UseCases
{

    public class GetWindowScreenUseCaseResponse
    {
        public string Players { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public string Pair { get; set; } = string.Empty;
        public string Path { get; set; } = string.Empty;
        public bool Suited { get; set; } = false;


    }

    public class GetWindowScreenUseCaseRequest
    {
        public string Path { get; set; } = string.Empty;
    }

    public class GetWindowScreenUseCase
    {
        private IntPtr _handle = IntPtr.Zero;

        public GetWindowScreenUseCaseResponse Execute(GetWindowScreenUseCaseRequest request)
        {
            var response = new GetWindowScreenUseCaseResponse();

            Image img = CaptureScreenHelper.CaptureWindow(_handle);
            img.Save(request.Path, ImageFormat.Jpeg);

            response.Path = request.Path;

            return response;
        }

        public void Window()
        {
            _handle = CaptureScreenHelper.User32.GetForegroundWindow();
        }

    }

    

}
