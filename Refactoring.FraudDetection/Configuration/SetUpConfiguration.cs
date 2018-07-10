using Payvision.CodeChallenge.Refactoring.FraudDetection.Dtos;
using Payvision.CodeChallenge.Refactoring.FraudDetection.Services;
using Payvision.CodeChallenge.Refactoring.FraudDetection.Wrapper;
using Unity;

namespace Payvision.CodeChallenge.Refactoring.FraudDetection.Configuration
{
    public  class SetUpConfiguration
    {
        public SetUpConfiguration()
        {
            IUnityContainer unitycontainer = new UnityContainer();

            unitycontainer.RegisterInstance<IFileIo>(FileIo.Instance);
            unitycontainer.RegisterInstance<ISettings>(Settings.Instance);

            unitycontainer.RegisterType<IDirectoryWrapper, DirectoryWrapper>();
            unitycontainer.RegisterType<IFraudResult, FraudResult>();
            unitycontainer.RegisterType<IFraudRadar, FraudRadar>();

            unitycontainer.RegisterType<ICheckFraudService, CheckFraudService>();
            unitycontainer.RegisterType<IOrderNormalizationService, OrderNormalizationService>();


        }
    }
}
